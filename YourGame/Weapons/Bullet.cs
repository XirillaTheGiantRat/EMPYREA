using Microsoft.Xna.Framework;
using YourEngine;
using YourGame.Objects;
using YourGame.States;

namespace YourGame
{
    public sealed class Bullet : GameObject
    {
        public int Damage { get; private set; }
        const float velocity = 200;
        Sprite sprite;
        public GameObject Object { get; set; } = null;
        public Bullet(int damage, Vector2 direction) 
        { 
            Damage = damage;
            this.Direction = direction * -1;
            this.Velocity = velocity;
            sprite = new Sprite(YourGame.AssetManager.LoadTexture("Weapons/bullet"));
            this.AddChild(sprite);
        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            base.UpdateSelf(gameTime);
            if (Object is Enemy)
            {
                foreach (Player2 p in Level.PlayerList)
                {
                    if (p.playerBox.Contains(this.GlobalPosition))
                    {
                        p.DoDamage(Damage);
                        Parent.RemoveChild(this);
                    }
                }
            }
            else
            {
                foreach (Enemy e in Level.EngagedEnemies)

                {
                    if (e.GlobalPosition == this.GlobalPosition)
                    {
                        e.DoDamage(Damage);
                        Parent.RemoveChild(this);
                    }
                }
            }
        }
    }
}
