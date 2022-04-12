using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Criptografia
{
    public class Criptografia
    {
        string clauPlaneta;
        string rutaXml;
        public Criptografia(string clauPlaneta, string rutaXml)
        {
            this.clauPlaneta = clauPlaneta;
            this.rutaXml = rutaXml;
        }

        private CspParameters CrearCsp()
        {
            CspParameters cspp = new CspParameters();
            cspp.KeyContainerName = this.clauPlaneta;
            return cspp;
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

        public string GetCodiValidacio(int numCaracters)
        {
            string valors = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
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
    }
}
