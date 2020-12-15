using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Util;
using Nilox2DGameEngine.Core;

namespace Nilox2DGameEngine.Character
{
    public enum Class
    {
        enemie,
        projectile,
        player
    }


    public abstract class Actor
    {
        #region Init
        public Sprite2D sprite = null;
        public Vector2 location = Vector2.Zero();
        #endregion
        //
        //
        //
        #region core
        public abstract void Destroy(Actor w);
        public abstract void Update();
        #endregion
        //
        //
        //
        #region Damage
        public abstract void Damge(Actor instigator, int damage);
        #endregion
    }
}
