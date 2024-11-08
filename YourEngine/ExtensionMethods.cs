using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YourEngine
{
    /// <summary>
    /// Extension methods (a C# feature) tutorial:
    /// https://youtu.be/iI9sfsMIZE8?si=BiIvFZPkBDeTZLw1
    /// This is helpful for classes that we cannot extend without writing a "wrapper class".
    /// Using extension methods avoids explicit static method calls, which can make
    /// code less readable.
    /// </summary>
    public static class ExtensionMethods
    {
        static ExtensionMethods()
        {
        }

        public static float Clamp(this float value, float min, float max)
        {
            return Math.Clamp(value, min, max);
        }

        public static int Clamp(this int value, int min, int max)
        {
            return Math.Clamp(value, min, max);
        }

        public static Vector2 Absolute(this Vector2 value)
        {
            return new Vector2(
                x: MathF.Abs(value.X),
                y: MathF.Abs(value.Y)
                );
        }

        public static float Absolute(this float value)
        {
            return MathF.Abs(value);
        }

        public static Vector2 Normalized(this Vector2 value)
        {
            return Vector2.Normalize(value);
        }

        public static bool IsApproximatelyEqual(this Vector2 value1, Vector2 value2)
        {
            return value1.X.IsApproximatelyEqual(value2.X)
                && value1.Y.IsApproximatelyEqual(value2.Y);
        }

        public static bool IsApproximatelyEqual(this float value1, float value2)
        {
            // Comparing floating-point numbers is not necessarily straightforward.
            // Credit: https://github.com/godotengine/godot/blob/master/core/math/math_funcs.h

            // First, check for exact equality to handle "infinity" values.
            if (value1 == value2)
                return true;

            // Then, check for approximate equality.
            float toleranceMargin = YourMath.Epsilon * MathF.Abs(value1);

            if (toleranceMargin < YourMath.Epsilon)
                toleranceMargin = YourMath.Epsilon;

            return MathF.Abs(value1 - value2) < toleranceMargin;
        }

        public static bool IsApproximatelyEqual(this float value1, float value2, float toleranceMargin)
        {
            return value1 == value2
                || MathF.Abs(value1 - value2) < toleranceMargin;
        }

        public static bool IsApproximatelyZero(this float value)
        {
            return MathF.Abs(value) < YourMath.Epsilon;
        }

        public static bool IsApproximatelyZero(this Vector2 value)
        {
            return value.X.IsApproximatelyZero() && value.Y.IsApproximatelyZero();
        }

        /// <summary>
        /// Recall that % is the remainder operator and technically not modulo.
        /// </summary>
        /// <param name="l">The dividend.</param>
        /// <param name="r">The divisor.</param>
        /// <returns>The remainder of l divided by r (l mod r).</returns>
        public static float Modulo(this float l, float r)
        {
            // Implementation is the same as:
            // https://stackoverflow.com/questions/1082917/mod-of-negative-number-is-melting-my-brain
            return ((l % r) + r) % r;
        }
        /// <summary>
        /// A convenient way to retrieve the time between the previous and current frame as a float.
        /// </summary>
        /// <param name="gameTime">An instance of GameTime provided by MonoGame's Update method.</param>
        /// <returns></returns>
        public static float Delta(this GameTime gameTime)
        {
            return (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        /// <summary>
        /// A convenient way to retrieve the total game time in seconds as a float.
        /// </summary>
        /// <param name="gameTime">An instance of GameTime provided by MonoGame's Update method.</param>
        /// <returns></returns>
        public static float TotalGameTimeInSeconds(this GameTime gameTime)
        {
            return (float)gameTime.TotalGameTime.TotalSeconds;
        }

        public static Texture2D CreateFlatTexture(this GraphicsDevice graphicsDevice, int width, int height, Color color)
        {
            Texture2D flatTexture = new Texture2D(graphicsDevice, width, height);
            Color[] colors = new Color[width * height];

            for (int i = 0; i < colors.Length; ++i)
                colors[i] = color;

            flatTexture.SetData(colors);
            return flatTexture;
        }

        public static Texture2D CreateFlatTexture(this GraphicsDevice graphicsDevice, Rectangle rectangle, Color color)
        {
            return CreateFlatTexture(graphicsDevice, rectangle.Width, rectangle.Height, color);
        }

        /// <summary>
        /// Calculates how much a sprite should be offset compared to its position (Dutch: "aangrijpspunt").
        /// </summary>
        /// <param name="rectangle">Typically the source rectangle of a Sprite instance.</param>
        /// <param name="offsetType">The origin type.</param>
        /// <returns></returns>
        public static Vector2 GetOrigin(this Rectangle rectangle, OriginType offsetType)
        {
            switch (offsetType)
            {
                // Top.
                default:
                case OriginType.TopLeft:
                    return Vector2.Zero;
                case OriginType.TopCenter:
                    return Vector2.UnitX * (rectangle.Width / 2f);
                case OriginType.TopRight:
                    return Vector2.UnitX * rectangle.Width;
                // Center.
                case OriginType.CenterLeft:
                    return Vector2.UnitY * (rectangle.Height / 2f);
                case OriginType.Center:
                    return new Vector2(rectangle.Width / 2f, rectangle.Height / 2f);
                case OriginType.CenterRight:
                    return new Vector2(rectangle.Width, rectangle.Height / 2f);
                // Bottom.
                case OriginType.BottomLeft:
                    return Vector2.UnitY * rectangle.Height;
                case OriginType.BottomCenter:
                    return new Vector2(rectangle.Width / 2f, rectangle.Height);
                case OriginType.BottomRight:
                    return new Vector2(rectangle.Width, rectangle.Height);
            }
        }
        /// <summary>
        /// This method calculates the rotation in radian from the origin of a sprite to the mouse position.
        /// </summary>
        /// <param name="mouseposition"></param>
        /// <param name="position"></param>
        /// <returns></returns>
        public static float CalcRotationToMouse(Vector2 mouseposition, Vector2 position)
        {
            return (float)Math.Atan2(position.Y - mouseposition.Y, position.X - mouseposition.X);
        }
        /// <summary>
        /// Reads text from file and produces dictionary that can be used for dialogue system
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static Dictionary<int,string> ReadDialogueFromFile(string filename)
        {
            Dictionary<int,string> dialogueDictionary = new Dictionary<int,string>();
            StreamReader reader = new StreamReader(filename);
            string line = reader.ReadLine();
            int index = 0;
            while (line != null)
            {
                dialogueDictionary.Add(index, line);
                index++;
                line = reader.ReadLine();
            }
            reader.Close();
            return dialogueDictionary;
        }
        public static bool PositionIsWithinRange(Vector2 originPosition, Vector2 objectPosition, int range)
        {
            int distance = (int)Vector2.Distance(originPosition, objectPosition);
            return distance < range && distance > -range;
        }
    }
}
