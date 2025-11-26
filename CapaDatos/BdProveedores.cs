using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class BdProveedores
    {
        BdConexionSQL BdConexion;
        public DataTable B1uscarProveedores()
        {
            DataTable dtVerProveedores = new DataTable();
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_SL_TbProveedores_Buscar", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtVerProveedores);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener lista de proveedores: " + ex.Message);
            }
            return dtVerProveedores;
        }
        public DataTable BuscarProveedores(string filtro)
        {
            DataTable dtVerProveedores = new DataTable();
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_SL_TbProveedores_Buscar", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Filtro", filtro);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtVerProveedores);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener lista de proveedores: " + ex.Message);
            }
            return dtVerProveedores;
        }
        //---------------------------------------------------------------
        public (bool, string) RegistrarContactoEmergencia(string nombreContacto, int idRelacion, int idUsuario, string contacto, int idTipoContacto)
        {
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_IN_TbContactosEmergenciaTbContacto", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@NombreContacto", nombreContacto);
                        cmd.Parameters.AddWithValue("@IdRelacion", idRelacion);
                        cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);
                        cmd.Parameters.AddWithValue("@Contacto", contacto);
                        cmd.Parameters.AddWithValue("@IdTipoContacto", idTipoContacto);

                        SqlParameter resultadoParam = new SqlParameter("@Resultado", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                        SqlParameter mensajeretornoparam = new SqlParameter("@MensajeRetorno", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };

                        cmd.Parameters.Add(resultadoParam);
                        cmd.Parameters.Add(mensajeretornoparam);

                        cmd.ExecuteNonQuery();

                        return (Convert.ToBoolean(resultadoParam.Value), mensajeretornoparam.Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Error al registrar el contacto de emergencia: " + ex.Message);
            }
        }
        public (bool, string) RegistrarContacto(string contacto, int idtipocontacto)
        {
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_IN_TbContacto", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Contacto", contacto);
                        cmd.Parameters.AddWithValue("@IdTipoContacto", idtipocontacto);
                        SqlParameter resultadoParam = new SqlParameter("@Resultado", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                        SqlParameter mensajeretornoparam = new SqlParameter("@MensajeRetorno", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(resultadoParam);
                        cmd.Parameters.Add(mensajeretornoparam);
                        cmd.ExecuteNonQuery();
                        return (Convert.ToBoolean(resultadoParam.Value), mensajeretornoparam.Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Error al registrar el contacto: " + ex.Message);
            }
        }
    }
}
