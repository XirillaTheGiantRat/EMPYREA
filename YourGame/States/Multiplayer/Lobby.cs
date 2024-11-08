using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
using YourEngine;

namespace YourGame.States
{
    sealed class Lobby : State
    {
        private Socket socket;
        private BackgroundWorker serverworker = new BackgroundWorker();
        private BackgroundWorker clientworker = new BackgroundWorker();
        private TcpListener server = null;
        private TcpClient client;

        Sprite lobbyOutline, lobbyName;
        TextBox lobbyNameBox;
        Button backButton, playButton;
        Texture2D nameOutline, background;
        SpriteFont fontl;

        int amountOfPlayers;
        string playerName, otherPlayerName1, otherPlayerName2;
        bool isHost;

        public Lobby(string playername, bool isHost, string ipAdress = null) 
        {
            this.isHost = isHost;
            playerName = playername;

            #region loading ui
            nameOutline = YourGame.AssetManager.LoadTexture("Multiplayer/lobbyoutline");
            fontl = YourGame.AssetManager.LoadFont("File");

            this.background = YourGame.AssetManager.LoadTexture("backgroundcolour");

            this.backButton = new Button(YourGame.AssetManager.LoadTexture("backbutton"),
            YourGame.AssetManager.LoadTexture("Buttons/backbuttonpressed"));
            backButton.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2 - 2*backButton.Width,
                YourGame.ScreenSize.Y / 1.01f);
            this.AddChild(backButton);

            this.playButton = new Button(YourGame.AssetManager.LoadTexture("playbutton"),
                YourGame.AssetManager.LoadTexture("playbuttonpressed"));
            playButton.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 2 + backButton.Width,
             YourGame.ScreenSize.Y / 1.01f);
            this.AddChild(playButton);

            this.lobbyOutline = new Sprite(YourGame.AssetManager.LoadTexture("Multiplayer/lobbylistoutlinetrans"))
            {
                GlobalPosition = YourGame.ScreenSize.ToVector2() / 2,
                OriginType = OriginType.Center
            };
            this.AddChild(lobbyOutline);

            this.lobbyNameBox = new TextBox(YourGame.AssetManager.LoadTexture("Multiplayer/lobbyoutline"),
            YourGame.AssetManager.LoadFont("File"), 9);
            lobbyNameBox.BoxRectangel = new Rectangle(YourGame.ScreenSize.X / 16,
                YourGame.ScreenSize.Y / 4, 100, lobbyNameBox.Height);
            this.AddChild(lobbyNameBox);

            this.lobbyName = new Sprite(YourGame.AssetManager.LoadTexture("Multiplayer/lobbyname"));
            lobbyName.GlobalPosition = new Vector2(YourGame.ScreenSize.X / 16,
                YourGame.ScreenSize.Y / 4 - lobbyName.Texture.Height - 5);
            this.AddChild(lobbyName);
            #endregion

            if (isHost)
                serverworker.DoWork += ServerWorker_DoWork;
            else
                clientworker.DoWork += Clientworker_DoWork;

            amountOfPlayers = 1;
            if (isHost)
            {
                server = new TcpListener(System.Net.IPAddress.Any, 5749); //5731-5740, 5749
                server.Start();
                socket = server.AcceptSocket(); //waiting for connection
                serverworker.RunWorkerAsync();
            }
            else
            {
                try
                {
                    client = new TcpClient(ipAdress, 5749); //5731-5740, 5749
                    socket = client.Client;
                    byte[] data = System.Text.Encoding.ASCII.GetBytes(playerName);
                    socket.Send(data);
                    clientworker.RunWorkerAsync();
                }
                catch(Exception ex)
                {
                    throw new Exception("Could not connect or smt: " + ex);
                }
            }
        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            if(backButton.Pressed)
            {
                socket.Close();
                if (isHost)
                {
                    server.Stop();
                    serverworker.WorkerSupportsCancellation = true;
                    serverworker.CancelAsync();
                }
                else
                {
                    clientworker.WorkerSupportsCancellation= true;
                    clientworker.CancelAsync();
                }

                this.NextState = new Multiplayer();
            }

            if(playButton.Pressed)
            {
                this.NextState = new MultiplayerLevel();
            }


            if (lobbyNameBox.BoxRectangel.Contains(YourGame.GetMouseWorldPosition()) &&
                YourGame.InputManager.HasMouseJustLeftClicked)
            {
                lobbyNameBox.Selected = true;
            }
            else if (!lobbyNameBox.BoxRectangel.Contains(YourGame.GetMouseWorldPosition()) &&
                YourGame.InputManager.HasMouseJustLeftClicked)
            {
                lobbyNameBox.Selected = false;
            }

