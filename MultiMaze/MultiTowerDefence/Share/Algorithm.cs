using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeClient.Share
{

    public class Algorithm
    {
        public bool[,] map;
        GameManager manager;
        public Algorithm()
        {
            manager = GameManager.Instance;
            map = manager.map.map;
        }
        virtual public List<Point> ToArray(Point start, Point end)
        {
            return null;

        }

    }

    public class BFS : Algorithm
    {
        int map_size_x;
        int map_size_y;
        const bool BLOCK = false;
        const bool WAY = true;

        public override List<Point> ToArray(Point start, Point end)
        {

            this.map_size_x = map.GetLength(0);
            this.map_size_y = map.GetLength(1);
            return bfs(start, end);
        }

        public List<Point> bfs(Point start, Point end)
        {
            if (map[start.X, start.Y] == false || map[start.X, start.Y] == false) return null;
            int[] dx = new int[] { -1, 0, 1, 0 };
            int[] dy = new int[] { 0, 1, 0, -1 };

            bool[,] visited = new bool[map_size_x, map_size_y];
            List<Point> result = new List<Point>();
            Queue<Point> queue = new Queue<Point>();

            Array.Clear(visited, 0, visited.Length);

            queue.Enqueue(start);
            visited[start.X, start.Y] = true;
            Point last_pos = start;

            while (queue.Count > 0)
            {
                var pop_value = queue.Dequeue();
                var now_x = pop_value.X;
                var now_y = pop_value.Y;

                if (getDistance(last_pos, pop_value) <= 1) result.Add(pop_value);
                else
                {
                    foreach (var path in path_search(last_pos, pop_value))
                    {
                        result.Add(path);
                    }
                }

                if (now_x == end.X && now_y == end.Y) break;

                last_pos = pop_value;
                for (int i = 0; i < 4; i++)
                {
                    int next_x = now_x + dx[i];
                    int next_y = now_y + dy[i];


                    if (next_x < 0 || next_x >= map_size_x || 0 > next_y || next_y >= map_size_y) continue;
                    if (visited[next_x, next_y] || map[next_x, next_y] == BLOCK) continue;

                    visited[next_x, next_y] = true;
                    queue.Enqueue(new Point(next_x, next_y));
                }
            }

            return result;
        }
        private Stack<Point> path_search(Point start, Point end)
        {
            int[] dx = new int[] { -1, 0, 1, 0 };
            int[] dy = new int[] { 0, 1, 0, -1 };
            bool[,] visited = new bool[map_size_x, map_size_y];
            Point[,] path = new Point[map_size_x, map_size_y];

            Array.Clear(path, 0, path.Length);
            Array.Clear(visited, 0, visited.Length);

            Queue<Point> queue = new Queue<Point>();
            queue.Enqueue(start);

            visited[start.X, start.Y] = true;
            while (queue.Count > 0)
            {
                var pop_value = queue.Dequeue();
                var now_x = pop_value.X;
                var now_y = pop_value.Y;

                if (now_x == end.X && now_y == end.Y) break;
                for (int i = 0; i < 4; i++)
                {
                    int next_x = now_x + dx[i];
                    int next_y = now_y + dy[i];


                    if (next_x < 0 || next_x >= map_size_x || 0 > next_y || next_y >= map_size_y) continue;
                    if (visited[next_x, next_y] || map[next_x, next_y] == BLOCK) continue;

                    visited[next_x, next_y] = true;
                    queue.Enqueue(new Point(next_x, next_y));
                    path[next_x, next_y] = pop_value;
                }
            }

            //int cur_x = end.X, cur_y = end.Y;
            Point cur_pos = new Point(end.X, end.Y);
            Stack<Point> result = new Stack<Point>();
            while (true)
            {
                if (cur_pos.X == start.X && cur_pos.Y == start.Y) break;
                //if (cur_x == start.X && cur_y == start.Y) break;
                result.Push(cur_pos);
                cur_pos = path[cur_pos.X, cur_pos.Y];
            }
            return result;
        }

        private int getDistance(Point last, Point now)
        {
            return Math.Abs(last.X - now.X) + Math.Abs(last.Y - now.Y);
        }
    }
    public class DFS : Algorithm
    {

        public override List<Point> ToArray(Point start, Point end)
        {
            return null;
            bool[,] temp = new bool[map.GetLength(0), map.GetLength(1)];
        }
    }

    public class Astar : Algorithm
    {
        public override List<Point> ToArray(Point start, Point end)
        {
            return null;
            bool[,] temp = new bool[map.GetLength(0), map.GetLength(1)];
        }
    }
}
