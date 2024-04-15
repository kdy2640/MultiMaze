using MazeClient.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MazeClient.Share
{
    public class Map
    {
        public bool[,] map = new bool[100, 100];
        public int mapSize = 100;

        //Setting에서 입력하거나 Main에서 서버에게 받아오기
        public MapSettingArgs MapArgs = new MapSettingArgs();

        //WaitScene 마지막에 서버에서 받아올 것들
        public int seed;
        public Point startPoint = new Point(10, 10);
        public Point endPoint = new Point(10, 10);
        public List<Point> PlayerStartPosList = new List<Point>();
        public List<Point> PlayerPosList = new List<Point>();   
        public List<Color> PlayerColorList = new List<Color>();
        

        public Map()
        {
            mapSize = 100;
            // 임시
            for (int i = 0; i < GameManager.MAX_PLAYER_NUM; i++)
            {
                PlayerStartPosList.Add(new Point(i, i));
                PlayerPosList.Add(new Point(i, i));
                PlayerColorList.Add(Color.Red);
            }
        }
        public Map(int mapSize)
        {
            this.mapSize = mapSize;
        }

        //길이 있어야함.
        public void FindPath( ) // 알고리즘?
        {

        }

        public void MakeMaze(int seed)
        {

        }



        
    }

}
