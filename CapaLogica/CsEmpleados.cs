using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CsEmpleados
    {
        BdEmpleados bdempleados = new BdEmpleados();
        // Listados para ComboBox
        public DataTable ListarCargos() => bdempleados.ObtenerDatosMaestros("SP_SL_ListarCargos");
        public DataTable ListarGeneros() => bdempleados.ObtenerDatosMaestros("SP_SL_ListarGeneros");
        public DataTable ListarEmpresas() => bdempleados.ObtenerDatosMaestros("SP_SL_ListarEmpresas");

        public (bool, string) IniciarSesion(string identificador, string contrasena)
        {
            (bool resultado, int idusuario) = bdempleados.IniciarSesion(identificador, contrasena);
            if (idusuario == 0) return (false, "Credenciales incorrectas");
            return (resultado, idusuario.ToString());
        }

        public (bool, string) ApellidoEmpleado (int idusuario)
        {
            string apellido = bdempleados.ApellidoEmpleado(idusuario);
            if (apellido == null) return (false, "Empleado no encontrado");
            return (true,  apellido);
        }
        // Buscar en Grid
        public DataTable BuscarEmpleados(string filtro)
        {
            var lista = new List<SqlParameter> { new SqlParameter("@Filtro", filtro) };
            return bdempleados.ObtenerDatosMaestros("SP_SL_BuscarEmpleados", lista);
        }

        // Traer Datos para Editar
        public DataTable TraerDatosEmpleado(int id)
        {
            var lista = new List<SqlParameter> { new SqlParameter("@IdEmpleado", id) };
            return bdempleados.ObtenerDatosMaestros("SP_SL_ObtenerEmpleadoPorId", lista);
        }
        public (bool, string) GuardarEmpleadoInteligente(int idCargo, int idGenero, int idEmpresa,
                                              string identificacion, string apellidos, string nombres,
                                              string telefono, string direccion, DateTime fechaNac,
                                              DateTime fechaContratacion, string correo)
        {
            // 1. Validaciones básicas
            if (string.IsNullOrWhiteSpace(identificacion)) return (false, "Falta la Identificación.");
            if (string.IsNullOrWhiteSpace(nombres)) return (false, "Falta el Nombre.");
            if (string.IsNullOrWhiteSpace(apellidos)) return (false, "Falta el Apellido.");

            // 2. Lógica de detección de Tipo Documento
            string nombreTipoID = "";
            bool esNumerico = long.TryParse(identificacion, out _);

            if (esNumerico && identificacion.Length == 10)
                nombreTipoID = "Cédula"; // Debe coincidir con tu BD
            else if (esNumerico && identificacion.Length == 13)
                nombreTipoID = "RUC";
            else
                nombreTipoID = "Pasaporte";

            // 3. Obtener el ID oculto desde la BD
            int idTipoId = bdempleados.ObtenerIdTipoPorNombre(nombreTipoID);

            if (idTipoId == 0)
                return (false, $"Error: No se encontró el tipo '{nombreTipoID}' en la base de datos.");

            // 4. Guardar (El estado ya no se envía, se pone en 1 en BD)
            return bdempleados.RegistrarEmpleado(idTipoId, idCargo, idGenero, idEmpresa,
                                                 identificacion, apellidos, nombres, telefono,
                                                 direccion, fechaNac, fechaContratacion, correo);
        }
        // Editar (EXISTENTE)
        public (bool, string) EditarEmpleado(int idEmpleado, int idCargo, int idGenero, int idEmpresa,
                                      string identificacion, string apellidos, string nombres,
                                      string telefono, string direccion, DateTime fechaNac,
                                      DateTime fechaContratacion, string correo, bool estado)
        {
            return bdempleados.ActualizarEmpleado(idEmpleado, idCargo, idGenero, idEmpresa,
                identificacion, apellidos, nombres, telefono, direccion, fechaNac, fechaContratacion, correo, estado);
        }

        public (bool, string) CrearCuenta (string identificacion, string contrasena)
        {
            bdempleados = new BdEmpleados();
            return bdempleados.CrearCuenta(identificacion, contrasena);
        }
    }
}
