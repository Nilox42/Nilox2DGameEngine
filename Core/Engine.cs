using Nilox2DGameEngine.Util;
using Nilox2DGameEngine.Objects;
//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Nilox2DGameEngine.Core
{
    #region Canvas
    //Custom Window to draw to 
    public class Canvas : Form
    {
        private PictureBox pictureBox1;
        public  Label lbcoins;

        public Canvas()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.lbcoins = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbcoins
            // 
            this.lbcoins.AutoSize = true;
            this.lbcoins.Location = new System.Drawing.Point(56, 29);
            this.lbcoins.Name = "lbcoins";
            this.lbcoins.Size = new System.Drawing.Size(13, 13);
            this.lbcoins.TabIndex = 2;
            this.lbcoins.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Nilox2DGameEngine.Properties.Resources.coin;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(38, 45);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // Canvas
            // 
            this.ClientSize = new System.Drawing.Size(834, 441);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lbcoins);
            this.Name = "Canvas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public void setlb1(string s)
        {
            lbcoins.Text = s;
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
        private Vector2 ScreenSize = Vector2.zero();
        private string Title = "Error";
        public Canvas Window = null;
        public Color backgroundColor = Color.Gray;
        #endregion

        //Engine varibles
        public static bool disablerenderer = true;
        private static bool shoulddestroy = false;
        public static int frametime = 20;
        private Thread gameLoopThread = null;

        //Infi
        Stopwatch sw = new Stopwatch();
        public static int frameCount = 0;

        //Engine lists
        //Shapes
        public static List<Shape2D> shapestoad = new List<Shape2D>();
        public static List<Shape2D> allShapes = new List<Shape2D>();
        public static List<Shape2D> shapestoremove = new List<Shape2D>();
        //Sprites
        public static List<Sprite2D> spritestoadd = new List<Sprite2D>();
        public static List<Sprite2D> allSprites = new List<Sprite2D>();
        private static List<Sprite2D> spritestoremove = new List<Sprite2D>();
        //Polygons
        public static List<Polygon> polygonestoadd = new List<Polygon>();
        public static List<Polygon> allPolygons = new List<Polygon>();
        public static List<Polygon> polygonstoremove = new List<Polygon>();

        //Ui
        public int coins = 0;
        public int health = 100;

        //Lists all images that are used 
        #region Images
        public static List<BaseImage> allimages = new List<BaseImage>();
        public string[] allcontentlocations = { @"\Content\Default\", @"\Content\Player\", @"\Content\Default\Items\", @"\Content\Overworld\Tiles\", @"\Content\Overworld\Objects\"};
        #endregion

        //Camera varibles
        #region Camera
        public static Vector2 cameraPos = new Vector2(0, 0);
        public float cameraAngle = 0f;
        #endregion

        //Logging
        #region Logging
        Random keygerator = new Random();
        public static string sessionkey = "keyerror";
        int keyrange = 9999;
        #endregion

        public Engine(Vector2 screenSize0, string title)
        {
            //safe
            shoulddestroy = false;

            //SessionKey
            sessionkey = keygerator.Next(0, keyrange).ToString();
            Log.load("[SESSION]    -    KEY:" + sessionkey);

            //Load Content
            foreach (string sl in allcontentlocations)
            {
                NLoad.imagesfromDirectory(Application.StartupPath + sl, allimages);
            }

            Log.info("Loading finished");
            Log.info("");
            Log.info("- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - ");
            Log.info("");


            //Ser base varibles
            Log.info("Game is starting ...");
            this.ScreenSize = screenSize0;
            this.Title = title;

            //Create and handle Window
            Window = new Canvas();
            Window.Size = new Size((int)ScreenSize.X, (int)ScreenSize.Y);
            Window.Text = this.Title;
            Window.FormBorderStyle = FormBorderStyle.Sizable;

            Window.Paint += renderFrame;
            Window.KeyDown += window_KeyDown;
            Window.KeyUp += window_KeyUp;
            Window.FormClosing += window_FormClosing;

            
            //Initiate Core Functions
            gameLoopThread = new Thread(gameLoop);
            gameLoopThread.Start();
            //Application.Run(Window);
            Window.Show();
        }
        #endregion
        //
        // //
        //
        #region Input

        private void window_KeyUp(object sender, KeyEventArgs e)
        {
            keyUp(e);
        }
        private void window_KeyDown(object sender, KeyEventArgs e)
        {
            keyDown(e);
        }
        #endregion
        //
        // //
        //
        #region Functions
        //Remove marked Sprite2D Polygons Shape2D and BaseImage
        #region TrashRemoval
        private void removeTrash()
        {
            //Sprite Trash Removal
            if (spritestoremove.Count > 0)
            {
                int index = 0;

                try
                {
                    foreach (Sprite2D sprite in spritestoremove)
                    {
                        lock (allSprites)
                        {
                            allSprites.Remove(sprite);
                        }
                        ++index;
                    }
                    spritestoremove.Clear();
                }
                catch
                {
                    Log.error($"[TrashRemoval]  -  FAILED TRASHREMOVAL");
                }
            }

            //Shape TrashRemoval
            if (shapestoremove.Count > 0)
            {
                int index = 0;

                foreach (Shape2D shape in shapestoremove)
                {
                    lock (allShapes)
                    {
                        allShapes.Remove(shape);
                    }
                    ++index;
                }

                shapestoremove.Clear();
            }

            //Polygon TrashRemoval
            if (polygonstoremove.Count > 0)
            {
                int index = 0;

                foreach (Polygon polygon in polygonstoremove)
                {
                    lock (allPolygons)
                    {
                        allPolygons.Remove(polygon);
                    }
                    ++index;
                }

                spritestoremove.Clear();
            }
        }

        private void addNew()
        {

            if (spritestoadd.Count > 0)
            {
                foreach(Sprite2D s in spritestoadd)
                {
                    lock (allSprites)
                    {
                        allSprites.Add(s);
                    }
                }
                spritestoadd.Clear();
            }

            if (shapestoad.Count > 0)
            {
                foreach (Shape2D s in shapestoad)
                {
                    lock (allShapes)
                    {
                        allShapes.Add(s);
                    }
                }
                shapestoad.Clear();
            }

            if (polygonestoadd.Count > 0)
            {
                foreach (Polygon s in polygonestoadd)
                {
                    lock (allPolygons)
                    {
                        allPolygons.Add(s);
                    }
                }
                polygonestoadd.Clear();
            }

        }

        public static void clearAllSprite2Ds()
        {
            foreach (Sprite2D sprite in allSprites)
            {
                unRegisterSprite(sprite);
            }

            if (allSprites.Count > 0)
            {
                allSprites.Clear();
            }
        }
        #endregion

        //REgister Sprite2D Shape2D and BaseImage
        #region Registration 
        public static void registerShape(Shape2D shape)
        {
            shapestoad.Add(shape);
            Log.info($"[SPRITE2D]  -  ({shape.Tag}  X:{shape.location.X}  Y:{shape.location.Y} ) - Has been registered!  -  now: {allShapes.Count}");
        }
        public static void registerSprite(Sprite2D sprite)
        {
            spritestoadd.Add(sprite);
            Log.info($"[SPRITE2D]  -  ({sprite.name}  X:{sprite.location.X}  Y:{sprite.location.Y} ) - Has been registered!  -  now: {allSprites.Count}");
        }
        public static void registerImage(BaseImage image)
        {
            allimages.Add(image);
            Log.load($"[BASEIMAGE]  -  ({image.name}  Tag:{image.tag}  loaded from  [{image.url}]  -  now: {allSprites.Count}  -  now: {allimages.Count}");
        }
        public static void registerPolygon(Polygon polygon)
        {
            polygonestoadd.Add(polygon);
            Log.info($"[POLYGON]  -  Has been registered!  -  now: {allPolygons.Count}");
        }
        #endregion

        //Unregister Sprite2D Shape2D and BaseImage
        #region Unregistration
        public static void unRegisterSprite(Sprite2D sprite)
        {
            //Set draw to false
            sprite.draw = false;

            //allSprites.Remove(sprite);
            spritestoremove.Add(sprite);
            Log.info($"[SPRITE2D][REMOVED]({sprite.name} @  X:{sprite.location.X}  Y:{sprite.location.Y}) - Has been marked for destruction!");
        }
        public static void unRegisterShape(Shape2D shape)
        {
            shapestoremove.Add(shape);
            Log.info($"[SHAPE2D][REMOVED](SHAPE @  X:{shape.location.X}  Y:{shape.location.Y}) - Has been marked for destruction!");
        }
        public static void unRegisterPolygon(Polygon polygon)
        {
            polygonstoremove.Add(polygon);
            Log.info($"[SHAPE2D][REMOVED]({polygon.color} Polygon - Has been marked for destruction!");
        }
        #endregion

        //User Interface
        #region Ui
        public void updateUi()
        {
            Window.lbcoins.Text = coins.ToString();
        }
        public void listfordestruction()
        {
            shoulddestroy = true;
        }
        #endregion

        private void window_FormClosing(object sender, FormClosingEventArgs e)
        {
            //disable Engine
            disablerenderer = true;

            // Abort GameLoopThread
            gameLoopThread.Abort();

            // Clear Lists
            allSprites.Clear();
            allShapes.Clear();
            allPolygons.Clear();
            allimages.Clear();

            // Call abstrakt onClose()
            onClose();

            Log.warning("[ENGINE] Closed <------------------------------------------------------------------------------------------>");
        }
        #endregion
        //
        //
        //
        #region Rendering
        void gameLoop()
        {
            onLoad();

            while (gameLoopThread.IsAlive)
            {
                try
                {
                    if (disablerenderer == false)
                    {
                        onDraw();
                        Window.BeginInvoke((MethodInvoker)delegate { Window.Refresh(); });
                        onUpdate();
                    }

                    Thread.Sleep(frametime);
                }
                catch
                {
                    Log.error("Window has not been found...");
                }
            }
        }

        private void renderFrame(object sender, PaintEventArgs e)
        {
            //add new 
            addNew();
            
            if (disablerenderer == false)
            {
                #region rendercore
                //Setup for Graphicsediting
                Graphics g = e.Graphics;
                g.Clear(backgroundColor);
                //Camera Transformation
                g.TranslateTransform(cameraPos.X, cameraPos.Y);
                g.RotateTransform(cameraAngle);

                //Draw all sprites
                try
                {
                    foreach (Sprite2D sprite in allSprites)
                    {
                        //Check if Sprite is on screen and only draw it if it is
                        if (sprite.location.X < cameraPos.X + Window.Width - 200 &&
                            sprite.location.X + sprite.scale.X> cameraPos.X &&
                            sprite.location.Y < cameraPos.Y + Window.Height - 200 &&
                            sprite.location.Y + sprite.scale.Y > cameraPos.Y &&

                            //Check if sprite should be drawn
                            sprite.draw == true)
                        {
                            try
                            {
                                //Draw Sprite
                                g.DrawImage(sprite.bitmap, sprite.location.X, sprite.location.Y, sprite.scale.X, sprite.scale.Y);
                            }
                            catch (Exception ex)
                            {
                                Log.error("Failed to Draw SPRITES:" + sprite.name + "    " + sprite.location.ToString() + "/" + ex.Message);
                            }
                        }
                        else
                        {

                        }
                    }
                }
                catch (Exception error)
                {
                    Log.error("Could not draw Sprites " + frameCount + "Exeption: " + error.Message);
                }


                //Draw all Shapes
                try
                {
                    foreach (Shape2D shape in allShapes)
                    {
                        try
                        {
                            g.FillRectangle(new SolidBrush(Color.Red), shape.location.X, shape.location.Y, shape.Scale.X, shape.Scale.Y);

                        }
                        catch (Exception ex)
                        {
                            Log.error("Failed to Draw SHAPES:" + shape.location.ToString() + "/" + ex.Message);
                        }
                    }
                }
                catch
                {
                    Log.error("Could not draw SHAPES " + frameCount);
                }


                //Draw all Polygons
                foreach (Polygon p in allPolygons)
                {
                    g.DrawPolygon(new Pen(p.color), p.points);
                }
                #endregion
            }

            //Call Trashremoval
            removeTrash();

            //update ui
            updateUi();

            if (shoulddestroy == true)
            {
                Window.Close();
                Log.warning("[CORE]  -  ENGINE IS BEING DESTROYED");
            }

            //Count Frame
            ++frameCount;
        }
        #endregion
        //
        //
        //
        #region Abstract Functions
        public abstract void onLoad();

        public abstract void onUpdate();

        public abstract void onDraw();

        public abstract void onClose();

        public abstract void keyDown(KeyEventArgs e);

        public abstract void keyUp(KeyEventArgs e);
        #endregion
    }
    #endregion
}