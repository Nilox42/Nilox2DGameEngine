using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Util;
using Nilox2DGameEngine.Core;

namespace Nilox2DGameEngine.Character
{
    public class Item : Actor
    {
        #region Init
        GameMode tgm;

        public Item(Sprite2D sprite0, GameMode GM)
        {
            sprite = sprite0;
            tgm = GM;

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

        public override void destroy()
        {
            tgm.destroyActor(this);
        }

        public override void update()
        {
        }
        #endregion
    }
}
