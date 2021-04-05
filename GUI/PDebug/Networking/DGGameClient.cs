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
    public partial class DGGameClient : Form , IDebugUpdate
    {
        public DGGameClient()
        {
            InitializeComponent();
        }

        public void DebugUpdate()
        {
            
        }


        private void DGNetworking_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
