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

        Sprite2D sprite = null;
        Vector2 location = Vector2.Zero();

        double health = 100;

        float maxwalkspeed = 1;

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
        
        public void move(Vector2 playerlocation0)
        {
<<<<<<< HEAD
            //Movement
            if(sprite.IsCollidingWithTag("collider") == null && hastarget == true)
            {
                Vector2 direction = Vector2.Normalize(location - player0.location);

                location = location + (direction * maxwalkspeed);
=======
            /*
            float y = Vector2.steigung(location, playerlocation0);
            location = new Vector2(playerlocation0.X, y);
            */
>>>>>>> bafe96dfec1fecefe42050b06398ae0af5e567bc

            Vector2 place = location - (playerlocation0);
            location = location + place / -25;

            updatesprite();
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
