using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YourEngine
{
    /// <summary>
    /// For you to implement! A typical core feature.
    /// Almost every game requires collision detection and it makes sense for such objects
    /// to inherit from GameObject, since they can be part of another entity (e.g.
    /// a Player HAS a hitbox that moves with it) or be textured (e.g. a Wall HAS a Sprite).
    /// Doing so makes positioning easier. You already got a bit of experience during Gameprogrammeren.
    /// Just remember that collision detection and collision handling are very different things.
    /// How are you going to handle those? So much designing to do! Feel free to do whatever
    /// you think is right.
    /// </summary>
    public class Area : GameObject
    {
        public Area() : base()
        {


        }

        public static bool ShapesIntersect(Rectangle boundingBox1, Rectangle boundingBox2)
        {
            return boundingBox1.Intersects(boundingBox2);
        }

        protected override void EnterSelf()
        {
            //
        }

        protected override void UpdateSelf(GameTime gameTime)
        {
            //
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            // You can color Rectangle instances with MonoGame I am sure.
            // That could be useful for debugging.
        }

        protected override void ExitSelf()
        {
            //
        }
    }
}
