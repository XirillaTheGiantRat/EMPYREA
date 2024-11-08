using YourEngine;
using YourGame.Objects;

namespace YourGame
{
    public sealed class Blueprint : GameObject
    {
        Sprite bp;
        Weapons weapon;
        public bool Unlocked {  get; private set; }

        int materials;
        public Blueprint(Weapons bpweapon, int craftingMaterials, bool unlocked, string texturename)
        {
            weapon = bpweapon;
            materials = craftingMaterials;
            bp = new Sprite(YourGame.AssetManager.LoadTexture(texturename));
            this.AddChild(bp);
            Unlocked = unlocked;
        }
        public void Craft(int amountOfMaterials, Player2 player)
        {
            if(amountOfMaterials >= materials)
            {
                player.PickUp1(weapon);
                player.CraftingMaterials -= materials;
            }
            else
            {

            }
        }
    }
}
