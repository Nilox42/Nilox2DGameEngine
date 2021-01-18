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

    public struct TraceResult
    {
        public TraceResult(Vector2 start0, Vector2 target0, Vector2 hitlocation0)
        {
            start = start0;
            target = target0;

            hitlocation = hitlocation0;
        }

        public Vector2 start;
        public Vector2 target;

        public Vector2 hitlocation;

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
        #region core
        public abstract void destroy(string reason = "");
        public abstract void update();
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
        public TraceResult lineTraceByTag(Vector2 start, Vector2 target, string tag)
        {
            Vector2 hitlocation = Vector2.zero();




            return new TraceResult(start, target, hitlocation);
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
