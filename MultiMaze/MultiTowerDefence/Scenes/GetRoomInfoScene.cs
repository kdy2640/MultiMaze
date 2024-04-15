using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MazeClient.Share;

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

        private async void enterRoomBtn_Click(object sender, EventArgs e)
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
                //다른 아이피 사용
                if (int.Parse(portTxtbox.Text) == 20000)
                {
                    bool serverResult = await Manager.server.ConnectServer(hostTxtbox.Text, int.Parse(portTxtbox.Text));
                    if(serverResult)
                    {
                        MessageBox.Show(messageString + "접속 완료!");
                        this.DialogResult = DialogResult.OK;
                    }else
                    {
                        MessageBox.Show(messageString + "접속 실패!");
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
                else
                {
                    MessageBox.Show("해당 호스트 정보가 존재하지 않습니다.");
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}
