using MazeClient.Scenes;
using MazeClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static MazeClient.Scenes.InGameSceneServerEvent;
using MazeClient.Share;

namespace MazeServer.Scenes
{
    internal class InGameServerScene
    {
        ServerGameManager manager;
        public InGameServerScene()
        {
            manager = ServerGameManager.Instance;
            manager.client.callbackFunctions.InGameSceneCallBack += InGameSceneCallBackFunction;
        }
        public void InGameSceneCallBackFunction(byte[] buffer, ServerEvent serverEvent,int playerCode)
        { 
            //GameStatus 확인
            if (serverEvent.GameStatus != Define.GameState.InGameScene) return;
            switch (serverEvent.EventType)
            {
                case 0:
                    SetPlayerPos(buffer, playerCode);
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }

        public async void SetPlayerPos(byte[] buffer,int playerCode)
        {
            byte[] xBuffer = new byte[2];
            byte[] yBuffer = new byte[2];

            //배열 복사
            Array.Copy(buffer, 0, xBuffer, 0, 2);
            Array.Copy(buffer, 2, yBuffer, 0, 2);

            int xPos = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(xBuffer, 0));
            int yPos = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(yBuffer, 0));
            manager.map.PlayerPosList[playerCode - 1] = new Point(xPos, yPos);
            SendAllPlayerPos();// 현재는 입력이 올때만 공유
        }
        public async void SendAllPlayerPos()
        {
            byte[] buffer = new byte[4 * ServerGameManager.MAX_PLAYER_NUM];
 
            for (int i = 0; i < ServerGameManager.MAX_PLAYER_NUM; i++)
            {

                Point pos = manager.map.PlayerPosList[i];
                byte[] xBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)pos.X));
                byte[] yBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)pos.Y));

                Array.Copy(xBuffer,0, buffer, i * 4, 2);
                Array.Copy(yBuffer, 0, buffer, i * 4 + 2, 2);
            } 

            InGameSceneServerEvent serverEvent = new InGameSceneServerEvent(InGameSceneServerEventType.AllPlayerPos);
            manager.client.SendToAllPlayers(buffer, serverEvent);
        }
    }
}
