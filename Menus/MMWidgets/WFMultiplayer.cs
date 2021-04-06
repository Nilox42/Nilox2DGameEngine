using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Nilox2DGameEngine.Networking;
using Nilox2DGameEngine.Core;

using NiloxUniversalLib.Logging;

namespace Nilox2DGameEngine.Menus
{
    public partial class WFMultiplayer : Form
    {
        List<ESession> sessions;

        public WFMultiplayer()
        {
            InitializeComponent();
        }

        #region Input   
        private void button1_Click(object sender, EventArgs e)
        {
            sessions = GlobalData.networkmanager.FindSesions();

            if (sessions == null)
            {
                dgv.Rows.Clear();
                return;
            }

            dgv.Rows.Clear();
            foreach (ESession s in sessions)
            {
                dgv.Rows.Add(s.ip, s.servername, s.playercount, s.maxplayer);
            }
        }
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && e.RowIndex != dgv.Rows.Count -1)
            {
                //get name
                string ip = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                string servername = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                string current = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
                string max = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();

                bool succes = GlobalData.networkmanager.JoinSession(ESession.Create(ip, servername, Convert.ToInt32(current), Convert.ToInt32(max)));
                if (succes)
                {
                    GlobalData.mainmenu.switchtomultolobby();
                }
            }
        }

        private void btcreatesession_Click(object sender, EventArgs e)
        {
            int maxp = (int)nudmaxplayer.Value;
            string servername = tbservername.Text;
            bool socces = false;

            //Servername Checks
            {
                if (servername == "")
                {
                    lberror.Text = "Servername cannot be empty";
                    return;
                }
                if (servername.Length > 20)
                {
                    lberror.Text = "Servername cannot be longer than 20 characters";
                    return;
                }
                if (servername.Length < 5)
                {
                    lberror.Text = "Servername must atleast 5 characters";
                    return;
                }
            }
            //maxplayer Checks
            {
                if (maxp.GetType() != 42.GetType())
                {
                    lberror.Text = "Maxplayer must be an integer";
                    return;
                }
                if (maxp > 5)
                {
                    lberror.Text = "Maxplayer cannot be over 5";
                    return;
                }
                if (maxp < 2)
                {
                    lberror.Text = "Maxplayer must at least be 2";
                    return;
                }
            }

            lberror.Text = "";
            try
            {
                maxp = (int)nudmaxplayer.Value;
                servername = tbservername.Text;

                socces = GlobalData.networkmanager.CreateSession(servername, maxp);                
            }
            catch
            {
                Log.Networking("[WFMULTIPLAYER] - Failed to convert Session options using standart settings to create Session");
                socces = GlobalData.networkmanager.CreateSession(servername);
            }

            if (socces)
            {
                GlobalData.mainmenu.switchtomultolobby();
            }
        }


        #endregion

    }
}
