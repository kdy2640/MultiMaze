using MazeClient.Scenes;
using MazeClient.Share;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Net;
using System.Text;
using System.Windows.Forms;
using static MazeClient.Share.Define;

namespace MazeClient
{
    public partial class WaitScene : Form
    {
        GameManager Manager;
        private bool _isHost = false;
        private bool _isPlayerReady = false;
        private int _playerCode = 0; // 플레이어 번호는 1번부터 
        private PictureBox[] _playerPictureBoxList = new PictureBox[4];
        WaitSceneArgs args = new WaitSceneArgs();

        public WaitScene()
        {
            InitializeComponent();
            Initialize();
        }

        private void Initialize()
        {
            Manager = GameManager.Instance;
            Manager.nowRound++;
            _playerCode = Manager.PlayerCode;
            Manager.server.callbackFunctions.WaitSceneCallBack = null;
            Manager.server.callbackFunctions.WaitSceneCallBack += WaitSceneCallBackFunction;

            args.playerArray[_playerCode - 1] = 1;
            args.playerColorArray[_playerCode - 1] = Color.Red;

            _playerPictureBoxList[0] = PicPlayer1;
            _playerPictureBoxList[1] = PicPlayer2;
            _playerPictureBoxList[2] = PicPlayer3;
            _playerPictureBoxList[3] = PicPlayer4;

            // 당신 텍스트 부여
            Player1.Invalidate();
            Player2.Invalidate();
            Player3.Invalidate();
            Player4.Invalidate();
            //IP전시
            hostLabel.Text += Manager.server.ServerIP + ":" + Manager.server.ServerPort;
            SendToServerArgs();
            //그림자

            shadowPictureBox1.Location = new Point(playerPanel.Location.X + 7, playerPanel.Location.Y + 7);
            shadowPictureBox1.Size = playerPanel.Size;
            shadowPictureBox1.SendToBack();
        }

        #region Form 이벤트
        private void Player_Paint(object sender, PaintEventArgs e)
        {
            Label PlayerLabel = sender as Label;
            int index = PlayerLabel.Name[6] - 48;
            if (index == _playerCode)
            {
                PlayerLabel.Text = $"나 (당신)";
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            //isAllPlayerReady 관련 상호작용 추가하기
            if (_isHost)
            {
                bool startTrigger = true;
                for (int i = 0; i < 4; i++)
                {
                    if (args.playerArray[i] == 0) continue;
                    if (args.playerArray[i] == 1)
                    {
                        startTrigger = false;
                        break;
                    }
                }
                if (startTrigger)
                {
                    MessageBox.Show("게임이 시작됩니다.");
                    StartGame();
                }
                else
                {
                    MessageBox.Show("모든 플레이어가 준비완료 상태가 아닙니다.");
                }
            }
            else
            {
                MessageBox.Show("호스트만 게임을 시작할 수 있습니다.");
            }
        }

        private void BtnReady_Click(object sender, EventArgs e)
        {
            if (_isPlayerReady)
            {
                args.playerArray[_playerCode - 1] = 2;
            }
            else
            {
                args.playerArray[_playerCode - 1] = 1;
            }
            _isPlayerReady = !_isPlayerReady;
            BtnReady.Text = _isPlayerReady ? "준비완료" : "준비";

            SendToServerArgs();
        }

        private void BtnLeave_Click(object sender, EventArgs e)
        {
            Manager.server.LeaveServer();
            Manager.scene.ChangeGameState(this, Define.GameState.MainScene);
        }

        private void BtnSend_Click(object sender, EventArgs e)
        {
            SendMessage(_playerCode);
        }

        private void BtnColor_Click(object sender, EventArgs e)
        {
            if (cld.ShowDialog() == DialogResult.OK)
            {
                Manager.map.PlayerColorList[_playerCode - 1] = cld.Color;
                args.playerColorArray[_playerCode - 1] = cld.Color;
                _playerPictureBoxList[_playerCode - 1].Invalidate();
                SendToServerArgs();
            }
        }

        private void SendMessage(int playerCode)
        {
            string message = inputTb.Text.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                string chatMessage = $"Player{playerCode}: {message}";
                byte[] messageBuffer = Encoding.UTF8.GetBytes(chatMessage);

                WaitSceneServerEvent chatEvent = new WaitSceneServerEvent(WaitSceneServerEvent.WaitSceneServerEventType.Chatting);

                Manager.server.SendToServerAsync(messageBuffer, chatEvent);

                inputTb.Text = "";
                inputTb.Focus();
            }
        }

