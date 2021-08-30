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

namespace Nilox2DGameEngine.GUI.Debug
{
    public partial class DGGameServer : Form , IDebugUpdate
    {
        public DGGameServer()
        {
            InitializeComponent();
        }

        public void DebugUpdate()
        {
            try
            {
                
            }
            catch
            {

            }
        }


        private void DGNetworking_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
