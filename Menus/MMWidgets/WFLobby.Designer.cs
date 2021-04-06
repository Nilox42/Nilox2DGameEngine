
namespace Nilox2DGameEngine.Menus.MMWidgets
{
    partial class WFLobby
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
            this.rtbchat = new System.Windows.Forms.RichTextBox();
            this.tbmessage = new System.Windows.Forms.TextBox();
            this.btsend = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rtbchat
            // 
            this.rtbchat.BackColor = System.Drawing.Color.DarkGray;
            this.rtbchat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbchat.Location = new System.Drawing.Point(1018, 12);
            this.rtbchat.Name = "rtbchat";
            this.rtbchat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbchat.Size = new System.Drawing.Size(250, 641);
            this.rtbchat.TabIndex = 0;
            this.rtbchat.Text = "";
            // 
            // tbmessage
            // 
            this.tbmessage.Location = new System.Drawing.Point(1018, 659);
            this.tbmessage.Name = "tbmessage";
            this.tbmessage.Size = new System.Drawing.Size(250, 20);
            this.tbmessage.TabIndex = 1;
            // 
            // btsend
            // 
            this.btsend.Location = new System.Drawing.Point(1018, 685);
            this.btsend.Name = "btsend";
            this.btsend.Size = new System.Drawing.Size(250, 23);
            this.btsend.TabIndex = 2;
            this.btsend.Text = "Send";
            this.btsend.UseVisualStyleBackColor = true;
            this.btsend.Click += new System.EventHandler(this.btsend_Click);
            // 
            // WFLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(23)))), ((int)(((byte)(23)))));
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.btsend);
            this.Controls.Add(this.tbmessage);
            this.Controls.Add(this.rtbchat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WFLobby";
            this.Text = "WFLobby";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbchat;
        private System.Windows.Forms.TextBox tbmessage;
        private System.Windows.Forms.Button btsend;
    }
}