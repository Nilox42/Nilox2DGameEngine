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
using Nilox2DGameEngine.Core;

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
            #region Console Visibility
            var handle = GetConsoleWindow();

            const int SW_HIDE = 0;
            const int SW_SHOW = 5;

            ShowWindow(handle,SW_SHOW);
            #endregion

            Controller ctr = new Controller();

            while (ctr != null)
            {
                string s = Console.ReadLine();
                if(s != "" && s.Length < 7)
                {
                    if (s == "stop" || s == "end" || s == "exit")
                    {
                        ctr = null;
                        Application.Exit();
                    }
                    else
                    {
                        ctr.executeCommand(s);
                    }
                }
                else
                {
                    Log.Error("[CONSOLE]  -  Line Empty or to long to be a command");
                    Console.Beep();
                }
            }

            Console.WriteLine("END");
        }

    }
}