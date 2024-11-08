using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using YourEngine;

namespace YourGame.States
{
    public sealed class Multiplayer : State
    {
        Sprite background, playerName, ip;
        Button backButton, creatLobby, connect;
        TextBox playerNameBox, ipBox;
        public Multiplayer() 
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
                YourGame.ScreenSize.Y / 1.01f);
            this.AddChild(backButton);

            this.creatLobby = new Button(YourGame.AssetManager.LoadTexture("Multiplayer/createlobbybutton"),
                YourGame.AssetManager.LoadTexture("Multiplayer/createlobbybuttonpressed"));
            creatLobby.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2 - creatLobby.Width / 2,
                YourGame.ScreenSize.Y / 2);
            this.AddChild(creatLobby);

            this.playerNameBox = new TextBox(YourGame.AssetManager.LoadTexture("Multiplayer/lobbyoutline"),
                YourGame.AssetManager.LoadFont("File"), 9);
            playerNameBox.BoxRectangel = new Rectangle(YourGame.ScreenSize.X / 2 - 50,
                YourGame.ScreenSize.Y / 4, 100, playerNameBox.Height);
            this.AddChild(playerNameBox);

            this.playerName = new Sprite(YourGame.AssetManager.LoadTexture("Multiplayer/playername"));
            playerName.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2 - playerName.Texture.Width / 2,
                YourGame.ScreenSize.Y / 4 - playerName.Texture.Height - 5);
            this.AddChild(playerName);

            this.ip = new Sprite(YourGame.AssetManager.LoadTexture("Multiplayer/ip"));
            ip.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2 - ip.Texture.Width / 2,
                YourGame.ScreenSize.Y / 2 + creatLobby.Height + 10);
            this.AddChild(ip);

            this.ipBox = new TextBox(YourGame.AssetManager.LoadTexture("Multiplayer/lobbyoutline"),
                YourGame.AssetManager.LoadFont("File"), 15);
            ipBox.BoxRectangel = new Rectangle(YourGame.ScreenSize.X / 2 - ipBox.Width / 2,
                YourGame.ScreenSize.Y / 2 + creatLobby.Height + ip.Texture.Height + 20, ipBox.Width, ipBox.Height);
            this.AddChild(ipBox);

            this.connect = new Button(YourGame.AssetManager.LoadTexture("Multiplayer/connectbutton"),
                YourGame.AssetManager.LoadTexture("Multiplayer/connectbuttonpressed"));
            connect.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2 - connect.Width / 2,
                YourGame.ScreenSize.Y / 2 + creatLobby.Height + ip.Texture.Height + ipBox.Height + 30);
            this.AddChild(connect);
        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            if(backButton.Pressed)
            {
                this.NextState = new MainMenu();
            }

            #region textboxes
            if (playerNameBox.BoxRectangel.Contains(YourGame.GetMouseWorldPosition()) &&
                YourGame.InputManager.HasMouseJustLeftClicked)
            {
                playerNameBox.Selected = true;
            }
            if ((!playerNameBox.BoxRectangel.Contains(YourGame.GetMouseWorldPosition()) &&
                YourGame.InputManager.HasMouseJustLeftClicked) || ipBox.Selected)
            {
                playerNameBox.Selected = false;
            }

            if (ipBox.BoxRectangel.Contains(YourGame.GetMouseWorldPosition()) &&
                YourGame.InputManager.HasMouseJustLeftClicked)
            {
                ipBox.Selected = true;
            }
            if ((!ipBox.BoxRectangel.Contains(YourGame.GetMouseWorldPosition()) &&
                YourGame.InputManager.HasMouseJustLeftClicked) || playerNameBox.Selected)
            {
                ipBox.Selected = false;
            }

            var keys = YourGame.InputManager.keys;
            if(keys.Count() > 0)
            {
                if(keys.Count() > 1)
                {
                    keys[0] = ExtractSingleKey(keys);
                }
                if (YourGame.InputManager.CheckIsKeyJustPressed(Keys.Back) ||
                    YourGame.InputManager.CheckIsKeyJustPressed(Keys.Delete))
                {
                    if(playerNameBox.Selected)
                    {
                        playerNameBox.AddText('\b');
                        return;
                    }
                    else if (ipBox.Selected)
                    {
                        ipBox.AddText('\b');
                        return;
                    }
                }
                if (YourGame.InputManager.CheckIsKeyJustPressed(Keys.OemPeriod))
                {
                    if (ipBox.Selected)
                    {
                        ipBox.AddText('.');
                        return;
                    }
                }
                if (playerNameBox.Selected && (int)keys[0] >= 48 && (int)keys[0] <= 105)
                {
                    if (YourGame.InputManager.CheckIsKeyJustPressed(keys[0]))
                        playerNameBox.AddText((char)keys[0]);
                }
                if (ipBox.Selected && (int)keys[0] >= 48 && (int)keys[0] <= 105)
                {
                    if (YourGame.InputManager.CheckIsKeyJustPressed(keys[0]))
                        ipBox.AddText((char)keys[0]);
                }
            }
            #endregion

            if(playerNameBox.Text != string.Empty && creatLobby.Pressed) 
            {
                this.NextState = new Lobby(playerNameBox.Text, true);
            }
            if(playerNameBox.Text != string.Empty && ipBox.Text != string.Empty && connect.Pressed)
            {
                this.NextState = new Lobby(playerNameBox.Text, false, ipBox.Text);
            }
        }
        Keys ExtractSingleKey(Keys[] keys)
        {
            foreach( Keys key in keys)
            {
                if ((int)key >= 48 && (int)key <= 105)
                    return key;
            }
            return Keys.None;
        }
    }
}
