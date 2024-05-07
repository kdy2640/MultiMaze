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

        private void test_function()
        {
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                label1.Text = i.ToString();
            }
        }

        private async void button_Click(object sender, EventArgs e)
        {
            await LoadingScene.Loading(() => test_function());
            MessageBox.Show("Done!");
            this.Close();
        }
    }
}
