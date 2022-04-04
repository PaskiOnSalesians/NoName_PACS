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
using FormBase;
using VariablesGlobals;
using TCP;
namespace PACS_NONAME_NAU
{
    public partial class frmConnectionShip : frmBaseMain
    {
        PacsTcpClient tcp = new PacsTcpClient();
        DadesDB db = new DadesDB("SecureCoreG2");

        public frmConnectionShip()
        {
            InitializeComponent();
        }

        private void frmConnectionShip_Load(object sender, EventArgs e)
        {
            db.Connectar();
            LoadPlanetData();
            LoadShipData();
        }

        private void LoadShipData()
        {
            lblShipName.Text = RefVariables.ShipName;
            lblShipIP.Text = RefVariables.ShipIp;
            lblFilePortShip.Text = RefVariables.ShipFilePort.ToString();
            lblMsgPortShip.Text = RefVariables.ShipMessagePort.ToString();
            picBoxShip.Image = Image.FromFile(RefVariables.ShipImage);
        }

        private void LoadPlanetData()
        {
            lblPlanetName.Text = RefVariables.PlanetName;
            lblPlanetIP.Text = RefVariables.PlanetIp;
            lblFilePortPlanet.Text = RefVariables.PlanetFilePort.ToString();
            lblMsgPortPlanet.Text = RefVariables.PlanetMessagePort.ToString();
            picBoxPlanet.Image = Image.FromFile(RefVariables.PlanetImage);
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
           
           //tcp.MakePing(RefVariables.PlanetIp);
           tcp.SendMessage(RefVariables.PlanetIp, RefVariables.PlanetMessagePort, "HOLA");
            
        }
    }
}
