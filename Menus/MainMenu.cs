﻿using System;
using System.Windows.Forms;

namespace Nilox2DGameEngine.Menus
{
    public partial class MainMenu : Form
    {
        #region Init
        Controller cr = null;

        public MainMenu(Controller cr0)
        {
            InitializeComponent();

            cr = cr0;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }
        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Controller.exit();
        }
        private void btexit_Click(object sender, EventArgs e)
        {
            Controller.exit();
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
            cr.showOptions();
        }



        #endregion

        
    }
}