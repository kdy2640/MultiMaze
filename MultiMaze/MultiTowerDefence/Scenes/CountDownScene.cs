using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeClient.Scenes
{
    public partial class CountDownScene : Form
    {
        public static CountDownScene countdownScene = new CountDownScene();
        private static Form Parent = new Form();
        public CountDownScene()
        {
            InitializeComponent();
            this.ControlBox = false;
        }

        public static void StartCountDown(Form sender)
        {
            countdownScene = new CountDownScene();
            Parent = sender as Form;
            foreach (Control c in Parent.Controls)
            {
                c.Enabled = false;
            }
            countdownScene.Show();
            countdownScene.Left = Parent.Left + Parent.Width/2 - countdownScene.Width/2;
            countdownScene.Top = Parent.Top + Parent.Height/2 - countdownScene.Height/2;
        }

        public static void StopCountDown()
        {
            foreach (Control c in Parent.Controls)
            {
                c.Enabled = false;
            }
            countdownScene.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
