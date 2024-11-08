using Microsoft.Xna.Framework;

namespace YourGame
{
    sealed class Pipebomb : AOEWeapons
    {
        const int minDamage = 50;
        const int maxDamage = 200;
        public Pipebomb() : base(5, 25, "Weapons/pipebomb")
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
