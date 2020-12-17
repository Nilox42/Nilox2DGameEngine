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
        TestGameMode tgm;

        public Item(Sprite2D sprite0, Vector2 location0, TestGameMode GM)
        {
            sprite = sprite0;
            location = sprite.location;
            tgm = GM;
        }
        #endregion
        //
        //
        //
        #region abstact functions
        public override void Damge(Actor instigator, int damage)
        {
        }

        public override void Destroy()
        {
            tgm.destroyActor(this);
        }

        public override void Update()
        {
        }
        #endregion
    }
}
