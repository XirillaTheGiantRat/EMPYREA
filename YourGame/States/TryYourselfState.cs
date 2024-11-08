using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using System.Linq;
using YourEngine;
using YourGame.Objects;


namespace YourGame.States
{
    
    public sealed class TryYourselfState : State
    {
        DialogueReader reader;
        Animation animation, ploxion;
        NPC npc;
        public TryYourselfState()
        {
            reader = new DialogueReader(YourGame.AssetManager.LoadTexture("dialoguebox"), YourGame.AssetManager.LoadFont("File"),
                ExtensionMethods.ReadDialogueFromFile("Content/dialogue.txt"));
            reader.DialogueRagtangle = new Rectangle(0,0,YourGame.ScreenSize.X,128);
            //this.AddChild(reader);
            animation = new Animation(YourGame.AssetManager.LoadTexture("Test/qwertyuiop["), 2);
            animation.GlobalPosition = new Vector2(YourGame.ScreenSize.X /2, 200);
            //this.AddChild(animation);
            npc = new NPC(this, false, new Animation(YourGame.AssetManager.LoadTexture("Weapons/exploxion"), 10),
                new Animation(YourGame.AssetManager.LoadTexture("Test/qwertyuiop["), 2), 
                new DialogueReader(YourGame.AssetManager.LoadTexture("dialoguebox"), YourGame.AssetManager.LoadFont("File"),
                ExtensionMethods.ReadDialogueFromFile("Content/dialogue.txt")), null);
            npc.GlobalPosition = YourGame.ScreenSize.ToVector2() / 2;
            this.AddChild(npc);
        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            if(YourGame.InputManager.CheckIsKeyJustPressed(Keys.Space))
            {
                reader.Skip();
                animation.Run = true;
                if (!npc.Interacting)
                {
                    npc.Interact();
                }
                this.NextState = new MultiplayerLevel();
            }
            if (reader.DialogeEnded)
            {
                this.RemoveChild(reader);
                this.NextState = new MainMenu();
            }
            if(YourGame.InputManager.CheckIsKeyJustPressed(Keys.Escape))
            {
                this.AddChild(new PauzeMenu(this));
            }
        }
    }
}
