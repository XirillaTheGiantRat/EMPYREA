using Microsoft.Xna.Framework;
using YourEngine;
using YourGame.States;

namespace YourGame
{
    sealed class Scythe : Weapons
    {
        const int meleeDamage = 300;
        const int meleeRange = 50;
        public Scythe() : base("scythe")
        {

        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            base.UpdateSelf(gameTime);
            if (YourGame.InputManager.HasMouseJustLeftClicked)
            {
                Strike();
            }
            if (YourGame.InputManager.HasMouseJustRightClicked)
            {
                LifeSuck();
            }
        }
        void Strike()
        {
            foreach (Enemy e in Level.EngagedEnemies)
            {
                if (ExtensionMethods.PositionIsWithinRange(this.GlobalPosition, e.GlobalPosition, meleeRange))
                {
                    e.DoDamage(meleeDamage); 
                    e.FireDamage = true;
                }
            }
        }
        void LifeSuck()
        {
            //Heal from enemies (cooldown?)
        }
    }
}
