using Microsoft.Xna.Framework;

namespace YourGame
{
    public class Tier1MeleeEnemy : MeleeEnemy
    {
        public Tier1MeleeEnemy() : base(50, "Enemies/Jackal")
        {

        }

        protected override void UpdateSelf(GameTime gametime)
        {
            ChasePlayer();
        }
    }
}
