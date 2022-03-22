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
    public partial class PlanetView : Form
    {
        #region Variables
        // Casteig Acces Dades
        Dades _Dades = new Dades();
        DataSet dts;

        // Dragging Variables
        bool dragging = false; // Per a comprovar si podem moure la finestra
        Point startPoint = new Point(0, 0); // Posicio inicial de la finestra
        #endregion

        int MaximitzarPantalla = 0;

        public PlanetView()
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
        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBoxButtons msgbuttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show("Segur que vols sortir?", "PACS - NONAME", msgbuttons);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        #endregion

        private void PlanetView_Load(object sender, EventArgs e)
        {
            _Dades.ConnectDB();

            // Carregar tots els planetes
            dts = new DataSet();
            string query, taula;

            taula = "Planets";
            query = "Select DescPlanet, PlanetPicture from " + taula + " order by DescPlanet ASC";

            _Dades.ConnectDB();

            dts = _Dades.PortarPerConsulta(query, taula);

            for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
                lstvPlanets.Items.Add(dts.Tables[0].Rows[i]["DescPlanet"].ToString());
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_maximize_Click(object sender, EventArgs e)
        {
            if(MaximitzarPantalla == 0)
            {
                this.WindowState = FormWindowState.Maximized;
                MaximitzarPantalla++;

            } else if(MaximitzarPantalla == 1)
            {
                //this.WindowState = FormWindowState.Minimized;
                this.WindowState = FormWindowState.Normal;
                //this.Form.Size = new Size(1264, 681);
                MaximitzarPantalla--;
            }
        }
    }
}
