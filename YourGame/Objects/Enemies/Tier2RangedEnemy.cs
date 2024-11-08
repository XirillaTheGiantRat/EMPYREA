using Microsoft.Xna.Framework;

namespace YourGame
{
    public class Tier2RangedEnemy : RangedEnemy
    {
        Bullet bullet, bullet2, bullet3;
        Vector2 bulletDirection2, bulletDirection3;
        public Tier2RangedEnemy() : base(100, 1.5f, "Enemies/smallspirit")
        {
            bulletDirection2 = new Vector2(bulletDirection.X - 40, bulletDirection.Y - 40);
            bulletDirection3 = new Vector2(bulletDirection.X - 40, bulletDirection.Y - 20 );
        }

        protected override void UpdateSelf(GameTime gametime)
        {
            ChasePlayer();
            DistanceToPlayer();

            bulletDirection = rangedEnemyPosition - targetEnemyPosition;

            fireRate.Update((float)gametime.ElapsedGameTime.TotalSeconds);
            if (fireRate.IsFinished)
            {
                bullet = new Bullet(40, bulletDirection);
                this.AddChild(bullet);
                bullet2 = new Bullet(40, bulletDirection2);
                this.AddChild(bullet2);
                bullet3 = new Bullet(40, bulletDirection3);
                this.AddChild(bullet3);
            }
        }
    }
}
