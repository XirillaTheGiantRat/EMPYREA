using Microsoft.Xna.Framework;
using YourEngine;
using YourGame.States;

namespace YourGame
{
    sealed class SunProjectile : GameObject
    {
        const int velocity = 100;
        int damage;
        Sprite sprite;
        public SunProjectile(Vector2 direction, int damage) 
        {
            sprite = new Sprite(YourGame.AssetManager.LoadTexture("sunprojectile"));
            this.AddChild(sprite);
            this.Velocity = velocity;
            this.damage = damage;
            this.Direction = direction;
        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            base.UpdateSelf(gameTime);
            foreach (Enemy e in Level.EngagedEnemies)
            {
                if (e.GlobalPosition == this.GlobalPosition)
                {
                    e.DoDamage(damage);
                    e.FireDamage = true;
                    Parent.RemoveChild(this);
                }
            }
        }
    }
}
