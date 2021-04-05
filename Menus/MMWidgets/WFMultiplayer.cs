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

            dgv.Rows.Clear();
            foreach (ESession s in sessions)
            {
                dgv.Rows.Add(s.ip, s.playercount, s.maxplayer);
            }
        }
        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)
            {
                //get name
                string ip = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
                string current = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                string max = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();

                GlobalData.networkmanager.JoinSession(ESession.Create(ip, Convert.ToInt32(current), Convert.ToInt32(max))); ;
            }
        }

        private void btcreatesession_Click(object sender, EventArgs e)
        {
            int maxp = 0;
            string servername = "";

            try
            {
                maxp = (int)nudmaxplayer.Value;
                servername = tbservername.Text;

                GlobalData.networkmanager.CreateSession(servername, maxp);
            }
            catch
            {
                Log.Networking("[WFMULTIPLAYER] - Failed to convert Session options using standart settings to create Session");
                GlobalData.networkmanager.CreateSession();
            }

        }

        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            GlobalData.networkmanager.destroySession();
        }
    }
}
