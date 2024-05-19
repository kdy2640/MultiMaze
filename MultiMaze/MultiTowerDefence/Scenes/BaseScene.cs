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
    public partial class BaseScene : Form
    {
        GameManager manager;
        public BaseScene()
        {
            InitializeComponent();
        }

        private void BaseScene_Load(object sender, EventArgs e)
        {

        }

        private void BaseScene_Shown(object sender, EventArgs e)
        {
            manager = GameManager.Instance;
            manager.scene.baseScene = this;

            Form Main = manager.scene.GetSceneInstance(Share.Define.GameState.MainScene);
            Main.FormClosing += manager.scene.Scene_FormClosing;
            this.Hide();
            formCount = 1; 
            Main.Show();

        }
        public static int formCount = 0;
        public void CountUpdate()
        {
            if(formCount == 0)
            {
                this.Close();
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}
