using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesDades;
using FormBase;
using GlobalVariables;
using TCP;

namespace PACS_Ship
{
    public partial class frmEncryptCodes : frmBase
    {
        int idPlanet;
        Dades db;
        string code, publicKey;
        byte[] encryptedCode;

        bool timeDownload = false, timeEncrypt = false, timeSend = false;

        public frmEncryptCodes()
        {
            InitializeComponent();
        }

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
            OpenForm(0);
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
            //OpenForm(3);
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

        private void frmEncryptCodes_Load(object sender, EventArgs e)
        {
            pboxPlanet.Image = Image.FromFile(RefVariables.PlanetImage);
            pboxShip.Image = Image.FromFile(RefVariables.ShipImage);
            lblDelivery.Text = RefVariables.DeliveryCode;

            idPlanet = RefVariables.PlanetId;
            db = new Dades();

            btnGetPublicKey.Enabled = false;

            server = new Thread(ServerListen);
            server.Start();
        }

        

        private void enableButtons()
        {
            if (timeEncrypt)
            {
                btnGetPublicKey.Enabled = false;
                btnEncrypt.Enabled = true;
            } else if (timeSend)
            {
                btnEncrypt.Enabled = false;
                btnSendKey.Enabled = true;
            }
        }

        private void btnGetPublicKey_Click(object sender, EventArgs e)
        {
            this.code = GetValidationCode();
            this.publicKey = GetPublicKey();
            rtxtData.Text +=
                "******** Started encryption methods ********\n" +
                "Getting public key...\n" +
                "Public key obtained!\n\n";
            timeEncrypt = true;
            enableButtons();
        }

        private string GetValidationCode()
        {
            string validationCode;
            string consulta = "SELECT ValidationCode FROM InnerEncryption WHERE idPlanet = " + this.idPlanet;
            DataSet resultat = db.PortarPerConsulta(consulta, "InnerEncryption");

            int consultaLong = resultat.Tables[0].Rows.Count;

            if (consultaLong > 0)
            {
                validationCode = resultat.Tables[0].Rows[consultaLong - 1]["ValidationCode"].ToString();
            }
            else
            {
                validationCode = "";
            }


            return validationCode;
        }

        private string GetPublicKey()
        {
            string validationCode;
            string consulta = "SELECT XmlKey FROM PlanetKeys WHERE idPlanet = " + this.idPlanet;
            DataSet resultat = db.PortarPerConsulta(consulta, "PlanetKeys");

            int consultaLong = resultat.Tables[0].Rows.Count;

            if (consultaLong > 0)
            {
                validationCode = resultat.Tables[0].Rows[consultaLong - 1]["XmlKey"].ToString();
            }
            else
            {
                validationCode = "";
            }


            return validationCode;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            this.encryptedCode = EncryptValidationCode(publicKey, code);
            string encryptedCode = Encoding.ASCII.GetString(this.encryptedCode);

            rtxtData.Text +=
                "--------- Encrypting Validation Code ---------\n" +
                "· Validation Code Encrypted: \n" + encryptedCode + "\n\n";
            timeEncrypt = false;
            timeSend = true;
            enableButtons();
        }

        private void btnSendKey_Click(object sender, EventArgs e)
        {
            if (timeSend)
            {
                PacsTcpClient tcpClient = new PacsTcpClient();
                if (tcpClient.MakePing(RefVariables.PlanetIp))
                {
                    tcpClient.SendMessage(RefVariables.PlanetIp, RefVariables.ShipMessagePort, this.encryptedCode);
                    rtxtData.Text += "Sending encrypted key...\nSended!";
                }


                // Start listening for a response
                server = new Thread(ServerListen);
                server.Start();

                btnSendKey.Enabled = false;
            }
        }

        private byte[] EncryptValidationCode(string xmlKey, string validationCode)
        {

            byte[] dataToEncrypt = Encoding.ASCII.GetBytes(validationCode);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(xmlKey);
                return rsa.Encrypt(dataToEncrypt, false);
            }
        }

        PacsTcpServer serverTCP = new PacsTcpServer();
        Thread server;


        private void ServerListen()
        {
            serverTCP.StartServer(RefVariables.ShipIp, RefVariables.ShipMessagePort);
            serverTCP.ReceivePing();
            rtxtData.Text += serverTCP.GetClientMessages();
            serverTCP.StopListening();

            ValidationResponse(rtxtData.Text);
            btnGetPublicKey.Enabled = true;
        }

        private void frmEncryptCodes_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Abort();
        }

        private void ValidationResponse(string data)
        {
            var newData = data.Split('\n');
            string valor = newData[newData.Length - 2];

            if (valor.EndsWith("VP"))
            {
                rtxtData.Text += "Validated\n";
            } else
            {
                rtxtData.Text += "Not validated\n";
            }
        }
    }
}
