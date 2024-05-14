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

        private async void makeRoomBtn_Click(object sender, EventArgs e)
        {
            // 서버 프로그램 실행
            if(!Manager.server.StartServer()) MessageBox.Show("서버 실행 실패");


            bool connectResult = await Manager.server.ConnectServer("127.0.0.1", 20000);
            if(connectResult == false)
            {
                MessageBox.Show("서버 연결 실패");
                return;
            }
            Manager.scene.ChangeGameState(this, Define.GameState.WaitScene);

        }

        private void cancelMakeRoomBtn_Click(object sender, EventArgs e)
        {
            Manager.scene.ChangeGameState(this, Define.GameState.MainScene);
        }

    }
}