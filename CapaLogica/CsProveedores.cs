using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CsProveedores
    {
        BdProveedores bdProveedores;
        int idProveedor;
        string nombre, celular, servicios, direccion, email, estado;
        public int IdProveedor { get { return idProveedor; } set { idProveedor = value; } }
        public string Nombre { get { return nombre; } set { nombre = value; } }
        public string Celular { get { return celular; } set { celular = value; } }
        public string Servicios { get { return servicios; } set { servicios = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Estado { get { return estado; } set { estado = value; } }

        public CsProveedores()
        { // Constructor default
            idProveedor = 0;
            nombre = "";
            celular = "";
            servicios = "";
            direccion = "";
            email = "";
            estado = "";
        }
        public CsProveedores(int idprove, string name, string phone, string servi, string direc, string mail, string stado)
        {
            // Constructor con datos
            idProveedor = idprove;
            nombre = name;
            celular = phone;
            servicios = servi;
            direccion = direc;
            email = mail;
            estado = stado;
        }
        public bool AgregarProveedor() // Metodo para Agregar un Proveedor
        {
            if (Celular == "" || Direccion == "" || Email == "" || Nombre == "" || Servicios == "" || Estado == "")
            {
                //MessageBox.Show("Algunos campos están vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                //conexion.Ingresar_Modificar("Insert into Proveedores (prv_nombre, prv_celular, prv_servicios, prv_direccion, prv_email, prv_estado) Values ('" + Nombre + "', '" + Celular + "', '" + Servicios + "', '" + Direccion + "', '" + Email + "', '" + Estado + "')");
                //MessageBox.Show("Proveedor Agregado Exitosamente :D");
                return true;
            }
        }
        public bool ModificarProveedor() // Metodo para modificar un proveedor
        {
            if (Celular == "" || Direccion == "" || Email == "" || Estado == "")
            {
                //MessageBox.Show("Algunos campos están vacíos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                //conexion.Ingresar_Modificar("Update Proveedores set prv_celular = '" + Celular + "', prv_direccion = '" + Direccion + "', prv_email = '" + Email + "', prv_estado = '" + Estado + "' where id_proveedor = " + IdProveedor);
                //MessageBox.Show("Proveedor Modificado Exitosamente :D");
                return true;
            }
        }
        //public DataTable ConsultaServicios() // Metodo para llenar el combobox de servicios del formulario AgregarProveedor
        //{
        //    DataTable Servicios = conexion.Leer("Select sp_nombre_servicio from Servicios_Proveedores");
        //    return Servicios;
        //}
        // SEGUNDA PARTE - GESTION DE PROVEEDORES - FM GESTIONAR PROVEEDORES
        public DataTable BuscarProveedores(string buscar)
        {
            DataTable VerProveedores;
            bdProveedores = new BdProveedores();
            VerProveedores = bdProveedores.BuscarProveedores(buscar);
            return VerProveedores;
        }
    }
}
