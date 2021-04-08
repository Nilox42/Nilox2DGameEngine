using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Util;
using Nilox2DGameEngine.Core;

namespace Nilox2DGameEngine.Objects
{
    public enum Class
    {
        enemie,
        projectile,
        player,
        item,
        boss
    }

    
    

    public abstract class Actor
    {
        #region Init
        public Sprite2D sprite = null;

        public Class clas;
        #endregion
        //
        //
        //
        #region absracts
        public abstract void destroy(string reason = "");
        public abstract void update(); 
        public abstract void damge(Actor instigator, int damage);
        #endregion
        //
        //
        //
        #region Transform
        //locations
        public Vector2 getActorLocation()
        {
            return new Vector2(sprite.location.X, sprite.location.Y);
        }
        public Vector2 getActorCenterLocation()
        {
            return new Vector2(sprite.location.X + (sprite.scale.X / 2), sprite.location.Y + (sprite.scale.Y / 2));
        }
        public void setActorLocation(Vector2 vector)
        {
            sprite.location = new Vector2(vector.X, vector.Y);
        }
        public void addActorLocation(Vector2 vector)
        {
            sprite.location += vector;
        }
        public Vector2 getActorScale2D()
        {
            return new Vector2(sprite.scale.X, sprite.scale.Y);
        }

        //
        #endregion
        //
        //
        //
        #region functions
        public bool canSeeActor(Actor a, bool debugvisual = true)
        {
            TraceResult trt = Trace.lineByTag(getActorCenterLocation(), a.getActorCenterLocation(), "collider", 100, true);

            if (trt.hit == true)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
