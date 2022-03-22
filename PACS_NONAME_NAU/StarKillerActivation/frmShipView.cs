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

namespace StarKillerActivation
{
    public partial class frmShipView : Form
    {
    
        DadesDB db = new DadesDB("SecureCoreServer");
        DataSet dts;

        // Dragging Variables
        bool dragging = false; // Per a comprovar si podem moure la finestra
        Point startPoint = new Point(0, 0); // Posicio inicial de la finestra

        int MaximitzarPantalla = 0, MaximitzarPantallaTab = 0;
        


        public frmShipView()
        {
            InitializeComponent();
        }

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            MessageBoxButtons msgbuttons = MessageBoxButtons.YesNo;

            DialogResult result = MessageBox.Show("Segur que vols sortir?", "PACS - NONAME", msgbuttons);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void PlanetView_Load(object sender, EventArgs e)
        {
            db.Connectar();

            // Carregar tots els planetes
            dts = new DataSet();
            string query, taula;

            taula = "Planets";
            query = "SELECT DescPlanet, PlanetPicture FROM " + taula + " ORDER BY DescPlanet;";

            db.Connectar();

            dts = db.PortarPerConsulta(query, taula);

            if (this.dts.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow item in dts.Tables[0].Rows)
                {
                    lstvPlanets.Items.Add(item["DescPlanet"].ToString());
                }

            }

            
        }

        private void btn_minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

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

     

        private void pnl_topbar_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (MaximitzarPantallaTab == 0)
            {
                this.WindowState = FormWindowState.Maximized;
                MaximitzarPantallaTab++;

            }
            else if (MaximitzarPantallaTab == 1)
            {
                
                this.WindowState = FormWindowState.Normal;
                MaximitzarPantallaTab--;
            }
        }
    }
}
