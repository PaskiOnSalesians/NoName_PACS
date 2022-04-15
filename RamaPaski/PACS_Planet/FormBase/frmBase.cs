using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormBase
{
    public partial class frmBase : Form
    {
        public frmBase()
        {
            InitializeComponent();
        }

        // Tancar aplicacio
        private void CloseApp_Click(object sender, EventArgs e)
        {
            MessageBoxButtons msgbuttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show("Segur que vols sortir?", "PACS - NONAME", msgbuttons);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Minimitzar finestra
        private void MinimizeApp_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
