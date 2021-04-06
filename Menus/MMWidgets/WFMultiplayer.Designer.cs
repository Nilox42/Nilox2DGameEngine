
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
            this.button1 = new System.Windows.Forms.Button();
            this.btcreatesession = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.nudmaxplayer = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbservername = new System.Windows.Forms.TextBox();
            this.ip = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.servername = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.playercount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxplayer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.join = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudmaxplayer)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ip,
            this.servername,
            this.playercount,
            this.maxplayer,
            this.join});
            this.dgv.Location = new System.Drawing.Point(723, 52);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(545, 656);
            this.dgv.TabIndex = 0;
            this.dgv.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_CellContentClick);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Location = new System.Drawing.Point(723, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(545, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btcreatesession
            // 
            this.btcreatesession.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btcreatesession.ForeColor = System.Drawing.SystemColors.Control;
            this.btcreatesession.Location = new System.Drawing.Point(12, 646);
            this.btcreatesession.Name = "btcreatesession";
            this.btcreatesession.Size = new System.Drawing.Size(287, 62);
            this.btcreatesession.TabIndex = 2;
            this.btcreatesession.Text = "HostGame";
            this.btcreatesession.UseVisualStyleBackColor = true;
            this.btcreatesession.Click += new System.EventHandler(this.btcreatesession_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(514, 62);
            this.label1.TabIndex = 3;
            this.label1.Text = "Multiplayer";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // nudmaxplayer
            // 
            this.nudmaxplayer.Location = new System.Drawing.Point(179, 195);
            this.nudmaxplayer.Name = "nudmaxplayer";
            this.nudmaxplayer.Size = new System.Drawing.Size(120, 20);
            this.nudmaxplayer.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(17, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Max Playercount:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(17, 168);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Servername:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbservername
            // 
            this.tbservername.Location = new System.Drawing.Point(179, 169);
            this.tbservername.Name = "tbservername";
            this.tbservername.Size = new System.Drawing.Size(120, 20);
            this.tbservername.TabIndex = 7;
            // 
            // ip
            // 
            this.ip.HeaderText = "ip";
            this.ip.Name = "ip";
            // 
            // servername
            // 
            this.servername.HeaderText = "servername";
            this.servername.Name = "servername";
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
            // join
            // 
            this.join.HeaderText = "join";
            this.join.Name = "join";
            this.join.Text = "join";
            // 
            // WFMultiplayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.tbservername);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nudmaxplayer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btcreatesession);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WFMultiplayer";
            this.Text = "WFMultiplayer";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudmaxplayer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btcreatesession;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nudmaxplayer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbservername;
        private System.Windows.Forms.DataGridViewTextBoxColumn ip;
        private System.Windows.Forms.DataGridViewTextBoxColumn servername;
        private System.Windows.Forms.DataGridViewTextBoxColumn playercount;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxplayer;
        private System.Windows.Forms.DataGridViewButtonColumn join;
    }
}