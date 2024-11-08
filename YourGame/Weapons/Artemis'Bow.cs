

using Microsoft.Xna.Framework;
using YourEngine;

namespace YourGame
{
    sealed class ArtemisBow : Weapons
    {
        const int damage = 200;
        const int explosiveRange = 50;
        Arrow arrow;
        public ArtemisBow() : base("bow")
        { 

        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            base.UpdateSelf(gameTime);
            if (YourGame.InputManager.HasMouseJustLeftClicked)
            {
                Shoot();
            }
            if (YourGame.InputManager.HasMouseJustRightClicked)
            {
                if (arrow != null)
                {
                    arrow.Explode();
                }
            }
        }
        void Shoot()
        {
            arrow = new Arrow(YourGame.GetMouseWorldPosition() - this.GlobalPosition, explosiveRange, damage);
            this.AddChild(arrow);
        }
    }
}
