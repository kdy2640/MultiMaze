using MazeClient;
using MazeClient.Scenes;
using MazeClient.Share;


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

            // 로딩, 연결은 비동기로
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Manager.server.ConnectServer("127.0.0.1", 20000);
            // 화면 바꾸기
            // Manager.scene.ChangeGameState(this, Define.GameState.SettingScene);
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
            if (modal.ShowDialog() == DialogResult.OK)
            {
                Manager.scene.ChangeGameState(this, Define.GameState.WaitScene);
            }
        }

        private void btm_makeroom_Click(object sender, EventArgs e)
        {
            // 화면 바꾸기
            Manager.scene.ChangeGameState(this, Define.GameState.SettingScene);

            // 이 부분부터 서버 통신
            //Manager.server.ConnectServer();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Form form = new AsyncTestScene();
            form.ShowDialog();
            Manager.scene.ChangeGameState(this, Define.GameState.SettingScene);
        }
    }
}