            var keys = YourGame.InputManager.keys;
            if (keys.Count() > 0)
            {
                if (keys.Count() > 1)
                {
                    keys[0] = ExtractSingleKey(keys);
                }
                if (YourGame.InputManager.CheckIsKeyJustPressed(Keys.Back) ||
                    YourGame.InputManager.CheckIsKeyJustPressed(Keys.Delete))
                {
                    if (lobbyNameBox.Selected)
                    {
                        lobbyNameBox.AddText('\b');
                        return;
                    }
                }
                if (lobbyNameBox.Selected && (int)keys[0] >= 48 && (int)keys[0] <= 105)
                {
                    if (YourGame.InputManager.CheckIsKeyJustPressed(keys[0]))
                        lobbyNameBox.AddText((char)keys[0]);
                }
            }
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Vector2(0, 0), Color.White);
            for (int i = 0; i < amountOfPlayers; i++)
            {
                spriteBatch.Draw(nameOutline, new Vector2(YourGame.ScreenSize.X / 2 - lobbyOutline.Texture.Width/2 + 4, 
                    YourGame.ScreenSize.Y /2 - lobbyOutline.Texture.Height / 2 + 4 + i * nameOutline.Height + 5), 
                    Color.White);
            } 
            spriteBatch.DrawString(fontl, playerName, new Vector2(
                YourGame.ScreenSize.X / 2 - lobbyOutline.Texture.Width / 2 + 4 + 5,
                YourGame.ScreenSize.Y / 2 - lobbyOutline.Texture.Height / 2 + 5), Color.White);
            if(amountOfPlayers == 2 || amountOfPlayers == 3)
            {
                spriteBatch.DrawString(fontl, otherPlayerName1, new Vector2(
                YourGame.ScreenSize.X / 2 - lobbyOutline.Texture.Width / 2 + 4 + 5,
                YourGame.ScreenSize.Y / 2 - lobbyOutline.Texture.Height / 2 + 10 + nameOutline.Height), Color.White);
            }
            if(amountOfPlayers == 3)
            {
                spriteBatch.DrawString(fontl, otherPlayerName2, new Vector2(
                YourGame.ScreenSize.X / 2 - lobbyOutline.Texture.Width / 2 + 4 + 5,
                YourGame.ScreenSize.Y / 2 - lobbyOutline.Texture.Height / 2 + 15 + 2 * nameOutline.Height), Color.White);
            }
        }
        #region Send and Recieve
        private void ServerWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if(amountOfPlayers == 1)
            {
                otherPlayerName1 = RecieveUsername();
                if(otherPlayerName1 != null)
                {
                    amountOfPlayers++;
                }
            }
            else if (amountOfPlayers == 2)
            {
                otherPlayerName2 = RecieveUsername();
                if(otherPlayerName2 != null)
                {
                    amountOfPlayers++;
                }
            }
            else { return; }
            SendPlayerCount();
            SendAllNames();
        }

        private void Clientworker_DoWork(object sender, DoWorkEventArgs e)
        {
            amountOfPlayers = RecievePlayerCount();
            if(amountOfPlayers == 2) 
            {
                otherPlayerName1 = RecieveUsername();
            }
            else if(amountOfPlayers == 3)
            {
                otherPlayerName1 = RecieveUsername();
                otherPlayerName2 = RecieveUsername();
            }
            else { return; }
        }
        string RecieveUsername()
        {
            byte[] buffer = new byte[1024];
            int iRx = socket.Receive(buffer);
            char[] chars = new char[iRx];

            System.Text.Decoder dec = System.Text.Encoding.UTF8.GetDecoder();
            int charLen = dec.GetChars(buffer, 0, iRx, chars, 0);
            return new String(chars);
        }
        int RecievePlayerCount()
        {
            byte[] data = new byte[1];
            socket.Receive(data);
            return data[0];
        }
        void SendPlayerCount()
        {
            byte[] data = new byte[1];
            data[0] = (byte)amountOfPlayers;
            socket.Send(data);
        }
        void SendAllNames()
        {
            if (amountOfPlayers == 2)
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(playerName);
                socket.Send(data);
            }
            else if (amountOfPlayers == 3)
            {
                byte[] data1 = System.Text.Encoding.ASCII.GetBytes(playerName);
                socket.Send(data1);
                byte[] data2 = System.Text.Encoding.ASCII.GetBytes(otherPlayerName1);
                socket.Send(data2);
                byte[] data3 = System.Text.Encoding.ASCII.GetBytes(otherPlayerName2);
                socket.Send(data3);
            }
            else
                return;
        }
        #endregion
        Keys ExtractSingleKey(Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if ((int)key >= 48 && (int)key <= 105)
                    return key;
            }
            return Keys.None;
        }
    }
}
