using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using YourEngine;
using YourGame.States;
using YourGame.UI;
using Microsoft.Xna.Framework.Audio;

namespace YourGame.Objects
{
    public class Player2 : GameObject
    {
        Animation player;
        YourEngine.Timer dashcooldown;
        PlayerUI ui;
        Slot1 slot1;
        Slot2 slot2;
        Slot3 slot3;
        Musket musket, musket2, musket3, musket4;
        Rectangle MusketBox, MusketBox2, MusketBox3, musketBox;
        bool holding1 = false, holding2 = false, holding3 = false, holding4 = false, holding11 = false, holding12 = false, holding13 = false, holding21 = false, holding22 = false, holding23 = false, holding31 = false, holding32 = false, holding33 = false;
        int shots = 5;
        Sprite chest, openChest;
        public bool openC = false;
        //private SoundEffect swoosh, wind, activate;
        private SoundEffectInstance playerSoundEffectInstance, playerSoundEffectInstance1, playerSoundEffectInstance2;
        float dashTimer, tpTimer, timeOutTimer, timeOutTimer2, dashDuration = 0.1f, tpDuration = 3.0f, timeOutDuration = 3.0f, timeOutTimerDuration = 3.0f, timeOutGT = 3.0f, bombTime;
        public bool tpTimeOut = false, timeOut = false, timeOut2 = false, isFlipped = false, reload = false, boost = false, timeOutG = false, bombGo;

        public static Vector2 playerPos, test, holdingpos;
        public int posX, posY, lastPosX, lastPosY;
        public Rectangle playerBox, chestBox;
        public bool collisonN = false, collisonE = false, collisonS = false, collisonW = false;
        public int Healt { get; private set; }
        public float Dashtimercooldown { get { return dashcooldown.TimeLeftInSeconds; } }

        public int CraftingMaterials { get; set; }

        Sprite expl;
        public static Vector2 teleport = new Vector2(50, 0), teleportY = new Vector2(50, 0), storedPlacement, s;

        public const int maxHealth = 100;
        public const int maxDashCooldown = 3;
        
        public Player2() : base()
        {
            dashcooldown = new YourEngine.Timer(3);
            dashcooldown.RestartsOnFinish = true;
            this.player = new Animation(YourGame.AssetManager.LoadTexture("playeridle"), 6);
            //expl = new Sprite(YourGame.AssetManager.LoadTexture("exploxion"));
            this.AddChild(player);
            playerPos = new Vector2(posX, posY);
            playerBox = new Rectangle(posX, posY, 20, 31);
            ui = new PlayerUI(this);
            this.AddChild(ui);
            
            /*slot1 = new Slot1();
            AddChild(slot1);
            slot2 = new Slot2();
            AddChild(slot2);
            slot3 = new Slot3();
            AddChild(slot3);
            musket = new Musket();
            musket2 = new Musket();
            musket3 = new Musket();
            this.chest = new Sprite(YourGame.AssetManager.LoadTexture("chest"));
            this.AddChild(chest);
            chest.GlobalPosition = new Vector2(40, 200);
            chestBox = new Rectangle(40, 200, 30, 30);
            musket.GlobalPosition = new Vector2(100, 100);
            musket2.GlobalPosition = new Vector2(200, 100);
            musket3.GlobalPosition = new Vector2(100, 200);
            AddChild(musket);
            AddChild(musket2);
            AddChild(musket3);
            MusketBox = new Rectangle(100, 100, 10, 10);
            MusketBox2 = new Rectangle(200, 100, 10, 10);
            MusketBox3 = new Rectangle(100, 200, 10, 10);*/



            this.Velocity = 64;
            dashTimer = 0;


            //soundeffects
           /* swoosh = YourGame.AssetManager.LoadSoundEffect("mixkit-sword-blade-attack-in-medieval-battle-2762");
            playerSoundEffectInstance = swoosh.CreateInstance();
            wind = YourGame.AssetManager.LoadSoundEffect("mixkit-short-wind-swoosh-1461");
            playerSoundEffectInstance1 = wind.CreateInstance();
            activate = YourGame.AssetManager.LoadSoundEffect("radio-103737");
            playerSoundEffectInstance2 = activate.CreateInstance();*/
            Healt = maxHealth;

          
        }

