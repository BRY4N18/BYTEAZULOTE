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
    internal class CsCompras
    {
        public int IdCompra { get; set; }
        public int IdProveedor { get; set; }
        public int IdEmpleado { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal TotalCompra { get; set; }

        csProveedor proveedores;
        csMedicina medicinas;
        CsLotes lotes;
        CsConexion conexion;
        SqlConnection conectar;
        CsMovimientos movimientos;
        CsCaja caja;
        public CsCompras()
        {
            proveedores = new csProveedor();
            medicinas = new csMedicina();
            lotes = new CsLotes();
            conexion = new CsConexion();
            movimientos = new CsMovimientos();
            caja = new CsCaja();

        }

        public bool IngresarCompra(string idproveedor, string idempleado, decimal total)
        {
            string idcajafac = caja.IDCaja();
            string idcaja = "";
            if (idcajafac.Length < 4)
            {
                idcaja = "000" + idcajafac;
                idcaja = idcaja.Substring(idcajafac.Length);
            }
            else idcaja = idcajafac;
            DataTable dt = conexion.Leer("Select * from Compras");
            string num = (dt.Rows.Count + 1).ToString();
            string numfactura = "000000000" + num.ToString();
            idcajafac = "001-" + idcaja + "-" + numfactura.Substring(num.Length);

            string comando = "INSERT INTO Compras (cm_factura, id_proveedor, id_empleado, cm_fecha_compra, cm_total_compra) VALUES('" + idcajafac + "', '" + idproveedor + "', '" + idempleado + "', GETDATE(), '" + total.ToString("F2", CultureInfo.InvariantCulture) + "'); ";

            if (conexion.Ingresar_Modificar(comando))
            {
                MessageBox.Show("Compra realizada con exito");
                movimientos.AccionForms("Se ingreso una nueva compra");
                return true;
            }
            else
                return false;

        }

        public bool IngresarDetallesCompra(string idcompra, string idproducto, int cantidad, decimal precioUnit, decimal subtotal)
        { 
            string comando = "INSERT INTO DetalleCompras (id_compra, id_producto, cm_cantidad, cm_precio_unitario, cm_subtotal) VALUES('"+ idcompra + "', '" + idproducto + "', " + cantidad + ", " + precioUnit.ToString("F2", CultureInfo.InvariantCulture) + ", " + subtotal.ToString("F2", CultureInfo.InvariantCulture) + ");";
            if (conexion.Ingresar_Modificar(comando))
            return true;
                else return false;
        }

        public string IDCompra()
        {
            string comando = "SELECT TOP 1 id_compra FROM Compras ORDER BY id_compra DESC;";
            DataTable dt = conexion.Leer(comando);

            if (dt.Rows.Count > 0)
                return dt.Rows[0]["id_compra"].ToString();

            return null;
        }
        public string NumFactura()
        {
            return conexion.RetornaConsulta("select top 1(cm_factura) from Compras order by id_compra desc");
        }
    }
}
