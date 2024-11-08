using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using YourEngine;

namespace YourGame
{
    public abstract class Weapons : GameObject
    {
        protected Sprite sprite;
        bool flipped;
        public double Angle {  get; private set; }

        protected bool striking;
        public Weapons(string spritename) 
        {
            this.sprite = new Sprite(YourGame.AssetManager.LoadTexture(spritename));
            this.sprite.OriginType = OriginType.CenterRight;
            this.AddChild(this.sprite);
            striking = false;
            flipped = false;
        }
        protected override void UpdateSelf(GameTime gameTime) 
        { 
            this.sprite.AngleRadians = ExtensionMethods.CalcRotationToMouse(YourGame.GetMouseWorldPosition(), GlobalPosition);
            this.Angle = this.sprite.AngleRadians;
            if (Angle > 0.5*MathF.PI && Angle < 1.5*MathF.PI)
            {
                sprite.Effects = SpriteEffects.FlipVertically;
                flipped = true;
            }
            else
            {
                sprite.Effects = SpriteEffects.None;
                flipped = false;
            }

            if (YourGame.InputManager.HoldLeftClickMouse)
                striking = true;
            else striking = false;
        }
    }
}
