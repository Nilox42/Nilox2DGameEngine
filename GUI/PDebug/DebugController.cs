using NiloxUniversalLib.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nilox2DGameEngine.GUI.Debug
{
    public interface IDebugUpdate
    {
        void DebugUpdate();
    }

    public partial class DebugController : Form
    {
        DGNetworking networking;
        Timer tick = new Timer();
        List<IDebugUpdate> forms = new List<IDebugUpdate>();

        public DebugController()
        {
            InitializeComponent();

            tick.Interval = 400;
            tick.Tick += Tick_Tick;
            tick.Start();
        }

        private void Tick_Tick(object sender, EventArgs e)
        {
            foreach (IDebugUpdate du in forms)
            {
                try
                {
                    du.DebugUpdate();
                }
                catch
                {
                    Log.Debug("[DEBUG CONTROLLER] - Update faield");
                }
            }
        }

        public void showDebug()
        {
            if (networking == null)
            {
                networking = new DGNetworking();
                forms.Add(networking);
                networking.Show();
            }
            else
            {
                networking.Show();
            }
        }

        public void hideDebug()
        {
            if (networking != null)
            {
                networking.Hide();
            }
        }

        private async void DebugController_Load(object sender, EventArgs e)
        {
            await Task.Delay(100);
            this.Hide();
        }
    }
}
