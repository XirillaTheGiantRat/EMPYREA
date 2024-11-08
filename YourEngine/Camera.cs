using Microsoft.Xna.Framework;

namespace YourEngine
{
    public static class Camera 
    {
        public static Vector2 position;


        static Camera()
        {
        }

        public static void Update(Vector2 playerPos, Vector2 screensize)
        {
            position = playerPos - screensize / 2;
        }

    }
}
