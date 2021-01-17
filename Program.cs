using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
//
using Nilox2DGameEngine.Editor;
using Nilox2DGameEngine.Util;
using Nilox2DGameEngine.MainMenu;
using Nilox2DGameEngine.Core;

namespace Nilox2DGameEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            // create corenadann
            Controller controllerForm = new Controller();
            Application.Run(controllerForm);
        }
    }
}