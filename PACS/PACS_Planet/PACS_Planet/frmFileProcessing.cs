using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesDades;

using FormBase;
using GlobalVariables;

namespace PACS_Planet
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
            OpenForm(2);
        }

        private void btnFileProcessing_Click(object sender, EventArgs e)
        {
            //OpenForm(3);
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            OpenForm(4);
        }

        #endregion

        string basePath = Application.StartupPath + "/../Resources/PACS";

        // Planet threads
        Thread createPacsFiles;
        Thread zipPacsFiles;
        Thread listenFiles;
        Thread checkFiles;
        Dades db = new Dades();

        // Dictionary for letter-number values
        Dictionary<string, string> innerEncryptionPairs;

        private void frmFileProcessing_Load(object sender, EventArgs e)
        {
            pboxPlanet.Image = Image.FromFile(RefVariables.PlanetImage);
            //pboxShip.Image = Image.FromFile(Application.StartupPath + RefVariables.ShipImage);
            lblDelivery.Text = RefVariables.DeliveryCode;

            Control.CheckForIllegalCrossThreadCalls = false;

            btnCheck.Enabled = false;

            LoadEncryptions();
        }

        private string GetRandomLetters()
        {
            int LETTERS_NUMBER = 100_000;
            string LETTERS_USED = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string content = GetValorsAleatoris(LETTERS_NUMBER, LETTERS_USED);
            return content;
        }

        private void CreateLettersFile(string path)
        {
            string content = GetRandomLetters();
            File.WriteAllText(path, content);
        }

        private void CreateEncodedPacsFile(string lettersFilePath, string newEncodedFilesPath)
        {
            string content = File.ReadAllText(lettersFilePath).Trim();
            string encodedContent = "";

            foreach (var item in content)
            {
                encodedContent += innerEncryptionPairs[item.ToString()];
            }

            File.WriteAllText(newEncodedFilesPath, encodedContent);
        }

        // methods extracted from Criptografia class
        private string GetValorsAleatoris(int numCaracters, string valors)
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

        private int GetNumeroAleatori(int valorMaxim)
        {
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            byte[] data = new byte[8];

            provider.GetBytes(data);
            var value = BitConverter.ToUInt32(data, 0);
            int rNumber = (int)(value % valorMaxim);

            return rNumber;
        }

        private void btnCompress_Click(object sender, EventArgs e)
        {
            // Create PACS files PACS1.txt, PACS2.txt, PACS3.txt
            createPacsFiles = new Thread(CreatePacsFiles);

            string zipPath = this.basePath + "/PACS.zip";
            string filesPath = this.basePath + "/PLANET/encoded_files";
            string[] files = Directory.GetFiles(filesPath, "*.txt");

            // zip all 3 files into PACS.zip
            zipPacsFiles = new Thread(() => CreateZipFile(zipPath, files));

            createPacsFiles.Start(3);
            zipPacsFiles.Start();

            listenFiles = new Thread(ReceiveTCP);
            listenFiles.Start();
        }

        private void CreatePacsFiles(object numberOfFiles)
        {
            string folderPath = this.basePath + "/PLANET";
            rtxtData.Text = "... Creating PACS files ...\n";

            Parallel.For(1, (int)numberOfFiles + 1,
            index =>
            {

                string lettersFilePath = folderPath + "/letters_files/letters" + index.ToString() + ".txt";
                CreateLettersFile(lettersFilePath);

                string encodedFilesPath = folderPath + "/encoded_files/PACS" + index.ToString() + ".txt";
                CreateEncodedPacsFile(lettersFilePath, encodedFilesPath);


            });

            rtxtData.Text += "PACS files created!\n";
        }

        // Method prob from FileHandling class
        private void CreateZipFile(string zipPath, string[] files)
        {
            createPacsFiles.Join();

            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }

            rtxtData.Text += "... Creating ZIP file ...\n";
            using (var archive = ZipFile.Open(zipPath, ZipArchiveMode.Create))
            {
                string filename;
                foreach (var item in files)
                {
                    filename = Path.GetFileName(item);
                    archive.CreateEntryFromFile(item, filename);
                }

            }
            rtxtData.Text += "ZIP file created!\n";
            btnCheck.Enabled = true;
            btnCompress.Enabled = false;
            SendTCP(zipPath, RefVariables.ShipIp, RefVariables.ShipFilePort);
        }

        private string ConcatLettersFiles(string folderPath)
        {
            string content = "";
            string[] files = Directory.GetFiles(folderPath, "*.txt");
            Array.Sort(files);

            foreach (string file in files)
            {
                content += File.ReadAllText(file).Trim();
            }

            return content;
        }

        private void CheckFilesValues()
        {
            
            string planetValues = ConcatLettersFiles(this.basePath + "/PLANET/letters_files");
            // This file will be received from the SpaceShip, and saved into a Planet directory
            string spaceShipValues = File.ReadAllText(this.basePath + "/SPACESHIP/PACSSOL.txt").Trim();

            bool result = planetValues == spaceShipValues;
            rtxtData.Text += "********** Checking content **********";
            rtxtData.Text += "\nEqual values: " + result.ToString();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            
            checkFiles = new Thread(CheckFilesValues);
            checkFiles.Start();
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
                rtxtData.Text += "File sended\n";


                Fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                netstream.Close();
                client.Close();

            }
        }
        public void ReceiveTCP()
        {
            TcpListener Listener = null;
            int BufferSize = 1024;
            string zipPath = this.basePath + "/SPACESHIP/PACSSOL.txt";

            if (File.Exists(zipPath))
            {
                File.Delete(zipPath);
            }

            try
            {
                Listener = new TcpListener(IPAddress.Parse(RefVariables.PlanetIp), RefVariables.PlanetFilePort);
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
                    rtxtData.Text += "\nFiles received successfully";

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


    }
}
