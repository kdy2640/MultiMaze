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

namespace MazeClient
{
    class ServerManager
    {
        Socket ServerSocket;
        string ServerIP = "127.0.0.1";
        public delegate void ReceiveCompleteFunction(byte[] buffer, int count, ServerEvent serverEvent);
        public ServerManager()
        {
            ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


        }

        //serverEvent에는 ServerEvent를 상속받은 각자의 클래스 객체를 input
        public void SendToServer(byte[] buffer, int count, ServerEvent serverEvent)
        {

        }

        // 한번 실행되면 비동기로 계속 실행.
        public void receiveFromServer(ReceiveCompleteFunction receiveCompleteFunction)
        {

        }

        //delegate 예시
        public void temp(byte[] buffer, int count, ServerEvent serverEvent)
        {
            TempSceneServerEvent Event = serverEvent as TempSceneServerEvent;
            if(Event != null) { return; }
            //GameStatus 확인
            if (serverEvent.GameStatus != Define.GameState.GameOverScene) return; 
            switch(Event.EventType)
            {
                case TempSceneServerEvent.TempSceneServerEventType.temp1:
                    break;
                case TempSceneServerEvent.TempSceneServerEventType.temp2:
                    break;
            }
        }



        /// v 당장 못 씀 연결 확인용
        public void ConnectCompleted2(IAsyncResult ar)
        {
              ServerSocket = (Socket)ar.AsyncState;

              MessageBox.Show("클라 - 연결완료");
         }


        public void ConnectServer()
        {
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(ServerIP), 20000);
            clientSocket.BeginConnect(endPoint, ConnectCompleted2, clientSocket);
        }


        public void SendCompleted2(IAsyncResult ar)
        {

            Socket serverSocket = (Socket)ar.AsyncState;
            serverSocket.EndSend(ar);

            string str = Console.ReadLine();
            if (str == "exit")
            {
                Console.WriteLine("연결 종료");
                serverSocket.Dispose();
                return;
            }

            byte[] buffer = Encoding.UTF8.GetBytes(str);
            serverSocket.BeginSend(buffer, 0, buffer.Length, SocketFlags.None, SendCompleted2, serverSocket);
        }
        // 비동기

        // 비동기?
        public void CloseServer()
        {

        }



    }
}
