using AccesDades;
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

namespace PACSProject
{
    public partial class frmPlanet : Form
    {
        Dades dades = new Dades();
        DataSet dts;
        int planetID;


        public frmPlanet()
        {
            InitializeComponent();
        }

        private void lblExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SecondForm_Load(object sender, EventArgs e)
        {
            // Load Planets

            string query, nomtaula;

            nomtaula = "Planets";
            query = "Select * from " + nomtaula;

            dades.ConnectDB();
            dts = dades.PortarPerConsulta(query, nomtaula);

            for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
                lsxPlanets.Items.Add(dts.Tables[0].Rows[i]["DescPlanet"].ToString());
        }

        private void lsxPlanets_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query, nomtaula;

            lblPlanet.Text = "Planet: " + lsxPlanets.Text;

            nomtaula = "Planets";
            query = "Select * from " + nomtaula + " where DescPlanet = " + "'" + lsxPlanets.Text + "'";

            dades.ConnectDB();
            dts = dades.PortarPerConsulta(query, nomtaula);

            planetID = Int32.Parse(dts.Tables[0].Rows[0]["idPlanet"].ToString());
        }

        private void btnEncriptar_Click(object sender, EventArgs e)
        {
            // Codi Validacio
            string query, nomtaula;
            string clau, insert;

            clau = GenerarClauValidacio(12);

            // Update a la BBDD, li crea una clau de Validacio
            nomtaula = "InnerEncryption";
            query = "Select * from " + nomtaula + " where idPlanet = " + planetID;
            dts = dades.PortarPerConsulta(query, nomtaula);

            if (dts.Tables[0].Rows.Count <= 0)
            {
                insert = "INSERT INTO InnerEncryption VALUES(" + planetID + "," + "'" + clau + "'" + "); ";
            }
            else
            {
                insert = "UPDATE InnerEncryption SET ValidationCode = " + "'" + clau + "'" + " WHERE idPlanet = " + planetID + ";";
            }
            dades.Executar(insert);

            MessageBox.Show("Generated Key: " + clau.Substring(0, 4) + " for planet " + lsxPlanets.Text);

            //XML
            String queryCodePlanet;
            queryCodePlanet = "Select * from Planets where idPlanet = " + planetID;
            dts = dades.PortarPerConsulta(queryCodePlanet, "Planets");
            CspParameters cspp = new CspParameters();

            for (int i = 0; i < dts.Tables[0].Rows.Count; i++)
                cspp.KeyContainerName = dts.Tables[0].Rows[i]["CodePlanet"].ToString(); // KeyContainer name = clau

            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspp);
            rsa.PersistKeyInCsp = true;

            //Salvem la info de les claus en un XML.

            string publicKey = rsa.ToXmlString(false);
            string privateKey = rsa.ToXmlString(true);


            nomtaula = "PlanetKeys";
            query = "Select * from " + nomtaula + " where idPlanet = " + planetID;
            dts = dades.PortarPerConsulta(query, nomtaula);

            if (dts.Tables[0].Rows.Count <= 0)
            {
                insert = "INSERT INTO PlanetKeys VALUES(" + planetID + "," + "'" + publicKey + "'" + "); ";
            }
            else
            {
                insert = "UPDATE PlanetKeys SET XMLKey = " + "'" + publicKey + "'" + " WHERE idPlanet = " + planetID + ";";
            }
            dades.Executar(insert);
        }

        public static string GenerarClauValidacio(int size)
        {
            char[] chars =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[size];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetBytes(data);
            }
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
    }
}
