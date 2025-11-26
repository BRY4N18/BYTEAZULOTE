using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class BdUnidadMedida
    {
        BdConexionSQL BdConexion;
        public (bool, string) AgregarUnidadMedidaProducto(int IdProducto, int IdUnidadMedida, double Precio)
        {
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_IN_TbProductosUnidades", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProducto", IdProducto);
                        cmd.Parameters.AddWithValue("@IdUnidadMedida", IdUnidadMedida);
                        cmd.Parameters.AddWithValue("@Precio", Precio);
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
        public int ObtenerIdUnidadMedidaId(string nombreUnidad)
        {
            int IdUnidad = 0;
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_SL_ObtenerIDdeUnidadMedida", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@unidadmedida", nombreUnidad);
                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            IdUnidad = Convert.ToInt32(reader["IdUnidadMedida"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el ID de unidad de medida: " + ex.Message);
            }
            return IdUnidad;

        }
        public DataTable ListarUnidadesMedida()
        {
            DataTable dt = new DataTable();
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_SL_ListarUnidadesMedida", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar unidades de medida: " + ex.Message);
            }
            return dt;
        }
    }
}
