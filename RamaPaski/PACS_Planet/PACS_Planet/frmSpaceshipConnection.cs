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
using TCP;
using FormBase;
using GlobalVariables;
using System.Threading;

namespace PACS_Planet
{
    public partial class frmSpaceshipConnection : frmBase
    {
        PacsTcpServer serverTCP = new PacsTcpServer();

        Thread server;

        Dades _Dades = new Dades();
        DataSet dts;

        string validationMessage;
        string remoteIP;

        bool status = false;

        public frmSpaceshipConnection()
        {
            InitializeComponent();
        }

        #region Carregador de Formularis

        // Carregador de formularis
        private void OpenForm(int num)
        {
            switch (num)
            {
                case 0:
                    frmSelectPlanet frmPlanet = new frmSelectPlanet();
                    this.Visible = false;
                    frmPlanet.Show();
                    break;
                case 1:
                    frmSpaceshipConnection frmConnection = new frmSpaceshipConnection();
                    this.Visible = false;
                    frmConnection.Show();
                    break;
                case 2:
                    frmEncryptCodes frmCodes = new frmEncryptCodes();
                    this.Visible = false;
                    frmCodes.Show();
                    break;
                case 3:
                    frmFileProcessing frmFiles = new frmFileProcessing();
                    this.Visible = false;
                    frmFiles.Show();
                    break;
                case 4:
                    frmEnd frmEnd = new frmEnd();
                    this.Visible = false;
                    frmEnd.Show();
                    break;
            }

            this.Close();
        }

        private void btnSelectPlanet_Click(object sender, EventArgs e)
        {
            OpenForm(0);
        }

        private void btnSpaceshipConnection_Click(object sender, EventArgs e)
        {
            //OpenForm(1);
        }

        private void btnEncryptCodes_Click(object sender, EventArgs e)
        {
            OpenForm(2);
        }

        private void btnFileProcessing_Click(object sender, EventArgs e)
        {
            OpenForm(3);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            OpenForm(4);
        }

        #endregion

        #region Start Server + Load Form + Close Form

        private void frmSpaceshipConnection_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            _Dades.ConnectDB();

            // Dades inicials Planeta
            lblPlanetName.Text = RefVariables.PlanetName;
            lblPlanetIP.Text = RefVariables.PlanetIp;
            lblPlanetMessagePort.Text = RefVariables.PlanetMessagePort.ToString();
            //Console.WriteLine("\n" + RefVariables.PlanetImage + "\n");
            pboxPlanet.Image = Image.FromFile(RefVariables.PlanetImage);

            // Dades inicials Nau
            lblShipName.Text = "???";
            lblShipIP.Text = "???";
            lblShipMessagePort.Text = "???";
            pboxShip.Image = Image.FromFile(Application.StartupPath + "\\..\\Resources\\images\\Ships\\shipUnknown.png");

            server = new Thread(ServerListen);
            server.Start();
        }

        private void ServerListen()
        {
            serverTCP.StartServer(RefVariables.PlanetIp, RefVariables.PlanetMessagePort);
            //serverTCP.ListenClient(RefVariables.PlanetIp, RefVariables.PlanetMessagePort);
            remoteIP = serverTCP.IPClient; // IP del client que ens fa ping
            rtxData.Text += serverTCP.GetClientMessages();
            LoadShipInfo(remoteIP);
            serverTCP.StopListening();
        }

        private void CheckThreadStatus()
        {
            if (status)
            {
                server.Abort();
            }
        }

        private void frmPlanetConnection_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Abort();
        }

        #endregion

        #region Load Ship Info + Defragment Code

        private void LoadShipInfo(string ip)
        {
            int pos;
            string cShip, delivery; // codeShip and Delivery
            dts = new DataSet();

            (cShip, delivery) = DefragmentCode();

            // Obtenir dades de la nau
            dts = _Dades.PortarPerConsulta("select * from SpaceShips where SpaceshipImage is not null and CodeSpaceShip = '" + cShip + "'", "SpaceShips");

            RefVariables.ShipName = cShip;
            RefVariables.ShipMessagePort = int.Parse(dts.Tables[0].Rows[0]["PortSpaceShip1"].ToString());
            RefVariables.ShipImage = dts.Tables[0].Rows[0]["SpaceshipImage"].ToString();
            RefVariables.ShipId = int.Parse(dts.Tables[0].Rows[0]["idSpaceShip"].ToString());
            RefVariables.ShipFilePort = int.Parse(dts.Tables[0].Rows[0]["PortSpaceShip"].ToString());

            RefVariables.DeliveryCode = delivery;

            // Afegir la nau a les etiquetes
            pos = ip.IndexOf(":");

            lblShipIP.Text = ip.Substring(0, pos);

            RefVariables.ShipIp = lblShipIP.Text;

            lblShipName.Text = cShip;
            lblShipMessagePort.Text = RefVariables.ShipMessagePort.ToString();
            pboxShip.Image = Image.FromFile(Application.StartupPath + "\\..\\Resources\\images\\Ships\\" + RefVariables.ShipImage);
        }

        private (string, string) DefragmentCode()
        {
            string[] finalSplitted;
            string codeShip, codeDelivery, text;

            text = rtxData.Text;

            int notIndex = text.IndexOf("ER");
            int firstindex = text.IndexOf("ER", notIndex + 1);
            int secondindex = text.IndexOf("\n", firstindex);
            string finalMessage = text.Substring(firstindex, secondindex - firstindex);

            finalSplitted = finalMessage.Split('.');

            codeShip = finalSplitted[1];
            codeDelivery = finalSplitted[2];

            return (codeShip, codeDelivery);
        }

        #endregion

        #region CheckData + Send validation

        private void btnCheckChat_Click(object sender, EventArgs e)
        {
            PacsTcpClient clientTCP = new PacsTcpClient();

            status = true;
            CheckThreadStatus();

            int stage = 1;
            string result;

            if (CheckDeliveryData())
            {
                result = "VP";
            }
            else
            {
                result = "AD";
            }

            validationMessage = "VR" + stage.ToString() + RefVariables.ShipName + result;

            if (clientTCP.MakePing(RefVariables.ShipIp))
            {
                clientTCP.SendMessage(RefVariables.ShipIp, RefVariables.ShipMessagePort, validationMessage);
            }
        }

        private bool CheckDeliveryData()
        {
            dts = new DataSet();

            dts = _Dades.PortarPerConsulta("select * from DeliveryData where idPlanet =" + RefVariables.PlanetId +
                " and idSpaceShip =" + RefVariables.ShipId +
                " and CodeDelivery ='" + RefVariables.DeliveryCode +
                "' and DeliveryDate = '2022-05-04'"
                );

            if (dts.Tables[0].Rows.Count == 1)
            {
                return true;
            }

            return false;
        }

        #endregion
    }
}
