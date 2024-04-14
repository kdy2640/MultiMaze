
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Room
{
    public partial class MainForm : Form
    {
        private bool isHost = false; // 방장 여부
        private bool allPlayersReady = false; // 모든 플레이어가 준비 상태인지 여부

        public MainForm()
        {
            InitializeComponent();
                btnStart.Click += BtnStart_Click;
                btnReady.Click += BtnReady_Click;
                btnLeave.Click += BtnLeave_Click;
                picPlayer1.Click += PicPlayer1_Click;
                picPlayer2.Click += PicPlayer2_Click;
                // 초기 상태 설정
                UpdateUI();
        }

        // 준비 버튼 클릭 이벤트 핸들러
        private void BtnReady_Click(object sender, EventArgs e)
        {
            // 플레이어의 준비 상태 변경
            allPlayersReady = CheckAllPlayersReady();
            UpdateUI();
        }

        // 시작 버튼 클릭 이벤트 핸들러
        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (isHost && allPlayersReady)
            {
                // 게임 시작 로직 수행
                StartGame();
            }
        }
        // 나가기 버튼 클릭 이벤트 핸들러
        private void BtnLeave_Click(object sender, EventArgs e)
        {
            // 나가기 버튼
        }

        // 플레이어1 PictureBox 클릭 이벤트 핸들러
        private void PicPlayer1_Click(object sender, EventArgs e)
        {
            // 플레이어1 캐릭터
        }

        // 플레이어2 PictureBox 클릭 이벤트 핸들러
        private void PicPlayer2_Click(object sender, EventArgs e)
        {
            // 플레이어2 캐릭터
        }
        // 모든 플레이어가 준비 상태인지 확인하는 메서드
        private bool CheckAllPlayersReady()
        {
            // 네트워크 통신으로 구현
            
            return true; // 임시로 true를 반환
        }

        // 게임 시작 메서드
        private void StartGame()
        {
            // 맵 생성 및 카운트 다운 등의 로직
        }

        // UI 업데이트 메서드
        private void UpdateUI()
        {
            // 시작 버튼 활성화 여부 설정
            btnStart.Enabled = isHost && allPlayersReady;
            // 준비 버튼 텍스트 업데이트
            btnReady.Text = allPlayersReady ? "준비 취소" : "준비하기";
        }
    }
}
