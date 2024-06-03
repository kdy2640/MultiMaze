using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MazeClient.Share;

namespace MazeClient
{
    public partial class RoundOverScene : Form
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
        public RoundOverScene()
        {
            InitializeComponent();
            Manager = GameManager.Instance;
            Manager.server.callbackFunctions.RoundOverSceneCallBack = null;
            Manager.server.callbackFunctions.RoundOverSceneCallBack += RoundOverSceneCallBackFunction;
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


            shadowPictureBox1.Location = new Point(panel1.Location.X + 7, panel1.Location.Y + 7);
            shadowPictureBox1.Size = panel1.Size;
            shadowPictureBox1.SendToBack();

            getWinnerPath();
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

            //종료지점 그리기
            Point end = Manager.map.endPoint;
            g.FillEllipse(new SolidBrush(Color.Cyan), startX + end.X * cellSize, startY + end.Y * cellSize, cellSize, cellSize);


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
        private void button1_Click(object sender, EventArgs e)
        {
            Manager.scene.ChangeGameState(this, Define.GameState.GameOverScene);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void RoundOverScene_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void timerCountdown_Tick(object sender, EventArgs e)
        {
        }

        private void drawTimer_Tick(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void Start_Click(object sender, EventArgs e)
        {

        }
        public void RoundOverSceneCallBackFunction(byte[] buffer, ServerEvent serverEvent)
        {
            //GameStatus 확인
            if (serverEvent.GameStatus != Define.GameState.RoundOverScene) return;
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
        #region 서버 송신
        private void getWinnerPath()
        {
            //서버한테 path달라고
            int playerCode = Manager.PlayerCode;
            // 직렬화
            byte[] buffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)playerCode));
            // 서버이벤트
            RoundOverSceneEvent serverEvent = new RoundOverSceneEvent(RoundOverSceneEvent.RoundOverSceneServerEventType.Path);
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
            drawTimer.Start();

            int winnerCode = Manager.WinnerList[Manager.nowRound - 1];
            if (winnerCode == 0)
            {
                Winner.Text += "AI";
            }
            else
            {
                Winner.Text += Manager.WinnerList[Manager.nowRound - 1].ToString() + "번 플레이어";
            }
            Time.Text += ((float)Manager.winnerTime / 20f).ToString() + " 초";
            if (Manager.nowRound == Manager.map.RoomArgs.Round)
            {
                nextRoundButton.Text = "최종결과 보러가기";
            }
            else
            {
                nextRoundButton.Text = "다음 라운드로 이동";
            }
            roundLabel.Text = Manager.nowRound.ToString() + " 라운드 종료";

            await Task.Delay(30);
            this.Paint += new PaintEventHandler(WinnerPath_Draw);
            this.Invalidate();
        }

        #endregion

        private void nextRoundButton_Click(object sender, EventArgs e)
        {
            if (Manager.nowRound == Manager.map.RoomArgs.Round)
            {
                Manager.scene.ChangeGameState(this, Define.GameState.GameOverScene);
            }
            else
            {
                Manager.scene.ChangeGameState(this, Define.GameState.WaitScene);
            }

        }
        public Color ShadowColor = Color.FromArgb(32, 32, 32);
        public int ShadowOffset = 2; 
        private void roundLabel_Paint(object sender, PaintEventArgs e)
        { 
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Label lbl = sender as Label;
            lbl.AutoSize = true;
            lbl.Text = "           ";
            using (Brush shadowBrush = new SolidBrush(ShadowColor))
            {
                e.Graphics.DrawString(Manager.nowRound.ToString() + " 라운드 종료", lbl.Font, shadowBrush, new PointF(ShadowOffset, ShadowOffset));
            }

            // 실제 텍스트
            using (Brush textBrush = new SolidBrush(Color.LightGray))
            {
                e.Graphics.DrawString(Manager.nowRound.ToString() + " 라운드 종료", lbl.Font, textBrush, new PointF(0, 0));
            }
        }
    }

    public class RoundOverSceneEvent : ServerEvent
    {
        public enum RoundOverSceneServerEventType
        {
            Path, None
        }


        public RoundOverSceneEvent() : base()
        {
            EventType = (int)RoundOverSceneServerEventType.None;
            GameStatus = Define.GameState.RoundOverScene;
        }
        public RoundOverSceneEvent(RoundOverSceneServerEventType roundOverSceneServerEventType) : base()
        {
            EventType = (int)roundOverSceneServerEventType;
            GameStatus = Define.GameState.RoundOverScene;
        }
    }
}
