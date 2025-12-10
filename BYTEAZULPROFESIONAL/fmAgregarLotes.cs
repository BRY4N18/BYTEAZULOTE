using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace BYTEAZULPROFESIONAL
{
    public partial class fmAgregarLotes : Form
    {
        CsCompras logicaCompra = new CsCompras();
        CsProveedores logicaProveedores = new CsProveedores();
        CsMedicinas logicaMedicina = new CsMedicinas();

        private int _idProveedorActual = 0;
        private int _idProductoActual = 0;
        public int IdEmpleadoLogueado;

        DataTable dtDetalle;

        public fmAgregarLotes()
        {
            InitializeComponent();
        }
        private void LimpiarTotales()
        {
            txtPrecioSubtotal.Text = "0.00";
            txtTotalIva.Text = "0.00";
            txtTotalPagar.Text = "0.00";
            txtEmpleado.Text = IdEmpleadoLogueado.ToString();
        }

        // 1. CONFIGURAR GRID (CARRITO)
        private void ConfigurarGrid()
        {
            dtDetalle = new DataTable();

            // Columnas ID (Ocultas)
            dtDetalle.Columns.Add("IdProducto", typeof(int));
            dtDetalle.Columns.Add("IdProductoUnidad", typeof(int));
            dtDetalle.Columns.Add("TasaIva", typeof(decimal)); 

            // Columnas Visibles
            dtDetalle.Columns.Add("Producto", typeof(string));
            dtDetalle.Columns.Add("Presentacion", typeof(string));
            dtDetalle.Columns.Add("Lote", typeof(string));
            dtDetalle.Columns.Add("Vencimiento", typeof(DateTime));
            dtDetalle.Columns.Add("Cantidad", typeof(decimal));
            dtDetalle.Columns.Add("Precio", typeof(decimal));
            dtDetalle.Columns.Add("MontoIva", typeof(decimal)); 
            dtDetalle.Columns.Add("Subtotal", typeof(decimal)); 

            dgvCompra.DataSource = dtDetalle;

            // Ocultamos IDs
            dgvCompra.Columns["IdProducto"].Visible = false;
            dgvCompra.Columns["IdProductoUnidad"].Visible = false;
            dgvCompra.Columns["TasaIva"].Visible = false;

            // Formatos
            dgvCompra.Columns["Precio"].DefaultCellStyle.Format = "C2";
            dgvCompra.Columns["MontoIva"].DefaultCellStyle.Format = "C2";
            dgvCompra.Columns["Subtotal"].DefaultCellStyle.Format = "C2"; // Base Imponible
            dgvCompra.Columns["Vencimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";

            dgvCompra.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Columna botón ELIMINAR
            DataGridViewButtonColumn colEliminar = new DataGridViewButtonColumn();
            colEliminar.Name = "ColEliminar";
            colEliminar.HeaderText = "Acción";
            colEliminar.Text = "Quitar";
            colEliminar.UseColumnTextForButtonValue = true;
            colEliminar.Width = 70;
            colEliminar.FlatStyle = FlatStyle.Popup;

            dgvCompra.Columns.Add(colEliminar);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones
            if (_idProductoActual == 0) { MessageBox.Show("Seleccione un producto."); return; }
            if (cmbPresentacion.SelectedValue == null) { MessageBox.Show("Seleccione presentación."); return; }
            if (string.IsNullOrWhiteSpace(txtLote.Text)) { MessageBox.Show("Ingrese el Lote."); return; }
            if (dtpFechaCaducidad.Value < DateTime.Today) { MessageBox.Show("El producto está vencido."); return; }

            decimal cant, precio;
            if (!decimal.TryParse(txtCantidad.Text, out cant) || cant <= 0) { MessageBox.Show("Cantidad inválida"); return; }
            if (!decimal.TryParse(txtPrecio.Text, out precio) || precio <= 0) { MessageBox.Show("Precio inválido"); return; }

            decimal baseImponible = cant * precio;

            decimal porcentajeIva = logicaMedicina.ObtenerIvaProducto(_idProductoActual);

            decimal dineroIva = baseImponible * porcentajeIva;

            DataRow row = dtDetalle.NewRow();
            row["IdProducto"] = _idProductoActual;
            row["IdProductoUnidad"] = cmbPresentacion.SelectedValue;
            row["Producto"] = txtNombreProducto.Text;
            row["Presentacion"] = cmbPresentacion.Text;
            row["Lote"] = txtLote.Text.ToUpper();
            row["Vencimiento"] = dtpFechaCaducidad.Value;
            row["Cantidad"] = cant;
            row["Precio"] = precio;
            row["Subtotal"] = baseImponible; 
            row["TasaIva"] = porcentajeIva;
            row["MontoIva"] = dineroIva;   

            dtDetalle.Rows.Add(row);

            CalcularTotalesGlobales();

            LimpiarCamposProducto();
        }
        private void CargarPresentaciones(int idProd)
        {
            cmbPresentacion.DataSource = logicaCompra.TraerPresentaciones(idProd);
            cmbPresentacion.DisplayMember = "Descripcion";
            cmbPresentacion.ValueMember = "IdProductoUnidad";
        }
        private void CalcularTotalesGlobales()
        {
            decimal sumaBase = 0;
            decimal sumaImpuestos = 0;

            foreach (DataRow fila in dtDetalle.Rows)
            {
                sumaBase += Convert.ToDecimal(fila["Subtotal"]);
                sumaImpuestos += Convert.ToDecimal(fila["MontoIva"]);
            }

            decimal totalPagar = sumaBase + sumaImpuestos;

            txtPrecioSubtotal.Text = sumaBase.ToString("N2");
            txtTotalIva.Text = sumaImpuestos.ToString("N2");
            txtTotalPagar.Text = totalPagar.ToString("N2");
        }
        private void btnBuscarIDProducto_Click(object sender, EventArgs e)
        {
            fmGestionarMedicina buscador = new fmGestionarMedicina();
            buscador.ModoSeleccion = true;

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                _idProductoActual = buscador.IdRetorno;
                txtNombreProducto.Text = buscador.NombreRetorno;

                txtPrecio.Text = buscador.PrecioRetorno.ToString("N2");

                CargarPresentaciones(_idProductoActual);

                decimal tasa = logicaMedicina.ObtenerIvaProducto(_idProductoActual);

                txtIVA.Text = (tasa * 100).ToString("0") + " %";
                txtLote.Focus();
            }
        }

        private void btnBuscarIDProveedor_Click(object sender, EventArgs e)
        {
            fmGestionarProveedores buscador = new fmGestionarProveedores();

            buscador.ModoSeleccion = true;

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                _idProveedorActual = buscador.IdRetorno;
                txtProveedor.Text = buscador.NombreRetorno;
                txtNumFactura.Focus();
            }
        }

        private void fmAgregarLotes_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            LimpiarTotales();
        }
        private void LimpiarCamposProducto()
        {
            txtLote.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            txtNombreProducto.Clear();
            _idProductoActual = 0;
            cmbPresentacion.DataSource = null;
        }

        private void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            if (_idProveedorActual == 0) { MessageBox.Show("Falta el proveedor."); return; }
            if (!txtNumFactura.MaskFull) { MessageBox.Show("Número de factura incompleto."); return; }
            if (dtDetalle.Rows.Count == 0) { MessageBox.Show("El carrito está vacío."); return; }

            try
            {
                var resultado = logicaCompra.GuardarCompraCompleta(
                    _idProveedorActual,
                    IdEmpleadoLogueado,
                    txtNumFactura.Text,
                    Convert.ToDecimal(txtTotalPagar.Text),
                    dtDetalle
                );

                MessageBox.Show(resultado.Item2); 

                if (resultado.Item1) 
                    this.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error crítico: " + ex.Message);
            }
        }

        private void dgvCompra_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvCompra.Columns[e.ColumnIndex].Name == "ColEliminar")
            {
                var resp = MessageBox.Show("¿Deseas quitar este producto?",
                                           "Confirmar",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);

                if (resp == DialogResult.Yes)
                {
                    DataRowView drv = dgvCompra.Rows[e.RowIndex].DataBoundItem as DataRowView;
                    if (drv != null)
                        drv.Row.Delete();
                    else
                        dgvCompra.Rows.RemoveAt(e.RowIndex);

                    CalcularTotalesGlobales();
                }
            }
        }
    }
}
