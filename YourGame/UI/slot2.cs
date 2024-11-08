using Microsoft.Xna.Framework.Graphics;
using YourEngine;
using Microsoft.Xna.Framework;

namespace YourGame.UI
{
    public class Slot2 : GameObject
    {
        Texture2D slot2;
        public bool empty = true;
        public Vector2 slot2Pos;


        public Slot2()
        {
           // slot2 = YourGame.AssetManager.LoadTexture("slot2");
            //slot2Pos = new Vector2((YourGame.ScreenSize.X / 2 - slot2.Width / 2 - slot2.Width / 6), YourGame.ScreenSize.Y - slot2.Height);



        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(slot2, new Vector2(YourGame.ScreenSize.X / 2 - slot2.Width - slot2.Width / 2, YourGame.ScreenSize.Y - slot2.Height - slot2.Height / 2), Color.White);

        }
    }
}

