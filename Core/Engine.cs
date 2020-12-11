using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using Nilox2DGameEngine.Util;
using Nilox2DGameEngine.Character;
using System.IO;

namespace Nilox2DGameEngine.Core
{
    #region Canvas
    //Custom Window to draw to 
    public class Canvas : Form
    {
        public Label lbfps;
        public ProgressBar pb_healthbar;

        public Canvas()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.pb_healthbar = new System.Windows.Forms.ProgressBar();
            this.lbfps = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pb_healthbar
            // 
            this.pb_healthbar.BackColor = System.Drawing.Color.White;
            this.pb_healthbar.ForeColor = System.Drawing.Color.Transparent;
            this.pb_healthbar.Location = new System.Drawing.Point(12, 12);
            this.pb_healthbar.Name = "pb_healthbar";
            this.pb_healthbar.Size = new System.Drawing.Size(163, 23);
            this.pb_healthbar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.pb_healthbar.TabIndex = 0;
            this.pb_healthbar.Value = 90;
            // 
            // lbfps
            // 
            this.lbfps.AutoSize = true;
            this.lbfps.Location = new System.Drawing.Point(208, 21);
            this.lbfps.Name = "lbfps";
            this.lbfps.Size = new System.Drawing.Size(25, 13);
            this.lbfps.TabIndex = 1;
            this.lbfps.Text = "000";
            // 
            // Canvas
            // 
            this.ClientSize = new System.Drawing.Size(834, 441);
            this.Controls.Add(this.lbfps);
            this.Controls.Add(this.pb_healthbar);
            this.Name = "Canvas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

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
        public static List<Shape2D> allShapes = new List<Shape2D>();
        public static List<Sprite2D> allSprites = new List<Sprite2D>();
        List<Actor> allActors = new List<Actor>();

        //Lists all images that are used 
        public static List<BaseImage> allimages = new List<BaseImage>();
        public string[] allcontentlocations = { @"\Content\Default\", @"\Content\Overworld\Tiles\", @"\Content\Overworld\Objects\", @"\Content\Player\" };

        //FPS
        Stopwatch stopwatch = new Stopwatch();

        //Camera varibles
        public static Vector2 CameraPostition = new Vector2(0, 0);
        public float CameraAngle = 0f;

        //Logging
        Log log;

        public Engine(Vector2 ScreenSize0, string Title)
        {
            foreach (string sl in allcontentlocations)
            {
                NLoad.ImagesfromDirectory(Application.StartupPath + sl, allimages);
            }

            //Ser base varibles
            Log.Info("Game is starting ...");
            this.ScreenSize = ScreenSize0;
            this.Title = Title;

            //Create and handle Window
            Window = new Canvas();
            Window.Size = new Size((int)ScreenSize.X, (int)ScreenSize.Y);
            Window.Text = this.Title;
            Window.FormBorderStyle = FormBorderStyle.Sizable;

            Window.Paint += Renderer;
            Window.KeyDown += Window_KeyDown;
            Window.KeyUp += Window_KeyUp;
            Window.FormClosing += Window_FormClosing;

            //Log
            log = new Log();
            log.startlogging();

            //Initiate Core Functions
            GameLoopThread = new Thread(GameLoop);
            GameLoopThread.Start();
            Application.Run(Window);
        }
        #endregion
        //
        // //
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
        // //
        //
        #region Functions
        public static void RegisterShape(Shape2D shape)
        {
            allShapes.Add(shape);
        }
        public static void RegisterSprite(Sprite2D sprite)
        {
            allSprites.Add(sprite);
            Log.Info($"[SPRITE2D]({sprite.name} +  X:{sprite.location.X}  +  Y:{sprite.location.Y} ) - Has been registered!");
        }
        public static void RegisterImage(BaseImage image)
        {
            allimages.Add(image);
        }


        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameLoopThread.Abort();
            allSprites.Clear();
            allShapes.Clear();
            Log.Warning("[ENGINE] Closed <------------------------------------------------------------------------------------------>");
        }

        public static void UnRegisterSprite(Sprite2D sprite)
        {
            allSprites.Remove(sprite);

            Log.Info($"[SPRITE2D][REMOVED]({sprite.name} @  X:{sprite.location.X}  Y:{sprite.location.Y}) - Has been destroyed!");

            sprite = null;
        }
        public static void UnRegisterShape(Shape2D shape)
        {
            allShapes.Remove(shape);
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
                    Thread.Sleep(10);
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

            foreach (Shape2D shape in allShapes)
            {
                g.FillRectangle(new SolidBrush(Color.Red), shape.Position.X, shape.Position.Y, shape.Scale.X, shape.Scale.Y);
            }


            try
            {
                foreach (Sprite2D sprite in allSprites)
                {
                    //Check if Sprite is on screen and only draw it if it is
                    if (sprite.location.X < CameraPostition.X + Window.Width &&
                        sprite.location.X + sprite.scale.X > CameraPostition.X &&
                        sprite.location.Y < CameraPostition.Y + Window.Height &&
                        sprite.location.Y + sprite.scale.Y > CameraPostition.Y &&

                        //Check if sprite should be drawn
                        sprite.draw == true)
                    {
                        try
                        {
                            //Draw Sprite
                            g.DrawImage(sprite.sprite, sprite.location.X, sprite.location.Y, sprite.scale.X, sprite.scale.Y);
                        }
                        catch
                        {
                            Log.Error("Failed to Draw sprite:" + sprite.name + "    " + sprite.location.ToString());
                        }
                    }
                }
            }
            catch
            {
                Log.Error("Could not draw " + FrameCount);
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