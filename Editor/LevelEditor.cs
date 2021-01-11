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

        #region FormVaribles
        private Button bt_LoadLevel;
        private RichTextBox richTextBox1;
        private FolderBrowserDialog FD;
        private TextBox tb_url;
        private NumericUpDown nudIndex;
        private Button btLoadTile;
        //private System.ComponentModel.IContainer components;
        private LevelEditor LB = null;
        private Button btDpadLeft;
        private Button btDpadRight;
        private Button btDpadDown;
        private Button btDpadEnter;
        private Button btDpadUp;
        public Label lb_debug_X;
        public Label lb_debug_Y;
        public TextBox tb_name;
        private Button btNew;
        public Label lb_tilesize;
        private Button bt_saveto;
        public TextBox tb_saveto;
        private TextBox tb_tilesize;
        private TextBox tb_tilename;
        private Label lb_tilename;
        private Button btSetTilesize;
        private Button btSetTilename;
        public PictureBox pb_selector;
        private Panel plInventory1;
        private PictureBox pb_20;
        private PictureBox pb_19;
        private PictureBox pb_18;
        private PictureBox pb_17;
        private PictureBox pb_16;
        private PictureBox pb_15;
        private PictureBox pb_10;
        private PictureBox pb_14;
        private PictureBox pb_13;
        private PictureBox pb_12;
        private PictureBox pb_11;
        private PictureBox pb_5;
        private PictureBox pb_6;
        private PictureBox pb_7;
        private PictureBox pb_8;
        private PictureBox pb_9;
        private PictureBox pb_2;
        private PictureBox pb_3;
        private PictureBox pb_4;
        private PictureBox pb_1;
        private Panel plInventory2;
        private PictureBox pb_40;
        private PictureBox pb_39;
        private PictureBox pb_38;
        private PictureBox pb_37;
        private PictureBox pb_36;
        private PictureBox pb_35;
        private PictureBox pb_30;
        private PictureBox pb_34;
        private PictureBox pb_33;
        private PictureBox pb_32;
        private PictureBox pb_31;
        private PictureBox pb_25;
        private PictureBox pb_26;
        private PictureBox pb_27;
        private PictureBox pb_28;
        private PictureBox pb_29;
        private PictureBox pb_22;
        private PictureBox pb_23;
        private PictureBox pb_24;
        private PictureBox pb_21;
        private Panel panel3;
        private Panel panel4;
        private Panel panel5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btSaveChanges;
        private Label lb_savetodebug;
        private Button bt_newLevel;
        private TextBox tb_newLevel;
        private Label lb_newleveldwbug;
        private Panel panel6;
        public Label lbYMouse;
        public Label lbXMouse;
        private System.Windows.Forms.Timer MouseCoordsTimer;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        #endregion

        public Builder(LevelEditor LB0)
        {
            LB = LB0;
            InitializeComponent();
            lockControls();
        }
        
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Builder));
            this.bt_LoadLevel = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.FD = new System.Windows.Forms.FolderBrowserDialog();
            this.tb_url = new System.Windows.Forms.TextBox();
            this.nudIndex = new System.Windows.Forms.NumericUpDown();
            this.btLoadTile = new System.Windows.Forms.Button();
            this.btDpadLeft = new System.Windows.Forms.Button();
            this.btDpadRight = new System.Windows.Forms.Button();
            this.btDpadDown = new System.Windows.Forms.Button();
            this.btDpadEnter = new System.Windows.Forms.Button();
            this.btDpadUp = new System.Windows.Forms.Button();
            this.lb_debug_X = new System.Windows.Forms.Label();
            this.lb_debug_Y = new System.Windows.Forms.Label();
            this.tb_name = new System.Windows.Forms.TextBox();
            this.btNew = new System.Windows.Forms.Button();
            this.lb_tilesize = new System.Windows.Forms.Label();
            this.bt_saveto = new System.Windows.Forms.Button();
            this.tb_saveto = new System.Windows.Forms.TextBox();
            this.tb_tilesize = new System.Windows.Forms.TextBox();
            this.tb_tilename = new System.Windows.Forms.TextBox();
            this.lb_tilename = new System.Windows.Forms.Label();
            this.btSetTilesize = new System.Windows.Forms.Button();
            this.btSetTilename = new System.Windows.Forms.Button();
            this.pb_selector = new System.Windows.Forms.PictureBox();
            this.plInventory1 = new System.Windows.Forms.Panel();
            this.pb_20 = new System.Windows.Forms.PictureBox();
            this.pb_19 = new System.Windows.Forms.PictureBox();
            this.pb_18 = new System.Windows.Forms.PictureBox();
            this.pb_17 = new System.Windows.Forms.PictureBox();
            this.pb_16 = new System.Windows.Forms.PictureBox();
            this.pb_15 = new System.Windows.Forms.PictureBox();
            this.pb_10 = new System.Windows.Forms.PictureBox();
            this.pb_14 = new System.Windows.Forms.PictureBox();
            this.pb_13 = new System.Windows.Forms.PictureBox();
            this.pb_12 = new System.Windows.Forms.PictureBox();
            this.pb_11 = new System.Windows.Forms.PictureBox();
            this.pb_5 = new System.Windows.Forms.PictureBox();
            this.pb_6 = new System.Windows.Forms.PictureBox();
            this.pb_7 = new System.Windows.Forms.PictureBox();
            this.pb_8 = new System.Windows.Forms.PictureBox();
            this.pb_9 = new System.Windows.Forms.PictureBox();
            this.pb_2 = new System.Windows.Forms.PictureBox();
            this.pb_3 = new System.Windows.Forms.PictureBox();
            this.pb_4 = new System.Windows.Forms.PictureBox();
            this.pb_1 = new System.Windows.Forms.PictureBox();
            this.plInventory2 = new System.Windows.Forms.Panel();
            this.pb_40 = new System.Windows.Forms.PictureBox();
            this.pb_39 = new System.Windows.Forms.PictureBox();
            this.pb_38 = new System.Windows.Forms.PictureBox();
            this.pb_37 = new System.Windows.Forms.PictureBox();
            this.pb_36 = new System.Windows.Forms.PictureBox();
            this.pb_35 = new System.Windows.Forms.PictureBox();
            this.pb_30 = new System.Windows.Forms.PictureBox();
            this.pb_34 = new System.Windows.Forms.PictureBox();
            this.pb_33 = new System.Windows.Forms.PictureBox();
            this.pb_32 = new System.Windows.Forms.PictureBox();
            this.pb_31 = new System.Windows.Forms.PictureBox();
            this.pb_25 = new System.Windows.Forms.PictureBox();
            this.pb_26 = new System.Windows.Forms.PictureBox();
            this.pb_27 = new System.Windows.Forms.PictureBox();
            this.pb_28 = new System.Windows.Forms.PictureBox();
            this.pb_29 = new System.Windows.Forms.PictureBox();
            this.pb_22 = new System.Windows.Forms.PictureBox();
            this.pb_23 = new System.Windows.Forms.PictureBox();
            this.pb_24 = new System.Windows.Forms.PictureBox();
            this.pb_21 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lb_savetodebug = new System.Windows.Forms.Label();
            this.btSaveChanges = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.bt_newLevel = new System.Windows.Forms.Button();
            this.tb_newLevel = new System.Windows.Forms.TextBox();
            this.lb_newleveldwbug = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.lbYMouse = new System.Windows.Forms.Label();
            this.lbXMouse = new System.Windows.Forms.Label();
            this.MouseCoordsTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_selector)).BeginInit();
            this.plInventory1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_1)).BeginInit();
            this.plInventory2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_40)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_39)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_38)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_37)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_36)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_35)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_30)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_34)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_33)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_32)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_25)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_26)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_27)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_28)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_29)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_22)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_23)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_24)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_21)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // bt_LoadLevel
            // 
            this.bt_LoadLevel.CausesValidation = false;
            this.bt_LoadLevel.Location = new System.Drawing.Point(12, 337);
            this.bt_LoadLevel.Name = "bt_LoadLevel";
            this.bt_LoadLevel.Size = new System.Drawing.Size(100, 22);
            this.bt_LoadLevel.TabIndex = 0;
            this.bt_LoadLevel.TabStop = false;
            this.bt_LoadLevel.Text = "LoadLevel";
            this.bt_LoadLevel.UseVisualStyleBackColor = true;
            this.bt_LoadLevel.Click += new System.EventHandler(this.bt_LoadLevelclick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.richTextBox1.CausesValidation = false;
            this.richTextBox1.Enabled = false;
            this.richTextBox1.Location = new System.Drawing.Point(12, 30);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(205, 275);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // tb_url
            // 
            this.tb_url.CausesValidation = false;
            this.tb_url.Location = new System.Drawing.Point(12, 311);
            this.tb_url.Name = "tb_url";
            this.tb_url.Size = new System.Drawing.Size(99, 20);
            this.tb_url.TabIndex = 3;
            this.tb_url.Text = "Test";
            this.tb_url.TextChanged += new System.EventHandler(this.tb_url_TextChanged);
            // 
            // nudIndex
            // 
            this.nudIndex.CausesValidation = false;
            this.nudIndex.Location = new System.Drawing.Point(117, 311);
            this.nudIndex.Name = "nudIndex";
            this.nudIndex.Size = new System.Drawing.Size(100, 20);
            this.nudIndex.TabIndex = 4;
            this.nudIndex.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // btLoadTile
            // 
            this.btLoadTile.CausesValidation = false;
            this.btLoadTile.Location = new System.Drawing.Point(117, 337);
            this.btLoadTile.Name = "btLoadTile";
            this.btLoadTile.Size = new System.Drawing.Size(100, 22);
            this.btLoadTile.TabIndex = 5;
            this.btLoadTile.TabStop = false;
            this.btLoadTile.Text = "LoadTile";
            this.btLoadTile.UseVisualStyleBackColor = true;
            this.btLoadTile.Click += new System.EventHandler(this.LoadTile_Click);
            // 
            // btDpadLeft
            // 
            this.btDpadLeft.Location = new System.Drawing.Point(3, 49);
            this.btDpadLeft.Name = "btDpadLeft";
            this.btDpadLeft.Size = new System.Drawing.Size(40, 40);
            this.btDpadLeft.TabIndex = 6;
            this.btDpadLeft.TabStop = false;
            this.btDpadLeft.Text = "<";
            this.btDpadLeft.UseVisualStyleBackColor = true;
            this.btDpadLeft.Click += new System.EventHandler(this.bt_left_Click);
            // 
            // btDpadRight
            // 
            this.btDpadRight.Location = new System.Drawing.Point(95, 49);
            this.btDpadRight.Name = "btDpadRight";
            this.btDpadRight.Size = new System.Drawing.Size(40, 40);
            this.btDpadRight.TabIndex = 7;
            this.btDpadRight.TabStop = false;
            this.btDpadRight.Text = ">";
            this.btDpadRight.UseVisualStyleBackColor = true;
            this.btDpadRight.Click += new System.EventHandler(this.bt_right_Click);
            // 
            // btDpadDown
            // 
            this.btDpadDown.Location = new System.Drawing.Point(49, 95);
            this.btDpadDown.Name = "btDpadDown";
            this.btDpadDown.Size = new System.Drawing.Size(40, 40);
            this.btDpadDown.TabIndex = 8;
            this.btDpadDown.TabStop = false;
            this.btDpadDown.Text = "\\/";
            this.btDpadDown.UseVisualStyleBackColor = true;
            this.btDpadDown.Click += new System.EventHandler(this.bt_down_Click);
            // 
            // btDpadEnter
            // 
            this.btDpadEnter.Location = new System.Drawing.Point(49, 49);
            this.btDpadEnter.Name = "btDpadEnter";
            this.btDpadEnter.Size = new System.Drawing.Size(40, 40);
            this.btDpadEnter.TabIndex = 9;
            this.btDpadEnter.TabStop = false;
            this.btDpadEnter.Text = "O";
            this.btDpadEnter.UseVisualStyleBackColor = true;
            this.btDpadEnter.Click += new System.EventHandler(this.bt_enter_Click);
            // 
            // btDpadUp
            // 
            this.btDpadUp.BackColor = System.Drawing.SystemColors.Control;
            this.btDpadUp.Location = new System.Drawing.Point(49, 3);
            this.btDpadUp.Name = "btDpadUp";
            this.btDpadUp.Size = new System.Drawing.Size(40, 40);
            this.btDpadUp.TabIndex = 10;
            this.btDpadUp.TabStop = false;
            this.btDpadUp.Text = "/\\";
            this.btDpadUp.UseVisualStyleBackColor = false;
            this.btDpadUp.Click += new System.EventHandler(this.bt_up_Click);
            // 
            // lb_debug_X
            // 
            this.lb_debug_X.AutoSize = true;
            this.lb_debug_X.BackColor = System.Drawing.Color.Transparent;
            this.lb_debug_X.Location = new System.Drawing.Point(3, 2);
            this.lb_debug_X.Name = "lb_debug_X";
            this.lb_debug_X.Size = new System.Drawing.Size(14, 13);
            this.lb_debug_X.TabIndex = 11;
            this.lb_debug_X.Text = "X";
            // 
            // lb_debug_Y
            // 
            this.lb_debug_Y.AutoSize = true;
            this.lb_debug_Y.BackColor = System.Drawing.Color.Transparent;
            this.lb_debug_Y.Location = new System.Drawing.Point(100, 2);
            this.lb_debug_Y.Name = "lb_debug_Y";
            this.lb_debug_Y.Size = new System.Drawing.Size(14, 13);
            this.lb_debug_Y.TabIndex = 12;
            this.lb_debug_Y.Text = "Y";
            // 
            // tb_name
            // 
            this.tb_name.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_name.Location = new System.Drawing.Point(1617, 718);
            this.tb_name.Name = "tb_name";
            this.tb_name.Size = new System.Drawing.Size(143, 20);
            this.tb_name.TabIndex = 13;
            // 
            // btNew
            // 
            this.btNew.Location = new System.Drawing.Point(6, 290);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(220, 20);
            this.btNew.TabIndex = 14;
            this.btNew.Text = "New";
            this.btNew.UseVisualStyleBackColor = true;
            this.btNew.Click += new System.EventHandler(this.bt_new_Click);
            // 
            // lb_tilesize
            // 
            this.lb_tilesize.AutoSize = true;
            this.lb_tilesize.Location = new System.Drawing.Point(7, 76);
            this.lb_tilesize.Name = "lb_tilesize";
            this.lb_tilesize.Size = new System.Drawing.Size(62, 13);
            this.lb_tilesize.TabIndex = 15;
            this.lb_tilesize.Text = "Tilesize: XX";
            // 
            // bt_saveto
            // 
            this.bt_saveto.Enabled = false;
            this.bt_saveto.Location = new System.Drawing.Point(7, 316);
            this.bt_saveto.Name = "bt_saveto";
            this.bt_saveto.Size = new System.Drawing.Size(75, 21);
            this.bt_saveto.TabIndex = 16;
            this.bt_saveto.Text = "Save to :";
            this.bt_saveto.UseVisualStyleBackColor = true;
            this.bt_saveto.Click += new System.EventHandler(this.bt_saveto_Click);
            // 
            // tb_saveto
            // 
            this.tb_saveto.Location = new System.Drawing.Point(86, 316);
            this.tb_saveto.Name = "tb_saveto";
            this.tb_saveto.Size = new System.Drawing.Size(138, 20);
            this.tb_saveto.TabIndex = 17;
            this.tb_saveto.TextChanged += new System.EventHandler(this.tb_saveto_TextChanged);
            // 
            // tb_tilesize
            // 
            this.tb_tilesize.Location = new System.Drawing.Point(162, 73);
            this.tb_tilesize.Name = "tb_tilesize";
            this.tb_tilesize.Size = new System.Drawing.Size(62, 20);
            this.tb_tilesize.TabIndex = 18;
            this.tb_tilesize.Text = "22";
            // 
            // tb_tilename
            // 
            this.tb_tilename.Location = new System.Drawing.Point(162, 47);
            this.tb_tilename.Name = "tb_tilename";
            this.tb_tilename.Size = new System.Drawing.Size(62, 20);
            this.tb_tilename.TabIndex = 19;
            this.tb_tilename.Text = "TEST2";
            // 
            // lb_tilename
            // 
            this.lb_tilename.AutoSize = true;
            this.lb_tilename.Location = new System.Drawing.Point(7, 51);
            this.lb_tilename.Name = "lb_tilename";
            this.lb_tilename.Size = new System.Drawing.Size(66, 13);
            this.lb_tilename.TabIndex = 20;
            this.lb_tilename.Text = "Tilename: \"\"";
            // 
            // btSetTilesize
            // 
            this.btSetTilesize.Location = new System.Drawing.Point(81, 72);
            this.btSetTilesize.Name = "btSetTilesize";
            this.btSetTilesize.Size = new System.Drawing.Size(75, 20);
            this.btSetTilesize.TabIndex = 21;
            this.btSetTilesize.Text = "Set";
            this.btSetTilesize.UseVisualStyleBackColor = true;
            // 
            // btSetTilename
            // 
            this.btSetTilename.Location = new System.Drawing.Point(81, 47);
            this.btSetTilename.Name = "btSetTilename";
            this.btSetTilename.Size = new System.Drawing.Size(75, 20);
            this.btSetTilename.TabIndex = 22;
            this.btSetTilename.Text = "Set";
            this.btSetTilename.UseVisualStyleBackColor = true;
            this.btSetTilename.Click += new System.EventHandler(this.bt_settilename_Click);
            // 
            // pb_selector
            // 
            this.pb_selector.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pb_selector.BackColor = System.Drawing.Color.Transparent;
            this.pb_selector.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pb_selector.BackgroundImage")));
            this.pb_selector.Location = new System.Drawing.Point(335, 905);
            this.pb_selector.Name = "pb_selector";
            this.pb_selector.Size = new System.Drawing.Size(48, 48);
            this.pb_selector.TabIndex = 23;
            this.pb_selector.TabStop = false;
            // 
            // plInventory1
            // 
            this.plInventory1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.plInventory1.BackColor = System.Drawing.SystemColors.Control;
            this.plInventory1.Controls.Add(this.pb_20);
            this.plInventory1.Controls.Add(this.pb_19);
            this.plInventory1.Controls.Add(this.pb_18);
            this.plInventory1.Controls.Add(this.pb_17);
            this.plInventory1.Controls.Add(this.pb_16);
            this.plInventory1.Controls.Add(this.pb_15);
            this.plInventory1.Controls.Add(this.pb_10);
            this.plInventory1.Controls.Add(this.pb_14);
            this.plInventory1.Controls.Add(this.pb_13);
            this.plInventory1.Controls.Add(this.pb_12);
            this.plInventory1.Controls.Add(this.pb_11);
            this.plInventory1.Controls.Add(this.pb_5);
            this.plInventory1.Controls.Add(this.pb_6);
            this.plInventory1.Controls.Add(this.pb_7);
            this.plInventory1.Controls.Add(this.pb_8);
            this.plInventory1.Controls.Add(this.pb_9);
            this.plInventory1.Controls.Add(this.pb_2);
            this.plInventory1.Controls.Add(this.pb_3);
            this.plInventory1.Controls.Add(this.pb_4);
            this.plInventory1.Controls.Add(this.pb_1);
            this.plInventory1.Location = new System.Drawing.Point(335, 757);
            this.plInventory1.Name = "plInventory1";
            this.plInventory1.Size = new System.Drawing.Size(1078, 68);
            this.plInventory1.TabIndex = 24;
            // 
            // pb_20
            // 
            this.pb_20.Location = new System.Drawing.Point(1027, 10);
            this.pb_20.Name = "pb_20";
            this.pb_20.Size = new System.Drawing.Size(48, 48);
            this.pb_20.TabIndex = 19;
            this.pb_20.TabStop = false;
            this.pb_20.Click += new System.EventHandler(this.pb_20_Click);
            // 
            // pb_19
            // 
            this.pb_19.Location = new System.Drawing.Point(973, 10);
            this.pb_19.Name = "pb_19";
            this.pb_19.Size = new System.Drawing.Size(48, 48);
            this.pb_19.TabIndex = 18;
            this.pb_19.TabStop = false;
            this.pb_19.Click += new System.EventHandler(this.pb_19_Click);
            // 
            // pb_18
            // 
            this.pb_18.Location = new System.Drawing.Point(919, 10);
            this.pb_18.Name = "pb_18";
            this.pb_18.Size = new System.Drawing.Size(48, 48);
            this.pb_18.TabIndex = 17;
            this.pb_18.TabStop = false;
            this.pb_18.Click += new System.EventHandler(this.pb_18_Click);
            // 
            // pb_17
            // 
            this.pb_17.Location = new System.Drawing.Point(865, 10);
            this.pb_17.Name = "pb_17";
            this.pb_17.Size = new System.Drawing.Size(48, 48);
            this.pb_17.TabIndex = 16;
            this.pb_17.TabStop = false;
            this.pb_17.Click += new System.EventHandler(this.pb_17_Click);
            // 
            // pb_16
            // 
            this.pb_16.Location = new System.Drawing.Point(811, 10);
            this.pb_16.Name = "pb_16";
            this.pb_16.Size = new System.Drawing.Size(48, 48);
            this.pb_16.TabIndex = 15;
            this.pb_16.TabStop = false;
            this.pb_16.Click += new System.EventHandler(this.pb_16_Click);
            // 
            // pb_15
            // 
            this.pb_15.Location = new System.Drawing.Point(757, 10);
            this.pb_15.Name = "pb_15";
            this.pb_15.Size = new System.Drawing.Size(48, 48);
            this.pb_15.TabIndex = 14;
            this.pb_15.TabStop = false;
            this.pb_15.Click += new System.EventHandler(this.pb_15_Click);
            // 
            // pb_10
            // 
            this.pb_10.Location = new System.Drawing.Point(487, 10);
            this.pb_10.Name = "pb_10";
            this.pb_10.Size = new System.Drawing.Size(48, 48);
            this.pb_10.TabIndex = 13;
            this.pb_10.TabStop = false;
            this.pb_10.Click += new System.EventHandler(this.pb_10_Click);
            // 
            // pb_14
            // 
            this.pb_14.Location = new System.Drawing.Point(703, 10);
            this.pb_14.Name = "pb_14";
            this.pb_14.Size = new System.Drawing.Size(48, 48);
            this.pb_14.TabIndex = 12;
            this.pb_14.TabStop = false;
            this.pb_14.Click += new System.EventHandler(this.pb_14_Click);
            // 
            // pb_13
            // 
            this.pb_13.Location = new System.Drawing.Point(649, 10);
            this.pb_13.Name = "pb_13";
            this.pb_13.Size = new System.Drawing.Size(48, 48);
            this.pb_13.TabIndex = 11;
            this.pb_13.TabStop = false;
            this.pb_13.Click += new System.EventHandler(this.pb_13_Click);
            // 
            // pb_12
            // 
            this.pb_12.Location = new System.Drawing.Point(595, 10);
            this.pb_12.Name = "pb_12";
            this.pb_12.Size = new System.Drawing.Size(48, 48);
            this.pb_12.TabIndex = 10;
            this.pb_12.TabStop = false;
            this.pb_12.Click += new System.EventHandler(this.pb_12_Click);
            // 
            // pb_11
            // 
            this.pb_11.Location = new System.Drawing.Point(541, 10);
            this.pb_11.Name = "pb_11";
            this.pb_11.Size = new System.Drawing.Size(48, 48);
            this.pb_11.TabIndex = 9;
            this.pb_11.TabStop = false;
            this.pb_11.Click += new System.EventHandler(this.pb_11_Click);
            // 
            // pb_5
            // 
            this.pb_5.Location = new System.Drawing.Point(217, 10);
            this.pb_5.Name = "pb_5";
            this.pb_5.Size = new System.Drawing.Size(48, 48);
            this.pb_5.TabIndex = 8;
            this.pb_5.TabStop = false;
            this.pb_5.Click += new System.EventHandler(this.pb_5_Click);
            // 
            // pb_6
            // 
            this.pb_6.Location = new System.Drawing.Point(271, 10);
            this.pb_6.Name = "pb_6";
            this.pb_6.Size = new System.Drawing.Size(48, 48);
            this.pb_6.TabIndex = 7;
            this.pb_6.TabStop = false;
            this.pb_6.Click += new System.EventHandler(this.pb_6_Click);
            // 
            // pb_7
            // 
            this.pb_7.Location = new System.Drawing.Point(325, 10);
            this.pb_7.Name = "pb_7";
            this.pb_7.Size = new System.Drawing.Size(48, 48);
            this.pb_7.TabIndex = 6;
            this.pb_7.TabStop = false;
            this.pb_7.Click += new System.EventHandler(this.pb_7_Click);
            // 
            // pb_8
            // 
            this.pb_8.Location = new System.Drawing.Point(379, 10);
            this.pb_8.Name = "pb_8";
            this.pb_8.Size = new System.Drawing.Size(48, 48);
            this.pb_8.TabIndex = 5;
            this.pb_8.TabStop = false;
            this.pb_8.Click += new System.EventHandler(this.pb_8_Click);
            // 
            // pb_9
            // 
            this.pb_9.Location = new System.Drawing.Point(433, 10);
            this.pb_9.Name = "pb_9";
            this.pb_9.Size = new System.Drawing.Size(48, 48);
            this.pb_9.TabIndex = 4;
            this.pb_9.TabStop = false;
            this.pb_9.Click += new System.EventHandler(this.pb_9_Click);
            // 
            // pb_2
            // 
            this.pb_2.Location = new System.Drawing.Point(55, 10);
            this.pb_2.Name = "pb_2";
            this.pb_2.Size = new System.Drawing.Size(48, 48);
            this.pb_2.TabIndex = 3;
            this.pb_2.TabStop = false;
            this.pb_2.Click += new System.EventHandler(this.pb_2_Click);
            // 
            // pb_3
            // 
            this.pb_3.Location = new System.Drawing.Point(109, 10);
            this.pb_3.Name = "pb_3";
            this.pb_3.Size = new System.Drawing.Size(48, 48);
            this.pb_3.TabIndex = 2;
            this.pb_3.TabStop = false;
            this.pb_3.Click += new System.EventHandler(this.pb_3_Click);
            // 
            // pb_4
            // 
            this.pb_4.Location = new System.Drawing.Point(163, 10);
            this.pb_4.Name = "pb_4";
            this.pb_4.Size = new System.Drawing.Size(48, 48);
            this.pb_4.TabIndex = 1;
            this.pb_4.TabStop = false;
            this.pb_4.Click += new System.EventHandler(this.pb_4_Click);
            // 
            // pb_1
            // 
            this.pb_1.Location = new System.Drawing.Point(1, 10);
            this.pb_1.Name = "pb_1";
            this.pb_1.Size = new System.Drawing.Size(48, 48);
            this.pb_1.TabIndex = 0;
            this.pb_1.TabStop = false;
            this.pb_1.Click += new System.EventHandler(this.pb_1_Click);
            // 
            // plInventory2
            // 
            this.plInventory2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.plInventory2.BackColor = System.Drawing.SystemColors.Control;
            this.plInventory2.Controls.Add(this.pb_40);
            this.plInventory2.Controls.Add(this.pb_39);
            this.plInventory2.Controls.Add(this.pb_38);
            this.plInventory2.Controls.Add(this.pb_37);
            this.plInventory2.Controls.Add(this.pb_36);
            this.plInventory2.Controls.Add(this.pb_35);
            this.plInventory2.Controls.Add(this.pb_30);
            this.plInventory2.Controls.Add(this.pb_34);
            this.plInventory2.Controls.Add(this.pb_33);
            this.plInventory2.Controls.Add(this.pb_32);
            this.plInventory2.Controls.Add(this.pb_31);
            this.plInventory2.Controls.Add(this.pb_25);
            this.plInventory2.Controls.Add(this.pb_26);
            this.plInventory2.Controls.Add(this.pb_27);
            this.plInventory2.Controls.Add(this.pb_28);
            this.plInventory2.Controls.Add(this.pb_29);
            this.plInventory2.Controls.Add(this.pb_22);
            this.plInventory2.Controls.Add(this.pb_23);
            this.plInventory2.Controls.Add(this.pb_24);
            this.plInventory2.Controls.Add(this.pb_21);
            this.plInventory2.Location = new System.Drawing.Point(335, 831);
            this.plInventory2.Name = "plInventory2";
            this.plInventory2.Size = new System.Drawing.Size(1078, 68);
            this.plInventory2.TabIndex = 25;
            // 
            // pb_40
            // 
            this.pb_40.Location = new System.Drawing.Point(1027, 10);
            this.pb_40.Name = "pb_40";
            this.pb_40.Size = new System.Drawing.Size(48, 48);
            this.pb_40.TabIndex = 19;
            this.pb_40.TabStop = false;
            this.pb_40.Click += new System.EventHandler(this.pb_40_Click);
            // 
            // pb_39
            // 
            this.pb_39.Location = new System.Drawing.Point(973, 10);
            this.pb_39.Name = "pb_39";
            this.pb_39.Size = new System.Drawing.Size(48, 48);
            this.pb_39.TabIndex = 18;
            this.pb_39.TabStop = false;
            this.pb_39.Click += new System.EventHandler(this.pb_39_Click);
            // 
            // pb_38
            // 
            this.pb_38.Location = new System.Drawing.Point(919, 10);
            this.pb_38.Name = "pb_38";
            this.pb_38.Size = new System.Drawing.Size(48, 48);
            this.pb_38.TabIndex = 17;
            this.pb_38.TabStop = false;
            this.pb_38.Click += new System.EventHandler(this.pb_38_Click);
            // 
            // pb_37
            // 
            this.pb_37.Location = new System.Drawing.Point(865, 10);
            this.pb_37.Name = "pb_37";
            this.pb_37.Size = new System.Drawing.Size(48, 48);
            this.pb_37.TabIndex = 16;
            this.pb_37.TabStop = false;
            this.pb_37.Click += new System.EventHandler(this.pb_37_Click);
            // 
            // pb_36
            // 
            this.pb_36.Location = new System.Drawing.Point(811, 10);
            this.pb_36.Name = "pb_36";
            this.pb_36.Size = new System.Drawing.Size(48, 48);
            this.pb_36.TabIndex = 15;
            this.pb_36.TabStop = false;
            this.pb_36.Click += new System.EventHandler(this.pb_36_Click);
            // 
            // pb_35
            // 
            this.pb_35.Location = new System.Drawing.Point(757, 10);
            this.pb_35.Name = "pb_35";
            this.pb_35.Size = new System.Drawing.Size(48, 48);
            this.pb_35.TabIndex = 14;
            this.pb_35.TabStop = false;
            this.pb_35.Click += new System.EventHandler(this.pb_35_Click);
            // 
            // pb_30
            // 
            this.pb_30.Location = new System.Drawing.Point(487, 10);
            this.pb_30.Name = "pb_30";
            this.pb_30.Size = new System.Drawing.Size(48, 48);
            this.pb_30.TabIndex = 13;
            this.pb_30.TabStop = false;
            this.pb_30.Click += new System.EventHandler(this.pb_30_Click);
            // 
            // pb_34
            // 
            this.pb_34.Location = new System.Drawing.Point(703, 10);
            this.pb_34.Name = "pb_34";
            this.pb_34.Size = new System.Drawing.Size(48, 48);
            this.pb_34.TabIndex = 12;
            this.pb_34.TabStop = false;
            this.pb_34.Click += new System.EventHandler(this.pb_34_Click);
            // 
            // pb_33
            // 
            this.pb_33.Location = new System.Drawing.Point(649, 10);
            this.pb_33.Name = "pb_33";
            this.pb_33.Size = new System.Drawing.Size(48, 48);
            this.pb_33.TabIndex = 11;
            this.pb_33.TabStop = false;
            this.pb_33.Click += new System.EventHandler(this.pb_33_Click);
            // 
            // pb_32
            // 
            this.pb_32.Location = new System.Drawing.Point(595, 10);
            this.pb_32.Name = "pb_32";
            this.pb_32.Size = new System.Drawing.Size(48, 48);
            this.pb_32.TabIndex = 10;
            this.pb_32.TabStop = false;
            this.pb_32.Click += new System.EventHandler(this.pb_32_Click);
            // 
            // pb_31
            // 
            this.pb_31.Location = new System.Drawing.Point(541, 10);
            this.pb_31.Name = "pb_31";
            this.pb_31.Size = new System.Drawing.Size(48, 48);
            this.pb_31.TabIndex = 9;
            this.pb_31.TabStop = false;
            this.pb_31.Click += new System.EventHandler(this.pb_31_Click);
            // 
            // pb_25
            // 
            this.pb_25.Location = new System.Drawing.Point(217, 10);
            this.pb_25.Name = "pb_25";
            this.pb_25.Size = new System.Drawing.Size(48, 48);
            this.pb_25.TabIndex = 8;
            this.pb_25.TabStop = false;
            this.pb_25.Click += new System.EventHandler(this.pb_25_Click);
            // 
            // pb_26
            // 
            this.pb_26.Location = new System.Drawing.Point(271, 10);
            this.pb_26.Name = "pb_26";
            this.pb_26.Size = new System.Drawing.Size(48, 48);
            this.pb_26.TabIndex = 7;
            this.pb_26.TabStop = false;
            this.pb_26.Click += new System.EventHandler(this.pb_26_Click);
            // 
            // pb_27
            // 
            this.pb_27.Location = new System.Drawing.Point(325, 10);
            this.pb_27.Name = "pb_27";
            this.pb_27.Size = new System.Drawing.Size(48, 48);
            this.pb_27.TabIndex = 6;
            this.pb_27.TabStop = false;
            this.pb_27.Click += new System.EventHandler(this.pb_27_Click);
            // 
            // pb_28
            // 
            this.pb_28.Location = new System.Drawing.Point(379, 10);
            this.pb_28.Name = "pb_28";
            this.pb_28.Size = new System.Drawing.Size(48, 48);
            this.pb_28.TabIndex = 5;
            this.pb_28.TabStop = false;
            this.pb_28.Click += new System.EventHandler(this.pb_28_Click);
            // 
            // pb_29
            // 
            this.pb_29.Location = new System.Drawing.Point(433, 10);
            this.pb_29.Name = "pb_29";
            this.pb_29.Size = new System.Drawing.Size(48, 48);
            this.pb_29.TabIndex = 4;
            this.pb_29.TabStop = false;
            this.pb_29.Click += new System.EventHandler(this.pb_29_Click);
            // 
            // pb_22
            // 
            this.pb_22.Location = new System.Drawing.Point(55, 10);
            this.pb_22.Name = "pb_22";
            this.pb_22.Size = new System.Drawing.Size(48, 48);
            this.pb_22.TabIndex = 3;
            this.pb_22.TabStop = false;
            this.pb_22.Click += new System.EventHandler(this.pb_22_Click);
            // 
            // pb_23
            // 
            this.pb_23.Location = new System.Drawing.Point(109, 10);
            this.pb_23.Name = "pb_23";
            this.pb_23.Size = new System.Drawing.Size(48, 48);
            this.pb_23.TabIndex = 2;
            this.pb_23.TabStop = false;
            this.pb_23.Click += new System.EventHandler(this.pb_23_Click);
            // 
            // pb_24
            // 
            this.pb_24.Location = new System.Drawing.Point(163, 10);
            this.pb_24.Name = "pb_24";
            this.pb_24.Size = new System.Drawing.Size(48, 48);
            this.pb_24.TabIndex = 1;
            this.pb_24.TabStop = false;
            this.pb_24.Click += new System.EventHandler(this.pb_24_Click);
            // 
            // pb_21
            // 
            this.pb_21.Location = new System.Drawing.Point(1, 10);
            this.pb_21.Name = "pb_21";
            this.pb_21.Size = new System.Drawing.Size(48, 48);
            this.pb_21.TabIndex = 0;
            this.pb_21.TabStop = false;
            this.pb_21.Click += new System.EventHandler(this.pb_21_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.Control;
            this.panel3.Controls.Add(this.lb_savetodebug);
            this.panel3.Controls.Add(this.btSaveChanges);
            this.panel3.Controls.Add(this.btNew);
            this.panel3.Controls.Add(this.tb_tilesize);
            this.panel3.Controls.Add(this.tb_tilename);
            this.panel3.Controls.Add(this.btSetTilesize);
            this.panel3.Controls.Add(this.btSetTilename);
            this.panel3.Controls.Add(this.bt_saveto);
            this.panel3.Controls.Add(this.tb_saveto);
            this.panel3.Controls.Add(this.lb_tilename);
            this.panel3.Controls.Add(this.lb_tilesize);
            this.panel3.Location = new System.Drawing.Point(1541, 30);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(231, 367);
            this.panel3.TabIndex = 26;
            // 
            // lb_savetodebug
            // 
            this.lb_savetodebug.ForeColor = System.Drawing.Color.Red;
            this.lb_savetodebug.Location = new System.Drawing.Point(7, 340);
            this.lb_savetodebug.Name = "lb_savetodebug";
            this.lb_savetodebug.Size = new System.Drawing.Size(217, 20);
            this.lb_savetodebug.TabIndex = 24;
            this.lb_savetodebug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btSaveChanges
            // 
            this.btSaveChanges.Location = new System.Drawing.Point(8, 99);
            this.btSaveChanges.Name = "btSaveChanges";
            this.btSaveChanges.Size = new System.Drawing.Size(220, 20);
            this.btSaveChanges.TabIndex = 23;
            this.btSaveChanges.Text = "Save Changes";
            this.btSaveChanges.UseVisualStyleBackColor = true;
            this.btSaveChanges.Click += new System.EventHandler(this.bt_savechanges_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.SystemColors.Control;
            this.panel4.Controls.Add(this.btDpadUp);
            this.panel4.Controls.Add(this.btDpadEnter);
            this.panel4.Controls.Add(this.btDpadDown);
            this.panel4.Controls.Add(this.btDpadRight);
            this.panel4.Controls.Add(this.btDpadLeft);
            this.panel4.Location = new System.Drawing.Point(1622, 754);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(138, 139);
            this.panel4.TabIndex = 27;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel5.Controls.Add(this.lb_debug_Y);
            this.panel5.Controls.Add(this.lb_debug_X);
            this.panel5.Location = new System.Drawing.Point(1622, 898);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(138, 19);
            this.panel5.TabIndex = 28;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(1548, 721);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Spritename:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(9, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Level:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(1538, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Toolbox:";
            // 
            // bt_newLevel
            // 
            this.bt_newLevel.Enabled = false;
            this.bt_newLevel.Location = new System.Drawing.Point(12, 391);
            this.bt_newLevel.Name = "bt_newLevel";
            this.bt_newLevel.Size = new System.Drawing.Size(202, 20);
            this.bt_newLevel.TabIndex = 31;
            this.bt_newLevel.Text = "New";
            this.bt_newLevel.UseVisualStyleBackColor = true;
            this.bt_newLevel.Click += new System.EventHandler(this.bt_newLevel_Click);
            // 
            // tb_newLevel
            // 
            this.tb_newLevel.CausesValidation = false;
            this.tb_newLevel.Location = new System.Drawing.Point(13, 365);
            this.tb_newLevel.Name = "tb_newLevel";
            this.tb_newLevel.Size = new System.Drawing.Size(201, 20);
            this.tb_newLevel.TabIndex = 32;
            this.tb_newLevel.TextChanged += new System.EventHandler(this.tb_newLevel_TextChanged);
            // 
            // lb_newleveldwbug
            // 
            this.lb_newleveldwbug.Location = new System.Drawing.Point(12, 414);
            this.lb_newleveldwbug.Name = "lb_newleveldwbug";
            this.lb_newleveldwbug.Size = new System.Drawing.Size(202, 19);
            this.lb_newleveldwbug.TabIndex = 33;
            this.lb_newleveldwbug.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel6.Controls.Add(this.lbYMouse);
            this.panel6.Controls.Add(this.lbXMouse);
            this.panel6.Location = new System.Drawing.Point(1622, 923);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(138, 19);
            this.panel6.TabIndex = 29;
            // 
            // lbYMouse
            // 
            this.lbYMouse.AutoSize = true;
            this.lbYMouse.BackColor = System.Drawing.Color.Transparent;
            this.lbYMouse.Location = new System.Drawing.Point(100, 2);
            this.lbYMouse.Name = "lbYMouse";
            this.lbYMouse.Size = new System.Drawing.Size(14, 13);
            this.lbYMouse.TabIndex = 12;
            this.lbYMouse.Text = "Y";
            // 
            // lbXMouse
            // 
            this.lbXMouse.AutoSize = true;
            this.lbXMouse.BackColor = System.Drawing.Color.Transparent;
            this.lbXMouse.Location = new System.Drawing.Point(3, 2);
            this.lbXMouse.Name = "lbXMouse";
            this.lbXMouse.Size = new System.Drawing.Size(14, 13);
            this.lbXMouse.TabIndex = 11;
            this.lbXMouse.Text = "X";
            // 
            // MouseCoordsTimer
            // 
            this.MouseCoordsTimer.Enabled = true;
            this.MouseCoordsTimer.Interval = 20;
            this.MouseCoordsTimer.Tick += new System.EventHandler(this.coordsTick);
            // 
            // Builder
            // 
            this.ClientSize = new System.Drawing.Size(1784, 961);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.lb_newleveldwbug);
            this.Controls.Add(this.tb_newLevel);
            this.Controls.Add(this.bt_newLevel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.plInventory2);
            this.Controls.Add(this.plInventory1);
            this.Controls.Add(this.pb_selector);
            this.Controls.Add(this.btLoadTile);
            this.Controls.Add(this.nudIndex);
            this.Controls.Add(this.tb_url);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.tb_name);
            this.Controls.Add(this.bt_LoadLevel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Builder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Builder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_selector)).EndInit();
            this.plInventory1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_1)).EndInit();
            this.plInventory2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_40)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_39)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_38)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_37)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_36)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_35)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_30)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_34)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_33)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_32)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_25)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_26)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_27)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_28)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_29)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_22)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_23)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_24)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_21)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        
        private void Builder_Load(object sender, EventArgs e)
        {
            Log.info("[BUILDER]  -  GUI Loaded");

            LB.loadPictureBoxes();
        }
        #endregion
        //
        //
        #region loadPictureboxes
        public void setPictureBoxes(int i, Bitmap bitmap)
        {
            switch (i)
            {
                case 0: pb_1.Image = bitmap;
                    break;
                case 1: pb_2.Image = bitmap;
                    break;
                case 2: pb_3.Image = bitmap;
                    break;
                case 3: pb_4.Image = bitmap;
                    break;
                case 4: pb_5.Image = bitmap;
                    break;
                case 5: pb_6.Image = bitmap;
                    break;
                case 6: pb_7.Image = bitmap;
                    break;
                case 7: pb_8.Image = bitmap;
                    break;
                case 8: pb_9.Image = bitmap;
                    break;
                case 9: pb_10.Image = bitmap;
                    break;
                case 10: pb_11.Image = bitmap;
                    break;
                case 11: pb_12.Image = bitmap;
                    break;
                case 12: pb_13.Image = bitmap;
                    break;
                case 13: pb_14.Image = bitmap;
                    break;
                case 14: pb_15.Image = bitmap;
                    break;
                case 15: pb_16.Image = bitmap;
                    break;
                case 16: pb_17.Image = bitmap; 
                    break;
                case 17: pb_18.Image = bitmap;
                    break;
                case 18: pb_19.Image = bitmap;
                    break;
                case 19: pb_20.Image = bitmap;
                    break;
                case 20: pb_21.Image = bitmap;
                    break;
                case 21: pb_22.Image = bitmap;
                    break;
                case 22: pb_23.Image = bitmap;
                    break;
                case 23: pb_24.Image = bitmap;
                    break;
                case 24: pb_25.Image = bitmap;
                    break;
                case 25: pb_26.Image = bitmap;
                    break;
                case 26: pb_27.Image = bitmap;
                    break;
                case 27: pb_28.Image = bitmap;
                    break;
                case 28: pb_29.Image = bitmap;
                    break;
                case 29: pb_30.Image = bitmap;
                    break;
                case 30: pb_31.Image = bitmap;
                    break;
                case 31: pb_32.Image = bitmap;
                    break;
                case 32: pb_33.Image = bitmap;
                    break;
                case 33: pb_34.Image = bitmap;
                    break;
                case 34: pb_35.Image = bitmap;
                    break;
                case 35: pb_36.Image = bitmap;
                    break;
                case 36: pb_37.Image = bitmap;
                    break;
                case 37: pb_38.Image = bitmap;
                    break;
                case 38: pb_39.Image = bitmap;
                    break;
                case 39: pb_40.Image = bitmap;
                    break;
            }
        }
        #endregion
        //
        //
        #region Controls Lock/Unlock
        public void lockControls()
        {
            btSaveChanges.Enabled = false;
            nudIndex.Enabled = false;
            btLoadTile.Enabled = false;

            btDpadUp.Enabled = false;
            btDpadLeft.Enabled = false;
            btDpadDown.Enabled = false;
            btDpadRight.Enabled = false;
            btDpadEnter.Enabled = false;

            btSetTilename.Enabled = false;
            btSetTilesize.Enabled = false;
            //btNew.Enabled = false; erstellt map

            plInventory1.Enabled = false;
            plInventory2.Enabled = false;
        }

        public void unlockControlls()
        {
            btSaveChanges.Enabled = true;
            nudIndex.Enabled = true;
            btLoadTile.Enabled = true;

            btDpadUp.Enabled = true;
            btDpadLeft.Enabled = true;
            btDpadDown.Enabled = true;
            btDpadRight.Enabled = true;
            btDpadEnter.Enabled = true;

            btSetTilesize.Enabled = true;
            btSetTilename.Enabled = true;
            //btNew.Enabled = true; erstellt map

            plInventory1.Enabled = true;
            plInventory2.Enabled = true;
        }
        #endregion
        //
        //
        #region Input

        private void tb_url_TextChanged(object sender, EventArgs e)
        {
            string content = tb_url.Text;
            string path = Application.StartupPath + @"\Levels\" + content;

            if (Directory.Exists(path))
            {
                tb_url.ForeColor = Color.Green;
            }
            else
            {
                tb_url.ForeColor = Color.Red;
            }
        }


        private void bt_settilename_Click(object sender, EventArgs e)
        {
            LB.allTiles.ElementAt((int)nudIndex.Value).name = tb_tilename.Text;
            Log.info("[CHANGED]  -  NAME to: " + LB.allTiles.ElementAt((int)nudIndex.Value).name);
        }

        private void bt_LoadLevelclick(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\Levels\" + tb_url.Text;

            if (Directory.Exists(path) && tb_url.Text != "")
            {
                //Set loadedlevelname varible and Log
                LB.loadedlevelname = tb_url.Text;
                Log.info("[BUILDER]  -  Level Exists     Name:" + LB.loadedlevelname);

                //Load Tiles in List
                LB.allTiles = NLoad.tilesL(path);
                richTextBox1.Text = "";

                //Add Tiles to RichTextBox
                int index = 0;
                foreach (Tile t in LB.allTiles)
                {
                    richTextBox1.Text = richTextBox1.Text + "Index:" + index.ToString() + "     Name:" + t.name + "\n";
                    index++;
                }

                //Check if there is i Tile to load
                if (LB.allTiles.Count > 0)
                {
                    LB.newLoadNewTile(LB.allTiles.ElementAt(0));
                }

                //Redraw Window
                LB.window.Refresh();

                unlockControlls();
            }
            else
            {
                Log.error("Directory does not Exist");
            }
        }

        private void bt_UnLoadTile_Click(object sender, EventArgs e)
        {
            LB.unloadCurrentTile();
            LB.window.Refresh();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (nudIndex.Value <= LB.allTiles.Count - 1 && nudIndex.Value >= 0)
            {
                LB.newLoadNewTile(LB.allTiles.ElementAt((int)nudIndex.Value));
                LB.window.Refresh();

                LB.selectedtile = (int)nudIndex.Value;
            }
            if (nudIndex.Value > LB.allTiles.Count - 1)
            {
                nudIndex.Value = LB.allTiles.Count - 1;
            }
            if (nudIndex.Value < 0)
            {
                nudIndex.Value = 0;
            }
            else
            {

            }
        }

        private void LoadTile_Click(object sender, EventArgs e)
        {
            if (nudIndex.Value <= LB.allTiles.Count - 1 && nudIndex.Value >= 0)
            {
                LB.newLoadNewTile(LB.allTiles.ElementAt((int)nudIndex.Value));
            }
            else
            {

            }
        }

        //Welcher Btn?-----
        private void button2_Click(object sender, EventArgs e)
        {
            LB.window.Refresh();
        }
        //-----------------

        #region Dpad
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

        #endregion

        #endregion
        //
        //
        #region tile dieting
        private void bt_new_Click(object sender, EventArgs e)
        {
            //Custom
            /*
            if (tb_tilename.Text != null || tb_tilesize.Text != null)
            {
                LB.allTiles.Clear();
                tb_url.Text = "";

                LB.allTiles.Add(new Tile(true, tb_tilename.Text, Convert.ToInt32(tb_tilesize.Text)));
                LB.selectedtile = 0;
                LB.NewLoadNewTile(LB.allTiles.ElementAt(0));
                Log.Info("[NEW TILE]  -  " + LB.allTiles.ElementAt(0).name);
            }
            else
            {

            }*/

            LB.allTiles.Clear();
            tb_url.Text = "";

            LB.allTiles.Add(new Tile(true, "Test20", 27,new Vector2(200,200)));
            LB.selectedtile = 0;
            LB.newLoadNewTile(LB.allTiles.ElementAt(0));
            Log.info("[NEW TILE]  -  " + LB.allTiles.ElementAt(0).name);

            unlockControlls();
        }

        private void bt_saveto_Click(object sender, EventArgs e)
        {
            if (tb_saveto.Text != null)
            {
                LB.savecurrenttoLevel(tb_saveto.Text);
            }
            else
            {

            }

        }

        private void tb_saveto_TextChanged(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\Levels\" + tb_saveto.Text;

            if (Directory.Exists(path) && path != Application.StartupPath + @"\Levels\")
            {
                lb_savetodebug.ForeColor = Color.Green;
                lb_savetodebug.Text = "Level exists";
                bt_saveto.Enabled = true;
            }
            else
            {
                lb_savetodebug.ForeColor = Color.Red;
                lb_savetodebug.Text = "Level doenst exists";
                bt_saveto.Enabled = false;
            }
        }

        private void bt_savechanges_Click(object sender, EventArgs e)
        {
            LB.savecurrent();
        }
        #endregion
        //
        //
        #region Level Editing
        private void bt_newLevel_Click(object sender, EventArgs e)
        {
            Directory.CreateDirectory(Application.StartupPath + @"\Levels\" + tb_newLevel.Text);
        }

        private void tb_newLevel_TextChanged(object sender, EventArgs e)
        {
            string path = Application.StartupPath + @"\Levels\" + tb_newLevel.Text;
            if (Directory.Exists(path))
            {
                lb_newleveldwbug.ForeColor = Color.Red;
                lb_newleveldwbug.Text = "Level already exists!";
                bt_newLevel.Enabled = false;
            }
            else
            {
                lb_newleveldwbug.ForeColor = Color.Green;
                lb_newleveldwbug.Text = "Path free!";
                bt_newLevel.Enabled = true;
            }
            if(path == Application.StartupPath + @"\Levels\")
            {
                lb_newleveldwbug.ForeColor = Color.Red;
                lb_newleveldwbug.Text = "Name cannot be empty!";
                bt_newLevel.Enabled = false;
            }
        }

        #endregion
        //
        //
        #region ClickEvents SpriteSelection / Inventory
        private void pb_1_Click(object sender, EventArgs e)
        {
            LB.pbSelect(1);
        }

        private void pb_2_Click(object sender, EventArgs e)
        {
            LB.pbSelect(2);
        }

        private void pb_3_Click(object sender, EventArgs e)
        {
            LB.pbSelect(3);
        }

        private void pb_4_Click(object sender, EventArgs e)
        {
            LB.pbSelect(4);
        }

        private void pb_5_Click(object sender, EventArgs e)
        {
            LB.pbSelect(5);
        }

        private void pb_6_Click(object sender, EventArgs e)
        {
            LB.pbSelect(6);
        }

        private void pb_7_Click(object sender, EventArgs e)
        {
            LB.pbSelect(7);
        }

        private void pb_8_Click(object sender, EventArgs e)
        {
            LB.pbSelect(8);
        }

        private void pb_9_Click(object sender, EventArgs e)
        {
            LB.pbSelect(9);
        }

        private void pb_10_Click(object sender, EventArgs e)
        {
            LB.pbSelect(10);
        }

        private void pb_11_Click(object sender, EventArgs e)
        {
            LB.pbSelect(11);
        }

        private void pb_12_Click(object sender, EventArgs e)
        {
            LB.pbSelect(12);
        }

        private void pb_13_Click(object sender, EventArgs e)
        {
            LB.pbSelect(13);
        }

        private void pb_14_Click(object sender, EventArgs e)
        {
            LB.pbSelect(14);
        }

        private void pb_15_Click(object sender, EventArgs e)
        {
            LB.pbSelect(15);
        }

        private void pb_16_Click(object sender, EventArgs e)
        {
            LB.pbSelect(16);
        }

        private void pb_17_Click(object sender, EventArgs e)
        {
            LB.pbSelect(17);
        }

        private void pb_18_Click(object sender, EventArgs e)
        {
            LB.pbSelect(18);
        }

        private void pb_19_Click(object sender, EventArgs e)
        {
            LB.pbSelect(19);
        }

        private void pb_20_Click(object sender, EventArgs e)
        {
            LB.pbSelect(20);
        }

        private void pb_21_Click(object sender, EventArgs e)
        {
            LB.pbSelect(21);
        }

        private void pb_22_Click(object sender, EventArgs e)
        {
            LB.pbSelect(22);
        }

        private void pb_23_Click(object sender, EventArgs e)
        {
            LB.pbSelect(23);
        }

        private void pb_24_Click(object sender, EventArgs e)
        {
            LB.pbSelect(24);
        }

        private void pb_25_Click(object sender, EventArgs e)
        {
            LB.pbSelect(25);
        }

        private void pb_26_Click(object sender, EventArgs e)
        {
            LB.pbSelect(26);
        }

        private void pb_27_Click(object sender, EventArgs e)
        {
            LB.pbSelect(27);
        }

        private void pb_28_Click(object sender, EventArgs e)
        {
            LB.pbSelect(28);
        }

        private void pb_29_Click(object sender, EventArgs e)
        {
            LB.pbSelect(29);
        }

        private void pb_30_Click(object sender, EventArgs e)
        {
            LB.pbSelect(30);
        }

        private void pb_31_Click(object sender, EventArgs e)
        {
            LB.pbSelect(31);
        }

        private void pb_32_Click(object sender, EventArgs e)
        {
            LB.pbSelect(32);
        }

        private void pb_33_Click(object sender, EventArgs e)
        {
            LB.pbSelect(33);
        }

        private void pb_34_Click(object sender, EventArgs e)
        {
            LB.pbSelect(34);
        }

        private void pb_35_Click(object sender, EventArgs e)
        {
            LB.pbSelect(35);
        }

        private void pb_36_Click(object sender, EventArgs e)
        {
            LB.pbSelect(36);
        }

        private void pb_37_Click(object sender, EventArgs e)
        {
            LB.pbSelect(37);
        }

        private void pb_38_Click(object sender, EventArgs e)
        {
            LB.pbSelect(38);
        }

        private void pb_39_Click(object sender, EventArgs e)
        {
            LB.pbSelect(39);
        }

        private void pb_40_Click(object sender, EventArgs e)
        {
            LB.pbSelect(40);
        }


        #endregion
        //
        //
        #region CoordsTick
        private void coordsTick(object sender, EventArgs e)
        {
            lbXMouse.Text = "X: " + Convert.ToString(Cursor.Position.X);
            lbYMouse.Text = "Y: " + Convert.ToString(Cursor.Position.Y);
        }
        #endregion

    }
    //

    //---------------------------------------------------------------------------------------------------------------------------------------------------------------

    //---------------------------------------------------------------------------------------------------------------------------------------------------------------

    //
    public class LevelEditor 
    {
        #region Init Builder
        private Vector2 screenSize = new Vector2(1800, 1000);
        private string title = "Level Builder - ";
        public Builder window = null;

        private int selectedindex = 0;
        public Vector2 selectedVector = Vector2.Zero();
        public int selectedtile = 0;

        public void loadBuilderGUI()
        {
            window = new Builder(this);
            window.Size = new Size((int)screenSize.X, (int)screenSize.Y);
            window.Text = this.title;
            //Window.FormBorderStyle = FormBorderStyle.SizableToolWindow;
            window.Paint += window_Paint;
            
            Application.Run(window);
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

        public Vector2 maporigin = new Vector2(240, 30);
        public Sprite2D selector = null;

        public string previewpng = string.Empty;

        public string loadedlevelname = string.Empty;


        public LevelEditor()
        {
            foreach (string sl in allcontentlocations)
            {
                NLoad.imagesfromDirectory(sl , allimages);
            }

            loadBuilderGUI();
        }

        #endregion
        //
        // //
        //
        #region Core Functions
        private void window_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(SystemColors.ControlLight);

            foreach (Sprite2D sprite in allSprite2Ds)
            {
                try
                {
                    g.DrawImage(sprite.bitmap, sprite.location.X, sprite.location.Y, sprite.scale.X, sprite.scale.Y);
                }
                catch
                {
                    Log.error("Sprite couldnt be drawn");
                }
            }
        }

        public void loadNewTile(Tile t)
        {
            allSprite2Ds.Clear();
            Log.info("[LOADING]:" + t.name);
            for (int i = 0; i < t.map.GetLength(0); i++)
            {
                for (int j = 0; j < t.map.GetLength(1); j++)
                {
                    if (t.map[j, i] == "g")
                    {
                        allSprite2Ds.Add(new Sprite2D(new Vector2(i * 48 + maporigin.X, j * 48 + maporigin.Y), new Vector2(48, 48), "Overworld/Tiles/tile22", "Collider",true, true, this));
                    }
                    if (t.map[j, i] == "w")
                    {
                        allSprite2Ds.Add(new Sprite2D(new Vector2(i * 48 + maporigin.X, j * 48 + maporigin.Y), new Vector2(48, 48), "Overworld/Tiles/tile53", "Collider", true, true, this));
                    }
                    if (t.map[j, i] == "s")
                    {
                        allSprite2Ds.Add(new Sprite2D(new Vector2(i * 48 + maporigin.X, j * 48 + maporigin.Y), new Vector2(48, 48), "Overworld/Tiles/tile12", "BackGround", true, true, this));
                    }
                    if (t.map[j, i] == "dr")
                    {
                        allSprite2Ds.Add(new Sprite2D(new Vector2(i * 48 + maporigin.X, j * 48 + maporigin.Y), new Vector2(48, 48), "Overworld/Tiles/tile110", "Collider", true, true, this));
                    }
                    if (t.map[j, i] == "dl")
                    {
                        allSprite2Ds.Add(new Sprite2D(new Vector2(i * 48 + maporigin.X, j * 48 + maporigin.Y), new Vector2(48, 48), "Overworld/Tiles/tile110", "Collider", true, true, this));
                    }
                }
            }
        }

        public void newLoadNewTile(Tile t , int selected = 0)
        {
            allSprite2Ds.Clear();
            Log.info("[LOADING] - [Tile]:" + t.name);
            for (int i = 0; i < t.map.GetLength(0); i++)
            {
                for (int j = 0; j < t.map.GetLength(1); j++)
                {
                    if (t.map[j, i] != ".")
                    {
                        allSprite2Ds.Add(new Sprite2D(new Vector2(i * 48 + maporigin.X, j * 48 + maporigin.Y), new Vector2(48, 48), t.map[j, i], "Collider", true, true, this));
                    }
                    else
                    {
                        //No Sprite to draw
                    }
                }
            }
            window.lb_tilesize.Text = "Tilesize:" + t.tilesize;

            window.Refresh();
        }

        public void unloadCurrentTile()
        {
            Log.warning("Clearing all Sprites");
            int count = Engine.allSprites.Count;
            for (int i = 0; i < count; ++i)
            {
                Engine.allSprites.ElementAt(0).DestroySelf();
                Console.WriteLine(Engine.allSprites.Count.ToString());
            }
        }

        public void loadPictureBoxes()
        {
            int index = 0;
            foreach (BaseImage b in allimages)
            {
                if (index > 0)
                {
                    window.setPictureBoxes(index - 1, b.image);
                }
                index++;
            }
            Log.info("[BUILDER] - Reference Sprite loaded");
        }

        #endregion
        //
        //
        //
        #region Selecting Functions
        public void moveup(int dir, int tilesize = 27)
        {
            //move down
            if (dir > 0)
            {
                ++selectedindex;

                //Check if out of bounds
                if (selectedindex > allSprite2Ds.Count - 1)
                {
                    --selectedindex;
                }

                window.pb_selector.Top = (int)allSprite2Ds.ElementAt(selectedindex).location.Y;
                window.pb_selector.Left = (int)allSprite2Ds.ElementAt(selectedindex).location.X;

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

                window.pb_selector.Top = (int)allSprite2Ds.ElementAt(selectedindex).location.Y;
                window.pb_selector.Left = (int)allSprite2Ds.ElementAt(selectedindex).location.X;

                //allSprite2Ds.ElementAt(selectedindex).setSelected(true);
            }
            window.Refresh();

            selectedVector = selectedindextovector2d(selectedindex);

            window.lb_debug_X.Text = "X:" + selectedVector.X.ToString();
            window.lb_debug_Y.Text = "Y:" + selectedVector.Y.ToString();
        }

        public void moveleft(int dir , int tilesize = 15)
        {
            //move right
            if (dir > 0)
            {
                selectedindex = selectedindex + tilesize;

                //Check if out of Bounds
                if (selectedindex > allSprite2Ds.Count - 1)
                {
                    selectedindex = selectedindex - tilesize;
                }

                window.pb_selector.Top = (int)allSprite2Ds.ElementAt(selectedindex).location.Y;
                window.pb_selector.Left = (int)allSprite2Ds.ElementAt(selectedindex).location.X;

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

                window.pb_selector.Top = (int)allSprite2Ds.ElementAt(selectedindex).location.Y;
                window.pb_selector.Left = (int)allSprite2Ds.ElementAt(selectedindex).location.X;


                //allSprite2Ds.ElementAt(selectedindex).setSelected(true);
            }
            window.Refresh();

            selectedVector = selectedindextovector2d(selectedindex);

            window.lb_debug_X.Text = "X:" + selectedVector.X.ToString();
            window.lb_debug_Y.Text = "Y:" + selectedVector.Y.ToString();
        }

        private Vector2 selectedindextovector2d(int si ,int tilesize = 15)
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
                allTiles.ElementAt(selectedtile).map[(int)location.Y, (int)location.X] = window.tb_name.Text;
                newLoadNewTile(allTiles.ElementAt(selectedtile), selectedindex);

                Log.warning("Sprite at:   X:" + selectedVector.X + "  Y" + selectedVector.Y + "   swaped for:" + name);
                window.Refresh();
            }
            else
            {
                Log.error("Sprite name does not exist!!!");
            }
        }

        public void savecurrenttoLevel(string dir)
        {
            NSave.tileS(allTiles.ElementAt(selectedtile) ,Application.StartupPath + @"\Levels\" + dir);
        }
        public void savecurrent()
        {
            NSave.tileS(allTiles.ElementAt(selectedtile), Application.StartupPath + @"\Levels\" + loadedlevelname);
        }

        public void pbSelect(int i)
        {
            window.tb_name.Text = allimages[i].name;

            replacecoorinate(selectedVector, window.tb_name.Text);
        }
        #endregion
    }
}