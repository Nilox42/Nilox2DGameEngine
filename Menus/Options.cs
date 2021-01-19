using System;
using System.Windows.Forms;

namespace Nilox2DGameEngine.Menus
{
    public partial class Options : Form
    {
        #region Init
        Controller cr = null;

        public Options(Controller cr0)
        {
            cr = cr0;

            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {

        }
        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            cr.showMainMenu();
        }


        #endregion

       

        private void cbconsolevisibility_CheckedChanged(object sender, EventArgs e)
        {
            if (cbconsolevisibility.Checked)
            {
                cr.showConsole();
            }
            else
            {
                cr.hideConsole();
            }
        }
    }
}