        private void ReceiveChatMessage(byte[] buffer)
        {
            string message = Encoding.UTF8.GetString(buffer);

            if (message.StartsWith($"Player{_playerCode}: "))
            {
                message = "나: " + message.Substring(message.IndexOf(": ") + 2);
            }

            RtbChat.Invoke(new Action(() =>
            {
                RtbChat.AppendText($"{message}\n");
                RtbChat.SelectionStart = RtbChat.Text.Length;
                RtbChat.ScrollToCaret();
            }));
        }



        Font font = new Font("Arial", 16);
        private void PicPlayer_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            int index = pic.Name[9] - 49;
            //접속 안함
            if (args.playerArray[index] == 0)
            {
                e.Graphics.Clear(Color.Black);
                return;
            }
            // 레디 안함
            if (args.playerArray[index] == 1)
            {
                e.Graphics.Clear(Color.Gray);
            }
            // 레디
            else
            {
                e.Graphics.Clear(Color.White);
            }
            SolidBrush br = new SolidBrush(Manager.map.PlayerColorList[index]);
            e.Graphics.FillEllipse(br, pic.Width / 4, pic.Height / 4, pic.Width / 2, pic.Height / 2);
            if (index + 1 == args.hostPlayerNum)
            {
                e.Graphics.DrawString("HOST", font, Brushes.Black, new PointF(0, 0));
            }
        }

