using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Core;
using Nilox2DGameEngine.Util;

namespace Nilox2DGameEngine.Character
{
    interface IDamageInterface
    {
        void TakeDamage(int damage0);

        void Death();
    }


    public class Enemy:IDamageInterface
    {
        int index = 0;

        TestGameMode tgm = null;

        public Sprite2D sprite = null;
        Vector2 location = Vector2.Zero();

        double health = 1;

        double maxwalkspeed = 2;
        bool hastarget = true;

        //Vector2 playerlocation = Vector2.Zero();

        public Enemy(Sprite2D sprite0 , Vector2 location0 , TestGameMode GM)
        {
            sprite = sprite0;
            location = location0;
            tgm = GM;


        }

        private void updatesprite()
        {
            sprite.location = location;

        }




        public void TakeDamage(int damage0)
        {
            health -= damage0;

            Log.Info("[DAMAGE] - [ENEMY] - " + damage0);

            if (health <= 0)
            {
                Death();
            }
        }
        public void Death()
        {
            Log.Error("[ENEMIE] - [REMOVED] -DIIIIIIIIIEEEEEEED");
         
            tgm.desroyEnemie(this);
        }

        public void aiTick(Sprite2D player0)
        {

            //Movement
            if (sprite.IsCollidingWithTag("collider") == null && hastarget == true)
            {
                if (Vector2.Lenght(location - player0.location) > 10)
                {
                    Vector2 direction = Vector2.Normalize(location - player0.location);

                    location += (direction * maxwalkspeed * -1);

                    updatesprite();
                }
            }
        }


        public void Shoot()
        {
            if (index > 120)
            {
                tgm.spawnProjectile(location);
                index = 0;
            }
            index++;
        }

        
    }
}
