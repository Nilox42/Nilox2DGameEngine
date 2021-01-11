using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nilox2DGameEngine.Util;

namespace Nilox2DGameEngine.Core
{
    public class Shape2D
    {
        public Vector2 location = null;
        public Vector2 Scale = null;
        public string Tag = "";
        public bool editor = false;

        public Shape2D(Vector2 postition0, Vector2 scale0 , string tag0 ,bool editor0 = false)
        {
            this.location = postition0;
            this.Scale = scale0;
            this.Tag = tag0;
            this.editor = editor0;

            Log.info($"[SHAPE2D]({Tag}) - Has been registered!");
            if (editor == false)
            {
                Engine.registerShape(this);
            }
        }

        public void DestroySelf()
        {
            Log.info($"[SHAPE2D]({Tag}) - Has been destroyed!");
            if (editor == false)
            {
                Engine.unRegisterShape(this);
            }
        }




    }
}
