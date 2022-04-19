using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using GlobalVariables;
using FormBase;
using TCP;
using System.Threading;
using System.Net.NetworkInformation;

namespace PACS_Ship
{
    public partial class frmConnectPlanet : frmBase
    {
        PacsTcpClient tcpClient = new PacsTcpClient();
        PacsTcpServer tcpServer = new PacsTcpServer();

        Thread WaitingVRMessage;

        bool networkStatus;
        bool accepted = false, completat = false;

        public frmConnectPlanet()
        {
            InitializeComponent();
        }

        #region Events

        private void frmConnectPlanet_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;

            LoadPlanetData();
            LoadShipData();
        }

        private void LoadShipData()
        {
            lblShipName.Text = RefVariables.ShipName;
            lblShipIP.Text = RefVariables.ShipIp;
            lblShipMessagePort.Text = RefVariables.ShipMessagePort.ToString();
            pboxShip.Image = Image.FromFile(RefVariables.ShipImage);
        }

        private void LoadPlanetData()
        {
            lblPlanetName.Text = RefVariables.PlanetName;
            lblPlanetIP.Text = RefVariables.PlanetIp;
            lblPlanetMessagePort.Text = RefVariables.PlanetMessagePort.ToString();
            pboxPlanet.Image = Image.FromFile(RefVariables.PlanetImage);
        }

        private void frmConnectPlanet_Activated(object sender, EventArgs e)
        {
            
        }

        private void frmConnectPlanet_FormClosing(object sender, FormClosingEventArgs e)
        {
            TancarFilListener();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            SendRequestMessage();
            EntryRequirementShip();
            WaitingVRMessagePlanet();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            frmEncryptCodes frmCodes = new frmEncryptCodes();
            frmCodes.Show();
            this.Hide();
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

        private void btnSelectShip_Click(object sender, EventArgs e)
        {
            OpenForm(0);
        }

        private void btnSelectPlanet_Click(object sender, EventArgs e)
        {
            OpenForm(1);
        }

        private void btnConnectPlanet_Click(object sender, EventArgs e)
        {
            //OpenForm(2);
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

        #region Demanar solicitud al planeta

        // Iniciar Servidor
        private void ServerListen()
        {
            tcpServer.StartServer(RefVariables.ShipIp, RefVariables.ShipMessagePort);
            tcpServer.ReceivePing();
            rtxData.Text += tcpServer.GetClientMessages();
            CheckVR(tcpServer.GetClientMessages());
            tcpServer.StopListening();
        }

        // Demanar peticio al planeta
        private void SendRequestMessage()
        {
            tcpClient.SendMessage(RefVariables.PlanetIp, RefVariables.PlanetMessagePort, SendRequestPlanet());
            accepted = true;
        }

        // Crear el missatge a enviar
        private string SendRequestPlanet()
        {
            string message = "";
            Ping myPing = new Ping();
            string ip_ping = RefVariables.PlanetIp;

            networkStatus = NetworkInterface.GetIsNetworkAvailable();

            message += "*********** ER - Entry Requirement ***********\n";
            message += "\nChecking for network availability...\n";

            if (networkStatus)
            {
                message += "System is connected to the network!\n\n";

                PingReply reply = myPing.Send(ip_ping, 1000);
                if (reply.Address != null)
                {
                    message += "-------------- Delivery Data --------------\n\n";
                    message += ("ER." + RefVariables.ShipName + "." + RefVariables.ShipName + "-" + RefVariables.PlanetCode + "\n\n");
                    NetworkConnectionPanel();
                }
                else
                {
                    message += "Response from " + ip_ping + ": Destination host inaccessible.\n";
                    NetworkConnectionPanel();
                }
            }
            else
            {
                message += "Inaccessible network.\n";
            }

            return message;
        }

        // Color de connexio
        private void NetworkConnectionPanel()
        {
            if (networkStatus)
            {
                pnlConn1.BackColor = Color.Green;
                pnlConn2.BackColor = Color.Green;
                pnlConn3.BackColor = Color.Green;
                pnlConn4.BackColor = Color.Green;
                pnlConn5.BackColor = Color.Green;
            }
            else
            {
                pnlConn1.BackColor = Color.Red;
                pnlConn2.BackColor = Color.Red;
                pnlConn3.BackColor = Color.Red;
                pnlConn4.BackColor = Color.Red;
                pnlConn5.BackColor = Color.Red;
            }
        }

        #endregion

        #region Imprimir dades al "xat"

        private string EntryRequirementShip()
        {
            string message = "";
            bool networkStatus;
            Ping myPing = new Ping();
            string ip_ping = RefVariables.PlanetIp;

            networkStatus = NetworkInterface.GetIsNetworkAvailable();

            rtxData.Clear();
            rtxData.AppendText("*********** ER - Entry Requirement ***********\n");

            rtxData.AppendText("\nCheck for network availability...\n");
            if (networkStatus)
            {
                rtxData.AppendText("System is connected to the network!\n\n");
                rtxData.AppendText("-------------- Remote device identificaton --------------\n\n");
                rtxData.AppendText("Sending ping to remote Host with ip: " + ip_ping + "\n");
                rtxData.AppendText("Ping " + ip_ping + "\n");

                PingReply reply = myPing.Send(ip_ping, 1000);
                if (reply.Address != null)

                {
                    rtxData.AppendText("Response from " + ip_ping + "\n\n");
                    rtxData.AppendText("-------------- Delivery Data --------------\n\n");

                    rtxData.AppendText("ER" + "." + RefVariables.ShipName + "." + RefVariables.ShipName + "-" + RefVariables.PlanetCode + "\n\n");

                    rtxData.AppendText("Waiting for the VR-Validation Result message of the TCP port.........\n");
                }
                else
                {
                    rtxData.AppendText("Response from " + ip_ping + ": Destination host inaccessible.\n");
                }
            }
            else
            {
                rtxData.AppendText("Inaccessible network.\n");
            }

            RefVariables.DeliveryCode = RefVariables.ShipName + "-" + RefVariables.PlanetCode;

            message += rtxData.Text;

            return message;
        }

        #endregion

        #region Comprobacions + Tancar Fils

        private void CheckVR(string message)
        {
            string code = message.Substring(message.Length - 3, 2);
            Console.Write(code);

            if (code.Equals("VP"))
            {
                btnNext.Enabled = true;
            }

            completat = true;
        }

        private void TancarFilListener()
        {
            if (WaitingVRMessage != null)
            {
                WaitingVRMessage.Abort();
            }
        }

        private void WaitingVRMessagePlanet()
        {
            if (accepted)
            {
                WaitingVRMessage = new Thread(ServerListen);
                WaitingVRMessage.Start();
            }
        }

        #endregion
    }
}
