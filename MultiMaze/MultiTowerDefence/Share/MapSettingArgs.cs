using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeClient.Share
{
    public class MapSettingArgs
    {
        public enum AIAlgo
        {
            BFS,DFS,Dijkstra,Astart
        }
        public enum MapSize
        {
            Small,Medium,Big
        }

    }
}
