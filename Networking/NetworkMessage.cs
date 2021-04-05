using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilox2DGameEngine.Networking
{
    public class NetworkMessage
    {
        public static string S_newClient(int playerid)
        {
            return "Client,new," + playerid.ToString();
        }

    }
}
