using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CsCategorias
    {
        BdCategorias bdCategorias;
        public DataTable ListarCategorias()
        {
            bdCategorias = new BdCategorias();
            return bdCategorias.ListarCategorias("SP_SL_ListarCategorias", null);
        }
        private int ObtenerIdCategoria(string categoria)
        {
            bdCategorias = new BdCategorias();
            return bdCategorias.ObtenerIdCategoria(categoria);
        }
        public (bool, string) AgregarCategoriaProducto(int IdProducto, string cat)
        {
            bdCategorias = new BdCategorias();
            return bdCategorias.AgregarCategoriaProducto(IdProducto, ObtenerIdCategoria(cat));
        }
    }
}
