using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CsUnidadMedida
    {
        BdUnidadMedida bdUnidadMedida;
        public (bool, string) AgregarUnidadMedidaProducto(int IdProducto, int IdUnidadMedida, double Precio)
        {
            bdUnidadMedida = new CapaDatos.BdUnidadMedida();
            return bdUnidadMedida.AgregarUnidadMedidaProducto(IdProducto, IdUnidadMedida, Precio);
        }
        public int ObtenerIdUnidadMedidaId(string nombreUnidad)
        {
            bdUnidadMedida = new BdUnidadMedida();
            return bdUnidadMedida.ObtenerIdUnidadMedidaId(nombreUnidad);
        }
        public DataTable ListarUnidadMedidas()
        {
            BdUnidadMedida bdUnidadMedida = new BdUnidadMedida();
            return bdUnidadMedida.ListarUnidadesMedida();
        }
    }
}
