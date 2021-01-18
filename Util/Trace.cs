using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Core;

namespace Nilox2DGameEngine.Util
{
    #region structure
    public struct TraceResult
    {
        public TraceResult(bool hit0, Vector2 start0, Vector2 target0, Vector2 hitlocation0)
        {
            hit = hit0;

            start = start0;
            target = target0;

            hitlocation = hitlocation0;
        }

        public bool hit;
        public Vector2 start;
        public Vector2 target;

        public Vector2 hitlocation;

        public string toString()
        {
            return $"Hit: {hit}    start:" + start.ToString() + "    target:" + target.ToString() + "    hitlocation:" + hitlocation.ToString(); ;
        }
    }
    #endregion
    //
    //
    //
    #region Trace
    class Trace
    {
        public static TraceResult lineByTag(Vector2 start, Vector2 target, string tag, int steps, bool show = false)
        {
            //Stopwatch
            //Stopwatch sw = new Stopwatch();
            //sw.Start();

            //calculate veribles
            float distance = Vector2.Distance(start, target);
            float stepdistance = distance / steps;
            Vector2 direction = (Vector2.normalize(start - target) * -1);

            //lists
            List<Shape2D> line = new List<Shape2D>();
            List<Vector2> points = new List<Vector2>();

            //varibles
            bool hit = false;
            Vector2 hitlocation = Vector2.zero();

            //Log.debug("DISTANCE:" + distance.ToString() + "      STEPDISTANCE:" + stepdistance.ToString() + "       DIRECTION" + direction.ToString());

            //loop through steps
            for (int i = 0; i < steps; i++)
            {
                Vector2 v = (start + (direction * (stepdistance * i)));
                points.Add(v);

                //loop throug Sprites
                List<Sprite2D> check = Engine.allSprites;
                foreach (Sprite2D s in check)
                {
                    if (s.tag == tag)
                    {
                        if (s.location.X < v.X + 1 &&
                            s.location.X + s.scale.X > v.X &&
                            s.location.Y < v.Y + 1 &&
                            s.location.Y + s.scale.Y > v.Y)
                        {
                            hit = true;
                            break;
                        }
                    }
                }

                //if a hit is detected break the loop and return
                if(hit == true)
                {
                    hitlocation = v;
                    break;
                }

                //used for visuals
                if (show == true)
                {
                    line.Add(new Shape2D(v, new Vector2(1, 1), "lineByTag"));
                }
            }

            //sw.Stop();
            //Log.debug("TRACE TOOK  " + sw.ElapsedMilliseconds.ToString() + "  Milliseconds");
            return new TraceResult(hit, start, target , hitlocation);
        }
    }
    #endregion
}
