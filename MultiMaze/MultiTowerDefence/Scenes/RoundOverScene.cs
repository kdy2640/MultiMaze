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
            Graphics g = e.Graphics;
            int cellSize = 3;
            int mazeHeight = map.GetLength(0);
            int mazeWidth = map.GetLength(1);

            //미로 그리기
            for(int i = 0; i< mazeHeight; i++)
            {
                for (int j = 0; j < mazeWidth; j++)
                {
                    Color color = map[i,j] ? Color.White : Color.Black;
                    g.FillRectangle(new SolidBrush(color), j * cellSize, i * cellSize, cellSize, cellSize);
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
