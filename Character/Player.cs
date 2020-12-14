using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Util;
using Nilox2DGameEngine.Core;

namespace Nilox2DGameEngine.Character
{
    public class Player : Actor
    {
        #region Init
        int health = 100;

        public Player(Sprite2D sprite0)
        {
            sprite = sprite0;
        }
        #endregion
        //
        //
        //
        #region abstract functions
        public override void Damge(Actor instigator, int damage)
        {
            health -= damage;

            if (health <= 0) 
            {
                Log.Error("[PLAYER]  -  Died!");
            }
        }

        public override void Destroy(Actor w)
        {
            
        }

        public override void Update()
        {
            
        }
        #endregion
        //
        //
        //
        #region functions
        public void keypickup()
        {
            Sprite2D key0 = sprite.IsCollidingWithTag("key");
            if (key0 != null)
            {
                key0.DestroySelf();
                key0 = null;
            }
        }
        public void healthpickup()
        {
            Sprite2D heart0 = sprite.IsCollidingWithTag("heart");
            if (heart0 != null)
            {
                heart0.DestroySelf();
                heart0 = null;
            }
        }
        public void coinpickup()
        {
            Sprite2D coin0 = sprite.IsCollidingWithTag("coin");
            if (coin0 != null)
            {
                coin0.DestroySelf();
                coin0 = null;
            }
        }

        #endregion
    }
}
