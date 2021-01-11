using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Core;
using Nilox2DGameEngine.Util;

namespace Nilox2DGameEngine.Character
{
    public class Enemy : Actor
    {
        #region Init
        GameMode tgm = null;

        double health = 100;
        bool alive = true;

        double maxwalkspeed = 2;
        bool hastarget = true;
        int damagepotential = 10;

        int index = 0;

        Vector2 laspos = Vector2.Zero();

        //Vector2 playerlocation = Vector2.Zero();
        public Enemy(Sprite2D sprite0, Vector2 location0, GameMode GM)
        {
            sprite = sprite0;
            location = location0;
            tgm = GM;

            sprite.location = location;

            if (sprite.IsCollidingWithTag("collider") != null)
            {
                destroy();
            }
        }
        #endregion
        //
        //
        //
        #region abstract functions
        public override void destroy()
        {
            Log.Info("[ENEMIE] - [DIED] - " + sprite.name);

            tgm.destroyActor(this);
        }
        //
        public override void update()
        {
            Sprite2D player = tgm.player.sprite;
            //Movement
            if (sprite.IsCollidingWithTag("collider") == null && hastarget == true)
            {
                if (Vector2.Lenght(location - player.location) > 10)
                {
                    Vector2 direction = Vector2.Normalize(location - player.location);

                    location += (direction * maxwalkspeed * -1);

                    updatesprite();
                }
                laspos = location;
            }
            else
            {
                location = laspos;
                sprite.location = location;
            }

            if (player.IsCollidingWithSprite(player,this.sprite))
            {
                player.actor.damge(this,damagepotential);
                damagepotential = 0;
                tgm.destroyActor(this);
            }



        }
        //
        public override void damge(Actor instigator, int damage)
        {
            health -= damage;

            Log.Info("[DAMAGE] - [ENEMY] - " + damage);

            if (health <= 0 && alive)
            {
                alive = false;
                sprite.draw = false;
                destroy();
            }
        }
        #endregion
        //
        //
        //
        #region functions
        private void updatesprite()
        {
            sprite.location = location;
        }
        //
        public void Shoot()
        {
            if (index > 120)
            {
                tgm.spawnActorFromClass(location, Class.projectile);
                index = 0;
            }
            index++;
        }
        #endregion

    }
}
