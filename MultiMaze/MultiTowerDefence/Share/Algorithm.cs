using System;
using System.Collections;
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
            if (map[start.X, start.Y] == false || map[end.X, end.Y] == false) return null;
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
    private int map_size_x;
    private int map_size_y;
    private const bool WALL = false;
    private const bool WAY = true;

    public override List<Point> ToArray(Point startingPoint, Point endingPoint)
    {
        this.map_size_x = map.GetLength(0);
        this.map_size_y = map.GetLength(1);
        if (!IsinMapBounds(startingPoint) || !IsinMapBounds(endingPoint) || !IsPath(startingPoint) || !IsPath(endingPoint))
            return null;

        return dfs(startingPoint, endingPoint);
    }

    private List<Point> dfs(Point startingPoint, Point endingPoint)
    {
        Stack<Point> explore = new Stack<Point>();
        HashSet<Point> visitedPoints = new HashSet<Point>();
        List<Point> visitedOrder = new List<Point>();

        explore.Push(startingPoint);
        visitedPoints.Add(startingPoint);

        while (explore.Count > 0)
        {
            Point currentPoint = explore.Pop();

            if (!visitedOrder.Contains(currentPoint))
                visitedOrder.Add(currentPoint);

            foreach (Point adjacent in FindNeighbors(currentPoint))
            {
                if (IsPath(adjacent) && !visitedPoints.Contains(adjacent))
                {
                    explore.Push(adjacent);
                    visitedPoints.Add(adjacent);
                }
            }
        }

        return visitedOrder;
    }

    private bool IsinMapBounds(Point location)
    {
        return location.X >= 0 && location.X < map_size_x && location.Y >= 0 && location.Y < map_size_y;
    }

    private bool IsPath(Point location)
    {
        // Accesses the external Map class's data
        return map[location.X, location.Y] == WAY;
    }

    private IEnumerable<Point> FindNeighbors(Point location)
    {
        Point[] directions = { new Point(1, 0), new Point(0, 1), new Point(-1, 0), new Point(0, -1) }; // 상 하 좌 우

        foreach (Point direction in directions)
        {
            Point adjacent = new Point(location.X + direction.X, location.Y + direction.Y);
            if (IsinMapBounds(adjacent))
                yield return adjacent;
        }
    }
}
    public class Astar : Algorithm
    {
        int map_size_x;
        int map_size_y;
        const bool Wall = false;
        const bool Way = true;
        public override List<Point> ToArray(Point start, Point end)
        {
            map_size_x = map.GetLength(0);
            map_size_y = map.GetLength(1);
            List<Point> Result = GenerateArr(start, end);
            return Result;
        }

        private List<Point> GenerateArr(Point start, Point end)
        {
            if (map[start.X, start.Y] == Wall || map[end.X, end.Y] == Wall) return null;
            
            List<Point> pathList = new List<Point>();
            PriorityQueue<Point,int> queue = new PriorityQueue<Point,int>();
            short[] diffX = { 0, 1, 0, -1 }; short[] diffY = { 1, 0, -1, 0 }; // 상우하좌
            short[,] WeightArr = new short[map.GetLength(0), map.GetLength(1)];
            Point[,] backArr = new Point[map.GetLength(0), map.GetLength(1)];
            //weight 초기화
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    WeightArr[i, j] = short.MaxValue;
                }
            }
            WeightArr[start.X, start.Y] = 0;
            queue.Enqueue(start, 0 + ManhattanDistance(start, end));
            Point NowPoint = start;
            Point PrevPoint = start;
            Point nextPoint = new Point();

            int debugIndex = 0;
            while ( queue.Count > 0 ) 
            {
                //0. 노드를 뽑는다.
                NowPoint = queue.Dequeue();
                int nowX = NowPoint.X;
                int nowY = NowPoint.Y;
                debugIndex++;
                if (NowPoint == end)
                {
                    pathList.Add(end); break;
                }

                //1. 이전노드가 먼 곳에 있다면 추적하는 루트를 pathList에 넣는다..
                if(ManhattanDistance(NowPoint,PrevPoint) > HeuristicWeight)
                {
                    Point A = new Point(); Point B = new Point();
                    bool trigger = true;
                    if (WeightArr[NowPoint.X,NowPoint.Y] > WeightArr[PrevPoint.X,PrevPoint.Y])
                    {
                        A = NowPoint; B = PrevPoint;
                        trigger = true;
                    }else
                    {
                        A = PrevPoint; B = NowPoint;
                        trigger = false;
                    }
                    List<Point> ListA = new List<Point>();
                    List<Point> ListB = new List<Point>();
                    // 1-1. weight이 큰 노드를 A, weight이 작은 노드를 B라고 할때 A.weight = B.weight이 되는 지점까지 A가 weight이 weigt-1이 되는 지점을 찾아 백트래킹
                    while (WeightArr[A.X,A.Y] != WeightArr[B.X,B.Y]) 
                    {
                        nextPoint = backArr[A.X, A.Y];
                        ListA.Add(nextPoint);
                        A = nextPoint; 
                    }
                    if(A != B)
                    {
                        // 1-2. A.weight = B.weight이므로 각각 weight이 weight -1이 되는 지점을 찾아 서로 같은지 비교
                        while (true)
                        { 
                            Point nextA = new Point();
                            Point nextB = new Point();
                            nextA = backArr[A.X, A.Y];
                            nextB = backArr[B.X, B.Y];
                            if (nextA == nextB)
                            {
                                A = nextA;
                                B = nextB;
                                break;
                            }
                            ListA.Add(nextA);
                            ListB.Add(nextB);
                            A = nextA;
                            B = nextB;
                        }
                    } 
                    
                    // 1-3. 시작은 똑같으므로 해당 지점은 항상 존재하고, 같은 지점을 발견했다면 PrevPoint -> 같은지점 -> NowPoint로 가는 경로를 pathList에 삽입
                    if (trigger) // nowPoint의 weight 가 더 큼 - ListB + 같은지점 + ListA의 역순
                    {
                        foreach(Point b in ListB)
                        {
                            pathList.Add(b);
                        }
                        pathList.Add(A);
                        ListA.Reverse();
                        foreach (Point a in ListA)
                        {
                            pathList.Add(a);
                        }
                    }
                    else  // PrevPoint의 weight가 더 큼 ListA + 같은지점 + ListB의 역순
                    {
                        foreach (Point a in ListA)
                        {
                            pathList.Add(a);
                        }
                        pathList.Add(A);
                        ListB.Reverse(); 
                        foreach (Point b in ListB)
                        {
                            pathList.Add(b);
                        }
                    }
                    
                 }
                //2. 현재 노드 주변 노드중 방문하지 않은 노드 들을 큐에 넣고 WeightArr에 현재 노드의 Weight + 1을 하여 넣는다.

                for (int i = 0; i < 4; i++)
                {
                    int next_x = NowPoint.X + diffX[i];
                    int next_y = NowPoint.Y + diffY[i];

                    if (next_x < 0 || next_x >= map_size_x || 0 > next_y || next_y >= map_size_y) continue;
                    if (map[next_x, next_y] == Wall) continue;
                    //방문 확인
                    if (WeightArr[next_x, next_y] < WeightArr[NowPoint.X, NowPoint.Y]) continue;

                    nextPoint = new Point(next_x, next_y);
                    WeightArr[next_x, next_y] = (short)(WeightArr[NowPoint.X, NowPoint.Y] + 1);
                    queue.Enqueue(nextPoint, -WeightArr[next_x, next_y] + ManhattanDistance(nextPoint, end));
                    backArr[next_x, next_y] = NowPoint;
                }

                //3. 현재 노드를 pathList에 넣고 prevPoint에 넣는다.
                pathList.Add(NowPoint);
                PrevPoint = NowPoint;
            } 

            return pathList;
        }
        const int HeuristicWeight = 1;
        private int ManhattanDistance(Point X, Point Y)
        {
            int diffX = Math.Abs(X.X - Y.X);
            int diffY = Math.Abs(X.Y - Y.Y); 
            return HeuristicWeight * (diffX + diffY);
        }
    }
}
