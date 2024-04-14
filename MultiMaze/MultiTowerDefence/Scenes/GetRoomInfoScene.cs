using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MazeClient;

namespace MazeClient.Scenes
{
    public partial class GetRoomInfoScene : Form
    {
        GameManager Manager;
        public GetRoomInfoScene()
        {
            InitializeComponent();
            Manager = GameManager.Instance;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void enterRoomBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(hostTxtbox.Text) || string.IsNullOrEmpty(portTxtbox.Text))
            {
                MessageBox.Show("입력 정보를 확인해주세요.");
                return;
            }

            string messageString = string.Format("IP : {0}\nPORT: {1}", hostTxtbox.Text, portTxtbox.Text);
            var result = MessageBox.Show(messageString + "\n접속 하시겠습니까?", "입장", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK) // 서버 접속 로직 처리 필요
            {
                if (hostTxtbox.Text.Equals("127.0.0.1") && int.Parse(portTxtbox.Text) == 8080)
                {
                    MessageBox.Show(messageString + "접속 완료!");
                    Manager.scene.ChangeGameState(this, Define.GameState.WaitScene);
                    //Manager.server.ConnectServer();
                    // 화면 바꾸기
                    //Manager.scene.ChangeGameState(this, Define.GameState.SettingScene);
                }
                else
                {
                    MessageBox.Show("해당 호스트 정보가 존재하지 않습니다.");
                }
            }
        }
    }
}
