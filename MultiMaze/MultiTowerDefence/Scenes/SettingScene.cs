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
            textBox1.Text = GetLocalIPAddress();
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

        private void makeRoomBtn_Click(object sender, EventArgs e)
        {
            // 이 부분부터 서버와 통신 필요.
            var result = MessageBox.Show("서버 연결 성공?", "서버 연결", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                Manager.server.ConnectServer();

                Manager.scene.ChangeGameState(this, Define.GameState.WaitScene);
            } else
            {
                MessageBox.Show("서버 연결 실패");
                return;
            }
        }

        private void cancelMakeRoomBtn_Click(object sender, EventArgs e)
        {
            Manager.scene.ChangeGameState(this, Define.GameState.MainScene);
        }
    }
}
