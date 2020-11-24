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
        TestGameMode tgm = null;

        Sprite2D sprite = null;
        Vector2 location = Vector2.Zero();
        Vector2 lastlocation = Vector2.Zero();

        double health = 100;

        Vector2 velocity = new Vector2(2,2);


        //AI
        bool hastarget = true;

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
            if(sprite.IsCollidingWithTag("collider") == null && hastarget == true)
            {
                Vector2 place = location - player0.location;
                location = location + place / -30;

                lastlocation = location;
                updatesprite();
            }
            else
            {
                location = lastlocation;
                hastarget = false;
            }

            


        }


        public void Shoot()
        {
            tgm.spawnProjectile(location);
        }
    }
}
