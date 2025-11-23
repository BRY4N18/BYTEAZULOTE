using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaLogica
{
    public class CsEmpleados
    {
        BdEmpleados bdempleados;
        public (bool, string) IniciarSesion(string identificador, string contrasena)
        {
            bdempleados = new BdEmpleados();
            (bool resultado, int idusuario) = bdempleados.IniciarSesion(identificador, contrasena);
            if (idusuario == 0) return (false, "Credenciales incorrectas");
            return (resultado, idusuario.ToString());
        }

        public (bool, string) ApellidoEmpleado (int idusuario)
        {
            bdempleados = new BdEmpleados();
            string apellido = bdempleados.ApellidoEmpleado(idusuario);
            if (apellido == string.Empty) return (false, "Empleado no encontrado");
            return (true,  apellido);
        }
    }
}
