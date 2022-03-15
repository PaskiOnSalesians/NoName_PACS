using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace AccesDades
{
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;

    using System.Configuration;
    using System.Windows.Forms;

    //using Microsoft.VisualBasic.CompilerServices;

    public class Dades
    {
        public SqlConnection con;
        public string conString;

        // Connectar a la Base de Dades
        #region Connectar
        public void ConnectDB()
        {
            conString = CadenaConnexio(); // Trae la cadena
            con = new SqlConnection(conString); // Nos genera la conexión
            con.Open(); // Obrim al connexió
            //con.InitializeLifetimeService();
        }
        #endregion

        // Obtenir la cadena de connexió de App.config
        #region Cadena Connexió
        private string CadenaConnexio()
        {
            string cadena = "";
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings["SecureCoreServer"];
            
            if(settings != null)
            {
                cadena = settings.ConnectionString.ToString();
            }

            return cadena;
        }
        #endregion

        // Portar la Taula de la Base de Dades
        #region PortaTaula
        public DataTable PortaTaula(string query)
        {
            DataTable taulaData = null;

            ConnectDB();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            SqlCommandBuilder sqlBuilder = new SqlCommandBuilder(adapter);

            taulaData = new DataTable();

            adapter.FillSchema(taulaData, SchemaType.Source);
            adapter.Fill(taulaData);

            if (con != null)
            {
                con.Close();
                con.Dispose();
            }

            return taulaData;
        }
        #endregion

        // Portar una consulta i retornar les Dades per DataSet
        #region PortarPerConsulta

        public DataSet PortarPerConsulta(string query)
        {
            ConnectDB();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
            DataSet dataSet = new DataSet();
            adapter.Fill(dataSet, "Taula");
            return dataSet;
        }

        public DataSet PortarPerConsulta(string query, string nomtaula)
        {
            ConnectDB();
            DataSet dataSet = new DataSet();
            new SqlDataAdapter(query, con).Fill(dataSet, nomtaula);
            return dataSet;
        }

        #endregion

        // Actualitzar la Base de Dades
        #region Actualitzar
        public void Actualitzar(string query, string taula, DataSet _dts)
        {
            int numReg;

            ConnectDB();
            SqlDataAdapter adapter = new SqlDataAdapter(query, con);
            SqlCommandBuilder sqlBuilder = new SqlCommandBuilder(adapter);

            if (_dts.HasChanges())
            {
                numReg = adapter.Update(_dts, taula);
                MessageBox.Show("Registres modificats: " + numReg.ToString());
            }

            if(con != null)
            {
                con.Close();
                con.Dispose();
            }
        }
        #endregion

        // Executar comandes
        #region Executa (INSERT + UPDATE + DELETE)
        public int Executar(string comanda)
        {
            this.ConnectDB();
            return new SqlCommand(comanda, this.con).ExecuteNonQuery();
        }
        #endregion
    }
}
