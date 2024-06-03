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
        // 우승횟수 저장
        int[] winCountList = new int[5];
        // 우승횟수 별 플레이어
        List<int>[] winCountPlayerList = new List<int>[6];
        // 1등 2등 3등 
        int[] rankList = new int[3];
        List<Point> fastPath;
        int fastTime;
        int fastIndex;
        int fastWinnerCode;
        private void receiveRequestPath(int playerCode)
        {
            //우승자 특정
            if(fastPath == null)
            { 
                fastTime = Int32.MaxValue;
                fastWinnerCode = 0;
                for (int i = 0; i < manager.map.RoomArgs.Round; i++)
                {
                    if( fastTime > manager.WinnerTimeList[i])
                    {
                        fastTime = manager.WinnerTimeList[i];
                        fastIndex = i;
                        fastWinnerCode = manager.WinnerList[i];
                    }
                    //우승횟수 저장
                    winCountList[manager.WinnerList[i]]++;
                }
                fastPath = manager.WinnerPathList[fastIndex];
                // 초기화
                for (int i = 0; i < winCountPlayerList.Length; i++)
                {
                    winCountPlayerList[i] = new List<int>();
                }
                // 우승횟수별로 정렬
                for (int i = 0; i < winCountList.Length; i++)
                {
                    //플레이어코드 일시적으로 + 1 ( 0 * 10은 0 이라서)
                    winCountPlayerList[winCountList[i]].Add(i + 1);
                }
                int rankIndex = 0;
                // 위에서부터 우승횟수 확인
                for (int i = 5; i >= 0; i--)
                {
                    //1,2,3등 특정 완료
                    if(rankIndex == 3)
                    {
                        break;
                    }

                    // 1,2,3등 특정중
                    if (winCountPlayerList[i].Count > 0)
                    {
                        for (int j = 0; j < winCountPlayerList[i].Count; j++)
                        {
                            // 우승횟수가 같아도 그대로 삽입
                            rankList[rankIndex] += winCountPlayerList[i][j] * (int)Math.Pow(10, j);
                        }
                        rankIndex++;
                    }
                }


            }

            byte[] buffer = new byte[fastPath.Count * 4 + 24];
            byte[] xbuffer = new byte[2];
            byte[] ybuffer = new byte[2];
            for (int i = 0; i < fastPath.Count; i++)
            {
                xbuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)fastPath[i].X));
                ybuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)fastPath[i].Y));

                Array.Copy(xbuffer, 0, buffer, 4 * i, 2);
                Array.Copy(ybuffer, 0, buffer, 4 * i + 2, 2);
            }

            byte[] fasttimeBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(fastTime));
            byte[] fastPlayerCodeBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(fastWinnerCode));
            byte[] seedBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(manager.SeedList[fastIndex]));
            byte[] rankBuffer = new byte[12];
            for (int i = 0; i < rankList.Length; i++)
            {
                byte[] tempBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(rankList[i]));
                Array.Copy(tempBuffer, 0, rankBuffer, 4 * i, 4);
            }

            Array.Copy(fasttimeBuffer, 0, buffer, fastPath.Count * 4, 4); 
            Array.Copy(fastPlayerCodeBuffer, 0, buffer, fastPath.Count * 4 + 4, 4);
            Array.Copy(seedBuffer, 0, buffer, fastPath.Count * 4 + 8, 4);
            Array.Copy(rankBuffer, 0, buffer, fastPath.Count * 4 + 12, 12);

            ServerEvent serverEvent = new ServerEvent(Define.GameState.GameOverScene, 0);

            manager.client.SendToPlayer(buffer, serverEvent, playerCode);
        }
    }
}
