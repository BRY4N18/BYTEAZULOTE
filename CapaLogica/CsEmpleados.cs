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
    }
}
