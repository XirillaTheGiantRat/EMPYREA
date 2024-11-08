using Microsoft.Xna.Framework;

namespace YourGame
{
    public class Tier2MeleeEnemy : MeleeEnemy
    {
        public Tier2MeleeEnemy() : base(100, "Enemies/Jackal")
        {
            Velocity = 90;


        }

        protected override void UpdateSelf(GameTime gameTime)
        {
            ChasePlayer();
        }
    }

}
