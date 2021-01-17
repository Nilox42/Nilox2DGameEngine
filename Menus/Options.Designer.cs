
namespace Nilox2DGameEngine.Menus
{
    partial class Options
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
            this.cbconsolevisibility = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cbconsolevisibility
            // 
            this.cbconsolevisibility.AutoSize = true;
            this.cbconsolevisibility.Location = new System.Drawing.Point(42, 115);
            this.cbconsolevisibility.Name = "cbconsolevisibility";
            this.cbconsolevisibility.Size = new System.Drawing.Size(100, 17);
            this.cbconsolevisibility.TabIndex = 1;
            this.cbconsolevisibility.Text = "Show Console?";
            this.cbconsolevisibility.UseVisualStyleBackColor = true;
            this.cbconsolevisibility.CheckedChanged += new System.EventHandler(this.cbconsolevisibility_CheckedChanged);
            // 
            // Options
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbconsolevisibility);
            this.Name = "Options";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Options";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Options_FormClosing);
            this.Load += new System.EventHandler(this.Options_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox cbconsolevisibility;
    }
}