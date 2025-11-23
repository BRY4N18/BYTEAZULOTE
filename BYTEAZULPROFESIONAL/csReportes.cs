using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace BYTEAZULPROFESIONAL
{
    internal class csReportes
    {
        public DateTime Inicio { get; set; }
        public DateTime Fin { get; set; }
        public csReportes(DateTime Fechainicio, DateTime Fechafin)
        {
            Inicio = Fechainicio;
            Fin = Fechafin;
        }
        public void Reportes(ReportViewer reporte, string consulta, string informe, string dsTabla)
        {
            CsConexion conexion = new CsConexion();
            ReportDataSource dataset = new ReportDataSource();
            reporte.LocalReport.DataSources.Clear();
            DataTable dt = conexion.Leer(consulta);
            reporte.LocalReport.ReportEmbeddedResource = "BYTEAZULPROFESIONAL.Reportes." + informe+ ".rdlc";
            try { dataset = new ReportDataSource(dsTabla,dt); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            reporte.LocalReport.DataSources.Add(dataset);
        }
        public string caden(string combo)
        {
            if (combo == "Reporte de Productos en Existencia")
                return "Select M.id_producto Id, M.md_producto Medicina, M.md_categoria Categoria, M.id_proveedor [IdProveedor], M.id_iva Iva, M.md_descripcion Descripcion, M.md_precio_unidad [Preciounitario], M.md_estado Estado, sum(l.lt_cantidad) Cantidad " +
                     "from Medicina M left join Lotes L on M.id_producto=L.id_producto where l.lt_cantidad > 0 and M.md_estado = 'Disponible'\r\ngroup by M.id_producto, M.md_producto, M.md_categoria, M.id_proveedor, M.id_iva, M.md_descripcion, M.md_precio_unidad, M.md_estado";
            else if (combo == "Reportes Graficos de Ventas Mensuales")
                return "Select YEAR(V.vt_fecha_venta) as ANIO, MONTH(vt_fecha_venta) as MES, DAY(vt_fecha_venta) as DIA, SUM(D.cantidad) as VENTAS " +
                  "from Detalles_Ventas D inner join Ventas V on D.id_venta=V.id_venta where YEAR(V.vt_fecha_venta) = " + Inicio.Year + " and MONTH(V.vt_fecha_venta) = " + Inicio.Month + " group by MONTH(vt_fecha_venta),YEAR(V.vt_fecha_venta),DAY(vt_fecha_venta)";
            else if (combo == "Reporte de Listado de Clientes")
                return "Select id_cliente AS IDCliente, cl_identificador AS Identificacion, cl_nombre AS Nombres, cl_apellido AS Apellidos, cl_celular AS Celular, " +
                    "cl_email AS email, cl_direccion AS Direccion, cl_estado AS Estado from Clientes";
            else if (combo == "Reportes de Ventas de Empleados")
                return "Select E.em_nombres+' '+ E.em_apellidos as Nombres,YEAR(V.vt_fecha_venta) as Anio, Month(V.vt_fecha_venta) as Mes, DAY(V.vt_fecha_venta) as Dia, Count(V.id_venta) as ven " +
                    "from Ventas V inner join Detalles_Ventas D on V.id_venta=D.id_venta inner join Empleados E on E.id_empleado=V.id_empleado where YEAR(V.vt_fecha_venta) = "+Inicio.Year +
                    " and MONTH(V.vt_fecha_venta) = "+Inicio.Month+ " group by E.em_nombres+' '+ E.em_apellidos,YEAR(V.vt_fecha_venta),Month(V.vt_fecha_venta),DAY(V.vt_fecha_venta)";
            else if (combo == "Reportes de Productos mas vendidos")
            {
                if (Inicio == Fin) return "Select TOP 10 M.id_producto as ID,M.md_producto as PRODUCTO, SUM(D.cantidad) as VENTAS " +
                  "from Detalles_Ventas D inner join Medicina M on D.id_producto= M.id_producto inner join Ventas V on D.id_venta=V.id_venta " +
                  "where YEAR(V.vt_fecha_venta) = " + Inicio.Year + " and MONTH(vt_fecha_venta) = " + Inicio.Month + " and DAY(vt_fecha_venta) = " + Inicio.Day + " " +
                  "group by M.id_producto,M.md_producto order by SUM(D.cantidad) desc";
                else return "Select TOP 10 M.id_producto as ID,M.md_producto as PRODUCTO, SUM(D.cantidad) as VENTAS " +
                     "from Detalles_Ventas D inner join Medicina M on D.id_producto= M.id_producto \r\ninner join Ventas V on D.id_venta=V.id_venta " +
                     "where V.vt_fecha_venta between  '" + Inicio.Date.ToString("yyyy-MM-dd") + "' and '" + Fin.Date.ToString("yyyy-MM-dd") + "'" +
                     "group by M.id_producto ,M.md_producto order by SUM(D.cantidad) desc";
            }
            else if (combo == "Reportes De Ventas")
            {
                if (Inicio == Fin) return "Select V.vt_factura AS Factura, D.id_producto AS IDMedicina, M.md_producto AS Medicina, v.id_cliente AS Cliente, C.cl_nombre AS CNombres, C.cl_apellido AS CApellidos, V.id_empleado AS IDEmpleado, E.em_nombres AS ENombres, E.em_apellidos AS EApellidos, D.id_lote AS IDLote, D.cantidad AS Cantidad, D.precio_unitario AS PrecioUnitario, " +
                     "D.subtotal as Subtotal from Detalles_Ventas D inner join Ventas V on D.id_venta= V.id_venta inner join Medicina M on D.id_producto= M.id_producto inner join Clientes C on V.id_cliente=C.id_cliente inner join Empleados E on V.id_empleado=E.id_empleado where YEAR(V.vt_fecha_venta)= " + Inicio.Year + " and MONTH(V.vt_fecha_venta) = " + Inicio.Month + " and DAY(V.vt_fecha_venta) = " + Inicio.Day;
                else return "Select V.vt_factura AS Factura, D.id_producto AS IDMedicina, M.md_producto AS Medicina, v.id_cliente AS Cliente, C.cl_nombre AS CNombres, C.cl_apellido AS CApellidos, V.id_empleado AS IDEmpleado, E.em_nombres AS ENombres, E.em_apellidos AS EApellidos, D.id_lote AS IDLote, D.cantidad AS Cantidad, D.precio_unitario AS PrecioUnitario, " +
                     "D.subtotal as Subtotal from Detalles_Ventas D inner join Ventas V on D.id_venta= V.id_venta inner join Medicina M on D.id_producto= M.id_producto inner join Clientes C on V.id_cliente=C.id_cliente inner join Empleados E on V.id_empleado=E.id_empleado \r\nwhere V.vt_fecha_venta between '" + Inicio.Date.ToString("yyyy-MM-dd") + "' and '" + Fin.Date.ToString("yyyy-MM-dd") + "'";
            }
            else if (combo == "Reportes De Movimiento de Inventario (Medicinas)")
            {
                if (Inicio == Fin) return "Select  P.id_producto as Id,M.md_producto as Medicina,P.id_empleado as Empleado,E.em_nombres as Nombre, E.em_apellidos as Apellido, " +
                     "P.movimientos as Movimientos, P.movp_hora as Hora, P.movp_fecha as Fecha from MovimientosProductos P inner join Medicina M on P.id_producto=M.id_producto  inner join Empleados E on P.id_empleado=E.id_empleado " +
                     "where YEAR(P.movp_fecha) = " + Inicio.Year + " and MONTH(P.movp_fecha) = " + Inicio.Month + " and DAY(P.movp_fecha) = " + Inicio.Day;
                else return "Select P.id_producto as Id,M.md_producto as Medicina,P.id_empleado as Empleado,E.em_nombres as Nombre, E.em_apellidos as Apellido, " +
                     "P.movimientos as Movimientos, P.movp_hora as Hora, P.movp_fecha as Fecha from MovimientosProductos P inner join Medicina M on P.id_producto=M.id_producto  inner join Empleados E on P.id_empleado=E.id_empleado " +
                     "where P.movp_fecha  between '" + Inicio.Date.ToString("yyyy-MM-dd") + "' and '" + Fin.Date.ToString("yyyy-MM-dd") + "'";
            }
            else if (combo == "Reportes de Compras")
            {
                if (Inicio == Fin) return "SELECT DISTINCT L.id_lote AS IDLote, L.id_producto AS CodigoProducto, M.md_producto AS Producto, L.id_proveedor AS IDProveedor, P.prv_nombre AS Proveedor, " +
                        "L.lt_fecha_entrada AS FechaIngreso, L.lt_fecha_caducidad AS FechaCaducidad, L.lt_cantidad AS Cantidad, L.lt_precio_compra AS PrecioCompra, L.lt_detalles AS Detalles, " +
                        "C.cm_fecha_compra AS FechaCompra, L.lt_estado AS Estado FROM Lotes L inner join Medicina M on L.id_producto=M.id_producto inner join Proveedores P on L.id_proveedor=P.id_proveedor inner join " +
                        "DetalleCompras D on D.id_producto=M.id_producto inner join Compras C on C.id_compra=D.id_compra where Year(C.cm_fecha_compra)= " + Inicio.Year + " and MONTH(C.cm_fecha_compra) = " + Inicio.Month + " and DAY(C.cm_fecha_compra) = " + Inicio.Day;
                else return "SELECT DISTINCT L.id_lote AS IDLote, L.id_producto AS CodigoProducto, M.md_producto AS Producto, L.id_proveedor AS IDProveedor, P.prv_nombre AS Proveedor, " +
                        "L.lt_fecha_entrada AS FechaIngreso, L.lt_fecha_caducidad AS FechaCaducidad, L.lt_cantidad AS Cantidad, L.lt_precio_compra AS PrecioCompra, L.lt_detalles AS Detalles, " +
                        "C.cm_fecha_compra AS FechaCompra, L.lt_estado AS Estado FROM Lotes L inner join Medicina M on L.id_producto=M.id_producto inner join Proveedores P on L.id_proveedor=P.id_proveedor inner join " +
                        "DetalleCompras D on D.id_producto=M.id_producto inner join Compras C on C.id_compra=D.id_compra where C.cm_fecha_compra between '" + Inicio.Date.ToString("yyyy-MM-dd") + "' and '" + Fin.Date.ToString("yyyy-MM-dd") + "'"; ;
            }
            else
            {
                if (Inicio == Fin) return "Select TOP 10 M.id_producto as ID,M.md_producto as PRODUCTO, SUM(D.cantidad) as VENTAS " +
                  "from Detalles_Ventas D inner join Medicina M on D.id_producto= M.id_producto inner join Ventas V on D.id_venta=V.id_venta " +
                  "where YEAR(V.vt_fecha_venta) = " + Inicio.Year + " and MONTH(vt_fecha_venta) = " + Inicio.Month + " and DAY(vt_fecha_venta) = " + Inicio.Day + " " +
                  "group by M.id_producto,M.md_producto order by SUM(D.cantidad) asc";
                else return "Select TOP 10 M.id_producto as ID ,M.md_producto as PRODUCTO, SUM(D.cantidad) as VENTAS " +
                     "from Detalles_Ventas D inner join Medicina M on D.id_producto= M.id_producto inner join Ventas V on D.id_venta=V.id_venta " +
                     "where V.vt_fecha_venta between  '" + Inicio.Date.ToString("yyyy-MM-dd") + "' and '" + Fin.Date.ToString("yyyy-MM-dd") + "'" +
                     "group by M.id_producto ,M.md_producto order by SUM(D.cantidad) asc";
            }
        }
        public string Informe(string combo)
        {
            if (combo == "Reporte de Productos en Existencia") return "rptProductosExistentes";
            else if (combo == "Reportes Graficos de Ventas Mensuales") return "rptGraficosMensuales";
            else if (combo == "Reportes de Productos mas vendidos") return "rptMasVendido";
            else if (combo == "Reportes De Ventas") return "rptVentas";
            else if (combo == "Reportes De Movimiento de Inventario (Medicinas)") return "rptMovimientoInventario";
            else if (combo == "Reporte de Listado de Clientes") return "rptListadoClientes";
            else if (combo == "Reportes de Compras") return "rptCompras";
            else if (combo == "Reportes de Ventas de Empleados") return "rptVenEmpleados";
            else return "rptMasVendido";
        }
        public string Tabla(string combo)
        {
            if (combo == "Reporte de Productos en Existencia") return "dsProductosExistentes";
            else if (combo == "Reportes Graficos de Ventas Mensuales") return "dsVentasMes";
            else if (combo == "Reportes de Productos mas vendidos") return "dsProductoMasVendido";
            else if (combo == "Reportes De Ventas") return "dsVentas";
            else if (combo == "Reportes De Movimiento de Inventario (Medicinas)") return "dsMovimientoInventario";
            else if (combo == "Reporte de Listado de Clientes") return "dsLisClientes";
            else if (combo == "Reportes de Compras") return "dsCompra";
            else if (combo == "Reportes de Ventas de Empleados") return "dsVenEmpleados";
            else return "dsProductoMasVendido";
        }
        public string Parametros(string combo)
        {
            if (combo == "Reportes Graficos de Ventas Mensuales") return "PmMes";
            else if (combo == "Reportes de Productos mas vendidos") return "PmTitulo";
            else if (combo == "Reportes De Ventas") return "PmFecha";
            else if (combo == "Reportes De Movimiento de Inventario (Medicinas)") return "PmFechaInicial";
            else if (combo == "Reportes de Compras") return "PmFecha";
            else if (combo == "Reportes de Ventas de Empleados") return "PmFecha";
            else return "PmTitulo";
        }
        public string rellenar(string combo)
        {
            if (combo == "Reportes Graficos de Ventas Mensuales")
            {
                if (Inicio.Month.ToString() == "1") return "Enero";
                else if (Inicio.Month.ToString() == "2") return "Febrero";
                else if (Inicio.Month.ToString() == "3") return "Marzo";
                else if (Inicio.Month.ToString() == "4") return "Abril";
                else if (Inicio.Month.ToString() == "5") return "Mayo";
                else if (Inicio.Month.ToString() == "6") return "Junio";
                else if (Inicio.Month.ToString() == "7") return "Julio";
                else if (Inicio.Month.ToString() == "8") return "Agosto";
                else if (Inicio.Month.ToString() == "9") return "Septiembre";
                else if (Inicio.Month.ToString() == "10") return "Octubre";
                else if (Inicio.Month.ToString() == "11") return "Noviembre";
                else return "Diciembre";
            }
            else if (combo == "Reportes de Productos mas vendidos") return "MEDICINAS MAS VENDIDAS";
            else if (combo == "Reportes De Ventas" || combo == "Reportes De Movimiento de Inventario (Medicinas)" || combo == "Reportes de Compras" || combo == "Reportes de Ventas de Empleados")
            {
                if (Inicio == Fin) return "De: " + Inicio.Date.ToString("yyyy-MM-dd");
                else return "Desde " + Inicio.Date.ToString("yyyy-MM-dd") + " hasta " + Fin.Date.ToString("yyyy-MM-dd");
            }
            else return "MEDICINAS MENOS VENDIDAS";
        }
    }
}
