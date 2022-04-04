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
    public partial class frmPlanetConnection : frmBaseMain
    {
        PacsTcpServer serverTCP = new  PacsTcpServer();
        Dades _Dades = new Dades();

        string planet;

        public frmPlanetConnection()
        {
            InitializeComponent();
            planet = RefVariables.PlanetName;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void rtxtInfo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void frmPlanetCrypto_Load(object sender, EventArgs e)
        {
            _Dades.ConnectDB();

            DataSet dts = new DataSet();

            lblPlanetName.Text = planet;
            lblPlanetIP.Text = RefVariables.PlanetIp;
            lblPlanetPort.Text = RefVariables.PlanetMessagePort.ToString();

            lblShipName.Text = "???";
            lblShipIp.Text = "???";
            lblShipPort.Text = "???";

            pboxPlanet.Image = Image.FromFile(RefVariables.PlanetImage);
            pboxNau.Image = Image.FromFile(Application.StartupPath + "\\..\\resources\\images\\Ships\\shipUnknown.png");

            Timer_Arrow.Start();

            Thread server = new Thread(ServerListen);
            server.Start();
        }

        private void Timer_Arrow_Tick(object sender, EventArgs e)
        {
            pnlConnect1.BackColor = Color.Yellow;
            pnlConnect1.BackColor = Color.White;

        }

        private void ServerListen()
        {
            
            serverTCP.StartServer(RefVariables.PlanetIp, RefVariables.PlanetMessagePort);
            rtxtInfo.Text += serverTCP.ReceivePing();
            rtxtInfo.Text = "\n";
            rtxtInfo.Text += serverTCP.GetClientMessages();
        }
    }
}
