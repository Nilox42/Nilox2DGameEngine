using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

using Nilox2DGameEngine.Editor;
using Nilox2DGameEngine.Util;
using Nilox2DGameEngine.MainMenu;

namespace Nilox2DGameEngine
{
    class Program
    {
        //Import Dll´s to be able to Hide the Console
        [DllImport("kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        static void Main(string[] args)
        {

            LevelEditor levelBuilder = null;
            TestGameMode test = null;

            MainMenuForm MMF = null;

            var handle = GetConsoleWindow();

           //const int SW_HIDE = 0;
            const int SW_SHOW = 5;

        a:
            ShowWindow(handle,SW_SHOW);

            if (test != null)
            {
                test = null;
            }

            if (levelBuilder != null)
            {
                levelBuilder = null;
            }

            switch (Console.ReadLine())
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
                    test = new TestGameMode();
                    break;
                case "1":
                    //ShowWindow(handle, SW_HIDE);
                    test = new TestGameMode();
                    break;
                //Editor
                case "editor":
                    //ShowWindow(handle, SW_HIDE);
                    levelBuilder = new LevelEditor();
                    break;
                case "2":
                    //ShowWindow(handle, SW_HIDE);
                    levelBuilder = new LevelEditor();
                    break;
                //Stop
                case "stop":
                    goto b;
                //Error
                default:
                    Log.Error("[COMMAND] Command not found!!");
                    //ShowWindow(handle, SW_SHOW);
                    break;
            }
    
            goto a;
            b:
            Console.WriteLine("END");

        }

    }
}