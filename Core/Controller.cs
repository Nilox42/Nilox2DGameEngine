using Nilox2DGameEngine.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using Nilox2DGameEngine.Util;
using Nilox2DGameEngine.MainMenu;

namespace Nilox2DGameEngine.Core
{
    class Controller
    {
        LevelEditor levelEditor = null;
        TestGameMode GM = null;

        MainMenuForm MMF = null;


        public Controller()
        {
            executeCommand("0");
        }



        public void executeCommand(string cmd)
        {
            switch (cmd)
            {
                //Game
                case "main":
                    //ShowWindow(handle, SW_HIDE);
                    MMF = new MainMenuForm();
                    Application.Run(MMF);
                    break;
                case "0":
                    //ShowWindow(handle, SW_HIDE);
                    MMF = new MainMenuForm();
                    Application.Run(MMF);
                    break;
                //Game
                case "game":
                    //ShowWindow(handle, SW_HIDE);
                    GM = new TestGameMode();
                    break;
                case "1":
                    //ShowWindow(handle, SW_HIDE);
                    GM = new TestGameMode();
                    break;
                //Editor
                case "editor":
                    //ShowWindow(handle, SW_HIDE);
                    levelEditor = new LevelEditor();
                    break;
                case "2":
                    //ShowWindow(handle, SW_HIDE);
                    levelEditor = new LevelEditor();
                    break;
                //Stop
                case "stop":
                    Application.Exit();
                    break;
                //Error
                default:
                    Log.Error("[COMMAND] Command not found!!");
                    //ShowWindow(handle, SW_SHOW);
                    break;
            }
        }
    }
}
