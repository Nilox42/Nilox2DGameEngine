using Nilox2DGameEngine.Util;
using Nilox2DGameEngine.Core;
using Nilox2DGameEngine.Objects;
using Nilox2DGameEngine.Audio;
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;

namespace Nilox2DGameEngine.Objects
{
    public class Boss : Actor
    {
        #region Init
        private GameMode gm = null;

        Vector2 lastpos = Vector2.zero();
        float maxwalkspeed = 0.2f;

        int health = 10000;
        int maxhealth = 10000;

        Timer timer = new Timer();

        public Boss(Sprite2D sprite0, GameMode gm0)
        {
            //setup
            gm = gm0;

            //setup sprite
            sprite = sprite0;
            sprite.actor = this;

            //setup actor
            clas = Class.boss;

            if (sprite.isCollidingWithTag("collider") != null)
            {
                Log.error($"[Enemie]  -  Enemie can't spawn here {getActorLocation().ToString()}");
                destroy();
            }

            //setup timer
            timer.Interval = 500;
            timer.Tick += shoot;
            timer.Start();
        }
        #endregion
        //
        //
        //
        #region overrides
        public override void damge(Actor instigator, int damage)
        {
            health -= damage;
        }

        public override void destroy(string reason = "")
        {
            timer.Stop();
            timer.Dispose();

            for (int i = 0; i < 3; i++)
            {
                gm.spawnActorFromClass(Vector2.randomInBox(getActorLocation(), getActorScale2D()), Class.item);
            }

            gm.destroyActor(this);
        }

        public override void update()
        {
            move();

        }
        #endregion
        //
        //
        //
        #region functions
        public void move()
        {
            Sprite2D player = gm.player.sprite;
            //Movement
            if (sprite.isCollidingWithTag("collider") == null)
            {
                if (Vector2.lenght(getActorLocation() - player.location) > 10)
                {
                    Vector2 direction = Vector2.normalize(getActorLocation() - player.location);

                    addActorLocation(direction * maxwalkspeed * -1);
                }
                lastpos = getActorLocation();
            }
            else
            {
                setActorLocation(lastpos);
            }
        }

        public void shoot(object sender, EventArgs e)
        {
            shootAtTarget();
        }

        public void shootAtTarget()
        {
            Projectile projectile = (Projectile)gm.spawnActorFromClass(getActorCenterLocation(), Class.projectile, this);
            projectile.direction = (Vector2.normalize(getActorCenterLocation() - gm.player.getActorCenterLocation()) * -1);
        }
        #endregion
    }
}