        private void inputTb_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnSend.PerformClick();
            }
        }
        #endregion

        #region 서버 파싱

        class WaitSceneArgs
        {
            /// <summary>
            /// 0은 접속안함, 1은 준비안함, 2는 준비상태
            /// </summary>
            public short[] playerArray = new short[4];
            public Color[] playerColorArray = new Color[4];
            public int hostPlayerNum = 1;
        }

        class WaitSceneServerEvent : ServerEvent
        {
            public enum playerState
            {
                NotConnected, NotReady, Ready, None
            }
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

        public void WaitSceneCallBackFunction(byte[] buffer, ServerEvent serverEvent)
        {
            if (serverEvent.GameStatus != Define.GameState.WaitScene) return;

            WaitSceneServerEvent.WaitSceneServerEventType eventType = (WaitSceneServerEvent.WaitSceneServerEventType)serverEvent.EventType;
            switch (eventType)
            {
                case WaitSceneServerEvent.WaitSceneServerEventType.Chatting:
                    ReceiveChatMessage(buffer);
                    break;
                case WaitSceneServerEvent.WaitSceneServerEventType.Arguments:
                    ReceiveArgs(buffer);
                    break;
                case WaitSceneServerEvent.WaitSceneServerEventType.GameStart:
                    ReceiveSeed(buffer);
                    break;
                case WaitSceneServerEvent.WaitSceneServerEventType.None:
                    break;
            }
        }


        #endregion
        #region 서버 송신 함수
        private void SendToServerArgs()
        {
            Color color = Manager.map.PlayerColorList[_playerCode - 1];
            WaitSceneServerEvent.playerState state = WaitSceneServerEvent.playerState.NotReady;
            if (_isPlayerReady)
            {
                state = WaitSceneServerEvent.playerState.Ready;
            }
            byte[] buffer = new byte[7];
            byte[] stateBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)state));
            byte[] roundBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)Manager.nowRound));
            byte[] colorBuffer = new byte[3];
            colorBuffer[0] = color.R;
            colorBuffer[1] = color.G;
            colorBuffer[2] = color.B;

            Array.Copy(colorBuffer, 0, buffer, 0, 3);
            Array.Copy(stateBuffer, 0, buffer, 3, 2);
            Array.Copy(roundBuffer, 0, buffer, 5, 2);

            WaitSceneServerEvent serverEvent = new WaitSceneServerEvent(WaitSceneServerEvent.WaitSceneServerEventType.Arguments);
            Manager.server.SendToServerAsync(buffer, serverEvent);
        }

        private void StartGame()
        {
            byte[] buffer = new byte[4];
            buffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(4));
            WaitSceneServerEvent serverEvent = new WaitSceneServerEvent(WaitSceneServerEvent.WaitSceneServerEventType.GameStart);
            Manager.server.SendToServerAsync(buffer, serverEvent);
        }
        #endregion

        #region 서버 수신 함수

        private async void ReceiveSeed(byte[] buffer)
        {
            int seed = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(buffer));
            Manager.map.seed = seed;

            GameInitialize(seed);
        }

        private async void GameInitialize(int seed)
        {
            Manager.map.GameInitialize(seed);
            await Task.Delay(10);

            CountDownScene.StartCountDown(this);
            await Task.Delay(7250); // 로딩 시간 조정  
            CountDownScene.StopCountDown();
            Manager.scene.ChangeGameState(this, Define.GameState.InGameScene);
        }

        private async void ReceiveArgs(byte[] buffer)
        {
            byte[] stateBuffer = new byte[2];
            byte[] colorBuffer = new byte[3];
            short state = 0;
            Color color = Color.Red;
            for (int i = 0; i < 4; i++)
            {
                Array.Copy(buffer, 5 * i, colorBuffer, 0, 3);
                Array.Copy(buffer, 5 * i + 3, stateBuffer, 0, 2);

                state = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(stateBuffer, 0));
                color = Color.FromArgb(colorBuffer[0], colorBuffer[1], colorBuffer[2]);

                args.playerArray[i] = state;
                if (state == 0)
                {
                    Manager.server.PlayerConnectArray[i] = false;
                }
                else
                {
                    Manager.server.PlayerConnectArray[i] = true;
                }
                args.playerColorArray[i] = color;
                Manager.map.PlayerColorList[i] = color;
            }

            byte[] hostBuffer = new byte[2];
            Array.Copy(buffer, 22, hostBuffer, 0, 2);
            short host = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(hostBuffer, 0));
            args.hostPlayerNum = host;
            ApplyArgs();
        }

        private void ApplyArgs()
        {
            //색상 초기화
            for (int i = 0; i < 4; i++)
            {
                _playerPictureBoxList[i].Invalidate();
            }
            //host
            if (_playerCode == args.hostPlayerNum)
            {
                _isHost = true;
            }
        }
        #endregion

        private void WaitScene_Load(object sender, EventArgs e)
        {

        }
        public Color ShadowColor = Color.FromArgb(32, 32, 32);
        public int ShadowOffset = 2;

        private void wait_label_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Label lbl = sender as Label;
            lbl.AutoSize = true;
            lbl.Text = "                  ";
            using (Brush shadowBrush = new SolidBrush(ShadowColor))
            {
                e.Graphics.DrawString(Manager.nowRound.ToString() + " 라운드 대기", lbl.Font, shadowBrush, new PointF(ShadowOffset, ShadowOffset));
            }

            // 실제 텍스트
            using (Brush textBrush = new SolidBrush(Color.LightGray))
            {
                e.Graphics.DrawString(Manager.nowRound.ToString() + " 라운드 대기", lbl.Font, textBrush, new PointF(0, 0));
            }
        }
    }
}
