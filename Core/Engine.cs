using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using Nilox2DGameEngine.Util;
using System.IO;

namespace Nilox2DGameEngine.Core
{
    #region Canvas
    //Custom Window to draw to 
    public class Canvas : Form
    {
        public Canvas()
        {
            this.DoubleBuffered = true;
        }
    }
    #endregion
    //
    //---------------------------------------------------------------------------------------------------------------------------------------
    //
    #region Engine
    public abstract class Engine
    {
        #region Engine Init
        //Windwo varibles
        private Vector2 ScreenSize = Vector2.Zero();
        private string Title = "Error";
        public static Canvas Window = null;
        public Color BackgroundColor = Color.Gray;

        //Engine varibles
        public int FrameCount = 0;
        private Thread GameLoopThread = null;

        //Engine lists
        public static List<Shape2D> AllShapes = new List<Shape2D>();
        public static List<Sprite2D> AllSprites = new List<Sprite2D>();
        public static List<BaseImage> allimages = new List<BaseImage>();

        public string[] allcontentlocations = { @"\Content\Default\" , @"\Content\Overworld\Tiles\" , @"\Content\Overworld\Objects\" , @"\Content\Player\" };

        //Camera varibles
        public static Vector2 CameraPostition = new Vector2(0, 0);
        public float CameraAngle = 0f;

        public Engine(Vector2 ScreenSize0, string Title)
        {
            foreach (string sl in allcontentlocations)
            {
                NLoad.ImagesfromDirectory(Application.StartupPath + sl , allimages);
            }

            //Ser base varibles
            Log.Info("Game is starting ...");
            this.ScreenSize = ScreenSize0;
            this.Title = Title;

            //Create and handle Window
            Window = new Canvas();
            Window.Size = new Size((int)ScreenSize.X, (int)ScreenSize.Y);
            Window.Text = this.Title;
            Window.FormBorderStyle = FormBorderStyle.SizableToolWindow;

            Window.Paint += Renderer;
            Window.KeyDown += Window_KeyDown;
            Window.KeyUp += Window_KeyUp;
            Window.FormClosing += Window_FormClosing;

            //Initiate Core Functions
            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();
            Application.Run(Window);
        }
        #endregion
        //
        //
        //
        #region Input
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            KeyUp(e);
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            KeyDown(e);
        }
        #endregion
        //
        //
        //
        #region Functions
        public static void RegisterShape(Shape2D shape)
        {
            AllShapes.Add(shape);
        }
        public static void RegisterSprite(Sprite2D sprite)
        {
            AllSprites.Add(sprite);
        }
        public static void RegisterImage(BaseImage image)
        {
            allimages.Add(image);
        }

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameLoopThread.Abort();
            AllSprites.Clear();
            AllShapes.Clear();
            Log.Warning("[ENGINE] Closed <------------------------------------------------------------------------------------------>");
        }

        public static void UnRegisterSprite(Sprite2D sprite)
        {
            AllSprites.Remove(sprite);
        }
        public static void UnRegisterShape(Shape2D shape)
        {
            AllShapes.Remove(shape);
        }
        #endregion
        //
        //
        //
        #region Rendering
        void GameLoop()
        {
            OnLoad();

            while (GameLoopThread.IsAlive)
            {
                try
                {
                    OnDraw();
                    Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                    OnUpdate();
                    Thread.Sleep(5);
                }
                catch
                {
                    Log.Error("Window has not been found...");
                }
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackgroundColor);

            g.TranslateTransform(CameraPostition.X, CameraPostition.Y);
            g.RotateTransform(CameraAngle);

            foreach (Shape2D shape in AllShapes)
            {
                g.FillRectangle(new SolidBrush(Color.Red), shape.Position.X, shape.Position.Y, shape.Scale.X, shape.Scale.Y);
            }

            //Try because Memorie Leek i think
            try
            {
                foreach (Sprite2D sprite in AllSprites)
                {
                    //Check if Sprite is on screen and only draw it if it is
                    if (sprite.position.X < CameraPostition.X   + Window.Width      &&
                        sprite.position.X + sprite.scale.X      > CameraPostition.X &&
                        sprite.position.Y < CameraPostition.Y   + Window.Height     &&
                        sprite.position.Y + sprite.scale.Y      > CameraPostition.Y    )
                    {
                        //Draw Sprite
                        g.DrawImage(sprite.sprite, sprite.position.X, sprite.position.Y, sprite.scale.X, sprite.scale.Y);
                    }
                }
            }
            catch
            {
                Log.Error("[ENGINE][RENDERER] Faield to draw AllSprites in Frame [F:" + FrameCount.ToString() + "]");
            }

            ++FrameCount;
        }
        #endregion
        //
        //
        //
        #region Abstract Functions
        public abstract void OnLoad();

        public abstract void OnUpdate();

        public abstract void OnDraw();


        public abstract void KeyDown(KeyEventArgs e);

        public abstract void KeyUp(KeyEventArgs e);
        #endregion
    }
    #endregion
}