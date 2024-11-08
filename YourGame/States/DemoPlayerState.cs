using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections.Generic;
using YourEngine;
using YourGame.Objects;

namespace YourGame.States
{
    /// <summary>
    /// A demo of a custom GameObject class (Player.cs). Can you spot the player?
    /// </summary>
    public sealed class DemoPlayerState : State
    {
       /* private const int MaxWorldDimension = 1000000;
        private readonly Sprite backgroundSprite;
        private Sprite healthbar1;
        private Sprite healthbar2;
        private Sprite healthbar3;
        private Sprite healthbar4;
        private Sprite healthbar5;

        private Sprite emptyhealthbar1;
        private Sprite emptyhealthbar2;
        private Sprite emptyhealthbar3;
        private Sprite emptyhealthbar4;
        private Sprite emptyhealthbar5;
        private readonly Player player;
        private readonly Timer timer;
        private readonly Song ambience;
        private Sprite sword;
        bool isSwordVisible = true;
        Vector2 heartPos1;
        Vector2 heartPos2;
        Vector2 heartPos3;
        Vector2 heartPos4;
        Vector2 heartPos5;

        //  private Animation playerAnimation;


        public DemoPlayerState() : base()
        {
            ambience = YourGame.AssetManager.LoadSong("SM64Birds");



            heartPos1.Y = heartPos2.Y = heartPos3.Y = heartPos4.Y = heartPos5.Y = YourGame.ScreenSize.Y - 20;
            heartPos1.X = YourGame.ScreenSize.X - 20;
            heartPos2.X = YourGame.ScreenSize.X - 36;
            heartPos3.X = YourGame.ScreenSize.X - 20 - 16 * 2;
            heartPos4.X = YourGame.ScreenSize.X - 20 - 16 * 3;
            heartPos5.X = YourGame.ScreenSize.X - 20 - 16 * 4;


            this.DrawClearColor = Color.CornflowerBlue;


            this.backgroundSprite = new Sprite(texture: YourGame.AssetManager.LoadTexture("TX Tileset Grass", "Pixel Art Top Down - Basic/"))
            {
                BaseDrawLayer = 0
            };
            this.player = new Player()
            {
                GlobalPosition = YourGame.ScreenSize.ToVector2() / 2,
            };



            //  var playerTexture = YourGame.AssetManager.LoadTexture("run", "Pixel Art Top Down - Basic/");

            //   playerAnimation = new Animation(playerTexture, framesX: 4, frameTime: 0.2f);



            this.AddChild(this.backgroundSprite);
            this.AddChild(this.player);



            this.timer = new Timer(timeLimitInSeconds: 5);
        }

        protected override void EnterSelf()
        {
            MediaPlayer.Play(ambience);
            MediaPlayer.IsRepeating = true;
            this.timer.Finished += this.OnTimerFinished;
        }

        protected override void UpdateSelf(GameTime gameTime)
        {
            this.timer.Update(gameTime.Delta());

            //  playerAnimation.Update(gameTime);

            //this.player.Sprite.BaseDrawLayer = this.CalculateYSort(this.player.Sprite.GlobalPosition.Y);

            //if (this.player.Sprite.GlobalPosition == YourGame.ScreenSize.ToVector2() / 3)
            //{
                //this.RemoveChild(this.sword);
            //}

            if (isSwordVisible)
            {
                this.sword = new Sprite(texture: YourGame.AssetManager.LoadTexture("sword", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = YourGame.ScreenSize.ToVector2() / 3,
                };
                this.AddChild(this.sword);
            }

            if (this.player.GlobalPosition == YourGame.ScreenSize.ToVector2() / 3)
            {
            //    player.Healt--;
            }


            if (YourGame.InputManager.CheckIsKeyJustPressed(Keys.Space))
                this.NextState = new SplashScreenState();

            if (player.Healt == 5)
            {
                this.healthbar1 = new Sprite(texture: YourGame.AssetManager.LoadTexture("Red 16px1", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos1,

                };
                this.healthbar2 = new Sprite(texture: YourGame.AssetManager.LoadTexture("Red 16px1", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos2,

                };
                this.healthbar3 = new Sprite(texture: YourGame.AssetManager.LoadTexture("Red 16px1", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos3,

                };
                this.healthbar4 = new Sprite(texture: YourGame.AssetManager.LoadTexture("Red 16px1", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos4,

                };
                this.healthbar5 = new Sprite(texture: YourGame.AssetManager.LoadTexture("Red 16px1", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos5,

                };


                this.AddChild(healthbar1);
                this.AddChild(healthbar2);
                this.AddChild(healthbar3);
                this.AddChild(healthbar4);
                this.AddChild(healthbar5);

            }

            if (player.Healt == 4)
            {
                this.healthbar1 = new Sprite(texture: YourGame.AssetManager.LoadTexture("Red 16px1", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos1,

                };
                this.healthbar2 = new Sprite(texture: YourGame.AssetManager.LoadTexture("Red 16px1", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos2,

                };
                this.healthbar3 = new Sprite(texture: YourGame.AssetManager.LoadTexture("Red 16px1", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos3,

                };
                this.healthbar4 = new Sprite(texture: YourGame.AssetManager.LoadTexture("Red 16px1", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos4,

                };
                this.emptyhealthbar5 = new Sprite(texture: YourGame.AssetManager.LoadTexture("16px", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos5,

                };



                this.AddChild(healthbar1);
                this.AddChild(healthbar2);
                this.AddChild(healthbar3);
                this.AddChild(healthbar4);
                this.AddChild(emptyhealthbar5);

            }

            if (player.Healt == 3)
            {
                this.healthbar1 = new Sprite(texture: YourGame.AssetManager.LoadTexture("Red 16px1", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos1,

                };
                this.healthbar2 = new Sprite(texture: YourGame.AssetManager.LoadTexture("Red 16px1", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos2,

                };
                this.healthbar3 = new Sprite(texture: YourGame.AssetManager.LoadTexture("Red 16px1", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos3,

                };
                this.emptyhealthbar4 = new Sprite(texture: YourGame.AssetManager.LoadTexture("16px", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos4,

                };
                this.emptyhealthbar5 = new Sprite(texture: YourGame.AssetManager.LoadTexture("16px", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos5,

                };



                this.AddChild(healthbar1);
                this.AddChild(healthbar2);
                this.AddChild(healthbar3);
                this.AddChild(emptyhealthbar4);
                this.AddChild(emptyhealthbar5);

            }

            if (player. Healt == 2)
            {
                this.healthbar1 = new Sprite(texture: YourGame.AssetManager.LoadTexture("Red 16px1", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos1,

                };
                this.healthbar2 = new Sprite(texture: YourGame.AssetManager.LoadTexture("Red 16px1", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos2,

                };
                this.emptyhealthbar3 = new Sprite(texture: YourGame.AssetManager.LoadTexture("16px", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos3,

                };
                this.emptyhealthbar4 = new Sprite(texture: YourGame.AssetManager.LoadTexture("16px", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos4,

                };
                this.emptyhealthbar5 = new Sprite(texture: YourGame.AssetManager.LoadTexture("16px", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos5,

                };



                this.AddChild(healthbar1);
                this.AddChild(healthbar2);
                this.AddChild(emptyhealthbar3);
                this.AddChild(emptyhealthbar4);
                this.AddChild(emptyhealthbar5);

            }

            if (player.Healt == 1)
            {
                this.healthbar1 = new Sprite(texture: YourGame.AssetManager.LoadTexture("Red 16px1", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos1,

                };
                this.emptyhealthbar2 = new Sprite(texture: YourGame.AssetManager.LoadTexture("16px", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos2,

                };
                this.emptyhealthbar3 = new Sprite(texture: YourGame.AssetManager.LoadTexture("16px", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos3,

                };
                this.emptyhealthbar4 = new Sprite(texture: YourGame.AssetManager.LoadTexture("16px", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos4,

                };
                this.emptyhealthbar5 = new Sprite(texture: YourGame.AssetManager.LoadTexture("16px", "Pixel Art Top Down - Basic/"))
                {
                    GlobalPosition = heartPos5,

                };



                this.AddChild(healthbar1);
                this.AddChild(emptyhealthbar2);
                this.AddChild(emptyhealthbar3);
                this.AddChild(emptyhealthbar4);
                this.AddChild(emptyhealthbar5);

            }

        }


        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            //   playerAnimation.Draw(spriteBatch, player.GlobalPosition);

        }

        protected override void ExitSelf()
        {
            MediaPlayer.Stop();
            this.timer.Finished -= this.OnTimerFinished;
        }

        private float CalculateYSort(float yGlobalPosition)
        {
            // A demo of how Y-sort could work.
            // If you want Y-sort to work with the game tree automatically, then you need
            // to think of how you can make GameObject instances "inherit" their DrawLayer somehow
            // to deal with nesting.
            return yGlobalPosition * (1f / MaxWorldDimension);
        }


        private void OnTimerFinished()
        {
            /*foreach (Sprite treeSprite in this.treeSprites)
                treeSprite.GlobalPosition = new Vector2(
                    x: YourGame.Random.Next(64, YourGame.ScreenSize.X - 64),
                    y: YourGame.Random.Next(64, YourGame.ScreenSize.Y - 64)
                    );
        }*/
    }
}