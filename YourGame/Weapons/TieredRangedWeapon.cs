using YourEngine;

namespace YourGame
{
    sealed class TieredRangedWeapon : RangedWeapons
    {
        public enum RangeTier
        {
            TierI,
            TierII,
            TierIII
        }
        RangeTier tier;
        /// <summary>
        /// Dependent on tier damage, firerate and ammocount will be ajusted if more than maximum
        /// </summary>
        /// <param name="ammoCount"></param>
        /// <param name="reloadSpeed"></param>
        /// <param name="fireRate"></param>
        /// <param name="accuracy"></param>
        /// <param name="tier"></param>
        /// <param name="spritename"></param>
        public TieredRangedWeapon(int ammoCount, float reloadSpeed, float fireRate, int accuracy, RangeTier tier, string spritename)
            : base(ammoCount, reloadSpeed, fireRate, accuracy, spritename)
        {
            this.tier = tier;
            if (tier == RangeTier.TierI)
            {
                if (ammoCount > 8)
                {
                    this.ammoCount = 8;
                }
                if (fireRate < 0.33)
                {
                    this.fireRate = new Timer((float)0.33);
                }
                if(damage > 25)
                {
                    this.damage = 25;
                }
            }
            else if (tier == RangeTier.TierII)
            {
                if (ammoCount > 25)
                {
                    this.ammoCount = 25;
                }
                if (fireRate < 0.16)
                {
                    this.fireRate = new Timer((float)0.16);
                }
                if (damage > 50)
                {
                    this.damage = 50;
                }
            }
            else
            {
                if (ammoCount > 35)
                {
                    this.ammoCount = 35;
                }
                if (fireRate < 0.05)
                {
                    this.fireRate = new Timer((float)0.05);
                }
                if (damage > 150)
                {
                    this.damage = 150;
                }
            }
        }
    }
}
