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
        public Vector2 position = null;
        public Vector2 scale = null;
        public string tag = "";
        public Bitmap sprite = null;

        private LevelEditor LB = null;
        public string name = string.Empty;

        private bool isleveleditor = false;

        public Sprite2D(Vector2 Postition0, Vector2 Scale0, string name0 , string Tag0 , bool isleveleditor0 = false , LevelEditor LB = null)
        {
            this.position = Postition0;
            this.scale = Scale0;
            this.name = name0;
            this.tag = Tag0;
            this.isleveleditor = isleveleditor0;
            this.LB = LB;

            fetchimage();
        }
        public void DestroySelf()
        {
            if (isleveleditor == false)
            {
                Log.Info($"[SPRITE2D]({name} @  X:{position.X}  Y:{position.Y}) - Has been destroyed!");
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

                Log.Info($"[SPRITE2D]({name} +  X:{position.X}  +  Y:{position.Y} ) - Has been registered!");
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
                if (a.position.X < b.position.X + b.scale.X &&
                    a.position.X + b.scale.X > b.position.X &&
                    a.position.Y < b.position.Y + b.scale.Y &&
                    a.position.Y + b.scale.Y > b.position.Y)
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
                    if (s.tag == tag)
                    {
                        if (this.position.X < s.position.X + s.scale.X &&
                            this.position.X + this.scale.X > s.position.X &&
                            this.position.Y < s.position.Y + s.scale.Y &&
                            this.position.Y + this.scale.Y > s.position.Y)
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

            if (this.position.X < cp.X          + cs.X &&
                this.position.X + this.scale.X  > cp.X &&
                this.position.Y < cp.Y          + cs.Y &&
                this.position.Y + this.scale.Y  > cp.Y   )
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
