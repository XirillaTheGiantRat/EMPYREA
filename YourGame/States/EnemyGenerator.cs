
using Microsoft.Xna.Framework;
using YourEngine;
using YourGame.Objects;

namespace YourGame.States
{ 

    public class EnemyGenerator : State
    {
        public Sprite background;
        public Rectangle SourceRectangle;
        public Point size, location;
        public Enemy enemy;
        public Tier1RangedEnemy tier1RangedEnemy;
        public Tier2RangedEnemy tier2RangedEnemy;
        public Tier3RangedEnemy tier3RangedEnemy;
        public Tier1MeleeEnemy tier1MeleeEnemy;
        public Tier2MeleeEnemy tier2MeleeEnemy;
        public Tier3MeleeEnemy tier3MeleeEnemy;
        public Tier1AOEEnemy tier1AOEEnemy;
        public Tier2AOEEnemy tier2AOEEnemy;
        public Tier3AOEEnemy tier3AOEEnemy;
        public Player2 player;
        

        public EnemyGenerator()
        {
            this.background = new Sprite(YourGame.AssetManager.LoadTexture("backgroundcolour"))
            {
                GlobalPosition = YourGame.ScreenSize.ToVector2() / 2,
                SourceRectangle = new Rectangle(
                    location: new Point(200, 200),
                    size: new Point(1920, 1080)
                    ),
                OriginType = OriginType.Center
            };
            this.AddChild(background);
            player = new Player2();
            this.AddChild(player);
            /* tier1MeleeEnemy = new Tier1MeleeEnemy();
             tier2MeleeEnemy = new Tier2MeleeEnemy();
             tier3MeleeEnemy = new Tier3MeleeEnemy();
             this.AddChild(tier1MeleeEnemy);
             this.AddChild(tier2MeleeEnemy);
             this.AddChild(tier3MeleeEnemy);

             tier1RangedEnemy = new Tier1RangedEnemy();
             tier2RangedEnemy = new Tier2RangedEnemy();
             tier3RangedEnemy = new Tier3RangedEnemy();
             this.AddChild(tier1RangedEnemy);
             this.AddChild(tier2RangedEnemy);
             this.AddChild(tier3RangedEnemy);*/

            //tier1AOEEnemy = new Tier1AOEEnemy();
            //tier2AOEEnemy = new Tier2AOEEnemy();
            tier3AOEEnemy = new Tier3AOEEnemy();
            //this.AddChild(tier1AOEEnemy);
            //this.AddChild(tier2AOEEnemy);
            this.AddChild(tier3AOEEnemy);
        }
    }
}
