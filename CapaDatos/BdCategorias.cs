using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class BdCategorias
    {
        BdConexionSQL BdConexion;
        public DataTable ListarCategorias(string nombreSP, List<SqlParameter> parametros = null)
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
        public int ObtenerIdCategoria(string categoria)
        {
            int IdCat = 0;
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_SL_ObtenerIDdeCategoria", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@categoria", categoria);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            IdCat = Convert.ToInt32(reader["IdCategoria"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el ID de categoria: " + ex.Message);
            }
            return IdCat;
        }
        public (bool, string) AgregarCategoriaProducto(int IdProducto, int IdCategoria)
        {
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_IN_TbProductoCategoria", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProducto", IdProducto);
                        cmd.Parameters.AddWithValue("@IdCategoria", IdCategoria);
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
    }
}
