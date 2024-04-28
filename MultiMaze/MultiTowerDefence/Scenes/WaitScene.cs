
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeClient
{
    public partial class WaitScene : Form
    {
        GameManager Manager;
        public WaitScene()
        {
            InitializeComponent();

            Manager = GameManager.Instance;
        }

        private void textBox1_TextChange(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Manager.scene.ChangeGameState(this, Define.GameState.InGameScene);
        }
        private PictureBox _mazePictureBox = new PictureBox();
        private CheckBox _hostCheckBox = new CheckBox(); // 호스트 여부를 선택할 체크박스
        private int _countdown = 5;

        public static class PlayerColors
        {
            public static Color Player1Color { get; set; } = Color.Red;
            public static Color Player2Color { get; set; } = Color.Blue;
        }

        private bool _isHost = false;
        private bool _isPlayerReady = false;

        private void InitializeControls()
        {
            _mazePictureBox.Size = new Size(300, 300);
            _mazePictureBox.Location = new Point(10, 10);
            _mazePictureBox.BorderStyle = BorderStyle.FixedSingle;
            _mazePictureBox.Visible = false;
            this.Controls.Add(_mazePictureBox);

            _hostCheckBox.Text = "I am the Host";
            _hostCheckBox.Location = new Point(320, 10);
            _hostCheckBox.AutoSize = true;
            _hostCheckBox.CheckedChanged += HostCheckBox_CheckedChanged;
            this.Controls.Add(_hostCheckBox);
        }

        private void HostCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _isHost = _hostCheckBox.Checked; // 예시
        }

        private async void BtnStart_Click(object sender, EventArgs e)
        {
            if (_isHost && _isPlayerReady)
            {
                await StartCountdown(_countdown);
                StartGame();
            }
            else if (!_isHost)
            {
                MessageBox.Show("Only the host can start the game.");
            }
            else
            {
                MessageBox.Show("Not all players are ready.");
            }
        }

        private void ApplyPlayerColors()
        {
            PicPlayer1.BackColor = PlayerColors.Player1Color;
            PicPlayer2.BackColor = PlayerColors.Player2Color;
        }

        private void PicPlayer1_Click(object sender, EventArgs e)
        {
            if (ChangePlayerColor(PicPlayer1))
            {
                PlayerColors.Player1Color = PicPlayer1.BackColor;
            }
        }

        private void PicPlayer2_Click(object sender, EventArgs e)
        {
            if (ChangePlayerColor(PicPlayer2))
            {
                PlayerColors.Player2Color = PicPlayer2.BackColor;
            }
        }

        private bool ChangePlayerColor(PictureBox pictureBox)
        {
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox.BackColor = colorDialog.Color;
                return true;
            }
            return false;
        }
        public class Player
        {
            public int PlayerNumber { get; set; }
            // 추가적인 플레이어 속성
        }

        public class GameRoom
        {
            private List<Player> Players;

            public GameRoom()
            {
                Players = new List<Player>();
            }

            public void PlayerLeft(Player player)
            {
                // 플레이어가 나갔을 때 그 플레이어를 리스트에서 제거
                Players.Remove(player);
                AdjustPlayerNumbers();
            }

            public void AdjustPlayerNumbers()
            {
                // 플레이어 번호를 1번부터 다시 채움
                for (int i = 0; i < Players.Count; i++)
                {
                    Players[i].PlayerNumber = i + 1;  // 플레이어 번호를 리스트 인덱스에 따라 1부터 시작하도록 재조정
                }
            }
        }
        /*
        public class GameManage
        {
            public static GameManage Instance { get; } = new GameManage();
            public Point StartPosition { get; private set; }
            public int Seed { get; private set; }

            private GameManage()
            {
                Seed = new Random().Next();
            }

            public void GenerateMap()
            {
                // 시드를 기반으로 맵 생성 로직
                // 예시로 시드 출력
                Console.WriteLine($"Map generated with seed: {Seed}");
            }

            public void CalculateStartPosition()
            {
                // 시작 위치 임의 설정
                StartPosition = new Point(Seed % 10, Seed % 10);  // 예시
            }

            public void UpdatePlayerStatus(bool isReady, bool isHost)
            {
                // 플레이어 상태 업데이트
            }

            public void AdjustPlayerNumbers()
            {
                // 플레이어 번호 조정 로직
            }
        }
        */
        private void BtnReady_Click(object sender, EventArgs e)
        {
            _isPlayerReady = !_isPlayerReady;
            BtnReady.Text = _isPlayerReady ? "준비" : "준비완료";
        }

        private void BtnLeave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("방을 나갑니다.");
            this.Close(); // Close the current form
        }

        private async Task StartCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                this.Text = $"Game starts in {i} seconds";
                await Task.Delay(1000);
            }
            this.Text = "Room";
        }

        private void StartGame()
        {
            MessageBox.Show("게임 시작!");
            Manager.scene.ChangeGameState(this, Define.GameState.InGameScene);
        }
    }
}
