using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FormBase;
using GlobalVariables;
using AccesDades;
using System.Net.Sockets;
using System.Net;

namespace PACS_Ship
{
    public partial class frmSelectShip : frmBase
    {
        Dades _Dades = new Dades(); // Obtenir les funcions relacionades amb la base de dades

        // Inicialitzacio de variables
        DataSet dts;
        string imageShipRoute = Application.StartupPath + "\\..\\Resources\\images\\Ships\\"; // Ruta a les imatges

        public frmSelectShip()
        {
            InitializeComponent();
        }

        #region Events

        // Carrega inicial del formulari
        private void frmSelectShip_Load(object sender, EventArgs e)
        {
            _Dades.ConnectDB(); // Connectar a la base de dades

            // Ara hem d'obtenir les imatges per fer la seleccio de 
            // naus, llavors farem una query obtenint el nom de les
            // respectives imatges amb l'extensio.

            dts = new DataSet();

            string query, taula;

            // Creem una llista d'imatges i definim el tamany
            ImageList imageShipList = new ImageList();
            imageShipList.ImageSize = new Size(255, 255);
            imageShipList.ColorDepth = ColorDepth.Depth32Bit; // Aquesta es per evitar un rebordat blanc

            updateIP();

            try
            {
                taula = "SpaceShips";
                query = "Select * from " + taula + " where SpaceshipImage is not null order by CodeSpaceShip";

                dts = _Dades.PortarPerConsulta(query, taula);

                for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
                {
                    imageShipList.Images.Add(Image.FromFile(@imageShipRoute + dts.Tables[0].Rows[i]["SpaceshipImage"].ToString()));
                    lstvSpaceship.LargeImageList = imageShipList;
                    lstvSpaceship.Items.Add(dts.Tables[0].Rows[i]["CodeSpaceShip"].ToString(), i);
                    lstvSpaceship.Items[i].Tag = dts.Tables[0].Rows[i]["idSpaceShip"];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No s'ha pogut carregar correctament!", "PACS - NONAME");
            }
        }

        // Seleccio de la nau
        private void lstvSpaceship_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView.SelectedListViewItemCollection selectedShip = this.lstvSpaceship.SelectedItems;

            foreach (ListViewItem item in selectedShip)
            {
                RefVariables.ShipId = (int)item.Tag;
            }

            LoadVariables(RefVariables.ShipId);
        }

        // Metode auxiliar per emmagatzemar dades globals
        private void LoadVariables(int id)
        {
            dts = new DataSet();

            //Cambiar select
            dts = _Dades.PortarPerConsulta("select * from SpaceShips where SpaceshipImage is not null and idSpaceShip =" + id);

            RefVariables.ShipId = int.Parse(dts.Tables[0].Rows[0]["idSpaceShip"].ToString());
            RefVariables.ShipName = dts.Tables[0].Rows[0]["CodeSpaceShip"].ToString();
            RefVariables.ShipIp = dts.Tables[0].Rows[0]["IPSpaceShip"].ToString();
            RefVariables.ShipFilePort = int.Parse(dts.Tables[0].Rows[0]["PortSpaceShip"].ToString());
            RefVariables.ShipMessagePort = int.Parse(dts.Tables[0].Rows[0]["PortSpaceShip1"].ToString());
            RefVariables.ShipImage = imageShipRoute + (dts.Tables[0].Rows[0]["SpaceShipImage"].ToString());
        }

        #endregion

        #region  Carregador de Formularis

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
            //OpenForm(0);
        }

        private void btnSelectPlanet_Click(object sender, EventArgs e)
        {
            OpenForm(1);
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
        private void lstvSpaceship_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter)
            {
                OpenForm(1);
            }
        }

        // Doble clic del mouse
        private void lstvSpaceship_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OpenForm(1);
        }

        #endregion

        #region Metodes Principals

        // Actualitzar IP
        private void updateIP()
        {
            string query, taula, currentIP;

            dts = new DataSet();

            try
            {
                using (Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, 0))
                {
                    socket.Connect("10.0.123.2", 1337); // Dona igual quina ip sigui
                    IPEndPoint endPoint = socket.LocalEndPoint as IPEndPoint;
                    currentIP = endPoint.Address.ToString(); // Obtenim la ip

                    Console.WriteLine("\n" + currentIP + "\n");

                    taula = "SpaceShips";
                    query = "Update " + taula + " set IPSpaceShip = '" + currentIP + "' where SpaceshipImage is not null";

                    _Dades.Executar(query);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ha ocorregut un error.", "PACS - NONAME");
            }
        }

        #endregion
    }
}
