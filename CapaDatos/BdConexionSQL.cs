using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    internal class BdConexionSQL
    {
        private string server, database, usuario, password, connectionString;
        public BdConexionSQL()
        {
            server = ".";
            database = "BYTEAZUL_REM";
            usuario = "sa";
            password = "12345";
        }

        public BdConexionSQL(string server, string database, string usuario, string password)
        {
            this.server = server;
            this.database = database;
            this.usuario = usuario;
            this.password = password;
        }

        public SqlConnection ObtenerConexion()
        {
            try
            {
                connectionString = "Server = " + server + "; Database = " + database + "; User id= " + usuario + "; Password = " + password;
                SqlConnection conexion = new SqlConnection(connectionString);
                return conexion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la conexión: " + ex.Message);
            }
        }
    }
}
