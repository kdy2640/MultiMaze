using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MazeClient.Share;
using static MazeClient.Scenes.InGameSceneServerEvent;

namespace MazeClient.Scenes
{
    public partial class InGameScene : Form
    {

        GameManager manager;// 매니저
        int PlayerCode; // 서버에서 부여하는 코드
        Point PlayerPos;
        public Point ScreenStart = new Point(25, 25);  // 화면 시작 
        public Point ScreenEnd = new Point(50, 50);    // 화면 끝
        public InGameScene()
        {
            manager = GameManager.Instance;

            InitializeComponent();
            GameInitialize(); //맵 준비, 이동 준비
        }



        List<PictureBox> PlayerList;  // 플레이어 이미지
        List<Bitmap> Sprites; // sprites 모음
        private void GameInitialize()
        {
            PlayerList = new List<PictureBox>();
            this.DoubleBuffered = true; // 로딩 잘 되게

            manager.resource.SpriteInitiator(this);
            manager.resource.UpdateMap(this);

            PlayerCode = manager.PlayerCode;// 서버 연결시 받은 플레이어 코드 
            Sprites = manager.resource.sprites; // Sprites 모음
            PlayerStartPointList = manager.map.PlayerStartPosList;
            PlayerPos = PlayerStartPointList[PlayerCode - 1]; // 시작 위치 받아오기

            manager.server.callbackFunctions.InGameSceneCallBack += InGameSceneCallBackFunction; // 콜백 삽입

            getAllPlayer(); // 플레이어 이미지 생성
            this.Focus();
            for (int i = 0; i < GameManager.MAX_PLAYER_NUM; i++)
            {
                this.Controls.Add(PlayerList[i]); // 폼에 PictureBox 추가
            }
            this.KeyPreview = true; // Form에서 키 이벤트를 미리 볼 수 있도록 설정
            this.KeyDown += MyForm_KeyDown; // KeyDown 이벤트 핸들러 추가
        }
        private void getAllPlayer()
        {

            for (int i = 0; i < GameManager.MAX_PLAYER_NUM; i++)
            {

                PictureBox player = new PictureBox();

                player.Width = 32;
                player.Height = 32;
                player.Left = manager.map.PlayerStartPosList[i].X * 32 + ScreenStart.X;
                player.Top = manager.map.PlayerStartPosList[i].Y * 32 + ScreenStart.Y;
                player.Image = Sprites[4]; // 분할된 스프라이트 이미지 삽입
                player.SizeMode = PictureBoxSizeMode.StretchImage; // 이미지 크기 조정 
                PlayerList.Add(player);
            }
            
        }

        //입력 이벤트핸들러
        private void MyForm_KeyDown(object sender, KeyEventArgs e)
        {
            int len = 32;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    PlayerList[PlayerCode-1].Top -= len;
                    PlayerPos.Y -= 1;
                    break;
                case Keys.Down:
                    PlayerList[PlayerCode - 1].Top += len;
                    PlayerPos.Y += 1;
                    break;
                case Keys.Left:
                    PlayerList[PlayerCode - 1].Left -= len;
                    PlayerPos.X -= 1;
                    break;
                case Keys.Right:
                    PlayerList[PlayerCode - 1].Left += len;
                    PlayerPos.X += 1;
                    break;
                case Keys.Space:
                    manager.scene.ChangeGameState(this, Define.GameState.RoundOverScene);
                    break;
            }

            SendPlayerPos(PlayerPos);

            UpdatePlayerPos();

            // 서버에 전송
        }

        //플레이어 위치 갱신
        List<Point> PlayerStartPointList;
        public async void UpdatePlayerPos()
        {
            for (int i = 0; i < GameManager.MAX_PLAYER_NUM; i++)
            {
                if (PlayerCode - 1 == i) continue; // 본인은 무시
                int deltaX = PlayerStartPointList[i].X - manager.map.PlayerPosList[i].X; // 양수면 원래보다 왼쪽으로
                int deltaY = PlayerStartPointList[i].Y - manager.map.PlayerPosList[i].Y; // 양수면 원래보다 위로

                PlayerList[i].Left = PlayerStartPointList[i].X * 32 + ScreenStart.X - deltaX * 32;
                PlayerList[i].Top = PlayerStartPointList[i].Y * 32+ ScreenStart.Y - deltaY * 32;
            }
        }
        #region 파싱 delegate

        public void InGameSceneCallBackFunction(byte[] buffer, ServerEvent serverEvent)
        {
            //GameStatus 확인
            if (serverEvent.GameStatus != Define.GameState.InGameScene) return;
            switch (serverEvent.EventType)
            {
                case 0:
                    break;
                case 1:
                    break;
                case 2:
                    GetAllPlayerPos(buffer);
                    break;
            }
        }
        #endregion
        #region 서버 수신
        //플레이어들 위치정보 수신
        public async void GetAllPlayerPos(byte[] buffer)
        {
            for (int i = 0; i < GameManager.MAX_PLAYER_NUM; i++)
            {
                if (PlayerCode - 1 == i) // 자기 정보는 필요 없음
                {
                   continue;
                }
                byte[] xBuffer = new byte[2];
                byte[] yBuffer = new byte[2];

                //배열 복사
                Array.Copy(buffer, 4 * i, xBuffer, 0,2);    
                Array.Copy(buffer, 4 * i + 2, yBuffer, 0, 2);

                int xPos = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(xBuffer, 0));
                int yPos = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(yBuffer, 0));
                manager.map.PlayerPosList[i] = new Point(xPos, yPos);
            }
            UpdatePlayerPos();
        }


        #endregion
        #region 서버 송신
        public async void SendPlayerPos(Point pos)
        {
            byte[] buffer = new byte[4];
            byte[] xBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)pos.X));
            byte[] yBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)pos.Y));

            Array.Copy(xBuffer,0,buffer, 0, 2);
            Array.Copy(yBuffer,0,buffer, 2, 2);

            InGameSceneServerEvent serverEvent = new InGameSceneServerEvent(InGameSceneServerEventType.PlayerMove);
            manager.server.SendToServerAsync(buffer, serverEvent);

        }
        #endregion

        private void InGameScene_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }
    }
    public class InGameSceneServerEvent : ServerEvent
    {
        public enum InGameSceneServerEventType
        {
            PlayerMove, PlayerEnd, AllPlayerPos,None
        }


        public InGameSceneServerEvent() : base()
        {
            EventType = (int)InGameSceneServerEventType.None;
            GameStatus = Define.GameState.InGameScene;
        }
        public InGameSceneServerEvent(InGameSceneServerEventType inGameSceneServerEventType) : base()
        {
            EventType = (int)inGameSceneServerEventType;
            GameStatus = Define.GameState.InGameScene;
        }
    }




}