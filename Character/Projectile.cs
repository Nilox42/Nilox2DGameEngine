using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Core;
using Nilox2DGameEngine.Util;

namespace Nilox2DGameEngine.Character
{
    class Projectile
    {
        Sprite2D sprite;
        Vector2 location = Vector2.Zero();

        Vector2 direction = Vector2.Zero();
        int speed = 0;

        public Projectile(Sprite2D sprite0, Vector2 location0 , Vector2 direction0 , int speed0) 
        {
            sprite = sprite0;
            location = location0;
            direction = direction0;
            speed = speed0;
        }

        public void move()
        {
            Vector2 tomove = direction * speed; 
        }


    }
}
