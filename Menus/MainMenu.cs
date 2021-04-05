using System;
using System.Collections.Generic;
using System.Windows.Forms;

using Nilox2DGameEngine.Networking;

using NiloxUniversalLib.Logging;

namespace Nilox2DGameEngine.Menus
{
    public partial class MainMenu : Form
    {

        #region Init
        Controller cr = null;
        Form[] openedForms = new Form[10];
        public MainMenu(Controller cr0)
        {
            InitializeComponent();

            cr = cr0;
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {
            switchtomain();
        }
        private void MainMenuForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Controller.exit();
        }
        private void btexit_Click(object sender, EventArgs e)
        {
            Controller.exit();
        }
        #endregion



        #region WidgetSwitcher
        public void switchtomain()
        {
            int index = 0;

            if (openedForms[index] != null)
            {
                openedForms[index].BringToFront();
                openedForms[index].Show();
            }
            else
            {
                CreateForm(new WFMain(), index);
                openedForms[index].BringToFront();
                openedForms[index].Show();
            }
        }
        public void switchtomultiplayer()
        {
            int index = 1;

            if (openedForms[index] != null)
            {
                openedForms[index].BringToFront();
                openedForms[index].Show();
            }
            else
            {
                CreateForm(new WFMultiplayer(), index);
                openedForms[index].BringToFront();
                openedForms[index].Show();
            }
        }
        

        private void CreateForm(Form newForm, int index)
        {
            openedForms.SetValue(newForm, index);
            newForm.TopLevel = false;
            newForm.FormBorderStyle = FormBorderStyle.None;
            newForm.Dock = DockStyle.Fill;
            pnmain.Controls.Add(newForm);
            pnmain.Tag = newForm;
        }
        #endregion
    }
}
