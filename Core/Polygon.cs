using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Util;
using System.Drawing;

namespace Nilox2DGameEngine.Core
{
    public class Polygon
    {
        #region Init
        public Color color = Color.Red;

        public Point[] points;

        public Polygon(Color color0, Point[] points0)
        {
            color = color0;
            points = points0;
        }
        #endregion
    }
}
