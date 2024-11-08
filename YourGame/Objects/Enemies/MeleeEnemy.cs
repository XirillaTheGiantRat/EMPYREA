using Microsoft.Xna.Framework;
using YourEngine;

namespace YourGame
{
    public class MeleeEnemy : Enemy
    {
        public MeleeEnemy(float HP, string spriteName) : base(HP, spriteName)
            {
            this.GlobalPosition = new Vector2(300, 400);
            }
        protected override void UpdateSelf(GameTime gameTime)
        {
            ChasePlayer();
        }
    }
}
