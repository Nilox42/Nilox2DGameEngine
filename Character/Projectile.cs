﻿using System;
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
        TestGameMode gm = null;

        public Sprite2D sprite = null;
        Vector2 location = Vector2.Zero();

        Vector2 direction = Vector2.Zero();
        int speed = 0;

        System.Timers.Timer sec = null;
        double lifespan = 0.5;



        public Projectile(Sprite2D sprite0, Vector2 location0 , Vector2 direction0 , int speed0, TestGameMode gm0): base ()
        {
            sprite = sprite0;
            location = location0;
            direction = direction0;
            speed = speed0;
            gm = gm0;

            sec = new System.Timers.Timer(lifespan * 1000);
            sec.Elapsed += Sec_Elapsed;
            sec.Start();
        }

        private void Sec_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            sec.Stop();
            sec = null;
            this.Destroy(this);
        }

        private void updatesprite()
        {
            sprite.location = location;
        }

        public void move()
        {
            Vector2 tomove = direction * speed;
            location = location + tomove;

            updatesprite();
        }


        #region Actor
        public override void Destroy(Actor w)
        {
            sprite.DestroySelf();
            gm.destroyProjectile(this);
        }

        public override void Damge(Actor instigator, int damage)
        {
            
        }
        #endregion
    }
}
