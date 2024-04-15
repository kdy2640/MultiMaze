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

namespace MazeClient
{
    public partial class RoundOverScene : Form
    {
        GameManager Manager;
        public RoundOverScene()
        {
            InitializeComponent();
            Manager = GameManager.Instance;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager.scene.ChangeGameState(this, Define.GameState.GameOverScene);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
