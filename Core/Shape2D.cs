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

        public Shape2D(Vector2 Postition0, Vector2 Scale0 , string Tag0 ,bool editor0 = false)
        {
            this.location = Postition0;
            this.Scale = Scale0;
            this.Tag = Tag0;
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
