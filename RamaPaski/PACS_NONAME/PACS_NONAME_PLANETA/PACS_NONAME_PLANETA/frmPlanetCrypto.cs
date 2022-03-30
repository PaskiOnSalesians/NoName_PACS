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

namespace PACS_NONAME_PLANETA
{
    public partial class frmPlanetCrypto : frmBaseMain
    {
        PacsTcpServer serverTCP = new  PacsTcpServer();
        Dades _Dades = new Dades();

        string planet, namePlanetImage;
        bool receivedMessage;
        int stage = 0;

        public frmPlanetCrypto(string planetName)
        {
            InitializeComponent();
            planet = planetName;
        }

        private void rtxtInfo_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void frmPlanetCrypto_Load(object sender, EventArgs e)
        {
            _Dades.ConnectDB();

            string ipAddr, port;
            DataSet dts = new DataSet();

            lblPlanetName.Text = planet;

            dts = _Dades.PortarPerConsulta("select IPPlanet, PortPlanet from Planets where DescPlanet = '" + planet + "'");

            ipAddr = dts.Tables[0].Rows[0]["IPPlanet"].ToString();
            port = dts.Tables[0].Rows[0]["PortPlanet"].ToString();

            lblIP_Port.Text = ipAddr + ":" + port;

            if (planet.Contains(' '))
            {
                namePlanetImage = planet.Replace(' ', '_');
                pboxPlanet.Image = Image.FromFile(Application.StartupPath + "\\..\\resources\\images\\Planets\\" + namePlanetImage + ".png");
            }
            else
            {
                pboxPlanet.Image = Image.FromFile(Application.StartupPath + "\\..\\resources\\images\\Planets\\" + planet + ".png");
            }

            Thread server = new Thread(ServerListen);
            server.Start();
        }

        private void ServerListen()
        {
            //serverTCP.ListenClient(getIPAddress(), getPort());
        }

        private string getIPAddress()
        {
            DataSet dts = new DataSet();
            string nomTaula = "Planets";
            string query = "select IPPlanet from " + nomTaula + " where DescPlanet = '" + planet + "'";

            string IP;

            dts = _Dades.PortarPerConsulta(query, nomTaula);

            IP = dts.Tables[0].Rows[0]["IPPlanet"].ToString();

            Console.WriteLine("\n\n\n" + IP + "\n\n\n");
            return IP;
        }

        private int getPort()
        {
            DataSet dts = new DataSet();
            string nomTaula = "Planets";
            string query = "select PortPlanet from " + nomTaula + " where DescPlanet = '" + planet + "'";

            int port;

            dts = _Dades.PortarPerConsulta(query, nomTaula);

            port = int.Parse(dts.Tables[0].Rows[0]["PortPlanet"].ToString());

            Console.WriteLine("\n\n\n" + port + "\n\n\n");
            return port;
        }
    }
}
