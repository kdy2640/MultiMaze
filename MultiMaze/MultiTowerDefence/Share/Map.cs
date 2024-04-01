using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MazeClient
{
    class Map
    {
        List<bool> map = new List<bool> ();
        int mapSize = 5;
        
        Point startPoint = new Point(0,0);
        Point endPoint = new Point(10, 10);

        public Map()
        {
            mapSize = 5;
        }
        public Map(int mapSize)
        {
            this.mapSize = mapSize;
        }





        //길이 있어야함.
        public void FindPath()
        {

        }



        
    }

}
