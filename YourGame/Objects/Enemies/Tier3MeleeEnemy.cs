using Microsoft.Xna.Framework;

namespace YourGame
{
    public class Tier3MeleeEnemy : MeleeEnemy
    {
        public Tier3MeleeEnemy() : base(300, "Enemies/Jackal")
        {
            Velocity = 50;
        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            ChasePlayer();
        }
    }
}
