using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using MazeClient.Share;

namespace MazeServer.Scenes
{
    internal class GameOverServerScene
    {
        ServerGameManager manager;
        public GameOverServerScene()
        {
            manager = ServerGameManager.Instance;
            manager.client.callbackFunctions.GameOverSceneCallBack = null;
            manager.client.callbackFunctions.GameOverSceneCallBack += GameOverSceneCallBackFunction;
        }
        public void GameOverSceneCallBackFunction(byte[] buffer, ServerEvent serverEvent, int playerCode)
        {
            //GameStatus 확인
            if (serverEvent.GameStatus != Define.GameState.GameOverScene) return;
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
            /*어떤 경우를 출력하기로 했는지 까먹어서 일단 랜덤 라운드 출력하였습니다.*/
            //System.Random rand = new System.Random();
            //int randomRound = rand.Next(0, 5);
            List<Point> path = manager.WinnerPathList[0];

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

            ServerEvent serverEvent = new ServerEvent(Define.GameState.GameOverScene, 0);

            manager.client.SendToPlayer(buffer, serverEvent, playerCode);
        }
    }
}
