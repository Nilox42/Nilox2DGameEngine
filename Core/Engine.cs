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
        public Label label1;
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
            this.label1 = new System.Windows.Forms.Label();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(62, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // Canvas
            // 
            this.ClientSize = new System.Drawing.Size(834, 441);
            this.Controls.Add(this.label1);
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
        #region Window
        private Vector2 ScreenSize = Vector2.Zero();
        private string Title = "Error";
        public static Canvas Window = null;
        public Color BackgroundColor = Color.Gray;
        #endregion

        //Engine varibles
        public static int frametime = 10;
        private Thread GameLoopThread = null;

        //Infi
        Stopwatch SW = new Stopwatch();
        public static int FrameCount = 0;

        //Engine lists
        public static List<Shape2D> allShapes = new List<Shape2D>();
        public static List<Sprite2D> allSprites = new List<Sprite2D>();
        private static List<Sprite2D> spritestoremove = new List<Sprite2D>();

        //Lists all images that are used 
        #region Images
        public static List<BaseImage> allimages = new List<BaseImage>();
        public string[] allcontentlocations = { @"\Content\Default\", @"\Content\Player\", @"\Content\Default\Items\", @"\Content\Overworld\Tiles\", @"\Content\Overworld\Objects\"};
        #endregion

        //Camera varibles
        #region Camera
        public static Vector2 CameraPostition = new Vector2(0, 0);
        public float CameraAngle = 0f;
        #endregion

        //Logging
        #region Logging
        Random keygerator = new Random();
        public static string sessionkey = "keyerror";
        int keyrange = 9999;
        #endregion

        public Engine(Vector2 ScreenSize0, string Title)
        {
            //SessionKey
            sessionkey = keygerator.Next(0, keyrange).ToString();
            Log.Load("[SESSION]    -    KEY:" + sessionkey);

            //Load Content
            foreach (string sl in allcontentlocations)
            {
                NLoad.ImagesfromDirectory(Application.StartupPath + sl, allimages);
            }

            Log.Info("Loading finished");
            Log.Info("");
            Log.Info("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            Log.Info("");


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
        //Remove marked Sprite2D Shape2D and BaseImage
        private void TrashRemoval()
        {
            if (spritestoremove.Count > 0)
            {
                int index = 0;

                foreach (Sprite2D sprite in spritestoremove)
                {
                    allSprites.Remove(sprite);
                    ++index;
                }

                spritestoremove.Clear();
            }
        }
        #region TrashRemoval
        #endregion


        //REgister Sprite2D Shape2D and BaseImage
        #region Registration 
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
        #endregion

        //Unregister Sprite2D Shape2D and BaseImage
        #region Unregistration
        public static void UnRegisterSprite(Sprite2D sprite)
        {
            //Set draw to false
            sprite.draw = false;

            //allSprites.Remove(sprite);
            spritestoremove.Add(sprite);

            Log.Info($"[SPRITE2D][REMOVED]({sprite.name} @  X:{sprite.location.X}  Y:{sprite.location.Y}) - Has been destroyed!");
            sprite = null;
        }
        public static void UnRegisterShape(Shape2D shape)
        {
            allShapes.Remove(shape);
        }
        #endregion

        private void Window_FormClosing(object sender, FormClosingEventArgs e)
        {
            OnClose();

            GameLoopThread.Abort();
            allSprites.Clear();
            allShapes.Clear();
            Log.Warning("[ENGINE] Closed <------------------------------------------------------------------------------------------>");
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
                    Thread.Sleep(frametime);
                }
                catch
                {
                    Log.Error("Window has not been found...");
                }
            }
        }

        private void Renderer(object sender, PaintEventArgs e)
        {
            SW.Restart();

            Graphics g = e.Graphics;
            g.Clear(BackgroundColor);

            g.TranslateTransform(CameraPostition.X, CameraPostition.Y);
            g.RotateTransform(CameraAngle);

            //Draw all Shapes
            foreach (Shape2D shape in allShapes)
            {
                g.FillRectangle(new SolidBrush(Color.Red), shape.Position.X, shape.Position.Y, shape.Scale.X, shape.Scale.Y);
            }

            //Draw all sprites
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
                            g.DrawImage(sprite.bitmap, sprite.location.X, sprite.location.Y, sprite.scale.X, sprite.scale.Y);
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

            TrashRemoval();

            ++FrameCount;

            SW.Stop();
            //Log.Error("[PIPELINE]  -  Missiseconds:" + (SW.ElapsedMilliseconds));
        }
        #endregion
        //
        //
        //
        #region Abstract Functions
        public abstract void OnLoad();

        public abstract void OnUpdate();

        public abstract void OnDraw();

        public abstract void OnClose();


        public abstract void KeyDown(KeyEventArgs e);

        public abstract void KeyUp(KeyEventArgs e);
        #endregion
    }
    #endregion
}