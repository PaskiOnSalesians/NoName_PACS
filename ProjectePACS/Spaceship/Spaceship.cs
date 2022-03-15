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

namespace Spaceship
{
    public partial class Spaceship : Form
    {
        #region Dragging Window Variables
        private bool dragging = false;
        private Point startPoint = new Point(0, 0);
        #endregion

        Dades _Dades = new Dades();
        DataSet dts;
        string ValidationCode, PublicKeyPlanet, nomPlaneta;

        public Spaceship()
        {
            InitializeComponent();
        }

        // Event per tancar la finestra
        private void lblExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Obtenir Codi de validació
        private void btn_GetValidationCode_Click(object sender, EventArgs e)
        {
            string query, taula;
            int idPlaneta;

            idPlaneta = getPlanetId(nomPlaneta);

            dts.Clear();

            taula = "InnerEncryption";
            query = "Select ValidationCode from " + taula + " where idPlanet = " + idPlaneta;

            dts = _Dades.PortarPerConsulta(query, taula);

            ValidationCode = dts.Tables[0].Rows[0]["ValidationCode"].ToString();
        }
        #endregion

        #region Obtenir Clau Publica
        private void btn_GetPublicKeyPlanet_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Funcions Auxiliars

        // Obtenir el id del Planeta
        private int getPlanetId(string namePlanet)
        {
            string consulta, table;
            int idPlaneta;

            dts.Clear();

            table = "Planets";
            Console.WriteLine(nomPlaneta);
            consulta = "Select idPlanet from " + table + " where DescPlanet = '" + namePlanet + "'";

            dts = _Dades.PortarPerConsulta(consulta, table);

            idPlaneta = Int32.Parse(dts.Tables[0].Rows[0]["idPlanet"].ToString());

            return idPlaneta;
        }

        #endregion

        #region Events per poder moure la finestra
        private void pnlTopBar_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void pnlTopBar_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void pnlTopBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point p = PointToScreen(e.Location);
                Location = new Point(p.X - this.startPoint.X, p.Y - this.startPoint.Y);
            }
        }
        #endregion

        // Obtenir el nom del planeta
        private void lsx_DestinationPlanet_SelectedIndexChanged(object sender, EventArgs e)
        {
            nomPlaneta = lsx_DestinationPlanet.Text;
        }

        // Carrega el formulari
        private void Spaceship_Load(object sender, EventArgs e)
        {
            dts = new DataSet();
            string query, taula;

            taula = "Planets";
            query = "Select DescPlanet from " + taula + " order by DescPlanet ASC";

            _Dades.ConnectDB();

            dts = _Dades.PortarPerConsulta(query, taula);

            for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
                lsx_DestinationPlanet.Items.Add(dts.Tables[0].Rows[i]["DescPlanet"].ToString());
        }
    }
}
