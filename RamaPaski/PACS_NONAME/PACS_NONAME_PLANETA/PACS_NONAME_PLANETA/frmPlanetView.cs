using AccesDades;
using FormBase;

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

        bool exit = true;
        public string nomPlaneta;

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

            string imageRoute = Application.StartupPath + "\\..\\resources\\images\\Planets\\"; // Ruta a les imatges

            #region Carregar Planetes

            try
            {

                taula = "Planets";
                query = "Select DescPlanet, PlanetPicture from " + taula + " order by DescPlanet ASC";

                _Dades.ConnectDB();

                dts = _Dades.PortarPerConsulta(query, taula);

                // dts.Tables[0].Rows[i]["DescPlanet"].ToString(), )

                for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
                {
                    imagePlanetList.Images.Add(Image.FromFile(@imageRoute + dts.Tables[0].Rows[i]["PlanetPicture"].ToString()));
                    lstvPlanets.LargeImageList = imagePlanetList;
                    lstvPlanets.Items.Add(dts.Tables[0].Rows[i]["DescPlanet"].ToString(), i);
                }
            }
            catch
            {
                MessageBox.Show("Algo ha fallado");
            }
            
            #endregion
        }
        #endregion

        #region Guardar Planeta en una variable
        private void lstvPlanets_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedPlanet = this.lstvPlanets.SelectedItems;

            System.Drawing.Color Highlight = Color.Red;

            foreach (ListViewItem item in selectedPlanet)
            {
                nomPlaneta = item.SubItems[0].Text;
                item.BackColor = Color.Red;
            }

            Console.WriteLine(nomPlaneta);
        }
        #endregion

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
            frmPlanetCrypto nextFrm = new frmPlanetCrypto(nomPlaneta);
            this.Visible = false;
            nextFrm.ShowDialog();
            this.Close();
        }
    }
}
