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
        Sprite2D sprite = null;
        Vector2 location = Vector2.Zero();

        double health = 100;

        public Enemy(Sprite2D sprite0 , Vector2 location0)
        {
            sprite = sprite0;
            location = location0;
        }

        public void TakeDamage(int damage0)
        {
            health = health - damage0;
        }
        
        public void move()
        {

        }
    }
}
