using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NiloxUniversalLib.Networking.Client;

namespace Nilox2DGameEngine.Networking
{
    public class GameClient : Client
    {


        public GameClient(string ip, int port) : base(ip, port)
        {
            OnReceivedResponse += handleServerResponse;
        }

        private void handleServerResponse(object sender, ReceivedServerResponseEventArgs e)
        {
            string message = e.message;
            
        }

        public void SendRequest(string s)
        {
            Send(s);
        }
    }
}
