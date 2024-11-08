namespace YourGame
{
    sealed class TieredAOEWeapon : AOEWeapons
    {
        public enum AOETier
        {
            TierI,
            TierII,
            TierIII
        }
        AOETier tier;
        public TieredAOEWeapon(float reloadSpeed, int explosiveRange, AOETier tier, string spritename, int ammoCount = 0)
    : base(reloadSpeed, explosiveRange, spritename, ammoCount)
        {
            this.tier = tier;
            if (tier == AOETier.TierI)
            {
                if (explosiveRange > 15)
                {
                    this.explosiveRange = 15;
                }
                if (damage > 25)
                {
                    this.damage = 25;
                }
            }
            else if (tier == AOETier.TierII)
            {
                if (explosiveRange > 25)
                {
                    this.explosiveRange = 25;
                }
                if (damage > 50)
                {
                    this.damage = 50;
                }
            }
            else
            {
                if (explosiveRange > 50)
                {
                    this.explosiveRange = 50;
                }
                if (damage > 150)
                {
                    this.damage = 150;
                }
            }
        }
    }
}
