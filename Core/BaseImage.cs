﻿using Nilox2DGameEngine.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilox2DGameEngine.Core
{
    public class BaseImage
    {
        public string url = string.Empty;
        public string name = string.Empty;

        public Bitmap image = null;

        public BaseImage(string name0 , string url0 , Bitmap image0 , bool isleveleditor = false)
        {
            name = name0;
            url = url0;
            image = image0;

            if (isleveleditor == false)
            {
                Engine.RegisterImage(this);
            }
            else
            {

            }

            Log.Load("[BASEIMAGE]  {" + name + "} loaded from [" + url + "]");
        }
    }
}
