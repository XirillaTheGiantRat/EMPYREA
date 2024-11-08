using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YourEngine;

namespace YourGame
{
    public sealed class Button : GameObject
    {
        Texture2D buttonSprite, hoverSprite;
        public int Width { get {  return buttonSprite.Width; } }
        public int Height {  get { return buttonSprite.Height; } }
        public Button(Texture2D buttonSprite, Texture2D hoverSprite)
        {
            this.buttonSprite = buttonSprite;
            this.hoverSprite = hoverSprite;
        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            if (ButtonRagtangle.Contains(YourGame.GetMouseWorldPosition()))
            {
                Pressed = false;
                RemoveAllChildren();
                Sprite hs = new Sprite(hoverSprite);
                AddChild(hs);
                if (YourGame.InputManager.HasMouseJustLeftClicked)
                {
                    Pressed = true;
                }
            }
            else
            {
                RemoveAllChildren();
                Pressed = false;
                Sprite bs = new Sprite(buttonSprite);
                AddChild(bs);
            }
        }
        public Rectangle ButtonRagtangle
        {
            get { return new Rectangle(
                (int)GlobalPosition.X, 
                (int)GlobalPosition.Y,
                buttonSprite.Width, 
                buttonSprite.Height); }
        }
        public bool Pressed { get; private set; }
    }
}

//Quithy
//quithy
//For some clips:
//https://medal.tv/u/Quithy?invite=ur-MSxTQVcsNzE2NjcwMTMs