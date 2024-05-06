using System;
using System.Drawing;
using System.IO;
using System.Numerics;
using System.Text;
using System.Windows.Forms;
using MazeClient.Share;

namespace MazeClient
{
    public partial class WaitScene : Form
    {
        GameManager Manager;
        ServerManager serverManager;
        private bool _isHost = false;
        private bool _isPlayerReady = false;
        private GameRoom gameroom = new GameRoom();

        public static class PlayerColors
        {
            public static Color PicPlayer1Color { get; set; } = Color.Red;
            public static Color PicPlayer2Color { get; set; } = Color.Blue;
            public static Color PicPlayer3Color { get; set; } = Color.Green;
            public static Color PicPlayer4Color { get; set; } = Color.Purple;
        }

        public WaitScene()
        {
            InitializeComponent();
            LoadPlayerColors();
            InitializeAsync();
            Manager = GameManager.Instance;
            serverManager = new ServerManager();
        }

        private void LoadPlayerColors()
        {
            // SpriteMap.png에서 받아오기(?)
        }

        private async void InitializeAsync()
        {
            try
            {
                bool isConnected = await serverManager.ConnectServer("127.0.0.1", 20000);
                if (isConnected)
                {
                    MessageBox.Show("호스트입니다.");
                    _isHost = true;
                }
                else
                {
                    MessageBox.Show("호스트가 아닙니다.");
                    _isHost = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"호스트를 찾을수 없습니다.");
                _isHost = false;
            }
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            if (_isHost && _isPlayerReady)
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
            Player leavingPlayer = FindLeavingPlayer(); 
            if (leavingPlayer != null)
            {
                gameroom.PlayerLeft(leavingPlayer); 
                MessageBox.Show("플레이어가 떠났습니다.");
            }
            Manager.scene.ChangeGameState(this, Define.GameState.SettingScene);
        }

        private Player FindLeavingPlayer()
        {
            return gameroom.Players.FirstOrDefault(); 
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

       
        private async void BtnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

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
    }
}
