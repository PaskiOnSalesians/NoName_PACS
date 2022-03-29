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

        DadesDB db = new DadesDB("SecureCoreServer");
        DataSet dts;
        public string nomNau;


        private void lstvShips_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedShip = this.lstvShips.SelectedItems;


            foreach (ListViewItem item in selectedShip)
            {
                nomNau = item.SubItems[0].Text;

            }

            Console.WriteLine(nomNau);
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
                query = "Select CodeSpaceShip, SpaceshipImage from " + taula + " where SpaceshipImage is not null order by CodeSpaceShip";

                db.Connectar();

                dts = db.PortarPerConsulta(query, taula);

                for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
                {
                    imageShipList.Images.Add(Image.FromFile(@imageRoute + dts.Tables[0].Rows[i]["SpaceshipImage"].ToString()));
                    lstvShips.LargeImageList = imageShipList;
                    lstvShips.Items.Add(dts.Tables[0].Rows[i]["CodeSpaceShip"].ToString(), i);
                }
            }
            catch (Exception ext)
            {
                MessageBox.Show(ext.ToString());
            }
        }
    }
}
