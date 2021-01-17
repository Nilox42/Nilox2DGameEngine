using Nilox2DGameEngine.Editor;
using Nilox2DGameEngine.Util;
//
using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        MainMenu MM = null;
        Options OP = null;

        GameMode GM = null;
        LevelEditor LE = null;

        public Controller()
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

            hideOptions();
            hideMainMenu();
            
            MM = new MainMenu(this);
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
                //Log.warning("[CORE]  -  Couldnt destroy MainMenu REF");
            }
        }

        public void showOptions()
        {
            Log.control("Options showing");

            hideMainMenu();
            hideOptions();
            

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
                LE = new LevelEditor(this);
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
