using CapaDatos;
using System;
using System.Collections.Generic;
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
    }
}
