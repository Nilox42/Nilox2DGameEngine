using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization.Formatters;
using Nilox2DGameEngine.Util;
using Nilox2DGameEngine.Character;
using Nilox2DGameEngine.Editor;
using System.Windows.Forms;
using System.Diagnostics;
using System.Drawing.Drawing2D;


namespace Nilox2DGameEngine.Core 
{
    public class Sprite2D
    {
        #region Init
        public Actor actor = null;

        public Vector2 location = null;
        public Vector2 scale = null;
        public string tag = "";
        public Bitmap bitmap = null;

        public bool draw = true;

        private LevelEditor lb = null;
        public string name = string.Empty;

        private bool isleveleditor = false;

        public Sprite2D(Vector2 Postition0, Vector2 Scale0, string name0, string Tag0, bool draw0, bool isleveleditor0 = false, LevelEditor LB0 = null)
        {
            location = Postition0;
            scale = Scale0;
            name = name0;
            tag = Tag0;
            isleveleditor = isleveleditor0;
            lb = LB0;
            draw = draw0;

            fetchimage();
        }

        public void destroySelf()
        {
            if (isleveleditor == false)
            {
                Engine.unRegisterSprite(this);
            }
            else
            {
                lb.allSprite2Ds.Remove(this);
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
                        this.bitmap = bi.image;
                        this.tag = bi.tag;
                        break;
                    }
                }
                if (this.bitmap == null)
                {
                    Log.error("[SPRITE2D  -  E]  -  Imige NAME:" + name + "  could not be found!!");
                    destroySelf();
                }

                Engine.registerSprite(this);
            }

            //get image from Level Builder
            if (isleveleditor == true)
            {
                foreach (BaseImage bi in lb.allimages)
                {
                    if (bi.name == this.name)
                    {
                        this.bitmap = bi.image;
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
        public bool isCollidingWithSprite(Sprite2D a , Sprite2D b)
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

        public Sprite2D isCollidingWithTag(string tag)
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

        public List<Sprite2D> getCollidingTags(string[] tags)
        {
            List<Sprite2D> result = new List<Sprite2D>();
            foreach (Sprite2D s in Engine.allSprites)
            {
                foreach (string st in tags)
                {
                    if (s.tag == st)
                    {
                        result.Add(s);
                    }
                }
            }

            return result;
        }

        public bool isonScreen()
        {
            bool res = false;
            Vector2 cp = Engine.cameraPos;
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
        #region Functions
        public void Flip()
        {
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
        }
        public static Bitmap RotateImage(Bitmap img, Vector2 scale, float rotationAngle)
        {
            
            return img;
        }
        #endregion
        //
        //
        //
        #region Editor
        public void setSelectedOLD(bool selecred0)
        {
            if (selecred0 == true)
            {
                Image tmp = Image.FromFile("Content/Default/tile60§doorleft.png");
                Bitmap sprite = new Bitmap(tmp);
                this.bitmap = sprite;
            }
            else
            {
                fetchimage();
            }
        }
        #endregion

    }
}
