using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CsCaja
    {
        BdCaja bdCaja = new BdCaja();

        // 1. MÉTODO PARA ABRIR (Lo usa tu formulario pequeño)
        public (bool, string) AbrirCaja(int idEmpleado, string montoTexto)
        {
            // Validamos que sea un número válido
            if (!decimal.TryParse(montoTexto, out decimal montoInicial))
            {
                return (false, "El monto inicial debe ser un número válido.");
            }

            if (montoInicial < 0)
            {
                return (false, "El monto no puede ser negativo.");
            }

            return bdCaja.AbrirCaja(idEmpleado, montoInicial);
        }

        // 2. MÉTODO "GUARDIÁN" (Dice si puede o no entrar a ventas)
        public bool EstaCajaAbierta(int idEmpleado)
        {
            // Si devuelve ID > 0 es True (Abierta), si es 0 es False (Cerrada)
            return bdCaja.ObtenerSesionAbierta(idEmpleado) > 0;
        }

        public (bool, string) GenerarVenta (int idempleado, int idcliente, decimal totalventa, DataTable detallescompras)
        {
            try
            {
                bdCaja = new BdCaja();
                int idventa = 0;
                bool resultado;
                string mensaje;
                (idventa, resultado, mensaje) = bdCaja.GuardarVenta(idcliente, idempleado, totalventa);

                if (!resultado)
                {
                    return (false, mensaje);
                }

                bool resultadoDetalles;
                string mensajeDetalles;
                foreach (DataRow fila in detallescompras.Rows)
                {
                    int idproducto = Convert.ToInt32(fila["Id Producto"]);
                    int cantidad = Convert.ToInt32(fila["Cantidad"]);
                    decimal preciounitario = Convert.ToDecimal(fila["Precio Unitario"]);

                    (resultadoDetalles, mensajeDetalles) = bdCaja.GuardarDetallesVenta(idventa, idproducto, cantidad, preciounitario);
                    if (!resultadoDetalles)
                    {
                        return (false, mensajeDetalles);
                    }
                }

                return (true, "Venta generada exitosamente");
            }
            catch (Exception)
            {
                return (false, "Error al generar la venta");
            } 
        }
    }
}
