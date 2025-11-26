using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class BdCompra
    {
        BdConexionSQL BdConexion = new BdConexionSQL();
        BdEmpleados util = new BdEmpleados();
        // Registrar Cabecera
        public (int, string) RegistrarCompra(int idProveedor, int idEmpleado, string numFactura, decimal total)
        {
            int idGenerado = 0;
            string msj = "";
            try
            {
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_IN_RegistrarCompra", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);
                        cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                        cmd.Parameters.AddWithValue("@NumFactura", numFactura);
                        cmd.Parameters.AddWithValue("@TotalCompra", total);

                        SqlParameter idOut = new SqlParameter("@IdCompraGenerado", SqlDbType.Int) { Direction = ParameterDirection.Output };
                        SqlParameter msjOut = new SqlParameter("@Mensaje", SqlDbType.VarChar, 100) { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(idOut); cmd.Parameters.Add(msjOut);

                        cmd.ExecuteNonQuery();
                        idGenerado = Convert.ToInt32(idOut.Value);
                        msj = msjOut.Value.ToString();
                    }
                }
            }
            catch (Exception ex) { msj = ex.Message; }
            return (idGenerado, msj);
        }

        // Registrar Detalle
        public bool RegistrarDetalle(int idCompra, int idProdUnidad, decimal cantidad, decimal precio, string lote, DateTime caducidad)
        {
            try
            {
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_IN_RegistrarDetalleLote", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCompra", idCompra);
                        cmd.Parameters.AddWithValue("@IdProductoUnidad", idProdUnidad);
                        cmd.Parameters.AddWithValue("@CantidadComprada", cantidad);
                        cmd.Parameters.AddWithValue("@PrecioUnitario", precio);
                        cmd.Parameters.AddWithValue("@NumeroLote", lote);
                        cmd.Parameters.AddWithValue("@FechaCaducidad", caducidad);

                        SqlParameter res = new SqlParameter("@Resultado", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(res);
                        cmd.ExecuteNonQuery();
                        return Convert.ToBoolean(res.Value);
                    }
                }
            }
            catch { return false; }
        }

        // Método para Aprobar (opcional si quieres hacerlo automático al final)
        public (bool, string) AprobarCompra(int idCompra)
        {
            try
            {
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_UP_AprobarCompra", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdCompra", idCompra);
                        SqlParameter res = new SqlParameter("@Resultado", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                        SqlParameter msj = new SqlParameter("@Mensaje", SqlDbType.VarChar, 100) { Direction = ParameterDirection.Output };
                        cmd.Parameters.Add(res); cmd.Parameters.Add(msj);
                        cmd.ExecuteNonQuery();
                        return (Convert.ToBoolean(res.Value), msj.Value.ToString());
                    }
                }
            }
            catch (Exception ex) { return (false, ex.Message); }
        }
        // Agrega esto dentro de la clase BdCompras
        public System.Data.DataTable ListarPresentaciones(int idProducto)
        {
            // Usamos una lista de parámetros para enviar el ID
            var listaParametros = new System.Collections.Generic.List<System.Data.SqlClient.SqlParameter>();

            listaParametros.Add(new System.Data.SqlClient.SqlParameter("@IdProducto", idProducto));

            // Reutilizamos tu método genérico (que está en util/BdEmpleados)
            return util.ObtenerDatosMaestros("SP_SL_ListarUnidadesPorProducto", listaParametros);
        }
   
        public bool RegistrarEgresoCaja(int idEmpleado, decimal monto, int idCompraRef)
        {
            try
            {
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    // Asegúrate de haber creado este SP en SQL (te lo di en la respuesta anterior)
                    using (SqlCommand cmd = new SqlCommand("SP_IN_RegistrarEgresoPorCompra", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdEmpleado", idEmpleado);
                        cmd.Parameters.AddWithValue("@Monto", monto);
                        cmd.Parameters.AddWithValue("@IdCompra", idCompraRef);

                        SqlParameter res = new SqlParameter("@Resultado", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                        SqlParameter msj = new SqlParameter("@Mensaje", SqlDbType.VarChar, 100) { Direction = ParameterDirection.Output };

                        cmd.Parameters.Add(res);
                        cmd.Parameters.Add(msj);

                        cmd.ExecuteNonQuery();
                        return Convert.ToBoolean(res.Value);
                    }
                }
            }
            catch
            {
                return false; // Si falla (ej: caja cerrada), no detiene la compra, solo no descuenta
            }
        }
    }
}
