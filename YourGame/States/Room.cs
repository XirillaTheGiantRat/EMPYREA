using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourEngine;
using YourGame.Objects;

namespace YourGame.States
{
    internal class Room : GameObject
    {
        const int maxRooms = 5;
        private int random;
        Sprite drawer, chest, openChest, roomElevator, room1, room2, room3, room4, room5, room6, room7, room8, room9, room10, room11, room12, room13, room14, room15, hallway1, hallway2, hallway3, hallway4, hallway5, hallway6, hallway7, hallway8, hallway9, hallway10, hallway11, hallway12, hallway13, hallway14, hallway15;
        Level level;
        int northX, northY, eastX, eastY, southX, southY, westX, westY;
        public static Rectangle drawerBox, chestBox, startroom1Box, startroom2Box, startroom3Box, startroom4Box, startroom5Box, startroom6Box, startroom7Box;
        public bool openC = true;

        public Room(Level level)
        {
            this.level = level;

            northX = level.roomsX;
            northY = level.roomsY;
            eastX = level.roomsX;
            eastY = level.roomsY;
            southX = level.roomsX;
            southY = level.roomsY;
            westX = level.roomsX;
            westY = level.roomsY;


            if (level.roomCounter == 0)
                MakeStartRoom();
            else
            {
                random = YourGame.Random.Next(3);

                switch (random)
                {
                    case 0:
                        MakeHallway();
                        break;
                    case 1:
                        MakeHallway();
                        break;
                    case 2:
                        MakeRooms();
                        break;
                    case 3:
                        if(level.loreRoom)
                        {
                            MakeLoreRoom();
                            level.loreRoom = false;
                        }
                        else MakeHallway();
                        break;
                    case 4:
                        if (level.craftingRoom)
                        {
                            MakeCraftingRoom();
                            level.craftingRoom = false;
                        }
                        else MakeHallway();
                        break;
                    case 5:
                        if (level.bossRoom)
                        {
                            MakeBossRoom();
                            level.bossRoom = false;
                        }
                        else MakeRooms();
                        break;
                }
            }
        }

        public void MakeStartRoom()
        {
            this.GlobalPosition = new Vector2(0, 0);
            Level.level[50, 50] = 14;
            this.roomElevator = new Sprite(YourGame.AssetManager.LoadTexture("roomelevator"));
            this.AddChild(roomElevator);
            
            
            startroom1Box = new Rectangle(0, 0, 256, 60);
            startroom2Box = new Rectangle(0, 60, 5, 46);
            startroom3Box = new Rectangle(251, 60, 5, 46);
            startroom4Box = new Rectangle(0, 150, 5, 106);
            startroom5Box = new Rectangle(251, 150, 5, 106);
            startroom6Box = new Rectangle(0, 251, 106, 5);
            startroom7Box = new Rectangle(150, 251, 106, 5);
            //this.drawer = new Sprite(YourGame.AssetManager.LoadTexture("drawer2"));
            //this.AddChild(drawer);
            //drawer.GlobalPosition = new Vector2(140,140);
            //drawerBox = new Rectangle(140,140,30,30);
            //this.chest = new Sprite(YourGame.AssetManager.LoadTexture("chest"));
            //this.AddChild(chest);
            //chest.GlobalPosition = new Vector2(40,200);
            //chestBox = new Rectangle(40, 200, 30, 30);
        }

