using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        string basePath = Application.StartupPath + "\\..\\Resources\\PACS";

        // Planet threads
        Thread createPacsFiles;
        Thread zipPacsFiles;

        // Dictionary for letter-number values
        Dictionary<string, string> innerEncryptionPairs;

        private void frmFileProcessing_Load(object sender, EventArgs e)
        {
            pboxPlanet.Image = Image.FromFile(RefVariables.PlanetImage);
            //pboxShip.Image = Image.FromFile(Application.StartupPath + "\\..\\Resources\\Ships\\" +  RefVariables.ShipImage);
            lblDelivery.Text = RefVariables.DeliveryCode;

            Control.CheckForIllegalCrossThreadCalls = false;

            btnSend.Enabled = false;
            btnCheck.Enabled = false;
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
        }

        private void CreatePacsFiles(object numberOfFiles)
        {
            string folderPath = this.basePath + "/PLANET";
            rtxtData.Text = "... Creating PACS files ...\n";

            Parallel.For(1, (int)numberOfFiles + 1,
            index => {

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
            //btnUnzipFiles.Enabled = true;
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
            rtxtData.Text = "Equal values: " + result.ToString();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            CheckFilesValues();
        }
    }
}
