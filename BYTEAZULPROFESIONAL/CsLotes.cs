using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace BYTEAZULPROFESIONAL
{
    internal class CsLotes
    {
        public string IDLote { get; set; }
        public string IDProducto { get; set; }
        public string IDProvedor { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public string Dettales { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public string Estado { get; set; }

        CsConexion conexion;
        CsMovimientos movimientos;
        SqlConnection conectar;
        //producto y provedor
        public CsLotes()
        {
            conexion = new CsConexion();
            movimientos = new CsMovimientos();
        }
        public CsLotes(int cantida, string idlote)//Constructor para ejecutar el metodo de modificar
        {
            Cantidad = cantida;
            IDLote = idlote;
        }
        public bool IngresarLotes(string idproducto, string idprovedor, DateTime fechacaducidad, int cantidad, decimal preciocompra, string detalles, string estado)
        {
            //string idprodu, int canti, string idemple
            movimientos = new CsMovimientos(idproducto, cantidad, movimientos.ID());
            string comando = "INSERT INTO Lotes (id_producto, id_proveedor, lt_fecha_entrada, lt_fecha_caducidad, lt_cantidad, lt_precio_compra, lt_detalles, lt_estado) VALUES " +
            "('" + idproducto + "', '" + idprovedor + "', GETDATE(), '" + fechacaducidad.ToString("yyyy-MM-dd") + "', " +
            cantidad + ", " + preciocompra.ToString("F2", CultureInfo.InvariantCulture) + ", '" + detalles + "', '" + estado + "')";

            if (conexion.Ingresar_Modificar(comando))
            {
                movimientos.AccionForms("Ingreso de nuevo lote");
                movimientos.AgregarProductos();
                return true;
            }
            else
                return false;
        }
        public DataTable TablaLotes()
        {
            string consulta = "SELECT id_lote AS [ID del Lote], id_producto AS [Código Producto], id_proveedor AS [ID Proveedor], " +
                "lt_fecha_entrada AS [Fecha de Ingreso], lt_fecha_caducidad AS [Fecha de Caducidad], lt_cantidad AS Cantidad, " +
                "lt_precio_compra AS [Precio de Compra], lt_detalles AS [Detalles], lt_estado AS Estado FROM Lotes";
            return conexion.Leer(consulta);
        }
        public DataTable TablaLotes(string buscar)
        {
            string consulta = "SELECT id_lote AS [ID del Lote], id_producto AS [Código Producto], id_proveedor AS [ID Proveedor], " +
                "lt_fecha_entrada AS [Fecha de Ingreso], lt_fecha_caducidad AS [Fecha de Caducidad], lt_cantidad AS Cantidad, " +
                "lt_precio_compra AS [Precio de Compra], lt_detalles AS [Detalles], lt_estado AS Estado FROM Lotes " +
                "WHERE id_lote LIKE '%" + buscar + "%' OR id_producto LIKE '%" + buscar + "%' OR  CAST(id_proveedor AS VARCHAR) LIKE '%" + buscar + "%' OR  " +
                "CONVERT(VARCHAR, lt_fecha_entrada, 23) LIKE '%" + buscar + "%' OR  CONVERT(VARCHAR, lt_fecha_caducidad, 23) LIKE '%" + buscar + "%'" +
                "OR  CAST(lt_cantidad AS VARCHAR) LIKE '%" + buscar + "%' OR  CAST(lt_precio_compra AS VARCHAR) LIKE '%" + buscar + "%' OR" +
                " lt_detalles LIKE '%" + buscar + "%' OR lt_estado LIKE '%" + buscar + "%';";
            return conexion.Leer(consulta);
        }
        public bool CambiarDisponiblidad(string id)
        {
            string sentencia = "UPDATE Lotes SET lt_estado = 'NoDisponible' WHERE id_lote = '" + id + "';";
            if (conexion.Ingresar_Modificar(sentencia))
            {
                MessageBox.Show("Disponibilidad del lote " + id + " modificada a 'NoDisponible'");
                movimientos.AccionForms("Estado de lote modificado");
                return true;
            }
            else return false;
        }
        public void ActualizarDisponiblidad()
        {
            string sentencia = "UPDATE Lotes SET lt_estado = 'NoDisponible' WHERE CAST(lt_fecha_caducidad AS DATE) < CAST(GETDATE() AS DATE) AND lt_estado != 'NoDisponible';";
            if (conexion.Ingresar_Modificar(sentencia))
                movimientos.AccionForms("Estado de lote modificado");
        }
        public bool Modificar()
        {
            try
            {
                conexion = new CsConexion();
                string modi = "Update Lotes set lt_cantidad= " + Cantidad + " where id_lote =" + IDLote;
                if (conexion.Ingresar_Modificar(modi)) return true;
                else return false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }
    }
}
