using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CsClientes
    {
        BdClientes bdcliente;
        public (bool, string) ApellidoCliente(int idusuario)
        {
            bdcliente = new BdClientes();
            string apellido = bdcliente.ApellidoCliente(idusuario);
            if (apellido == string.Empty) return (false, "Cliente no encontrado");
            return (true, apellido);
        }
    }
}
