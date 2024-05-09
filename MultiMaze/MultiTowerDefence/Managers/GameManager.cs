using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeClient.Share;

namespace MazeClient
{

    class GameManager
    {
        private static GameManager? instance = null;
        public Define.GameState state = Define.GameState.MainScene;
        public SceneManager scene = new SceneManager();
        public ServerManager server = new ServerManager(); 
        public Map map = new Map();
        /// <summary>
        /// 1~4는 플레이어 코드이고 0은 AI 우승입니다.
        /// AI 우승시 서버 상호작용 없이 각 클라이언트의 GameManager.AiPath에서 AI 경로를 가져와서 표시합니다.
        /// </summary>
        public int[] WinnerList = new int[5];
        /// <summary>
        /// 플레이어 본인의 경로를 저장합니다.
        /// </summary>
        public List<Point> path;
        /// <summary>
        /// 각 라운드마다 AI의 경로를 저장합니다.
        /// </summary>
        public List<Point> AiPath;

        public const int MAX_PLAYER_NUM = 4;
        /// <summary>
        /// 라운드는 1 부터 시작합니다.
        /// </summary>
        public int nowRound = 0;

        public int PlayerCode; // 몇번 플레이어인지 1번부터 시작
        private GameManager()
        {
        }

        // GameManager의 인스턴스를 반환하는 public static 메서드
        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }
                return instance;
            }
        }




    }

}
