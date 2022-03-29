using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AccesDades
{
    public class DadesDB
    {
        private string query;
        DataSet dts;
        SqlConnection conn;
        string nomConnexio;
        string StringConnexio;


        //Constructor de la classe que s'executa en tots el mètodes per tal de no repetir Connectar()
        public DadesDB(string nomConnexio)
        {
            this.nomConnexio = nomConnexio;
        }

        public void Connectar()
        {
            ConnectionStringSettings conf = ConfigurationManager.ConnectionStrings[nomConnexio];
            StringConnexio = conf.ToString();
            conn = new SqlConnection(StringConnexio);
        }


        //Mètode per fer obrir el DataSet i fer el Select de la taula
        public DataSet PortarTaula(string NomTaula)
        {

            Connectar();
            SqlDataAdapter adapter;
            query = "select * from " + NomTaula;
            adapter = new SqlDataAdapter(query, conn);
            dts = new DataSet();
            conn.Open();
            adapter.Fill(dts, "Taula");
            conn.Close();

            return dts;
        }

        //Mètode que rebra la query (consulta) i retornarà un DataSet, aquesta es farà servir per si volem fer Joins
        public DataSet PortarPerConsulta(string query)
        {

            Connectar();
            SqlDataAdapter adapter;
            adapter = new SqlDataAdapter(query, conn);
            dts = new DataSet();
            conn.Open();
            adapter.Fill(dts, "Taula");
            conn.Close();

            return dts;
        }

        //Mètode sobrecarregat que rebra la query (consulta) i el nom de la DataTable que retornarà un DataSet, aquesta es farà servir per si volem fer Joins
        public DataSet PortarPerConsulta(string query, string nomDataTable)
        {

            Connectar();
            SqlDataAdapter adapter;
            dts = new DataSet();
            adapter = new SqlDataAdapter(query, conn);
            conn.Open();
            adapter.Fill(dts, nomDataTable);
            conn.Close();

            return dts;
        }

        //Mètode que compara si hi ha canvis i veurà si ha de fer Updates, Deletes o Inserts
        // afegir query y dataset
        public string Actualitzar()
        {
            string numCanvis;
            Connectar();
            conn.Open();
            SqlDataAdapter adapter;
            adapter = new SqlDataAdapter(query, conn);
            SqlCommandBuilder cmdBuilder;
            cmdBuilder = new SqlCommandBuilder(adapter);


            if (dts.HasChanges())
            {
                int resultat = adapter.Update(dts.Tables[0]);
                numCanvis = resultat.ToString();

            }
            else
            {
                numCanvis = "";
            }
            conn.Close();

            return numCanvis;
        }

        public void Executa(string query)
        {
            Connectar();
            conn.Open();

            SqlCommand cmd = new SqlCommand(query, conn);

            int registresAfectats = cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();
        }
    }
}
