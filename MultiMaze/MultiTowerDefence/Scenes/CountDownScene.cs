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
        }

        public static void StartCountDown(Form sender)
        {
            Parent = sender as Form;
            foreach (Control c in Parent.Controls)
            {
                c.Enabled = false;
            }
            countdownScene.Show();
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
