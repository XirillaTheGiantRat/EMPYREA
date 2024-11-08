using Microsoft.Xna.Framework;
using YourEngine;
using YourGame.Objects;
using YourGame.States;

namespace YourGame
{
    public sealed class Exploxive : GameObject
    {
        int exploxiveRange;
        public int Damage { get; private set; }
        const int velocity = 100;
        public bool Exploding { get; private set; }

        Sprite sprite;
        Animation exploxion;
        public GameObject Object { get; set; } = null;

        Timer timer;

        public Exploxive(int damage, int Explosionrange, float Exploxiontimer, Vector2 direction, string spritename)
        {
            this.exploxiveRange = Explosionrange;
            this.Direction = direction;
            this.Velocity = velocity;
            Damage = damage;
            this.timer = new Timer(Exploxiontimer);
            timer.RestartsOnFinish = false;
            this.sprite = new Sprite(YourGame.AssetManager.LoadTexture(spritename));
            this.exploxion = new Animation(YourGame.AssetManager.LoadTexture("Weapons/exploxion"), 10);
            exploxion.Repeat = false;
            exploxion.TimePerFrame = 0.05f;
            Exploding = false;
            this.AddChild(exploxion);
            this.AddChild(sprite);
        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            base.UpdateSelf(gameTime);
            timer.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            if (timer.IsFinished)
            {
                
                Explode();
            }
            if (Object is Enemy)
            {
                foreach(Player2 p in Level.PlayerList)
                {
                    if (p.playerBox.Contains(this.GlobalPosition))
                    {
                        Explode();
                    }
                }
            }
            else
            {
                foreach (Enemy e in Level.EngagedEnemies)
                {
                    if (this.GlobalPosition == e.GlobalPosition)
                    {
                        Explode();
                    }
                }
            }
        }
        void Explode()
        {
            this.Velocity = 0;
            Exploding = true;
            sprite.IsVisible = false;
            exploxion.Run = true;
            if(Object is Enemy)
            {
                foreach (Player2 p in Level.PlayerList)
                {
                    if (ExtensionMethods.PositionIsWithinRange(this.GlobalPosition, p.GlobalPosition, exploxiveRange))
                    {
                        p.DoDamage(Damage);
                    }
                }
            }
            else {
                foreach (Enemy e in Level.EngagedEnemies)
                {
                    if (ExtensionMethods.PositionIsWithinRange(this.GlobalPosition, e.GlobalPosition, exploxiveRange))
                    {
                        e.DoDamage(Damage);

                    }
                } }
            if (exploxion.HasFinished)
            {
                
                if (Object is Enemy) 
                {
                    return;
                }
                Parent.RemoveChild(this);
            }
        }
    }
        
}
