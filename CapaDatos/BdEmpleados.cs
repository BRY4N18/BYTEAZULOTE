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

                        SqlParameter resultadoParam = new SqlParameter("@Apellido", SqlDbType.VarChar, 100) { Direction = ParameterDirection.Output };

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
        // Método Genérico para llenar cualquier ComboBox
        public DataTable ObtenerDatosMaestros(string nombreSP)
        {
            DataTable dt = new DataTable();
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(nombreSP, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                // ¡Agrega esto temporalmente para ver el error real!
                throw new Exception("Error cargando " + nombreSP + ": " + ex.Message);
            }
            return dt;
        }
        // --- MÉTODO 2: CON PARÁMETROS (Para Buscar/Editar) ---
        public DataTable ObtenerDatosMaestros(string nombreSP, List<SqlParameter> parametros)
        {
            DataTable dt = new DataTable();
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(nombreSP, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (parametros != null) foreach (var p in parametros) cmd.Parameters.Add(p);
                        new SqlDataAdapter(cmd).Fill(dt);
                    }
                }
            }
            catch { }
            return dt;
        }
        // Método auxiliar para buscar ID de Tipo Documento
        public int ObtenerIdTipoPorNombre(string nombreTipo)
        {
            int id = 0;
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_SL_ObtenerIdTipoIdentificacion", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NombreTipo", nombreTipo);

                        SqlParameter idParam = new SqlParameter("@IdTipo", SqlDbType.Int) { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(idParam);

                        cmd.ExecuteNonQuery();

                        if (idParam.Value != DBNull.Value)
                            id = Convert.ToInt32(idParam.Value);
                    }
                }
            }
            catch { id = 0; }
            return id;
        }

        // Método Principal de Insertar
        public (bool, string) RegistrarEmpleado(int idTipoId, int idCargo, int idGenero, int idEmpresa,
                                              string identificacion, string apellidos, string nombres,
                                              string telefono, string direccion, DateTime fechaNac,
                                              DateTime fechaContratacion, string correo)
        {
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_IN_RegistrarEmpleado", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdTipoIdentificacion", idTipoId);
                        cmd.Parameters.AddWithValue("@IdCargo", idCargo);
                        cmd.Parameters.AddWithValue("@IdGenero", idGenero);
                        cmd.Parameters.AddWithValue("@IdEmpresa", idEmpresa);
                        cmd.Parameters.AddWithValue("@Identificacion", identificacion);
                        cmd.Parameters.AddWithValue("@Apellidos", apellidos);
                        cmd.Parameters.AddWithValue("@Nombres", nombres);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);
                        cmd.Parameters.AddWithValue("@Direccion", direccion);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNac);
                        cmd.Parameters.AddWithValue("@FechaContratacion", fechaContratacion);
                        cmd.Parameters.AddWithValue("@Correo", correo);

                        SqlParameter resultadoParam = new SqlParameter("@Resultado", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                        SqlParameter mensajeParam = new SqlParameter("@Mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output };

                        cmd.Parameters.Add(resultadoParam);
                        cmd.Parameters.Add(mensajeParam);

                        cmd.ExecuteNonQuery();

                        return (Convert.ToBoolean(resultadoParam.Value), mensajeParam.Value.ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Error BD: " + ex.Message);
            }
        }
        // --- ACTUALIZAR ---
        public (bool, string) ActualizarEmpleado(int idEmpleado, int idCargo, int idGenero, int idEmpresa,
                                      string identificacion, string apellidos, string nombres,
                                      string telefono, string direccion, DateTime fechaNac,
                                      DateTime fechaContratacion, string correo, bool estado)
        {
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_UP_ActualizarEmpleado", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                        cmd.Parameters.AddWithValue("@IdCargo", idCargo);
                        cmd.Parameters.AddWithValue("@IdGenero", idGenero);
                        cmd.Parameters.AddWithValue("@IdEmpresa", idEmpresa);
                        cmd.Parameters.AddWithValue("@Identificacion", identificacion);
                        cmd.Parameters.AddWithValue("@Apellidos", apellidos);
                        cmd.Parameters.AddWithValue("@Nombres", nombres);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);
                        cmd.Parameters.AddWithValue("@Direccion", direccion);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNac);
                        cmd.Parameters.AddWithValue("@FechaContratacion", fechaContratacion);
                        cmd.Parameters.AddWithValue("@Correo", correo);
                        cmd.Parameters.AddWithValue("@Estado", estado); // Estado manual

                        SqlParameter res = new SqlParameter("@Resultado", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                        SqlParameter msj = new SqlParameter("@Mensaje", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(res); cmd.Parameters.Add(msj);

                        cmd.ExecuteNonQuery();
                        return (Convert.ToBoolean(res.Value), msj.Value.ToString());
                    }
                }
            }
            catch (Exception ex) { return (false, ex.Message); }
        }
    }
}
