using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CsMovimientos
    {
        BdMovimientos bdmovimientos;
        public DataTable ListarMovimientos(string filtro)
        {
            bdmovimientos = new BdMovimientos();
            return bdmovimientos.ListarMovimientos(filtro);
        }
    }
}
