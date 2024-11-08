using Microsoft.Xna.Framework;
using YourEngine;

namespace YourGame
{
    abstract class AOEWeapons : Weapons
    {
        Timer reloadSpeed, fireRate;
        int  ammoCount, currentAmmoCount;
        protected int damage, explosiveRange;
        bool reloading;
        string spritename;
        public AOEWeapons(float reloadSpeed, int explosiveRange, string spritename, int ammoCount = 0) : base(spritename) 
        {
            this.reloadSpeed = new Timer(reloadSpeed);
            this.reloadSpeed.RestartsOnFinish = false;
            fireRate = new Timer((float)0.66);
            reloading = false;
            this.ammoCount = ammoCount;
            currentAmmoCount = ammoCount;
            this.explosiveRange = explosiveRange;
            this.spritename = spritename;
        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            reloadSpeed.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            fireRate.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.UpdateSelf(gameTime);
            if (striking && !reloading)
            {
                if (ammoCount > 0)
                {
                    if (fireRate.HasStarted && currentAmmoCount > 0 && !reloading)
                    {
                        Throw();
                        currentAmmoCount--;
                        striking = false;
                    }
                    else if (currentAmmoCount == 0 && !reloading)
                    {
                        reloading = true;
                        reloadSpeed.Restart();
                    }
                }
                else
                {
                    Throw();
                    reloading = true;
                    reloadSpeed.Restart();
                    striking = false;
                }
            }
            else if (reloadSpeed.IsFinished)
            {
                reloading = false;
                currentAmmoCount = ammoCount;
            }
        }
        void Throw()
        {
            Exploxive e = new Exploxive(damage, explosiveRange, 2,
                YourGame.GetMouseWorldPosition() - this.GlobalPosition, spritename);
            this.AddChild(e);
        }
    }
}
