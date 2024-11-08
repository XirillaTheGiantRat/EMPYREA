using Microsoft.Xna.Framework;
using YourEngine;

namespace YourGame
{
    public class Tier3AOEEnemy : AOEEnemy
    {
        Exploxive miniExploxive1, miniExploxive2, miniExploxive3, miniExploxive4, miniExploxive5, miniExploxive6;
        Vector2 miniExploxiveDirection1, miniExploxiveDirection2, miniExploxiveDirection3, miniExploxiveDirection4, miniExploxiveDirection5, miniExploxiveDirection6;
        bool clusterExploding;
        
        
        public Tier3AOEEnemy() : base(200, 3, 60, 60, "Enemies/cyclops")
        {
            miniExploxiveDirection1 = new Vector2(1, 50);    //down
            miniExploxiveDirection2 = new Vector2(-41, 25);  //down left
            miniExploxiveDirection3 = new Vector2(-41, -25); //up left
            miniExploxiveDirection4 = new Vector2(1, -50);   //up
            miniExploxiveDirection5 = new Vector2(41, -25);  //up right
            miniExploxiveDirection6 = new Vector2(41, 25);   //down right

        }
        protected override void UpdateSelf(GameTime gametime)
        {
            ChasePlayer();
            DistanceToPlayer();
            FireRate.Update((float)gametime.ElapsedGameTime.TotalSeconds);
            if (FireRate.IsFinished)
            {
                Shoot();
                clusterExploding = false;
                
            
            }
            if (exploxive != null && exploxive.Exploding == true && !clusterExploding)
            {
                clusterExploding = true;
                miniExploxive1 = new Exploxive(20, 20, 0.5f, miniExploxiveDirection1, "Enemies/enemybomb");
                miniExploxive2 = new Exploxive(20, 20, 0.5f, miniExploxiveDirection2, "Enemies/enemybomb");
                miniExploxive3 = new Exploxive(20, 20, 0.5f, miniExploxiveDirection3, "Enemies/enemybomb");
                miniExploxive4 = new Exploxive(20, 20, 0.5f, miniExploxiveDirection4, "Enemies/enemybomb");
                miniExploxive5 = new Exploxive(20, 20, 0.5f, miniExploxiveDirection5, "Enemies/enemybomb");
                miniExploxive6 = new Exploxive(20, 20, 0.5f, miniExploxiveDirection6, "Enemies/enemybomb");
                exploxive.AddChild(miniExploxive1);
                exploxive.AddChild(miniExploxive2);
                exploxive.AddChild(miniExploxive3);
                exploxive.AddChild(miniExploxive4);
                exploxive.AddChild(miniExploxive5);
                exploxive.AddChild(miniExploxive6);

               /* if (clusterExploding);
                {
                    exploxive.RemoveAllChildren();
                }*/
                //als alle minis exploded, removechild(exploxive) ook in tier 1 en 2
            }
        }
    }
}
