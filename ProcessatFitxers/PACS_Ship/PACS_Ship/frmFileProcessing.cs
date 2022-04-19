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

        string basePath = Application.StartupPath + "/PACS";

        // SpaceShip threads
        Thread unzipPacsFiles;
        Thread decodePacsFiles;

        // Dictionary for letter-number values
        Dictionary<string, string> innerEncryptionPairs;

        private void frmFileProcessing_Load(object sender, EventArgs e)
        {
            pboxPlanet.Image = Image.FromFile(RefVariables.PlanetImage);
            pboxShip.Image = Image.FromFile(RefVariables.ShipImage);
            lblDelivery.Text = RefVariables.DeliveryCode;

            Control.CheckForIllegalCrossThreadCalls = false;
           
            btnDecode.Enabled = false;
            btnSend.Enabled = false;
        }

        private void btnDecompress_Click(object sender, EventArgs e)
        {
            unzipPacsFiles = new Thread(UnzipFile);
            unzipPacsFiles.Start();
            
        }

        private void UnzipFile()
        {
            string zipPath = this.basePath + "/PACS.zip";
            string extractPath = this.basePath + "/SPACESHIP/encoded_files";

            // Clean directory
            string[] files = Directory.GetFiles(extractPath);
            foreach (var item in files)
            {
                File.Delete(item);
            }

            ZipFile.ExtractToDirectory(zipPath, extractPath);

            rtxtData.Text = "Files unzipped\n";
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
            //btnCompararLetras.Enabled = true;
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            decodePacsFiles = new Thread(DecodePacsFiles);
            decodePacsFiles.Start();
        }
    }
}
