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
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MazeClient.Share;
using static MazeClient.Scenes.InGameSceneServerEvent;

namespace MazeClient.Scenes
{
    public partial class InGameScene : Form
    {
        private bool isGameEnd = false;
        int cellSize = 25;
        GameManager manager;// 매니저
        int PlayerCode; // 서버에서 부여하는 코드
        Point PlayerPos;
        List<PictureBox> PlayerList;  // 플레이어 PictureBox
        PictureBox EndPointPictureBox;
        //AI 관련
        public Algorithm algorithm = new Astar();
        // Map 관련
        private bool[,] map = new bool[0, 0];
        private Point endPoint = new Point();
        private List<Point> path = new List<Point>();

        public InGameScene()
        {
            manager = GameManager.Instance;

            InitializeComponent(); 
        }

        private void InGameScene_Load(object sender, EventArgs e)
        {
             GameInitialize(); //맵 준비, 이동 준비
        }


        #region 게임 초기화
        public Point ScreenStart = new Point(25, 25);  // 화면 시작 
        public Point CameraPos = new Point(0, 0);  //카메라
        public Point CameraLimit = new Point(0, 0);
        private async void GameInitialize()
        {
            // 맵 초기화
            MapInitialize();


            //콜백 함수 할당
            manager.server.callbackFunctions.InGameSceneCallBack = null;
            manager.server.callbackFunctions.InGameSceneCallBack += InGameSceneCallBackFunction;

            //플레이어 이미지 생성 및 정보 초기화
            getAllPlayer();
            AIInitialize();

            // 폼 설정
            FormInitialize();

            //패널 초기화 
            PanelInitialize();


            //카메라 관련
            CameraLimit.X = panel1.Width / 50;
            CameraLimit.Y = panel1.Height / 50;
            RenderPlayer();
        }

        private void MapInitialize()
        {
            // 미로 생성(임시)
            DrawMaze(manager.map.map);
            map = manager.map.map;
            endPoint = manager.map.endPoint;

            getEndPoint();
        }
        private void PanelInitialize()
        {
            panel1.Controls.Add(pictureBox1);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            this.Controls.Add(panel1);
            ScreenStart = new Point(panel1.Left, panel1.Top);
            panel1.SendToBack();
        }

