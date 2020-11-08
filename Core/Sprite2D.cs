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
        public Vector2 Position = null;
        public Vector2 Scale = null;
        public string Tag = "";
        public Bitmap Sprite = null;

        private LevelEditor LB = null;
        public string name = string.Empty;

        private bool isleveleditor = false;

        public Sprite2D(Vector2 Postition0, Vector2 Scale0, string name0 , string Tag0 , bool isleveleditor0 = false , LevelEditor LB = null)
        {
            this.Position = Postition0;
            this.Scale = Scale0;
            this.name = name0;
            this.Tag = Tag0;
            this.isleveleditor = isleveleditor0;
            this.LB = LB;

            fetchimage();
        }
        public void DestroySelf()
        {
            if (isleveleditor == false)
            {
                Log.Info($"[SPRITE2D]({name} @  X:{Position.X}  Y:{Position.Y}) - Has been destroyed!");
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
                        this.Sprite = bi.image;
                        break;
                    }
                }
                if (this.Sprite == null)
                {
                    Log.Error("[SPRITE2D  -  E]  -  Imige NAME:" + name + "  could not be found!!");
                    DestroySelf();
                }

                Log.Info($"[SPRITE2D]({name} +  X:{Position.X}  +  Y:{Position.Y} ) - Has been registered!");
                Engine.RegisterSprite(this);
            }

            //get image from Level Builder
            if (isleveleditor == true)
            {
                foreach (BaseImage bi in LB.allimages)
                {
                    if (bi.name == this.name)
                    {
                        this.Sprite = bi.image;
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
                if (a.Position.X < b.Position.X + b.Scale.X &&
                    a.Position.X + b.Scale.X > b.Position.X &&
                    a.Position.Y < b.Position.Y + b.Scale.Y &&
                    a.Position.Y + b.Scale.Y > b.Position.Y)
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
                foreach (Sprite2D s in Engine.AllSprites)
                {
                    if (s.Tag == tag)
                    {
                        if (this.Position.X < s.Position.X + s.Scale.X &&
                            this.Position.X + this.Scale.X > s.Position.X &&
                            this.Position.Y < s.Position.Y + s.Scale.Y &&
                            this.Position.Y + this.Scale.Y > s.Position.Y)
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

            if (this.Position.X < cp.X          + cs.X &&
                this.Position.X + this.Scale.X  > cp.X &&
                this.Position.Y < cp.Y          + cs.Y &&
                this.Position.Y + this.Scale.Y  > cp.Y   )
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
                Image tmp = Image.FromFile("Content/Default/tile60.png");
                Bitmap sprite = new Bitmap(tmp);
                Sprite = sprite;
            }
            else
            {
                fetchimage();
            }
        }
        #endregion




    }
}
