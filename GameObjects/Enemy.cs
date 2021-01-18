using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using Nilox2DGameEngine.Core;
using Nilox2DGameEngine.Util;

namespace Nilox2DGameEngine.Objects
{
    public class Enemy : Actor
    {
        #region Init
        GameMode gm = null;

        double health = 100;
        bool alive = true;

        double maxwalkspeed = 0.01;
        bool hastarget = true;
        int damagepotential = 10;

        //int index = 0;

        Vector2 laspos = Vector2.zero();

        int shootcoundownnuber = 0;
        int shootcoundown = 100;

        //Vector2 playerlocation = Vector2.Zero();
        public Enemy(Sprite2D sprite0, GameMode gm0)
        {
            //setup
            gm = gm0;

            //sprite setup
            sprite = sprite0;
            sprite.actor = this;

            //actor setup
            clas = Class.enemie;



            if (sprite.isCollidingWithTag("collider") != null)
            {
                Log.error($"[Enemie]  -  Enemie can't spawn here {getActorLocation().ToString()}");
                destroy();
            }
        }
        #endregion
        //
        //
        //
        #region overrides
        public override void destroy(string reason = "")
        {
            Log.info("[ENEMIE] - [DIED] - " + sprite.name);

            gm.destroyActor(this);
        }
        //
        public override void update()
        {
            Sprite2D player = gm.player.sprite;
            //Movement
            if (sprite.isCollidingWithTag("collider") == null && hastarget == true)
            {
                if (Vector2.lenght(getActorLocation() - player.location) > 10)
                {
                    Vector2 direction = Vector2.normalize(getActorLocation() - player.location);

                    addActorLocation(direction * maxwalkspeed * -1);
                }
                laspos = getActorLocation();
            }
            else
            {
                setActorLocation(laspos);
            }

            if (player.isCollidingWithSprite(player,this.sprite))
            {
                player.actor.damge(this,damagepotential);
                damagepotential = 0;
                gm.destroyActor(this);
            }

            if (shootcoundownnuber > shootcoundown)
            {
                shoot();

                Random r = new Random();
                shootcoundown = r.Next(70,200);

                shootcoundownnuber = 0;
            }
            shootcoundownnuber++;
        }
        //
        public override void damge(Actor instigator, int damage)
        {
            health -= damage;

            Log.info("[DAMAGE] - [ENEMY] - " + damage);

            if (health <= 0 && alive)
            {
                alive = false;
                sprite.draw = false;

                gm.spawnActorFromClass(getActorCenterLocation(), Class.item);

                destroy();
            }
        }
        #endregion
        //
        //
        //
        #region functions
        public void shoot()
        {
            Projectile projectile = (Projectile)gm.spawnActorFromClass(getActorCenterLocation(), Class.projectile, this);
            projectile.direction = (Vector2.normalize(getActorCenterLocation() - gm.player.getActorCenterLocation())* -1);
    }
        #endregion

    }
}
