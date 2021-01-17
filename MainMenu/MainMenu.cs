﻿using Nilox2DGameEngine.Editor;
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

namespace Nilox2DGameEngine.MainMenu
{
    public partial class MainMenu : Form
    {
        #region Init
        ControllerForm cr = null;

        public MainMenu(ControllerForm cr0)
        {
            InitializeComponent();

            cr = cr0;
        }
        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ControllerForm.exit();
        }
        private void btexit_Click(object sender, EventArgs e)
        {
            ControllerForm.exit();
        }
        #endregion


        #region Input
        private void bt_startgame_Click(object sender, EventArgs e)
        {
            cr.initiateGame();
        }

        private void bteditor_Click(object sender, EventArgs e)
        {
            cr.initiateEditor();
        }
        private void btoptions_Click(object sender, EventArgs e)
        {

        }

        #endregion

        
    }
}