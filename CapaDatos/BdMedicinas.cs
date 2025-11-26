using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class BdMedicinas
    {
        BdConexionSQL BdConexion;
        public DataTable BuscarMedicina(string filtro)
        {
            DataTable dtVerMedicina = new DataTable();
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_SL_TbProductos_Listado", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@NombreProducto", filtro);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtVerMedicina);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener lista de medicina: " + ex.Message);
            }
            return dtVerMedicina;
        }

        public (bool, string) AgregarMedicina(string Producto, string Descripcion)
        {
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_IN_TbProductos", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Producto", Producto);
                        cmd.Parameters.AddWithValue("@Descripcion", Descripcion);
                        cmd.Parameters.AddWithValue("@CostoPromedio", 0);

                        SqlParameter resultadoParam = new SqlParameter("@Resultado", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                        SqlParameter mensajeParam = new SqlParameter("@MensajeRetorno", SqlDbType.VarChar, 500) { Direction = ParameterDirection.Output };

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
        public int ObtenerUltimoProductoId()
        {
            int ultimoId = 0;
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_SL_ObtenerIDdelUltimoProducto", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        object result = cmd.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            ultimoId = id;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el último ID de producto: " + ex.Message);
            }
            return ultimoId;
        }
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
    }
}
