using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeClient
{
    public partial class InGameScene : Form
    {

        GameManager manager;
        Map Map;
        int PlayerCode; // 서버에서 부여하는 코드
        PictureBox Player;
        public InGameScene()
        {
            InitializeComponent();

            SpriteInitiator();
            UpdateMap();

            manager = GameManager.Instance;
            // 서버 연결시 받은 플레이어 코드 
            PlayerCode = manager.PlayerCode;


            Map = new Map();
            Player = getPlayer();
            this.Focus();

            this.Controls.Add(Player); // 폼에 PictureBox 추가
            this.KeyPreview = true; // Form에서 키 이벤트를 미리 볼 수 있도록 설정
            this.KeyDown += MyForm_KeyDown; // KeyDown 이벤트 핸들러 추가

        }
        private PictureBox getPlayer()
        {
            PictureBox player = new PictureBox();

            player.Width = 32;
            player.Height = 32;
            player.Left = 50;
            player.Top = 50;
            player.Image = sprites[4]; // 분할된 스프라이트 이미지 삽입
            player.SizeMode = PictureBoxSizeMode.StretchImage; // 이미지 크기 조정 

            return player;
        }


        private void MyForm_KeyDown(object sender, KeyEventArgs e)
        {
            int len = 32;
            switch (e.KeyCode)
            {
                case Keys.Up:
                    Player.Top -= len;
                    break;
                case Keys.Down:
                    Player.Top += len;
                    break;
                case Keys.Left:
                    Player.Left -= len;
                    break;
                case Keys.Right:
                    Player.Left += len;
                    break;
            }


            // 서버에 전송
        }





        /// ResourceManager로 옮겨야하고 갈아엎어야함 vvv

        public List<Bitmap> SliceSpriteSheet(Bitmap spriteSheet, int spriteWidth, int spriteHeight)
        {
            List<Bitmap> sprites = new List<Bitmap>();

            // 스프라이트 시트의 가로와 세로에 있는 스프라이트의 수를 계산합니다.
            int spritesAcross = spriteSheet.Width / spriteWidth;
            int spritesDown = spriteSheet.Height / spriteHeight;

            for (int y = 0; y < spritesDown; y++)
            {
                for (int x = 0; x < spritesAcross; x++)
                {
                    // 새 Bitmap 객체를 생성하고 스프라이트 시트의 일부를 그립니다.
                    Bitmap sprite = new Bitmap(spriteWidth, spriteHeight);
                    using (Graphics g = Graphics.FromImage(sprite))
                    {
                        // 스프라이트 시트에서 현재 스프라이트 위치의 부분을 잘라내어 새 Bitmap에 그립니다.
                        Rectangle sourceRectangle = new Rectangle(x * spriteWidth, y * spriteHeight, spriteWidth, spriteHeight);
                        Rectangle destRectangle = new Rectangle(0, 0, spriteWidth, spriteHeight);

                        g.DrawImage(spriteSheet, destRectangle, sourceRectangle, GraphicsUnit.Pixel);
                    }
                    sprites.Add(sprite); // 리스트에 추가합니다.
                }
            }

            return sprites; // 모든 스프라이트가 포함된 리스트를 반환합니다.
        }

        List<Bitmap> sprites;
        List<PictureBox> PictureBoxs;
        Image spriteSheet;
        Point Start = new Point(100, 100);

        private void SpriteInitiator()
        {
            this.DoubleBuffered = true;

            // 1.이미지를 불러와서 스프라이트를 분할
            spriteSheet = Image.FromFile("C:\\Users\\kimran\\Desktop\\공부\\응소실\\SpriteMap.png");
            sprites = SliceSpriteSheet((Bitmap)spriteSheet, 32, 32);

            // 2. picturebox 생성
            int tilesPerRow = 4; // 한 줄에 표시할 타일의 수
            int tileSize = 32; // 타일의 크기 (픽셀 단위)

            PictureBoxs = new List<PictureBox>();
            for (int i = 0; i < sprites.Count; i++)
            {
                PictureBoxs.Add(new PictureBox());
                PictureBox pictureBox = PictureBoxs[i];
                pictureBox.Width = tileSize;
                pictureBox.Height = tileSize;
                pictureBox.Left = Start.X + (i % tilesPerRow) * tileSize; // X 위치 계산
                pictureBox.Top = Start.Y + (i / tilesPerRow) * tileSize; // Y 위치 계산
                this.Controls.Add(pictureBox); // 폼에 PictureBox 추가
            }
        }

        private void UpdateMap()
        {

            int tilesPerRow = 4; // 한 줄에 표시할 타일의 수
            int tileSize = 32; // 타일의 크기 (픽셀 단위)
            for (int i = 0; i < sprites.Count; i++)
            {
                PictureBox pictureBox = PictureBoxs[i];
                pictureBox.Image = sprites[i]; // 분할된 스프라이트 이미지 삽입
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // 이미지 크기 조정 옵션
            }
        }

        /// ^^^

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChange(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            manager.scene.ChangeGameState(this, Define.GameState.RoundOverScene);
        }
    }
}
