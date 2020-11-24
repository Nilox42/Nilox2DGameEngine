﻿using System;
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
        Vector2 lastlocation = Vector2.Zero();

        double health = 100;

        Vector2 velocity = new Vector2(2,2);

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
        
        public void move(Sprite2D player0)
        {
            if(sprite.IsCollidingWithTag("collider") == null)
            {
                Vector2 place = location - player0.location;
                location = location + place / -30;

                lastlocation = location;
                updatesprite();
            }
            else
            {

                location = lastlocation;

                Log.Warning("Colliding");
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
