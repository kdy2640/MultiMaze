using System;
using System.Windows.Forms;

namespace Room
{
    public partial class MainForm : Form
    {
        private bool isHost = false; // 방장 여부
        private bool allPlayersReady = false; // 모든 플레이어가 준비 상태인지 여부
        private int countdownSeconds = 10; // 초 설정
        private Timer countdownTimer; // 카운트 다운을 위한 타이머

        public MainForm()
        {
            InitializeComponent();
            InitializeUI();
            countdownTimer = new Timer();
            countdownTimer.Interval = 1000; 
            countdownTimer.Tick += CountdownTimer_Tick;
        }

   
        private void BtnReady_Click(object sender, EventArgs e)
        {
  
            allPlayersReady = !allPlayersReady;
            UpdateUI();
        }

     
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (isHost && allPlayersReady)
            {
    
                StartGame();
            }
        }

 
        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            countdownSeconds--; 
            if (countdownSeconds <= 0)
            {
       
                countdownTimer.Stop();
                StartGame();
            }
            else
            {
     
                lblCountdown.Text = countdownSeconds.ToString();
            }
        }

    
        private void StartGame()
        {

        }

        private void InitializeUI()
        {
            btnStart.Click += BtnStart_Click;
            btnReady.Click += BtnReady_Click;
            btnLeave.Click += BtnLeave_Click;
            picPlayer1.Click += PicPlayer1_Click;
            picPlayer2.Click += PicPlayer2_Click;

            UpdateUI();
        }

 
        private void UpdateUI()
        {
      
            btnStart.Enabled = isHost && allPlayersReady;
            btnReady.Text = allPlayersReady ? "준비 취소" : "준비하기";
            lblCountdown.Text = countdownSeconds.ToString();
        }
    }
}
