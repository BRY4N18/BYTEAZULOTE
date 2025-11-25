using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CsMedicinas
    {
        static Random rnd = new Random(DateTime.Now.Millisecond);
        BdMedicinas bdMedicina;
        // Atributos
        string nombreMedicina, idMedicina, categoria, descripcion, estado, iva;
        int idProveedor;
        double precio;
        // Propiedades
        public string NombreMedicina { get { return nombreMedicina; } set { nombreMedicina = value; } }
        public string IdMedicina { get { return idMedicina; } set { idMedicina = value; } }
        public string Categoria { get { return categoria; } set { categoria = value; } }
        public string Descripcion { get { return descripcion; } set { descripcion = value; } }
        public int IdProveedor { get { return idProveedor; } set { idProveedor = value; } }
        public double Precio { get { return precio; } set { precio = value; } }
        public string Iva { get { return iva; } set { iva = value; } }
        public string Estado { get { return estado; } set { estado = value; } }

        public CsMedicinas() // Constructor default para el fm Agregar Medicina
        {
            nombreMedicina = "";
            idMedicina = "";
            categoria = "";
            descripcion = "";
            estado = "";
            idProveedor = 0;
            precio = -1;
            iva = "";
        }
        // Constructor Con parámetros para el fm AgregarMedicina
        public CsMedicinas(string medi, string idmedi, string categ, string descrip, int idprove, double preci, string iv, string estad)
        {
            nombreMedicina = medi;
            idMedicina = idmedi;
            categoria = categ;
            descripcion = descrip;
            idProveedor = idprove;
            precio = preci;
            iva = iv;
            estado = estad;
        }

        // SEGUNDA PARTE - GESTION DE MEDICINA - FM GESTIONAR MEDICINA

        public DataTable Buscar(string buscar) // Metodo de busqueda
        {
            bdMedicina = new BdMedicinas();
            DataTable VerMedicinas = bdMedicina.BuscarMedicina(buscar);
            return VerMedicinas;
        }
    }
}
