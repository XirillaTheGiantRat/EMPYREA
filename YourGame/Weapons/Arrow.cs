using Microsoft.Xna.Framework;
using YourEngine;
using YourGame.States;

namespace YourGame
{
    sealed class Arrow : GameObject
    {
        const int velocity = 100;
        int explosiveRange, damage;
        Sprite sprite, explode;
        public Arrow(Vector2 direction, int explosiveRange, int damage) 
        {
            sprite = new Sprite(YourGame.AssetManager.LoadTexture("arrow"));
            this.AddChild(sprite);
            explode = new Sprite(YourGame.AssetManager.LoadTexture("blast"));
            this.Velocity = velocity;
            this.Direction = direction;
            this.explosiveRange = explosiveRange;
            this.damage = damage;
        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            base.UpdateSelf(gameTime);
            foreach (Enemy e in Level.EngagedEnemies)
            {
                if (e.GlobalPosition == this.GlobalPosition)
                {
                    //e.DoDamage(Damage);
                    Parent.RemoveChild(this);
                }
            }
        }
        public void Explode() 
        {
            foreach (Enemy e in Level.EngagedEnemies)
            {
                if (ExtensionMethods.PositionIsWithinRange(this.GlobalPosition, e.GlobalPosition, explosiveRange))
                {
                    e.DoDamage(damage);
                    e.Stun = true;
                    Parent.RemoveChild(this);
                }
            }
            this.Velocity = 0;
        }
    }
}
