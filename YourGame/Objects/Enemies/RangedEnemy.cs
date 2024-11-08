using Microsoft.Xna.Framework;
using YourEngine;

namespace YourGame
{
    public class RangedEnemy : Enemy    
    {
        public Timer fireRate;
        Bullet bullet;
        public Vector2 bulletDirection, rangedEnemyPosition;
        public RangedEnemy(float HP, float fireRate, string spriteName) : base(HP, spriteName)
        {
            this.fireRate = new Timer(fireRate);
            this.GlobalPosition = new Vector2(50, 100);
        }
        protected override void UpdateSelf(GameTime gametime)
        {
            ChasePlayer();
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
