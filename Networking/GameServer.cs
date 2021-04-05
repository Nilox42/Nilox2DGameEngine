using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

using Nilox2DGameEngine.Core;

using NiloxUniversalLib.Networking.Server;
using NiloxUniversalLib.Logging;

namespace Nilox2DGameEngine.Networking
{
    public class GameServer:Server
    {
        public GameServer() : base()
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
                SendResponse(response, client);
            }
        }


        protected override void OnClientConnects(Socket socket)
        {
            SendResponse(NetworkMessage.S_newClient(getPlayerIDofSocket(socket)), socket);
        }


        public int getPlayerIDofSocket(Socket socket)
        {
            return clientsockets.IndexOf(socket) + 1;
        }

        public void travel(string target)
        {
            switch (target)
            {
                default:
                    break;

                case "game":
                    {
                        GlobalData.controller.initiateGame();
                        break;
                    }
                case "mainmenu":
                    {
                        GlobalData.controller.showMainMenu();
                        break;
                    }
            }
        }

    }
}
