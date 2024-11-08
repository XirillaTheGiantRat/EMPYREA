using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;


namespace YourEngine
{
    public sealed class DialogueReader : GameObject
    {
        Dictionary<int,string> dialogueLines = new Dictionary<int,string>();
        Texture2D backGround;
        SpriteFont font;
        Timer timer;

        int reader;
        const int lineOffset = 30;
        public bool DialogeEnded { get; private set; } = false;
        public bool DialogueLoop { get; set; } = false;
        public Rectangle DialogueRagtangle { get; set; }
        public int Height { get { return backGround.Height; } }
        public int Widht {  get { return backGround.Width; } }
        public DialogueReader(Texture2D backGround, SpriteFont font, Dictionary<int, string> dialogueLines) 
        {
            timer = new Timer(5);
            timer.RestartsOnFinish = false;
            this.font = font;
            this.backGround = backGround; 
            this.dialogueLines = dialogueLines;
            DialogeEnded = false;
            reader = 0;
        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            timer.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            if(timer.IsFinished)
            {
                Skip();
            }
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backGround, DialogueRagtangle, Color.White);
            spriteBatch.DrawString(font, dialogueLines[reader], 
                new Vector2(DialogueRagtangle.X, DialogueRagtangle.Y) + new Vector2(lineOffset, lineOffset), Color.White); 
        }
        public void Skip()
        {
            reader++;
            timer.Restart();
            if (reader > dialogueLines.Count() - 1)
            {
                if (DialogueLoop)
                {
                    reader = 0;
                }
                else 
                { 
                    reader = dialogueLines.Count() - 1; 
                }
                DialogeEnded = true;
            }
        }

    }
}
