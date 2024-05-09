using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
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
        int startX = 100;
        int startY = 10;
        public RoundOverScene()
        {
            InitializeComponent();
            Manager = GameManager.Instance;
            this.Paint += new PaintEventHandler(WinnerPath_Draw);
            this.DoubleBuffered = true; // 로딩 잘 되게 합니다.
            map = Manager.map.map;
            path = Manager.path;
            cellSize = 4;
            mazeHeight = map.GetLength(0);
            mazeWidth = map.GetLength(1);
            drawTimer.Start();
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
            Pen pen = new Pen(Color.Red, 2);
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
            if(count == path.Count)
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
    }
}
