using Microsoft.Xna.Framework;

namespace YourGame
{
     public  class Tier3RangedEnemy : RangedEnemy
    {
        Bullet bullet1, bullet2, bullet3, bullet4, bullet5, bullet6, bullet7, bullet8;
        Vector2 bulletDirection2, bulletDirection3, bulletDirection4, bulletDirection5, bulletDirection6, bulletDirection7, bulletDirection8;
        public Tier3RangedEnemy() : base(200, 1.5f, "Enemies/smallspirit")
        {
            bulletDirection = new Vector2(1, 100);
            bulletDirection2 = new Vector2(70, 70);
            bulletDirection3 = new Vector2(200, 1);
            bulletDirection4 = new Vector2(70, -70);
            bulletDirection5 = new Vector2(1, -100);
            bulletDirection6 = new Vector2(-70, -70);
            bulletDirection7 = new Vector2(-200, 1);
            bulletDirection8 = new Vector2(-70, 70);
        }
        protected override void UpdateSelf(GameTime gametime)
        {
            ChasePlayer();
            DistanceToPlayer();

            fireRate.Update((float)gametime.ElapsedGameTime.TotalSeconds);
            if (fireRate.IsFinished)
            {
                 bullet1 = new Bullet(40, bulletDirection);   //up
                 bullet2 = new Bullet(40, bulletDirection2);  //up left
                 bullet3 = new Bullet(40, bulletDirection3);  //left
                 bullet4 = new Bullet(40, bulletDirection4);  //down left
                 bullet5 = new Bullet(40, bulletDirection5);  //down
                 bullet6 = new Bullet(40, bulletDirection6);  //down right
                 bullet7 = new Bullet(40, bulletDirection7);  //right
                 bullet8 = new Bullet(40, bulletDirection8);  //up right 
                this.AddChild(bullet1);
                this.AddChild(bullet2);
                this.AddChild(bullet3);
                this.AddChild(bullet4);
                this.AddChild(bullet5);
                this.AddChild(bullet6);
                this.AddChild(bullet7);
                this.AddChild(bullet8);
            }
        }
    }
}
