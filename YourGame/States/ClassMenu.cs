using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Net.NetworkInformation;
using YourEngine;

namespace YourGame.States
{
    /// <summary>
    /// An example of how you could make a splash screen.
    /// </summary>
    public sealed class ClassMenu : State
    {
        //private readonly SoundEffectInstance sfx;
        private Sprite background;
        Button backButton, class1, class2, class3;
        public static bool aoe, range, melee;

        public ClassMenu() : base()
        {
            this.background = new Sprite(YourGame.AssetManager.LoadTexture("backgroundcolour"))
            {
                GlobalPosition = YourGame.ScreenSize.ToVector2() / 2,
                SourceRectangle = new Rectangle(
                    location: new Point(0, 0),
                    size: new Point(1920, 1080)
                    ),
                OriginType = OriginType.Center
            };

            this.AddChild(background);


            this.backButton = new Button(YourGame.AssetManager.LoadTexture("backbutton"),
                YourGame.AssetManager.LoadTexture("Buttons/backbuttonpressed"));

            backButton.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2 - backButton.Width / 2,
                YourGame.ScreenSize.Y / 1.2f);

            this.AddChild(backButton);

            this.class1 = new Button(YourGame.AssetManager.LoadTexture("class1"),
                YourGame.AssetManager.LoadTexture("Buttons/class1pressed"));
            class1.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 3 - class1.Width/2, YourGame.ScreenSize.Y / 1.8f);

            this.AddChild(class1);

            this.class2 = new Button(YourGame.AssetManager.LoadTexture("class2"),
                YourGame.AssetManager.LoadTexture("Buttons/class2pressed"));
            class2.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2 - class1.Width / 2, YourGame.ScreenSize.Y / 1.8f);

            this.AddChild(class2);

            this.class3 = new Button(YourGame.AssetManager.LoadTexture("class3"),
                YourGame.AssetManager.LoadTexture("Buttons/class3pressed"));
            class3.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 1.5f - class1.Width / 2, YourGame.ScreenSize.Y / 1.8f);

            this.AddChild(class3);
        }

        protected override void EnterSelf()
        {

        }

        protected override void UpdateSelf(GameTime gameTime)
        {

            if (YourGame.InputManager.CheckIsKeyJustPressed(Keys.Space))
                this.Skip();

            if (backButton.Pressed)
            {

                this.NextState = new MainMenu();
            }
            if(class1.Pressed)
            {
                melee = true;
                this.NextState = new Tutorial();
            }
            else if (class2.Pressed)
            {
                range = true;
                this.NextState = new Level();
            }
            else if (class3.Pressed)
            {
                aoe = true;
                this.NextState = new Level();
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            //
        }

        protected override void ExitSelf()
        {
            //this.sfx.Stop();
        }

        private void Skip()
        {
            this.NextState = new MainMenu();
        }
    }
}
