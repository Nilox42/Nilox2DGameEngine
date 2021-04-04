using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilox2DGameEngine.Networking
{
    
    public struct ESession
    {
        public string ip;
        public int playercount;
        public int maxplayer;

        public static ESession Create(string ip, int maxplayer)
        {
            ESession e = new ESession();

            e.ip = ip;
            e.playercount = 1;
            e.maxplayer = maxplayer;

            return e;
        }
        public static ESession Create(string ip, int playercount, int maxplayer)
        {
            ESession e = new ESession();

            e.ip = ip;
            e.playercount = playercount;
            e.maxplayer = maxplayer;

            return e;
        }

    }

}
