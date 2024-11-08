using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Runtime.CompilerServices;
using YourEngine;

namespace YourGame.States
{
    /// <summary>
    /// An example of how you could make a splash screen.
    /// </summary>
    public sealed class MainMenu : State
    {
        //private readonly SoundEffectInstance sfx;
        private readonly Timer timer;
        private readonly Sprite logo, background;
        private Phase phase = Phase.FadeIn;
        Button playButton, settingsButton, quitButton, multiplayrButtn;
        bool switching;
        public static SettingsMenu smenu;

        public MainMenu() : base()
        {
            smenu = new SettingsMenu(this);
            switching = false;
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

            this.timer = new Timer(timeLimitInSeconds: 1)
            {
                RestartsOnFinish = false
            };

            this.logo = new Sprite(YourGame.AssetManager.LoadTexture("logo2"))
            {
                GlobalPosition = YourGame.ScreenSize.ToVector2() / 2,
                OriginType = OriginType.Center
            };

            this.AddChild(logo);

            this.playButton = new Button(YourGame.AssetManager.LoadTexture("playbutton"),
                YourGame.AssetManager.LoadTexture("playbuttonpressed"));

            playButton.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2 - playButton.Width / 2,

               YourGame.ScreenSize.Y / 1.6f);


            this.AddChild(playButton);

            this.multiplayrButtn = new Button(YourGame.AssetManager.LoadTexture("Buttons/multiplayerbutton"),
                YourGame.AssetManager.LoadTexture("Buttons/multiplayerbuttonpressed"));

            multiplayrButtn.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2 - multiplayrButtn.Width / 2,

               YourGame.ScreenSize.Y / 1.49f);


            this.AddChild(multiplayrButtn);

            this.settingsButton = new Button(YourGame.AssetManager.LoadTexture("settingsbutton"),
                YourGame.AssetManager.LoadTexture("Buttons/settingsbuttonpressed"));
            
            settingsButton.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2 - settingsButton.Width / 2, 
                YourGame.ScreenSize.Y / 1.39f);

            this.AddChild(settingsButton);

            this.quitButton = new Button(YourGame.AssetManager.LoadTexture("quitbutton"),
                YourGame.AssetManager.LoadTexture("Buttons/quitbuttonpressed"));

            quitButton.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2 - quitButton.Width / 2,
                YourGame.ScreenSize.Y / 1.3f);

            this.AddChild(quitButton);
        }

        

        private enum Phase
        {
            FadeIn,
            Hold,
            FadeOut
        }

        protected override void EnterSelf()
        {
            this.timer.Finished += this.OnTimerFinished;
        }

        protected override void UpdateSelf(GameTime gameTime)
        {
            this.timer.Update(gameTime.Delta());

            switch (this.phase)
            {
                case Phase.FadeIn:
                    this.logo.Transparency = this.timer.TimeLeftToTimeLimitRatio;
                    break;
                default:
                case Phase.Hold:
                    break;
                case Phase.FadeOut:
                    this.logo.Transparency = this.timer.TimeElapsedToTimeLimitRatio;
                    break;
            }

            if (YourGame.InputManager.CheckIsKeyJustPressed(Keys.Space))
                this.Skip();

            if (playButton.Pressed)
            {
                this.ClassMenu();
            }

            if (settingsButton.Pressed)
            {
                    this.SettingsMenu();
            }


            if (multiplayrButtn.Pressed) 
            {
                this.NextState = new Multiplayer();

            }

            if (quitButton.Pressed)
            {
                YourGame.Quit = true;
            }
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            //
        }

        protected override void ExitSelf()
        {
            this.timer.Finished -= this.OnTimerFinished;
            //this.sfx.Stop();
        }

        private void OnTimerFinished()
        {
            switch (this.phase)
            {
                case Phase.FadeIn:
                    // An enum is a number under the hood, so we can do this ++ trick!
                    ++this.phase;
                    this.timer.TimeLimitInSeconds = 1;
                    this.timer.Restart();
                    break;
                case Phase.Hold:
                    // ++this.phase;
                    this.timer.TimeLimitInSeconds = 1.75f;
                    this.timer.Restart();
                    break;
                default:
                case Phase.FadeOut:
                    this.Skip();
                    break;
            }
        }
        
        
        private void SettingsMenu()
        {
            this.AddChild(smenu);
            //this.NextState = new SettingsMenu(this);
        }

        private void ClassMenu()
        {
            this.NextState = new ClassMenu();
        }
        private void Skip()
        {
            this.NextState = new TryYourselfState();
        }
    }
}
