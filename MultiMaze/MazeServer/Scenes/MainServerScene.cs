using MazeClient.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks; 


namespace MazeServer.Scenes
{
    internal class MainServerScene
    {
        ServerGameManager manager;
        public MainServerScene()
        {
            manager = ServerGameManager.Instance;
            manager.client.callbackFunctions.MainSceneCallBack = null;
            manager.client.callbackFunctions.MainSceneCallBack += MainSceneCallBackFunction;
        }
        public void MainSceneCallBackFunction(byte[] buffer, ServerEvent serverEvent, int playerCode)
        {
            //GameStatus 확인
            if (serverEvent.GameStatus != Define.GameState.MainScene) return;
            switch (serverEvent.EventType)
            {
                case 0:
                    ReceiveRequestRoomArgs(playerCode);
                    break;
                case 1: 
                    break;
                case 2:
                    break;
            }
        }

        private void ReceiveRequestRoomArgs(int playerCode)
        {
            // playerCode에 해당하는 클라이언트에게 유지하고있는 방설정을 보냄
            RoomSettingArgs args = manager.map.RoomArgs;
            // 직렬화
            byte[] roundBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)args.Round));
            byte[] aiBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)args.ai));
            byte[] sizeBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)args.mapSize));
            byte[] buffer = new byte[roundBuffer.Length + aiBuffer.Length + sizeBuffer.Length];
            // 합체
            Array.Copy(roundBuffer, 0, buffer, 0, roundBuffer.Length);
            Array.Copy(aiBuffer, 0, buffer, 2, aiBuffer.Length);
            Array.Copy(sizeBuffer, 0, buffer, 4, sizeBuffer.Length);
            // 서버이벤트
            ServerEvent serverEvent = new ServerEvent();
            serverEvent.GameStatus = Define.GameState.MainScene;
            serverEvent.EventType = 0;
            // 송신
            manager.client.SendToPlayer(buffer,serverEvent,playerCode);
        }
         
    }
}
