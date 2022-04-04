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
using AccesDades;
using VariablesGlobals;

namespace PACS_NONAME_NAU
{
    public partial class frmPlanetView : frmBaseMain
    {

        public frmPlanetView()
        {
            InitializeComponent();
        }

        DadesDB db = new DadesDB("SecureCoreG2");
        DataSet dts;
        string imageRoute = Application.StartupPath + "\\..\\resources\\images\\Planets\\"; // Ruta a les imatges


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

        private void frmPlanetView_Load(object sender, EventArgs e)
        {
            db.Connectar();

            dts = new DataSet();
            string query, taula;

            // Variables Imatges de la ListView
            ImageList imagePlanetList = new ImageList();
            imagePlanetList.ImageSize = new Size(128, 128);

            try
            {
                taula = "Planets";
                query = "Select * from " + taula + " order by DescPlanet ASC";

                db.Connectar();

                dts = db.PortarPerConsulta(query, taula);

                for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
                {
                    imagePlanetList.Images.Add(Image.FromFile(@imageRoute + dts.Tables[0].Rows[i]["PlanetPicture"].ToString()));
                    lstvPlanets.LargeImageList = imagePlanetList;
                    lstvPlanets.Items.Add(dts.Tables[0].Rows[i]["DescPlanet"].ToString(), i);
                    lstvPlanets.Items[i].Tag = dts.Tables[0].Rows[i]["idPlanet"];
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void LoadVariables(int idPlanetSelect)
        {
            dts = new DataSet();
            dts = db.PortarPerConsulta("select * from Planets where idPlanet = '" + idPlanetSelect + "'");

            RefVariables.PlanetCode = dts.Tables[0].Rows[0]["CodePlanet"].ToString();
            RefVariables.PlanetName = dts.Tables[0].Rows[0]["DescPlanet"].ToString();
            RefVariables.PlanetImage = imageRoute + (dts.Tables[0].Rows[0]["PlanetPicture"].ToString());
            RefVariables.PlanetIp = dts.Tables[0].Rows[0]["IPPlanet"].ToString();
            RefVariables.PlanetMessagePort = int.Parse(dts.Tables[0].Rows[0]["PortPlanet"].ToString());
            RefVariables.PlanetFilePort = int.Parse(dts.Tables[0].Rows[0]["PortPlanet1"].ToString());
        }

        private void generateTCPForm()
        {
            frmConnectionShip nextFrm = new frmConnectionShip();
            this.Visible = false;
            nextFrm.ShowDialog();
            this.Close();
        }

        private void lstvPlanets_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                generateTCPForm();
            }
        }

        private void lstvPlanets_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            generateTCPForm();
        }
    }
}