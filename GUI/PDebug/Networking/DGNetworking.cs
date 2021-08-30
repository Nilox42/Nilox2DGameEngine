/*
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Nilox2DGameEngine.Core;
using Nilox2DGameEngine.Networking;

namespace Nilox2DGameEngine.GUI.Debug
{
    public partial class DGNetworking : Form , IDebugUpdate
    {
        DGGameServer dgserver;
        DGGameClient dgclient;

        public DGNetworking()
        {
            InitializeComponent();
        }
        private void DGNetworking_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        public void DebugUpdate()
        {
            updateserverclient();
            if (dgserver != null)
            {
                dgserver.DebugUpdate();
            }
            if (dgclient != null)
            {
                dgclient.DebugUpdate();
            }
        }

        #region Input
        private void button1_Click(object sender, EventArgs e)
        {
            GlobalData.networkmanager.destroySession();
        }

        private void updateserverclient()
        {
            if (GlobalData.networkmanager.server == null)
            {
                lbserveractive.Text = "off";
                hideserver();
            }
            else
            {
                lbserveractive.Text = "on";
                showserver();
            }

            if (GlobalData.networkmanager.client == null)
            {
                lbclientactive.Text = "off";
                hideclient();
            }
            else
            {
                lbclientactive.Text = "on";
                showclient();
            }

        }
        #endregion

        #region subs
        private void showserver()
        {
            if (dgserver == null)
            {
                dgserver = new DGGameServer();
                dgserver.Show();
            }
            else
            {
                dgserver.Show();
            }
        }
        private void hideserver()
        {
            if (dgserver != null)
            {
                dgserver.Hide();
                dgserver.Dispose();
            }
        }

        private void showclient()
        {
            if (dgclient == null)
            {
                dgclient = new DGGameClient();
                dgclient.Show();
            }
            else
            {
                dgclient.Show();
            }
        }
        private void hideclient()
        {
            if (dgclient != null)
            {
                dgclient.Hide();
                dgclient.Dispose();
            }
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine(NetworkManager.getpublicIP());
        }
    }
}
*/