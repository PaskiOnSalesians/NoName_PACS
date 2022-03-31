using AccesDades;
using FormBase;
using GlobalVariables;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PACS_NONAME_PLANETA
{
    public partial class frmPlanetView : frmBaseMain
    {
        #region Variables

        #region Variables Generals

        string imageRoute = Application.StartupPath + "\\..\\resources\\images\\Planets\\"; // Ruta a les imatges

        #endregion

        #region Variables de Dades
        // Casteig Acces Dades

        Dades _Dades = new Dades();
        DataSet dts;

        #endregion

        #region Variables de customització de programa
        // Variables de tamany pantalla
        int MaximitzarPantalla = 0;

        // Dragging Variables
        bool dragging = false; // Per a comprovar si podem moure la finestra
        Point startPoint = new Point(0, 0); // Posicio inicial de la finestra
        #endregion

        #endregion

        public frmPlanetView()
        {
            InitializeComponent();
        }

        #region Events Formulari

        // Carreguem dades a l'inici de programa
        private void PlanetView_Load(object sender, EventArgs e)
        {
            _Dades.ConnectDB();

            dts = new DataSet();
            string query, taula;
            
            // Variables Imatges de la ListView
            ImageList imagePlanetList = new ImageList();
            imagePlanetList.ImageSize = new Size(128, 128);

            #region Carregar Planetes

            try
            {
                taula = "Planets";
                query = "Select * from " + taula + " order by DescPlanet ASC";

                _Dades.ConnectDB();

                dts = _Dades.PortarPerConsulta(query, taula);

                for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
                {
                    imagePlanetList.Images.Add(Image.FromFile(@imageRoute + dts.Tables[0].Rows[i]["PlanetPicture"].ToString()));
                    lstvPlanets.LargeImageList = imagePlanetList;
                    lstvPlanets.Items.Add(dts.Tables[0].Rows[i]["DescPlanet"].ToString(), i);
                    lstvPlanets.Items[i].Tag = dts.Tables[0].Rows[i]["idPlanet"];
                }
            }
            catch(Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            
            #endregion
        }
        #endregion

        #region Guardar Planeta en una variable
        private void lstvPlanets_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedPlanet = this.lstvPlanets.SelectedItems;

            foreach (ListViewItem item in selectedPlanet)
            {
                RefVariables.PlanetId = (int)item.Tag;
                Console.WriteLine(RefVariables.PlanetId);
            }

            LoadVariables(RefVariables.PlanetId);
        }

        private void LoadVariables(int idPlanetSelect)
        {
            dts = new DataSet();
            dts = _Dades.PortarPerConsulta("select * from Planets where idPlanet = '" + idPlanetSelect + "'");

            RefVariables.PlanetCode = dts.Tables[0].Rows[0]["CodePlanet"].ToString();
            RefVariables.PlanetName = dts.Tables[0].Rows[0]["DescPlanet"].ToString();
            RefVariables.PlanetImage = imageRoute + (dts.Tables[0].Rows[0]["PlanetPicture"].ToString());
            RefVariables.PlanetIp = dts.Tables[0].Rows[0]["IPPlanet"].ToString();
            RefVariables.PlanetMessagePort = int.Parse(dts.Tables[0].Rows[0]["PortPlanet"].ToString());
            RefVariables.PlanetFilePort = int.Parse(dts.Tables[0].Rows[0]["PortPlanet1"].ToString());
        }

        #endregion

        #region Generar formulari TCP
        private void lstvPlanets_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            generateTCPForm();
        }

        private void lstvPlanets_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                generateTCPForm();
            }
        }

        private void generateTCPForm()
        {
            frmPlanetCrypto nextFrm = new frmPlanetCrypto();
            this.Visible = false;
            nextFrm.ShowDialog();
            this.Close();
        }

        #endregion
    }
}
