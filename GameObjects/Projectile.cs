using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Core;
using Nilox2DGameEngine.Util;

namespace Nilox2DGameEngine.Objects
{
    public class Projectile:Actor
    {
        #region Init
        private GameMode gm = null;
        public Actor owner = null;

        public Vector2 direction = Vector2.zero();
        public int speed = 0;

        private System.Timers.Timer sec = null;
        private double lifespan = 2;

        int damagepotential = 100;

        public Projectile(Sprite2D sprite0, Vector2 direction0, int speed0, GameMode gm0, Actor owner0): base ()
        {
            //setup
            gm = gm0;
            owner = owner0;
            direction = direction0;
            speed = speed0;

            //sprite setup
            sprite = sprite0;
            sprite.actor = this;

            //actor setup
            clas = Class.projectile;



            sec = new System.Timers.Timer(lifespan * 1000);
            sec.Elapsed += sec_Elapsed;
            sec.Start();
        }
        #endregion
        //
        //
        //
        #region overrides
        public override void destroy(string reason = "")
        {
            Log.debug(reason);
            if (sec != null)
            {
                sec.Stop();
                sec.Close();
            }
            sprite.destroySelf();
            gm.destroyActor(this);
        }

        public override void damge(Actor instigator, int damage)
        {
        }

        public override void update()
        {
            // collider collision
            if (sprite.isCollidingWithTag("collider") != null)
            {
                destroy("collision collider");
            }

            // projectile collision
            Sprite2D p = sprite.isCollidingWithTag("projectile");
            if (p != null && sprite != p)
            {
                Projectile projectile = (Projectile)p.actor;
                projectile.destroy();
                destroy("collision projectile");
            }

            // enemie collision
            Sprite2D e = sprite.isCollidingWithTag("enemie");
            if (e != null && owner.clas == Class.player)
            {
                Enemy enemy = (Enemy)e.actor;
                enemy.damge(this, damagepotential);
                damagepotential = 0;
                destroy("collision enemie");
            }

            //damage player
            if (sprite.isCollidingWithSprite(sprite, gm.player.sprite) && owner != gm.player)
            {
                gm.player.damge(this, damagepotential);
                damagepotential = 0;
                destroy("collision player");
            }

            // enemie collision
            Sprite2D b = sprite.isCollidingWithTag("boss");
            if (b != null && owner.clas == Class.player)
            {
                Boss boss = (Boss)b.actor;
                boss.damge(this, damagepotential);
                damagepotential = 0;
                destroy("collision enemie");
            }

        }
        #endregion
        //
        //
        //
        #region functions
        private void sec_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            sec.Stop();
            sec = null;
            this.destroy("lifetime");
        }

        public void move()
        {
            Vector2 tomove = direction * speed;
            setActorLocation(getActorLocation() + tomove);
        }
        #endregion


    }
}
