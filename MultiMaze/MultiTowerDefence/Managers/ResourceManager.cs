using MazeClient.Scenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeClient
{
    internal class ResourceManager
    {
        public List<Bitmap> sprites;
        List<PictureBox> PictureBoxs;
        Image spriteSheet;
        Point Start = new Point(100, 100);

        public List<Bitmap> SliceSpriteSheet(Bitmap spriteSheet, int spriteWidth, int spriteHeight)
        {
            List<Bitmap> sprites = new List<Bitmap>();

            // 가로 새로 개수 계산
            int spritesHorizontalCount = spriteSheet.Width / spriteWidth;
            int spritesVerticalCount = spriteSheet.Height / spriteHeight;

            for (int y = 0; y < spritesVerticalCount; y++)
            {
                for (int x = 0; x < spritesHorizontalCount; x++)
                {
                    // Bitmap으로 분할
                    Bitmap sprite = new Bitmap(spriteWidth, spriteHeight);
                    using (Graphics g = Graphics.FromImage(sprite))
                    {
                        // rectangle을 이용해서 분할
                        Rectangle sourceRectangle = new Rectangle(x * spriteWidth, y * spriteHeight, spriteWidth, spriteHeight);
                        Rectangle destRectangle = new Rectangle(0, 0, spriteWidth, spriteHeight);

                        //spriteSheet의 sourceRectangle에 있는 데이터를 sprite에 있는 destRectangle 에 추가
                        g.DrawImage(spriteSheet, destRectangle, sourceRectangle, GraphicsUnit.Pixel);
                    }
                    sprites.Add(sprite); // 리스트에 추가합니다.
                }
            }

            return sprites; // 모든 스프라이트가 포함된 리스트를 반환합니다.
        }


        public void SpriteInitiator(object sender)
        {
            InGameScene scene = sender as InGameScene;

            // 1.이미지를 불러와서 스프라이트를 분할
            spriteSheet = Image.FromFile("SpriteMap.png");
            sprites = SliceSpriteSheet((Bitmap)spriteSheet, 32, 32);
             
        }

        public void UpdateMap(object sender)
        {
            InGameScene scene = sender as InGameScene;
        }
    }
}
