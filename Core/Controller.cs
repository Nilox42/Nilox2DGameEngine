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
using System.Threading;

namespace Nilox2DGameEngine.Core
{
    public class Controller
    {
        LevelEditor levelEditor = null;
        GameMode gm = null;

        //MainMenuForm MMF = null;


        public Controller()
        {
            executeCommand("1");
        }



        public void executeCommand(string cmd)
        {
            switch (cmd)
            {
                //Game
                case "main":
                    
                    break;
                case "0":
                   
                    break;
                //Game
                case "game":
                    
                    gm = new GameMode();
                    break;
                case "1":
                    
                    gm = new GameMode();
                    break;
                //Editor
                case "editor":
                    levelEditor = new LevelEditor();
                    break;
                case "2":
                    levelEditor = new LevelEditor();
                    break;
                //Stop
                case "stop":
                    Application.Exit();
                    break;
                //Error
                default:
                    Log.error("[COMMAND] Command not found!!");
                    break;
            }
        }

    }
}
