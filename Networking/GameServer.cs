using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using NiloxUniversalLib.Networking.Server;
using NiloxUniversalLib.Logging;

namespace Nilox2DGameEngine.Networking
{
    public class GameServer:Server
    {
        public GameServer()
        {
            OnReceiveRequest += handleClientRequest;
        }

        private void handleClientRequest(object sender, ReceivedClientRequestEventArgs e)
        {
            string message = e.message;
            string response = "response";
            Socket client = e.socket;

            if (message == "test")
            {
                byte[] buffer = Encoding.ASCII.GetBytes(message);
                Log.Networking("[SENDING] - " + response);
                client.Send(buffer, 0, buffer.Length, SocketFlags.None);
            }

        }



    }
}
