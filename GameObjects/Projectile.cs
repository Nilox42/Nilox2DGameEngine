using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Core;
using Nilox2DGameEngine.Util;

namespace Nilox2DGameEngine.Character
{
    public class Projectile:Actor
    {
        #region Init
        private GameMode gm = null;

        public Vector2 direction = Vector2.zero();
        public int speed = 0;

        private System.Timers.Timer sec = null;
        private double lifespan = 2;



        public Projectile(Sprite2D sprite0, Vector2 location0 , Vector2 direction0 , int speed0, GameMode gm0): base ()
        {
            sprite = sprite0;
            setActorLocation(location0);
            direction = direction0;
            speed = speed0;
            gm = gm0;

            sec = new System.Timers.Timer(lifespan * 1000);
            sec.Elapsed += sec_Elapsed;
            sec.Start();
        }
        #endregion
        //
        //
        //
        #region abstract functions
        public override void destroy()
        {
            sprite.destroySelf();
            gm.destroyActor(this);
        }

        public override void damge(Actor instigator, int damage)
        {
        }

        public override void update()
        {
        }
        #endregion
        //
        //
        //
        #region dunctions
        private void sec_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            sec.Stop();
            sec = null;
            this.destroy();
        }

        public void move()
        {
            Vector2 tomove = direction * speed;
            setActorLocation(getActorLocation() + tomove);
        }
        #endregion


    }
}
