﻿using Nilox2DGameEngine.Editor;
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

namespace Nilox2DGameEngine.MainMenu
{
    public partial class MainMenuForm : Form
    {
        Controller ctr = null;
        public MainMenuForm(Controller ctr0)
        {
            InitializeComponent();
            ctr = ctr0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ctr.executeCommand("1");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ctr.executeCommand("2");
        }
    }
}