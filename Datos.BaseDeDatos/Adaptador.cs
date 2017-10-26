using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

namespace Data.Database
{
    public class Adaptador
    {

        private SqlConnection sqlCon;

        //Clave por defecto a utlizar para la cadena de conexion

        //const string claveConexionPorDefecto = "ConnStringLocal";
        const string claveConexionPorDefecto = "ConnStringExpress";

        public SqlConnection SqlCon
        {
            get
            {
                return sqlCon;
            }

            set
            {
                sqlCon = value;
            }
        }

        protected void AbrirConexion()
        {
            string cadenaConexion = ConfigurationManager.ConnectionStrings[claveConexionPorDefecto].ConnectionString;
            sqlCon = new SqlConnection(cadenaConexion);
            sqlCon.Open();
            //throw new Exception("Error al conectar a base de datos");
        }

        protected void CerrarConexion()
        {
            sqlCon.Close();
            sqlCon = null;
            //throw new Exception("Metodo no implementado");
        }

        protected SqlDataReader ExecuteReader(String commandText)
        {
            throw new Exception("Metodo no implementado");
        }
    }
}
