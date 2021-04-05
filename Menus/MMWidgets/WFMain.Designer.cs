
namespace Nilox2DGameEngine.Menus
{
    partial class WFMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bt = new System.Windows.Forms.Button();
            this.btoptions = new System.Windows.Forms.Button();
            this.bteditor = new System.Windows.Forms.Button();
            this.bt_startgame = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bbtexit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bt
            // 
            this.bt.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt.ForeColor = System.Drawing.SystemColors.Control;
            this.bt.Location = new System.Drawing.Point(453, 393);
            this.bt.Name = "bt";
            this.bt.Size = new System.Drawing.Size(165, 51);
            this.bt.TabIndex = 10;
            this.bt.Text = "Multiplayer";
            this.bt.UseVisualStyleBackColor = true;
            this.bt.Click += new System.EventHandler(this.bt_Click);
            // 
            // btoptions
            // 
            this.btoptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btoptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btoptions.ForeColor = System.Drawing.SystemColors.Control;
            this.btoptions.Location = new System.Drawing.Point(453, 450);
            this.btoptions.Name = "btoptions";
            this.btoptions.Size = new System.Drawing.Size(165, 51);
            this.btoptions.TabIndex = 8;
            this.btoptions.Text = "Options";
            this.btoptions.UseVisualStyleBackColor = false;
            this.btoptions.Click += new System.EventHandler(this.btoptions_Click);
            // 
            // bteditor
            // 
            this.bteditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bteditor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bteditor.ForeColor = System.Drawing.SystemColors.Control;
            this.bteditor.Location = new System.Drawing.Point(624, 336);
            this.bteditor.Name = "bteditor";
            this.bteditor.Size = new System.Drawing.Size(165, 51);
            this.bteditor.TabIndex = 7;
            this.bteditor.Text = "Editor";
            this.bteditor.UseVisualStyleBackColor = true;
            this.bteditor.Click += new System.EventHandler(this.bteditor_Click);
            // 
            // bt_startgame
            // 
            this.bt_startgame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bt_startgame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bt_startgame.ForeColor = System.Drawing.SystemColors.Control;
            this.bt_startgame.Location = new System.Drawing.Point(453, 336);
            this.bt_startgame.Name = "bt_startgame";
            this.bt_startgame.Size = new System.Drawing.Size(165, 51);
            this.bt_startgame.TabIndex = 6;
            this.bt_startgame.Text = "SinglePlayer";
            this.bt_startgame.UseVisualStyleBackColor = true;
            this.bt_startgame.Click += new System.EventHandler(this.bt_startgame_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1240, 92);
            this.label1.TabIndex = 11;
            this.label1.Text = "THE DUNGEON";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bbtexit
            // 
            this.bbtexit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bbtexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bbtexit.ForeColor = System.Drawing.SystemColors.Control;
            this.bbtexit.Location = new System.Drawing.Point(624, 450);
            this.bbtexit.Name = "bbtexit";
            this.bbtexit.Size = new System.Drawing.Size(165, 51);
            this.bbtexit.TabIndex = 12;
            this.bbtexit.Text = "Exit";
            this.bbtexit.UseVisualStyleBackColor = false;
            this.bbtexit.Click += new System.EventHandler(this.btexit);
            // 
            // WFMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.bbtexit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bt);
            this.Controls.Add(this.btoptions);
            this.Controls.Add(this.bteditor);
            this.Controls.Add(this.bt_startgame);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WFMain";
            this.Text = "WFMain";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bt;
        private System.Windows.Forms.Button btoptions;
        private System.Windows.Forms.Button bteditor;
        private System.Windows.Forms.Button bt_startgame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bbtexit;
    }
}