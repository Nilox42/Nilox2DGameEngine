using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using Nilox2DGameEngine.Core;
using System.Diagnostics;

namespace Nilox2DGameEngine.Util
{
    public class Log
    {
        public static void normal(string msg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[MSG] - {msg}");
            line($"[MSG] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void info(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[INFO] - {msg}");
            line($"[INFO] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void warning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARNING] - {msg}");
            line($"[WARNING] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] - {msg}");
            Log.line($"[ERROR] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //
        //
        //
        public static void save(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[SAVE] - {msg}");
            line($"[SAVE] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void load(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[LOAD] - {msg}");
            line($"[LOAD] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //
        //
        //
        //
        //
        //
        //
        #region logfile
        public static void line(string line)
        {
            GameMode.logs.Add(line);
        }
        #endregion
    }
}
