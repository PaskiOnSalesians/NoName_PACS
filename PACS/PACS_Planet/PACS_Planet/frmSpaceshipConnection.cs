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

        string validationMessage, remoteIP;

        bool status = false;

        public frmSpaceshipConnection()
        {
            InitializeComponent();
        }

        #region Carregador de Formularis

        private void OpenForm(int num)
        {
            switch (num)
            {
                case 0:
                    frmSelectPlanet frmPlanet = new frmSelectPlanet();
                    frmPlanet.Show();
                    break;
                case 1:
                    frmSpaceshipConnection frmConnection = new frmSpaceshipConnection();
                    frmConnection.Show();
                    break;
                case 2:
                    frmEncryptCodes frmCodes = new frmEncryptCodes();
                    frmCodes.Show();
                    break;
                case 3:
                    frmFileProcessing frmFiles = new frmFileProcessing();
                    frmFiles.Show();
                    break;
                case 4:
                    frmEnd frmEnd = new frmEnd();
                    frmEnd.Show();
                    break;
            }

            this.Hide();
        }

        private void btnSelectPlanet_Click(object sender, EventArgs e)
        {
            OpenForm(0);
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
            LoadPlanetData();

            // Dades inicials Nau
            LoadShipInitialData();

            btnConnect.Enabled = false;

            server = new Thread(ServerListen);
            server.Start();

            btnSelectPlanet.BackColor = Color.DarkGreen;
            btnSelectPlanet.ForeColor = Color.White;
            btnEncryptCodes.ForeColor = Color.White;
            btnFileProcessing.ForeColor = Color.White;
            btnEnd.ForeColor = Color.White;
        }

        private void LoadPlanetData()
        {
            lblPlanetName.Text = RefVariables.PlanetName;
            lblPlanetIP.Text = RefVariables.PlanetIp;
            lblPlanetMessagePort.Text = RefVariables.PlanetMessagePort.ToString();
            pboxPlanet.Image = Image.FromFile(RefVariables.PlanetImage);
        }

        private void LoadShipInitialData()
        {
            lblShipName.Text = "???";
            lblShipIP.Text = "???";
            lblShipMessagePort.Text = "???";
            pboxShip.Image = Image.FromFile(Application.StartupPath + "\\..\\Resources\\images\\Ships\\shipUnknown.png");
        }

        private void ServerListen()
        {
            serverTCP.StartServer(RefVariables.PlanetIp, RefVariables.PlanetMessagePort);
            remoteIP = serverTCP.ReceivePing();
            if(remoteIP != null || remoteIP != "")
            {
                btnConnect.Enabled = true;
            }
            rtxtData.Text += serverTCP.GetClientMessages();
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

        private void frmSpaceshipConnection_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Abort();
        }

        #endregion

        #region Load Ship Info + Defragment Code

        private void LoadShipInfo(string ip)
        {
            int pos;
            string cShip, delivery;
            dts = new DataSet();

            (cShip, delivery) = DefragmentCode();

            // Obtenir dades de la nau
            dts = _Dades.PortarPerConsulta("select * from SpaceShips where SpaceshipImage is not null and CodeSpaceShip = '" + cShip + "'", "SpaceShips");

            RefVariables.ShipName = cShip;
            RefVariables.ShipMessagePort = int.Parse(dts.Tables[0].Rows[0]["PortSpaceShip"].ToString());
            RefVariables.ShipImage = Application.StartupPath + "\\..\\Resources\\images\\Ships\\" + dts.Tables[0].Rows[0]["SpaceshipImage"].ToString();
            RefVariables.ShipId = int.Parse(dts.Tables[0].Rows[0]["idSpaceShip"].ToString());
            RefVariables.ShipFilePort = int.Parse(dts.Tables[0].Rows[0]["PortSpaceShip1"].ToString());

            RefVariables.DeliveryCode = delivery;

            // Afegir la nau a les etiquetes
            pos = ip.IndexOf(":");

            lblShipIP.Text = ip.Substring(0, pos);

            RefVariables.ShipIp = lblShipIP.Text;

            lblShipName.Text = cShip;
            lblShipMessagePort.Text = RefVariables.ShipMessagePort.ToString();
            pboxShip.Image = Image.FromFile(RefVariables.ShipImage);

            connectedPanelsColor();
        }

        private void connectedPanelsColor()
        {
            pnlConn1.BackColor = Color.Green;
            pnlConn2.BackColor = Color.Green;
            pnlConn3.BackColor = Color.Green;
            pnlConn4.BackColor = Color.Green;
            pnlConn5.BackColor = Color.Green;
        }

        private (string, string) DefragmentCode()
        {
            string[] finalSplitted;
            string codeShip, codeDelivery, text;

            text = rtxtData.Text;

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

        #region Send Validation + Checks

        private void btnConnect_Click(object sender, EventArgs e)
        {
            PacsTcpClient clientTCP = new PacsTcpClient();

            status = true;
            CheckThreadStatus();

            int stage = 1;
            string result;

            if (CheckDeliveryData())
            {
                result = "VP";
                btnEncryptCodes.Enabled = true;
                GlobalVariables.RefVariables.CanEnter = true;
            }
            else
            {
                result = "AD";

                GlobalVariables.RefVariables.CanEnter = false;
                btnSpaceshipConnection.Enabled = false;
                btnEncryptCodes.Enabled = false;
                btnFileProcessing.Enabled = false;
                btnEnd.Enabled = true;

                btnSpaceshipConnection.BackColor = Color.Red;
                btnEncryptCodes.BackColor = Color.Red;
                btnFileProcessing.BackColor = Color.Red;

            }

            validationMessage = "VR" + stage.ToString() + RefVariables.ShipName + result;

            rtxtData.Text += "------ VALIDATION RESULT ------\n" + validationMessage;

            if (clientTCP.MakePing(RefVariables.ShipIp))
            {
                clientTCP.SendMessage(RefVariables.ShipIp, RefVariables.ShipMessagePort, validationMessage);
            }

            
            btnConnect.Enabled = false;
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
