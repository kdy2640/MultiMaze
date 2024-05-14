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
            Form Main = manager.scene.GetSceneInstance(Share.Define.GameState.MainScene);
            this.Hide();
            Main.Show();
        }
    }
}
