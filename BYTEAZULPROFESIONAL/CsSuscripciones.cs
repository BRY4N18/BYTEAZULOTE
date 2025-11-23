using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BYTEAZULPROFESIONAL
{
    internal class CsSuscripciones
    {
        CsConexion conexion = new CsConexion();
        CsMovimientos movimientos = new CsMovimientos();
        public CsSuscripciones() { }

        public bool VerificarSuscriptor(string idcliente)
        {
            DataTable dsCaja = conexion.Leer("select * from Suscripciones where id_cliente = '" + idcliente + "'");
            if (dsCaja.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public bool VerificarSuscriptorAldia(string idcliente)
        {
            DataTable dsCaja = conexion.Leer("select * from Suscripciones where id_cliente = '" + idcliente + "' and sc_estado_pago = 'Al dia' and sc_estado_suscripcion = 'Activa'");
            if (dsCaja.Rows.Count > 0)
                return true;
            else
                return false;
        }
        public void VerificarPago()
        {
            string sentencia = "UPDATE Suscripciones SET sc_estado_suscripcion = 'Vencida', sc_estado_pago = 'Atrasada'  WHERE DATEADD(MONTH, 1, sc_fecha_ultimo_pago) < GETDATE() AND (sc_estado_suscripcion <> 'Vencida' or sc_estado_suscripcion <> 'Cancelada');";
            if (conexion.Ingresar_Modificar(sentencia))
                movimientos.AccionForms("Suscripcion actualizada");
        }
        public string MontoSuscripcion(string idcliente)
        {
            return conexion.RetornaConsulta("select sc_monto from Suscripciones where id_cliente = '" + idcliente + "'");
        }
        public void InsertarSuscripcion(string idcliente, string idempleado)
        {
            if (conexion.Ingresar_Modificar("insert into Suscripciones values('" + idcliente + "', '" + idempleado + "', GETDATE(), NUll, GETDATE(),'50.00', 'Al dia', 'Activa')"))
            {
                movimientos.AccionForms("Se registro una suscripcion");
                MessageBox.Show("Suscripción registrada con exito");
            }
        }
        public void ActualizarSuscripcion(string idcliente)
        {
            if (conexion.Ingresar_Modificar("update Suscripciones set sc_fecha_ultimo_pago = getdate(), sc_estado_pago = 'Al dia', sc_estado_suscripcion = 'Activa' where id_suscripcion = '" + idcliente + "'"))
            {
                movimientos.AccionForms("Se actualizo una suscripcion");
                MessageBox.Show("Suscripción actualizada con exito");
            }
        }
        public void CancelarSuscripcion(string idcliente)
        {
            if (conexion.Ingresar_Modificar("UPDATE Suscripciones SET sc_estado_suscripcion = 'Cancelada', sc_fecha_fin = GETDATE(), sc_estado_pago = 'N/A' where id_suscripcion = '" + idcliente + "'"))
            {
                movimientos.AccionForms("Se cancelo una suscripcion");
                MessageBox.Show("Suscripción cancelada con exito");
            }
        }
        public void RenovarSuscripcion(string idcliente)
        {
            if (conexion.Ingresar_Modificar("UPDATE Suscripciones SET sc_estado_suscripcion = 'Activa', sc_estado_pago = 'Al dia', sc_fecha_ultimo_pago = GETDATE() WHERE id_suscripcion = '" + idcliente + "';"))
            {
                movimientos.AccionForms("Se renovo una suscripcion");
                MessageBox.Show("Suscripción renovada con exito");
            }
        }
        public DataTable TablaSuscriptores()
        {
            conexion = new CsConexion();
            string comando = "SELECT id_suscripcion AS [ID Suscripción], id_cliente AS [ID Cliente], id_empleado AS [ID Empleado Responsable], sc_fecha_inicio AS [Fecha de Inicio], sc_fecha_fin AS [Fecha de Finalización], sc_fecha_ultimo_pago AS [Fecha del Último Pago], sc_monto AS [Monto de la Suscripción], sc_estado_pago AS [Estado de Pago], sc_estado_suscripcion AS [Estado de la Suscripcion] FROM Suscripciones;";
            return conexion.Leer(comando);
        }

    }
}
