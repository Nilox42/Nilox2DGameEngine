using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Nilox2DGameEngine.Util;

namespace Nilox2DGameEngine.Core
{
    public class Shape2D
    {
        public Vector2 location = null;
        public Vector2 Scale = null;
        public string Tag = "";
        public bool editor = false;

        Timer death;

        public Shape2D(Vector2 postition0, Vector2 scale0 , string tag0 = "debug", bool editor0 = false)
        {
            location = postition0;
            Scale = scale0;
            Tag = tag0;
            editor = editor0;

            Log.info($"[SHAPE2D]({Tag}) - Has been registered!");
            if (editor == false)
            {
                Engine.registerShape(this);
            }
        }

        private void Death_Tick(object sender, EventArgs e)
        {
            DestroySelf();
        }

        public void DestroySelf()
        {
            Log.info($"[SHAPE2D]({Tag}) - Has been destroyed!");
            if (editor == false)
            {
                Engine.unRegisterShape(this);
            }
        }

        public void setlifetime()
        {
            death = new Timer();
            death.Enabled = true;
        }


    }
}
