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
        GameMode gm = null;

        int health = 100;

        public int coins = 0;

        public Player(Sprite2D sprite0, GameMode gm0)
        {
            sprite = sprite0;
            location = sprite.location;
            gm = gm0;

            clas = Class.player;
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

        public override void Destroy()
        {
            
        }

        public override void Update()
        {
            if (coins >= 3 && gm.ismoving == false && gm.canmoveon == false)
            {
                gm.canmoveon = true;
                Log.Warning("[CINDITION] - Coin Condition met");
            }
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
