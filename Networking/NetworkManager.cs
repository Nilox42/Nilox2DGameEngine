using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Sockets;

using NiloxUniversalLib.SQL;
using NiloxUniversalLib.Logging;
using NiloxUniversalLib.Networking.Server;
using NiloxUniversalLib.Networking.Client;

namespace Nilox2DGameEngine.Networking
{
    public enum nmstate
    {
        offline,client,server
    }
    public enum nmfgamestate
    {
        menu, lobby, ingame
    }

    public class NetworkManager
    {
        private ESession currentsession;
        public nmstate state = nmstate.offline;
        public nmfgamestate gamestate = nmfgamestate.menu;

        public event ReceivedServerResponseEventHandler OnRecieveChatMessage; // uses this handler because its good for messages no more no less

        public GameServer server;
        public  GameClient client;

        public NetworkManager()
        {
        }


        #region Controlls
        public bool CreateSession(string servername, int maxpalyer = 2)
        {
            if (client != null)
            {
                Log.Networking("This is already a client");
                return false;
            }
            if (server != null)
            {
                Log.Networking("Server already exists");
                return false;
            }
            else
            {
                ESession session = ESession.Create(getpublicIP(), servername, maxpalyer);
                bool entlist = entlistSession(session);

                if (entlist == false)
                {
                    return false;
                }

                server = new GameServer();
                server.Init();

                currentsession = session;
                state = nmstate.server;
                Log.Networking("[NETWORK MANAGER] - State --> server");
            }

            return true;
        }
        public List<ESession> FindSesions()
        {
            return getAvailableSession();
        }
        public bool JoinSession(ESession e)
        {
            if (client != null)
            {
                Log.Networking("Client already exists");
                return false;
            }
            if (server != null)
            {
                Log.Networking("There is already a server");
                return false;
            }

            client = new GameClient(e.ip, 100);
            client.Init();

            currentsession = e;
            state = nmstate.client;

            return true;
        }
        public void destroySession()
        {
            if (server != null)
            {
                removeIpfromList();
                server.destroy();
                server = null;
            }
            if (client != null)
            {
                client.destroy();
                client = null;
            }

            state = nmstate.offline;

            Log.Networking("[NETWORK MANAGER] - State --> offline");
        }
        #endregion

        #region SQL
        private List<ESession> getAvailableSession()
        {
            List<ESession> sessions = new List<ESession>();

            string url = "nilox.network";
            DBConnection d = new DBConnection(url, "server");

            if (d.IsConnect())
            {
                string res = "";

                string query = $"SELECT * FROM `test`";
                var cmd = new MySqlCommand(query, d.Connection);
                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    res += reader.GetString(0) + ",";
                    res += reader.GetString(1) + ",";
                    res += reader.GetString(2) + ",";
                    res += reader.GetString(3);
                }

                if (res == "")
                {
                    Log.Networking("[NETWORK MANAGER] - No sessions found");
                    return null;
                }

                res.Remove(res.Length - 1, 1);

                string[] list = res.Split(';');
                foreach (string s in list)
                {
                    if (s == "") break;


                    string[] sess = s.Split(',');

                    sessions.Add(ESession.Create(sess[0], sess[1], Convert.ToInt32(sess[2]), Convert.ToInt32(sess[3])));
                }

                d.Close();
            }

            return sessions;
        }
        private bool entlistSession(ESession session)
        {
            string url = "nilox.network";
            DBConnection d = new DBConnection(url, "server");

            if (d.IsConnect())
            {
                string query = $"INSERT INTO `test`(`ip`, `servername`, `currentplayer`, `maxplayer`) VALUES('{session.ip}','{session.servername}','{session.playercount}','{session.maxplayer}')";
                MySqlCommand cmd = new MySqlCommand(query, d.Connection);
                var res = cmd.ExecuteNonQuery();

                if (res == 1)
                {
                    Log.Networking("[NETWORK MANAGER] - Added Server to List");
                    return true;
                }
                else
                {
                    Log.Networking("[NETWORK MANAGER] - Couldnt add Server to List");
                    return false;
                }
            }

            return false;
        }
        private bool removeIpfromList()
        {
            string url = "nilox.network";
            DBConnection d = new DBConnection(url, "server");

            if (d.IsConnect())
            {
                string query = $"DELETE FROM `test` WHERE `ip` = '{getpublicIP()}'";
                MySqlCommand cmd = new MySqlCommand(query, d.Connection);
                var res = cmd.ExecuteNonQuery();

                if (res == 1)
                {
                    Log.Networking("[NETWORK MANAGER] - Removed from SQL List");
                    return true;
                }
                else
                {
                    Log.Networking("[NETWORK MANAGER] - Couldnt remove IP from List");
                    return false;
                }
            }

            return false;
        }
        #endregion

        #region IP
        public static string getpublicIP()
        {
            WebClient wr = new WebClient();
            Uri uri = new Uri("http://nilox.network/open/PHP/generall/getip.php");

            return wr.DownloadString(uri);
        }
        #endregion

        #region Chat
        public void ChatSend(string message)
        {
            if (state == nmstate.client)
            {
                client.SendRequest(NetworkMessage.C_ChatMessage(message)); 
            }
            else
            {
                server.SendToAll(message);
                ChatReceived(message);
            }
        }
        public void ChatReceived(string message)
        {

            ReceivedServerResponseEventHandler handler = OnRecieveChatMessage;
            if (handler != null)
            {
                handler(this, new ReceivedServerResponseEventArgs(message));
            }

        }
        #endregion

    }
}
