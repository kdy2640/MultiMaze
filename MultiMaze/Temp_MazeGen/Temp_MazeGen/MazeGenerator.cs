using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temp_MazeGen
{
    public class MazeGenerator
    {
        public static bool[,] GenerateMaze(int width, int height)
        {
            // 2차원 배열을 모두 1(벽)으로 초기화
            bool[,] maze = new bool[width, height];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    maze[i, j] = true;
                }
            }

            // 미로의 랜덤화를 위한 난수 생성
            Random random = new Random();
            Stack<Tuple<int, int>> stack = new Stack<Tuple<int, int>>();
            List<Tuple<int, int>> directions = new List<Tuple<int, int>>
        {
            Tuple.Create(2, 0), Tuple.Create(-2, 0), Tuple.Create(0, 2), Tuple.Create(0, -2)
        };

            // 시작 지점: (1, 1)
            int x = 1, y = 1;
            maze[x, y] = false; // 시작 지점을 0(길)로 설정
            /*
            maze[width - 2, height - 2] = false; // 도착 지점을 0(길)로 설정
            */
            stack.Push(Tuple.Create(x, y));

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                x = current.Item1;
                y = current.Item2;
                List<Tuple<int, int>> neighbors = new List<Tuple<int, int>>();

                foreach (var dir in directions)
                {
                    int nx = x + dir.Item1, ny = y + dir.Item2;
                    if (nx >= 1 && nx < width - 1 && ny >= 1 && ny < height - 1 && maze[nx, ny])
                    {
                        neighbors.Add(Tuple.Create(nx, ny));
                    }
                }

                if (neighbors.Count > 0)
                {
                    var next = neighbors[random.Next(neighbors.Count)];

                    // 현재 셀과 선택된 셀의 중간을 0(길)로 설정
                    maze[(x + next.Item1) / 2, (y + next.Item2) / 2] = false;
                    maze[next.Item1, next.Item2] = false;
                    /*
                    if (next.Item1 == width - 2 && next.Item2 == height - 2)
                    {
                        // Ensure the path to the exit is open
                        maze[(x + (width - 2)) / 2, (y + (height - 2)) / 2] = false;
                    }
                    */
                    stack.Push(current);  // 다음 길을 뚫기 위해 현재 셀 재설정
                    stack.Push(next);

          
                }
            }

            return maze;
        }
    }
}
