using Microsoft.Xna.Framework;
using System;

namespace YourGame
{
    sealed class Musket : RangedWeapons
    {
        const int minDamage = 50;
        const int maxDamage = 200;
        public Musket() : base(1,(float)2.5,1,50, "Weapons/mosinnagant")
        {
            damage = YourGame.Random.Next(minDamage, maxDamage + 1);
        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            base.UpdateSelf(gameTime);
            if (striking)
            {
                damage = YourGame.Random.Next(minDamage, maxDamage + 1);
            }
        }
    }
}
