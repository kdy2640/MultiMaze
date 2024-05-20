
using MazeClient.Share;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace MazeServer.Scenes
{
    internal class WaitServerScene
    {
        ServerGameManager manager;
        WaitSceneArgs args = new WaitSceneArgs();
        public WaitServerScene()
        {
            manager = ServerGameManager.Instance;
            manager.client.callbackFunctions.WaitSceneCallBack = null;
            manager.client.disconnectedRecallFunction = null;
            manager.client.callbackFunctions.WaitSceneCallBack += WaitSceneCallBackFunction;
            manager.client.disconnectedRecallFunction += resetDisconnectedPlayer;
            for (int i = 0; i < 4; i++)
            {
                args.playerColorArray[i] = Color.Red;
                args.playerArray[i] = 0;
            }

        }
        public void WaitSceneCallBackFunction(byte[] buffer, ServerEvent serverEvent, int playerCode)
        {
            //GameStatus 확인
            if (serverEvent.GameStatus != Define.GameState.WaitScene) return;
            switch (serverEvent.EventType)
            {
                case 0:
                    break;
                case 1:
                    ReceiveArgs(buffer, playerCode);
                    break;
                case 2:
                    SpreadSeed(buffer);
                    break;
            }
        }

        private async void ReceiveArgs(byte[] buffer, int playerCode)
        {
            byte[] colorBuffer = new byte[3];
            byte[] stateBuffer = new byte[2];
            byte[] roundBuffer = new byte[2];
            byte[] chatBuffer = new byte[100];

            Array.Copy(buffer, 0, colorBuffer, 0, 3);
            Array.Copy(buffer, 3, stateBuffer, 0, 2);
            Array.Copy(buffer, 5, roundBuffer, 0, 2);
            Array.Copy(buffer, 7, chatBuffer, 0, 100);

            short state = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(stateBuffer));
            Color color = Color.FromArgb(colorBuffer[0], colorBuffer[1], colorBuffer[2]);
            short round = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(roundBuffer));
            string message = Encoding.UTF8.GetString(chatBuffer).TrimEnd('\0');

            args.playerArray[playerCode - 1] = state;
            args.playerColorArray[playerCode - 1] = color;
            args.chatBuffer[playerCode - 1] = chatBuffer;
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
            ServerEvent serverEvent = new ServerEvent(Define.GameState.WaitScene, 2);
            manager.client.SendToAllPlayers(sendbuffer, serverEvent);
            manager.ServerScene.SetLog($"{manager.nowRound} 라운드 시작");
            manager.client.isGameStart = true;
        }
        /// <summary> 
        /// </summary>
        /// <param name="seed"></param> 
        public void setMazeBeforeGameStart(int seed)
        {
            Random rand = new Random(seed);
            Point[] corners = new Point[4];
            int size = manager.map.mapSize;
            // 시작, 끝 지점 생성
            corners[0] = new Point(1, 1);
            corners[1] = new Point(size - 3, 1);
            corners[2] = new Point(1, size - 3);
            corners[3] = new Point(size - 3, size - 3);
            int type = rand.Next(4);
            manager.map.endPoint = corners[type];       // type이 끝점
            manager.map.startPoint = corners[3 - type]; // 3- type이 끝점과 마주보는 점

            bool[] playerlocated = new bool[4];
            Array.Fill<bool>(playerlocated, false);
            List<Point> startPosArr = new List<Point>();
            startPosArr.Add(corners[3 - type]);
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
            byte[] buffer = new byte[428];
            byte[] stateBuffer;
            byte[] colorBuffer;
            for (int i = 0; i < 4; i++)
            {
                short state = args.playerArray[i];
                Color color = args.playerColorArray[i];
                byte[] chatBuffer = args.chatBuffer[i];

                stateBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)state));
                colorBuffer = new byte[3];
                colorBuffer[0] = color.R;
                colorBuffer[1] = color.G;
                colorBuffer[2] = color.B;

                Array.Copy(colorBuffer, 0, buffer, 107 * i, 3);
                Array.Copy(stateBuffer, 0, buffer, 107 * i + 3, 2);
                Array.Copy(chatBuffer, 0, buffer, 107 * i + 5, chatBuffer.Length);
            }
            byte[] hostBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)manager.client.HostPlayerNum));

            Array.Copy(hostBuffer, 0, buffer, 428, 2);

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
        public byte[][] chatBuffer = new byte[4][]; // 각 플레이어에 대한 chatBuffer 배열

        public WaitSceneArgs()
        {
            for (int i = 0; i < 4; i++)
            {
                chatBuffer[i] = new byte[100]; // 각 플레이어의 chatBuffer 초기화
            }
        }
    }
}
