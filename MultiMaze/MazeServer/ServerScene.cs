using System.Net.Sockets;
using System.Net;
using System.Text;
using MazeClient.Share;
using MazeServer.Scenes;
namespace MazeServer
{
    public partial class ServerScene : Form
    {
        ServerGameManager Manager;
        List<Socket> PlayerList;

        //�� ���� Ŭ����
        MainServerScene mainScene;
        SettingServerScene settingScene;
        WaitServerScene waitScene;
        InGameServerScene inGameScene;
        RoundOverServerScene roundOverScene;
        GameOverServerScene gameOverScene;
        public ServerScene()
        {
            InitializeComponent();
            Manager = ServerGameManager.Instance;

            Manager.ServerScene = this;
            Manager.client.WaitForPlayer();
            ServerInitializer();
        }

        //delegate ���Կ�
        public void ServerInitializer()
        {
            mainScene = new MainServerScene();
            settingScene = new SettingServerScene();
            waitScene = new WaitServerScene();
            inGameScene = new InGameServerScene();
            roundOverScene   = new RoundOverServerScene(); 
            gameOverScene = new GameOverServerScene();
        }

        public void SetLog(string log)
        {
            logTextBox.AppendText(log + "\n");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ServerTempScene_Load(object sender, EventArgs e)
        {

        }
    }
}
