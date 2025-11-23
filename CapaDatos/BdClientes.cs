using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaDatos
{
    public class BdClientes
    {
        BdConexionSQL BdConexion;
        public string ApellidoCliente(int idusuario)
        {
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_SL_ApellidoUsuarios", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdUsuario", idusuario);
                        cmd.Parameters.AddWithValue("@TipoUsuario", 'C');

                        SqlParameter resultadoParam = new SqlParameter("@Apellido", SqlDbType.VarChar) { Direction = ParameterDirection.Output };

                        cmd.Parameters.Add(resultadoParam);

                        cmd.ExecuteNonQuery();

                        return resultadoParam.Value.ToString();
                    }
                }
            }
            catch
            {
                return "";
            }
        }
    }
}
