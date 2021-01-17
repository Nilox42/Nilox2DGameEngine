using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
//
using Nilox2DGameEngine.Util;
using Nilox2DGameEngine.Editor;

namespace Nilox2DGameEngine.MainMenu
{
    public partial class ControllerForm : Form
    {
        #region imported Dll´s
        //Import Dll´s to be able to Hide the Console
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        //Setup Consolevisibility
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        private IntPtr handle = GetConsoleWindow();
        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;
        #endregion
        //
        #region Init
        MainMenuForm MM = null;

        //Game
        GameMode GM = null;
        //Level Editor
        LevelEditor LE = null;
        //Options
        Options OP = null;

        public ControllerForm()
        {
            InitializeComponent();
        }

        private async void ControllerForm_Load(object sender, EventArgs e)
        {
            Log.control("Controller initialising");

            await Task.Delay(10);
            this.Hide();
            showConsole();

            showMainMenu();
        }
        public static void exit()
        {
            Log.control("Controller exit");
            Application.Exit();
        }
        #endregion
        //
        //
        #region showhideconsole
        public void showConsole()
        {
            ShowWindow(handle, SW_SHOW);
        }
        public void hideConsole()
        {
            ShowWindow(handle, SW_HIDE);
        }
        #endregion
        //
        //
        #region show/hide forms
        public void showMainMenu()
        {
            Log.control("Mainmenu showing");

            if (MM != null)
            {
                hideMainMenu();
            }

            MM = new MainMenuForm(this);
            MM.Show();
        }
        public void hideMainMenu()
        {
            if (MM != null)
            {
                MM.Hide();
                MM.Dispose();
                MM = null;

                Log.control("Mainmenu hidden");
            }
            else
            {
                Log.warning("[CORE]  -  Couldnt destroy MainMenu REF");
            }
        }

        public void showOptions()
        {
            Log.control("Options showing");

            if (OP != null)
            {
                hideMainMenu();
            }

            OP = new Options(this);
            OP.Show();
        }
        public void hideOptions()
        {
            if (OP != null)
            {
                OP.Hide();
                OP.Dispose();
                OP = null;

                Log.control("Options hidden");
            }
            else
            {
                Log.warning("[CORE]  -  Couldnt destroy MainMenu REF");
            }
        }

        #endregion
        //
        //
        #region initate subroutines

        public void initiateGame()
        {
            hideMainMenu();
            if (GM == null &&  LE == null)
            {
                Log.control("Gamemode initialising");
                GM = new GameMode(this);
            }
            else
            {
                Log.error("[CORE]  -  There is already an existing Gamemode");
                showMainMenu();
            }
        }
        public void closeGame()
        {
            GM = null;
            showMainMenu();
            Log.control("closed game");
        }

        public void initiateEditor()
        {
            hideMainMenu();
            if (LE == null && GM == null)
            {
                Log.control("Level Editor initialising");
                LE = new LevelEditor();
            }
            else
            {
                Log.error("[CORE]  -  There is already an existing LevelEditor");
                showMainMenu();
            }
        }
        #endregion
    }
}
