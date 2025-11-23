using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class BdEmpleados
    {
        BdConexionSQL BdConexion;
        public (bool, int) IniciarSesion(string identificador, string contrasena)
        {
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_SL_ACCESO", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Identificacion", identificador);
                        cmd.Parameters.AddWithValue("@Contrasena", contrasena);

                        SqlParameter resultadoParam = new SqlParameter("@Resultado", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                        SqlParameter idusuario = new SqlParameter("@IdUsuario", SqlDbType.Int) { Direction = ParameterDirection.Output };

                        cmd.Parameters.Add(resultadoParam);
                        cmd.Parameters.Add(idusuario);

                        cmd.ExecuteNonQuery();

                        return (Convert.ToBoolean(resultadoParam.Value), int.Parse(idusuario.Value.ToString()));
                    }
                }
            }
            catch
            {
                return (false, 0);
            }
        }

        public string ApellidoEmpleado (int idusuario)
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
                        cmd.Parameters.AddWithValue("@TipoUsuario", 'E');

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
