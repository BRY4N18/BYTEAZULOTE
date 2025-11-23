using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BYTEAZULPROFESIONAL
{
    internal class csClientes
    {
        string id, nombres, apellido, identificacion, celular, direccion, email;
        CsConexion conexion;
        CsMovimientos Movimientos = new CsMovimientos();
        public string Nombres { get { return nombres; } set { nombres = value; } }
        public string Apellidos { get { return apellido; } set { apellido = value; } }
        public string Identificacion { get { return identificacion; } set { identificacion = value; } }
        public string Celular { get { return celular; } set { celular = value; } }
        public string Direccion { get { return direccion; } set { direccion = value; } }
        public string Emails { get { return email; } set { email = value; } }

        public csClientes()
        {
            nombres = "";
            apellido = "";
            identificacion = "";
            celular = "";
            direccion = "";
            email = "";

            conexion = new CsConexion();
            Movimientos = new CsMovimientos();
        }
        public csClientes(string Nombre, string Apellido, string Ident, string Celu, string Direc, string Ema)
        {
            nombres = Nombre;
            apellido = Apellido;
            identificacion = Ident;
            celular = Celu;
            direccion = Direc;
            email = Ema;
        }

        public bool IngresarCliente()
        {
            string ingreso = "Insert into Clientes (cl_nombre, cl_apellido, cl_cedula, cl_celular, cl_email, cl_direccion) values ('" + Nombres + "' , '" +
                              Apellidos + "', '" + Identificacion + "' , '" + Celular + "', '" + Emails + "' , '" + Direccion + "')";
            conexion = new CsConexion();
            if (conexion.Ingresar_Modificar(ingreso))
            {
                MessageBox.Show("El cliente se ingresó correctamente");

                Movimientos.AccionForms("Se Agrego un nuevo cliente");

                return true;
            }
            else { return false; }
        }
        public bool IngresarCliente(string Nombres, string Apellidos, string Ident, string Celular, string Direccion, string Email, string estado)
        {
            string ingreso = "Insert into Clientes (cl_nombre, cl_apellido, cl_identificador, cl_celular, cl_email, cl_direccion, cl_estado) values ('" + Nombres + "' , '" +
                              Apellidos + "', '" + Ident + "' , '" + Celular + "', '" + Email + "' , '" + Direccion + "', '" + estado + "')";

            if (conexion.Ingresar_Modificar(ingreso))
            {
                MessageBox.Show("El cliente se ingresó correctamente");

                Movimientos.AccionForms("Se Agrego un nuevo cliente");

                return true;
            }
            else { return false; }
        }

        public bool ModificarCliente(string Celular, string Direccion, string Email, string Ident, string estado)
        {
            string orden = "UPDATE Clientes SET cl_celular = '" + Celular + "', cl_direccion = '" + Direccion + "' , cl_email = '" + Email
                + "', cl_estado = '" + estado + "' WHERE cl_identificador = '" + Ident + "'";
            if (conexion.Ingresar_Modificar(orden))
            {
                MessageBox.Show("Los datos se actualizaron correctamente");

                Movimientos.AccionForms("Se modificó un cliente");

                return true;
            }
            else { return false; }
        }

        public bool VerificarIdentBD(string identificador)
        {
            // Verificar si la identificacion ya existe en la BD
            string cad = "SELECT * FROM Clientes WHERE cl_identificador = '" + identificador + "'";
            DataTable ds = conexion.Leer(cad);

            if (ds.Rows.Count == 0)
                return true;
            else
                return false;
        }
        public DataTable TablaClientes()
        {
            string consulta = "Select id_cliente AS [ID Cliente], cl_identificador AS Identificación, cl_nombre AS Nombres, cl_apellido AS Apellidos, cl_celular AS Celular, cl_email AS email, cl_direccion AS Dirección, cl_estado AS Estado from Clientes";
            return conexion.Leer(consulta);
        }

        public DataTable TablaClientes(string buscar)
        {
            string consulta = "select id_cliente as [ID Cliente], cl_identificador as Identificación, cl_nombre as Nombres, cl_apellido as Apellidos, cl_celular as Celular, cl_email as Email, cl_direccion as Dirección, cl_estado AS Estado from Clientes where id_cliente like '%" + buscar + "%' or cl_identificador like '%" + buscar + "%' or cl_apellido like '%" + buscar + "%' or cl_celular like '%" + buscar + "%' or cl_email like '%" + buscar + "%' or cl_direccion like '%" + buscar + "%' or cl_estado like '% " + buscar + " %'";
            return conexion.Leer(consulta);
        }
    }
}
