using YourEngine;
using Microsoft.Xna.Framework;
using System;
using YourGame.States;
using System.Text;

namespace YourGame
{
    sealed class ThorsHammer : Weapons
    {
        const int meleeRange = 50;
        const int shockwaveRange = 100;
        const int damage = 200;
        Sprite blast; //animation
        public ThorsHammer() : base("Hammer")
        {
            blast = new Sprite(YourGame.AssetManager.LoadTexture("blast"));
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
                Smash();
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
        void Smash()
        {
            foreach (Enemy e in Level.EngagedEnemies)
            {
                if (ExtensionMethods.PositionIsWithinRange(this.GlobalPosition, e.GlobalPosition, shockwaveRange))
                {
                    e.DoDamage(damage);
                    e.Shock = true;
                }
            }
        }
    }
}
