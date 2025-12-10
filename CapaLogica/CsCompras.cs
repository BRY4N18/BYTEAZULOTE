using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaLogica
{
    public class CsCompras
    {
        BdCompra bd = new BdCompra();

        public System.Data.DataTable TraerPresentaciones(int idProducto)
        {
            // Simplemente pasamos la llamada a la capa de datos
            return bd.ListarPresentaciones(idProducto);
        }
        public (bool, string) GuardarCompraCompleta(int idProv, int idEmp, string factura, decimal total, DataTable detalles)
        {
            // PASO 1: REGISTRAR CABECERA (Tabla TbCompras)
            // Esto nos devuelve el ID de la compra creada (ej: 45)
            var respuestaCabecera = bd.RegistrarCompra(idProv, idEmp, factura, total);
            int idCompraGenerado = respuestaCabecera.Item1;
            string mensajeCabecera = respuestaCabecera.Item2;

            // Si el ID es mayor a 0, significa que la cabecera se creó bien
            if (idCompraGenerado > 0)
            {
                bool algunDetalleFallo = false;

                // PASO 2: RECORRER EL GRID (DataTable) Y GUARDAR DETALLES
                foreach (DataRow fila in detalles.Rows)
                {
                    // Extraemos los datos de cada fila del Grid
                    int idProdUnidad = Convert.ToInt32(fila["IdProductoUnidad"]);
                    string lote = fila["Lote"].ToString();
                    DateTime vencimiento = Convert.ToDateTime(fila["Vencimiento"]);
                    decimal cantidad = Convert.ToDecimal(fila["Cantidad"]);
                    decimal precio = Convert.ToDecimal(fila["Precio"]);

                    // Llamamos a BD para guardar este producto específico
                    bool detalleExito = bd.RegistrarDetalle(
                        idCompraGenerado,
                        idProdUnidad,
                        cantidad,
                        precio,
                        lote,
                        vencimiento
                    );

                    if (!detalleExito)
                    {
                        algunDetalleFallo = true;
                    }
                }

                if (algunDetalleFallo)
                {
                    return (false, "La cabecera se creó, pero algunos productos fallaron al guardarse. Revise los datos.");
                }

                // PASO 4: REGISTRAR EGRESO DE CAJA (Restar el dinero)
                // Intentamos descontar el total de la caja del empleado logueado
                bool egresoExito = bd.RegistrarEgresoCaja(idEmp, total, idCompraGenerado);

                string msjFinal = "Compra registrada exitosamente.";

                if (!egresoExito)
                {
                    // Si falló la caja, avisamos, pero la compra ES VÁLIDA.
                    msjFinal += "\nNota: No se pudo descontar el dinero de la Caja (quizás está cerrada o sin saldo), pero el inventario sí se cargó.";
                }

                return (true, msjFinal);
            }
            else
            {
                // Si falló la cabecera (ej: Factura duplicada)
                return (false, "Error al crear la compra: " + mensajeCabecera);
            }
        }

        public DataTable ListarCompras(string estado)
        {
            return bd.ListarCompras(estado);
        }

        public DataTable VerDetalleCompra(int idCompra)
        {
            return bd.VerDetalleCompra(idCompra);
        }

        // 2. APROBAR (SUPERVISOR): Mueve Stock y Dinero
        public (bool, string) AprobarCompra(int idCompra, int idSupervisor, decimal monto)
        {
            return bd.ConfirmarCompra(idCompra, idSupervisor, monto);
        }
    }
}
