using MazeClient;
using MazeClient.Scenes;
using MazeClient.Share;
using System;
using System.Drawing.Text;
using System.Net;


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
            Manager.server.callbackFunctions.MainSceneCallBack += MainSceneCallBackFunction;

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
                getRoomArgs();

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

        public void MainSceneCallBackFunction(byte[] buffer, ServerEvent serverEvent)
        {
            //GameStatus 확인
            if (serverEvent.GameStatus != Define.GameState.MainScene) return;

            switch (serverEvent.EventType)
            {
                case 0: // ReceiveRoomARgs
                    receiveRoomArgs(buffer);
                    break;
                case 1: // None
                    break;
            }
        }
        #region 서버 수신
        private async void receiveRoomArgs(byte[] buffer)
        {
            //배열 선언
            byte[] roundBuffer = new byte[2];
            byte[] aiBuffer = new byte[2];
            byte[] sizeBuffer = new byte[2];
            // 배열 복사
            Array.Copy(buffer, 0, roundBuffer, 0, 2);
            Array.Copy(buffer, 2, aiBuffer, 0, 2);
            Array.Copy(buffer, 4, sizeBuffer, 0, 2);
            // 역직렬화
            short round = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(roundBuffer, 0));
            short ai = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(aiBuffer, 0));
            short size = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(sizeBuffer, 0));

            //roomArgs 만들어서 
            RoomSettingArgs args = new RoomSettingArgs();
            args.Round = round;
            args.ai = (RoomSettingArgs.AIAlgorithm)ai;
            args.mapSize = (RoomSettingArgs.MapSize)size;

            Manager.map.RoomArgs = args;
             
            await Task.Delay(10);

            Manager.scene.ChangeGameState(this, Define.GameState.WaitScene);
        }
        #endregion
        #region 서버송신

        private void getRoomArgs()
        {
            // 의미 없는데이터
            int playerCode = Manager.PlayerCode;
            // 직렬화
            byte[] Buffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(playerCode));
            // 서버이벤트 생성
            MainGameSceneServerEvent serverEvent = new MainGameSceneServerEvent(MainGameSceneServerEvent.MainSceneServerEventType.ReceiveRoomArgs);
            // 송신
            Manager.server.SendToServerAsync(Buffer, serverEvent);
        }
        #endregion 

    }
}
// 서버쪽으로 송신 // 정보를 달라고
// 서버에서 받는다
// 클라 -> 서버 -> 클라
public class MainGameSceneServerEvent : ServerEvent
{
    public enum MainSceneServerEventType
    {
        ReceiveRoomArgs, None
    }


    public MainGameSceneServerEvent() : base()
    {
        EventType = (int)MainSceneServerEventType.None;
        GameStatus = Define.GameState.MainScene;
    }
    public MainGameSceneServerEvent(MainSceneServerEventType inGameSceneServerEventType) : base()
    {
        EventType = (int)inGameSceneServerEventType;
        GameStatus = Define.GameState.MainScene;
    }
}
