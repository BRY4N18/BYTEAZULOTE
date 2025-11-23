using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BYTEAZULPROFESIONAL
{
    class CsMovimientos
    {

        CsConexion conexion;

        public CsMovimientos()
        {
            conexion = new CsConexion();
        }

        public bool Accion(string movimiento, string id)
        {
            CsConexion conectar = new CsConexion();
            try
            {
                string hora = DateTime.Now.ToString("HH:mm:ss"); // Hora actual
                string fecha = DateTime.Now.ToString("yyyy-MM-dd"); // Fecha actual

                if ((conectar.Ingresar_Modificar("INSERT INTO Movimientos (id_empleado, mov_accion, mov_hora, mov_fecha) " + "VALUES ('" + id + "', '" + movimiento + "', '" + hora + "', '" + fecha + "')"))) return true;
                else return false;
            }
            catch (Exception ex)
            {
                conectar.cerrarconexion();
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        public bool AccionForms(string movimiento)
        {
            if (Accion(movimiento, ID())) return true;
            else return false;
        }
        public string ID()
        {
            conexion = new CsConexion();
            return conexion.RetornaConsulta("Select Top 1(id_empleado) from Movimientos order by id_movimiento desc");
        }
        public DataTable BuscarMovimientos(string buscar)
        {
            conexion = new CsConexion();
            string consulta = "Select id_movimiento as ID , id_empleado as [Id Empleado], mov_accion as Accion, mov_hora as Hora, mov_fecha as Fecha " +
                "from Movimientos where id_movimiento LIKE '%" + buscar + "%' or id_empleado LIKE '%" + buscar + "%' or mov_accion LIKE '%" + buscar + "%' or mov_hora LIKE '%" + buscar + "%' or mov_fecha LIKE '%" + buscar + "%' order by id_movimiento Desc";
            return conexion.Leer(consulta);
        }
        public DataTable Buscar()
        {
            conexion = new CsConexion();
            string consulta = "Select id_movimiento as ID , id_empleado as [Id Empleado], mov_accion as Accion, mov_hora as Hora, mov_fecha as Fecha from Movimientos order by id_movimiento Desc";
            return conexion.Leer(consulta);
        }

        // MOVIMIENTOS DE PRODUCTOS
        string idProducto, idEmpleado;
        int cantidad;
        public string IdProducto { get { return idProducto; } set { idProducto = value; } }
        public string IdEmpleado { get { return idEmpleado; } set { idEmpleado = value; } }
        public int Cantidad { get { return cantidad; } set { cantidad = value; } }
        public CsMovimientos(string idprodu, int canti, string idemple)
        {
            idEmpleado = idemple;
            idProducto = idprodu; // Constructor para modificaciones del stock de productos
            cantidad = canti;
        }
        public CsMovimientos(string idprodu, string idemple)
        {
            idEmpleado = idemple;
            idProducto = idprodu; // Constructor para la habilitacion y deshabilitacion de productos
        }
        public bool AgregarProductos()
        {
            string fechaHoraActual = DateTime.Now.ToString("yyyy-MM-dd");
            string hora = DateTime.Now.ToString("HH:mm:ss"); 
            conexion = new CsConexion();
            try
            {
                string producto = conexion.RetornaConsulta("Select md_producto from Medicina where id_producto = '" + IdProducto + "'");
                conexion.Ingresar_Modificar("Insert into MovimientosProductos (id_producto, id_empleado, movimientos, movp_hora, movp_fecha) values ('" + IdProducto + "', '" + IdEmpleado + "', 'Se agregaron " + Cantidad + " cantidades de " + producto + "', '" + hora + "', '" + fechaHoraActual + "')");
                cantidad = int.Parse(conexion.RetornaConsulta("select sum(L.lt_cantidad) Cantidad from Medicina M inner join Lotes L on M.id_producto=L.id_producto where M.id_producto = '" + IdProducto + "'"));
                conexion.Ingresar_Modificar("Insert into MovimientosProductos (id_producto, id_empleado, movimientos, movp_hora, movp_fecha) values ('" + IdProducto + "', '" + IdEmpleado + "','Ahora el producto " + producto + " consta de " + Cantidad + " cantidades', '" + hora + "', '" + fechaHoraActual + "')");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }
        public bool ConsumirProductos()
        {
            string hora = DateTime.Now.ToString("HH:mm:ss"); // Hora actual
            string fecha = DateTime.Now.ToString("yyyy-MM-dd"); // Fecha actual
            conexion = new CsConexion();
            try
            {
                string producto = conexion.RetornaConsulta("Select md_producto from Medicina where id_producto = '" + IdProducto + "'");
                conexion.Ingresar_Modificar("Insert into MovimientosProductos (id_producto, id_empleado, movimientos, movp_hora, movp_fecha) values ('" + IdProducto + "', '" + IdEmpleado + "', 'Se consumieron " + Cantidad + " cantidades de " + producto + "', '" + hora + "', '" + fecha + "')");
                cantidad = int.Parse(conexion.RetornaConsulta("select sum(L.lt_cantidad) Cantidad from Medicina M inner join Lotes L on M.id_producto=L.id_producto where M.id_producto = '" + IdProducto + "'"));
                conexion.Ingresar_Modificar("Insert into MovimientosProductos (id_producto, id_empleado, movimientos, movp_hora, movp_fecha) values ('" + IdProducto + "', '" + IdEmpleado + "', 'Ahora el producto " + producto + " consta de " + Cantidad + " cantidades', '" + hora + "', '" + fecha + "')");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }
        public bool DeshabilitarProductos()
        {
            string hora = DateTime.Now.ToString("HH:mm:ss"); // Hora actual
            string fecha = DateTime.Now.ToString("yyyy-MM-dd"); // Fecha actual
            conexion = new CsConexion();
            try
            {
                string producto = conexion.RetornaConsulta("Select md_producto from Medicina where id_producto = '" + IdProducto + "'");
                conexion.Ingresar_Modificar("Insert into MovimientosProductos (id_producto, id_empleado, movimientos, movp_hora, movp_fecha) values ('" + IdProducto + "', '" + IdEmpleado + "', 'Se deshabilito el producto " + producto + "', '" + hora + "', '" + fecha + "')");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }
        public bool HabilitarProductos()
        {
            string hora = DateTime.Now.ToString("HH:mm:ss"); // Hora actual
            string fecha = DateTime.Now.ToString("yyyy-MM-dd"); // Fecha actual
            conexion = new CsConexion();
            try
            {
                string producto = conexion.RetornaConsulta("Select md_producto from Medicina where id_producto = '" + IdProducto + "'");
                conexion.Ingresar_Modificar("Insert into MovimientosProductos (id_producto, id_empleado, movimientos, movp_hora, movp_fecha) values ('" + IdProducto + "', '" + IdEmpleado + "', 'Se habilito el producto " + producto + "', '" + hora + "', '" + fecha + "')");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }
        public bool Agg1Productos(string estado)
        {
            string hora = DateTime.Now.ToString("HH:mm:ss"); // Hora actual
            string fecha = DateTime.Now.ToString("yyyy-MM-dd"); // Fecha actual
            conexion = new CsConexion();
            try
            {
                string producto = conexion.RetornaConsulta("Select md_producto from Medicina where id_producto = '" + IdProducto + "'");
                conexion.Ingresar_Modificar("Insert into MovimientosProductos (id_producto, id_empleado, movimientos, movp_hora, movp_fecha) values ('" + IdProducto + "', '" + IdEmpleado + "', 'Se agrego el producto " + producto + " con estado " + estado + "', '" + hora + "', '" + fecha + "')");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return true;
        }
        public DataTable BuscarProduMovi(string control)
        {
            CsConexion conexion = new CsConexion();
            DataTable moviP;
            if (control == "1")
                moviP = conexion.Leer("Select id_moviProducto as [Id Movimiento P.], id_producto as [Id Producto], id_empleado as [Id Empleado], movimientos as Movimientos, movp_hora as Hora, movp_fecha as Fecha from MovimientosProductos");
            else
                moviP = conexion.Leer("Select id_moviProducto as [Id Movimiento P.], id_producto as [Id Producto], id_empleado as [Id Empleado], movimientos as Movimientos, movp_hora as Hora, movp_fecha as Fecha from MovimientosProductos where id_producto like '%" + control + "%' Or id_empleado like '%" + control + "%' Or movimientos like '%" + control + "%' Or movp_hora like '%" + control + "%' Or movp_fecha like '%" + control + "%'");
            return moviP;
        }
        public DataTable BuscarProduMoviSelector(string control)
        {
            CsConexion conexion = new CsConexion();
            DataTable moviP;
            moviP = conexion.Leer("Select id_moviProducto as [Id Movimiento P.], id_producto as [Id Producto], id_empleado as [Id Empleado], movimientos as Movimientos, movp_hora as Hora, movp_fecha as Fecha from MovimientosProductos where id_producto = '" + control + "'");
            return moviP;
        }
        public DataTable TablaCaja()
        {
            conexion = new CsConexion();
            string comando = "SELECT id_caja AS [ID Caja], fecha_apertura AS [Fecha Apertura], fecha_cierre AS [Fecha Cierre], saldo_inicial AS [Saldo Inicial], saldo_final AS [Saldo Final], id_empleado_apertura AS [ID Empleado Apertura], id_empleado_cierre AS [ID Empleado Cierre] FROM Caja;";
            return conexion.Leer(comando);
        }
        public DataTable TablaCaja(string buscar)
        {
            conexion = new CsConexion();
            string comando = "SELECT id_caja AS [ID Caja], fecha_apertura AS [Fecha Apertura], fecha_cierre AS [Fecha Cierre], saldo_inicial AS [Saldo Inicial], saldo_final AS [Saldo Final], id_empleado_apertura AS [ID Empleado Apertura],id_empleado_cierre AS [ID Empleado Cierre] FROM Caja " +
                "WHERE CAST(id_caja AS NVARCHAR) LIKE '%" + buscar + "%' OR CAST(fecha_apertura AS NVARCHAR) LIKE '%" + buscar + "%' OR CAST(fecha_cierre AS NVARCHAR) LIKE '%" + buscar + "%' OR CAST(saldo_inicial AS NVARCHAR) LIKE '%" + buscar + "%' OR CAST(saldo_final AS NVARCHAR) LIKE '%" + buscar + "%' " +
                "OR CAST(id_empleado_apertura AS NVARCHAR) LIKE '%" + buscar + "%' OR CAST(id_empleado_cierre AS NVARCHAR) LIKE '%" + buscar + "%';";
            return conexion.Leer(comando);
        }
        public DataTable TablaTransacciones()
        {
            conexion = new CsConexion();
            string comando = "SELECT id_transaccion AS [ID Transacción], id_caja AS [ID Caja], tipo_transaccion AS [Tipo Transacción], monto AS [Monto], fecha_hora AS [Fecha y Hora], id_empleado AS [ID Empleado], descripcion AS [Descripción] FROM Transacciones_Caja;";
            return conexion.Leer(comando);
        }
        public DataTable TablaTransacciones(string buscar)
        {
            conexion = new CsConexion();
            string comando = "SELECT id_transaccion AS [ID Transacción], id_caja AS [ID Caja], tipo_transaccion AS [Tipo Transacción], monto AS [Monto], fecha_hora AS [Fecha y Hora], id_empleado AS [ID Empleado], descripcion AS [Descripción] FROM Transacciones_Caja WHERE CAST(id_transaccion AS NVARCHAR) LIKE '%" + buscar + "%' OR CAST(id_caja AS NVARCHAR) LIKE '%" + buscar + "%' OR CAST(tipo_transaccion AS NVARCHAR) LIKE '%" + buscar + "%' OR CAST(monto AS NVARCHAR) LIKE '%" + buscar + "%' OR CAST(fecha_hora AS NVARCHAR) LIKE '%" + buscar + "%' OR CAST(id_empleado AS NVARCHAR) LIKE '%" + buscar + "%' OR CAST(descripcion AS NVARCHAR) LIKE '%" + buscar + "%';";
            return conexion.Leer(comando);
        }
    }
}
