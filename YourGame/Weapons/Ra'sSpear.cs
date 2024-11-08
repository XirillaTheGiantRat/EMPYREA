using Microsoft.Xna.Framework;
using System;
using YourEngine;
using YourGame.States;

namespace YourGame
{
    sealed class RasSpear : Weapons
    {
        const int damage = 200;
        const int meleeRange = 50;
        public RasSpear() : base ("Spear") 
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
                Shoot();
            }
        }
        void Strike()
        {
            foreach (Enemy e in Level.EngagedEnemies)
            {
                if (ExtensionMethods.PositionIsWithinRange(this.GlobalPosition, e.GlobalPosition, meleeRange))
                {
                    e.DoDamage(damage);
                }
            }
        }

        void Shoot()
        {
            SunProjectile s = new SunProjectile(YourGame.GetMouseWorldPosition() - this.GlobalPosition, damage);
            this.AddChild(s);
        }
    }
}
