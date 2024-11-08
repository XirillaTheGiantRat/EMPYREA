using Microsoft.Xna.Framework;
using System;
using YourEngine;

namespace YourGame
{
    public class AOEEnemy : Enemy
    {

        public Timer FireRate;
        protected Exploxive exploxive;
        int Damage, ExplosionRange;
        public AOEEnemy(float HP, float fireRate, int damage, int explosionRange, string spriteName) : base(HP, spriteName)
        {
            FireRate = new Timer(fireRate);
            Damage = damage;
            ExplosionRange = explosionRange;
        }
        protected override void UpdateSelf(GameTime gametime)
        {
            ChasePlayer();
            DistanceToPlayer();
            FireRate.Update((float)gametime.ElapsedGameTime.TotalSeconds);
            if (FireRate.IsFinished)
            {
                Shoot();
            }
        }
        protected void Shoot()
        {
            exploxive = new Exploxive(Damage, ExplosionRange, 1, targetEnemyPosition, "Enemies/enemybomb")
            {
                Object = this
            };
               this.AddChild(exploxive);
            
            /*if (Exploxive.exploxion.hasfinished)
            {
                this.RemoveChild(exploxive);
            }*/

        }
    }
}
