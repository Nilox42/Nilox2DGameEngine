using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Timers;
using Nilox2DGameEngine.Util;
using Nilox2DGameEngine.Map;
using Nilox2DGameEngine.Core;
using System.DirectoryServices.ActiveDirectory;
using System.Linq.Expressions;

namespace Nilox2DGameEngine.Editor
{
    public class Builder : Form
    {
        #region Init
        private Button bt_LoadLevel;
        private RichTextBox richTextBox1;
        private FolderBrowserDialog FD;
        private TextBox tb_url;
        private NumericUpDown nud_index;
        private Button button1;
        //private System.ComponentModel.IContainer components;
        private LevelEditor LB = null;
        private Button bt_left;
        private Button bt_right;
        private Button bt_down;
        private Button bt_enter;
        private Button bt_up;
        public Label lb_debug_X;
        public Label lb_debug_Y;
        public TextBox tb_name;
        private Button bt_new;
        public Label lb_tilesize;
        private Button bt_saveto;
        public TextBox tb_saveto;
        private TextBox textBox1;
        private TextBox tb_tilename;
        private Label lb_tilename;
        private Button bt_settilesize;
        private Button bt_settilename;
        public PictureBox pb_selector;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public Builder(LevelEditor LB0)
        {
            LB = LB0;
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Builder));
            this.bt_LoadLevel = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.FD = new System.Windows.Forms.FolderBrowserDialog();
            this.tb_url = new System.Windows.Forms.TextBox();
            this.nud_index = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.bt_left = new System.Windows.Forms.Button();
            this.bt_right = new System.Windows.Forms.Button();
            this.bt_down = new System.Windows.Forms.Button();
            this.bt_enter = new System.Windows.Forms.Button();
            this.bt_up = new System.Windows.Forms.Button();
            this.lb_debug_X = new System.Windows.Forms.Label();
            this.lb_debug_Y = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.bt_new = new System.Windows.Forms.Button();
            this.lb_tilesize = new System.Windows.Forms.Label();
            this.bt_saveto = new System.Windows.Forms.Button();
            this.tb_saveto = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tb_tilename = new System.Windows.Forms.TextBox();
            this.lb_tilename = new System.Windows.Forms.Label();
            this.bt_settilesize = new System.Windows.Forms.Button();
            this.bt_settilename = new System.Windows.Forms.Button();
            this.pb_selector = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.nud_index)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_selector)).BeginInit();
            this.SuspendLayout();
            // 
            // bt_LoadLevel
            // 
            this.bt_LoadLevel.CausesValidation = false;
            this.bt_LoadLevel.Location = new System.Drawing.Point(12, 367);
            this.bt_LoadLevel.Name = "bt_LoadLevel";
            this.bt_LoadLevel.Size = new System.Drawing.Size(109, 38);
            this.bt_LoadLevel.TabIndex = 0;
            this.bt_LoadLevel.TabStop = false;
            this.bt_LoadLevel.Text = "LoadLevel";
            this.bt_LoadLevel.UseVisualStyleBackColor = true;
            this.bt_LoadLevel.Click += new System.EventHandler(this.bt_LoadLevelclick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.CausesValidation = false;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(266, 349);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // tb_url
            // 
            this.tb_url.CausesValidation = false;
            this.tb_url.Location = new System.Drawing.Point(12, 411);
            this.tb_url.Name = "tb_url";
            this.tb_url.Size = new System.Drawing.Size(109, 20);
            this.tb_url.TabIndex = 3;
            this.tb_url.Text = "Overworld";
            // 
            // nud_index
            // 
            this.nud_index.CausesValidation = false;
            this.nud_index.Location = new System.Drawing.Point(169, 412);
            this.nud_index.Name = "nud_index";
            this.nud_index.Size = new System.Drawing.Size(109, 20);
            this.nud_index.TabIndex = 4;
            this.nud_index.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button1
            // 
            this.button1.CausesValidation = false;
            this.button1.Location = new System.Drawing.Point(169, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 38);
            this.button1.TabIndex = 5;
            this.button1.TabStop = false;
            this.button1.Text = "LoadTile";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // bt_left
            // 
            this.bt_left.Location = new System.Drawing.Point(306, 363);
            this.bt_left.Name = "bt_left";
            this.bt_left.Size = new System.Drawing.Size(40, 40);
            this.bt_left.TabIndex = 6;
            this.bt_left.TabStop = false;
            this.bt_left.Text = "<";
            this.bt_left.UseVisualStyleBackColor = true;
            this.bt_left.Click += new System.EventHandler(this.bt_left_Click);
            // 
            // bt_right
            // 
            this.bt_right.Location = new System.Drawing.Point(398, 363);
            this.bt_right.Name = "bt_right";
            this.bt_right.Size = new System.Drawing.Size(40, 40);
            this.bt_right.TabIndex = 7;
            this.bt_right.TabStop = false;
            this.bt_right.Text = ">";
            this.bt_right.UseVisualStyleBackColor = true;
            this.bt_right.Click += new System.EventHandler(this.bt_right_Click);
            // 
            // bt_down
            // 
            this.bt_down.Location = new System.Drawing.Point(352, 409);
            this.bt_down.Name = "bt_down";
            this.bt_down.Size = new System.Drawing.Size(40, 40);
            this.bt_down.TabIndex = 8;
            this.bt_down.TabStop = false;
            this.bt_down.Text = "\\/";
            this.bt_down.UseVisualStyleBackColor = true;
            this.bt_down.Click += new System.EventHandler(this.bt_down_Click);
            // 
            // bt_enter
            // 
            this.bt_enter.Location = new System.Drawing.Point(352, 363);
            this.bt_enter.Name = "bt_enter";
            this.bt_enter.Size = new System.Drawing.Size(40, 40);
            this.bt_enter.TabIndex = 9;
            this.bt_enter.TabStop = false;
            this.bt_enter.Text = "O";
            this.bt_enter.UseVisualStyleBackColor = true;
            this.bt_enter.Click += new System.EventHandler(this.bt_enter_Click);
            // 
            // bt_up
            // 
            this.bt_up.Location = new System.Drawing.Point(352, 317);
            this.bt_up.Name = "bt_up";
            this.bt_up.Size = new System.Drawing.Size(40, 40);
            this.bt_up.TabIndex = 10;
            this.bt_up.TabStop = false;
            this.bt_up.Text = "/\\";
            this.bt_up.UseVisualStyleBackColor = true;
            this.bt_up.Click += new System.EventHandler(this.bt_up_Click);
            // 
            // lb_debug_X
            // 
            this.lb_debug_X.AutoSize = true;
            this.lb_debug_X.Location = new System.Drawing.Point(398, 411);
            this.lb_debug_X.Name = "lb_debug_X";
            this.lb_debug_X.Size = new System.Drawing.Size(42, 13);
            this.lb_debug_X.TabIndex = 11;
            this.lb_debug_X.Text = "dbug_x";
            // 
            // lb_debug_Y
            // 
            this.lb_debug_Y.AutoSize = true;
            this.lb_debug_Y.Location = new System.Drawing.Point(398, 436);
            this.lb_debug_Y.Name = "lb_debug_Y";
            this.lb_debug_Y.Size = new System.Drawing.Size(35, 13);
            this.lb_debug_Y.TabIndex = 12;
            this.lb_debug_Y.Text = "label2";
            // 
            // tb_name
            // 
            this.tb_name.Location = new System.Drawing.Point(306, 473);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(134, 20);
            this.tb_name.TabIndex = 13;
            // 
            // bt_new
            // 
            this.bt_new.Location = new System.Drawing.Point(923, 363);
            this.bt_new.Name = "bt_new";
            this.bt_new.Size = new System.Drawing.Size(75, 40);
            this.bt_new.TabIndex = 14;
            this.bt_new.Text = "New";
            this.bt_new.UseVisualStyleBackColor = true;
            this.bt_new.Click += new System.EventHandler(this.bt_new_Click);
            // 
            // lb_tilesize
            // 
            this.lb_tilesize.AutoSize = true;
            this.lb_tilesize.Location = new System.Drawing.Point(507, 363);
            this.lb_tilesize.Name = "lb_tilesize";
            this.lb_tilesize.Size = new System.Drawing.Size(62, 13);
            this.lb_tilesize.TabIndex = 15;
            this.lb_tilesize.Text = "Tilesize: XX";
            // 
            // bt_saveto
            // 
            this.bt_saveto.Location = new System.Drawing.Point(923, 409);
            this.bt_saveto.Name = "bt_saveto";
            this.bt_saveto.Size = new System.Drawing.Size(75, 40);
            this.bt_saveto.TabIndex = 16;
            this.bt_saveto.Text = "Save to :";
            this.bt_saveto.UseVisualStyleBackColor = true;
            this.bt_saveto.Click += new System.EventHandler(this.bt_saveto_Click);
            // 
            // tb_saveto
            // 
            this.tb_saveto.Location = new System.Drawing.Point(1004, 420);
            this.tb_saveto.Name = "tb_saveto";
            this.tb_saveto.Size = new System.Drawing.Size(146, 20);
            this.tb_saveto.TabIndex = 17;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(624, 360);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(144, 20);
            this.textBox1.TabIndex = 18;
            // 
            // tb_tilename
            // 
            this.tb_tilename.Location = new System.Drawing.Point(624, 387);
            this.tb_tilename.Name = "tb_tilename";
            this.tb_tilename.Size = new System.Drawing.Size(144, 20);
            this.tb_tilename.TabIndex = 19;
            // 
            // lb_tilename
            // 
            this.lb_tilename.AutoSize = true;
            this.lb_tilename.Location = new System.Drawing.Point(507, 390);
            this.lb_tilename.Name = "lb_tilename";
            this.lb_tilename.Size = new System.Drawing.Size(66, 13);
            this.lb_tilename.TabIndex = 20;
            this.lb_tilename.Text = "Tilename: \"\"";
            // 
            // bt_settilesize
            // 
            this.bt_settilesize.Location = new System.Drawing.Point(785, 360);
            this.bt_settilesize.Name = "bt_settilesize";
            this.bt_settilesize.Size = new System.Drawing.Size(75, 20);
            this.bt_settilesize.TabIndex = 21;
            this.bt_settilesize.Text = "Set";
            this.bt_settilesize.UseVisualStyleBackColor = true;
            // 
            // bt_settilename
            // 
            this.bt_settilename.Location = new System.Drawing.Point(785, 387);
            this.bt_settilename.Name = "bt_settilename";
            this.bt_settilename.Size = new System.Drawing.Size(75, 20);
            this.bt_settilename.TabIndex = 22;
            this.bt_settilename.Text = "Set";
            this.bt_settilename.UseVisualStyleBackColor = true;
            // 
            // pb_selector
            // 
            this.pb_selector.BackColor = System.Drawing.Color.Transparent;
            this.pb_selector.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_selector.BackgroundImage")));
            this.pb_selector.Location = new System.Drawing.Point(371, 309);
            this.pb_selector.Name = "pb_selector";
            this.pb_selector.Size = new System.Drawing.Size(48, 48);
            this.pb_selector.TabIndex = 23;
            this.pb_selector.TabStop = false;
            // 
            // Builder
            // 
            this.ClientSize = new System.Drawing.Size(1162, 505);
            this.Controls.Add(this.pb_selector);
            this.Controls.Add(this.bt_settilename);
            this.Controls.Add(this.bt_settilesize);
            this.Controls.Add(this.lb_tilename);
            this.Controls.Add(this.tb_tilename);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tb_saveto);
            this.Controls.Add(this.bt_saveto);
            this.Controls.Add(this.lb_tilesize);
            this.Controls.Add(this.bt_new);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.lb_debug_Y);
            this.Controls.Add(this.lb_debug_X);
            this.Controls.Add(this.bt_up);
            this.Controls.Add(this.bt_enter);
            this.Controls.Add(this.bt_down);
            this.Controls.Add(this.bt_right);
            this.Controls.Add(this.bt_left);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nud_index);
            this.Controls.Add(this.tb_url);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.bt_LoadLevel);
            this.Name = "Builder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Builder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nud_index)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_selector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private void Timer_Tick(object sender, EventArgs e)
        {
            foreach (Sprite2D b0 in LB.allSprite2Ds)
            {
                Vector2 a = new Vector2(Cursor.Position.X - DesktopLocation.X, Cursor.Position.Y - DesktopLocation.Y);
                Vector2 b = new Vector2(b0.location.X, b0.location.Y + 15);

                if (    a.X < b.X   + 48    &&
                        a.X + 0     > b.X   &&
                        a.Y < b.Y   + 48    &&
                        a.Y + 0     > b.Y      )
                {
                    if (LB.selector != b0)
                    {
                        LB.selector = b0;
                        b0.setSelected(true);

                        foreach (Sprite2D s in LB.allSprite2Ds)
                        {
                            if (s != b0)
                            {
                                s.setSelected(false);
                            }
                        }
                        LB.Window.Refresh();
                    }
                }
                else if (LB.selector != null)
                {
                    LB.selector.setSelected(false);
                    LB.selector = null;
                }
            }
        }

        private void Builder_Load(object sender, EventArgs e)
        {
            Log.Info("[BUILDER] GUI Loaded");
        }


        #region Input
        private void bt_LoadLevelclick(object sender, EventArgs e)
        {
            string url = Application.StartupPath + @"\Levels\" + tb_url.Text;
            if (Directory.Exists(url))
            {
                Log.Info("Exists");
                LB.allTiles = NLoad.TilesL(url);

                richTextBox1.Text = "";

                int index = 0;
                foreach (Tile t in LB.allTiles)
                {
                    richTextBox1.Text = richTextBox1.Text + "Index:" + index.ToString() + "     Name:" + t.name + "\n";
                    index++;
                }

                //Check if there is i Tile to load
                if (LB.allTiles.Count > 0)
                {
                    LB.NewLoadNewTile(LB.allTiles.ElementAt(0));
                }
                
                LB.Window.Refresh();
            }
            else
            {
                Log.Error("Directory does not Exist");
            }
        }
        

        private void bt_UnLoadTile_Click(object sender, EventArgs e)
        {
            LB.UnloadCurrentTile();
            LB.Window.Refresh();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (nud_index.Value <= LB.allTiles.Count - 1 && nud_index.Value >= 0)
            {
                LB.NewLoadNewTile(LB.allTiles.ElementAt((int)nud_index.Value));
                LB.Window.Refresh();

                LB.selectedtile = (int)nud_index.Value;
            }
            if (nud_index.Value > LB.allTiles.Count - 1)
            {
                nud_index.Value = LB.allTiles.Count - 1;
            }
            if (nud_index.Value < 0)
            {
                nud_index.Value = 0;
            }
            else
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (nud_index.Value <= LB.allTiles.Count - 1 && nud_index.Value >= 0)
            {
                LB.NewLoadNewTile(LB.allTiles.ElementAt((int)nud_index.Value));
            }
            else
            {

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            LB.Window.Refresh();
        }

        //Dpad
        private void bt_up_Click(object sender, EventArgs e)
        {
            LB.moveup(-1);
        }

        private void bt_right_Click(object sender, EventArgs e)
        {
            LB.moveleft(1);
        }

        private void bt_down_Click(object sender, EventArgs e)
        {
            LB.moveup(1);
        }

        private void bt_left_Click(object sender, EventArgs e)
        {
            LB.moveleft(-1);
        }

        private void bt_enter_Click(object sender, EventArgs e)
        {
            LB.replacecoorinate(LB.selectedVector, tb_name.Text);
        }

        private void bt_new_Click(object sender, EventArgs e)
        {
            LB.allTiles.Clear();
            tb_url.Text = "";

            LB.allTiles.Add(new Tile(true));
            LB.selectedtile = 0;
            LB.NewLoadNewTile(LB.allTiles.ElementAt(0));
            Log.Info("[NEW TILE]  -  " + LB.allTiles.ElementAt(0).name);
        }
        #endregion

        private void bt_saveto_Click(object sender, EventArgs e)
        {
            LB.savecurrent(tb_saveto.Text);
        }
    }
    //

    //---------------------------------------------------------------------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------------------------------------------------------------------

    //
    public class LevelEditor 
    {
        #region Init Builder
        private Vector2 ScreenSize = new Vector2(1178, 544);
        private string title = "Level Builder - ";
        public Builder Window = null;

        private int selectedindex = 0;
        public Vector2 selectedVector = Vector2.Zero();
        public int selectedtile = 0;

        public void LoadBuilderGUI()
        {
            Window = new Builder(this);
            Window.Size = new Size((int)ScreenSize.X, (int)ScreenSize.Y);
            Window.Text = this.title;
            Window.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            Window.Paint += Window_Paint;
            
            Application.Run(Window);
        }
        #endregion
        //
        // //
        //
        // LevelBuilder
        //
        // //
        //
        #region Init
        public List<Tile> allTiles = new List<Tile>();
        public List<Sprite2D> allSprite2Ds = new List<Sprite2D>();

        public List<BaseImage> allimages = new List<BaseImage>();
        public string[] allcontentlocations = { Application.StartupPath + @"\Content\Default\", Application.StartupPath + @"\Content\Overworld\Tiles\", Application.StartupPath + @"\Content\Overworld\Objects\" };

        public Vector2 maporigin = new Vector2(284, 12);
        public Sprite2D selector = null;

        public string previewpng = string.Empty;


        public LevelEditor()
        {
            foreach (string sl in allcontentlocations)
            {
                NLoad.ImagesfromDirectory(sl , allimages);
            }

            LoadBuilderGUI();
        }

        #endregion
        //
        // //
        //
        #region Core Functions
        private void Window_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Gray);

            foreach (Sprite2D sprite in allSprite2Ds)
            {
                try
                {
                    g.DrawImage(sprite.sprite, sprite.location.X, sprite.location.Y, sprite.scale.X, sprite.scale.Y);
                }
                catch
                {
                    Log.Error("Sprite couldnt be drawn");
                }
            }
        }

        public void LoadNewTile(Tile t)
        {
            allSprite2Ds.Clear();
            Log.Info("[LOADING]:" + t.name);
            for (int i = 0; i < t.Map.GetLength(0); i++)
            {
                for (int j = 0; j < t.Map.GetLength(1); j++)
                {
                    if (t.Map[j, i] == "g")
                    {
                        allSprite2Ds.Add(new Sprite2D(new Vector2(i * 48 + maporigin.X, j * 48 + maporigin.Y), new Vector2(48, 48), "Overworld/Tiles/tile22", "Collider",true,this));
                    }
                    if (t.Map[j, i] == "w")
                    {
                        allSprite2Ds.Add(new Sprite2D(new Vector2(i * 48 + maporigin.X, j * 48 + maporigin.Y), new Vector2(48, 48), "Overworld/Tiles/tile53", "Collider", true, this));
                    }
                    if (t.Map[j, i] == "s")
                    {
                        allSprite2Ds.Add(new Sprite2D(new Vector2(i * 48 + maporigin.X, j * 48 + maporigin.Y), new Vector2(48, 48), "Overworld/Tiles/tile12", "BackGround", true, this));
                    }
                    if (t.Map[j, i] == "dr")
                    {
                        allSprite2Ds.Add(new Sprite2D(new Vector2(i * 48 + maporigin.X, j * 48 + maporigin.Y), new Vector2(48, 48), "Overworld/Tiles/tile110", "Collider", true, this));
                    }
                    if (t.Map[j, i] == "dl")
                    {
                        allSprite2Ds.Add(new Sprite2D(new Vector2(i * 48 + maporigin.X, j * 48 + maporigin.Y), new Vector2(48, 48), "Overworld/Tiles/tile110", "Collider", true, this));
                    }
                }
            }

            allSprite2Ds.ElementAt(0).setSelected(true);
        }

        public void NewLoadNewTile(Tile t , int selected = 0)
        {
            allSprite2Ds.Clear();
            Log.Info("[LOADING] - [Tile]:" + t.name);
            for (int i = 0; i < t.Map.GetLength(0); i++)
            {
                for (int j = 0; j < t.Map.GetLength(1); j++)
                {
                    if (t.Map[j, i] != ".")
                    {
                        allSprite2Ds.Add(new Sprite2D(new Vector2(i * 48 + maporigin.X, j * 48 + maporigin.Y), new Vector2(48, 48), t.Map[j, i], "Collider", true, this));
                    }
                }
            }
            Window.lb_tilesize.Text = "Tilesize:" + t.TileSize;

            allSprite2Ds.ElementAt(selected).setSelected(true);
            Window.Refresh();
        }

        public void UnloadCurrentTile()
        {
            Log.Warning("Clearing all Sprites");
            int count = Engine.AllSprites.Count;
            for (int i = 0; i < count; ++i)
            {
                Engine.AllSprites.ElementAt(0).DestroySelf();
                Console.WriteLine(Engine.AllSprites.Count.ToString());
            }
        }
        #endregion
        //
        //
        //
        #region Selecting Functions
        public void moveup(int dir, int tilesize = 5)
        {
            foreach (Sprite2D s in allSprite2Ds)
            {
                s.setSelected(false);
            }
            //move down
            if (dir > 0)
            {
                ++selectedindex;

                //Check if out of bounds
                if (selectedindex > allSprite2Ds.Count - 1)
                {
                    --selectedindex;
                }

                Window.pb_selector.Top = (int)allSprite2Ds.ElementAt(selectedindex).location.Y;
                Window.pb_selector.Left = (int)allSprite2Ds.ElementAt(selectedindex).location.X;

                //allSprite2Ds.ElementAt(selectedindex).setSelected(true);
            }
            //move up
            if (dir < 0)
            {
                --selectedindex;

                //Check if out of Bounds
                if (selectedindex < 0)
                {
                    ++selectedindex;
                }

                Window.pb_selector.Top = (int)allSprite2Ds.ElementAt(selectedindex).location.Y;
                Window.pb_selector.Left = (int)allSprite2Ds.ElementAt(selectedindex).location.X;

                //allSprite2Ds.ElementAt(selectedindex).setSelected(true);
            }
            Window.Refresh();

            selectedVector = selectedindextovector2d(selectedindex);

            Window.lb_debug_X.Text = "X:" + selectedVector.X.ToString();
            Window.lb_debug_Y.Text = "Y:" + selectedVector.Y.ToString();
        }

        public void moveleft(int dir , int tilesize = 5)
        {
            foreach (Sprite2D s in allSprite2Ds)
            {
                s.setSelected(false);
            }
            //move right
            if (dir > 0)
            {
                selectedindex = selectedindex + tilesize;

                //Check if out of Bounds
                if (selectedindex > allSprite2Ds.Count - 1)
                {
                    selectedindex = selectedindex - tilesize;
                }

                Window.pb_selector.Top = (int)allSprite2Ds.ElementAt(selectedindex).location.Y;
                Window.pb_selector.Left = (int)allSprite2Ds.ElementAt(selectedindex).location.X;

                //allSprite2Ds.ElementAt(selectedindex).setSelected(true);
            }
            //moveleft left
            if (dir < 0)
            {
                selectedindex = selectedindex - tilesize;

                //check if out of bounds
                if (selectedindex < 0)
                {
                    selectedindex = selectedindex + tilesize;
                }

                Window.pb_selector.Top = (int)allSprite2Ds.ElementAt(selectedindex).location.Y;
                Window.pb_selector.Left = (int)allSprite2Ds.ElementAt(selectedindex).location.X;


                //allSprite2Ds.ElementAt(selectedindex).setSelected(true);
            }
            Window.Refresh();

            selectedVector = selectedindextovector2d(selectedindex);

            Window.lb_debug_X.Text = "X:" + selectedVector.X.ToString();
            Window.lb_debug_Y.Text = "Y:" + selectedVector.Y.ToString();
        }

        private Vector2 selectedindextovector2d(int si ,int tilesize = 5)
        {
            Vector2 v = Vector2.Zero();

            int x = 0;
            int y = 0;

            for (int i = 0; i < 150; i++)
            {
                if (si <= tilesize - 1)
                {
                    break;
                }
                x++;
                si = si - tilesize;
            }

            y = si;

            v.X = x;
            v.Y = y;

            return v;
        }

        #endregion
        //
        //
        //
        #region Creator
        public void replacecoorinate(Vector2 location, string name)
        {
            bool exists = false;

            //Check if name exists
            foreach (BaseImage i in Engine.allimages)
            {
                if (i.name == name)
                {
                    exists = true;
                    break;
                }
            }

            //Replace name
            if (exists == true)
            {
                allTiles.ElementAt(selectedtile).Map[(int)location.Y, (int)location.X] = Window.tb_name.Text;
                NewLoadNewTile(allTiles.ElementAt(selectedtile), selectedindex);

                Log.Warning("Sprite at:   X:" + selectedVector.X + "  Y" + selectedVector.Y + "   swaped for:" + name);
                Window.Refresh();
            }
            else
            {
                Log.Error("Sprite name does not exist!!!");
            }
        }

        public void savecurrent(string dir)
        {
            NSave.TileS(allTiles.ElementAt(selectedtile) ,Application.StartupPath + @"\Levels\" + dir);
        } 

        #endregion
    }
}
