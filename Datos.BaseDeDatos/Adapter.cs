using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adapter
    {
        //private SqlConnection sqlConn = new SqlConnection("ConnectionString;");

        private SqlConnection sqlConn;

        //Clave por defecto a utlizar para la cadena de conexion

        const string consKeyDefaultCnnString = "ConnStringLocal";

        public SqlConnection SqlConn
        {
            get
            {
                return sqlConn;
            }

            set
            {
                sqlConn = value;
            }
        }

        protected void OpenConnection()
        {
            string connString = ConfigurationManager.ConnectionStrings[consKeyDefaultCnnString].ConnectionString;
            sqlConn = new SqlConnection(connString);
            sqlConn.Open();
            //throw new Exception("Error al conectar a base de datos");
        }

        protected void CloseConnection()
        {
            sqlConn.Close();
            sqlConn = null;
            //throw new Exception("Metodo no implementado");
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
