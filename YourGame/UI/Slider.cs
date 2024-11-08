using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using YourEngine;

namespace YourGame
{
    public sealed class Slider : GameObject
    {
        Sprite slider, sliderthing;
        float minValue, maxValue;
        public float Width { get { return slider.Texture.Width; } }
        public float Height { get { return slider.Texture.Height; } }
        public Slider(Texture2D slider, Texture2D sliderthing, float minValue = 0, float maxValue = 1) 
        { 
            this.slider = new Sprite(slider);
            this.AddChild(this.slider);
            this.sliderthing = new Sprite(sliderthing);
            this.sliderthing.OriginType = OriginType.Center;
            this.AddChild(this.sliderthing);
            this.minValue = minValue;
            this.maxValue = maxValue;
        }
        protected override void UpdateSelf(GameTime gameTime)
        {
            if(YourGame.InputManager.HoldLeftClickMouse && sliderRectangel.Contains(YourGame.GetMouseWorldPosition()))
            {
                float newx = YourGame.GetMouseWorldPosition().X - GlobalPosition.X;
                CurrentValue = CalcValue(newx);
                newx += slider.GlobalPosition.X;
                sliderthing.GlobalPosition = new Vector2(newx, sliderthing.GlobalPosition.Y);
            }
        }
        public float CurrentValue { get; private set; }
        private Rectangle sliderRectangel
        {
            get
            {
            return new Rectangle(
            (int)GlobalPosition.X,
            (int)(GlobalPosition.Y - 2 *sliderthing.Texture.Height),
            slider.Texture.Width,
            2*sliderthing.Texture.Height);
            }
        }
        float CalcValue(float value)
        {
            float currentVal = value + minValue;
            currentVal = ExtensionMethods.Clamp(currentVal, minValue, maxValue);
            return currentVal;
        }
    }
}
