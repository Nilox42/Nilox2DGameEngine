using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Util;
using System.Drawing;

namespace Nilox2DGameEngine.Util
{
    public class Vector2
    {
        public float X { get; set; }

        public float Y { get; set; }

        public Vector2()
        {
            X = zero().X;
            Y = zero().Y;
        }

        public Vector2(float X , float Y)
        {
            this.X = X;
            this.Y = Y;
        }
        #region Functions
        public static Vector2 zero()
        {
            return new Vector2(0,0);
        }

        public static Vector2 normalize(Vector2 v0)
        {
            double distance = Math.Sqrt(v0.X * v0.X + v0.Y * v0.Y);

            return new Vector2(v0.X / (float)distance, v0.Y / (float)distance);
        }

        public static float lenght(Vector2 v0)
        {
            return (float)Math.Sqrt(v0.X * v0.X + v0.Y * v0.Y);
        }

        public static float Distance(Vector2 v0, Vector2 v1)
        {
            float f = ((v0.X - v1.X) * (v0.X - v1.X) + (v0.Y - v1.Y) * (v0.Y - v1.Y));
            return f;
        }
        #endregion

        #region Converts
        public override string ToString()
        {
            string s = "X:" + X + "Y:" + Y;

            return s;
        }

        public Point ToPoint()
        {
            Point res = new Point(Convert.ToInt32(X), Convert.ToInt32(Y));
            return res;
        }
        #endregion


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
        public static Vector2 operator -(Vector2 v1, float f)
        {
            return new Vector2(
               v1.X - f,
               v1.Y - f);
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
        public static Vector2 operator *(Vector2 v1, double i)
        {
            return new Vector2(
               v1.X * (float)i,
               v1.Y * (float)i);
        }
        public static Vector2 operator *(double i, Vector2 v1)
        {
            return new Vector2(
               v1.X * (float)i,
               v1.Y * (float)i);
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
