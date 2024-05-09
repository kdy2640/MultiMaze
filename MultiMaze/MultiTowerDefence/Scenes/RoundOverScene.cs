using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MazeClient.Share;

namespace MazeClient
{
    public partial class RoundOverScene : Form
    {
        GameManager Manager;
        public RoundOverScene()
        {
            InitializeComponent();
            Manager = GameManager.Instance;
            this.Paint += new PaintEventHandler(WinnerPath_Draw);
        }

        private void WinnerPath_Draw(object sender, PaintEventArgs e)
        {
            bool[,] map = Manager.map.map;
            List<Point> path = GameManager.Instance.path;
            Graphics g = e.Graphics;
            int cellSize = 3;
            int mazeHeight = map.GetLength(0);
            int mazeWidth = map.GetLength(1);

            //맵 & 경로 출력 시작 좌표
            int startX = 100;
            int startY = 10;

            
            //미로 그리기
            for(int i = 0; i< mazeHeight - 1; i++)
            {
                for (int j = 0; j < mazeWidth - 1; j++)
                {
                    Color color = map[i,j] ? Color.White : Color.Black;
                    g.FillRectangle(new SolidBrush(color), startX + j * cellSize, startY + i * cellSize, cellSize, cellSize);
                }
            }

            //경로 그리기
            if (path != null && path.Count > 1)
            {
                for (int i = 1; i < path.Count; i++)
                {
                    Point prev = new Point(startX + path[i - 1].X * cellSize + cellSize / 2, startY + path[i - 1].Y * cellSize + cellSize / 2);
                    Point curr = new Point(startX + path[i].X * cellSize + cellSize / 2, startY + path[i].Y * cellSize + cellSize / 2);
                    g.DrawLine(new Pen(Color.Blue, 2), prev, curr);
                }
            }
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
    }
}
