using YourEngine;

namespace YourGame
{
    sealed class TieredMeleeWeapon : MeleeWeapons
    {
        public enum MeleeTier
        {
            TierI,
            TierII,
            TierIII
        }
        MeleeTier tier;
        public TieredMeleeWeapon(int damage, int range, float strikeSpeed, MeleeTier tier, string spritename)
            :base(damage, range, strikeSpeed, spritename)
        {
            this.tier = tier;
            if (tier == MeleeTier.TierI)
            {
                if (strikeSpeed < 0.33)
                {
                    this.strikeSpeed = new Timer((float)0.33);
                }
                if (damage > 25)
                {
                    this.Damage = 25;
                }
            }
            else if (tier == MeleeTier.TierII)
            {
                if (strikeSpeed < 0.16)
                {
                    this.strikeSpeed = new Timer((float)0.16);
                }
                if (damage > 50)
                {
                    this.Damage = 50;
                }
            }
            else
            {
                if (strikeSpeed < 0.05)
                {
                    this.strikeSpeed = new Timer((float)0.05);
                }
                if (damage > 150)
                {
                    this.Damage = 150;
                }
            }
        }
    }
}
