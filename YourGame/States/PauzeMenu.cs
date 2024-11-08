using Microsoft.Xna.Framework;
using YourEngine;

namespace YourGame.States
{
    public sealed class PauzeMenu : State
    {
        State levelstate;
        Sprite background, paused;
        Button backButton, settingsButton, quitButton;
        public bool Active {  get; private set; }
        public PauzeMenu(State levelState) 
        {
            //this.levelstate = levelState;
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

            paused = new Sprite(YourGame.AssetManager.LoadTexture("Buttons/paused"));
            paused.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2 - paused.Texture.Width/2, YourGame.ScreenSize.Y /4);

            this.backButton = new Button(YourGame.AssetManager.LoadTexture("Buttons/resumebutton"),
            YourGame.AssetManager.LoadTexture("Buttons/resumebuttonpressed"));

            backButton.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2 - backButton.Width / 2,
                YourGame.ScreenSize.Y / 1.2f);

            this.AddChild(backButton);

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
            Active = false;
        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            Active = true;
            if (backButton.Pressed)
            {
                Active = false;
                Parent.RemoveChild(this);
                //this.NextState = levelstate;
            }
            if (settingsButton.Pressed)
            {
                Active = false;
                this.AddChild(MainMenu.smenu);
                //this.NextState = new SettingsMenu(this);
            }
            if (quitButton.Pressed)
            {
                Active = false;
                this.NextState = new MainMenu();
            }
        }
    }
}
