using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using YourEngine;
using YourGame.Objects;

namespace YourGame
{
    public sealed class PlayerUI : GameObject
    {
        Texture2D background, healthbar, dashcooldown;
        Player2 player;
        public PlayerUI(Player2 player)
        {
            background = YourGame.AssetManager.LoadTexture("Plyrui/barsoutline");
            healthbar = YourGame.AssetManager.LoadTexture("Plyrui/healthbar");
            dashcooldown = YourGame.AssetManager.LoadTexture("Plyrui/dashcooldowntimer");
            this.player = player;
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, new Vector2(0, YourGame.ScreenSize.Y - background.Height), Color.White);
            spriteBatch.Draw(
                healthbar, 
                new Rectangle(4, YourGame.ScreenSize.Y - background.Height + 6, CalcHealt(), 8), 
                Color.White);
            spriteBatch.Draw(
                dashcooldown,
                new Rectangle(4, YourGame.ScreenSize.Y - background.Height + 19, CalcDash(), 4),
                Color.White);
        }
        int CalcHealt()
        {
            return 128 * (player.Healt /Player2.maxHealth);
        }
        int CalcDash()
        {
            return (int)(63 * (Player2.maxDashCooldown - (player.Dashtimercooldown/Player2.maxDashCooldown)));
        }
    }
}
