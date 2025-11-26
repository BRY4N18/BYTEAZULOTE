using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CsPrecios
    {
        CapaDatos.BdPrecios bdPrecios;
        public bool AgregarPrecioMedicina(int IdProducto, double Precio)
        {
            bdPrecios = new CapaDatos.BdPrecios();
            return bdPrecios.AgregarPrecioMedicina(IdProducto, Precio);
        }
    }
}
