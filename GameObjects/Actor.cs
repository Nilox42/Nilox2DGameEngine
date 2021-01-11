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
        player,
        item
    }


    public abstract class Actor:GameObject
    {
        #region Init
        public Sprite2D sprite = null;
        public Vector2 location = Vector2.zero();

        public Class clas;
        #endregion
        //
        //
        //
        #region core
        public abstract void destroy();
        public abstract void update();
        #endregion
        //
        //
        //
        #region Transform
        public void setLocation(Vector2 vector)
        {
            location = new Vector2(vector.X, vector.Y);
            sprite.location = new Vector2(vector.X, vector.Y);
        }
        #endregion
        //
        //
        //
        #region Damage
        public abstract void damge(Actor instigator, int damage);
        #endregion
    }
}
