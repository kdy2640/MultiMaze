using MazeClient.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MazeServer.Scenes
{
    internal class SettingServerScene
    {
        ServerGameManager manager;

        public SettingServerScene()
        {
            manager = ServerGameManager.Instance;
            manager.client.callbackFunctions.SettingSceneCallBack = null;
            manager.client.callbackFunctions.SettingSceneCallBack += SettingSceneCallBackFunction;
        }
        public void SettingSceneCallBackFunction(byte[] buffer, ServerEvent serverEvent, int playerCode)
        {
            //GameStatus 확인
            if (serverEvent.GameStatus != Define.GameState.SettingScene) return;
            switch (serverEvent.EventType)
            {
                case 0:
                    ReceiveCreateRoom(buffer, playerCode);
                    break;
                case 1:
                    break;
                case 2:
                    break;
            }
        }

        private void ReceiveCreateRoom(byte[] buffer, int playerCode)
        {
            //배열 선언
            byte[] roundBuffer = new byte[2];
            byte[] aiBuffer = new byte[2];
            byte[] sizeBuffer = new byte[2];
            // 배열 복사
            Array.Copy(buffer, 0, roundBuffer, 0, 2);
            Array.Copy(buffer, 2, aiBuffer, 0, 2);
            Array.Copy(buffer, 4, sizeBuffer, 0, 2);
            // 역직렬화
            short round = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(roundBuffer, 0));
            short ai = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(aiBuffer, 0));
            short size = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(sizeBuffer, 0));

            // roomArgs 만들어서 서버 roomArgs 적용
            RoomSettingArgs args = new RoomSettingArgs();
            args.Round = round;
            args.ai = (RoomSettingArgs.AIAlgorithm)ai;
            args.mapSize = (RoomSettingArgs.MapSize)size;
            manager.map.RoomArgs = args;

            byte[] Buffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(playerCode));
            ServerEvent serverEvent = new ServerEvent();
            serverEvent.GameStatus = Define.GameState.SettingScene;
            serverEvent.EventType = 0;
            manager.client.SendToPlayer(Buffer, serverEvent, playerCode);
        }
    }
}
