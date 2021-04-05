using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Nilox2DGameEngine.Core;
using Nilox2DGameEngine.Menus;
using Nilox2DGameEngine.Editor;
using Nilox2DGameEngine.Networking;

namespace Nilox2DGameEngine.Core
{
    public static class GlobalData
    {
        //Core Controller
        public static Controller controller;

        //Main Modes
        public static GameMode gameMode;
        public static LevelEditor editor;

        //Menus
        public static MainMenu mainmenu;
        public static Options options;

        //Networking
        public static NetworkManager networkmanager;
    }
}
