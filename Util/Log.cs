using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Nilox2DGameEngine.Util
{
    public class Log
    {
        string path = String.Empty;
        StreamWriter sw;

        public static void Normal(string msg)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[MSG] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Info(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[INFO] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Warning(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[WARNING] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        //
        //
        //
        public static void Save(string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"[SAVE] - {msg}");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Load(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[LOAD] - {msg}");
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
        public void startlogging()
        {
            string name = "log";
            

            if (File.Exists(Application.StartupPath + @"\log" + @"\" + name + ".txt"))
            {
                Random r = new Random();

                name = name + r.Next(0,10000);
            }

            path = Application.StartupPath + @"\log" + @"\" + name + ".txt";
            sw = new StreamWriter(path);
        }

        public void stoplogging()
        {
            sw.Dispose();
        }

        public void line(string line)
        {
            sw.WriteLine(line);
        }
        #endregion
    }
}
