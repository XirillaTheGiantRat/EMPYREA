using Microsoft.Xna.Framework.Graphics;
using YourEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics.PackedVector;

namespace YourGame.UI
{
    public class Slot3 : GameObject
    {
        Texture2D slot3;
        public bool empty = true;
        public Vector2 slot3Pos;


        public Slot3()
        {
            //slot3 = YourGame.AssetManager.LoadTexture("slot3");
            //slot3Pos = new Vector2((YourGame.ScreenSize.X / 2 + slot3.Width * (1 / 6)), YourGame.ScreenSize.Y - slot3.Height / 2);


        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(slot3, new Vector2(YourGame.ScreenSize.X / 2 - slot3.Width / 2, YourGame.ScreenSize.Y - slot3.Height - slot3.Height / 2), Color.White);

        }
    }
}
