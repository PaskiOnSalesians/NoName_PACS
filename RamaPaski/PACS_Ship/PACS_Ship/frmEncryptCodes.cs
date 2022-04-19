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
        }

        int idPlanet;
        Dades db;
        string code, publicKey;
        byte [] encryptedData;
        string encryptedCode;

        private void btnGetPublicKey_Click(object sender, EventArgs e)
        {
            this.code = GetValidationCode();
            this.publicKey = GetPublicKey();

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
            MessageBox.Show(encryptedCode);
            

        }

        private void btnSendKey_Click(object sender, EventArgs e)
        {
            PacsTcpClient tcpClient = new PacsTcpClient();
            if (tcpClient.MakePing(RefVariables.PlanetIp))
            {
                string result = tcpClient.SendMessage(RefVariables.PlanetIp, RefVariables.ShipMessagePort, encryptedCode);
                MessageBox.Show(result);
            }


            // Start listening for a response
            server = new Thread(ServerListen);
            server.Start();
        }

        private string EncryptValidationCode(string xmlKey, string validationCode)
        {
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte [] dataToEncrypt = ByteConverter.GetBytes(validationCode);

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(xmlKey);
                this.encryptedData = rsa.Encrypt(dataToEncrypt, false);
                return ByteConverter.GetString(encryptedData);
            }
        }

        PacsTcpServer serverTCP = new PacsTcpServer();
        Thread server;


        private void ServerListen()
        {
            serverTCP.StartServer(RefVariables.ShipIp, RefVariables.PlanetMessagePort);
            serverTCP.ReceivePing();
            rtxtData.Text += serverTCP.GetClientMessages();
            serverTCP.StopListening();

            ValidationResponse(rtxtData.Text);
        }

        private void frmEncryptCodes_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Abort();
        }

        private void ValidationResponse(string data)
        {
            var newData = data.Split('\n');
            string valor = newData[newData.Length - 2];

            if (valor.EndsWith("SI"))
            {
                MessageBox.Show("Nice!");
            }
        }
    }
}
