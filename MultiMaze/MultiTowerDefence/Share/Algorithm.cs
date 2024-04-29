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

        public override List<Point> ToArray(Point start, Point end)
        {
            return null;
            bool[,] temp = new bool[map.GetLength(0), map.GetLength(1)];
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
