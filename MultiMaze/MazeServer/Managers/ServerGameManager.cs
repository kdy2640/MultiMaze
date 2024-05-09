
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using MazeClient.Share;

namespace MazeServer
{
    internal class ServerGameManager
    {
        private static ServerGameManager? instance = null;
        public ServerScene ServerScene;
        public Define.GameState state = Define.GameState.InGameScene;
        public ClientManager client = new ClientManager();
        public Map map = new Map();
        /// <summary>
        /// 1~4는 플레이어 코드이고 0은 AI 우승입니다.
        /// AI 우승시 서버 상호작용 없이 각 클라이언트의 GameManager.AiPath에서 AI 경로를 가져와서 표시합니다.
        /// </summary>
        public int[] WinnerList = new int[5];
        public int[] SeedList = new int[5];

        public const int MAX_PLAYER_NUM = 4;
        /// <summary>
        /// 라운드는 1 부터 시작합니다.
        /// </summary>
        public int nowRound = 0;

        private ServerGameManager()
        { 
        }

        // GameManager의 인스턴스를 반환하는 public static 메서드
        public static ServerGameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ServerGameManager();
                }
                return instance;
            }
        }


    }
}
