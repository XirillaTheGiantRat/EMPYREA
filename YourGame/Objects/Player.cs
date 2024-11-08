
//actual player but when i tried to add this code to player 2 it stopped working ;)


using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using YourEngine;
using YourGame.States;
using Microsoft.Xna.Framework.Audio;
using System.ComponentModel;


namespace YourGame.Objects
{
    public class Player : GameObject
    {
       /* Sprite player, expl;
        public static Vector2 playerPos, teleport = new Vector2(50, 0), teleportY = new Vector2(50, 0), storedPlacement;
        public static int posX = 50, posY = 50, lastPosX, lastPosY, health, shots = 5;
        public static Rectangle playerBox;
        public bool collisonN = false, collisonE = false, collisonS = false, collisonW = false, melee = false, range = false, aoe = true, tpTimeOut = false, timeOut = false, timeOut2 = false, isFlipped = false, reload = false, boost = false;
        float dashTimer, tpTimer, timeOutTimer, timeOutTimer2, dashDuration = 0.1f, tpDuration = 3.0f, timeOutDuration = 3.0f, timeOutTimerDuration;
        private SoundEffect swoosh, wind, activate;
        private SoundEffectInstance playerSoundEffectInstance, playerSoundEffectInstance1, playerSoundEffectInstance2;
        Timer dashcooldown;
        PlayerUI ui;
        public int Healt { get; private set; }
        public float Dashtimercooldown { get { return dashcooldown.TimeLeftInSeconds; } }

        public Player() : base()
        {
            this.player = new Sprite(YourGame.AssetManager.LoadTexture("Player"));
            expl = new Sprite(YourGame.AssetManager.LoadTexture("exploxion"));

            this.Velocity = 64;
            health = 3;
            GlobalPosition = new Vector2(posX, posY);
            playerBox = new Rectangle(posX, posY, 20, 31);
            dashTimer = 0;
            expl.GlobalPosition = new Vector2(-500, -500);


            this.AddChild(player);
            this.AddChild(expl);

            //soundeffects
            swoosh = YourGame.AssetManager.LoadSoundEffect("mixkit-sword-blade-attack-in-medieval-battle-2762");
            playerSoundEffectInstance = swoosh.CreateInstance();
            wind = YourGame.AssetManager.LoadSoundEffect("mixkit-short-wind-swoosh-1461");
            playerSoundEffectInstance1 = wind.CreateInstance();
            activate = YourGame.AssetManager.LoadSoundEffect("radio-103737");
            playerSoundEffectInstance2 = activate.CreateInstance();

            dashcooldown = new Timer(3);
            dashcooldown.RestartsOnFinish = true;
            this.player = new Sprite(YourGame.AssetManager.LoadTexture("Player"));
            Healt = 100;
            //ui = new PlayerUI(this);
            //this.AddChild(ui);
        }

        protected override void UpdateSelf(GameTime gameTime)
        {

            if (range && boost)
            {
                timeOutTimerDuration = 1.0f;
            }
            else
            {
                timeOutTimerDuration = 3.0f;
            }

            //Camera.Update(LocalPosition);

            lastPosX = posX; lastPosY = posY;

            if (playerBox.Intersects(Room.drawerBox))
            {
                if (lastPosX < Room.drawerBox.X)
                {
                    collisonE = true;
                }
                if (lastPosX > Room.drawerBox.X)
                {
                    collisonW = true;
                }
                if (lastPosY < Room.drawerBox.Y)
                {
                    collisonS = true;
                }
                if (lastPosY > Room.drawerBox.Y)
                {
                    collisonN = true;
                }
            }

            if (playerBox.Intersects(Room.startroom1Box))
            {
                collisonN = true;
            }
            if (playerBox.Intersects(Room.startroom2Box))
            {
                collisonW = true;
            }
            if (playerBox.Intersects(Room.startroom3Box))
            {
                collisonE = true;
            }
            if (playerBox.Intersects(Room.startroom4Box))
            {
                collisonW = true;
            }
            if (playerBox.Intersects(Room.startroom5Box))
            {
                collisonE = true;
            }
            if (playerBox.Intersects(Room.startroom6Box))
            {
                collisonS = true;
            }
            if (playerBox.Intersects(Room.startroom7Box))
            {
                collisonS = true;
            }

            Vector2 direction = Vector2.Zero;


            if (!collisonN)
            {
                if (YourGame.InputManager.CheckIsKeyPressed(Keys.W))
                {
                    direction -= Vector2.UnitY;
                    posY = posY - 1;
                    playerBox.Y = posY;
                }
            }
            if (!collisonW)
            {
                if (YourGame.InputManager.CheckIsKeyPressed(Keys.A))
                {
                    direction -= Vector2.UnitX;

                    if (!isFlipped)
                    {
                        player.Effects = SpriteEffects.FlipHorizontally;
                        isFlipped = true;
                    }
                    posX = posX - 1;
                    playerBox.X = posX;
                }
            }
            if (!collisonS)
            {
                if (YourGame.InputManager.CheckIsKeyPressed(Keys.S))
                {
                    direction += Vector2.UnitY;
                    posY = posY + 1;
                    playerBox.Y = posY;
                }
            }
            if (!collisonE)
            {
                if (YourGame.InputManager.CheckIsKeyPressed(Keys.D))
                {
                    direction += Vector2.UnitX;
                    if (isFlipped)
                    {
                        player.Effects = SpriteEffects.None;
                        isFlipped = false;
                    }
                    posX = posX + 1;
                    playerBox.X = posX;
                }
            }



            collisonN = false;
            collisonE = false;
            collisonS = false;
            collisonW = false;

            if (YourGame.InputManager.HasMouseJustLeftClicked && !timeOut2 && boost)
            {
                if (timeOut2 == false)
                {
                    swoosh.Play();
                    timeOutTimer2 = timeOutTimerDuration;
                    timeOut2 = true;
                    shots--;
                }
            }
            else if (YourGame.InputManager.HasMouseJustLeftClicked && !timeOut2 && !reload)
            {
                if (timeOut2 == false)
                {
                    swoosh.Play();
                    timeOutTimer2 = timeOutTimerDuration;
                    timeOut2 = true;
                    shots--;
                }
            }

            if (shots == 0)
            {
                reload = true;
            }


            if (YourGame.InputManager.CheckIsKeyPressed(Keys.R))
            {
                reload = false;
                shots = 5;
            }

            if (YourGame.InputManager.CheckIsKeyPressed(Keys.G))
            {
                activate.Play();

                if (melee)
                {
                    if (tpTimeOut == false)
                    {
                        tpTimer = tpDuration;
                        tpTimeOut = true;
                        if (YourGame.InputManager.CheckIsKeyPressed(Keys.W))
                        {
                            GlobalPosition -= teleportY;

                        }
                        else if (!isFlipped)
                        {
                            GlobalPosition += teleport;
                        }
                        else if (isFlipped)
                        {
                            GlobalPosition -= teleport;
                        }
                        else if (YourGame.InputManager.CheckIsKeyPressed(Keys.S))
                        {
                            GlobalPosition += teleportY;
                        }

                    }
                }
                if (range)
                {
                    boost = true;
                }
                if (aoe)
                {
                    expl.GlobalPosition = player.GlobalPosition;
                }

            }

            if (tpTimer > 0)
            {
                tpTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                tpTimeOut = false;
                tpTimer = 0;
            }



            if (YourGame.InputManager.CheckIsKeyPressed(Keys.Space))
            {
                if (timeOut == false)
                {
                    dashTimer = dashDuration;
                    timeOut = true;
                    timeOutTimer = timeOutDuration;
                }
            }

            if (dashTimer > 0)
            {
                dashTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
                this.Velocity = 400;
                wind.Play();
            }
            else
            {
                dashTimer = 0;
                this.Velocity = 64;
            }

            if (timeOutTimer > 0)
            {
                timeOutTimer -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                timeOut = false;
                timeOutTimer = 0;
            }

            if (timeOutTimer2 > 0)
            {
                timeOutTimer2 -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                timeOut2 = false;
                timeOutTimer2 = 0;
            }






            this.Direction = direction;
        }*/
    }
}

