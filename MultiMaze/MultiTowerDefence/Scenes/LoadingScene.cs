using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeClient.Scenes
{
    public partial class LoadingScene : Form
    {
        public static LoadingScene loadingScene = new LoadingScene();
        private static Form Parent = new Form();
        private LoadingScene()
        {
            InitializeComponent();
            pictureBox1.BringToFront();
            this.ControlBox = false;
        }
        public static void StartLoading(Form sender)
        {
            Parent = sender as Form;
            foreach (Control c in Parent.Controls)
            {
                c.Enabled = false;
            }
            loadingScene.Show();
            loadingScene.Left = Parent.Left + Parent.Width / 2 - loadingScene.Width / 2;
            loadingScene.Top = Parent.Top + Parent.Height / 2 - loadingScene.Height / 2;

        }

        public static void StopLoading()
        {
            foreach (Control c in Parent.Controls)
            {
                c.Enabled = false;
            }
            loadingScene.Hide();
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
        }
    }
}
