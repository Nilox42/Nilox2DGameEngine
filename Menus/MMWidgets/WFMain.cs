using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Nilox2DGameEngine.Core;

namespace Nilox2DGameEngine.Menus
{
    public partial class WFMain : Form
    {
        public WFMain()
        {
            InitializeComponent();
        }

        #region Input
        private void bt_startgame_Click(object sender, EventArgs e)
        {
            GlobalData.controller.initiateGame();
        }
        private void bteditor_Click(object sender, EventArgs e)
        {
            GlobalData.controller.initiateEditor();
        }
        private void btoptions_Click(object sender, EventArgs e)
        {
            GlobalData.controller.showOptions();
        }
        private void btexit(object sender, EventArgs e)
        {
            Controller.exit();
        }
        private void bt_Click(object sender, EventArgs e)
        {
            GlobalData.mainmenu.switchtomultiplayer();
        }
        #endregion


    }
}
