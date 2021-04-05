using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NiloxUniversalLib.Logging;
using NiloxUniversalLib.Networking.Client;

namespace Nilox2DGameEngine.Networking
{
    public class GameClient : Client
    {
        int playerindex = -1;

        public GameClient(string ip, int port) : base(ip, port)
        {
            OnReceivedResponse += handleServerResponse;
        }

        #region Recieve
        private void handleServerResponse(object sender, ReceivedServerResponseEventArgs e)
        {
            string message = e.message;
            string[] command = message.Split(',');

            switch (command[0])
            {
                default:
                    break;

                case "client":
                    {
                        C_Client(command);
                        break;
                    }
            }

        }
        #endregion

        #region Handle Command
        public void C_Client(string[] command)
        {
            switch (command[1])
            {
                default:
                    break;
                case "new":
                    {
                        playerindex = Convert.ToInt32(command[2]);
                        break;
                    }
                case "joined":
                    {
                        Log.Networking($"[GAME CLIENT] - player {command[2]} joined");
                        break;
                    }
            }
        }
        #endregion

        public void SendRequest(string s)
        {
            Send(s);
        }
    }
}
