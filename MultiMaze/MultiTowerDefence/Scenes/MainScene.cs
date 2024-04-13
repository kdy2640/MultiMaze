using MazeClient;
using MazeClient.Scenes;


namespace MazeClient
{
    public partial class MainScene : Form
    {
        GameManager Manager;
        public MainScene()
        {
            InitializeComponent();
            //Manager 할당
            Manager = GameManager.Instance;

            // 로딩이나 연결은 비동기방식으로 받아야함. 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager.server.ConnectServer();
            // 화면 바꾸기
            Manager.scene.ChangeGameState(this, Define.GameState.SettingScene);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainScene_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetRoomInfoScene modal = new GetRoomInfoScene();
            modal.ShowDialog(); 
        }
    }
}
