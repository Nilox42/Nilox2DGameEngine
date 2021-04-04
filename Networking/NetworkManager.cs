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

    public class NetworkManager
    {
        private ESession currentsession;
        public nmstate state = nmstate.offline;

        public GameServer server;
        public  GameClient client;

        public NetworkManager()
        {
        }


        #region Controlls
        public bool CreateSession(int maxpalyer = 2)
        {
            ESession session = ESession.Create(getpublicIP(), maxpalyer);
            bool entlist = entlistSession(session);
            if (server != null)
            {
                Log.Networking("Server already exists");
            }
            else
            {
                server = new GameServer();
                server.Init();

                currentsession = session;
                state = nmstate.server;
            }

            return entlist;
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
                server.destroy();
                server = null;
            }
            if (client != null)
            {
                client.destroy();
                client = null;
            }

            state = nmstate.offline;
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
                    res += reader.GetString(2) + ";";
                }

                res.Remove(res.Length - 1, 1);

                string[] list = res.Split(';');
                foreach (string s in list)
                {
                    if (s == "") break;


                    string[] sess = s.Split(',');

                    sessions.Add(ESession.Create(sess[0], Convert.ToInt32(sess[1]), Convert.ToInt32(sess[2])));
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
                string query = $"INSERT INTO `test`(`ip`, `currentplayer`, `maxplayer`) VALUES('{session.ip}','srtring','{session.maxplayer}')";
                MySqlCommand cmd = new MySqlCommand(query, d.Connection);
                var res = cmd.ExecuteNonQuery();

                Log.Networking("RESULT" + res.ToString());

                if (res == 1)
                {
                    return true;
                }
                else
                {
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

    }
}
