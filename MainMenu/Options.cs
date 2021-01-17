using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nilox2DGameEngine.MainMenu
{
    public partial class Options : Form
    {
        #region Init
        ControllerForm cr = null;

        public Options(ControllerForm cr0)
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
            this.Close();
            this.Dispose();
            cr.showMainMenu();
        }
        #endregion

        
    }
}
