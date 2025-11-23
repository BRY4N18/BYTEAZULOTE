using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace BYTEAZULPROFESIONAL
{
    internal class csEmpleados
    {
        public string IdEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public string Genero { get; set; }
        public string Cargo { get; set; }
        public DateTime FechaDeIngreso { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string Celular { get; set; }
        public string Estado { get; set; }

        CsConexion conexion;
        CsMovimientos movimientos;
        public csEmpleados()
        {
            conexion = new CsConexion();
            movimientos = new CsMovimientos();
        }
        SqlConnection conectar;
        public bool InsertarEmpleado(string nombre, string apellido, string identificador, DateTime fechaNacimiento, string genero, string cargo, DateTime FechaIngreso, string email, string direccion, string celular, string estado)
        {
            string fechaNacimientoFormatted = fechaNacimiento.ToString("yyyy-MM-dd");

            string comando = "INSERT INTO Empleados (em_nombres, em_apellidos, em_identificador, em_fecha_de_nacimiento, em_genero, em_cargo, em_fecha_de_ingreso, em_email, " +
                             "em_direccion, em_celular, em_estado) VALUES ('" + nombre + "', '" + apellido + "', '" + identificador + "', '" + fechaNacimientoFormatted + "', '" +
                             genero + "', '" + cargo + "', GETDATE(), '" + email + "', '" + direccion + "', '" + celular + "', '" + estado + "')";

            if(conexion.Ingresar_Modificar(comando))
            {
                MessageBox.Show("El nuevo empleado se ingresó correctamente al sistema. En espera de 'crear cuenta'");
                movimientos.AccionForms("Se ingreso un nuevo empleado");
                return true;
            }
            else
                return false;
        }
        public bool InsertarAcceso(string idempleado, string contra)
        {
            if (conexion.Ingresar_Modificar("INSERT INTO Acceso (id_empleado, ac_contraseña) VALUES ('" + idempleado + "', '" + contra + "')"))
            {
                movimientos.AccionForms("Nuevo empleado en el sistema");
                return true;
            }
            else
                return false;
        }
        public bool ActualizarAcceso(string idempleado, string cargo)
        {
            if (conexion.Ingresar_Modificar("update Acceso set ac_rol = '" + cargo + "' where id_empleado = " + idempleado + ""))
            {
                return true;
            }
            else
                return false;
        }
        public bool ModificarEmpleado(string direccion, string cargo, string celular, string correo, string estado, string identificador)
        {
            string modi = "UPDATE Empleados SET em_direccion = '" + direccion + "', em_cargo = '" + cargo + "' , em_celular = '" + celular + "' , em_email = '" + correo + "' , em_estado = '" + estado + "' WHERE em_identificador = '" + identificador + "' ";
            if (conexion.Ingresar_Modificar(modi))
            {
                MessageBox.Show("Se actualizaron los datos correctamente");
                movimientos.AccionForms("Datos actualizados en empleado");
                return true;
            }
            else
                return false;
        }
        public string SacarClaveEncriptada(string cedula)
        {
            string modi = "select A.ac_contraseña from Empleados E inner join Acceso A on E.id_empleado = A.id_empleado where E.em_cedula = '" + cedula + "'";
            DataTable ds = conexion.Leer(modi);

            if (ds.Rows.Count > 0)
                return ds.Rows[0]["ac_contraseña"].ToString();
            else
                return null;
        }
        public bool Ingreso(string usu, string contra)
        {

            string sentencia = "Select E.id_empleado as ID, E.em_identificador as Usuario,A.ac_contraseña, E.em_cargo as Cargo, E.em_estado as Estado from Acceso A inner join Empleados E on A.id_empleado=E.id_empleado where E.em_identificador = '" + usu+"' and A.ac_contraseña = '"+contra+"'";
            DataTable Setdat = conexion.Leer(sentencia);
            if (Setdat.Rows.Count == 1)
            {
                IdEmpleado = Setdat.Rows[0]["ID"].ToString().Trim();
                Cargo = Setdat.Rows[0]["Cargo"].ToString().Trim();
                Estado = Setdat.Rows[0]["Estado"].ToString().Trim();
                return true;
            }
            else return false;
        }
        public bool VerificarIdentBD(string identificador)
        {
            // Verificar si la identificacion ya existe en la BD
            string cad = "SELECT * FROM Empleados WHERE em_identificador = '" + identificador + "'";
            DataTable ds = conexion.Leer(cad);

            if (ds.Rows.Count == 0)
                return true;
            else
                return false;
        }
        public string VerificarUsuario(string identificador)
        {
            DataTable ds1 = conexion.Leer("SELECT id_empleado FROM Empleados WHERE em_identificador = '" + identificador + "'");

            if (ds1.Rows.Count > 0)
                return ds1.Rows[0]["id_empleado"].ToString();
            else
                return null;
        }
        public DataTable TablaEmpleados()
        {
            string comando = "SELECT  id_empleado AS [ID Empleado], em_nombres AS Nombres, em_apellidos AS Apellidos, em_identificador AS Identificación, em_fecha_de_nacimiento AS [Fecha de Nacimiento], em_genero AS Género, " +
                            "em_cargo AS Cargo, em_fecha_de_ingreso AS [Fecha de Ingreso], em_email AS Email, em_direccion AS Dirección, em_celular AS Celular, em_estado AS Estado "+
                            "FROM Empleados";
            return conexion.Leer(comando);
        }
        public DataTable TablaEmpleados(string buscar)
        {
            string cad = "SELECT id_empleado AS [ID Empleados], em_nombres AS Nombres, em_apellidos AS Apellidos, em_identificador AS Idntificación, em_fecha_de_nacimiento AS [Fecha de Nacimiento],  em_genero AS Género,   " +
                         " em_cargo AS Cargo,     em_fecha_de_ingreso AS [Fecha de Ingreso],    em_email AS Email,   em_direccion AS Dirección,    em_celular AS Celular, em_estado AS Estado FROM   Empleados WHERE   em_nombres " +
                         "LIKE '%" + buscar + "%' OR  em_apellidos LIKE '%" + buscar + "%' OR em_identificador LIKE '%" + buscar + "%' OR CONVERT(VARCHAR, em_fecha_de_nacimiento, 103) LIKE '%" + buscar + "%' OR  em_genero LIKE '%" 
                         + buscar + "%' OR em_cargo LIKE '%" + buscar + "%' OR CONVERT(VARCHAR, em_fecha_de_ingreso, 103) LIKE '%" + buscar + "%' OR em_email LIKE '%" + buscar + "%' OR em_direccion LIKE '%" + buscar + "%' OR em_celular " +
                         "LIKE '%" + buscar + "%' OR em_estado LIKE '%" + buscar + "%';";
            return conexion.Leer(cad);
        }
        public DataTable Buscar()
        {
            string comando = "Select A.id_usuario as ID, E.em_nombres as Nombre, E.em_apellidos as Apellido, E.em_identificador as usuario, E.em_cargo as Cargo from Acceso A inner join Empleados E on A.id_empleado=E.id_empleado";
            return conexion.Leer(comando);
        }
        public DataTable BuscarUsuario(string buscar)
        {
            string cad = "Select A.id_usuario as ID, E.em_nombres as Nombre, E.em_apellidos as Apellido, E.em_identificador as usuario, E.em_cargo as Cargo " +
                "from Acceso A inner join Empleados E on A.id_empleado=E.id_empleado  where A.id_usuario Like '%"+buscar+ "%'or E.em_nombres like '%"+buscar+ "%' or  E.em_apellidos like '%"+buscar+ "%' or  E.em_identificador like '%"+buscar+ "%' or A.ac_contraseña like '%"+buscar+"%'";
            return conexion.Leer(cad);
        }
        public string SacarIdentificador()
        {
            string identificador = conexion.RetornaConsulta("select em_identificador from Empleados where id_empleado = '" + movimientos.ID() + "'");
            if (identificador != null)
                return identificador;
            return null;
        }

        public string SacarNombreEmpleado(int idempleado)
        {
            string nombre = conexion.RetornaConsulta("select em_apellidos+' '+em_nombres from Empleados where id_empleado = '" + idempleado + "'");
            if (nombre != null)
                return nombre;
            return null;
        }
        public bool ConfirmarContraActual(string id, string antiguaContra)
        {
            DataTable dt = conexion.Leer("select * from Acceso where id_empleado = '" + id + "' and ac_contraseña = '" + antiguaContra + "'");
            if (dt.Rows.Count == 1)
                return true;
            return false;
        }
        public void CambiarContraseña(string id, string nuevacontra)
        {
            if (conexion.Ingresar_Modificar("Update Acceso set ac_contraseña = '" + nuevacontra + "' where id_empleado = '" + id + "'"))
            {
                MessageBox.Show("Nueva contraseña actualizada");
                movimientos.AccionForms("Clave de acceso atualizada");
            }
        }
        public bool VerificarCuenta(string ident)
        {
            DataTable dt = conexion.Leer("select * from Acceso where id_empleado = '" + ident + "'");
            if (dt.Rows.Count == 1)
                return true;
            return false;
        }
    }
}
