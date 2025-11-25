using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class BdMedicina
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
        //---------------------------------------------------------------
    }
}
