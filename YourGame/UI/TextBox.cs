using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using YourEngine;


namespace YourGame
{
    sealed class TextBox : GameObject
    {
        public string Text {  get; private set; }
        public int Height { get { return backGroundsprite.Height; } }
        public int Width { get {  return backGroundsprite.Width; } }
        public bool Selected { get; set; }

        Texture2D backGroundsprite;
        SpriteFont font;

        public Rectangle BoxRectangel { get; set; }
        int length;

        public TextBox(Texture2D backGroundsprite, SpriteFont font, int length)
        {
            this.backGroundsprite = backGroundsprite;
            this.font = font;
            this.length = length;
            Text = string.Empty;
            Selected = false;
        }
        public void AddText(char text)
        {
            bool lowercase = true;
            if (YourGame.InputManager.CheckIsKeyPressed(Keys.LeftShift) || YourGame.InputManager.CheckIsKeyPressed(Keys.RightShift)) 
            {
                lowercase = false;  
            }
            if (text != '\b')
            {
                if(Text.Length < length) 
                {
                    if(lowercase)
                    {
                        text = Char.ToLower(text);
                    }

                    Text += text;
                }
            }
            else if (text == '.')
            {
                Text += text;
            }
            else
            {
                if(Text.Length > 0)
                {
                    Text = Text.Remove(Text.Length - 1, 1);
                }
            }
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backGroundsprite, BoxRectangel, Color.White);
            spriteBatch.DrawString(font, Text, new Vector2(BoxRectangel.X + 2, BoxRectangel.Y + 2), Color.White);
        }
    }
}
