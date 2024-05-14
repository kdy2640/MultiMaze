using MazeClient.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;  
using MazeClient.Share;
using System.Net;

namespace MazeServer.Scenes
{
    internal class RoundOverServerScene
    {
        ServerGameManager manager;
        public RoundOverServerScene()
        {
            manager = ServerGameManager.Instance;
            manager.client.callbackFunctions.RoundOverSceneCallBack += RoundOverSceneCallBackFunction;
        }
        public void RoundOverSceneCallBackFunction(byte[] buffer, ServerEvent serverEvent, int playerCode)
        {
            //GameStatus 확인
            if (serverEvent.GameStatus != Define.GameState.RoundOverScene) return;
            switch (serverEvent.EventType)
            {
                case 0:  //path
                    receiveRequestPath(playerCode);
                    break;
                case 1: // none
                    break;
            }
        }
 
        private void receiveRequestPath(int playerCode)
        {
            List<Point> path = manager.WinnerPathList[manager.nowRound - 1];

            byte[] buffer = new byte[path.Count * 4];
            byte[] xbuffer = new byte[2]; 
            byte[] ybuffer = new byte[2]; 
            for (int i = 0; i < path.Count; i++)
            {
                xbuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)path[i].X));
                ybuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)path[i].Y));

                Array.Copy(xbuffer, 0, buffer, 4 * i, 2);
                Array.Copy(ybuffer, 0, buffer, 4 * i + 2, 2); 
            }

            ServerEvent serverEvent = new ServerEvent(Define.GameState.RoundOverScene, 0);

            manager.client.SendToPlayer(buffer, serverEvent, playerCode);
        }
    }
}
