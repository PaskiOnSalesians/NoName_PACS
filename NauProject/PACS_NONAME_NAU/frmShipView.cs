using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VariablesGlobals;
using AccesDades;
using FormBase;


namespace PACS_NONAME_NAU
{
    public partial class frmShipView : frmBaseMain
    {
        public frmShipView()
        {
            InitializeComponent();
        }

        DadesDB db = new DadesDB("SecureCoreG2");
        DataSet dts;

    
        private void lstvShips_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedPlanet = this.lstvShips.SelectedItems;

            foreach (ListViewItem item in selectedPlanet)
            {
                RefVariables.ShipId = (int)item.Tag;
            }

            LoadVariables(RefVariables.ShipId);
        }

        private void frmShipView_Load(object sender, EventArgs e)
        {
            db.Connectar();

            dts = new DataSet();
            string query, taula;

            // Variables Imatges de la ListView
            ImageList imageShipList = new ImageList();
            imageShipList.ImageSize = new Size(144, 144);

            string imageRoute = Application.StartupPath + "\\..\\resources\\images\\Ships\\"; // Ruta a les imatges

            try
            {

                taula = "SpaceShips";
                query = "Select * from " + taula + " where SpaceshipImage is not null order by CodeSpaceShip";

                db.Connectar();

                dts = db.PortarPerConsulta(query, taula);

                for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
                {
                    imageShipList.Images.Add(Image.FromFile(@imageRoute + dts.Tables[0].Rows[i]["SpaceshipImage"].ToString()));
                    lstvShips.LargeImageList = imageShipList;
                    lstvShips.Items.Add(dts.Tables[0].Rows[i]["CodeSpaceShip"].ToString(), i);
                    lstvShips.Items[i].Tag = dts.Tables[0].Rows[i]["idSpaceShip"];
                }
                
            }
            catch (Exception ext)
            {
                MessageBox.Show(ext.ToString());
            }
        }

        private void LoadVariables(int id)
        {
            dts = new DataSet();
            //Cambiar select
            dts = db.PortarPerConsulta("SELECT * FROM SpaceShips WHERE SpaceshipImage IS NOT NULL AND '" + id + "' ORDER BY CodeSpaceShip", "SpaceShips");


            RefVariables.ShipId = int.Parse(dts.Tables[0].Rows[0]["idSpaceShip"].ToString());
            RefVariables.ShipName = dts.Tables[0].Rows[0]["CodeSpaceShip"].ToString();
            RefVariables.ShipIp = dts.Tables[0].Rows[0]["IPSpaceShip"].ToString();
            RefVariables.ShipFilePort = int.Parse(dts.Tables[0].Rows[0]["PortSpaceShip"].ToString());
            RefVariables.ShipMessagePort = int.Parse(dts.Tables[0].Rows[0]["PortSpaceShip1"].ToString());
            RefVariables.ShipImage = dts.Tables[0].Rows[0]["SpaceShipImage"].ToString();
        }

        private void generateTCPForm()
        {
            frmMenuNau nextFrm = new frmMenuNau();
            this.Visible = false;
            nextFrm.ShowDialog();
            this.Close();
        }

        private void lstvShips_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter)
            {
                generateTCPForm();
            }

        }

        private void lstvShips_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            generateTCPForm();
        }
    }
}
