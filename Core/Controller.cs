using Nilox2DGameEngine.Editor;
using Nilox2DGameEngine.Util;
//
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

using Nilox2DGameEngine.Core;
using Nilox2DGameEngine.Networking;
using Nilox2DGameEngine.GUI.Debug;

namespace Nilox2DGameEngine.Menus
{
    public partial class Controller : Form
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
        public Controller() 
        {
            GlobalData.controller = this;
            GlobalData.networkmanager = new NetworkManager();
            GlobalData.debugcontroller = new DebugController();
            GlobalData.debugcontroller.showDebug();
            InitializeComponent();
        }

        private async void ControllerForm_Load(object sender, EventArgs e)
        {
            Log.control("Controller initialising");

            await Task.Delay(10);
            this.Hide();
            showMainMenu();

            showConsole();

        }
        public static void exit()
        {
            Log.control("Controller exit");
            GlobalData.controller.Close();
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

            hideOptions();
            hideMainMenu();
            
            GlobalData.mainmenu = new MainMenu(this);
            GlobalData.mainmenu.Show();
        }
        public void hideMainMenu()
        {
            if (GlobalData.mainmenu != null)
            {
                GlobalData.mainmenu.Hide();
                GlobalData.mainmenu.Dispose();
                GlobalData.mainmenu = null;

                Log.control("Mainmenu hidden");
            }
            else
            {
                //Log.warning("[CORE]  -  Couldnt destroy MainMenu REF");
            }
        }

        public void showOptions()
        {
            Log.control("Options showing");

            hideMainMenu();
            hideOptions();
            

            GlobalData.options = new Options();
            GlobalData.options.Show();
        }
        public void hideOptions()
        {
            if (GlobalData.options != null)
            {
                GlobalData.options.Hide();
                GlobalData.options.Dispose();
                GlobalData.options = null;

                Log.control("Options hidden");
            }
            else
            {
               // Log.warning("[CORE]  -  Couldnt destroy MainMenu REF");
            }
        }

        #endregion
        //
        //
        #region initate subroutines

        public void initiateGame()
        {
            hideMainMenu();
            if (GlobalData.gameMode == null && GlobalData.editor == null)
            {
                Log.control("Gamemode initialising");
                GlobalData.gameMode = new GameMode();
            }
            else
            {
                Log.error("[CORE]  -  There is already an existing Gamemode");
                showMainMenu();
            }
        }
        public void closeGame()
        {
            GlobalData.gameMode = null;
            showMainMenu();
            Log.control("closed game");
        }

        public void initiateEditor()
        {
            hideMainMenu();
            if (GlobalData.editor == null && GlobalData.gameMode == null)
            {
                Log.control("Level Editor initialising");
                GlobalData.editor = new LevelEditor();
            }
            else
            {
                Log.error("[CORE]  -  There is already an existing LevelEditor");
                showMainMenu();
            }
        }
        public void closeEditor()
        {
            GlobalData.editor = null;
            showMainMenu();
            Log.control("closed editor");
        }
        #endregion
    }
}
