using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using YourEngine;

namespace YourGame.States
{
    /// <summary>
    /// An example of how you could make a splash screen.
    /// </summary>
    public sealed class SettingsMenu : State
    {
        //private readonly SoundEffectInstance sfx;
        private Sprite background, settingsbutton, fullscreenoff, resolutions, selectresolution;
        Button backButton;
        Slider musicSlider;
        State prevState;

        public SettingsMenu(State prevState) : base()
        {
            //this.prevState = prevState;
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


            this.settingsbutton = new Sprite(YourGame.AssetManager.LoadTexture("settingsbutton"))
            {
                GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2, YourGame.ScreenSize.Y / 4f),
                OriginType = OriginType.Center
            };

            this.AddChild(settingsbutton);

            this.backButton = new Button(YourGame.AssetManager.LoadTexture("backbutton"),
                YourGame.AssetManager.LoadTexture("Buttons/backbuttonpressed"));

            backButton.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2 - backButton.Width / 2,
                YourGame.ScreenSize.Y / 1.2f);

            this.AddChild(backButton);

            this.musicSlider = new Slider(YourGame.AssetManager.LoadTexture("Buttons/slider"),
                YourGame.AssetManager.LoadTexture("Buttons/sliderpointer"));

            musicSlider.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2 - musicSlider.Width / 2,
                YourGame.ScreenSize.Y / 2);

            this.AddChild(musicSlider);

            if (YourGame.Fullscreen)
            {
                fullscreenoff = new Sprite(YourGame.AssetManager.LoadTexture("fullscreenoff"))
                {
                    GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2, YourGame.ScreenSize.Y / 3f),
                    OriginType = OriginType.Center
                };
            }

            else
            {
                fullscreenoff = new Sprite(YourGame.AssetManager.LoadTexture("fullscreenon"))
                {
                    GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2, YourGame.ScreenSize.Y / 1.8f),
                    OriginType = OriginType.Center
                };
            }

            this.AddChild(fullscreenoff);

            this.selectresolution = new Sprite(YourGame.AssetManager.LoadTexture("selectresolution"))
            {
                GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2, YourGame.ScreenSize.Y / 2.5f),
                OriginType = OriginType.Center
            };

            this.AddChild(selectresolution);

            this.resolutions = new Sprite(YourGame.AssetManager.LoadTexture("resolutions"))
            {
                GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2, YourGame.ScreenSize.Y / 1.95f),
                OriginType = OriginType.Center
            };

            this.AddChild(resolutions);

            this.resolutions.Opacity = 0;
            
            MediaPlayer.Play(YourGame.AssetManager.LoadSong("Test/disposal"));
            MediaPlayer.IsRepeating = true;
        }

        protected override void EnterSelf()
        {

        }

        protected override void UpdateSelf(GameTime gameTime)
        {
            MediaPlayer.Volume = musicSlider.CurrentValue;


            if (YourGame.InputManager.CheckIsKeyJustPressed(Keys.Space))
                this.Skip();

            Rectangle fullscreencollision = new Rectangle(YourGame.ScreenSize.X / 2 - fullscreenoff.Texture.Width + 10, (int)(YourGame.ScreenSize.Y / 1.2f - fullscreenoff.Texture.Width + 8), fullscreenoff.Texture.Width + 3, fullscreenoff.Texture.Height);

            if (fullscreencollision.Contains(YourGame.GetMouseWorldPosition()) && YourGame.InputManager.HasMouseJustLeftClicked)
            {
                //this.NextState = new MainMenu();
            }

            if (backButton.Pressed)
            {
                //this.NextState = prevState;
                Parent.RemoveChild(this);
            }

            Rectangle selectresolutioncollision = new Rectangle(YourGame.ScreenSize.X / 2 - fullscreenoff.Texture.Width + 10, (int)(YourGame.ScreenSize.Y / 1.6f - fullscreenoff.Texture.Width + 8), fullscreenoff.Texture.Width + 90, fullscreenoff.Texture.Height);

            if (selectresolutioncollision.Contains(YourGame.GetMouseWorldPosition()))
            {
                if (this.resolutions.Opacity == 0 && YourGame.InputManager.HasMouseJustLeftClicked)
                {
                    this.resolutions.Opacity = 100;
                }
            }

            Rectangle resolutionscollision = new Rectangle(YourGame.ScreenSize.X / 2 - fullscreenoff.Texture.Width + 10, (int)(YourGame.ScreenSize.Y / 1.4f - fullscreenoff.Texture.Width + 8), fullscreenoff.Texture.Width + 90, fullscreenoff.Texture.Height + 60);

            if (resolutionscollision.Contains(YourGame.GetMouseWorldPosition()) && YourGame.InputManager.HasMouseJustLeftClicked)
            {
                    this.resolutions.Opacity = 0;
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
