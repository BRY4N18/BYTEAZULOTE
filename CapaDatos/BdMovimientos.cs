using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class BdMovimientos
    {
        BdConexionSQL BdConexion;
        public DataTable ListarMovimientos(string filtro)
        {
            DataTable dtMovimientos = new DataTable();
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_SL_ListarMovimientos ", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Filtro", filtro);
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtMovimientos);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el listado de movimientos: " + ex.Message);
            }
            return dtMovimientos;
        }
    }
}
