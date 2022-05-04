using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AccesDades;
using GlobalVariables;
using FormBase;

namespace PACS_Ship
{
    public partial class frmSelectPlanet : frmBase
    {
        Dades _Dades = new Dades(); // Obtenir les funcions relacionades amb la base de dades

        // Inicialitzacio de variables
        DataSet dts;
        string imageRoute = Application.StartupPath + "\\..\\Resources\\images\\Planets\\"; // Ruta a les imatges

        public frmSelectPlanet()
        {
            InitializeComponent();
        }

        #region Events

        // Carrega inicial del formulari
        private void frmSelectPlanet_Load(object sender, EventArgs e)
        {
            _Dades.ConnectDB(); // Connectar a la base de dades

            // Ara hem d'obtenir les imatges per fer la seleccio de 
            // planetes, llavors farem una query obtenint el nom de
            // les respectives imatges amb l'extensio.

            dts = new DataSet();

            string query, taula;

            // Creem una llista d'imatges i definim el tamany
            ImageList imagePlanetList = new ImageList();
            imagePlanetList.ImageSize = new Size(255, 255);
            imagePlanetList.ColorDepth = ColorDepth.Depth32Bit;

            try
            {
                taula = "Planets";
                query = "Select * from " + taula + " order by DescPlanet ASC";

                dts = _Dades.PortarPerConsulta(query, taula);

                for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
                {
                    imagePlanetList.Images.Add(Image.FromFile(@imageRoute + dts.Tables[0].Rows[i]["PlanetPicture"].ToString()));
                    lstvPlanets.LargeImageList = imagePlanetList;
                    lstvPlanets.Items.Add(dts.Tables[0].Rows[i]["DescPlanet"].ToString(), i);
                    lstvPlanets.Items[i].Tag = dts.Tables[0].Rows[i]["idPlanet"];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No s'ha pogut carregar correctament!", "PACS - NONAME");
            }


            btnSelectShip.ForeColor = Color.White;
            btnSelectShip.BackColor = Color.DarkGreen;
            btnConnectPlanet.ForeColor = Color.White;
            btnEncryptCodes.ForeColor = Color.White;
            btnFileProcessing.ForeColor = Color.White;
            btnEnd.ForeColor = Color.White;
        }

        // Seleccio del planeta
        private void lstvPlanets_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedPlanet = this.lstvPlanets.SelectedItems;

            foreach (ListViewItem item in selectedPlanet)
            {
                RefVariables.PlanetId = (int)item.Tag;
                Console.WriteLine(RefVariables.PlanetId);
            }

            LoadVariables(RefVariables.PlanetId);

            btnConnectPlanet.Enabled = true;
        }

        // Metode auxiliar per emmagatzemar dades globals
        private void LoadVariables(int idPlanetSelect)
        {
            dts = new DataSet();
            dts = _Dades.PortarPerConsulta("select * from Planets where idPlanet = " + idPlanetSelect);

            RefVariables.PlanetCode = dts.Tables[0].Rows[0]["CodePlanet"].ToString();
            RefVariables.PlanetName = dts.Tables[0].Rows[0]["DescPlanet"].ToString();
            RefVariables.PlanetImage = imageRoute + (dts.Tables[0].Rows[0]["PlanetPicture"].ToString());
            RefVariables.PlanetIp = dts.Tables[0].Rows[0]["IPPlanet"].ToString();
            RefVariables.PlanetMessagePort = int.Parse(dts.Tables[0].Rows[0]["PortPlanet"].ToString());
            RefVariables.PlanetFilePort = int.Parse(dts.Tables[0].Rows[0]["PortPlanet1"].ToString());
        }

        #endregion

        #region Carregador de Formularis

        // Carregador de formularis
        private void OpenForm(int num)
        {
            switch (num)
            {
                case 0:
                    frmSelectShip frmShip = new frmSelectShip();
                    frmShip.Show();
                    break;
                case 1: 
                    frmSelectPlanet frmPlanet = new frmSelectPlanet();
                    frmPlanet.Show();
                    break;
                case 2:
                    frmConnectPlanet frmConnection = new frmConnectPlanet();
                    frmConnection.Show();
                    break;
                case 3:
                    frmEncryptCodes frmCodes = new frmEncryptCodes();
                    frmCodes.Show();
                    break;
                case 4:
                    frmFileProcessing frmFiles = new frmFileProcessing();
                    frmFiles.Show();
                    break;
                case 5:
                    frmEnd frmEnd = new frmEnd();
                    frmEnd.Show();
                    break;
            }

            this.Hide();
        }

        private void btnSelectSpaceship_Click(object sender, EventArgs e)
        {
            OpenForm(0);
        }

        private void btnSelectPlanet_Click(object sender, EventArgs e)
        {
            //OpenForm(1);
        }

        private void btnConnectPlanet_Click(object sender, EventArgs e)
        {
            OpenForm(2);
        }

        private void btnEncryptCodes_Click(object sender, EventArgs e)
        {
            OpenForm(3);
        }

        private void btnFileProcessing_Click(object sender, EventArgs e)
        {
            OpenForm(4);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            OpenForm(5);
        }

        #endregion

        #region Metodes per accedir al seguent formulari

        // Apretar la tecla enter
        private void lstvPlanets_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                OpenForm(2);
            }
        }

        // Doble clic del mouse
        private void lstvPlanets_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenForm(2);
        }

        #endregion
    }
}
