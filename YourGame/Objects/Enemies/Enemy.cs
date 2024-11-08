using Microsoft.Xna.Framework;
using YourEngine;
using YourGame.Objects;

namespace YourGame
{
    public class Enemy : GameObject
    {
        public Vector2 enemyPosition, targetEnemyPosition;
        Sprite enemySprite;
        public string spriteName;
        public Rectangle enemyHitbox;
        public int HP { get; protected set; }


        //tier 1 hp 50, tier 2 hp 100, tier 3 hp 200
        //spirit ranged, cyclops aoe, jackal melee

        public bool Shock { get; set; }
        public bool FireDamage { get; set; }
        public bool Stun { get; set; }


        public Enemy(float HP, string spriteName)
        {
            Velocity = 35f;
            this.enemySprite = new Sprite(YourGame.AssetManager.LoadTexture(spriteName));
            this.enemySprite.OriginType = OriginType.Center;
            this.GlobalPosition = new Vector2(0, 0);
            enemyHitbox = new Rectangle((int)GlobalPosition.X, (int)GlobalPosition.Y, enemySprite.Texture.Width, enemySprite.Texture.Height);
            this.AddChild(enemySprite);
        }
        protected override void UpdateSelf(GameTime gametime)
        {
            if (!Stun)
            {
                ChasePlayer();
            }

        }
        protected void ChasePlayer()
        {
            targetEnemyPosition = Player2.playerPos;
            enemyPosition = targetEnemyPosition - this.GlobalPosition;
            this.Direction = enemyPosition * 8;
        }

        public void DoDamage(int damage)
        {
            HP -= damage;
        }
        protected void DistanceToPlayer()
        {
            if (ExtensionMethods.PositionIsWithinRange(this.GlobalPosition, targetEnemyPosition, 80))
            {
                this.Velocity = 0;
            }
            else
            {
                this.Velocity = 35f;
            }
        }


    }

}
