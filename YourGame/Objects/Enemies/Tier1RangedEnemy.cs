using Microsoft.Xna.Framework;

namespace YourGame
{
    public class Tier1RangedEnemy : RangedEnemy
    {
        Bullet bullet;
        public Tier1RangedEnemy() : base(50, 4, "Enemies/smallspirit")
        {
            
            
        }

        protected override void UpdateSelf(GameTime gametime)
        {
            ChasePlayer();
            DistanceToPlayer();
            bulletDirection = rangedEnemyPosition - targetEnemyPosition;
            

            fireRate.Update((float)gametime.ElapsedGameTime.TotalSeconds);
            if (fireRate.IsFinished)
            {
                bullet = new Bullet(25, bulletDirection);
                this.AddChild(bullet);
                
            }

        }
    }
}
