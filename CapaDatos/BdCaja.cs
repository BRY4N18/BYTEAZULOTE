using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class BdCaja
    {
        BdConexionSQL BdConexion = new BdConexionSQL();

        // 1. ABRIR
        public (bool, string) AbrirCaja(int idEmpleado, decimal montoInicial)
        {
            try
            {
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_IN_AbrirCaja", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                        cmd.Parameters.AddWithValue("@MontoInicial", montoInicial);

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

        // 2. VERIFICAR SI ESTÁ ABIERTA (Retorna el ID de sesión o 0)
        public int ObtenerSesionAbierta(int idEmpleado)
        {
            int idSesion = 0;
            try
            {
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_SL_VerificarEstadoCaja", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);

                        SqlParameter idParam = new SqlParameter("@IdSesionAbierta", SqlDbType.Int) { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(idParam);

                        cmd.ExecuteNonQuery();
                        if (idParam.Value != DBNull.Value) idSesion = Convert.ToInt32(idParam.Value);
                    }
                }
            }
            catch { }
            return idSesion;
        }

        // 3. CERRAR
        public (bool, string) CerrarCaja(int idSesion, decimal montoFisico)
        {
            try
            {
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_UP_CerrarCaja", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCajaSesion", idSesion);
                        cmd.Parameters.AddWithValue("@MontoFinalFisico", montoFisico);

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
