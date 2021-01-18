using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Util;
using Nilox2DGameEngine.Core;

namespace Nilox2DGameEngine.Objects
{
    public class Item : Actor
    {
        #region Init
        GameMode tgm;

        public Item(Sprite2D sprite0, GameMode GM)
        {
            //setup
            tgm = GM;

            //sprite setup
            sprite = sprite0;
            sprite.actor = this;

            //actor setup
            clas = Class.item;

            if (sprite.isCollidingWithTag("collider") != null)
            {
                destroy();
            }
        }
        #endregion
        //
        //
        //
        #region abstact functions
        public override void damge(Actor instigator, int damage)
        {
        }

        public override void destroy(string reason = "")
        {
            tgm.destroyActor(this);
        }

        public override void update()
        {
        }
        #endregion
    }
}
