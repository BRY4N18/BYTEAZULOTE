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
        public (bool, string, int) RegistrarProveedor(string Proveedor, string RUC, string Telefono, string Direccion, string Correo)
        {
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_IN_TbProveedores", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Proveedor", Proveedor);
                        cmd.Parameters.AddWithValue("@RUC", RUC);
                        cmd.Parameters.AddWithValue("@Telefono", Telefono);
                        cmd.Parameters.AddWithValue("@Direccion", Direccion);
                        cmd.Parameters.AddWithValue("@Correo", Correo);

                        SqlParameter resultadoParam = new SqlParameter("@Resultado", SqlDbType.Bit) { Direction = ParameterDirection.Output };
                        SqlParameter mensajeretornoparam = new SqlParameter("@MensajeRetorno", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                        SqlParameter idProveedorParam = new SqlParameter("@IdProveedor", SqlDbType.Int) { Direction = ParameterDirection.Output };

                        cmd.Parameters.Add(resultadoParam);
                        cmd.Parameters.Add(mensajeretornoparam);
                        cmd.Parameters.Add(idProveedorParam);

                        cmd.ExecuteNonQuery();

                        return (Convert.ToBoolean(resultadoParam.Value), mensajeretornoparam.Value.ToString(), Convert.ToInt32(idProveedorParam.Value));
                    }
                }
            }
            catch (Exception ex)
            {
                return (false, "Error al registrar el contacto de emergencia: " + ex.Message, 0);
            }
        }
        public (bool, string) RegistrarServicioProveedor(int IdProv, int IdServ)
        {
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_IN_PROVEEDOR_SERVICIO_PROVEEDOR", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProveedor", IdProv);
                        cmd.Parameters.AddWithValue("@IdServicio", IdServ);
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
        public (bool, string) RegistrarProductoProveedor(int IdProv, int IdProd)
        {
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_IN_PROVEEDOR_PRODUCTO_PROVEEDOR", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IdProveedor", IdProv);
                        cmd.Parameters.AddWithValue("@IdProducto", IdProd);
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
        public DataTable ServiciosProveedores()
        {
            DataTable dtVerServicios = new DataTable();
            try
            {
                BdConexion = new BdConexionSQL();
                using (SqlConnection conn = BdConexion.ObtenerConexion())
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("SP_SL_ListarServicios", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(dtVerServicios);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener lista de servicios de proveedores: " + ex.Message);
            }
            return dtVerServicios;
        }
    }
}
