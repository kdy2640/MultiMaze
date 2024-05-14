using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.Xml.Schema;
using System.Net.Http.Headers;
using static MazeClient.ServerManager;
using MazeClient.Share;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Threading;
using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static MazeClient.WaitScene;

namespace MazeClient
{
    class ServerManager
    {
        GameManager Manager;
        public Socket ServerSocket;
        public ReceiveCallback callbackFunctions;
        string ServerIP = "127.0.0.1";

        const int HEADER_BYTE = 6;
        //읽기전용
        public int Now_Player_Num
        {
            get
            {
                int count = 0; 
                for (int i = 0; i < 4; i++)
                {
                    if (PlayerConnectArray[i] == true) count++;
                }
                return count;
            } 
        }
        public bool[] PlayerConnectArray { get; set; }
         

        public delegate void ReceiveCompleteFunction(byte[] buffer, ServerEvent serverEvent);
        public ServerManager()
        {
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            callbackFunctions = new ReceiveCallback(); PlayerConnectArray = new bool[4];

        }
        #region 서버 연결


        // 서버 연결 시도
        public async Task<bool> ConnectServer(string ip, int port)
        {
            Manager = GameManager.Instance;
            try
            {
                // 소켓 생성
                ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ip), port);

                await ServerSocket.ConnectAsync(endPoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"연결 실패: {ex.Message}");
                return false;
            }

