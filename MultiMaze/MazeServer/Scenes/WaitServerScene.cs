using MazeClient.Share;
using System;
using System.Drawing;
using System.Net;
using System.Text;

namespace MazeServer.Scenes
{
    internal class WaitSceneServerEvent : ServerEvent
    {
        public enum WaitSceneServerEventType
        {
            Chatting, Arguments, GameStart, None
        }

        public WaitSceneServerEvent() : base()
        {
            EventType = (int)WaitSceneServerEventType.None;
            GameStatus = Define.GameState.WaitScene;
        }

        public WaitSceneServerEvent(WaitSceneServerEventType waitSceneServerEventType) : base()
        {
            EventType = (int)waitSceneServerEventType;
            GameStatus = Define.GameState.WaitScene;
        }
    }

    internal class WaitServerScene
    {
        ServerGameManager manager;
        WaitSceneArgs args = new WaitSceneArgs();

        public WaitServerScene()
        {
            manager = ServerGameManager.Instance;
            manager.client.callbackFunctions.WaitSceneCallBack = null;
            manager.client.disconnectedRecallFunction = null;
            manager.client.callbackFunctions.WaitSceneCallBack = WaitSceneCallBackFunction;
            manager.client.disconnectedRecallFunction = resetDisconnectedPlayer;

            for (int i = 0; i < 4; i++)
            {
                args.playerColorArray[i] = Color.Red;
                args.playerArray[i] = 0;
            }
        }

        public void WaitSceneCallBackFunction(byte[] buffer, ServerEvent serverEvent, int playerCode)
        {
            if (serverEvent.GameStatus != Define.GameState.WaitScene) return;

            WaitSceneServerEvent.WaitSceneServerEventType eventType = (WaitSceneServerEvent.WaitSceneServerEventType)serverEvent.EventType;
            switch (eventType)
            {
                case WaitSceneServerEvent.WaitSceneServerEventType.None:
                    break;
                case WaitSceneServerEvent.WaitSceneServerEventType.Arguments:
                    ReceiveArgs(buffer, playerCode);
                    break;
                case WaitSceneServerEvent.WaitSceneServerEventType.GameStart:
                    SpreadSeed(buffer);
                    break;
                case WaitSceneServerEvent.WaitSceneServerEventType.Chatting:
                    SendChatMessage(buffer, playerCode);
                    break;
            }
        }

        private void SendChatMessage(byte[] buffer, int playerCode)
        {
            string message = Encoding.UTF8.GetString(buffer);
            byte[] messageBuffer = Encoding.UTF8.GetBytes(message);

            ServerEvent chatEvent = new ServerEvent(Define.GameState.WaitScene, (int)WaitSceneServerEvent.WaitSceneServerEventType.Chatting);
            manager.client.SendToAllPlayers(messageBuffer, chatEvent);
        }

        private async void ReceiveArgs(byte[] buffer, int playerCode)
        {
            byte[] colorBuffer = new byte[3];
            byte[] stateBuffer = new byte[2];
            byte[] roundBuffer = new byte[2];

            Array.Copy(buffer, 0, colorBuffer, 0, 3);
            Array.Copy(buffer, 3, stateBuffer, 0, 2);
            Array.Copy(buffer, 5, roundBuffer, 0, 2);

            short state = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(stateBuffer));
            Color color = Color.FromArgb(colorBuffer[0], colorBuffer[1], colorBuffer[2]);
            short round = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(roundBuffer));

            args.playerArray[playerCode - 1] = state;
            args.playerColorArray[playerCode - 1] = color;
            manager.map.PlayerColorList[playerCode - 1] = color;
            manager.nowRound = round;

            SendArgs();
        }

        private async void SpreadSeed(byte[] buffer)
        {
            int seed = new Random().Next();
            manager.map.seed = seed;
            setMazeBeforeGameStart(seed);
            byte[] sendbuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((int)seed));
            ServerEvent serverEvent = new ServerEvent(Define.GameState.WaitScene, (int)WaitSceneServerEvent.WaitSceneServerEventType.GameStart);
            manager.client.SendToAllPlayers(sendbuffer, serverEvent);
            manager.ServerScene.SetLog($"{manager.nowRound} 라운드 시작");
            manager.client.isGameStart = true;
        }

        public void setMazeBeforeGameStart(int seed)
        {
            Random rand = new Random(seed);
            Point[] corners = new Point[4];
            int size = manager.map.mapSize;
            corners[0] = new Point(1, 1);
            corners[1] = new Point(size - 3, 1);
            corners[2] = new Point(1, size - 3);
            corners[3] = new Point(size - 3, size - 3);
            int type = rand.Next(4);
            manager.map.endPoint = corners[type];
            manager.map.startPoint = corners[3 - type];

            bool[] playerlocated = new bool[4];
            Array.Fill<bool>(playerlocated, false);
            List<Point> startPosArr = new List<Point>
            {
                corners[3 - type]
            };
            for (int i = 0; i < 4; i++)
            {
                if (i == type || i == 3 - type) continue;
                startPosArr.Add(new Point((corners[i].X + 3 * corners[3 - type].X) / 4, (corners[i].Y + 3 * corners[3 - type].Y) / 4));
            }

            for (int i = 0; i < 4; i++)
            {
                int typeIndex = rand.Next(3);
                manager.map.PlayerStartPosList[i] = startPosArr[typeIndex];
                manager.map.PlayerPosList[i] = startPosArr[typeIndex];

                if (args.playerArray[i] == 2)
                {
                    args.playerArray[i] = 1;
                }
            }
            manager.SeedList[manager.nowRound - 1] = seed;
        }

        private void SendArgs()
        {
            byte[] buffer = new byte[24];
            byte[] stateBuffer = new byte[2];
            byte[] colorBuffer = new byte[3];
            for (int i = 0; i < 4; i++)
            {
                short state = args.playerArray[i];
                Color color = args.playerColorArray[i];

                stateBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)state));
                colorBuffer = new byte[3];
                colorBuffer[0] = color.R;
                colorBuffer[1] = color.G;
                colorBuffer[2] = color.B;

                Array.Copy(colorBuffer, 0, buffer, 5 * i, 3);
                Array.Copy(stateBuffer, 0, buffer, 5 * i + 3, 2);
            }
            byte[] hostBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)manager.client.HostPlayerNum));

            Array.Copy(hostBuffer, 0, buffer, 22, 2);

            ServerEvent serverEvent = new ServerEvent(Define.GameState.WaitScene, 1);

            manager.client.SendToAllPlayers(buffer, serverEvent);
        }

        private void resetDisconnectedPlayer(int playerCode)
        {
            args.playerArray[playerCode - 1] = 0;
            SendArgs();
        }
    }

    class WaitSceneArgs
    {
        public short[] playerArray = new short[4];
        public Color[] playerColorArray = new Color[4];
    }
}
