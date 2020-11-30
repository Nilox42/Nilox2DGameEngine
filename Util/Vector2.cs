﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Util;

namespace Nilox2DGameEngine.Util
{
    public class Vector2
    {
        public float X { get; set; }

        public float Y { get; set; }

        public Vector2()
        {
            X = Zero().X;
            Y = Zero().Y;
        }

        public Vector2(float X , float Y)
        {
            this.X = X;
            this.Y = Y;
        }

        public static Vector2 Zero()
        {
            return new Vector2(0,0);
        }

        public static Vector2 Normalize(Vector2 v0)
        {
            double distance = Math.Sqrt(v0.X * v0.X + v0.Y * v0.Y);

            Log.Error(distance.ToString());

            return new Vector2(v0.X / (float)distance, v0.Y / (float)distance);
        }

        public static float steigung(Vector2 posEnemy, Vector2 posPlayer)
        {
            float deltaX = posEnemy.X - posPlayer.X;
            float deltaY = posEnemy.Y - posPlayer.X;

            if (deltaX <= 0)
            {
                deltaX = ((deltaX * deltaX) / deltaX);
            }
            if (deltaY <= 0)
            {
                deltaY = ((deltaY * deltaY) / deltaY);
            }

            return deltaY / deltaX;
        }

        public override string ToString()
        {
            string s = "X:" + X + "Y:" + Y;

            return s;
        }

        #region Operatoren
        public static Vector2 operator + (Vector2 v1, Vector2 v2)
        {
            return new Vector2(
               v1.X + v2.X,
               v1.Y + v2.Y);
        }
        public static Vector2 operator + (Vector2 v1, double d)
        {
            return new Vector2(
               v1.X + (float)d,
               v1.Y + (float)d);
        }

        public static Vector2 operator - (Vector2 v1, Vector2 v2)
        {
            return new Vector2(
               v1.X - v2.X,
               v1.Y - v2.Y);
        }

        public static bool operator < (Vector2 v1, Vector2 v2)
        {
            bool res = false;
            if (v1.X < v2.X && v1.Y < v2.Y)
            {
                res = true;
            }
            return res;
        }

        public static bool operator > (Vector2 v1, Vector2 v2)
        {
            bool res = false;
            if (v1.X > v2.X && v1.Y > v2.Y)
            {
                res = true;
            }
            return res;
        }

        public static Vector2 operator * (Vector2 v1, Vector2 v2)
        {
            return new Vector2(
               v1.X * v2.X,
               v1.Y * v2.Y);

        }
        public static Vector2 operator * (Vector2 v1, int i)
        {
            return new Vector2(
               v1.X * i,
               v1.Y * i);
        }
        public static Vector2 operator *(Vector2 v1, float i)
        {
            return new Vector2(
               v1.X * i,
               v1.Y * i);
        }

        public static Vector2 operator / (Vector2 v1, Vector2 v2)
        {
            return new Vector2(
               v1.X / v2.X,
               v1.Y / v2.Y);
        }
        public static Vector2 operator / (Vector2 v1, int i)
        {
            return new Vector2(
               v1.X / i,
               v1.Y / i);
        }
        public static Vector2 operator /(Vector2 v1, float f)
        {
            return new Vector2(
               v1.X / f,
               v1.Y / f);
        }
        #endregion
    }
}
