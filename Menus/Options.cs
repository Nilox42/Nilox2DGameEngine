using System;
using System.Windows.Forms;

using Nilox2DGameEngine.Core;

namespace Nilox2DGameEngine.Menus
{
    public partial class Options : Form
    {
        #region Init

        public Options()
        {
            InitializeComponent();
        }

        private void Options_Load(object sender, EventArgs e)
        {

        }
        private void Options_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            GlobalData.controller.showMainMenu();
        }
        #endregion

        private void cbconsolevisibility_CheckedChanged(object sender, EventArgs e)
        {
            if (cbconsolevisibility.Checked)
            {
                GlobalData.controller.showConsole();
            }
            else
            {
                GlobalData.controller.hideConsole();
            }
        }

    }
}
