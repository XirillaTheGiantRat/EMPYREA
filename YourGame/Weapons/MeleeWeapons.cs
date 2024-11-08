using Microsoft.Xna.Framework;
using YourEngine;
using YourGame.States;

namespace YourGame
{
    abstract class MeleeWeapons : Weapons
    {
        int meleeRange;
        public int Damage { get; protected set; }
        protected Timer strikeSpeed;
        public MeleeWeapons(int damage, int range, float strikeSpeed, string spritename) : base(spritename)
        { 
            this.strikeSpeed = new Timer(strikeSpeed);
            this.Damage = damage;
            this.meleeRange = range;
        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            base.UpdateSelf(gameTime);
            strikeSpeed.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            if (striking)
            {
                if(strikeSpeed.HasStarted)
                {
                    Strike();
                    striking = false;
                }
            }
        }
        void Strike()
        {
            foreach (Enemy e in Level.EngagedEnemies)
            {
                if (ExtensionMethods.PositionIsWithinRange(this.GlobalPosition, e.GlobalPosition, meleeRange))
                {
                    e.DoDamage(Damage); 
                }
            }
        }
    }
}