        private void FormInitialize()
        {
            this.Focus();
            this.KeyPreview = true; // Form에서 키 이벤트를 미리 볼 수 있도록 설정
            this.KeyDown += MyForm_KeyDown; // KeyDown 이벤트 핸들러 추가
            this.DoubleBuffered = true; // 로딩 잘 되게
        }
        private void getAllPlayer()
        {
            PlayerCode = manager.PlayerCode;// 서버 연결시 받은 플레이어 코드  
            PlayerPos = manager.map.PlayerStartPosList[PlayerCode - 1]; // 시작 위치 받아오기
            for (int i = 0; i < 4; i++)
            {
                manager.map.PlayerPosList[i] = manager.map.PlayerStartPosList[i];
            }

            //Player PictureBox
            PlayerList = new List<PictureBox>();
            for (int i = 0; i < GameManager.MAX_PLAYER_NUM; i++)
            {
                
                PictureBox player = new PictureBox();

                player.Width = cellSize;
                player.Height = cellSize;
                player.Left = manager.map.PlayerStartPosList[i].X * cellSize + ScreenStart.X;
                player.Top = manager.map.PlayerStartPosList[i].Y * cellSize + ScreenStart.Y;    // Paint 이벤트에 핸들러 추가
                int LocalI = i;
                player.Paint += (sender, e) =>
                {
                    e.Graphics.Clear(Color.White); 
                    SolidBrush br;
                    if (manager.server.PlayerConnectArray[LocalI] == true)
                    { 
                        br = new SolidBrush(manager.map.PlayerColorList[LocalI]);
                    }
                    else
                    {
                        if (manager.map.map[manager.map.PlayerPosList[LocalI].X, manager.map.PlayerPosList[LocalI].Y] == true)
                        {
                            br = new SolidBrush(Color.White);
                        }
                        else
                        {
                            e.Graphics.Clear(Color.Black);
                            br = new SolidBrush(Color.Black);
                        }
                    }
                    e.Graphics.FillEllipse(br, 0, 0, player.Width, player.Height);

                };
                player.SizeMode = PictureBoxSizeMode.StretchImage; // 이미지 크기 조정 
                PlayerList.Add(player);
                this.Controls.Add(player);
                player.BringToFront();
                path.Add(manager.map.PlayerPosList[PlayerCode - 1]);
            }
            //AI PictureBOx
            AiPlayer = new PictureBox();

            AiPlayer.Width = cellSize;
            AiPlayer.Height = cellSize;
            AiPlayer.Left = 1 * cellSize + ScreenStart.X;
            AiPlayer.Top = 1 * cellSize + ScreenStart.Y;    // Paint 이벤트에 핸들러 추가
            AiPlayer.Paint += (sender, e) =>
            { 
                e.Graphics.Clear(Color.White);

                // 사각형 꼭짓점
                Point point1 = new Point(AiPlayer.Width / 2, 0); // 상
                Point point3 = new Point(AiPlayer.Width / 2, AiPlayer.Height); // 하 
                Point point2 = new Point(AiPlayer.Width, AiPlayer.Height / 2); // 우
                Point point4 = new Point(0, AiPlayer.Height / 2); // 좌

                Point[] points = { point1, point2, point3, point4 };

                // 그리기
                e.Graphics.FillPolygon(Brushes.Purple, points);
            };
            AiPlayer.SizeMode = PictureBoxSizeMode.StretchImage; // 이미지 크기 조정 
            this.Controls.Add(AiPlayer);
            PlayerList[PlayerCode-1].BringToFront();

             
            player = PlayerList[PlayerCode - 1];
            playerBrush = new SolidBrush(manager.map.PlayerColorList[PlayerCode - 1]);

        }
        private void getEndPoint()
        {
            int portalSize = 8;
            EndPointPictureBox = new PictureBox();
            EndPointPictureBox.Width = cellSize;
            EndPointPictureBox.Height = cellSize;
            EndPointPictureBox.Left = endPoint.X * cellSize + ScreenStart.X;
            EndPointPictureBox.Top = endPoint.Y * cellSize + ScreenStart.Y;    // Paint 이벤트에 핸들러 추가
            EndPointPictureBox.Paint += (sender, e) =>
            {
                SolidBrush br = new SolidBrush(Color.Green);
                e.Graphics.FillEllipse(br, 0, 0, EndPointPictureBox.Width, EndPointPictureBox.Height);
                br = new SolidBrush(Color.Cyan);
                e.Graphics.FillEllipse(br, portalSize/2, portalSize/2, EndPointPictureBox.Width- portalSize, EndPointPictureBox.Height- portalSize);
            };
            EndPointPictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // 이미지 크기 조정 

            this.Controls.Add(EndPointPictureBox);
        }
        private void DrawMaze(bool[,] maze) //로직 테스트용
        {
            Bitmap bitmap = new Bitmap(maze.GetLength(0) * cellSize, maze.GetLength(1) * cellSize);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    for (int j = 0; j < maze.GetLength(1); j++)
                    {
                        if (maze[i, j] == false) //벽을 검은색으로 출력
                        {
                            g.FillRectangle(Brushes.Black, i * cellSize, j * cellSize, cellSize, cellSize);
                        }
                        else //길을 흰색으로 출력
                        {
                            g.FillRectangle(Brushes.White, i * cellSize, j * cellSize, cellSize, cellSize);
                        }

                    }
                }
            }
            pictureBox1.Image = bitmap;
        }
        #endregion

        #region 플레이어 입력 및 위치 렌더링


        #region 점프시 색상 변경

        private void PaintJump(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(playerBrush, 0, 0, player.Width, player.Height);
        }

        private void PaintLand(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            e.Graphics.FillEllipse(playerBrush, 0, 0, player.Width, player.Height);
        }
        public void OnJump()
        {
            player.Width += 1;
            player.Height += 1;
            isJump = true;
            player.Paint -= PaintLand;
            player.Paint += PaintJump;
        }
        public void OnLand()
        {
            player.Width -= 1;
            player.Height -= 1;
            isJump = false;
            player.Paint -= PaintJump;
            player.Paint += PaintLand;
        }
        #endregion 
        //입력 이벤트핸들러
        bool noClip = false;
        bool isJump = false;
        bool TickBooster = false;
        PictureBox player = new PictureBox();
        Brush playerBrush = Brushes.Wheat;
        private void MyForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (isGameEnd == true) return;
            int len = cellSize;
            Point tempPos = PlayerPos;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    PlayerPos.Y -= 1;
                    break;
                case Keys.Down:
                    PlayerPos.Y += 1;
                    break;
                case Keys.Left:
                    PlayerPos.X -= 1;
                    break;
                case Keys.Right:
                    PlayerPos.X += 1;
                    break;
                case Keys.C:
                    noClip = !noClip;
                    break;
                case Keys.T:
                    {
                        if(TickBooster)
                        {
                            timer1.Interval = 200;
                        }
                        else
                        {
                            timer1.Interval = 30;
                        }
                        TickBooster = !TickBooster;
                        break;
                    }
                case Keys.X:
                    {
                        if (isJump)
                        {
                            OnLand();
                        }
                        else
                        {
                            OnJump();
                        }
                        break;
                    } 
            }
            if (isJump)
            {
                switch (e.KeyCode)
                {
                    case Keys.Up:
                        PlayerPos.Y -= 1;
                        OnLand();
                        break;
                    case Keys.Down:
                        PlayerPos.Y += 1;
                        OnLand();
                        break;
                    case Keys.Left:
                        PlayerPos.X -= 1;
                        OnLand();
                        break;
                    case Keys.Right:
                        PlayerPos.X += 1;
                        OnLand();
                        break;
                }
            }
            PlayerPos.X = Math.Clamp(PlayerPos.X, 0, manager.map.mapSize - 1);
            PlayerPos.Y = Math.Clamp(PlayerPos.Y, 0, manager.map.mapSize - 1);
            
            // 벽으로 이동했으면 복구
            if (!noClip && map[PlayerPos.X, PlayerPos.Y] == false)
            {
                PlayerPos = tempPos;
                return;
            }
            if(PlayerPos == endPoint)
            {
                SendWinner(PlayerCode);
                return;
            }
            path.Add(PlayerPos);
            // 서버에 전송
            SendPlayerPos(PlayerPos);

            // 카메라 조정
            RenderPlayer();

        }

        //플레이어 위치 갱신 
        public async void RenderPlayer()
        {
            CameraPos = PlayerPos;
            // 카메라 먼저 움직임
            CameraPos.X = Math.Clamp(CameraPos.X, CameraLimit.X, manager.map.mapSize - CameraLimit.X);
            CameraPos.Y = Math.Clamp(CameraPos.Y, CameraLimit.Y, manager.map.mapSize - CameraLimit.Y);
            pictureBox1.Left = CameraLimit.X * cellSize - CameraPos.X * cellSize;
            pictureBox1.Top = CameraLimit.Y * cellSize - CameraPos.Y * cellSize;

            // 플레이어 렌더링
            for (int i = 0; i < GameManager.MAX_PLAYER_NUM; i++)
            {
                //본인은 서버에 영향을 받지 않음
                if (PlayerCode - 1 == i)
                {
                    PlayerList[i].Left = ScreenStart.X + pictureBox1.Left + PlayerPos.X * cellSize;
                    PlayerList[i].Top = ScreenStart.Y + pictureBox1.Top + PlayerPos.Y * cellSize;
                    continue;
                }
                PlayerList[i].Left = ScreenStart.X + pictureBox1.Left + manager.map.PlayerPosList[i].X * cellSize;
                PlayerList[i].Top = ScreenStart.Y + pictureBox1.Top + manager.map.PlayerPosList[i].Y * cellSize;
            }

            // 목표지점 렌더링
            EndPointPictureBox.Left = ScreenStart.X + pictureBox1.Left +endPoint.X * cellSize;
            EndPointPictureBox.Top = ScreenStart.Y + pictureBox1.Top + endPoint.Y * cellSize;

            int temp = 0;
        }
        #endregion

        #region AI 관련

        PictureBox AiPlayer = new PictureBox();
        private Point AiPosition = new Point(1, 1);
        private List<Point> AiPath = new List<Point>();
        private int AiIndex = 0;
        bool EndTrigger = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (EndTrigger == false)
            { 
                UpdateAIPos();
                label4.Text = manager.server.ServerSocket.Connected.ToString();
                if(AiPosition == endPoint)
                {
                    SendWinner(0);
                }
            }
        }
        int Index = 0;
        private void UpdateAIPos()
        {
            if (AiIndex < AiPath.Count)
            {
                AiPosition = AiPath[AiIndex++];
                AiPlayer.Left = ScreenStart.X + pictureBox1.Left + AiPosition.X * cellSize;
                AiPlayer.Top = ScreenStart.Y + pictureBox1.Top + AiPosition.Y * cellSize;

                label2.Text = AiPosition.X.ToString() + ", " + AiPosition.Y.ToString();
                label3.Text = (Index++).ToString();
                    }
            else
            {
                EndTrigger = true;
            }
        }
        private void AIInitialize()
        {
            AiPath = algorithm.ToArray(manager.map.startPoint, manager.map.endPoint);
            manager.AiPath = AiPath;
        }

        #endregion AI 관련

        #region 게임로직
        private async void gameEnd(int playerCode)
        {
            manager.WinnerList[manager.nowRound - 1] = playerCode;
            await Task.Delay(30);
            manager.scene.ChangeGameState(this, Define.GameState.RoundOverScene);
        }
        #endregion

        #region 서버 수신
        //플레이어들 위치정보 수신
        public async void GetAllPlayerPos(byte[] buffer)
        {
            for (int i = 0;  i < GameManager.MAX_PLAYER_NUM; i++)
            {
                if (PlayerCode - 1 == i) // 자기 정보는 필요 없음
                {
                    continue;
                }
                byte[] xBuffer = new byte[2];
                byte[] yBuffer = new byte[2];

                //배열 복사
                Array.Copy(buffer, 4 * i, xBuffer, 0, 2);
                Array.Copy(buffer, 4 * i + 2, yBuffer, 0, 2);

                int xPos = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(xBuffer, 0));
                int yPos = IPAddress.NetworkToHostOrder(BitConverter.ToInt16(yBuffer, 0));
                manager.map.PlayerPosList[i] = new Point(xPos, yPos);
            }
            RenderPlayer();
        }

        private void ReceiveEndPlayer(byte[] buffer)
        {
            byte[] codeBuffer = new byte[4];
            byte[] timeBuffer = new byte[4];

            Array.Copy(buffer, 0, codeBuffer, 0, 4);
            Array.Copy(buffer, 4, timeBuffer, 0, 4);


            int time = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(timeBuffer));
            int playerCode = IPAddress.NetworkToHostOrder(BitConverter.ToInt32(codeBuffer));

            manager.winnerTime = time;
            gameEnd(playerCode);
        }

        #endregion

        #region 서버 송신
        private async void SendPlayerPos(Point pos)
        {
            byte[] buffer = new byte[4];
            byte[] xBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)pos.X));
            byte[] yBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)pos.Y));

            Array.Copy(xBuffer, 0, buffer, 0, 2);
            Array.Copy(yBuffer, 0, buffer, 2, 2);

            InGameSceneServerEvent serverEvent = new InGameSceneServerEvent(InGameSceneServerEventType.PlayerMove);
            manager.server.SendToServerAsync(buffer, serverEvent);

        }

        private async void SendWinner(int playercode)
        {
            isGameEnd = true;
            manager.path =  path;
            List<Point> newPath = manager.path;
            byte[] Codebuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(playercode));
            byte[] timeBuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder(Index));
            byte[] xbuffer = new byte[2];
            byte[] ybuffer = new byte[2];
            byte[] buffer = new byte[newPath.Count * 4 + 8];

            Array.Copy(Codebuffer, 0, buffer, 0, 4);
            Array.Copy(timeBuffer, 0, buffer, 4, 4);

            InGameSceneServerEvent serverEvent = new InGameSceneServerEvent(InGameSceneServerEventType.GameEnd);


            for (int i = 0; i < newPath.Count; i++)
            {
                xbuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)newPath[i].X));
                ybuffer = BitConverter.GetBytes(IPAddress.HostToNetworkOrder((short)newPath[i].Y));

                Array.Copy(xbuffer, 0, buffer, 8+ 4 * i, 2);
                Array.Copy(ybuffer, 0, buffer, 8 + 4 * i + 2, 2);
            }
             

            manager.server.SendToServerAsync(buffer, serverEvent);
        }
        #endregion

        #region 사용하지 않는 함수
        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion

        #region 파싱 delegate

        public void InGameSceneCallBackFunction(byte[] buffer, ServerEvent serverEvent)
        {
            //GameStatus 확인
            if (serverEvent.GameStatus != Define.GameState.InGameScene) return;
            switch (serverEvent.EventType)
            {
                case 0: // PlayerMove
                    break;
                case 1: // GameEnd
                    ReceiveEndPlayer(buffer);
                    break;
                case 2:
                    GetAllPlayerPos(buffer);
                    break;
            }
        }
        #endregion
    }
    public class InGameSceneServerEvent : ServerEvent
    {
        public enum InGameSceneServerEventType
        {
            PlayerMove, GameEnd, AllPlayerPos,None
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