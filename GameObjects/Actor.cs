﻿using System;
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
        //public Vector2 location = Vector2.zero();

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
        public Vector2 getActorLocation()
        {
            return new Vector2(sprite.location.X, sprite.location.Y);
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
        #endregion
        //
        //
        //
        #region Damage
        public abstract void damge(Actor instigator, int damage);
        #endregion
    }
}