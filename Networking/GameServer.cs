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
            string[] command = e.message.Split(',');
            string response = "";
            Socket client = e.socket;

            switch (command[0])
            {
                default:
                    break;

                case "chat":
                    {
                        if (command[1] == "client")
                        {
                            SendToAll(NetworkMessage.S_ChatMessahe(command[2]));
                        }
                        break;
                    }
            }
        }


        protected override void OnClientConnects(Socket socket)
        {
            SendResponse(NetworkMessage.S_Clientnew(getPlayerIDofSocket(socket)), socket);
        }


        public int getPlayerIDofSocket(Socket socket)
        {
            return clientsockets.IndexOf(socket) + 1;
        }

        public int getPlayerCount()
        {
            return clientsockets.Count;
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
