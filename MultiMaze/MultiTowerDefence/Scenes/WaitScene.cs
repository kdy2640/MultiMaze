using System;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using MazeClient.Share;
using static MazeClient.WaitScene;

namespace MazeClient
{
    public partial class WaitScene : Form
    {
        GameManager Manager;
        ServerManager serverManager;
        private bool _isHost = false;
        private bool _isPlayerReady = false;
        private bool _isAllPlayerReady = true;
        private int _playerCode = 0; // 플레이어 코드 추가
        private GameRoom gameroom = new GameRoom();
        private PictureBox[] _playerPictureBoxList = new PictureBox[4];

        public WaitScene()
        {
            InitializeComponent();
            LoadPlayerColors();
            Initialize();
        }

        private void LoadPlayerColors()
        {
        }


        private void Initialize()
        {
            Manager = GameManager.Instance;
            _playerCode = Manager.PlayerCode;
            _playerPictureBoxList[0] = PicPlayer1;
            _playerPictureBoxList[1] = PicPlayer2;
            _playerPictureBoxList[2] = PicPlayer3;
            _playerPictureBoxList[3] = PicPlayer4;
            if (_playerCode == 1)
            {
                _isHost = true;
            }
            else
            {
                _isHost = false;
            }
        }
        #region 버튼 이벤트
        private async void BtnStart_Click(object sender, EventArgs e)
        {
            //isAllPlayerReady 관련 상호작용 추가하기
            if (_isHost && _isAllPlayerReady)
            {
                MessageBox.Show("게임이 시작됩니다.");
                Manager.scene.ChangeGameState(this, Define.GameState.InGameScene);
            }
            else if (!_isHost)
            {
                MessageBox.Show("호스트만 게임을 시작할 수 있습니다.");
            }
            else
            {
                MessageBox.Show("모든 플레이어가 준비완료 상태가 아닙니다.");
            }
        }
        private void BtnReady_Click(object sender, EventArgs e)
        {
            _isPlayerReady = !_isPlayerReady;
            BtnReady.Text = _isPlayerReady ? "준비" : "준비완료";
        }
        private void BtnLeave_Click(object sender, EventArgs e)
        {
            // 이상함 내가 나가는데 해야할건 나 나가요 메시지 보내주면 됨
            //Player leavingPlayer = FindLeavingPlayer();
            //if (leavingPlayer != null)
            //{
            //    gameroom.PlayerLeft(leavingPlayer);
            //    MessageBox.Show("플레이어가 떠났습니다.");
            //}
            Manager.scene.ChangeGameState(this, Define.GameState.SettingScene);
        }
        private async void BtnSend_Click(object sender, EventArgs e)
        {
            SendMessage();

        }
        private void BtnColor_Click(object sender, EventArgs e)
        {
            if(cld.ShowDialog()== DialogResult.OK)
            {
                Manager.map.PlayerColorList[_playerCode-1] = cld.Color;
                _playerPictureBoxList[_playerCode-1].Invalidate();
            }

        }
        #endregion

        #region 플레이어코드 동기화 쉽지 않음 - 나중에


        private Player FindLeavingPlayer()
        {
            return null;
        }
        public class Player
        {
            public int PlayerNumber { get; set; }
            public string Name { get; set; }
        }

        public class GameRoom
        {
            public List<Player> Players { get; set; } = new List<Player>();

            public void AddPlayer(Player player)
            {
                Players.Add(player);
                AdjustPlayerNumbers();
            }

            public void PlayerLeft(Player player)
            {
                Players.Remove(player);
                AdjustPlayerNumbers();
            }

            private void AdjustPlayerNumbers()
            {
                int number = 1;
                foreach (var player in Players)
                {
                    player.PlayerNumber = number++;
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // 안가짐
            Manager.scene.ChangeGameState(this, Define.GameState.InGameScene);
        }




        #endregion


        // 채팅 (서버랑 연결 X)
        private async void SendMessage()
        {
            string message = RtbChat.Text.Trim();
            if (!string.IsNullOrEmpty(message))
            {
                try
                {
                    RtbChat.AppendText($"나: {message}\n");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"채팅 메시지 전송 실패: {ex.Message}");
                }
            }
        }
        private void AddMessageToChat(string message)
        {
            RtbChat.AppendText(message + Environment.NewLine);

            RtbChat.SelectionStart = RtbChat.Text.Length;
            RtbChat.ScrollToCaret();

        }

        private void PicPlayer_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pic = sender as PictureBox;
            int index = pic.Name[9] - 49;
            SolidBrush br = new SolidBrush(Manager.map.PlayerColorList[index]);
            e.Graphics.FillEllipse(br, pic.Width / 4, pic.Height / 4, pic.Width / 2, pic.Height / 2);
        }

        
    }
}
