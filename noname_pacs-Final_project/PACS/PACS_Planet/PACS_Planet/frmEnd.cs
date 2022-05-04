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
    public partial class frmEnd : frmBase
    {
        public frmEnd()
        {
            InitializeComponent();
        }

        #region Carregador de Formularis

        // Carregador de formularis
        private void OpenForm(int num)
        {
            switch (num)
            {
                case 0:
                    frmSelectPlanet frmPlanet = new frmSelectPlanet();
                    frmPlanet.Show();
                    break;
                case 1:
                    frmSpaceshipConnection frmConnection = new frmSpaceshipConnection();
                    frmConnection.Show();
                    break;
                case 2:
                    frmEncryptCodes frmCodes = new frmEncryptCodes();
                    frmCodes.Show();
                    break;
                case 3:
                    frmFileProcessing frmFiles = new frmFileProcessing();
                    frmFiles.Show();
                    break;
                case 4:
                    frmEnd frmEnd = new frmEnd();
                    frmEnd.Show();
                    break;
            }

            this.Hide();
        }

        private void btnSelectPlanet_Click(object sender, EventArgs e)
        {
            OpenForm(0);
        }

        private void btnSpaceshipConnection_Click(object sender, EventArgs e)
        {
            OpenForm(1);
        }

        private void btnEncryptCodes_Click(object sender, EventArgs e)
        {
            OpenForm(2);
        }

        private void btnFileProcessing_Click(object sender, EventArgs e)
        {
            OpenForm(3);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            //OpenForm(4);
        }

        #endregion

        private void frmEnd_Load(object sender, EventArgs e)
        {
            btnSelectPlanet.BackColor = Color.DarkGreen;
            btnSelectPlanet.ForeColor = Color.White;
            btnSpaceshipConnection.BackColor = Color.DarkGreen;
            btnSpaceshipConnection.ForeColor = Color.White;
            btnEncryptCodes.BackColor = Color.DarkGreen;
            btnEncryptCodes.ForeColor = Color.White;
            btnFileProcessing.BackColor = Color.DarkGreen;
            btnFileProcessing.ForeColor = Color.White;
        }
    }
}
