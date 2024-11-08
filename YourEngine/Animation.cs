using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YourEngine
{
    public sealed class Animation : GameObject
    {
        Texture2D animationSheet;
        Rectangle? sourceRectangle;
        int amountOfSprites, index;
        float rotationRadians, time;
        public Animation(Texture2D animationSheet, int amountOfSprites)
        {
            this.animationSheet = animationSheet;
            this.amountOfSprites = amountOfSprites;
            index = 0;
            time = 0;
        }
        public int Width { get { return this.animationSheet.Width / amountOfSprites; } }
        public int Height { get { return this.animationSheet.Height; } }
        public OriginType OriginType { get; set; } = OriginType.Center;
        public SpriteEffects SpriteEffects { get; set; } = SpriteEffects.None;
        public float AngleRadians
        {
            get => this.rotationRadians;
            set => this.rotationRadians = value.Modulo(2 * MathF.PI);
        }
        public Vector2 Scale { get; set; } = Vector2.One;
        public Rectangle SourceRectangle
        {
            get => this.sourceRectangle ?? this.animationSheet.Bounds;
            private set => this.sourceRectangle = value;
        }
        public Vector2 Origin => this.SourceRectangle.GetOrigin(this.OriginType);
        public bool Run { get; set; } = false;
        public bool Repeat { get; set; } = true;
        public bool HasFinished { get; private set; } = false;
        public float TimePerFrame { get; set; } = 0.5f;
        protected override void UpdateSelf(GameTime gameTime)
        {
            if (Run)
            {
                SourceRectangle = new Rectangle(index * Width, 0, Width, Height);
                time += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if(time >= TimePerFrame && index == amountOfSprites -1)
                {
                    Run = false;
                    if (Repeat)
                    {
                        index = 0;
                        time = 0;
                        Run = true;
                    }
                    else HasFinished = true;
                }
                else
                {
                    if(time >= TimePerFrame)
                    {
                        index++;
                        time -= TimePerFrame;
                    }
                }
            }
        }
        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            if (Run)
            {
                spriteBatch.Draw(animationSheet, GlobalPosition, SourceRectangle,
                    Color.White, AngleRadians, Origin, Scale, SpriteEffects, this.DrawLayer);
            }
        }
    }
}
