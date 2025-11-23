using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BYTEAZULPROFESIONAL
{
    internal class csMedicina
    {
        static Random rnd = new Random(DateTime.Now.Millisecond);
        CsConexion conexion;
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

        public csMedicina() // Constructor default para el fm Agregar Medicina
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
        public csMedicina(string medi, string idmedi, string categ, string descrip, int idprove, double preci, string iv, string estad)
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
        public csMedicina(string categoria)
        {
            Categoria = categoria;
        }
        public DataTable ConsultaCategorias() // Metodo para llenar el combobox de categorías del formulario AgregarMedicina
        {
            conexion = new CsConexion();
            DataTable Categorias = conexion.Leer("Select ca_categoria from Categoria");
            return Categorias;
        }

        public bool AgregarMedicina() // Metodo para Agregar Medicina
        {
            // Control de campos vacios
            if (NombreMedicina == "" || Descripcion == "" || IdProveedor == 0 || Categoria == "" || Iva == "" || Precio == -1 || Estado == "")
                MessageBox.Show("Algunos campos están vacíos");
            else if (Precio <= 0) // Control de cantidades 
                MessageBox.Show("Los valores deben ser mayor 0");
            else
            {
                // Generacion del id de la medicina automaticamente con las primeras 3 letras del nombre + numero random de 3 cifras
                //IdMedicina = (NombreMedicina.Substring(0, 3) + rnd.Next(100, 1000)).ToUpper();
                conexion = new CsConexion();
                // Mando sentencia para hacer la consulta SQL
                conexion.Ingresar_Modificar("Insert into Medicina (id_producto, md_producto, md_categoria, id_proveedor, id_iva, md_descripcion, md_precio_unidad, md_estado) Values ('" + IdMedicina + "', '" + NombreMedicina + "', '" + Categoria + "', '" + IdProveedor + "', '" + Iva + "', '" + Descripcion + "', " + Precio.ToString().Replace(',', '.') + ", '" + Estado + "')");
                return true;
            }
            return false;
        }
        public bool ModificarMedicina() // Metodo para modificar la medicina
        {
            // Control de campos vacios
            if (Descripcion == "" || Categoria == "" || Precio == -1 || Iva == "" || Estado == "")
                MessageBox.Show("Algunos campos están vacíos");
            else if (Precio <= 0) // Control de cantidades 
                MessageBox.Show("Los valores deben ser mayor 0");
            else
            {
                conexion = new CsConexion();
                // Se envia sentencia para modificar la medicina
                conexion.Ingresar_Modificar("Update Medicina set md_categoria = '" + Categoria + "', id_iva = '" + Iva + "', md_descripcion = '" + Descripcion + "', md_precio_unidad = " + Precio.ToString().Replace(',', '.') + ", md_estado = '" + Estado + "' where id_producto = '" + IdMedicina + "'");
                MessageBox.Show("Producto Modificado Exitosamente :D");
                return true;
            }
            return false;
        }

        // SEGUNDA PARTE - GESTION DE MEDICINA - FM GESTIONAR MEDICINA

        public DataTable Buscar(string buscar) // Metodo de busqueda
        {
            conexion = new CsConexion();
            DataTable VerMedicinas;
            if (buscar == "")
                VerMedicinas = conexion.Insertinto("Select M.id_producto Id, M.md_producto Medicina, M.md_categoria Categoria, M.id_proveedor [Id Proveedor], P.prv_nombre [Nombre del proveedor], M.id_iva Iva, M.md_descripcion Descripcion, M.md_precio_unidad [Precio unitario], M.md_estado Estado, sum(l.lt_cantidad) Cantidad from Medicina M left join Lotes L on M.id_producto=L.id_producto inner join Proveedores P on M.id_proveedor=P.id_proveedor group by M.id_producto, M.md_producto, M.md_categoria, M.id_proveedor, M.id_iva, M.md_descripcion, M.md_precio_unidad, M.md_estado, P.prv_nombre");
            else
            {
                VerMedicinas = conexion.Insertinto("Select M.id_producto Id, M.md_producto Medicina, M.md_categoria Categoria, M.id_proveedor [Id Proveedor], P.prv_nombre [Nombre del proveedor], M.id_iva Iva, M.md_descripcion Descripcion, M.md_precio_unidad [Precio unitario], M.md_estado Estado, sum(l.lt_cantidad) Cantidad from Medicina M left join Lotes L on M.id_producto=L.id_producto inner join Proveedores P on M.id_proveedor=P.id_proveedor where M.id_proveedor like '%" + buscar + "%' group by M.id_producto, M.md_producto, M.md_categoria, M.id_proveedor, M.id_iva, M.md_descripcion, M.md_precio_unidad, M.md_estado, P.prv_nombre");
                if (VerMedicinas.Rows.Count == 0)
                {
                    VerMedicinas = conexion.Insertinto("Select M.id_producto Id, M.md_producto Medicina, M.md_categoria Categoria, M.id_proveedor [Id Proveedor], M.id_iva Iva, M.md_descripcion Descripcion, M.md_precio_unidad [Precio unitario], M.md_estado Estado, sum(l.lt_cantidad) Cantidad from Medicina M left join Lotes L on M.id_producto=L.id_producto where M.id_producto like '%" + buscar + "%' Or M.md_producto like '%" + buscar + "%' Or M.md_categoria like '%" + buscar + "%' Or M.md_descripcion like '%" + buscar + "%' Or M.md_estado like '%" + buscar + "%' group by M.id_producto, M.md_producto, M.md_categoria, M.id_proveedor, M.id_iva, M.md_descripcion, M.md_precio_unidad, M.md_estado");
                    if (VerMedicinas.Rows.Count == 0)
                        VerMedicinas = conexion.Insertinto("Select M.id_producto Id, M.md_producto Medicina, M.md_categoria Categoria, M.id_proveedor [Id Proveedor], M.id_iva Iva, M.md_descripcion Descripcion, M.md_precio_unidad [Precio unitario], M.md_estado Estado, sum(l.lt_cantidad) Cantidad from Medicina M left join Lotes L on M.id_producto=L.id_producto where M.md_precio_unidad like '%" + buscar + "%' Or M.id_iva like '%" + buscar + "%' group by M.id_producto, M.md_producto, M.md_categoria, M.id_proveedor, M.id_iva, M.md_descripcion, M.md_precio_unidad, M.md_estado");
                }
            }
            return VerMedicinas;
        }
        public bool AgregarCategoria()//Metodo de agregar categoria
        {
            conexion = new CsConexion();
            if (conexion.Ingresar_Modificar("Insert into Categoria values ('" + Categoria + "')")) return true;
            else return false;
        }
        public string SacarIVA(string codigo)
        {
            conexion = new CsConexion();
            return conexion.RetornaConsulta("select valor_iva from IVA where id_iva = '" + codigo + "'");
        }
    }
}
