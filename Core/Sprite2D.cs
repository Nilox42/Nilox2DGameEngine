using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization.Formatters;
using Nilox2DGameEngine.Util;
using Nilox2DGameEngine.Editor;
using System.Windows.Forms;

namespace Nilox2DGameEngine.Core 
{
    public class Sprite2D
    {
        #region Init
        public Vector2 location = null;
        public Vector2 scale = null;
        public string tag = "";
        public Bitmap sprite = null;

        private LevelEditor LB = null;
        public string name = string.Empty;

        private bool isleveleditor = false;

        public Sprite2D(Vector2 Postition0, Vector2 Scale0, string name0, string Tag0, bool isleveleditor0 = false, LevelEditor LB0 = null)
        {
            location = Postition0;
            scale = Scale0;
            name = name0;
            tag = Tag0;
            isleveleditor = isleveleditor0;
            LB = LB0;

            fetchimage();
        }

        public void DestroySelf()
        {
            if (isleveleditor == false)
            {
                Log.Info($"[SPRITE2D][REMOVED]({name} @  X:{location.X}  Y:{location.Y}) - Has been destroyed!");
                Engine.UnRegisterSprite(this);
            }
            else
            {
                LB.allSprite2Ds.Remove(this);
            }
        }

        public void fetchimage()
        {
            //Get image for Engine
            if (isleveleditor == false)
            {
                foreach (BaseImage bi in Engine.allimages)
                {
                    if (bi.name == this.name)
                    {
                        this.sprite = bi.image;
                        this.tag = bi.tag;
                        break;
                    }
                }
                if (this.sprite == null)
                {
                    Log.Error("[SPRITE2D  -  E]  -  Imige NAME:" + name + "  could not be found!!");
                    DestroySelf();
                }

                Log.Info($"[SPRITE2D]({name} +  X:{location.X}  +  Y:{location.Y} ) - Has been registered!");
                Engine.RegisterSprite(this);
            }

            //get image from Level Builder
            if (isleveleditor == true)
            {
                foreach (BaseImage bi in LB.allimages)
                {
                    if (bi.name == this.name)
                    {
                        this.sprite = bi.image;
                        break;
                    }
                    else
                    {
                    }
                }
            }
        }
        #endregion
        //
        //
        //
        #region Collision
        public bool IsCollidingWithSprite(Sprite2D a , Sprite2D b)
        {
            if (isleveleditor == false)
            {
                if (a.location.X < b.location.X + b.scale.X &&
                    a.location.X + a.scale.X > b.location.X &&
                    a.location.Y < b.location.Y + b.scale.Y &&
                    a.location.Y + a.scale.Y > b.location.Y)
                {
                    return true;
                }
            }
            return false;
        }

        public Sprite2D IsCollidingWithTag(string tag)
        {
            if (isleveleditor == false)
            {
                foreach (Sprite2D s in Engine.allSprites)
                {
                    if (s.tag == tag)
                    {
                        if (this.location.X < s.location.X + s.scale.X &&
                            this.location.X + this.scale.X > s.location.X &&
                            this.location.Y < s.location.Y + s.scale.Y &&
                            this.location.Y + this.scale.Y > s.location.Y)
                        {
                            return s;
                        }
                    }
                }
            }
            return null;
        }

        public bool isonScreen()
        {
            bool res = false;
            Vector2 cp = Engine.CameraPostition;
            Vector2 cs = new Vector2(Engine.Window.Width ,Engine.Window.Height);

            if (this.location.X < cp.X          + cs.X &&
                this.location.X + this.scale.X  > cp.X &&
                this.location.Y < cp.Y          + cs.Y &&
                this.location.Y + this.scale.Y  > cp.Y   )
            {
                res = true;
            }

            return res;
        }
        #endregion
        //
        //
        //
        #region Editor
        public void setSelected(bool selecred0)
        {
            if (selecred0 == true)
            {
                Image tmp = Image.FromFile("Content/Default/tile60§door.png");
                Bitmap sprite = new Bitmap(tmp);
                this.sprite = sprite;
            }
            else
            {
                fetchimage();
            }
        }
        #endregion

    }
}
