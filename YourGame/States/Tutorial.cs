using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YourEngine;
using YourGame.Objects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace YourGame.States
{
    internal class Tutorial : State
    {
        Sprite jackal, room1, room2, room3, room4, room5, room6, room7, room8, room9, room10, room11, room12, room13, room14, room15, hallway1, hallway2, hallway3, hallway4, hallway5, hallway6, hallway7, hallway8, hallway9, hallway10, hallway11, hallway12, hallway13, hallway14, hallway15, bosRoom, lobby, workbench;
        public Player2 player;
        public static Rectangle elevatorBox;

        public Tutorial()
        {
            MakeTutorial();
        }

        void MakeTutorial()
        {
            this.room13 = new Sprite(YourGame.AssetManager.LoadTexture("room13"));
            this.AddChild(room13);
            room13.GlobalPosition = new Vector2(100 * 256, 100 * 256);

            this.hallway2 = new Sprite(YourGame.AssetManager.LoadTexture("hallway2"));
            this.AddChild(hallway2);
            hallway2.GlobalPosition = new Vector2(100 * 256, 99 * 256);

            this.hallway8 = new Sprite(YourGame.AssetManager.LoadTexture("hallway8"));
            this.AddChild(hallway8);
            hallway8.GlobalPosition = new Vector2(100 * 256, 98 * 256);

            this.room3 = new Sprite(YourGame.AssetManager.LoadTexture("room3"));
            this.AddChild(room3);
            room3.GlobalPosition = new Vector2(99 * 256, 98 * 256);

            this.workbench = new Sprite(YourGame.AssetManager.LoadTexture("workbench"));
            this.AddChild(workbench);
            workbench.GlobalPosition = new Vector2(99 * 256 + 50, 98 * 256 + 50);
            workbench.BaseDrawLayer = 1;

            this.hallway11 = new Sprite(YourGame.AssetManager.LoadTexture("hallway11"));
            this.AddChild(hallway11);
            hallway11.GlobalPosition = new Vector2(100 * 256, 97 * 256);

            this.hallway2 = new Sprite(YourGame.AssetManager.LoadTexture("hallway2"));
            this.AddChild(hallway2);
            hallway2.GlobalPosition = new Vector2(99 * 256, 97 * 256);

            this.hallway6 = new Sprite(YourGame.AssetManager.LoadTexture("hallway6"));
            this.AddChild(hallway6);
            hallway6.GlobalPosition = new Vector2(99 * 256, 96 * 256);

            this.hallway4 = new Sprite(YourGame.AssetManager.LoadTexture("hallway4"));
            this.AddChild(hallway4);
            hallway4.GlobalPosition = new Vector2(100 * 256, 96 * 256);

            this.room2 = new Sprite(YourGame.AssetManager.LoadTexture("room2"));
            this.AddChild(room2);
            room2.GlobalPosition = new Vector2(100 * 256, 95 * 256);

            this.hallway2 = new Sprite(YourGame.AssetManager.LoadTexture("hallway2"));
            this.AddChild(hallway2);
            hallway2.GlobalPosition = new Vector2(100 * 256, 94 * 256);

            this.lobby = new Sprite(YourGame.AssetManager.LoadTexture("lobby"));
            this.AddChild(lobby);
            lobby.GlobalPosition = new Vector2(100 * 256 - 128, 92 * 256);
            elevatorBox = new Rectangle(100 * 256 + 100, 92 * 256 + 70, 45, 25);

            player = new Player2();
            this.AddChild(player);
            player.GlobalPosition = new Vector2(100 * 256 + 50, 100 * 256 + 50);
            player.BaseDrawLayer = 1;

            player.posX = 100 * 256 + 120;
            player.posY = 100 * 256 + 120;
        }

        protected override void UpdateSelf(GameTime gameTime)
        {
            
            if (elevatorBox.Contains(Player2.playerPos))
            {
                if (YourGame.InputManager.CheckIsKeyJustPressed(Keys.E))
                {
                    this.NextState = new Level();
                }
            }
        }
    }
}
