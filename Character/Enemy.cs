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
        Sprite2D sprite = null;
        Vector2 location = Vector2.Zero();

        double health = 100;

        Vector2 velocity = new Vector2(2,2);

        Vector2 playerlocation = Vector2.Zero();

        public Enemy(Sprite2D sprite0 , Vector2 location0)
        {
            sprite = sprite0;
            location = location0;
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
            playerlocation = playerlocation0;

            Vector2 dir = playerlocation - location ;
            dir = Vector2.Normalize(dir);

            velocity = dir;

            location = location + velocity;

            updatesprite();

            Log.Normal(dir.ToString());
        }
    }
}
