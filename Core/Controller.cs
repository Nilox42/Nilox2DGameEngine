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
                    MMF = new MainMenuForm(this);
                    Thread TMMF= new Thread( OpenMaiMenu());
                    break;
                case "0":
                    MMF = new MainMenuForm(this);
                    MMF.Show();
                    break;
                //Game
                case "game":
                    MMF.Close();
                    MMF.Dispose();
                    GM = new TestGameMode();
                    break;
                case "1":
                    MMF.Close();
                    MMF.Dispose();
                    GM = new TestGameMode();
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
                    Log.Error("[COMMAND] Command not found!!");
                    break;
            }
        }


        void TMMF()
        {
            while (TMMF.IsAlive)
            {
            }
        }
    }
}
