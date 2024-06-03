using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeClient.Share
{
    public class RoomSettingArgs
    {
        public enum AIAlgorithm
        {
            BFS,DFS,Astar
        }
        public enum MapSize
        {
            Small,Medium,Big
        } 
        public int Round = 1;
        public AIAlgorithm ai =  AIAlgorithm.BFS;
        public MapSize mapSize = MapSize.Medium; 


    }
}
