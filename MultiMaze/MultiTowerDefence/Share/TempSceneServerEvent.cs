using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using MazeClient.Share;
namespace MazeClient
{
    [Serializable] // 직렬화가능 
    public class TempSceneServerEvent : ServerEvent
    {
        public enum TempSceneServerEventType
        {
            move, over,exit
        }
        

        public TempSceneServerEvent() : base()
        {
            EventType = (int)TempSceneServerEventType.move;
            GameStatus = Define.GameState.MainScene;
        }
    }
}
