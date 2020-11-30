using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Core;
using Nilox2DGameEngine.Util;

namespace Nilox2DGameEngine.Character
{
    interface DamageInterface
    {
        void TakeDamage(int damage0);
    }


    public class Enemy:DamageInterface
    {
        int index = 0;

        TestGameMode tgm = null;

        public Sprite2D sprite = null;
        Vector2 location = Vector2.Zero();

        double health = 100;

        float maxwalkspeed = 1;
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
            health = health - damage0;
        }
        
        public void aiTick(Sprite2D player0)
        {

            //Movement
            if (sprite.IsCollidingWithTag("collider") == null && hastarget == true)
            {
                Vector2 direction = Vector2.Normalize(location - player0.location);

                location = location + (direction * maxwalkspeed);


                updatesprite();
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
