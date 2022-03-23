using AccesDades;

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
    public partial class frmPlanetView : Form
    {
        #region Variables

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

        #region Dragging window
        private void pnl_topbar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void pnl_topbar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void pnl_topbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }

        #endregion

        #region Minimize - Maximize - Exit

        // Botó Sortir
        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBoxButtons msgbuttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show("Segur que vols sortir?", "PACS - NONAME", msgbuttons);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Botó Minimitzar
        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Botó Maximitzar
        private void btn_maximize_Click(object sender, EventArgs e)
        {
            if (MaximitzarPantalla == 0)
            {
                this.WindowState = FormWindowState.Maximized;
                MaximitzarPantalla++;

            }
            else if (MaximitzarPantalla == 1)
            {
                this.WindowState = FormWindowState.Normal;
                MaximitzarPantalla--;
            }
        }

        // Maximitzar/Normal amb la barra superior
        private void pnl_topbar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MaximitzarPantalla == 0)
            {
                this.WindowState = FormWindowState.Maximized;
                MaximitzarPantalla++;

            }
            else if (MaximitzarPantalla == 1)
            {
                this.WindowState = FormWindowState.Normal;
                MaximitzarPantalla--;
            }
        }
        #endregion

        #region Events Formulari

        // Carreguem dades a l'inici de programa
        private void PlanetView_Load(object sender, EventArgs e)
        {
            _Dades.ConnectDB();

            dts = new DataSet();
            string query, taula;
            string imageRoute = Application.StartupPath + "\\..\\resources\\Planets\\"; // Ruta a les imatges
            
            ImageList imagePlanetList = new ImageList();
            imagePlanetList.ImageSize = new Size(128, 128);

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
    }
}
