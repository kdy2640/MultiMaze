using MazeClient.Share;
using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace MazeClient.Share
{
    public class Map
    {

        //Setting에서 입력하거나 Main에서 서버에게 받아오기
        GameManager Manager;
        public RoomSettingArgs RoomArgs = new RoomSettingArgs();

        //MapInitializer 에서 RoomArgs를 보고 초기화하는 것들
        public bool[,] map = new bool[10, 10];
        public int mapSize = 100;
        public Point startPoint = new Point();
        public Point endPoint = new Point();
        public int seed = 50; 

        public List<Point> PlayerStartPosList = new List<Point>();
        public List<Point> PlayerPosList = new List<Point>();   
        public List<Color> PlayerColorList = new List<Color>();
        
        public Map()
        {
            // 임시
            for (int i = 0; i < GameManager.MAX_PLAYER_NUM; i++)
            {
                PlayerStartPosList.Add(new Point(i+1, i+1));
                PlayerPosList.Add(new Point(i+1, i+1));
                PlayerColorList.Add(Color.Red);
            }
        }
        /// <summary>
        /// 초기값은 있으나 MapArgs를 다 초기화 한 후 실행해야 정상작동합니다.
        /// </summary>
        public void MapInitialize(RoomSettingArgs args)
        {
            this.RoomArgs = args;
            //맵 크기
            switch(RoomArgs.mapSize)
            {
                case RoomSettingArgs.MapSize.Small:
                    mapSize = 40;
                    break;
                case RoomSettingArgs.MapSize.Medium:
                    mapSize = 70;
                    break;
                case RoomSettingArgs.MapSize.Big:
                    mapSize = 100;
                    break;
            }
            map = new bool[mapSize, mapSize];
            //AI 시작, 끝
            endPoint = new Point(mapSize-3,mapSize-3); 
            //미로 생성
            GenerateMaze(mapSize,mapSize,seed);
        }

        /// <summary>
        /// seed를 입력하여 seed에 맞는 게임시작 전 상태로 Map을 초기화합니다.
        /// </summary>
        public void GameInitialize(int seed)
        {
            //맵 생성
            Point[] corners = new Point[4]; 
            Manager = GameManager.Instance;

            Manager.map.MapInitialize(Manager.map.RoomArgs);
            int size = Manager.map.mapSize;
            Manager.map.GenerateMaze(size, size, seed);
            Random rand = new Random(seed);

            // 시작, 끝 지점 생성
            corners[0] = new Point(1, 1);
            corners[1] = new Point(size - 3, 1);
            corners[2] = new Point(1, size - 3);
            corners[3] = new Point(size - 3, size - 3);
            int type = rand.Next(4);
            Manager.map.endPoint = corners[type];       // type이 끝점
            Manager.map.startPoint = corners[3 - type]; // 3- type이 끝점과 마주보는 점

            bool[] playerlocated = new bool[4];
            Array.Fill<bool>(playerlocated, false);
            List<Point> startPosArr = new List<Point>();
            startPosArr.Add(corners[3 - type]);
            for (int i = 0; i < 4; i++)
            {
                if (i == type || i == 3 - type) continue;
                startPosArr.Add(new Point((corners[i].X + 3 * corners[3 - type].X) / 4, (corners[i].Y + 3 * corners[3 - type].Y) / 4));
            }

            for (int i = 0; i < 4; i++)
            {
                int typeIndex = rand.Next(3);
                Manager.map.PlayerStartPosList[i] = startPosArr[typeIndex];
                Manager.map.PlayerPosList[i] = startPosArr[typeIndex];
            }
        }
        public bool[,] GenerateMaze(int width, int height,int seed)
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
            Random random = new Random(seed);
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
            //반전
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze.GetLength(1); j++)
                {
                    maze[i, j] = !maze[i, j];
                }
            }
            map = maze;
            return maze;

        }

        
    }

}
