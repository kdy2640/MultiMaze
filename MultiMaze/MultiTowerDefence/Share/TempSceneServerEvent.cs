using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MazeClient
{
    [Serializable] // 직렬화가능
    class TempSceneServerEvent : ServerEvent
    {
        public enum TempSceneServerEventType
        {
            temp1, temp2
        }

        public TempSceneServerEventType EventType;
    }
}
