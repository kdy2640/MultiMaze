using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeClient.Share
{

    // 상속용
    [Serializable]
    public class ServerEvent
    {
        public Define.GameState GameStatus { get; set; }

        public int EventType { get; set; }
        public ServerEvent() : this(0,0)
        {
        }
        public ServerEvent(int gameStatus,int eventType) 
        {
            GameStatus = (Define.GameState)gameStatus;
            EventType = eventType;
        }
        public ServerEvent(Define.GameState gameStatus, int eventType)
        {
            GameStatus = gameStatus;
            EventType = eventType;
        }
    }

}
