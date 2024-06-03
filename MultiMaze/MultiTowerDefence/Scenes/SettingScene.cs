using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MazeClient.Share;
using System.Diagnostics;
using static MazeClient.Share.RoomSettingArgs;
using static System.Resources.ResXFileRef;
using System.Runtime.InteropServices;
using System.Security.Policy;
using MazeClient.Scenes;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace MazeClient
{
    public partial class SettingScene : Form
    {
        GameManager Manager;
        public SettingScene()
        {
            InitializeComponent();

            //매니저 할당
            Manager = GameManager.Instance;
            Manager.server.callbackFunctions.SettingSceneCallBack = null;
            Manager.server.callbackFunctions.SettingSceneCallBack += SettingSceneCallBackFunction;
            textBox1.Text = GetLocalIPAddress();

            shadowPictureBox3.Location = new Point(gameRoundPanel.Location.X + 7, gameRoundPanel.Location.Y  + 7);
            shadowPictureBox3.Size = gameRoundPanel.Size;
            shadowPictureBox4.Location = new Point(algorithmPanel.Location.X + 7, algorithmPanel.Location.Y + 7);
            shadowPictureBox4.Size = algorithmPanel.Size;
            shadowPictureBox5.Location = new Point(mapPanel.Location.X + 7, mapPanel.Location.Y + 7);
            shadowPictureBox5.Size = mapPanel.Size;

            shadowPictureBox3.SendToBack();
            shadowPictureBox4.SendToBack();
            shadowPictureBox5.SendToBack();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager.scene.ChangeGameState(this, Define.GameState.WaitScene);
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        private async void makeRoomBtn_Click(object sender, EventArgs e)
        {
            LoadingScene.StartLoading(this);
            // 서버 프로그램 실행
            if (!Manager.server.StartServer()) MessageBox.Show("서버 실행 실패");

            bool connectResult = await Manager.server.ConnectServer("127.0.0.1", -1);
            if (connectResult == false)
            {
                MessageBox.Show("서버 연결 실패");
                return;
            }
            SendCreateRoom();

        }

        private void cancelMakeRoomBtn_Click(object sender, EventArgs e)
        {
            Manager.scene.ChangeGameState(this, Define.GameState.MainScene);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        public void SettingSceneCallBackFunction(byte[] buffer, ServerEvent serverEvent)
        {
            //GameStatus 확인
            if (serverEvent.GameStatus != Define.GameState.SettingScene) return;

            switch (serverEvent.EventType)
            {
                case 0:
                    receiveServerIpPort();
                    break;
                case 1: // None
                    break;
            }
        }

        private async void receiveServerIpPort()
        {
            Manager.nowRound = 0;
            await Task.Delay(10);
            LoadingScene.StopLoading();
            Manager.scene.ChangeGameState(this, Define.GameState.WaitScene);
        }
        private void SendCreateRoom()
        {
            short round = (short)(gameCount1.Checked ? 1 :
                                  gameCount3.Checked ? 3 :
                                  5);
            short algorithm = (short)(computerBFS.Checked ? AIAlgorithm.BFS :
                              computerDFS.Checked ? AIAlgorithm.DFS :
                              AIAlgorithm.Astar);
            short mapSize = (short)(size30.Checked ? MapSize.Small :
                                    size50.Checked ? MapSize.Medium :
                                    MapSize.Big);

            // 클라이언트 room 설정 update
            RoomSettingArgs args = new RoomSettingArgs();
            args.Round = round;
            args.ai = (RoomSettingArgs.AIAlgorithm)algorithm;
            args.mapSize = (RoomSettingArgs.MapSize)mapSize;
            Manager.map.RoomArgs = args;

            byte[] roundBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(round));
            byte[] algorithmBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(algorithm));
            byte[] mapSizeBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(mapSize));
            byte[] buffer = new byte[roundBuffer.Length + algorithmBuffer.Length + mapSizeBuffer.Length];
            // 합체
            Array.Copy(roundBuffer, 0, buffer, 0, roundBuffer.Length);
            Array.Copy(algorithmBuffer, 0, buffer, 2, algorithmBuffer.Length);
            Array.Copy(mapSizeBuffer, 0, buffer, 4, mapSizeBuffer.Length);

            SettingSceneServerEvent serverEvent = new SettingSceneServerEvent(SettingSceneServerEvent.SettingSceneServerEventType.SendCreateRoom);
            Manager.server.SendToServerAsync(buffer, serverEvent);
        }

        private void size50_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void computerAster_CheckedChanged(object sender, EventArgs e)
        {

        }

        public Color ShadowColor = Color.FromArgb(32, 32, 32);
        public int ShadowOffset = 2;
        private void makeRoom_label_Paint(object sender, PaintEventArgs e)
        {

            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Label lbl = sender as Label;
            lbl.AutoSize = true;
            lbl.Text = "           ";
            using (Brush shadowBrush = new SolidBrush(ShadowColor))
            {
                e.Graphics.DrawString("게임설정", lbl.Font, shadowBrush, new PointF(ShadowOffset, ShadowOffset));
            }

            // 실제 텍스트
            using (Brush textBrush = new SolidBrush(Color.LightGray))
            {
                e.Graphics.DrawString("게임설정", lbl.Font, textBrush, new PointF(0, 0));
            }
        }

        private void SettingScene_Load(object sender, EventArgs e)
        {

        }
    }
}
public class SettingSceneServerEvent : ServerEvent
{
    public enum SettingSceneServerEventType
    {
        SendCreateRoom, None
    }


    public SettingSceneServerEvent() : base()
    {
        EventType = (int)SettingSceneServerEventType.None;
        GameStatus = Define.GameState.SettingScene;
    }
    public SettingSceneServerEvent(SettingSceneServerEventType inGameSceneServerEventType) : base()
    {
        EventType = (int)inGameSceneServerEventType;
        GameStatus = Define.GameState.SettingScene;
    }
}