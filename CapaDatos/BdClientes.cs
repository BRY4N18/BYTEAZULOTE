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
        BdEmpleados utilitarios = new BdEmpleados();
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

                        SqlParameter resultadoParam = new SqlParameter("@Apellido", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };

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
        //MÉTODO GENÉRICO (Reutilizamos el de empleados para Combos y Búsquedas)
        public DataTable ObtenerDatosMaestros(string nombreSP, List<SqlParameter> parametros = null)
        {
            return utilitarios.ObtenerDatosMaestros(nombreSP, parametros);
        }

        // REGISTRAR CLIENTE
        public (bool, string) RegistrarCliente(int idTipoId, int idGenero, string identificacion,
            string apellidos, string nombres, string telefono, string direccion,
            DateTime fechaNac, string correo)
        {
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_IN_AGREGAR_CLIENTE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdTipoIdentificacion", idTipoId);
                        cmd.Parameters.AddWithValue("@IdGenero", idGenero);
                        cmd.Parameters.AddWithValue("@Identificacion", identificacion);
                        cmd.Parameters.AddWithValue("@Apellidos", apellidos);
                        cmd.Parameters.AddWithValue("@Nombres", nombres);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);
                        cmd.Parameters.AddWithValue("@Direccion", direccion);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNac);
                        cmd.Parameters.AddWithValue("@FechaRegistro", DateTime.Now); // Automático
                        cmd.Parameters.AddWithValue("@Correo", correo);

                        SqlParameter res = new SqlParameter("@Resultados", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                        SqlParameter msj = new SqlParameter("@MensajeRetorno", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output }; // Tu SP dice 50 chars
                        cmd.Parameters.Add(res);
                        cmd.Parameters.Add(msj);

                        cmd.ExecuteNonQuery();
                        return (Convert.ToBoolean(res.Value), msj.Value.ToString());
                    }
                }
            }
            catch (Exception ex) { return (false, "Error: " + ex.Message); }
        }

        // ACTUALIZAR CLIENTE
        public (bool, string) ActualizarCliente(int idCliente, int idTipoId, int idGenero, string identificacion,
            string apellidos, string nombres, string telefono, string direccion,
            DateTime fechaNac, string correo)
        {
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_UP_ACTUALIZAR_CLIENTE", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                        cmd.Parameters.AddWithValue("@IdTipoIdentificacion", idTipoId);
                        cmd.Parameters.AddWithValue("@IdGenero", idGenero);
                        cmd.Parameters.AddWithValue("@Identificacion", identificacion);
                        cmd.Parameters.AddWithValue("@Apellidos", apellidos);
                        cmd.Parameters.AddWithValue("@Nombres", nombres);
                        cmd.Parameters.AddWithValue("@Telefono", telefono);
                        cmd.Parameters.AddWithValue("@Direccion", direccion);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", fechaNac);
                        cmd.Parameters.AddWithValue("@FechaRegistro", DateTime.Now); // Se actualiza o mantiene
                        cmd.Parameters.AddWithValue("@Correo", correo);

                        SqlParameter res = new SqlParameter("@Resultados", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                        SqlParameter msj = new SqlParameter("@MensajeRetorno", SqlDbType.VarChar, 250) { Direction = ParameterDirection.Output }; // Tu SP dice 250
                        cmd.Parameters.Add(res);
                        cmd.Parameters.Add(msj);

                        cmd.ExecuteNonQuery();
                        return (Convert.ToBoolean(res.Value), msj.Value.ToString());
                    }
                }
            }
            catch (Exception ex) { return (false, "Error: " + ex.Message); }
        }
        // Agregar al final de la clase BdClientes
        public DataTable BuscarClientes(string filtro)
        {
            var lista = new List<SqlParameter>();
            lista.Add(new SqlParameter("@Filtro", filtro));

            // Reutilizamos el método genérico que ya tienes
            return utilitarios.ObtenerDatosMaestros("SP_SL_BuscarClientes", lista);
        }
    }
}
