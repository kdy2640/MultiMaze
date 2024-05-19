using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeClient.Scenes
{
    public partial class AsyncTestScene : Form
    {

        public AsyncTestScene()
        {
            InitializeComponent();
        }

        private async void button_Click(object sender, EventArgs e)
        {
            LoadingScene.StartLoading(this);
            await Task.Delay(5000); // 로딩 시간 조정 
            //작업
            LoadingScene.StopLoading();
            MessageBox.Show("Done!");
            this.Close();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            CountDownScene.StartCountDown(this);
            await Task.Delay(7250); // 로딩 시간 조정 
            //작업
            CountDownScene.StopCountDown();
            MessageBox.Show("Done!");
            this.Close();
        }
    }
}
