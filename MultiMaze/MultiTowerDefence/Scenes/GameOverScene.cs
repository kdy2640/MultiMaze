using MazeClient.Scenes;
using MazeClient.Share;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace MazeClient
{
    public partial class GameOverScene : Form
    {
        GameManager Manager;
        bool[,] map;
        List<Point> path;
        int cellSize = 4;
        int mazeHeight;
        int mazeWidth;

        //맵 & 경로 출력 시작 좌표
        int startX = 30;
        int startY = 90;
        public GameOverScene()
        {
            InitializeComponent();
            Manager = GameManager.Instance;
            Manager.server.callbackFunctions.GameOverSceneCallBack = null;
            Manager.server.callbackFunctions.GameOverSceneCallBack += GameOverSceneCallBackFunction;
            this.DoubleBuffered = true; // 로딩 잘 되게 합니다.

            switch (Manager.map.RoomArgs.mapSize)
            {
                case RoomSettingArgs.MapSize.Small:
                    cellSize = 10;
                    break;
                case RoomSettingArgs.MapSize.Medium:
                    cellSize = 6;
                    break;
                case RoomSettingArgs.MapSize.Big:
                    cellSize = 4;
                    break;
            }

            getWinnerPath();
            CalculateFinalRanking();
        }

        int count = 0;
        private void WinnerPath_Draw(object sender, PaintEventArgs e)
        {

            Graphics g = e.Graphics;


            //미로 그리기 
            for (int i = 0; i < mazeHeight - 1; i++)
            {
                for (int j = 0; j < mazeWidth - 1; j++)
                {
                    Color color = map[i, j] ? Color.White : Color.Black;
                    g.FillRectangle(new SolidBrush(color), startX + i * cellSize, startY + j * cellSize, cellSize, cellSize);
                }
            }

            //경로 그리기
            Pen pen = new Pen(Color.Red, cellSize / 2);
            if (path != null && path.Count > 1)
            {
                for (int i = 1; i < count; i++)
                {
                    Point prev = CalculatePoint(i - 1);
                    Point curr = CalculatePoint(i);
                    g.DrawLine(pen, prev, curr);
                }
            }


            count++;
            if (count == path.Count)
            {
                count = 0;
            }
        }

        private Point CalculatePoint(int index)
        {
            return new Point(startX + path[index].X * cellSize + cellSize / 2, startY + path[index].Y * cellSize + cellSize / 2);
        }

        public void GameOverSceneCallBackFunction(byte[] buffer, ServerEvent serverEvent)
        {
            //GameStatus 확인
            if (serverEvent.GameStatus != Define.GameState.GameOverScene) return;
            switch (serverEvent.EventType)
            {
                case 0: // Path
                    receiveWinnerPath(buffer);
                    //함수
                    break;
                case 1: // None 
                    break;
            }
        }


        public void CalculateFinalRanking()
        {
            //AI는 0번, player는 player번호로 저장
            Dictionary<int, int> playerScores = new Dictionary<int, int>();

            // 최종점수 초기화
            for (int i = 0; i <= GameManager.MAX_PLAYER_NUM; i++)
            {
                if (i == 0 || Manager.server.PlayerConnectArray[i - 1])
                {
                    playerScores[i] = 0;
                }
            }

            //각 라운드별 승자에게 2점씩 부여
            foreach (int winner in Manager.WinnerList)
            {
                if (playerScores.ContainsKey(winner))
                {
                    playerScores[winner] += 2;
                }
            }

            // 랭킹 정렬
            var rankedPlayers = playerScores.OrderByDescending(pair => pair.Value).ToList();

            // 랭킹 출력
            for (int i = 0; i < rankedPlayers.Count; i++)
            {
                string playerType = rankedPlayers[i].Key == 0 ? "AI" : $"{rankedPlayers[i].Key}번 플레이어";
                switch (i)
                {
                    case 0:
                        First.Text = "1등: " + playerType;
                        break;
                    case 1:
                        Second.Text = "2등: " + playerType;
                        break;
                    case 2:
                        Third.Text = "3등: " + playerType;
                        break;
                }
            }
        }

            #region 서버 송신
            private void getWinnerPath()
        {
            //서버한테 path달라고
            int playerCode = Manager.PlayerCode;
            // 직렬화
            byte[] buffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)playerCode));
            // 서버이벤트
            GameOverSceneEvent serverEvent = new GameOverSceneEvent(GameOverSceneEvent.GameOverSceneServerEventType.Path);
            // 송신
            Manager.server.SendToServerAsync(buffer, serverEvent);
        }
        #endregion

        #region 서버 수신
        private async void receiveWinnerPath(byte[] buffer)
        {
            List<Point> newpath = new List<Point>();

            byte[] xBuffer = new byte[2];
            byte[] yBuffer = new byte[2];
            int len = buffer.Length / 4;
            for (int i = 0; i < len; i++)
            {
                Array.Copy(buffer, 4 * i, xBuffer, 0, 2);
                Array.Copy(buffer, 4 * i + 2, yBuffer, 0, 2);

                int x = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(xBuffer, 0));
                int y = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(yBuffer, 0));
                newpath.Add(new Point(x, y));
            }

            path = newpath;
            Manager.path = path;
            map = Manager.map.map;
            mazeHeight = map.GetLength(0);
            mazeWidth = map.GetLength(1);

            await Task.Delay(30);
            this.Paint += new PaintEventHandler(WinnerPath_Draw);
            this.Invalidate();
        }

        #endregion

        private void BackToMain_Click(object sender, EventArgs e)
        {
            Manager.server.LeaveServer();
            BaseScene temp = Manager.scene.baseScene;
            GameManager.Refresh();
            GameManager.Instance.scene.baseScene = temp;
            Manager.scene.ChangeGameState(this, Define.GameState.MainScene);
        }
    }

    public class GameOverSceneEvent : ServerEvent
    {
        public enum GameOverSceneServerEventType
        {
            Path, None
        }


        public GameOverSceneEvent() : base()
        {
            EventType = (int)GameOverSceneServerEventType.None;
            GameStatus = Define.GameState.GameOverScene;
        }
        public GameOverSceneEvent(GameOverSceneServerEventType gameOverSceneServerEventType) : base()
        {
            EventType = (int)gameOverSceneServerEventType;
            GameStatus = Define.GameState.GameOverScene;
        }
    }
}
