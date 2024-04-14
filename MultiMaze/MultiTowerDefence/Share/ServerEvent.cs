using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MazeClient.Define;

namespace MazeClient
{

    // 상속용
    [Serializable]
    class ServerEvent
    {
        public Define.GameState GameStatus { get; set; }
    }

}
