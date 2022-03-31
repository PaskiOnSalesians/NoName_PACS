using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using FormBase;
using TCP;
using AccesDades;
using GlobalVariables;

namespace PACS_NONAME_PLANETA
{
    public partial class frmPlanetCrypto : frmBaseMain
    {
        PacsTcpServer serverTCP = new  PacsTcpServer();
        Dades _Dades = new Dades();

        string planet, namePlanetImage;
        bool receivedMessage;
        int stage = 0;

        public frmPlanetCrypto()
        {
            InitializeComponent();
            planet = RefVariables.PlanetName;
        }

        private void rtxtInfo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void frmPlanetCrypto_Load(object sender, EventArgs e)
        {
            _Dades.ConnectDB();

            DataSet dts = new DataSet();

            lblPlanetName.Text = RefVariables.PlanetName;

            lblIP_Port.Text = RefVariables.PlanetIp + ":" + RefVariables.PlanetMessagePort;

            pboxPlanet.Image = Image.FromFile(RefVariables.PlanetImage);

            Thread server = new Thread(ServerListen);
            server.Start();
        }

        private void ServerListen()
        {
            //serverTCP.ListenClient(getIPAddress(), getPort());
        }
    }
}
