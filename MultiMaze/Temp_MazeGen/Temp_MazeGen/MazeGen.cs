using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Temp_MazeGen
{
    public partial class MazeGen : Form
    {
        public MazeGen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var maze = MazeGenerator.GenerateMaze(99, 99);  //홀수 추천.
            DrawMaze(maze);
        }

        private void DrawMaze(bool[,] maze) //로직 테스트용
        {
            int cellSize = 3;
            Bitmap bitmap = new Bitmap(maze.GetLength(0) * cellSize, maze.GetLength(1) * cellSize);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    for (int j = 0; j < maze.GetLength(1); j++)
                    {
                        if (maze[i, j]) //벽을 검은색으로 출력
                        {
                            g.FillRectangle(Brushes.Black, i * cellSize, j * cellSize, cellSize, cellSize);
                        }
                        else //길을 흰색으로 출력
                        {
                            g.FillRectangle(Brushes.White, i * cellSize, j * cellSize, cellSize, cellSize);
                        }
                    }
                }
            }
            pictureBox1.Image = bitmap;
        }
    }
}
