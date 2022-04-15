using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FormBase;

namespace PACS_Planet
{
    public partial class frmSpaceshipConnection : frmBase
    {
        public frmSpaceshipConnection()
        {
            InitializeComponent();
        }

        private void btnSelectPlanet_Click(object sender, EventArgs e)
        {
            OpenForm();
        }

        private void OpenForm()
        {
            frmPlanetSelect frm = new frmPlanetSelect();
            frm.Show();

            this.Hide();
        }
    }
}
