using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using YourGame.Objects;

namespace YourGame.States
{
    internal class MultiplayerLevel : Level
    {
        const int maxRooms = 5;
        public int roomCounter = 0, roomsX = 0, roomsY = 0;
        public Room room;
        public bool north = false, east = false, south = false, west = false, loreRoom = true, craftingRoom = true, bossRoom = true;
        public static int[,] level;
        public static int[,] rooms;
        public static List<Enemy> EngagedEnemies = new List<Enemy>();
        public static List<Player2> PlayerList = new List<Player2>();
        public Player2 player, player2;

        public MultiplayerLevel()
        {
            level = new int[101, 101];
            rooms = new int[101, 101];
            for (int i = 0; i < 101; i++)
            {
                for (int j = 0; j < 101; j++)
                {
                    rooms[i, j] = 0;
                }
            }

            GenerateLevel();

            player = new Player2()
            {
                GlobalPosition = Vector2.Zero
            };
            player2 = new Player2()
            {
                GlobalPosition = Vector2.Zero + new Vector2(200, 0)
            };

            PlayerList.Add(player);
            this.AddChild(player);
            player.BaseDrawLayer = 1;
            player.posX = 50; player.posY = 50;
        }

        public void GenerateLevel()
        {
            for (int i = 0; i < 101; i++)
            {
                for (int j = 0; j < 101; j++)
                {
                    rooms[j, i] = level[j, i];
                }
            }

            if (roomCounter == 0)
            {
                room = new Room(this);
                this.AddChild(room);
                roomCounter++;
            }
            if (roomCounter < maxRooms)
            {
                for (int y = 0; y < 101; y++)
                {
                    for (int x = 0; x < 101; x++)
                    {

                        if (roomCounter < maxRooms)
                        {
                            switch (level[x, y])
                            {
                                case 0:
                                    break;
                                case 1:
                                    north = true;
                                    break;
                                case 2:
                                    east = true;
                                    break;
                                case 3:
                                    south = true;
                                    break;
                                case 4:
                                    west = true;
                                    break;
                                case 5:
                                    north = true;
                                    east = true;
                                    break;
                                case 6:
                                    north = true;
                                    south = true;
                                    break;
                                case 7:
                                    north = true;
                                    west = true;
                                    break;
                                case 8:
                                    east = true;
                                    south = true;
                                    break;
                                case 9:
                                    east = true;
                                    west = true;
                                    break;
                                case 10:
                                    south = true;
                                    west = true;
                                    break;
                                case 11:
                                    north = true;
                                    east = true;
                                    south = true;
                                    break;
                                case 12:
                                    north = true;
                                    east = true;
                                    west = true;
                                    break;
                                case 13:
                                    north = true;
                                    south = true;
                                    west = true;
                                    break;
                                case 14:
                                    east = true;
                                    south = true;
                                    west = true;
                                    break;
                            }

                            if (level[x, y] > 0)
                            {
                                level[x, y] = 0;
                                roomsX = x; roomsY = y;
                                room = new Room(this);
                                this.AddChild(room);
                                room.BaseDrawLayer = 0;
                                GenerateLevel();
                            }
                        }
                    }
                }
            }
        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            if (YourGame.InputManager.CheckIsKeyJustPressed(Keys.Escape))
            {
                PauzeMenu p = new PauzeMenu(this)
                {
                    GlobalPosition = player.GlobalPosition,
                };
                this.AddChild(p);
                //this.NextState = new PauzeMenu(this);
            }

            if (YourGame.InputManager.CheckIsKeyJustPressed(Keys.U))
            {
                this.NextState = new Tutorial();
                player.posX = 100 * 256 + 50; player.posY = 100 * 256 + 50;

            }
        }
    }
}

