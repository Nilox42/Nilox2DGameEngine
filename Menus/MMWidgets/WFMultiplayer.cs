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
            Update();
        }
        #endregion

        public void Update()
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
    }
}
