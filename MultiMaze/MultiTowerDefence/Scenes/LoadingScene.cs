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
        public static LoadingScene loadingScene;
        public static bool is_end = false;

        public LoadingScene()
        {
            InitializeComponent();
        }

        public static async Task Loading(Action AsyncMethod)
        {
            loadingScene = new LoadingScene();
            Task t1 = Task.Run(() =>  AsyncMethod());

            loadingScene.Show();
            await t1;
            loadingScene.Close();
        }
    }
}