            // 플레이어 번호 수신
            byte[] buffer = new byte[8];
            ArraySegment<byte> playerNumberBuffer = new ArraySegment<byte>(buffer);
            bool result = await ReceiveWithTimeOut(playerNumberBuffer);
            if (result == false) return false;
            // 플레이어 번호 할당
            short playerNumber = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(buffer, 0));
            Manager.PlayerCode = playerNumber;

            MessageBox.Show($"연결 성공: 플레이어 번호는 {playerNumber} 입니다.");
            PlayerConnectArray[playerNumber - 1] = true;

            // 지속적으로 수신
            ReceiveFromServer();

            return true;
        }
        private async Task<bool> ReceiveWithTimeOut(ArraySegment<byte> buffer)
        {
            Task<int> receiveTask = ServerSocket.ReceiveAsync(buffer, SocketFlags.None); // 수신
            Task delayTask = Task.Delay(3000); // 기다림
            Task completedTask = await Task.WhenAny(receiveTask, delayTask); // 하나라도 완료되면 반환

            if (completedTask == receiveTask) // 수신이 먼저
            {
                return true; // 수신 성공
            }
            else // 딜레이가 먼저
            {
                return false; // 타임아웃
            }

        }
        #endregion 서버 연결

        #region 서버 송신
        //serverEvent에는 ServerEvent를 상속받은 각자의 클래스 객체를 input
        public async Task SendToServerAsync(byte[] buffer, ServerEvent serverEvent)
        {
            try
            {
                // 헤더 생성
                byte[] headerBuffer;
                AddHeaderToBuffer(buffer, (int)serverEvent.GameStatus, serverEvent.EventType, out headerBuffer);

                // 배열 세그먼트 생성
                ArraySegment<byte> headerSegment = new ArraySegment<byte>(headerBuffer);

                // 비동기 송신
                int bytesSent = await ServerSocket.SendAsync(headerSegment, SocketFlags.None);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception Occur: {ex.Message}");
            }
        }
        #endregion 서버 송신


        #region 서버 수신
        internal class ReceiveArguments
        {
            public Socket Socket; // 서버 소켓
            public byte[] Buffer; // 헤더 버퍼
            public int ReceiveCount; // 현재까지 모은 바이트
            public int MaxSize; // 목표 사이즈
            public ServerEvent ServerEvent; // 서버이벤트
            public ReceiveArguments(Socket socket, byte[] buffer, int receiveCount, int maxSize, ServerEvent serverEvent)
            {
                Socket = socket;
                Buffer = buffer;
                ReceiveCount = receiveCount;
                MaxSize = maxSize;
                ServerEvent = serverEvent;
            }
        }

        /// <summary>
        /// 한번 작동하면 지속적으로 작동합니다. 씬이 바뀔시에 다시 호출해야합니다.
        /// </summary>
        /// <returns></returns>
        private async Task ReceiveFromServer()
        {
            byte[] headerBuffer = new byte[HEADER_BYTE]; // 헤더는 6바이트
            ReceiveArguments receiveArgs = new ReceiveArguments(ServerSocket, headerBuffer, 0, HEADER_BYTE, new ServerEvent()); // 인자 생성
            await ReceiveHeader(receiveArgs); // 비동기 헤더 수신
        }
        // 비동기 헤더 수신
        private async Task ReceiveHeader(ReceiveArguments receiveArgs)
        {
            try
            {
                // 바이트 까지 데이터 수신
                 while (receiveArgs.ReceiveCount < receiveArgs.MaxSize)
                {
                    // 세그먼트 생성
                    ArraySegment<byte> bufferSegment = new ArraySegment<byte>(receiveArgs.Buffer, receiveArgs.ReceiveCount, receiveArgs.MaxSize -receiveArgs.ReceiveCount);
                    int receivedBytes = await receiveArgs.Socket.ReceiveAsync(bufferSegment); // 수신
                    if (receivedBytes == 0)
                    {
                        throw new Exception("disconnected");
                    }
                    receiveArgs.ReceiveCount += receivedBytes;

                }

                // 헤더 해석
                int dataLength; int gameStatus; int eventType;
                GetHeaderFromBuffer(receiveArgs.Buffer, out dataLength, out gameStatus, out eventType);

                // 데이터 수신
                ReceiveArguments newReceiveArgs = new ReceiveArguments(receiveArgs.Socket, new byte[dataLength], 0, dataLength, new ServerEvent(gameStatus, eventType));
                await ReceiveData(newReceiveArgs);
           
            
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception Occur: {ex.Message}");
           
            }
        }

        private async Task ReceiveData(ReceiveArguments receiveArgs)
        {
            try
            {

                //목표까지 데이터 수신
                while (receiveArgs.ReceiveCount < receiveArgs.MaxSize)
                {
                    var bufferSegment = new ArraySegment<byte>(receiveArgs.Buffer, receiveArgs.ReceiveCount, receiveArgs.MaxSize - receiveArgs.ReceiveCount);
                    int receivedBytes = await receiveArgs.Socket.ReceiveAsync(bufferSegment, SocketFlags.None);
                    if (receivedBytes == 0)
                    {
                        throw new Exception("disconnected");
                    }
                    receiveArgs.ReceiveCount += receivedBytes;

                }
                 
                ReceiveCompleted(receiveArgs.Buffer, receiveArgs.ServerEvent); 


                // 헤더 재수신 준비
                byte[] headerBuffer = new byte[6];
                ReceiveArguments newHeaderArgs = new ReceiveArguments(receiveArgs.Socket, headerBuffer, 0, 6, new ServerEvent());
                await ReceiveHeader(newHeaderArgs);
         
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception Occur: {ex.Message}");

            }
        }


        #endregion 서버 수신




        //delegate 예시
        public void TempSceneCallBackFunction(byte[] buffer,ServerEvent serverEvent)
        {
            TempSceneServerEvent Event = serverEvent as TempSceneServerEvent;
            if(Event != null) { return; }
            //GameStatus 확인
            if (serverEvent.GameStatus != Define.GameState.GameOverScene) return; 
            switch(serverEvent.EventType)
            {
                case 1:
                    break;
                case 2:
                    break;
            }
        } 

        private async void ReceiveCompleted(byte[] buffer, ServerEvent serverEvent)
        {
            if (serverEvent.GameStatus != Manager.state) return;
            switch(serverEvent.GameStatus)
            {
                case Define.GameState.MainScene:
                    callbackFunctions.MainSceneCallBack?.Invoke(buffer, serverEvent);
                    break;
                case Define.GameState.SettingScene:
                    callbackFunctions.SettingSceneCallBack?.Invoke(buffer, serverEvent);
                    break;
                case Define.GameState.WaitScene:
                    callbackFunctions.WaitSceneCallBack?.Invoke(buffer, serverEvent);
                    break;
                case Define.GameState.InGameScene:
                    callbackFunctions.InGameSceneCallBack?.Invoke(buffer, serverEvent);
                    break;
                case Define.GameState.RoundOverScene:
                    callbackFunctions.RoundOverSceneCallBack?.Invoke(buffer, serverEvent);
                    break;
                case Define.GameState.GameOverScene:
                    callbackFunctions.GameOverSceneCallBack?.Invoke(buffer, serverEvent);
                    break;
                default:
                    break;
            }
        }




        // 서버 연결 끊기
        public void CloseServer()
        {

        }

        private void AddHeaderToBuffer(byte[] buffer, int gameStatus, int serverEventType, out byte[] resultBuffer)
        {

            //직렬화
            resultBuffer = new byte[6 + buffer.Length];
            byte[] dataSize = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)buffer.Length));
            byte[] statusSize = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)gameStatus));
            byte[] eventTypeSize = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)serverEventType));

            //배열 생성
            Array.Copy(dataSize, 0, resultBuffer, 0, dataSize.Length);
            Array.Copy(statusSize, 0, resultBuffer, 2, statusSize.Length);
            Array.Copy(eventTypeSize, 0, resultBuffer, 4, eventTypeSize.Length);
            Array.Copy(buffer, 0, resultBuffer, 6, buffer.Length);

        }

        private void GetHeaderFromBuffer(byte[] headerBuffer,out int dataLength, out int gameStatus,  out int serverEventType)
        {
            byte[] data = new byte[2];
            byte[] statusSize  = new byte[2];
            byte[] eventTypeSize = new byte[2];

            //배열 복사
            Array.Copy(headerBuffer, 0, data, 0, 2);
            Array.Copy(headerBuffer, 2, statusSize, 0, 2);
            Array.Copy(headerBuffer, 4, eventTypeSize, 0, 2);

            dataLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(data, 0));
            gameStatus = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(statusSize, 0));
            serverEventType = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(eventTypeSize, 0));

        }


        public bool StartServer()
        {
            try
            {
                //서버 프로그램 실행
                Process process = new Process();
                string name="";
                if (File.Exists("MazeServer.exe")) name = "MazeServer.exe";
                if (File.Exists("..\\..\\..\\..\\MazeServer\\bin\\Release\\net8.0-windows\\MazeServer.exe"))
                { name = "..\\..\\..\\..\\MazeServer\\bin\\Release\\net8.0-windows\\MazeServer.exe"; }
                process.StartInfo.FileName = name;
                process.Start();
            }
            catch
            {
                return false;
            }
            return true;
        }

    }

    class ReceiveCallback
    {
        public ReceiveCompleteFunction? MainSceneCallBack;
        public ReceiveCompleteFunction? SettingSceneCallBack;
        public ReceiveCompleteFunction? WaitSceneCallBack;
        public ReceiveCompleteFunction? InGameSceneCallBack;
        public ReceiveCompleteFunction? RoundOverSceneCallBack;
        public ReceiveCompleteFunction? GameOverSceneCallBack;
    }
}
