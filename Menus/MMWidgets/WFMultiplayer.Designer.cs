
namespace Nilox2DGameEngine.Menus
{
    partial class WFMultiplayer
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playercount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxplayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.join = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btcreatesession = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ip,
            this.playercount,
            this.maxplayer,
            this.join});
            this.dgv.Location = new System.Drawing.Point(825, 52);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(443, 656);
            this.dgv.TabIndex = 0;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // ip
            // 
            this.ip.HeaderText = "ip";
            this.ip.Name = "ip";
            // 
            // playercount
            // 
            this.playercount.HeaderText = "playercount";
            this.playercount.Name = "playercount";
            // 
            // maxplayer
            // 
            this.maxplayer.HeaderText = "maxplayer";
            this.maxplayer.Name = "maxplayer";
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(825, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(443, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // join
            // 
            this.join.HeaderText = "join";
            this.join.Name = "join";
            // 
            // btcreatesession
            // 
            this.btcreatesession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btcreatesession.ForeColor = System.Drawing.SystemColors.Control;
            this.btcreatesession.Location = new System.Drawing.Point(151, 236);
            this.btcreatesession.Name = "btcreatesession";
            this.btcreatesession.Size = new System.Drawing.Size(443, 34);
            this.btcreatesession.TabIndex = 2;
            this.btcreatesession.Text = "CreateSession";
            this.btcreatesession.UseVisualStyleBackColor = true;
            this.btcreatesession.Click += new System.EventHandler(this.btcreatesession_Click);
            // 
            // WFMultiplayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.btcreatesession);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WFMultiplayer";
            this.Text = "WFMultiplayer";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn playercount;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxplayer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewButtonColumn join;
        private System.Windows.Forms.Button btcreatesession;
    }
}