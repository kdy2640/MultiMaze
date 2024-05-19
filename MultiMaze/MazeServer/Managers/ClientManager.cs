using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using MazeClient.Share;
namespace MazeServer
{
    public class ClientManager
    {
        public int max_Player_Num = ServerGameManager.MAX_PLAYER_NUM;
        const int HEADER_BYTE = 6;
          
        public int Now_Player_Num = 0;
        public Player[] PlayerArray = new Player[4];
        public int HostPlayerNum = 1;
        public bool isGameStart = false;

        ServerGameManager Manager;
        public ReceiveCallback callbackFunctions;
        public DisconnectedRecallFunction disconnectedRecallFunction;
        public delegate void DisconnectedRecallFunction(int playerCode);
        public delegate void ReceiveCompleteFunction(byte[] buffer, ServerEvent serverEvent,int sender);
        public ClientManager()
        { 
            callbackFunctions = new ReceiveCallback();
            for (int i = 0; i < 4; i++)
            {
                PlayerArray[i] = new Player();
                PlayerArray[i].isExist = false;
            }
        }


        #region 플레이어 대기
        public async Task WaitForPlayer()
        {
            Manager = ServerGameManager.Instance; 
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("0.0.0.0"), 20000);

            serverSocket.Bind(endPoint);
            serverSocket.Listen(max_Player_Num);

