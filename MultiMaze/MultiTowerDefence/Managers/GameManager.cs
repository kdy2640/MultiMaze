using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MazeClient;

namespace MazeClient
{

    class GameManager
    {
        private static GameManager? instance = null;
        public Define.GameState state = Define.GameState.MainScene;
        public SceneManager scene = new SceneManager();
        public ServerManager server = new ServerManager();



        public int PlayerCode; // 몇번 플레이어인지
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
