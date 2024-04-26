using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeClient.Share
{
    public class MapSettingArgs
    {
        public enum AIAlgorithm
        {
            BFS,DFS,Astart
        }
        public enum MapSize
        {
            Small,Medium,Big
        }
        public int PlayerCount;
        public int Round;
        public AIAlgorithm ai;
        public MapSize mapSize;


    }
}
