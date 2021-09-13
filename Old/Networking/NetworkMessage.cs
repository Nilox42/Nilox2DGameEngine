using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nilox2DGameEngine.Networking
{
    public class NetworkMessage
    {
        /// <summary>
        /// Send id to player who joined
        /// </summary>
        /// <param name="playerid"></param>
        /// <returns></returns>
        public static string S_Clientnew(int playerid)
        {
            return "client,new," + playerid.ToString();
        }

        /// <summary>
        /// Send id to all player exept the new one that the new one joined
        /// </summary>
        /// <param name="playerid"></param>
        /// <returns></returns>
        public static string S_Clientjoined(int playerid)
        {
            return "client,joined," + playerid.ToString();
        }

        /// <summary>
        /// When client send chatmessage to server ()
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string C_ChatMessage(string message)
        {
            return "chat,client," + message;
        }

        /// <summary>
        /// when server send chatmessage to clients (MULTICAST)
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public static string S_ChatMessahe(string message)
        {
            return "chat,server," + message;
        }

    }
}
