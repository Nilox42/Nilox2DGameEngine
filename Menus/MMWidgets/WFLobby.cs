using Nilox2DGameEngine.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nilox2DGameEngine.Menus.MMWidgets
{
    public partial class WFLobby : Form
    {
        public static string chat = "";
        Timer tick = new Timer();

        public WFLobby()
        {
            InitializeComponent();
            GlobalData.networkmanager.OnRecieveChatMessage += Networkmanager_OnRecieveChatMessage;

            tick.Interval = 400;
            tick.Tick += Tick_Tick;
            tick.Start();
        }

        private void Tick_Tick(object sender, EventArgs e)
        {
            if (chat != rtbchat.Text)
            {
                rtbchat.Text = chat;
            }
        }

        private void Networkmanager_OnRecieveChatMessage(object sender, NiloxUniversalLib.Networking.Client.ReceivedServerResponseEventArgs e)
        {
            chat += e.message + "\n";
        }

        private void btsend_Click(object sender, EventArgs e)
        {
            string message = tbmessage.Text;

            //Check Message
            {
                if (message == "")
                {
                    return;
                }
                if (message.Length > 50)
                {
                    return;
                }
            }

            GlobalData.networkmanager.ChatSend("PLAYER INDEX:    " + message);
        }

    }
}
