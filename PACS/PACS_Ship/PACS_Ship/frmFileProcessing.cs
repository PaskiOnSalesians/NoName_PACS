using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using FormBase;
using GlobalVariables;
using AccesDades;
using System.Net.Sockets;
using System.Net;
using TCP;


namespace PACS_Ship
{
    public partial class frmFileProcessing : frmBase
    {
        public frmFileProcessing()
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
            //OpenForm(1);
        }

        private void btnConnectPlanet_Click(object sender, EventArgs e)
        {
            OpenForm(2);
        }

        private void btnEncryptCodes_Click(object sender, EventArgs e)
        {
            OpenForm(3);
        }

        private void btnFileProcessing_Click(object sender, EventArgs e)
        {
            //OpenForm(4);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            OpenForm(5);
        }

        #endregion

        string basePath = Application.StartupPath + "/../Resources/PACS";
        Dades db;
        PacsTcpServer tcpServer = new PacsTcpServer();
        string zipPath;


        // SpaceShip threads
        Thread unzipPacsFiles;
        Thread decodePacsFiles;
        Thread listenFiles;
        Thread listenValidation;

        // Dictionary for letter-number values
        Dictionary<string, string> innerEncryptionPairs;

        private void frmFileProcessing_Load(object sender, EventArgs e)
        {
            db = new Dades();

            pboxPlanet.Image = Image.FromFile(RefVariables.PlanetImage);
            pboxShip.Image = Image.FromFile(RefVariables.ShipImage);
            lblDelivery.Text = RefVariables.DeliveryCode;

            Control.CheckForIllegalCrossThreadCalls = false;

            btnDecode.Enabled = false;


            LoadEncryptions();
            zipPath = this.basePath + "/PACS.zip";

            listenFiles = new Thread(ReceiveTCP);
            listenFiles.Start();
        }



        private void btnDecompress_Click(object sender, EventArgs e)
        {
            listenFiles.Abort();
            unzipPacsFiles = new Thread(UnzipFile);
            unzipPacsFiles.Start();

        }

        private void UnzipFile()
        {
            
            string extractPath = this.basePath + "/SPACESHIP/encoded_files";

            // Clean directory
            string[] files = Directory.GetFiles(extractPath);
            foreach (var item in files)
            {
                File.Delete(item);
            }

            ZipFile.ExtractToDirectory(zipPath, extractPath);

            rtxtData.Text = "Files unzipped\n";
            btnDecode.Enabled = true;
            btnDecompress.Enabled = false;
        }

        private string DecodeFileContent(string filePath)
        {
            string fileContent = File.ReadAllText(filePath).Trim();
            string decodedContent = "";
            string number, letter;


            for (int i = 0; i < fileContent.Length; i += 3)
            {
                number = fileContent.Substring(i, 3);
                letter = innerEncryptionPairs.FirstOrDefault(encryption => encryption.Value == number).Key;
                decodedContent += letter;
            }

            return decodedContent;

        }

        private void DecodePacsFiles()
        {
            unzipPacsFiles.Join();

            rtxtData.Text += "... Decoding PACS files ...\n";
            string baseDirPath = this.basePath + "/SPACESHIP";
            string[] files = Directory.GetFiles(baseDirPath + "/encoded_files", "*.txt");
            Array.Sort(files);
            string letters = "";

            foreach (var item in files)
            {
                letters += DecodeFileContent(item);
            }

            File.WriteAllText(baseDirPath + "/PACSSOL.txt", letters);
            rtxtData.Text += "PACS files decoded into \"PACSSOL.txt\"!\n";
            btnDecompress.Enabled = false;
            SendTCP(baseDirPath + "/PACSSOL.txt", RefVariables.PlanetIp, RefVariables.PlanetFilePort);
            
        }

        private void ListenValidation()
        {
            
            tcpServer.StartServer(RefVariables.ShipIp, RefVariables.ShipMessagePort);
            tcpServer.ReceivePing();
            rtxtData.Text += tcpServer.GetClientMessages();
           
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {

            decodePacsFiles = new Thread(DecodePacsFiles);
            decodePacsFiles.Start();

            listenValidation = new Thread(ListenValidation);
            listenValidation.Start();

        }

        private void LoadEncryptions()
        {
            innerEncryptionPairs = new Dictionary<string, string>();
            int idInnerEncryption = GetIdInnerEncryption();
            var dts = db.PortarPerConsulta("SELECT word, numbers FROM InnerEncryptionData where idInnerEncryption = " + idInnerEncryption);
            var result = dts.Tables[0].Rows;
            if (result.Count > 0)
            {
                foreach (DataRow item in result)
                {
                    innerEncryptionPairs.Add(item["word"].ToString(), item["numbers"].ToString());
                }
            }



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

        public void ReceiveTCP()
        {
            TcpListener Listener = null;
            int BufferSize = 1024;
            string zipPath = this.basePath + "/PACS.zip";

            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }

            try
            {
                Listener = new TcpListener(IPAddress.Parse(RefVariables.ShipIp), RefVariables.ShipFilePort);
                Listener.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            byte[] RecData = new byte[BufferSize];
            int RecBytes;

            for (; ; )
            {
                TcpClient client = null;
                NetworkStream netstream = null;
      

                if (Listener.Pending())
                {
                    client = Listener.AcceptTcpClient();
                    netstream = client.GetStream();
                    rtxtData.Text += "Files received successfully";
                   
                    int totalrecbytes = 0;
                    FileStream Fs = new FileStream(zipPath, FileMode.OpenOrCreate, FileAccess.Write);
                    while ((RecBytes = netstream.Read(RecData, 0, RecData.Length)) > 0)
                    {
                        Fs.Write(RecData, 0, RecBytes);
                        totalrecbytes += RecBytes;
                    }
                    Fs.Close();

                    netstream.Close();
                    client.Close();
                }

            }
        }
        public void SendTCP(string resourcePath, string ip, int port)
        {
            byte[] SendingBuffer = null;
            TcpClient client = null;

            int BufferSize = 1024;
            NetworkStream netstream = null;
            try
            {
                client = new TcpClient(ip, port);
                rtxtData.Text += "Connected to the Server...\n";
                netstream = client.GetStream();
                FileStream Fs = new FileStream(resourcePath, FileMode.Open, FileAccess.Read);
                int NoOfPackets = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(Fs.Length) / Convert.ToDouble(BufferSize)));
                int TotalLength = (int)Fs.Length, CurrentPacketLength, counter = 0;
                for (int i = 0; i < NoOfPackets; i++)
                {
                    if (TotalLength > BufferSize)
                    {
                        CurrentPacketLength = BufferSize;
                        TotalLength = TotalLength - CurrentPacketLength;
                    }
                    else
                    CurrentPacketLength = TotalLength;
                    SendingBuffer = new byte[CurrentPacketLength];
                    Fs.Read(SendingBuffer, 0, CurrentPacketLength);
                    netstream.Write(SendingBuffer, 0, (int)SendingBuffer.Length);

                }
                rtxtData.Text += "File sended";


                Fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                netstream.Close();
                client.Close();

            }
        }

 
        private void frmFileProcessing_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (unzipPacsFiles != null)
            {
                unzipPacsFiles.Abort();
            }

            if (decodePacsFiles != null)
            {
                decodePacsFiles.Abort();
            }

            if (listenFiles != null)
            {
                listenFiles.Abort();
            }
        }
    }
}
