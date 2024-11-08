using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace YourEngine
{
    /// <summary>
    /// Handles asset loading. Feel free to expand/change this.
    /// </summary>
    public sealed class AssetManager
    {
        private readonly ContentManager contentManager;

        public AssetManager(ContentManager concentManager) : base()
        {
            this.contentManager = concentManager;
        }

        public Texture2D LoadTexture(string spriteName, string basePath = "")
        {
            return this.contentManager.Load<Texture2D>(basePath + spriteName);
        }

        public SpriteFont LoadFont(string fontName, string basePath = "")
        {
            return this.contentManager.Load<SpriteFont>(basePath + fontName);
        }

        public SoundEffect LoadSoundEffect(string soundEffectName, string basePath = "")
        {
            return this.contentManager.Load<SoundEffect>(basePath + soundEffectName);
        }

        public Song LoadSong(string songName, string basePath = "")
        {
            return this.contentManager.Load<Song>(basePath + songName);
        }
    }
}