using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YourEngine
{
    /// <summary>
    /// A texture object that can be easily configured.
    /// </summary>
    public class Sprite : GameObject
    {
        private float opacity = 1;
        private float rotationRadians = 0;
        private Rectangle? sourceRectangle;

        public Sprite(Texture2D texture) : base()
        {
            this.Texture = texture;
        }

        public Texture2D Texture { get; set; }
        /// <summary>
        /// Use for flipping the sprite horizontally or vertically.
        /// This is especially useful if you have a sidescrolling game.
        /// No effect is applied by default.
        /// </summary>
        public SpriteEffects Effects { get; set; } = SpriteEffects.None;
        /// <summary>
        /// The color used to modulate the sprite.
        /// </summary>
        public Color Color { get; set; } = Color.White;
        /// <summary>
        /// The position where the texture will be drawn.
        /// </summary>
        public Vector2 GlobalDrawPosition => this.GlobalPosition - this.ScrollOffset;
        public Vector2 Scale { get; set; } = Vector2.One;
        /// <summary>
        /// How much the sprite is offset compared to its position.
        /// </summary>
        public Vector2 Origin => this.SourceRectangle.GetOrigin(this.OriginType);
        /// <summary>
        /// How the sprite is offset compared to its position.
        /// It is set to top left by default (as you would expect from MonoGame).
        /// </summary>
        public OriginType OriginType { get; set; } = OriginType.TopLeft;
        /// <summary>
        /// How much the sprite is rotated. Monogame uses radians for rotation.
        /// Modulo (2 PI) is applied on a provided value to ensure that values
        /// are always within the range [0, 2 * PI) and correctly converted.
        /// </summary>
        public float AngleRadians
        {
            get => this.rotationRadians;
            set => this.rotationRadians = value.Modulo(2 * MathF.PI);
        }
        /// <summary>
        /// How much the sprite is rotated.
        /// This is an alternative to RotationRadians.
        /// It is a bit more slow, because of conversions between DEG and RAD.
        /// </summary>
        public float AngleDegrees
        {
            get => MathHelper.ToDegrees(this.AngleRadians);
            set => this.AngleRadians = MathHelper.ToRadians(value.Modulo(360));
        }
        /// <summary>
        /// The portion of the sprite that is drawn.
        /// Set this if the texture is a sprite sheet.
        /// If the value is null, then the whole texture is drawn.
        /// </summary>
        public Rectangle SourceRectangle
        {
            // https://stackoverflow.com/questions/446835/what-do-two-question-marks-together-mean-in-c
            get => this.sourceRectangle ?? this.Texture.Bounds;
            set => this.sourceRectangle = value;
        }
        /// <summary>
        /// Determines how opaque the sprite is. Opacity is an antonym for transparency.
        /// A value of 1 means absolutely no transparency. A value of 0 means full transparency.
        /// Values that exceed the range are clamped automatically.
        /// </summary>
        public float Opacity
        {
            get => this.opacity;
            set => this.opacity = value.Clamp(0, 1);
        }
        /// <summary>
        /// The inverse of Opacity. Determines how transparent the sprite is.
        /// A value of 1 means absolutely full transparency. A value of 0 means no transparency.
        /// Values that exceed the range are clamped automatically.
        /// </summary>
        public float Transparency
        {
            get => 1 - this.Opacity;
            set => this.opacity = 1 - value.Clamp(0, 1);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture: this.Texture,
                position: this.GlobalDrawPosition,
                sourceRectangle: this.SourceRectangle,
                color: this.Color * this.Opacity,
                rotation: this.AngleRadians,
                origin: this.Origin,
                scale: this.Scale,
                effects: this.Effects,
                layerDepth: this.DrawLayer
                );
        }
    }
}
