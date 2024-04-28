
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeClient
{
    public partial class WaitScene : Form
    {
        int temp;
        GameManager Manager;
        public WaitScene()
        {
            InitializeComponent();

            Manager = GameManager.Instance;
            


            
        }

        private void textBox1_TextChange(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            Manager.scene.ChangeGameState(this, Define.GameState.InGameScene);
        }

    }
}
