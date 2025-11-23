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
    internal class CsCaja
    {
        CsConexion conexion;
        CsEmail correo;
        CsMovimientos movimientos = new CsMovimientos();
        CsLotes Lotes = new CsLotes();
        string idp, producto, pre, fech, cli, empleado,idlo;
        int canti;
        double ivita, total;
        public string IdProducto { get { return idp; } set { idp = value; } }
        public string Nomproducto { get { return producto; } set { producto = value; } }
        public string Precio { get { return pre; } set { pre = value; } }
        public int Cantidad { get { return canti; } set { canti = value; } }
        public string Fecha { get { return fech; } set { fech = value; } }
        public string Cliente { get { return cli; } set { cli = value; } }
        public string Empleado { get { return empleado; } set { empleado = value; } }
        public double IVA { get { return ivita; } set { ivita = value; } }
        public string LoteID { get { return idlo; } set { idlo = value; } }
        public double TOTAL { get { return total; } set { total = value; } }

        public CsCaja()//constructor default 
        {
            idp = "";
            producto = "";
            pre = "";
            canti = 0;
            fech = "";
            cli = "";
            empleado = "";
        }
        public CsCaja(string id, double to)//Constructor para hacer generar la factura
        {
            cli = id;
            empleado = movimientos.ID();
            total = to;
        }
        public CsCaja(int ca,string idproductito)//Constructor para descontar la cantidad comprada de los lotes y devolver cantidad
        {
            canti = ca;
            IdProducto = idproductito;        
        }
        public CsCaja(string id, string nom, string prec, int ca, string fe, string clie, string em) //constructor que reciba todo los parametros
        {
            idp = id;
            producto = nom;
            pre = prec;
            canti = ca;
            fech = fe;
            cli = clie;
            empleado = em;
        }
        public string descontar()
        {
            string[] idlote;
            string loid = null;
            DateTime[] datim;
            int[] cant;
            int can = Cantidad, cont = 0, cint = 0;
            try
            {
                conexion = new CsConexion();
                string cadena = "Select id_lote,lt_fecha_caducidad,lt_cantidad from Lotes where id_producto = '" + IdProducto + "'";
                DataTable setda = conexion.Leer(cadena);
                idlote = new string[setda.Rows.Count];
                datim = new DateTime[setda.Rows.Count];
                cant = new int[setda.Rows.Count];
                for (int i = 0; i < setda.Rows.Count; i++)
                {
                    idlote[i] = setda.Rows[i]["id_lote"].ToString();
                    datim[i] = DateTime.Parse(setda.Rows[i]["lt_fecha_caducidad"].ToString());
                    cant[i] = int.Parse(setda.Rows[i]["lt_cantidad"].ToString());
                }
                DateTime[] aux = datim;
                Array.Sort(aux);
                bool sal = true;
                while (sal)
                {
                    if (aux[cont] >= DateTime.Today)
                    {
                        if (Cantidad <= 0) sal = false;
                        if (aux[cont] == datim[cint])
                        {
                            if (cant[cint] >= Cantidad)
                            {
                                loid = idlote[cint];
                                cant[cint] -= Cantidad;
                                Cantidad = 0;
                            }
                            else if (cant[cint] < Cantidad)
                            {
                                Cantidad = Cantidad - cant[cint];
                                cant[cint] = 0;
                                cint = 0;
                                cont++;
                            }
                        }
                        else cint++;
                    }
                    else cont++;
                }
                for (int i = 0; i < idlote.Length; i++)
                {
                    Lotes = new CsLotes(cant[i], idlote[i]);
                    Lotes.Modificar();                   
                }
                movimientos = new CsMovimientos(IdProducto, can, movimientos.ID());
                movimientos.ConsumirProductos();
                return loid;

            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return null; }
        }
        public bool Generarfactura(DataGridView ventas)
        {
            conexion = new CsConexion();
            movimientos = new CsMovimientos();
            string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"); // Fecha actual con todo y hora
            string idcajafac = IDCaja();
            string idcaja = "";
            if (idcajafac.Length < 4)
            {
               idcaja = "000" + idcajafac;
               idcaja = idcaja.Substring(idcajafac.Length);
            }else idcaja = idcajafac;
            DataTable dt = conexion.Leer("Select * from Ventas");
            string num = (dt.Rows.Count + 1).ToString();
            string numfactura = "000000000"+num.ToString();
            idcajafac = "001-" + idcaja + "-" + numfactura.Substring(num.Length);
            try
            {
                string cadena = "";
                if (Cliente != "") cadena = "Insert into Ventas (vt_fecha_venta,vt_factura,id_cliente, id_empleado, vt_total) Values ('" + fecha + "','" +idcajafac+"',"+Cliente+","+Empleado+",'"+ TOTAL.ToString().Replace(',', '.') + "')";
                else return false;
                if (conexion.Ingresar_Modificar(cadena))
                {                   
                    string idventa =  conexion.RetornaConsulta("Select max(id_venta) As A from Ventas");                  
                    for (int i = 0; i < ventas.Rows.Count; i++)
                    {
                         cadena = "INSERT INTO Detalles_Ventas (id_venta, id_producto,id_lote, cantidad, precio_unitario, subtotal, Estado)" +
                                " VALUES ( "+int.Parse(idventa)+", "+ ventas[1, i].Value.ToString().Trim() + ", " + ventas[0, i].Value.ToString().Trim() +","+int.Parse(ventas[3, i].Value.ToString().Trim()) +","+ventas[4, i].Value.ToString().Trim().Replace(',','.') +", "+ ventas[5, i].Value.ToString().Trim().Replace(',', '.') +", 'Vendido')";
                        conexion.Ingresar_Modificar(cadena);
                    }
                }
                string cuerfactura = "ID\tNOMBRE PRODUCTO\tCANTIDAD\tPRECIO UNITARIO\tPRECIO TOTAL\n";
                cadena = "Select cl_nombre as Nombre, cl_apellido as Apellido,  cl_email As Email from Clientes where id_cliente = '" + Cliente + "'";
                DataTable setda = conexion.Leer(cadena);
                string email = setda.Rows[0]["Email"].ToString().Trim();
                string clnombrecompleto = setda.Rows[0]["Nombre"].ToString().Trim() + " " + setda.Rows[0]["Apellido"].ToString().Trim();
                cadena = "Select em_nombres as Nombres,em_apellidos as Apellidos from Empleados where id_empleado  = '" + movimientos.ID() + "'";
                setda = conexion.Leer(cadena);
                string nomcompleto = setda.Rows[0]["Nombres"].ToString().Trim() + " " + setda.Rows[0]["Apellidos"].ToString().Trim();
                for (int i = 0; i < ventas.Rows.Count; i++)
                {
                    cadena = "Select md_producto As A from Medicina where id_producto ='" + ventas[1, i].Value.ToString().Trim() + "'";
                    cuerfactura += ventas[1, i].Value.ToString().Trim() + "\t" + conexion.RetornaConsulta(cadena) + "\t" + ventas[3, i].Value.ToString().Trim() + "\t" + ventas[4, i].Value.ToString().Trim() + "\t" + ventas[5, i].Value.ToString().Trim() + "\n";
                }
                correo = new CsEmail();
                correo.Para = email;
                correo.ConCopia = "byte.azul05@gmail.com";
                correo.Asunto = "FACTURA";
                correo.Cuerpo = "Factura: "+ idcajafac + "\nFecha: " + DateTime.Now.ToString().Split(' ')[0] + "\nHora: " + DateTime.Now.ToString().Split(' ')[1] + "\nVendedor: " + nomcompleto + "\nCliente: " + clnombrecompleto + "\n" +cuerfactura + "\nTotal a pagar: " + TOTAL.ToString("F2");
                if (correo.Enviar()) MessageBox.Show("Detalles de ventas enviados al correo");
            }
            catch (Exception ex) { MessageBox.Show(ex.Message.ToString()); return false; }
            return true;
        }
        public bool DevolverProducto(string num)
        {          
        conexion = new CsConexion();
        int ltcantidad = int.Parse(conexion.RetornaConsulta("Select lt_cantidad from Lotes where id_lote = '" + IdProducto + "'"));
        string idpro = conexion.RetornaConsulta("Select id_producto from Lotes where id_lote ='" + IdProducto + "'");
         Cantidad += ltcantidad;
         Lotes = new CsLotes(Cantidad, IdProducto);
            if (Lotes.Modificar())
            {
                movimientos = new CsMovimientos(idpro, Cantidad, movimientos.ID());
                movimientos.AgregarProductos();
                if (num != "NO") conexion.Ingresar_Modificar("Update Detalles_Ventas set Estado ='Devuelto' where id_detalle = "+num);                
                return true;             
            }
        else return false;          
        }
        public void InsertarTransaccion(int idCaja, string tipoTransaccion, decimal monto, int idEmpleado, string descripcion)
        {
            string query = "INSERT INTO Transacciones_Caja (id_caja, tipo_transaccion, monto, fecha_hora, id_empleado, descripcion) " +
                   "VALUES (" + idCaja + ", '" + tipoTransaccion + "', " + monto.ToString("F2", CultureInfo.InvariantCulture) + ", GETDATE(), " + idEmpleado + ", '" + descripcion + "');";

            conexion.Ingresar_Modificar(query);
        }
        public string IDCaja()
        {
            conexion = new CsConexion();
            DataTable ds = conexion.Leer("SELECT TOP 1 id_caja FROM Caja WHERE CAST(fecha_apertura AS DATE) <= CAST(GETDATE() AS DATE) AND fecha_cierre IS NULL ORDER BY fecha_apertura DESC;");
            if (ds.Rows.Count > 0)
            {
                return ds.Rows[0]["id_caja"].ToString();
            }
            return null;
        }
        public decimal ObtenerTotalIngresos(string idcaja)
        {
            conexion = new CsConexion();
            DataTable dsIngresos = conexion.Leer("select SUM(monto) as monto_final from Transacciones_Caja T inner join Caja C on C.id_caja = T.id_caja where C.id_caja = " + idcaja + " and tipo_transaccion = 'Ingreso'");
            if (dsIngresos.Rows.Count > 0 && dsIngresos.Rows[0]["monto_final"] != DBNull.Value)
                return Convert.ToDecimal(dsIngresos.Rows[0]["monto_final"]);
            else
                return 0;
        }
        public decimal ObtenerSaldoIncial(string idcaja)
        {
            conexion = new CsConexion();
            string dssaldo = conexion.RetornaConsulta("select saldo_inicial from Caja where id_caja = '" + idcaja + "'");
            return Convert.ToDecimal(dssaldo);
        }
        public DataTable BuscarVentas(string buscar)
        {
            conexion = new CsConexion();
            string consulta = "Select V.id_venta AS ID, V.vt_factura as Factura,V.vt_fecha_venta as [Fecha de venta], V.id_cliente as [ID Cliente], C.cl_apellido+' '+C.cl_nombre as [Nombre del cliente], V.id_empleado as [ID Empleado], E.em_apellidos+' '+E.em_nombres [Nombres del empleado], V.vt_total as TOTAL from Ventas V inner join Clientes C on V.id_cliente=C.id_cliente inner join Empleados E on V.id_empleado = E.id_empleado " +
                "where V.vt_factura LIKE '%"+buscar+"%' or V.vt_fecha_venta LIKE '%"+buscar+"%' or C.cl_apellido + ' ' + C.cl_nombre LIKE '%"+buscar+ "%' or E.em_apellidos + ' ' + E.em_nombres LIKE '%"+buscar+"%' or vt_total LIKE '%"+buscar+"%'";
            return conexion.Leer(consulta);
        }
        public DataTable Buscar()
        {
            conexion = new CsConexion();
            string consulta = "Select V.id_venta AS ID, V.vt_factura as Factura,V.vt_fecha_venta as [Fecha de venta], V.id_cliente as [ID Cliente], C.cl_apellido+' '+C.cl_nombre as [Nombre del cliente], V.id_empleado as [ID Empleado], E.em_apellidos+' '+E.em_nombres [Nombres del empleado], V.vt_total as TOTAL from Ventas V inner join Clientes C on V.id_cliente=C.id_cliente inner join Empleados E on V.id_empleado = E.id_empleado";
            return conexion.Leer(consulta);
        }
        public DataTable BuscarDetalles(string idventa)
        {
            conexion = new CsConexion();
            string consulta = "Select * from (Select D.id_detalle as ID, D.id_producto as [ID MEDICINA], M.md_producto as Medicina, D.id_lote as [ID Lote], L.lt_fecha_caducidad as [Fecha de caducidad], D.cantidad as Cantidad, D.precio_unitario as [Precio Unitario], D.subtotal as Subtotal, D.Estado " +
                "from Detalles_Ventas D inner join Ventas V on D.id_venta= V.id_venta inner join Medicina M on D.id_producto=M.id_producto inner join Lotes L on D.id_lote=L.id_lote where V.id_venta = " + idventa + ") as X ";
            return conexion.Leer(consulta);
        }
        public DataTable BuscarDetallesVentas(string idventa, string buscar)
        {
            conexion = new CsConexion();
            string consulta = "Select * from (Select D.id_detalle as ID, D.id_producto as [ID MEDICINA], M.md_producto as Medicina, D.id_lote as [ID Lote], L.lt_fecha_caducidad as [Fecha de caducidad], D.cantidad as Cantidad, D.precio_unitario as [Precio Unitario], D.subtotal as Subtotal, D.Estado " +
                "from Detalles_Ventas D inner join Ventas V on D.id_venta= V.id_venta inner join Medicina M on D.id_producto=M.id_producto inner join Lotes L on D.id_lote=L.id_lote where V.id_venta = "+idventa+") as X " +
                "where X.ID Like '%"+buscar+ "%' or X.[ID MEDICINA] LIKE '%"+buscar+ "%' or X.Medicina LIKE '%"+buscar+ "%' or X.[ID Lote] LIKE '%"+buscar+ "%' or X.[Fecha de caducidad] LIKE '%"+buscar+ "%' or X.Cantidad LIKE '%"+buscar+ "%' or X.[Precio Unitario] LIKE '%"+buscar+ "%' or X.Subtotal LIKE '%"+buscar+"%' or X.Estado LIKE '%"+buscar+"%'";
            return conexion.Leer(consulta);
        }
        public double iva()
        {
            conexion = new CsConexion();
            string consulta = "Select I.valor_iva as iva from Medicina M inner join IVA I on M.id_iva=I.id_iva where id_producto = '" + IdProducto + "'";
            return double.Parse(conexion.RetornaConsulta(consulta));
        }
        public decimal ObtenerTotalEgresos(string idcaja)
        {
            conexion = new CsConexion();
            DataTable dsEgresos = conexion.Leer("select SUM(monto) as monto_final from Transacciones_Caja T inner join Caja C on C.id_caja = T.id_caja where C.id_caja = " + idcaja + " and tipo_transaccion = 'Egreso'");
            if (dsEgresos.Rows.Count > 0 && dsEgresos.Rows[0]["monto_final"] != DBNull.Value)
                return Convert.ToDecimal(dsEgresos.Rows[0]["monto_final"]);
            else
                return 0;
        }
        public bool AbrirCaja(string saldoinicial, string id)
        {
            conexion = new CsConexion();
            if (conexion.Ingresar_Modificar("INSERT INTO Caja (fecha_apertura, saldo_inicial, id_empleado_apertura) VALUES (GETDATE(), " + saldoinicial + ", " + id + ");"))
                return true;
            else
                return false;
        }
        public bool CajaAbierta()
        {
            conexion = new CsConexion();
            DataTable dsCaja = conexion.Leer("SELECT * FROM Caja WHERE CAST(fecha_apertura AS DATE) = CAST(GETDATE() AS DATE) AND fecha_cierre IS NULL;");
            if (dsCaja.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public bool InsertarIngresoCaja(string subtotal)
        {
            movimientos = new CsMovimientos();
            csEmpleados empleados = new csEmpleados();

            try
            {
                string idcaja = IDCaja();
                string tipo = "Ingreso";
                string descripcion = "Monto de venta";

                int idCaja = Convert.ToInt32(idcaja);
                decimal monto = Convert.ToDecimal(subtotal);
                int idEmpleado = Convert.ToInt32(movimientos.ID());

                InsertarTransaccion(idCaja, tipo, monto, idEmpleado, descripcion);
                movimientos.AccionForms("Ingreso en caja");
                return true;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }
        public bool InsertarEgresoCaja(string subtotal)
        {
            movimientos = new CsMovimientos();
            csEmpleados empleados = new csEmpleados();
            try
            {
                string idcaja = IDCaja();
                string tipo = "Egreso"; string descripcion = "Monto de compra";

                if (int.TryParse(idcaja, out int idCaja) &&
                    decimal.TryParse(subtotal, out decimal monto) &&
                    int.TryParse(movimientos.ID(), out int idEmpleado))
                {
                    InsertarTransaccion(idCaja, tipo, monto, idEmpleado, descripcion);
                    movimientos.AccionForms("Egreso en caja");
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return false; }
        }
        public void CerrarCaja()
        {
            conexion = new CsConexion(); csEmpleados empleados = new csEmpleados();
            try
            {
                DataTable dsCaja = conexion.Leer("SELECT * FROM Caja WHERE CAST(fecha_apertura AS DATE) = CAST(GETDATE() AS DATE) AND fecha_cierre IS NULL;");
                if (dsCaja.Rows.Count > 0)
                {
                    string idcaja = IDCaja();
                    string id = movimientos.ID();
                    decimal totalIngresos = ObtenerTotalIngresos(idcaja);
                    decimal totalEgresos = ObtenerTotalEgresos(idcaja);
                    decimal saldoinicial = ObtenerSaldoIncial(idcaja);
                    decimal saldofinal = (totalIngresos + saldoinicial) - totalEgresos;

                    DialogResult res = MessageBox.Show("CAJA SE CIERRA CON:\t\t\t\n\nSaldo Inicial: " + saldoinicial.ToString("F2", CultureInfo.InvariantCulture) + "$ \nIngresos: " + totalIngresos.ToString("F2", CultureInfo.InvariantCulture) + "$ \nEgresos: " + totalEgresos.ToString("F2", CultureInfo.InvariantCulture) + "$\nSaldo final: " + saldofinal.ToString("F2", CultureInfo.InvariantCulture) + "$ ", "Confirmación de cierre de caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        string sentenciacaja = "UPDATE Caja SET fecha_cierre = GETDATE(), saldo_final = " + saldofinal.ToString("F2", CultureInfo.InvariantCulture) + ", id_empleado_cierre = " + id + " WHERE id_caja = " + idcaja + ";";
                        if (conexion.Ingresar_Modificar(sentenciacaja))
                            MessageBox.Show("Caja cerrada y actualizada correctamente.");
                        else
                            MessageBox.Show("Error al cerrar y actualizar la caja.");
                    }
                }
                else
                    MessageBox.Show("La caja ya fue cerrada.");
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
    }
}
