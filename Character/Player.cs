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
            throw new NotImplementedException();
        }

        public override void Destroy(Actor w)
        {
            throw new NotImplementedException();
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
