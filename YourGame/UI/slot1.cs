using Microsoft.Xna.Framework.Graphics;
using YourEngine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics.PackedVector;

namespace YourGame.UI
{
    public class Slot1 : GameObject
    {
        Texture2D slot1;
        public bool empty = true;
        public Vector2 slot1Pos;

        public Slot1()
        {
            //slot1 = YourGame.AssetManager.LoadTexture("slot1");
            //slot1Pos = new Vector2((YourGame.ScreenSize.X / 2 - slot1.Width - slot1.Width / 2 - slot1.Width / 6), YourGame.ScreenSize.Y - slot1.Height);


        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            //spriteBatch.Draw(slot1, new Vector2(YourGame.ScreenSize.X / 2 - 2 * slot1.Width - slot1.Width / 2, YourGame.ScreenSize.Y - slot1.Height - slot1.Height / 2), Color.White);

        }
    }
}