        protected override void UpdateSelf(GameTime gameTime)
        {
            Camera.Update(playerPos, YourGame.ScreenSize.ToVector2());
           /* if(playerBox.Intersects(MusketBox))
            { 
                if (!holding1)
                {
                    PickUp1();
                }
            }
            if (playerBox.Intersects(MusketBox2))
            {
                    if (!holding2)
                    {
                    PickUp2();
                }
            }
            if (playerBox.Intersects(MusketBox3))
            {  
                    if (!holding3)
                    {
                    PickUp3();
                }
            }

            if (playerBox.Intersects(musketBox))
            {
                if (!holding4)
                {
                    PickUp4();
                }
            }

            if (openC)
            {
                NewMusket();
            }*/

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

            if (!collisonN)
            {
                if (YourGame.InputManager.CheckIsKeyPressed(Keys.W))
                {
                    posY = posY - 1;
                    playerBox.Y = posY;
                }
            }
            if (!collisonW)
            {
                if (YourGame.InputManager.CheckIsKeyPressed(Keys.A))
                {
                    if (!isFlipped)
                    {
                        player.SpriteEffects = SpriteEffects.FlipHorizontally;
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
                    posY = posY + 1;
                    playerBox.Y = posY;
                }
            }
            if (!collisonE)
            {
                if (YourGame.InputManager.CheckIsKeyPressed(Keys.D))
                {
                    if (isFlipped)
                    {
                        player.SpriteEffects = SpriteEffects.None;
                        isFlipped = false;
                    }

                    posX = posX + 1;
                    playerBox.X = posX;
                }
            }


            playerPos = new Vector2(posX, posY);
            player.GlobalPosition = playerPos;

            collisonN = false;
            collisonE = false;
            collisonS = false;
            collisonW = false;

            if (YourGame.InputManager.CheckIsKeyPressed(Keys.Q))
            {
                Drop();
            }

            /*if (playerBox.Intersects(chestBox))
            {
                if (YourGame.InputManager.CheckIsKeyPressed(Keys.E))
                {
                    openC = true;
                    if (openC)
                    {
                        //this.RemoveChild(chest);
                        this.openChest = new Sprite(YourGame.AssetManager.LoadTexture("chestopened"));
                        this.AddChild(openChest);
                        openChest.GlobalPosition = new Vector2(40, 200);
                        //openC = false;

                    }
                }
            }*/

            if (YourGame.InputManager.HasMouseJustLeftClicked && !timeOut2 && boost)
            {
                if (timeOut2 == false)
                {
                    //swoosh.Play();
                    timeOutTimer2 = timeOutTimerDuration;
                    timeOut2 = true;
                    shots--;
                }
            }
            else if (YourGame.InputManager.HasMouseJustLeftClicked && !timeOut2 && !reload)
            {
                if (timeOut2 == false)
                {
                    //swoosh.Play();
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
                if (timeOutG == false)
                {
                    timeOutG = true;
                    timeOutGT = 3.0f;
                    if (ClassMenu.melee)
                    {
                        //activate.Play();

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
                    if (ClassMenu.range)
                    {
                       // activate.Play();

                        boost = true;
                    }
                    if (ClassMenu.aoe)
                    {
                        //activate.Play();

                        Bomb();
                    }
                }



            }
            if (timeOutGT > 0)
            {
                timeOutGT -= (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
            else
            {
                timeOutG = false;
                timeOutGT = 0;
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
            if (bombGo)
            {
                expl.GlobalPosition += new Vector2(2, 0);
            }
            if (bombTime < 0.4 && bombTime > 0.3)
            {
                expl.GlobalPosition -= new Vector2(0,
                    1);
            }
            if (bombTime < 0.2f && bombTime > 0)
            {
                expl.GlobalPosition += new Vector2(0, 1);

            }
            if (bombTime > 0)
            {
                bombTime -= (float)gameTime.ElapsedGameTime.TotalSeconds;

            }
            else
            {
                bombGo = false;
                bombTime = 0;
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
               // wind.Play();
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


        }

        public void Bomb()
        {
            expl = new Sprite(YourGame.AssetManager.LoadTexture("exploxion2"));
            bombTime = 0.4f;

            s = player.GlobalPosition;
            expl.GlobalPosition = new Vector2(s.X, s.Y - 20);
            AddChild(expl);
            bombGo = true;

        }

        public void DoDamage(int damage)
        {
            Healt -= damage;
        }
        public void PickUp1(Weapons weapon)
        {
            holding1 = true;
            if (slot1.empty && !holding12 && !holding13)
            {
                weapon.GlobalPosition = slot1.slot1Pos;
                slot1.empty = false;
                holding11 = true;
                
            }
            else if (slot1.empty == false && slot2.empty && !holding11 && !holding13)
            {
                weapon.GlobalPosition = slot2.slot2Pos;
                slot2.empty = false;
                holding21 = true;
            }
            else if (slot1.empty == false && slot2.empty == false && slot3.empty && !holding11 && !holding12)
            {
                weapon.GlobalPosition = slot3.slot3Pos;
                slot3.empty = false;
                holding31 = true;
            }
        }
        public void PickUp2()
        {
            holding2 = true;
            if (slot1.empty && !holding22 && !holding23)
            {
                musket2.GlobalPosition = slot1.slot1Pos;
                slot1.empty = false;
                holding12 = true;
            }
            else if (slot1.empty == false && slot2.empty && !holding21 && !holding23)
            {
                musket2.GlobalPosition = slot2.slot2Pos;
                slot2.empty = false;
                holding22 = true;
            }
            else if (slot1.empty == false && slot2.empty == false && slot3.empty && !holding21 && !holding22)
            {
                musket2.GlobalPosition = slot3.slot3Pos;
                slot3.empty = false;
                holding23 = true;
            }
        }
        public void PickUp3()
        {
            holding3 = true;
            if (slot1.empty && !holding32 && !holding33)
            {
                musket3.GlobalPosition = slot1.slot1Pos;
                slot1.empty = false;
                holding13 = true;
            }
            else if (slot1.empty == false && slot2.empty && !holding31 && !holding33)
            {
                musket3.GlobalPosition = slot2.slot2Pos;
                slot2.empty = false;
                holding23 = true;
            }
            else if (slot1.empty == false && slot2.empty == false && slot3.empty && !holding31 && !holding32)
            {
                musket3.GlobalPosition = slot3.slot3Pos;
                slot3.empty = false;
                holding33 = true;
            }
        }

        public void PickUp4()
        {
            if (slot1.empty)
            {
                musket4.GlobalPosition = slot1.slot1Pos;
                slot1.empty = false;
            }
        }

        public void Drop()
        {
            if (YourGame.InputManager.CheckIsKeyPressed(Keys.D1))
            {
                holdingpos = player.GlobalPosition;

                if (holding11 && slot1.empty == false)
                {
                    musket.GlobalPosition = player.GlobalPosition;
                    slot1.empty = true;
                    MusketBox = new Rectangle((int)holdingpos.X, (int)holdingpos.Y, 10, 10);
                    holding11 = false;

                }
                else if (holding12 && slot1.empty == false)
                {
                    musket2.GlobalPosition = player.GlobalPosition;
                    slot2.empty = true;
                    MusketBox = new Rectangle((int)holdingpos.X, (int)holdingpos.Y, 10, 10);
                    holding12 = false;
                }
                else if (holding13 && slot1.empty == false)
                {
                    musket3.GlobalPosition = player.GlobalPosition;
                    slot3.empty = true;
                    MusketBox = new Rectangle((int)holdingpos.X, (int)holdingpos.Y, 10, 10);
                    holding13 = false;
                }
                
                
            }

            if (YourGame.InputManager.CheckIsKeyPressed(Keys.D2))
            {
            if (holding21 && slot2.empty == false)
            {
                musket.GlobalPosition = player.GlobalPosition;
                slot1.empty = true;
                MusketBox2 = new Rectangle((int)holdingpos.X, (int)holdingpos.Y, 10, 10);
                holding21 = false;

            }
            else if (holding22 && slot2.empty == false)
            {
                musket2.GlobalPosition = player.GlobalPosition;
                slot2.empty = true;
                MusketBox2 = new Rectangle((int)holdingpos.X, (int)holdingpos.Y, 10, 10);
                holding22 = false;
            }
            else if (holding23 && slot2.empty == false)
            {
                musket3.GlobalPosition = player.GlobalPosition;
                slot3.empty = true;
                MusketBox2 = new Rectangle((int)holdingpos.X, (int)holdingpos.Y, 10, 10);
                holding23 = false;
            }
            }
            if (YourGame.InputManager.CheckIsKeyPressed(Keys.D3))
            {
                 if (holding31 && slot3.empty == false)
                {
                    musket.GlobalPosition = player.GlobalPosition;
                    slot1.empty = true;
                    MusketBox3 = new Rectangle((int)holdingpos.X, (int)holdingpos.Y, 10, 10);
                    holding31 = false;

                }
                else if (holding32 && slot3.empty == false)
                {
                    musket2.GlobalPosition = player.GlobalPosition;
                    slot2.empty = true;
                    MusketBox3 = new Rectangle((int)holdingpos.X, (int)holdingpos.Y, 10, 10);
                    holding32 = false;
                }
                else if (holding33 && slot3.empty == false)
                {
                    musket3.GlobalPosition = player.GlobalPosition;
                    slot3.empty = true;
                    MusketBox3 = new Rectangle((int)holdingpos.X, (int)holdingpos.Y, 10, 10);
                    holding33 = false;
                }
            }





        }

    }

}


