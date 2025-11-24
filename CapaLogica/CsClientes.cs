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
    public class CsClientes
    {
        BdClientes bdClientes = new BdClientes();
        BdEmpleados bdUtilidad = new BdEmpleados();
        public (bool, string) ApellidoCliente(int idusuario)
        {
            string apellido = bdClientes.ApellidoCliente(idusuario);
            if (apellido == string.Empty) return (false, "Cliente no encontrado");
            return (true, apellido);
        }
        // Listar Géneros 
        public DataTable ListarGeneros() => bdClientes.ObtenerDatosMaestros("SP_SL_ListarGeneros", null);

        // Traer Datos de Cliente
        public DataTable TraerDatosCliente(int id)
        {
            var lista = new List<SqlParameter> { new SqlParameter("@IdCliente", id) };
            return bdClientes.ObtenerDatosMaestros("SP_SL_ObtenerClientePorId", lista);
        }

        // GUARDAR 
        public (bool, string) GuardarCliente(int idGenero, string identificacion,
            string apellidos, string nombres, string telefono, string direccion,
            DateTime fechaNac, string correo)
        {
            // Detectar Tipo Documento
            string nombreTipoID = "";
            bool esNumerico = long.TryParse(identificacion, out _);

            if (esNumerico && identificacion.Length == 10) nombreTipoID = "Cédula";
            else if (esNumerico && identificacion.Length == 13) nombreTipoID = "RUC";
            else nombreTipoID = "Pasaporte";

            int idTipoId = bdUtilidad.ObtenerIdTipoPorNombre(nombreTipoID);
            if (idTipoId == 0) return (false, $"Error: No existe el tipo '{nombreTipoID}' en BD.");

            // Guardar
            return bdClientes.RegistrarCliente(idTipoId, idGenero, identificacion, apellidos,
                nombres, telefono, direccion, fechaNac, correo);
        }

        // EDITAR CLIENTE
        public (bool, string) EditarCliente(int idCliente, int idGenero, string identificacion,
            string apellidos, string nombres, string telefono, string direccion,
            DateTime fechaNac, string correo)
        {
            //Recalcular Tipo Documento (por si cambió el documento)
            string nombreTipoID = "";
            bool esNumerico = long.TryParse(identificacion, out _);

            if (esNumerico && identificacion.Length == 10) nombreTipoID = "Cédula";
            else if (esNumerico && identificacion.Length == 13) nombreTipoID = "RUC";
            else nombreTipoID = "Pasaporte";

            int idTipoId = bdUtilidad.ObtenerIdTipoPorNombre(nombreTipoID);

            //Actualizar
            return bdClientes.ActualizarCliente(idCliente, idTipoId, idGenero, identificacion,
                apellidos, nombres, telefono, direccion, fechaNac, correo);
        }
        // Agregar al final de la clase CsClientes
        public DataTable BuscarClientes(string filtro)
        {
            return bdClientes.BuscarClientes(filtro);
        }
    }
}