        public void MakeRooms()
        {
            if(level.north)
            {
                level.north = false;

                if(Level.rooms[northX, northY - 1] == 0)
                {
                    if (level.roomCounter < maxRooms)
                    {
                        level.roomCounter++;

                        if (Level.rooms[northX, northY - 2] != 0)
                        {
                            if (Level.rooms[northX - 1, northY - 1] != 0)
                            {
                                if (Level.rooms[northX + 1, northY - 1] != 0)
                                {
                                    this.room11 = new Sprite(YourGame.AssetManager.LoadTexture("room11"));
                                    this.AddChild(room11);
                                    room11.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                }
                                else
                                {
                                    random = YourGame.Random.Next(2);

                                    if (random == 0)
                                    {
                                        this.room6 = new Sprite(YourGame.AssetManager.LoadTexture("room6"));
                                        this.AddChild(room6);
                                        Level.level[northX, northY - 1] = 2;
                                        room6.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                    }
                                    else
                                    {
                                        this.room11 = new Sprite(YourGame.AssetManager.LoadTexture("room11"));
                                        this.AddChild(room11);
                                        room11.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                    }
                                }
                            }
                            else if (Level.rooms[northX + 1, northY - 1] != 0)
                            {
                                random = YourGame.Random.Next(2);

                                if (random == 0)
                                {
                                    this.room5 = new Sprite(YourGame.AssetManager.LoadTexture("room5"));
                                    this.AddChild(room5);
                                    Level.level[northX, northY - 1] = 4;
                                    room5.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                }
                                else
                                {
                                    this.room11 = new Sprite(YourGame.AssetManager.LoadTexture("room11"));
                                    this.AddChild(room11);
                                    room11.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                }
                            }
                            else
                            {
                                random = YourGame.Random.Next(4);

                                if (random == 0)
                                {
                                    this.room5 = new Sprite(YourGame.AssetManager.LoadTexture("room5"));
                                    this.AddChild(room5);
                                    Level.level[northX, northY - 1] = 4;
                                    room5.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                }
                                if (random == 1)
                                {
                                    this.room6 = new Sprite(YourGame.AssetManager.LoadTexture("room6"));
                                    this.AddChild(room6);
                                    Level.level[northX, northY - 1] = 2;
                                    room6.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                }
                                if (random == 2)
                                {
                                    this.room9 = new Sprite(YourGame.AssetManager.LoadTexture("room9"));
                                    this.AddChild(room9);
                                    Level.level[northX, northY - 1] = 9;
                                    room9.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                }
                                if (random == 3)
                                {
                                    this.room11 = new Sprite(YourGame.AssetManager.LoadTexture("room11"));
                                    this.AddChild(room11);
                                    room11.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                }
                            }
                        }
                        else if (Level.rooms[northX - 1, northY - 1] != 0)
                        {
                            if (Level.rooms[northX + 1, northY - 1] != 0)
                            {
                                random = YourGame.Random.Next(2);

                                if (random == 0)
                                {
                                    this.room2 = new Sprite(YourGame.AssetManager.LoadTexture("room2"));
                                    this.AddChild(room2);
                                    Level.level[northX, northY - 1] = 1;
                                    room2.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                }
                                else
                                {
                                    this.room11 = new Sprite(YourGame.AssetManager.LoadTexture("room11"));
                                    this.AddChild(room11);
                                    room11.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                }
                            }
                            else
                            {
                                
                                random = YourGame.Random.Next(4);

                                if (random == 0)
                                {
                                    this.room2 = new Sprite(YourGame.AssetManager.LoadTexture("room2"));
                                    this.AddChild(room2);
                                    Level.level[northX, northY - 1] = 1;
                                    room2.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                }
                                if (random == 1)
                                {
                                    this.room6 = new Sprite(YourGame.AssetManager.LoadTexture("room6"));
                                    this.AddChild(room6);
                                    Level.level[northX, northY - 1] = 2;
                                    room6.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                }
                                if (random == 2)
                                {
                                    this.room10 = new Sprite(YourGame.AssetManager.LoadTexture("room10"));
                                    this.AddChild(room10);
                                    Level.level[northX, northY - 1] = 5;
                                    room10.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                }
                                if (random == 3)
                                {
                                    this.room11 = new Sprite(YourGame.AssetManager.LoadTexture("room11"));
                                    this.AddChild(room11);
                                    room11.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                }
                                
                            }
                        }
                        else if (Level.rooms[northX + 1, northY - 1] != 0)
                        {
                            random = YourGame.Random.Next(4);

                            if (random == 0)
                            {
                                this.room2 = new Sprite(YourGame.AssetManager.LoadTexture("room2"));
                                this.AddChild(room2);
                                Level.level[northX, northY - 1] = 1;
                                room2.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                            }
                            if (random == 1)
                            {
                                this.room5 = new Sprite(YourGame.AssetManager.LoadTexture("room5"));
                                this.AddChild(room5);
                                Level.level[northX, northY - 1] = 4;
                                room5.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                            }
                            if (random == 2)
                            {
                                this.room8 = new Sprite(YourGame.AssetManager.LoadTexture("room8"));
                                this.AddChild(room8);
                                Level.level[northX, northY - 1] = 7;
                                room8.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                            }
                            if (random == 3)
                            {
                                this.room11 = new Sprite(YourGame.AssetManager.LoadTexture("room11"));
                                this.AddChild(room11);
                                room11.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                            }
                        }
                        else
                        {
                            random = YourGame.Random.Next(8);

                            switch (random)
                            {
                            case 0:
                                this.room2 = new Sprite(YourGame.AssetManager.LoadTexture("room2"));
                                this.AddChild(room2);
                                Level.level[northX, northY - 1] = 1;
                                room2.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                break;
                            case 1:
                                this.room5 = new Sprite(YourGame.AssetManager.LoadTexture("room5"));
                                this.AddChild(room5);
                                Level.level[northX, northY - 1] = 4;
                                room5.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                break;
                            case 2:
                                this.room6 = new Sprite(YourGame.AssetManager.LoadTexture("room6"));
                                this.AddChild(room6);
                                Level.level[northX, northY - 1] = 2;
                                room6.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                break;
                            case 3:
                                this.room8 = new Sprite(YourGame.AssetManager.LoadTexture("room8"));
                                this.AddChild(room8);
                                Level.level[northX, northY - 1] = 7;
                                room8.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                break;
                            case 4:
                                this.room9 = new Sprite(YourGame.AssetManager.LoadTexture("room9"));
                                this.AddChild(room9);
                                Level.level[northX, northY - 1] = 9;
                                room9.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                break;
                            case 5:
                                this.room10 = new Sprite(YourGame.AssetManager.LoadTexture("room10"));
                                this.AddChild(room10);
                                Level.level[northX, northY - 1] = 5;
                                room10.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                break;
                            case 6:
                                this.room11 = new Sprite(YourGame.AssetManager.LoadTexture("room11"));
                                this.AddChild(room11);
                                room11.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                break;
                            case 7:
                                this.room15 = new Sprite(YourGame.AssetManager.LoadTexture("room15"));
                                this.AddChild(room15);
                                Level.level[northX, northY - 1] = 12;
                                room15.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                break;
                            }
                        }
                    }
                }
            }

            if (level.east)
            {
                level.east = false;
                if(Level.rooms[eastX + 1, eastY] == 0)
                {
                    if (level.roomCounter < maxRooms)
                    {
                        level.roomCounter++;

                        if (Level.rooms[eastX + 1, eastY - 1] != 0)
                        {
                            if (Level.rooms[eastX + 2, eastY] != 0)
                            {
                                if (Level.rooms[eastX + 1, eastY + 1] != 0)
                                {
                                    this.room14 = new Sprite(YourGame.AssetManager.LoadTexture("room14"));
                                    this.AddChild(room14);
                                    room14.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                }
                                else
                                {
                                    random = YourGame.Random.Next(2);

                                    if (random == 0)
                                    {
                                        this.room5 = new Sprite(YourGame.AssetManager.LoadTexture("room5"));
                                        this.AddChild(room5);
                                        Level.level[eastX + 1, eastY] = 3;
                                        room5.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                    }
                                    else
                                    {
                                        this.room14 = new Sprite(YourGame.AssetManager.LoadTexture("room14"));
                                        this.AddChild(room14);
                                        room14.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                    }
                                }
                            }
                            else if (Level.rooms[eastX + 1, eastY + 1] != 0)
                            {
                                random = YourGame.Random.Next(2);

                                if (random == 0)
                                {
                                    this.room1 = new Sprite(YourGame.AssetManager.LoadTexture("room1"));
                                    this.AddChild(room1);
                                    Level.level[eastX + 1, eastY] = 2;
                                    room1.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                }
                                else
                                {
                                    this.room14 = new Sprite(YourGame.AssetManager.LoadTexture("room14"));
                                    this.AddChild(room14);
                                    room14.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                }
                            }
                            else
                            {
                                random = YourGame.Random.Next(4);

                                if (random == 0)
                                {
                                    this.room1 = new Sprite(YourGame.AssetManager.LoadTexture("room1"));
                                    this.AddChild(room1);
                                    Level.level[eastX + 1, eastY] = 2;
                                    room1.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                }
                                if (random == 1)
                                {
                                    this.room5 = new Sprite(YourGame.AssetManager.LoadTexture("room5"));
                                    this.AddChild(room5);
                                    Level.level[eastX + 1, eastY] = 3;
                                    room5.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                }
                                if (random == 2)
                                {
                                    this.room9 = new Sprite(YourGame.AssetManager.LoadTexture("room9"));
                                    this.AddChild(room9);
                                    Level.level[eastX + 1, eastY] = 8;
                                    room9.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                }
                                if (random == 3)
                                {
                                    this.room14 = new Sprite(YourGame.AssetManager.LoadTexture("room14"));
                                    this.AddChild(room14);
                                    room14.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                }
                            }
                        }
                        else if (Level.rooms[eastX + 2, eastY] != 0)
                        {
                            if (Level.rooms[eastX + 1, eastY + 1] != 0)
                            {
                                random = YourGame.Random.Next(2);

                                if (random == 0)
                                {
                                    this.room4 = new Sprite(YourGame.AssetManager.LoadTexture("room4"));
                                    this.AddChild(room4);
                                    Level.level[eastX + 1, eastY] = 1;
                                    room4.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                }
                                else
                                {
                                    this.room14 = new Sprite(YourGame.AssetManager.LoadTexture("room14"));
                                    this.AddChild(room14);
                                    room14.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                }
                            }
                            else
                            {
                                random = YourGame.Random.Next(4);

                                if (random == 0)
                                {
                                    this.room4 = new Sprite(YourGame.AssetManager.LoadTexture("room4"));
                                    this.AddChild(room4);
                                    Level.level[eastX + 1, eastY] = 1;
                                    room4.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                }
                                if (random == 1)
                                {
                                    this.room5 = new Sprite(YourGame.AssetManager.LoadTexture("room5"));
                                    this.AddChild(room5);
                                    Level.level[eastX + 1, eastY] = 3;
                                    room5.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                }
                                if (random == 2)
                                {
                                    this.room8 = new Sprite(YourGame.AssetManager.LoadTexture("room8"));
                                    this.AddChild(room8);
                                    Level.level[eastX + 1, eastY] = 6;
                                    room8.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                }
                                if (random == 3)
                                {
                                    this.room14 = new Sprite(YourGame.AssetManager.LoadTexture("room14"));
                                    this.AddChild(room14);
                                    room14.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                }
                            }
                        }
                        else if (Level.rooms[eastX + 1, eastY - 1] != 0)
                        {
                            random = YourGame.Random.Next(4);

                            if (random == 0)
                            {
                                this.room1 = new Sprite(YourGame.AssetManager.LoadTexture("room1"));
                                this.AddChild(room1);
                                Level.level[eastX + 1, eastY] = 2;
                                room1.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                            }
                            if (random == 1)
                            {
                                this.room4 = new Sprite(YourGame.AssetManager.LoadTexture("room4"));
                                this.AddChild(room4);
                                Level.level[eastX + 1, eastY] = 1;
                                room4.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                            }
                            if (random == 2)
                            {
                                this.room7 = new Sprite(YourGame.AssetManager.LoadTexture("room7"));
                                this.AddChild(room7);
                                Level.level[eastX + 1, eastY] = 5;
                                room7.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                            }
                            if (random == 3)
                            {
                                this.room14 = new Sprite(YourGame.AssetManager.LoadTexture("room14"));
                                this.AddChild(room14);
                                room14.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                            }
                        }
                        else
                        {
                            random = YourGame.Random.Next(8);

                            switch (random)
                            {
                                case 0:
                                    this.room1 = new Sprite(YourGame.AssetManager.LoadTexture("room1"));
                                    this.AddChild(room1);
                                    Level.level[eastX + 1, eastY] = 2;
                                    room1.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                    break;
                                case 1:
                                    this.room4 = new Sprite(YourGame.AssetManager.LoadTexture("room4"));
                                    this.AddChild(room4);
                                    Level.level[eastX + 1, eastY] = 1;
                                    room4.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                    break;
                                case 2:
                                    this.room5 = new Sprite(YourGame.AssetManager.LoadTexture("room5"));
                                    this.AddChild(room5);
                                    Level.level[eastX + 1, eastY] = 3;
                                    room5.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                    break;
                                case 3:
                                    this.room7 = new Sprite(YourGame.AssetManager.LoadTexture("room7"));
                                    this.AddChild(room7);
                                    Level.level[eastX + 1, eastY] = 5;
                                    room7.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                    break;
                                case 4:
                                    this.room8 = new Sprite(YourGame.AssetManager.LoadTexture("room8"));
                                    this.AddChild(room8);
                                    Level.level[eastX + 1, eastY] = 6;
                                    room8.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                    break;
                                case 5:
                                    this.room9 = new Sprite(YourGame.AssetManager.LoadTexture("room9"));
                                    this.AddChild(room9);
                                    Level.level[eastX + 1, eastY] = 8;
                                    room9.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                    break;
                                case 6:
                                    this.room14 = new Sprite(YourGame.AssetManager.LoadTexture("room14"));
                                    this.AddChild(room14);
                                    room14.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                    break;
                                case 7:
                                    this.room15 = new Sprite(YourGame.AssetManager.LoadTexture("room15"));
                                    this.AddChild(room15);
                                    Level.level[eastX + 1, eastY] = 11;
                                    room15.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                    break;
                            }
                        }
                    }
                }
            }

            if (level.south)
            {
                level.south = false;
                if (Level.rooms[southX, southY + 1] == 0)
                {
                    if (level.roomCounter < maxRooms)
                    {
                        level.roomCounter++;

                        if (Level.rooms[southX + 1, southY + 1] != 0)
                        {
                            if (Level.rooms[southX, southY + 2] != 0)
                            {
                                if (Level.rooms[southX - 1, southY + 1] != 0)
                                {
                                    this.room13 = new Sprite(YourGame.AssetManager.LoadTexture("room13"));
                                    this.AddChild(room13);
                                    room13.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                }
                                else
                                {
                                    random = YourGame.Random.Next(2);

                                    if (random == 0)
                                    {
                                        this.room4 = new Sprite(YourGame.AssetManager.LoadTexture("room4"));
                                        this.AddChild(room4);
                                        Level.level[southX, southY + 1] = 4;
                                        room4.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                    }
                                    else
                                    {
                                        this.room13 = new Sprite(YourGame.AssetManager.LoadTexture("room13"));
                                        this.AddChild(room13);
                                        room13.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                    }
                                }
                            }
                            else if (Level.rooms[southX - 1, southY + 1] != 0)
                            {
                                random = YourGame.Random.Next(2);

                                if (random == 0)
                                {
                                    this.room2 = new Sprite(YourGame.AssetManager.LoadTexture("room2"));
                                    this.AddChild(room2);
                                    Level.level[southX, southY + 1] = 3;
                                    room2.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                }
                                else
                                {
                                    this.room13 = new Sprite(YourGame.AssetManager.LoadTexture("room13"));
                                    this.AddChild(room13);
                                    room13.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                }
                            }
                            else
                            {
                                random = YourGame.Random.Next(4);

                                if (random == 0)
                                {
                                    this.room2 = new Sprite(YourGame.AssetManager.LoadTexture("room2"));
                                    this.AddChild(room2);
                                    Level.level[southX, southY + 1] = 3;
                                    room2.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                }
                                if (random == 1)
                                {
                                    this.room4 = new Sprite(YourGame.AssetManager.LoadTexture("room4"));
                                    this.AddChild(room4);
                                    Level.level[southX, southY + 1] = 4;
                                    room4.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                }
                                if (random == 2)
                                {
                                    this.room8 = new Sprite(YourGame.AssetManager.LoadTexture("room8"));
                                    this.AddChild(room8);
                                    Level.level[southX, southY + 1] = 10;
                                    room8.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                }
                                if (random == 3)
                                {
                                    this.room13 = new Sprite(YourGame.AssetManager.LoadTexture("room13"));
                                    this.AddChild(room13);
                                    room13.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                }
                            }
                        }
                        else if (Level.rooms[southX, southY + 2] != 0)
                        {
                            if (Level.rooms[southX - 1, southY + 1] != 0)
                            {
                                random = YourGame.Random.Next(2);

                                if (random == 0)
                                {
                                    this.room3 = new Sprite(YourGame.AssetManager.LoadTexture("room3"));
                                    this.AddChild(room3);
                                    Level.level[southX, southY + 1] = 2;
                                    room3.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                }
                                else
                                {
                                    this.room13 = new Sprite(YourGame.AssetManager.LoadTexture("room13"));
                                    this.AddChild(room13);
                                    room13.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                }
                            }
                            else
                            {
                                random = YourGame.Random.Next(4);

                                if (random == 0)
                                {
                                    this.room3 = new Sprite(YourGame.AssetManager.LoadTexture("room3"));
                                    this.AddChild(room3);
                                    Level.level[southX, southY + 1] = 2;
                                    room3.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                }
                                if (random == 1)
                                {
                                    this.room4 = new Sprite(YourGame.AssetManager.LoadTexture("room4"));
                                    this.AddChild(room4);
                                    Level.level[southX, southY + 1] = 4;
                                    room4.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                }
                                if (random == 2)
                                {
                                    this.room7 = new Sprite(YourGame.AssetManager.LoadTexture("room7"));
                                    this.AddChild(room7);
                                    Level.level[southX, southY + 1] = 9;
                                    room7.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                }
                                if (random == 3)
                                {
                                    this.room13 = new Sprite(YourGame.AssetManager.LoadTexture("room13"));
                                    this.AddChild(room13);
                                    room13.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                }
                            }
                        }
                        else if (Level.rooms[southX - 1, southY + 1] != 0)
                        {
                            random = YourGame.Random.Next(4);

                            if (random == 0)
                            {
                                this.room2 = new Sprite(YourGame.AssetManager.LoadTexture("room2"));
                                this.AddChild(room2);
                                Level.level[southX, southY + 1] = 3;
                                room2.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                            }
                            if (random == 1)
                            {
                                this.room3 = new Sprite(YourGame.AssetManager.LoadTexture("room3"));
                                this.AddChild(room3);
                                Level.level[southX, southY + 1] = 2;
                                room3.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                            }
                            if (random == 2)
                            {
                                this.room10 = new Sprite(YourGame.AssetManager.LoadTexture("room10"));
                                this.AddChild(room10);
                                Level.level[southX, southY + 1] = 8;
                                room10.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                            }
                            if (random == 3)
                            {
                                this.room13 = new Sprite(YourGame.AssetManager.LoadTexture("room13"));
                                this.AddChild(room13);
                                room13.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                            }
                        }
                        else
                        {
                            random = YourGame.Random.Next(8);

                            switch (random)
                            {
                                case 0:
                                    this.room2 = new Sprite(YourGame.AssetManager.LoadTexture("room2"));
                                    this.AddChild(room2);
                                    Level.level[southX, southY + 1] = 3;
                                    room2.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                    break;
                                case 1:
                                    this.room3 = new Sprite(YourGame.AssetManager.LoadTexture("room3"));
                                    this.AddChild(room3);
                                    Level.level[southX, southY + 1] = 2;
                                    room3.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                    break;
                                case 2:
                                    this.room4 = new Sprite(YourGame.AssetManager.LoadTexture("room4"));
                                    this.AddChild(room4);
                                    Level.level[southX, southY + 1] = 4;
                                    room4.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                    break;
                                case 3:
                                    this.room7 = new Sprite(YourGame.AssetManager.LoadTexture("room7"));
                                    this.AddChild(room7);
                                    Level.level[southX, southY + 1] = 9;
                                    room7.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                    break;
                                case 4:
                                    this.room8 = new Sprite(YourGame.AssetManager.LoadTexture("room8"));
                                    this.AddChild(room8);
                                    Level.level[southX, southY + 1] = 10;
                                    room8.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                    break;
                                case 5:
                                    this.room10 = new Sprite(YourGame.AssetManager.LoadTexture("room10"));
                                    this.AddChild(room10);
                                    Level.level[southX, southY + 1] = 8;
                                    room10.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                    break;
                                case 6:
                                    this.room13 = new Sprite(YourGame.AssetManager.LoadTexture("room13"));
                                    this.AddChild(room13);
                                    room13.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                    break;
                                case 7:
                                    this.room15 = new Sprite(YourGame.AssetManager.LoadTexture("room15"));
                                    this.AddChild(room15);
                                    Level.level[southX, southY + 1] = 14;
                                    room15.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                    break;
                            }
                        }
                    }
                }
            }

            if (level.west)
            {
                level.west = false;
                if (Level.rooms[westX - 1, westY] == 0)
                {
                    if (level.roomCounter < maxRooms)
                    {
                        level.roomCounter++;

                        if (Level.rooms[westX - 1, westY - 1] != 0)
                        {
                            if (Level.rooms[westX - 2, westY] != 0)
                            {
                                if (Level.rooms[westX - 1, westY + 1] != 0)
                                {
                                    this.room12 = new Sprite(YourGame.AssetManager.LoadTexture("room12"));
                                    this.AddChild(room12);
                                    room12.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                }
                                else
                                {
                                    random = YourGame.Random.Next(2);

                                    if (random == 0)
                                    {
                                        this.room6 = new Sprite(YourGame.AssetManager.LoadTexture("room6"));
                                        this.AddChild(room6);
                                        Level.level[westX - 1, westY] = 3;
                                        room6.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                    }
                                    else
                                    {
                                        this.room12 = new Sprite(YourGame.AssetManager.LoadTexture("room12"));
                                        this.AddChild(room12);
                                        room12.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                    }
                                }
                            }
                            else if (Level.rooms[westX - 1, westY + 1] != 0)
                            {
                                random = YourGame.Random.Next(2);

                                if (random == 0)
                                {
                                    this.room1 = new Sprite(YourGame.AssetManager.LoadTexture("room1"));
                                    this.AddChild(room1);
                                    Level.level[westX - 1, westY] = 4;
                                    room1.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                }
                                else
                                {
                                    this.room12 = new Sprite(YourGame.AssetManager.LoadTexture("room12"));
                                    this.AddChild(room12);
                                    room12.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                }
                            }
                            else
                            {
                                random = YourGame.Random.Next(4);

                                if (random == 0)
                                {
                                    this.room1 = new Sprite(YourGame.AssetManager.LoadTexture("room1"));
                                    this.AddChild(room1);
                                    Level.level[westX - 1, westY] = 4;
                                    room1.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                }
                                if (random == 1)
                                {
                                    this.room6 = new Sprite(YourGame.AssetManager.LoadTexture("room6"));
                                    this.AddChild(room6);
                                    Level.level[westX - 1, westY] = 3;
                                    room6.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                }
                                if (random == 2)
                                {
                                    this.room9 = new Sprite(YourGame.AssetManager.LoadTexture("room9"));
                                    this.AddChild(room9);
                                    Level.level[westX - 1, westY] = 10;
                                    room9.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                }
                                if (random == 3)
                                {
                                    this.room12 = new Sprite(YourGame.AssetManager.LoadTexture("room12"));
                                    this.AddChild(room12);
                                    room12.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                }
                            }
                        }
                        else if (Level.rooms[westX - 2, westY] != 0)
                        {
                            if (Level.rooms[westX - 1, westY + 1] != 0)
                            {
                                random = YourGame.Random.Next(2);

                                if (random == 0)
                                {
                                    this.room3 = new Sprite(YourGame.AssetManager.LoadTexture("room3"));
                                    this.AddChild(room3);
                                    Level.level[westX - 1, westY] = 1;
                                    room3.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                }
                                else
                                {
                                    this.room12 = new Sprite(YourGame.AssetManager.LoadTexture("room12"));
                                    this.AddChild(room12);
                                    room12.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                }
                            }
                            else
                            {
                                random = YourGame.Random.Next(4);

                                if (random == 0)
                                {
                                    this.room3 = new Sprite(YourGame.AssetManager.LoadTexture("room3"));
                                    this.AddChild(room3);
                                    Level.level[westX - 1, westY] = 1;
                                    room3.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                }
                                if (random == 1)
                                {
                                    this.room6 = new Sprite(YourGame.AssetManager.LoadTexture("room6"));
                                    this.AddChild(room6);
                                    Level.level[westX - 1, westY] = 3;
                                    room6.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                }
                                if (random == 2)
                                {
                                    this.room10 = new Sprite(YourGame.AssetManager.LoadTexture("room10"));
                                    this.AddChild(room10);
                                    Level.level[westX - 1, westY] = 6;
                                    room10.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                }
                                if (random == 3)
                                {
                                    this.room12 = new Sprite(YourGame.AssetManager.LoadTexture("room12"));
                                    this.AddChild(room12);
                                    room12.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                }
                            }
                        }
                        else if (Level.rooms[westX - 1, westY + 1] != 0)
                        {
                            random = YourGame.Random.Next(4);

                            if (random == 0)
                            {
                                this.room1 = new Sprite(YourGame.AssetManager.LoadTexture("room1"));
                                this.AddChild(room1);
                                Level.level[westX - 1, westY] = 4;
                                room1.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                            }
                            if (random == 1)
                            {
                                this.room3 = new Sprite(YourGame.AssetManager.LoadTexture("room3"));
                                this.AddChild(room3);
                                Level.level[westX - 1, westY] = 1;
                                room3.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                            }
                            if (random == 2)
                            {
                                this.room7 = new Sprite(YourGame.AssetManager.LoadTexture("room7"));
                                this.AddChild(room7);
                                Level.level[westX - 1, westY] = 7;
                                room7.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                            }
                            if (random == 3)
                            {
                                this.room12 = new Sprite(YourGame.AssetManager.LoadTexture("room12"));
                                this.AddChild(room12);
                                room12.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                            }
                        }
                        else
                        {
                            random = YourGame.Random.Next(8);

                            switch (random)
                            {
                                case 0:
                                    this.room1 = new Sprite(YourGame.AssetManager.LoadTexture("room1"));
                                    this.AddChild(room1);
                                    Level.level[westX - 1, westY] = 4;
                                    room1.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                    break;
                                case 1:
                                    this.room3 = new Sprite(YourGame.AssetManager.LoadTexture("room3"));
                                    this.AddChild(room3);
                                    Level.level[westX - 1, westY] = 1;
                                    room3.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                    break;
                                case 2:
                                    this.room6 = new Sprite(YourGame.AssetManager.LoadTexture("room6"));
                                    this.AddChild(room6);
                                    Level.level[westX - 1, westY] = 3;
                                    room6.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                    break;
                                case 3:
                                    this.room7 = new Sprite(YourGame.AssetManager.LoadTexture("room7"));
                                    this.AddChild(room7);
                                    Level.level[westX - 1, westY] = 7;
                                    room7.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                    break;
                                case 4:
                                    this.room9 = new Sprite(YourGame.AssetManager.LoadTexture("room9"));
                                    this.AddChild(room9);
                                    Level.level[westX - 1, westY] = 10;
                                    room9.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                    break;
                                case 5:
                                    this.room10 = new Sprite(YourGame.AssetManager.LoadTexture("room10"));
                                    this.AddChild(room10);
                                    Level.level[westX - 1, westY] = 6;
                                    room10.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                    break;
                                case 6:
                                    this.room12 = new Sprite(YourGame.AssetManager.LoadTexture("room12"));
                                    this.AddChild(room12);
                                    room12.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                    break;
                                case 7:
                                    this.room15 = new Sprite(YourGame.AssetManager.LoadTexture("room15"));
                                    this.AddChild(room15);
                                    Level.level[westX - 1, westY] = 13;
                                    room15.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public void MakeHallway()
        {
            if (level.north)
            {
                level.north = false;
                if(Level.rooms[northX, northY + 1] == 0)
                {
                    if (Level.rooms[northX, northY - 2] != 0)
                    {
                        if (Level.rooms[northX - 1, northY - 1] != 0)
                        {
                            if (Level.rooms[northX + 1, northY - 1] != 0)
                            {
                                this.hallway11 = new Sprite(YourGame.AssetManager.LoadTexture("hallway11"));
                                this.AddChild(hallway11);
                                hallway11.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                            }
                            else
                            {
                                random = YourGame.Random.Next(2);

                                if (random == 0)
                                {
                                    this.hallway6 = new Sprite(YourGame.AssetManager.LoadTexture("hallway6"));
                                    this.AddChild(hallway6);
                                    Level.level[northX, northY - 1] = 2;
                                    hallway6.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                }
                                else
                                {
                                    this.hallway11 = new Sprite(YourGame.AssetManager.LoadTexture("hallway11"));
                                    this.AddChild(hallway11);
                                    hallway11.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                }
                            }
                        }
                        else if (Level.rooms[northX + 1, northY - 1] != 0)
                        {
                            random = YourGame.Random.Next(2);

                            if (random == 0)
                            {
                                this.hallway5 = new Sprite(YourGame.AssetManager.LoadTexture("hallway5"));
                                this.AddChild(hallway5);
                                Level.level[northX, northY - 1] = 4;
                                hallway5.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                            }
                            else
                            {
                                this.hallway11 = new Sprite(YourGame.AssetManager.LoadTexture("hallway11"));
                                this.AddChild(hallway11);
                                hallway11.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                            }
                        }
                        else
                        {
                            random = YourGame.Random.Next(4);

                            if (random == 0)
                            {
                                this.hallway5 = new Sprite(YourGame.AssetManager.LoadTexture("hallway5"));
                                this.AddChild(hallway5);
                                Level.level[northX, northY - 1] = 4;
                                hallway5.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                            }
                            if (random == 1)
                            {
                                this.hallway6 = new Sprite(YourGame.AssetManager.LoadTexture("hallway6"));
                                this.AddChild(hallway6);
                                Level.level[northX, northY - 1] = 2;
                                hallway6.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                            }
                            if (random == 2)
                            {
                                this.hallway9 = new Sprite(YourGame.AssetManager.LoadTexture("hallway9"));
                                this.AddChild(hallway9);
                                Level.level[northX, northY - 1] = 9;
                                hallway9.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                            }
                            if (random == 3)
                            {
                                this.hallway11 = new Sprite(YourGame.AssetManager.LoadTexture("hallway11"));
                                this.AddChild(hallway11);
                                hallway11.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                            }
                        }
                    }
                    else if (Level.rooms[northX - 1, northY - 1] != 0)
                    {
                        if (Level.rooms[northX + 1, northY - 1] != 0)
                        {
                            random = YourGame.Random.Next(2);

                            if (random == 0)
                            {
                                this.hallway2 = new Sprite(YourGame.AssetManager.LoadTexture("hallway2"));
                                this.AddChild(hallway2);
                                Level.level[northX, northY - 1] = 1;
                                hallway2.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                            }
                            else
                            {
                                this.hallway11 = new Sprite(YourGame.AssetManager.LoadTexture("hallway11"));
                                this.AddChild(hallway11);
                                hallway11.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                            }
                        }
                        else
                        {

                            random = YourGame.Random.Next(4);

                            if (random == 0)
                            {
                                this.hallway2 = new Sprite(YourGame.AssetManager.LoadTexture("hallway2"));
                                this.AddChild(hallway2);
                                Level.level[northX, northY - 1] = 1;
                                hallway2.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                            }
                            if (random == 1)
                            {
                                this.hallway6 = new Sprite(YourGame.AssetManager.LoadTexture("hallway6"));
                                this.AddChild(hallway6);
                                Level.level[northX, northY - 1] = 2;
                                hallway6.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                            }
                            if (random == 2)
                            {
                                this.hallway10 = new Sprite(YourGame.AssetManager.LoadTexture("hallway10"));
                                this.AddChild(hallway10);
                                Level.level[northX, northY - 1] = 5;
                                hallway10.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                            }
                            if (random == 3)
                            {
                                this.hallway11 = new Sprite(YourGame.AssetManager.LoadTexture("hallway11"));
                                this.AddChild(hallway11);
                                hallway11.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                            }

                        }
                    }
                    else if (Level.rooms[northX + 1, northY - 1] != 0)
                    {
                        random = YourGame.Random.Next(4);

                        if (random == 0)
                        {
                            this.hallway2 = new Sprite(YourGame.AssetManager.LoadTexture("hallway2"));
                            this.AddChild(hallway2);
                            Level.level[northX, northY - 1] = 1;
                            hallway2.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                        }
                        if (random == 1)
                        {
                            this.hallway5 = new Sprite(YourGame.AssetManager.LoadTexture("hallway5"));
                            this.AddChild(hallway5);
                            Level.level[northX, northY - 1] = 4;
                            hallway5.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                        }
                        if (random == 2)
                        {
                            this.hallway8 = new Sprite(YourGame.AssetManager.LoadTexture("hallway8"));
                            this.AddChild(hallway8);
                            Level.level[northX, northY - 1] = 7;
                            hallway8.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                        }
                        if (random == 3)
                        {
                            this.hallway11 = new Sprite(YourGame.AssetManager.LoadTexture("hallway11"));
                            this.AddChild(hallway11);
                            hallway11.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                        }
                    }
                    else
                    {
                        random = YourGame.Random.Next(8);

                        switch (random)
                        {
                            case 0:
                                this.hallway2 = new Sprite(YourGame.AssetManager.LoadTexture("hallway2"));
                                this.AddChild(hallway2);
                                Level.level[northX, northY - 1] = 1;
                                hallway2.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                break;
                            case 1:
                                this.hallway5 = new Sprite(YourGame.AssetManager.LoadTexture("hallway5"));
                                this.AddChild(hallway5);
                                Level.level[northX, northY - 1] = 4;
                                hallway5.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                break;
                            case 2:
                                this.hallway6 = new Sprite(YourGame.AssetManager.LoadTexture("hallway6"));
                                this.AddChild(hallway6);
                                Level.level[northX, northY - 1] = 2;
                                hallway6.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                break;
                            case 3:
                                this.hallway8 = new Sprite(YourGame.AssetManager.LoadTexture("hallway8"));
                                this.AddChild(hallway8);
                                Level.level[northX, northY - 1] = 7;
                                hallway8.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                break;
                            case 4:
                                this.hallway9 = new Sprite(YourGame.AssetManager.LoadTexture("hallway9"));
                                this.AddChild(hallway9);
                                Level.level[northX, northY - 1] = 9;
                                hallway9.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                break;
                            case 5:
                                this.hallway10 = new Sprite(YourGame.AssetManager.LoadTexture("hallway10"));
                                this.AddChild(hallway10);
                                Level.level[northX, northY - 1] = 5;
                                hallway10.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                break;
                            case 6:
                                this.hallway11 = new Sprite(YourGame.AssetManager.LoadTexture("hallway11"));
                                this.AddChild(hallway11);
                                hallway11.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                break;
                            case 7:
                                this.hallway15 = new Sprite(YourGame.AssetManager.LoadTexture("hallway15"));
                                this.AddChild(hallway15);
                                Level.level[northX, northY - 1] = 12;
                                hallway15.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                                break;
                        }
                    }
                }
            }

            if (level.east)
            {
                level.east = false;
                if (Level.rooms[eastX + 1, eastY] == 0)
                {
                    if (Level.rooms[eastX + 1, eastY - 1] != 0)
                    {
                        if (Level.rooms[eastX + 2, eastY] != 0)
                        {
                            if (Level.rooms[eastX + 1, eastY + 1] != 0)
                            {
                                this.hallway14 = new Sprite(YourGame.AssetManager.LoadTexture("hallway14"));
                                this.AddChild(hallway14);
                                hallway14.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                            }
                            else
                            {
                                random = YourGame.Random.Next(2);

                                if (random == 0)
                                {
                                    this.hallway5 = new Sprite(YourGame.AssetManager.LoadTexture("hallway5"));
                                    this.AddChild(hallway5);
                                    Level.level[eastX + 1, eastY] = 3;
                                    hallway5.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                }
                                else
                                {
                                    this.hallway14 = new Sprite(YourGame.AssetManager.LoadTexture("hallway14"));
                                    this.AddChild(hallway14);
                                    hallway14.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                }
                            }
                        }
                        else if (Level.rooms[eastX + 1, eastY + 1] != 0)
                        {
                            random = YourGame.Random.Next(2);

                            if (random == 0)
                            {
                                this.hallway1 = new Sprite(YourGame.AssetManager.LoadTexture("hallway1"));
                                this.AddChild(hallway1);
                                Level.level[eastX + 1, eastY] = 2;
                                hallway1.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                            }
                            else
                            {
                                this.hallway14 = new Sprite(YourGame.AssetManager.LoadTexture("hallway14"));
                                this.AddChild(hallway14);
                                hallway14.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                            }
                        }
                        else
                        {
                            random = YourGame.Random.Next(4);

                            if (random == 0)
                            {
                                this.hallway1 = new Sprite(YourGame.AssetManager.LoadTexture("hallway1"));
                                this.AddChild(hallway1);
                                Level.level[eastX + 1, eastY] = 2;
                                hallway1.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                            }
                            if (random == 1)
                            {
                                this.hallway5 = new Sprite(YourGame.AssetManager.LoadTexture("hallway5"));
                                this.AddChild(hallway5);
                                Level.level[eastX + 1, eastY] = 3;
                                hallway5.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                            }
                            if (random == 2)
                            {
                                this.hallway9 = new Sprite(YourGame.AssetManager.LoadTexture("hallway9"));
                                this.AddChild(hallway9);
                                Level.level[eastX + 1, eastY] = 8;
                                hallway9.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                            }
                            if (random == 3)
                            {
                                this.hallway14 = new Sprite(YourGame.AssetManager.LoadTexture("hallway14"));
                                this.AddChild(hallway14);
                                hallway14.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                            }
                        }
                    }
                    else if (Level.rooms[eastX + 2, eastY] != 0)
                    {
                        if (Level.rooms[eastX + 1, eastY + 1] != 0)
                        {
                            random = YourGame.Random.Next(2);

                            if (random == 0)
                            {
                                this.hallway4 = new Sprite(YourGame.AssetManager.LoadTexture("hallway4"));
                                this.AddChild(hallway4);
                                Level.level[eastX + 1, eastY] = 1;
                                hallway4.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                            }
                            else
                            {
                                this.hallway14 = new Sprite(YourGame.AssetManager.LoadTexture("hallway14"));
                                this.AddChild(hallway14);
                                hallway14.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                            }
                        }
                        else
                        {
                            random = YourGame.Random.Next(4);

                            if (random == 0)
                            {
                                this.hallway4 = new Sprite(YourGame.AssetManager.LoadTexture("hallway4"));
                                this.AddChild(hallway4);
                                Level.level[eastX + 1, eastY] = 1;
                                hallway4.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                            }
                            if (random == 1)
                            {
                                this.hallway5 = new Sprite(YourGame.AssetManager.LoadTexture("hallway5"));
                                this.AddChild(hallway5);
                                Level.level[eastX + 1, eastY] = 3;
                                hallway5.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                            }
                            if (random == 2)
                            {
                                this.hallway8 = new Sprite(YourGame.AssetManager.LoadTexture("hallway8"));
                                this.AddChild(hallway8);
                                Level.level[eastX + 1, eastY] = 6;
                                hallway8.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                            }
                            if (random == 3)
                            {
                                this.hallway14 = new Sprite(YourGame.AssetManager.LoadTexture("hallway14"));
                                this.AddChild(hallway14);
                                hallway14.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                            }
                        }
                    }
                    else if (Level.rooms[eastX + 1, eastY - 1] != 0)
                    {
                        random = YourGame.Random.Next(4);

                        if (random == 0)
                        {
                            this.hallway1 = new Sprite(YourGame.AssetManager.LoadTexture("hallway1"));
                            this.AddChild(hallway1);
                            Level.level[eastX + 1, eastY] = 2;
                            hallway1.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                        }
                        if (random == 1)
                        {
                            this.hallway4 = new Sprite(YourGame.AssetManager.LoadTexture("hallway4"));
                            this.AddChild(hallway4);
                            Level.level[eastX + 1, eastY] = 1;
                            hallway4.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                        }
                        if (random == 2)
                        {
                            this.hallway7 = new Sprite(YourGame.AssetManager.LoadTexture("hallway7"));
                            this.AddChild(hallway7);
                            Level.level[eastX + 1, eastY] = 5;
                            hallway7.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                        }
                        if (random == 3)
                        {
                            this.hallway14 = new Sprite(YourGame.AssetManager.LoadTexture("hallway14"));
                            this.AddChild(hallway14);
                            hallway14.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                        }
                    }
                    else
                    {
                        random = YourGame.Random.Next(8);

                        switch (random)
                        {
                            case 0:
                                this.hallway1 = new Sprite(YourGame.AssetManager.LoadTexture("hallway1"));
                                this.AddChild(hallway1);
                                Level.level[eastX + 1, eastY] = 2;
                                hallway1.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                break;
                            case 1:
                                this.hallway4 = new Sprite(YourGame.AssetManager.LoadTexture("hallway4"));
                                this.AddChild(hallway4);
                                Level.level[eastX + 1, eastY] = 1;
                                hallway4.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                break;
                            case 2:
                                this.hallway5 = new Sprite(YourGame.AssetManager.LoadTexture("hallway5"));
                                this.AddChild(hallway5);
                                Level.level[eastX + 1, eastY] = 3;
                                hallway5.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                break;
                            case 3:
                                this.hallway7 = new Sprite(YourGame.AssetManager.LoadTexture("hallway7"));
                                this.AddChild(hallway7);
                                Level.level[eastX + 1, eastY] = 5;
                                hallway7.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                break;
                            case 4:
                                this.hallway8 = new Sprite(YourGame.AssetManager.LoadTexture("hallway8"));
                                this.AddChild(hallway8);
                                Level.level[eastX + 1, eastY] = 6;
                                hallway8.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                break;
                            case 5:
                                this.hallway9 = new Sprite(YourGame.AssetManager.LoadTexture("hallway9"));
                                this.AddChild(hallway9);
                                Level.level[eastX + 1, eastY] = 8;
                                hallway9.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                break;
                            case 6:
                                this.hallway14 = new Sprite(YourGame.AssetManager.LoadTexture("hallway14"));
                                this.AddChild(hallway14);
                                hallway14.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                break;
                            case 7:
                                this.hallway15 = new Sprite(YourGame.AssetManager.LoadTexture("hallway15"));
                                this.AddChild(hallway15);
                                Level.level[eastX + 1, eastY] = 11;
                                hallway15.GlobalPosition = new Vector2((eastX + 1) * 256 - 12800, eastY * 256 - 12800);
                                break;
                        }
                    }
                }
            }

            if (level.south)
            {
                level.south = false;
                if (Level.rooms[southX, southY + 1] == 0)
                {
                    if (Level.rooms[southX + 1, southY + 1] != 0)
                    {
                        if (Level.rooms[southX, southY + 2] != 0)
                        {
                            if (Level.rooms[southX - 1, southY + 1] != 0)
                            {
                                this.hallway13 = new Sprite(YourGame.AssetManager.LoadTexture("hallway13"));
                                this.AddChild(hallway13);
                                hallway13.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                            }
                            else
                            {
                                random = YourGame.Random.Next(2);

                                if (random == 0)
                                {
                                    this.hallway4 = new Sprite(YourGame.AssetManager.LoadTexture("hallway4"));
                                    this.AddChild(hallway4);
                                    Level.level[southX, southY + 1] = 4;
                                    hallway4.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                }
                                else
                                {
                                    this.hallway13 = new Sprite(YourGame.AssetManager.LoadTexture("hallway13"));
                                    this.AddChild(hallway13);
                                    hallway13.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                }
                            }
                        }
                        else if (Level.rooms[southX - 1, southY + 1] != 0)
                        {
                            random = YourGame.Random.Next(2);

                            if (random == 0)
                            {
                                this.hallway2 = new Sprite(YourGame.AssetManager.LoadTexture("hallway2"));
                                this.AddChild(hallway2);
                                Level.level[southX, southY + 1] = 3;
                                hallway2.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                            }
                            else
                            {
                                this.hallway13 = new Sprite(YourGame.AssetManager.LoadTexture("hallway13"));
                                this.AddChild(hallway13);
                                hallway13.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                            }
                        }
                        else
                        {
                            random = YourGame.Random.Next(4);

                            if (random == 0)
                            {
                                this.hallway2 = new Sprite(YourGame.AssetManager.LoadTexture("hallway2"));
                                this.AddChild(hallway2);
                                Level.level[southX, southY + 1] = 3;
                                hallway2.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                            }
                            if (random == 1)
                            {
                                this.hallway4 = new Sprite(YourGame.AssetManager.LoadTexture("hallway4"));
                                this.AddChild(hallway4);
                                Level.level[southX, southY + 1] = 4;
                                hallway4.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                            }
                            if (random == 2)
                            {
                                this.hallway8 = new Sprite(YourGame.AssetManager.LoadTexture("hallway8"));
                                this.AddChild(hallway8);
                                Level.level[southX, southY + 1] = 10;
                                hallway8.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                            }
                            if (random == 3)
                            {
                                this.hallway13 = new Sprite(YourGame.AssetManager.LoadTexture("hallway13"));
                                this.AddChild(hallway13);
                                hallway13.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                            }
                        }
                    }
                    else if (Level.rooms[southX, southY + 2] != 0)
                    {
                        if (Level.rooms[southX - 1, southY + 1] != 0)
                        {
                            random = YourGame.Random.Next(2);

                            if (random == 0)
                            {
                                this.hallway3 = new Sprite(YourGame.AssetManager.LoadTexture("hallway3"));
                                this.AddChild(hallway3);
                                Level.level[southX, southY + 1] = 2;
                                hallway3.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                            }
                            else
                            {
                                this.hallway13 = new Sprite(YourGame.AssetManager.LoadTexture("hallway13"));
                                this.AddChild(hallway13);
                                hallway13.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                            }
                        }
                        else
                        {
                            random = YourGame.Random.Next(4);

                            if (random == 0)
                            {
                                this.hallway3 = new Sprite(YourGame.AssetManager.LoadTexture("hallway3"));
                                this.AddChild(hallway3);
                                Level.level[southX, southY + 1] = 2;
                                hallway3.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                            }
                            if (random == 1)
                            {
                                this.hallway4 = new Sprite(YourGame.AssetManager.LoadTexture("hallway4"));
                                this.AddChild(hallway4);
                                Level.level[southX, southY + 1] = 4;
                                hallway4.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                            }
                            if (random == 2)
                            {
                                this.hallway7 = new Sprite(YourGame.AssetManager.LoadTexture("hallway7"));
                                this.AddChild(hallway7);
                                Level.level[southX, southY + 1] = 9;
                                hallway7.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                            }
                            if (random == 3)
                            {
                                this.hallway13 = new Sprite(YourGame.AssetManager.LoadTexture("hallway13"));
                                this.AddChild(hallway13);
                                hallway13.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                            }
                        }
                    }
                    else if (Level.rooms[southX - 1, southY + 1] != 0)
                    {
                        random = YourGame.Random.Next(4);

                        if (random == 0)
                        {
                            this.hallway2 = new Sprite(YourGame.AssetManager.LoadTexture("hallway2"));
                            this.AddChild(hallway2);
                            Level.level[southX, southY + 1] = 3;
                            hallway2.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                        }
                        if (random == 1)
                        {
                            this.hallway3 = new Sprite(YourGame.AssetManager.LoadTexture("hallway3"));
                            this.AddChild(hallway3);
                            Level.level[southX, southY + 1] = 2;
                            hallway3.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                        }
                        if (random == 2)
                        {
                            this.hallway10 = new Sprite(YourGame.AssetManager.LoadTexture("hallway10"));
                            this.AddChild(hallway10);
                            Level.level[southX, southY + 1] = 8;
                            hallway10.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                        }
                        if (random == 3)
                        {
                            this.hallway13 = new Sprite(YourGame.AssetManager.LoadTexture("hallway13"));
                            this.AddChild(hallway13);
                            hallway13.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                        }
                    }
                    else
                    {
                        random = YourGame.Random.Next(8);

                        switch (random)
                        {
                            case 0:
                                this.hallway2 = new Sprite(YourGame.AssetManager.LoadTexture("hallway2"));
                                this.AddChild(hallway2);
                                Level.level[southX, southY + 1] = 3;
                                room2.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                break;
                            case 1:
                                this.hallway3 = new Sprite(YourGame.AssetManager.LoadTexture("hallway3"));
                                this.AddChild(hallway3);
                                Level.level[southX, southY + 1] = 2;
                                hallway3.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                break;
                            case 2:
                                this.hallway4 = new Sprite(YourGame.AssetManager.LoadTexture("hallway4"));
                                this.AddChild(hallway4);
                                Level.level[southX, southY + 1] = 4;
                                hallway4.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                break;
                            case 3:
                                this.hallway7 = new Sprite(YourGame.AssetManager.LoadTexture("hallway7"));
                                this.AddChild(hallway7);
                                Level.level[southX, southY + 1] = 9;
                                hallway7.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                break;
                            case 4:
                                this.hallway8 = new Sprite(YourGame.AssetManager.LoadTexture("hallway8"));
                                this.AddChild(hallway8);
                                Level.level[southX, southY + 1] = 10;
                                hallway8.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                break;
                            case 5:
                                this.hallway10 = new Sprite(YourGame.AssetManager.LoadTexture("hallway10"));
                                this.AddChild(hallway10);
                                Level.level[southX, southY + 1] = 8;
                                hallway10.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                break;
                            case 6:
                                this.hallway13 = new Sprite(YourGame.AssetManager.LoadTexture("hallway13"));
                                this.AddChild(hallway13);
                                hallway13.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                break;
                            case 7:
                                this.hallway15 = new Sprite(YourGame.AssetManager.LoadTexture("hallway15"));
                                this.AddChild(hallway15);
                                Level.level[southX, southY + 1] = 14;
                                hallway15.GlobalPosition = new Vector2(southX * 256 - 12800, (southY + 1) * 256 - 12800);
                                break;
                        }
                    }
                }
            }

            if (level.west)
            {
                level.west = false;
                if (Level.rooms[westX - 1, westY] == 0)
                {
                    if (Level.rooms[westX - 1, westY - 1] != 0)
                    {
                        if (Level.rooms[westX - 2, westY] != 0)
                        {
                            if (Level.rooms[westX - 1, westY + 1] != 0)
                            {
                                this.hallway12 = new Sprite(YourGame.AssetManager.LoadTexture("hallway12"));
                                this.AddChild(hallway12);
                                hallway12.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                            }
                            else
                            {
                                random = YourGame.Random.Next(2);

                                if (random == 0)
                                {
                                    this.hallway6 = new Sprite(YourGame.AssetManager.LoadTexture("hallway6"));
                                    this.AddChild(hallway6);
                                    Level.level[westX - 1, westY] = 3;
                                    hallway6.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                }
                                else
                                {
                                    this.hallway12 = new Sprite(YourGame.AssetManager.LoadTexture("hallway12"));
                                    this.AddChild(hallway12);
                                    hallway12.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                }
                            }
                        }
                        else if (Level.rooms[westX - 1, westY + 1] != 0)
                        {
                            random = YourGame.Random.Next(2);

                            if (random == 0)
                            {
                                this.hallway1 = new Sprite(YourGame.AssetManager.LoadTexture("hallway1"));
                                this.AddChild(hallway1);
                                Level.level[westX - 1, westY] = 4;
                                hallway1.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                            }
                            else
                            {
                                this.hallway12 = new Sprite(YourGame.AssetManager.LoadTexture("hallway12"));
                                this.AddChild(hallway12);
                                hallway12.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                            }
                        }
                        else
                        {
                            random = YourGame.Random.Next(4);

                            if (random == 0)
                            {
                                this.hallway1 = new Sprite(YourGame.AssetManager.LoadTexture("hallway1"));
                                this.AddChild(hallway1);
                                Level.level[westX - 1, westY] = 4;
                                hallway1.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                            }
                            if (random == 1)
                            {
                                this.hallway6 = new Sprite(YourGame.AssetManager.LoadTexture("hallway6"));
                                this.AddChild(hallway6);
                                Level.level[westX - 1, westY] = 3;
                                hallway6.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                            }
                            if (random == 2)
                            {
                                this.hallway9 = new Sprite(YourGame.AssetManager.LoadTexture("hallway9"));
                                this.AddChild(hallway9);
                                Level.level[westX - 1, westY] = 10;
                                hallway9.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                            }
                            if (random == 3)
                            {
                                this.hallway12 = new Sprite(YourGame.AssetManager.LoadTexture("hallway12"));
                                this.AddChild(hallway12);
                                hallway12.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                            }
                        }
                    }
                    else if (Level.rooms[westX - 2, westY] != 0)
                    {
                        if (Level.rooms[westX - 1, westY + 1] != 0)
                        {
                            random = YourGame.Random.Next(2);

                            if (random == 0)
                            {
                                this.hallway3 = new Sprite(YourGame.AssetManager.LoadTexture("hallway3"));
                                this.AddChild(hallway3);
                                Level.level[westX - 1, westY] = 1;
                                hallway3.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                            }
                            else
                            {
                                this.hallway12 = new Sprite(YourGame.AssetManager.LoadTexture("hallway12"));
                                this.AddChild(hallway12);
                                hallway12.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                            }
                        }
                        else
                        {
                            random = YourGame.Random.Next(4);

                            if (random == 0)
                            {
                                this.hallway3 = new Sprite(YourGame.AssetManager.LoadTexture("hallway3"));
                                this.AddChild(hallway3);
                                Level.level[westX - 1, westY] = 1;
                                hallway3.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                            }
                            if (random == 1)
                            {
                                this.hallway6 = new Sprite(YourGame.AssetManager.LoadTexture("hallway6"));
                                this.AddChild(hallway6);
                                Level.level[westX - 1, westY] = 3;
                                hallway6.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                            }
                            if (random == 2)
                            {
                                this.hallway10 = new Sprite(YourGame.AssetManager.LoadTexture("hallway10"));
                                this.AddChild(hallway10);
                                Level.level[westX - 1, westY] = 6;
                                hallway10.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                            }
                            if (random == 3)
                            {
                                this.hallway12 = new Sprite(YourGame.AssetManager.LoadTexture("hallway12"));
                                this.AddChild(hallway12);
                                hallway12.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                            }
                        }
                    }
                    else if (Level.rooms[westX - 1, westY + 1] != 0)
                    {
                        random = YourGame.Random.Next(4);

                        if (random == 0)
                        {
                            this.hallway1 = new Sprite(YourGame.AssetManager.LoadTexture("hallway1"));
                            this.AddChild(hallway1);
                            Level.level[westX - 1, westY] = 4;
                            hallway1.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                        }
                        if (random == 1)
                        {
                            this.hallway3 = new Sprite(YourGame.AssetManager.LoadTexture("hallway3"));
                            this.AddChild(hallway3);
                            Level.level[westX - 1, westY] = 1;
                            hallway3.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                        }
                        if (random == 2)
                        {
                            this.hallway7 = new Sprite(YourGame.AssetManager.LoadTexture("hallway7"));
                            this.AddChild(hallway7);
                            Level.level[westX - 1, westY] = 7;
                            hallway7.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                        }
                        if (random == 3)
                        {
                            this.hallway12 = new Sprite(YourGame.AssetManager.LoadTexture("hallway12"));
                            this.AddChild(hallway12);
                            hallway12.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                        }
                    }
                    else
                    {
                        random = YourGame.Random.Next(8);

                        switch (random)
                        {
                            case 0:
                                this.hallway1 = new Sprite(YourGame.AssetManager.LoadTexture("hallway1"));
                                this.AddChild(hallway1);
                                Level.level[westX - 1, westY] = 4;
                                hallway1.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                break;
                            case 1:
                                this.hallway3 = new Sprite(YourGame.AssetManager.LoadTexture("hallway3"));
                                this.AddChild(hallway3);
                                Level.level[westX - 1, westY] = 1;
                                hallway3.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                break;
                            case 2:
                                this.hallway6 = new Sprite(YourGame.AssetManager.LoadTexture("hallway6"));
                                this.AddChild(hallway6);
                                Level.level[westX - 1, westY] = 3;
                                hallway6.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                break;
                            case 3:
                                this.hallway7 = new Sprite(YourGame.AssetManager.LoadTexture("hallway7"));
                                this.AddChild(hallway7);
                                Level.level[westX - 1, westY] = 7;
                                hallway7.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                break;
                            case 4:
                                this.hallway9 = new Sprite(YourGame.AssetManager.LoadTexture("hallway9"));
                                this.AddChild(hallway9);
                                Level.level[westX - 1, westY] = 10;
                                hallway9.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                break;
                            case 5:
                                this.room10 = new Sprite(YourGame.AssetManager.LoadTexture("hallway10"));
                                this.AddChild(room10);
                                Level.level[westX - 1, westY] = 6;
                                room10.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                break;
                            case 6:
                                this.hallway12 = new Sprite(YourGame.AssetManager.LoadTexture("hallway12"));
                                this.AddChild(hallway12);
                                hallway12.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                break;
                            case 7:
                                this.hallway15 = new Sprite(YourGame.AssetManager.LoadTexture("hallway15"));
                                this.AddChild(hallway15);
                                Level.level[westX - 1, westY] = 13;
                                hallway15.GlobalPosition = new Vector2((westX - 1) * 256 - 12800, westY * 256 - 12800);
                                break;
                        }
                    }
                }
            }

        }

        public void MakeLoreRoom()
        {
            if (level.north)
            {
                if (Level.rooms[northX, northY + 1] == 0)
                {
                    this.room11 = new Sprite(YourGame.AssetManager.LoadTexture("room11"));
                    this.AddChild(room11);
                    Level.level[northX, northY + 1] = 0;
                    room11.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                }
            }
            else
            {
                if (level.east)
                {
                    if (Level.rooms[eastX + 1, eastY] == 0)
                    {

                    }
                }
                if (level.south)
                {
                    if (Level.rooms[southX, southY + 1] == 0)
                    {

                    }
                }
                if (level.west)
                {
                    if (Level.rooms[westX - 1, westY] == 0)
                    {

                    }
                }
            }
        }

        public void MakeCraftingRoom() 
        {
            if (level.north)
            {
                if (Level.rooms[northX, northY + 1] == 0)
                {
                    this.room11 = new Sprite(YourGame.AssetManager.LoadTexture("room11"));
                    this.AddChild(room11);
                    Level.level[northX, northY + 1] = 0;
                    room11.GlobalPosition = new Vector2(northX * 256 - 12800, (northY - 1) * 256 - 12800);
                }
            }
            else
            {
                if (level.east)
                {
                    if (Level.rooms[eastX + 1, eastY] == 0)
                    {

                    }
                }
                if (level.south)
                {
                    if (Level.rooms[southX, southY + 1] == 0)
                    {

                    }
                }
                if (level.west)
                {
                    if (Level.rooms[westX - 1, westY] == 0)
                    {

                    }
                }
            }
        }

        public void MakeBossRoom()
        {
            if (level.north)
            {

            }
            else
            {

            }
        }

        protected override void UpdateSelf(GameTime gameTime)
        {

            if (chestBox.Contains(Player2.playerPos))
            {
                if (YourGame.InputManager.CheckIsKeyPressed(Keys.E))
                {
                    if (openC)
                    {
                        //this.RemoveChild(chest);
                        this.openChest = new Sprite(YourGame.AssetManager.LoadTexture("chestopened"));
                        this.AddChild(openChest);
                        openChest.GlobalPosition = new Vector2(40, 200);
                        openC = false;
                    }
                }
            }
        }
    }
}
