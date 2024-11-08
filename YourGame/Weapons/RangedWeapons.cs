using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using YourEngine;

namespace YourGame
{
    abstract class RangedWeapons : Weapons
    {
        protected int ammoCount, currentAmmo, accuracy, damage;
        protected Timer reloadSpeed, fireRate;

        bool reloading;
        /// <summary>
        /// Accuracy will be rounded to max 80 and min 0!
        /// </summary>
        /// <param name="ammoCount"></param>
        /// <param name="reloadSpeed"></param>
        /// <param name="fireRate"></param>
        /// <param name="accuracy"></param>
        public RangedWeapons(int ammoCount, float reloadSpeed, float fireRate, int accuracy, string spritename) : base(spritename)
        {
            this.ammoCount = ammoCount;
            this.reloadSpeed = new Timer(reloadSpeed);
            this.reloadSpeed.RestartsOnFinish = false;
            this.fireRate = new Timer(fireRate);
            this.accuracy = accuracy;
            if (accuracy < 0)
                this.accuracy = 0;
            if (accuracy > 80)
                this.accuracy = 80;
            currentAmmo = ammoCount;
            reloading = false;
        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            reloadSpeed.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            base.UpdateSelf(gameTime);
            if (striking && !reloading)
            {
                if (fireRate.HasStarted)
                {
                    Shoot();
                    striking = false;
                }
                fireRate.Update((float)gameTime.ElapsedGameTime.TotalSeconds);
            }
            else if (currentAmmo <= 0 && !reloading)
            {
                reloadSpeed.Restart();
                reloading = true;
            }
            else if (reloading)
            {
                if (reloadSpeed.IsFinished)
                {
                    reloading = false;
                    currentAmmo = ammoCount;
                }
            }
        }
        void Shoot()
        {
            currentAmmo--;
            Bullet b = new Bullet(damage, CalcDirection());
            this.AddChild(b);
        }
        Vector2 CalcDirection()
        {
            if (accuracy <= 100 && accuracy >= 0)
            {
                float accmod = 1 + accuracy / 100;
                float direction = this.sprite.AngleRadians + (1 / 8) * MathF.PI * accmod;
                direction = direction + direction * YourGame.Random.Next(2) * -1;
                float vertcomp = (float)Math.Sin(direction);
                float horcomp = (float)Math.Cos(direction);
                return new Vector2(vertcomp, horcomp);
            }
            else return Vector2.Zero;
        }
    }
}
