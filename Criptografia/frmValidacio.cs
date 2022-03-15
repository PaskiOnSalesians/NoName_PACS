using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AccesDades;

namespace Criptografia
{
    public partial class frmValidacio : Form
    {
        string clauPlaneta = "KeyPlanet";
        string xmlPath = Application.StartupPath + "/plublicKey.xml";
        Criptografia crp;

        public frmValidacio()
        {
            InitializeComponent();
        }

        private string GetClauPublica(int idPlaneta)
        {
            DadesDB ad = new DadesDB();

            string consulta = "SELECT * FROM PlanetKeys WHERE idPlanet = " + idPlaneta;
            DataSet resultat = ad.PortarPerConsulta(consulta);

            if (resultat.Tables[0].Rows.Count > 0)
            {
                return (string)resultat.Tables[0].Rows[0]["XMLKey"];
            } else
            {
                return "";
            }
        }

        private void InsertarPlanetKey(int idPlanet, string clauPublica)
        {
            DadesDB ad = new DadesDB();
            string consulta = @"INSERT INTO PlanetKeys (idPlanet, XMLKey)
                                values(" + idPlanet + ", '" + clauPublica + "');";
            ad.Executa(consulta);
        }

        private void btnKeyPair_Click(object sender, EventArgs e)
        {
            string clauPublica = crp.GenerarParClaus();

            // Escriure publicKey al XML
            File.WriteAllText(xmlPath, clauPublica);

            // Insertar planetkey. Ex: id = 1
            int idPlanet = 1;
            InsertarPlanetKey(idPlanet, clauPublica);
        }

        private void btnPublicKey_Click(object sender, EventArgs e)
        {
            string publicKey = GetClauPublica(4);
            if (publicKey == "")
            {
                publicKey = "0 results found";
            }
            MessageBox.Show(publicKey);
        }

        private void frmValidacio_Load(object sender, EventArgs e)
        {
            this.crp = new Criptografia(this.clauPlaneta, this.xmlPath);
        }

        private void btnGenerarXifrat_Click(object sender, EventArgs e)
        {
            // Generar codi de 12 caracters (A - Z) | (a - z) | (0 - 9)
            string codi = crp.GetCodiValidacio(12);


            // Generar llistat amb par (lletra - numero)
            string lletres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            HashSet<string> numerosAleatoris = crp.GenerarNumerosRandom(lletres.Length);
            List<Xifrat> xifrats = new List<Xifrat>();

            for (int i = 0; i < lletres.Length; i++)
            {
                Xifrat x = new Xifrat
                {
                    lletra = lletres[i],
                    numero = numerosAleatoris.ElementAt(i)
                };

                xifrats.Add(x);
            }

            // Insertar valors a la BBDD

            int idPlanet = 1;
            DadesDB ad = new DadesDB();

            // InnerEncryption
            string consulta = @"INSERT INTO InnerEncryption (idPlanet, ValidationCode)
                                values(" + idPlanet + ", '" + codi + "');";
            ad.Executa(consulta);

            // InnerEncryptionData
            consulta = "SELECT MAX(idInnerEncryption) FROM InnerEncryption";
            DataSet resultat = ad.PortarPerConsulta(consulta);

            int idInnerEncryption;
            idInnerEncryption = int.Parse((string)resultat.Tables[0].Rows[0]["idInnerEncryption"]);

            foreach (Xifrat item in xifrats)
            {
                consulta = @"INSERT INTO InnerEncryptionData (idInnerEncryption, Word, Numbers)
                             values(" + idInnerEncryption + ", '" + item.lletra + "', '" + item.numero + "');";
                ad.Executa(consulta);
            }
        }
    }
}
