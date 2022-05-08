using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using FormBase;
using GlobalVariables;
using AccesDades;
using System.IO;
using TCP;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace PACS_Planet
{
    public partial class frmEncryptCodes : frmBase
    {
        Dades db;
        int idPlanet;
        string clauPlaneta = "KeyPlanet";
        string xmlPath = Application.StartupPath + "/../Resources/files/publicKey.xml";
        
        PacsTcpServer serverTCP = new PacsTcpServer();
        Thread server;

        bool status = false;
        string data = "";

        byte[] bytes = new byte[128];

        string code;
        string decodedText;

        class Xifrat
        {
            public string lletra;
            public string numero;
        }

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

        private void btnSpaceshipConnection_Click(object sender, EventArgs e)
        {
            OpenForm(1);
        }

        private void btnEncryptCodes_Click(object sender, EventArgs e)
        {
            //OpenForm(2);
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

        private void frmEncryptCodes_Load(object sender, EventArgs e)
        {
            btnDecrypt.Enabled = false;
            pboxPlanet.Image = Image.FromFile(RefVariables.PlanetImage);
            pboxShip.Image = Image.FromFile(RefVariables.ShipImage);
            lblDelivery.Text = RefVariables.DeliveryCode;

            idPlanet = RefVariables.PlanetId;
            db = new Dades();

            GenerateKeyPair();

            btnSelectPlanet.ForeColor = Color.White;
            btnSelectPlanet.BackColor = Color.DarkGreen;
            btnSpaceshipConnection.ForeColor = Color.White;
            btnSpaceshipConnection.BackColor = Color.DarkGreen;

            btnFileProcessing.ForeColor = Color.White;
            btnEnd.ForeColor = Color.White;
        }

        private void btnGenerateCode_Click(object sender, EventArgs e)
        {
            // Generar código de 12 chars, insertar en InnerEncryption)
            code = GenerarCodiValidacio();
            InsertarCodiValidacio(code);

            // Insertar codificación (letra-numero), donde el idInnerEncryption es el creado anteriormente
            int idInnerEnc = GetIdInnerEncryption();
            if (idInnerEnc != -1)
            {
                List<Xifrat> codificacioLletraNum = GenerarParsLletraNum();
                InsertarCodificacions(idInnerEnc, codificacioLletraNum);

                rtxtData.Text +=
                    "****** Generating Codes ******\n" +
                    "Codes generated correctly!\n\n";

                string codeGenerated = "------ Codes generated! ------\n";

                PacsTcpClient tcpClient = new PacsTcpClient();
                tcpClient.SendMessage(RefVariables.ShipIp, RefVariables.ShipMessagePort, codeGenerated);

                server = new Thread(ListenBytes);
                server.Start();

                btnGenerateCode.Enabled = false;
            }
        }

        private void GenerateKeyPair()
        {
            string clauPublica = GenerarParClaus();
            File.WriteAllText(xmlPath, clauPublica);
            InsertarPlanetKey(clauPublica);
        }

        private CspParameters CrearCsp()
        {
            CspParameters cspp = new CspParameters();
            cspp.KeyContainerName = clauPlaneta;
            return cspp;
        }

        private void InsertarPlanetKey(string clauPublica)
        {
            string consulta = @"INSERT INTO PlanetKeys (idPlanet, XMLKey)
                                values(" + this.idPlanet + ", '" + clauPublica + "');";
            db.Executar(consulta);
        }

        public string GenerarParClaus()
        {

            CspParameters cspp = CrearCsp();

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspp);
            string publicKey = rsa.ToXmlString(false);
            rsa.PersistKeyInCsp = true;
            rsa.Clear();

            return publicKey;
        }

        private string GenerarCodiValidacio()
        {
            // Generar codi de 12 caracters (A - Z) | (a - z) | (0 - 9)
            string valors = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            string codi = GetValorsAleatoris(12, valors);
            return codi;
        }

        private void InsertarCodiValidacio(string codi)
        {

            string consulta = @"INSERT INTO InnerEncryption (idPlanet, ValidationCode)
                                values(" + this.idPlanet + ", '" + codi + "');";
            db.Executar(consulta);
        }

        private List<Xifrat> GenerarParsLletraNum()
        {
            // Generar llistat amb par (lletra - numero)
            string lletres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            HashSet<string> numerosAleatoris = GenerarNumerosRandom(lletres.Length);
            List<Xifrat> xifrats = new List<Xifrat>();

            for (int i = 0; i < lletres.Length; i++)
            {
                Xifrat x = new Xifrat
                {
                    lletra = lletres[i].ToString(),
                    numero = numerosAleatoris.ElementAt(i)
                };

                xifrats.Add(x);
            }

            return xifrats;
        }

        private void InsertarCodificacions(int idInnerEncryption, List<Xifrat> xifrats)
        {
            string consulta = @"INSERT INTO InnerEncryptionData (idInnerEncryption, Word, Numbers) VALUES";

            for (int i = 0; i < xifrats.Count; i++)
            {
                consulta += "(" + idInnerEncryption + ", '" + xifrats[i].lletra + "', '" + xifrats[i].numero + "')";
                if (i < xifrats.Count - 1)
                {
                    consulta += ",";
                }
            }

            this.db.Executar(consulta);
        }

        private int GetIdInnerEncryption()
        {
            int idInnerEncryption;
            string consulta = "SELECT MAX(idInnerEncryption) idInnerEncryption  FROM InnerEncryption";
            DataSet resultat = db.PortarPerConsulta(consulta, "InnerEncryption");

            if (resultat.Tables[0].Rows.Count > 0)
            {
                idInnerEncryption = int.Parse(resultat.Tables[0].Rows[0]["idInnerEncryption"].ToString());
            }
            else
            {
                idInnerEncryption = -1;
            }


            return idInnerEncryption;
        }

        public string GetValorsAleatoris(int numCaracters, string valors)
        {
            string codi = "";
            int indexValors;
            for (int i = 0; i < numCaracters; i++)
            {
                indexValors = GetNumeroAleatori(valors.Length);
                codi += valors[indexValors];
            }

            return codi;
        }

        public int GetNumeroAleatori(int valorMaxim)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] data = new byte[8];

            provider.GetBytes(data);
            var value = BitConverter.ToUInt32(data, 0);
            int rNumber = (int)(value % valorMaxim);

            return rNumber;
        }

        public HashSet<string> GenerarNumerosRandom(int numXifres)
        {
            HashSet<string> numeros = new HashSet<string>();
            int numeroAleatori;
            string numeroAmbZeros;

            while (numeros.Count < numXifres)
            {
                numeroAleatori = GetNumeroAleatori(999);
                numeroAmbZeros = numeroAleatori.ToString().PadLeft(3, '0');
                numeros.Add(numeroAmbZeros);
            }

            return numeros;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            CspParameters cspp = new CspParameters();

            string keyName = clauPlaneta;
            cspp.KeyContainerName = keyName;
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspp);
            var decryptedData = rsa.Decrypt(this.bytes, false);
            decodedText = Encoding.ASCII.GetString(decryptedData);

            rtxtData.Text +=
                "-------- Decrypting key --------\n" +
                "Code decrypted: " + decodedText +  "\nPrepare for sending the Validation.\n\n";
            
            btnSendValidation.Enabled = true;
            btnDecrypt.Enabled = false;
        }

        private void frmEncryptCodes_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Abort();
        }

        private void btnSendValidation_Click(object sender, EventArgs e)
        {
            btnDecrypt.Enabled = false;
            rtxtData.Text += "Validating...\n";
            bool result = CheckValidationCode();
            string message = "VR" + RefVariables.ShipName;

            if (result)
            {
                message += "VP";
                rtxtData.Text += "SpaceShip correct!\n";
            }
            else
            {
                message += "AD";
                rtxtData.Text += "SpaceShip incorrect!\n";
            }

            PacsTcpClient tcpClient = new PacsTcpClient();
            tcpClient.SendMessage(RefVariables.ShipIp, RefVariables.ShipMessagePort, message);            

            btnFileProcessing.Enabled = true;
            btnSendValidation.Enabled = false;
        }

        private bool CheckValidationCode()
        {
            return this.code == this.decodedText;
        }

        private void ListenBytes()
        {
            bool estat = true;

            TcpListener server = null;
            try
            {
                IPAddress localAddr = IPAddress.Parse(RefVariables.PlanetIp);

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, RefVariables.ShipMessagePort);

                // Start listening for client requests.
                server.Start();

                // Enter the listening loop.
                while (estat)
                {

                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    NetworkStream stream = client.GetStream();

                    int i = stream.Read(bytes, 0, bytes.Length);
                    client.Close();

                    estat = false;
                    rtxtData.Text += "------- VALIDATION KEY -------\nVK\n\n";
                    btnDecrypt.Enabled = true;


                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                // Stop listening for new clients.
                server.Stop();
            }

        }
    }
}