            while (isGameStart == false)
            {
                Socket clientSocket = await serverSocket.AcceptAsync(); 
                if((Now_Player_Num >= max_Player_Num) || (isGameStart == true))
                {
                    continue;   
                }
                Player newPlayer = new Player(); newPlayer.clientSocket = clientSocket; newPlayer.isExist = true;
                int blankIndex = 0;
                for (int i = 0; i < 4; i++)
                {
                    if (PlayerArray[i].isExist == false)
                    {
                        blankIndex = i; break;  
                    }
                }
                PlayerArray[blankIndex] = newPlayer;
                Now_Player_Num++;


                Manager.ServerScene.SetLog($"{blankIndex + 1}번 플레이어와 연결되었습니다.");
                // 클라이언트에게 플레이어 번호 부여
                int playerNumber = blankIndex + 1;
                byte[] buffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)playerNumber));
                await clientSocket.SendAsync(new ArraySegment<byte>(buffer));


                // 지속적으로 수신 시작
                ReceiveFromPlayer(clientSocket,playerNumber);
            }



        }
        
        private void removePlayer(int playercode)
        {
            PlayerArray[playercode - 1].isExist = false;
            if(playercode == HostPlayerNum)
            {
                for (int i = 0; i < 4; i++)
                {
                    if(PlayerArray[i].isExist == true)
                    {
                        HostPlayerNum = i + 1;
                        break;
                    }
                }
            }
            disconnectedRecallFunction.Invoke(playercode);
            Now_Player_Num--;
            if(Now_Player_Num == 0 && isGameStart)
            {
                Manager.ServerScene.shutDownServerBtn.PerformClick();
            }
        }
        #endregion

        #region 플레이어 송신
        /// <summary>
        /// 모든 플레이어에게 송신하는 함수.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="serverEvent"></param>
        public void SendToAllPlayers(byte[] buffer, ServerEvent serverEvent)
        {
            for (int i = 0; i < max_Player_Num; i++)
            {
                if (PlayerArray[i].isExist == false) { continue; }
                SendToPlayer(buffer, serverEvent, i+1);
            }
        }
        /// <summary>
        /// 특정 플레이어에게 송신하는 함수. 플레이어 번호는 1, 2 순서 입니다.
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="serverEvent"></param>
        /// <param name="playerNumber"></param>
        public async Task SendToPlayer(byte[] buffer, ServerEvent serverEvent, int playerNumber)
        {
            if (PlayerArray[playerNumber - 1].isExist == false) { return; }
            Socket clientSocket = PlayerArray[playerNumber - 1].clientSocket;
            try
            {
                // 헤더 생성
                byte[] headerBuffer;
                AddHeaderToBuffer(buffer, (int)serverEvent.GameStatus, serverEvent.EventType, out headerBuffer);

                // 배열 세그먼트 생성
                ArraySegment<byte> headerSegment = new ArraySegment<byte>(headerBuffer);

                // 비동기 송신
                int bytesSent = await clientSocket.SendAsync(headerSegment, SocketFlags.None);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception Occur: {ex.Message}");
            }
        }
        #endregion

        #region 플레이어 수신
        private class ReceiveArguments
        {
            public Socket Socket; // 서버 소켓
            public byte[] Buffer; // 헤더 버퍼
            public int ReceiveCount; // 현재까지 모은 바이트
            public int MaxSize; // 목표 사이즈
            public ServerEvent ServerEvent; // 서버이벤트
            public int PlayerCode; // 플레이어 번호
            public ReceiveArguments(Socket socket, byte[] buffer, int receiveCount, int maxSize, ServerEvent serverEvent, int playerCode)
            {
                Socket = socket;
                Buffer = buffer;
                ReceiveCount = receiveCount;
                MaxSize = maxSize;
                ServerEvent = serverEvent;
                PlayerCode = playerCode;
            }
        }
        // receive는 연결 이후에 계속 반복되므로 직접적으로 사용하지 않습니다.
        private async void ReceiveFromPlayer(Socket clientSocket, int playerCode)
        {
            byte[] headerBuffer = new byte[HEADER_BYTE]; // 헤더는 6바이트
            ReceiveArguments receiveArgs = new ReceiveArguments(clientSocket, headerBuffer, 0, HEADER_BYTE, new ServerEvent(), playerCode); // 인자 생성
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
                    ArraySegment<byte> bufferSegment = new ArraySegment<byte>(receiveArgs.Buffer, receiveArgs.ReceiveCount, receiveArgs.MaxSize - receiveArgs.ReceiveCount);
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
                ReceiveArguments newReceiveArgs = new ReceiveArguments(receiveArgs.Socket, new byte[dataLength], 0, dataLength, new ServerEvent(gameStatus, eventType), receiveArgs.PlayerCode);
                await ReceiveData(newReceiveArgs);


            }
            catch (Exception ex)
            {
                Manager.ServerScene.SetLog($"{receiveArgs.PlayerCode}번 플레이어의 연결이 끊어졌습니다. : {ex.Message}");
                removePlayer(receiveArgs.PlayerCode);
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


                // 데이터 수신 완료 후 콜백 함수 호출
                ReceiveCompleted(receiveArgs.Buffer, receiveArgs.ServerEvent, receiveArgs.PlayerCode);

                // 헤더 재수신 준비
                byte[] headerBuffer = new byte[6];
                ReceiveArguments newHeaderArgs = new ReceiveArguments(receiveArgs.Socket, headerBuffer, 0, 6, new ServerEvent(), receiveArgs.PlayerCode);
                await ReceiveHeader(newHeaderArgs);

            }
            catch (Exception ex)
            {
                Manager.ServerScene.SetLog($"{receiveArgs.PlayerCode}번 플레이어의 연결이 끊어졌습니다. : {ex.Message}");
                removePlayer(receiveArgs.PlayerCode);
            }
        }
        #endregion

        #region 해더생성 및 파싱
        private void ReceiveCompleted(byte[] buffer, ServerEvent serverEvent, int playerCode)
        {
            switch (serverEvent.GameStatus)
            {
                case Define.GameState.MainScene:
                    callbackFunctions.MainSceneCallBack?.Invoke(buffer, serverEvent, playerCode);
                    break;
                case Define.GameState.SettingScene:
                    callbackFunctions.SettingSceneCallBack?.Invoke(buffer, serverEvent, playerCode);
                    break;
                case Define.GameState.WaitScene:
                    callbackFunctions.WaitSceneCallBack?.Invoke(buffer, serverEvent, playerCode);
                    break;
                case Define.GameState.InGameScene:
                    callbackFunctions.InGameSceneCallBack?.Invoke(buffer, serverEvent, playerCode);
                    break;
                case Define.GameState.RoundOverScene:
                    callbackFunctions.RoundOverSceneCallBack?.Invoke(buffer, serverEvent, playerCode);
                    break;
                case Define.GameState.GameOverScene:
                    callbackFunctions.GameOverSceneCallBack?.Invoke(buffer, serverEvent, playerCode);
                    break;
                default:
                    break;
            }
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

        private void GetHeaderFromBuffer(byte[] headerBuffer, out int dataLength, out int gameStatus, out int serverEventType)
        {
            byte[] data = new byte[2];
            byte[] statusSize = new byte[2];
            byte[] eventTypeSize = new byte[2];

            //배열 복사
            Array.Copy(headerBuffer, 0, data, 0, 2);
            Array.Copy(headerBuffer, 2, statusSize, 0, 2);
            Array.Copy(headerBuffer, 4, eventTypeSize, 0, 2);

            dataLength = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(data, 0));
            gameStatus = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(statusSize, 0));
            serverEventType = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(eventTypeSize, 0));

        }
        public class ReceiveCallback
        {
            public ReceiveCompleteFunction? MainSceneCallBack;
            public ReceiveCompleteFunction? SettingSceneCallBack;
            public ReceiveCompleteFunction? WaitSceneCallBack;
            public ReceiveCompleteFunction? InGameSceneCallBack;
            public ReceiveCompleteFunction? RoundOverSceneCallBack;
            public ReceiveCompleteFunction? GameOverSceneCallBack;
        }
        #endregion


    }
}