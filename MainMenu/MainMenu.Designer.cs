namespace Nilox2DGameEngine.MainMenu
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.bt_startgame = new System.Windows.Forms.Button();
            this.bteditor = new System.Windows.Forms.Button();
            this.btoptions = new System.Windows.Forms.Button();
            this.btexit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(158, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(483, 76);
            this.label1.TabIndex = 0;
            this.label1.Text = "EinGeielrName";
            // 
            // bt_startgame
            // 
            this.bt_startgame.Location = new System.Drawing.Point(232, 196);
            this.bt_startgame.Name = "bt_startgame";
            this.bt_startgame.Size = new System.Drawing.Size(165, 51);
            this.bt_startgame.TabIndex = 1;
            this.bt_startgame.Text = "Start Game";
            this.bt_startgame.UseVisualStyleBackColor = true;
            this.bt_startgame.Click += new System.EventHandler(this.bt_startgame_Click);
            // 
            // bteditor
            // 
            this.bteditor.Location = new System.Drawing.Point(403, 196);
            this.bteditor.Name = "bteditor";
            this.bteditor.Size = new System.Drawing.Size(165, 51);
            this.bteditor.TabIndex = 2;
            this.bteditor.Text = "Editor";
            this.bteditor.UseVisualStyleBackColor = true;
            this.bteditor.Click += new System.EventHandler(this.bteditor_Click);
            // 
            // btoptions
            // 
            this.btoptions.Location = new System.Drawing.Point(232, 253);
            this.btoptions.Name = "btoptions";
            this.btoptions.Size = new System.Drawing.Size(165, 51);
            this.btoptions.TabIndex = 3;
            this.btoptions.Text = "Options";
            this.btoptions.UseVisualStyleBackColor = true;
            this.btoptions.Click += new System.EventHandler(this.btoptions_Click);
            // 
            // btexit
            // 
            this.btexit.BackColor = System.Drawing.Color.Transparent;
            this.btexit.Cursor = System.Windows.Forms.Cursors.No;
            this.btexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btexit.Location = new System.Drawing.Point(12, 387);
            this.btexit.Name = "btexit";
            this.btexit.Size = new System.Drawing.Size(165, 51);
            this.btexit.TabIndex = 4;
            this.btexit.Text = "Exit";
            this.btexit.UseVisualStyleBackColor = false;
            this.btexit.Click += new System.EventHandler(this.btexit_Click);
            // 
            // MainMenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btexit);
            this.Controls.Add(this.btoptions);
            this.Controls.Add(this.bteditor);
            this.Controls.Add(this.bt_startgame);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MainMenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenuForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainMenuForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bt_startgame;
        private System.Windows.Forms.Button bteditor;
        private System.Windows.Forms.Button btoptions;
        private System.Windows.Forms.Button btexit;
    }
}