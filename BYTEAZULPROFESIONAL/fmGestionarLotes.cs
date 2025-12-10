using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace BYTEAZULPROFESIONAL
{
    public partial class fmGestionarLotes : Form
    {
        CsCompras logica = new CsCompras();
        public int IdSupervisorLogueado;
        public fmGestionarLotes()
        {
            InitializeComponent();
        }

        private void ConfigurarGridCompras()
        {
            dgvCompras.AutoGenerateColumns = false;
            dgvCompras.Columns.Clear();

            // 1. ID (Oculto)
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "colId";
            colId.DataPropertyName = "IdCompra"; // Viene del SQL
            colId.Visible = false;
            dgvCompras.Columns.Add(colId);

            // 2. Factura
            DataGridViewTextBoxColumn colFac = new DataGridViewTextBoxColumn();
            colFac.HeaderText = "N° Factura";
            colFac.DataPropertyName = "NumFactura";
            colFac.Width = 100;
            dgvCompras.Columns.Add(colFac);

            // 3. Proveedor
            DataGridViewTextBoxColumn colProv = new DataGridViewTextBoxColumn();
            colProv.HeaderText = "Proveedor";
            colProv.DataPropertyName = "Proveedor";
            colProv.Width = 180;
            dgvCompras.Columns.Add(colProv);

            // 4. Total
            DataGridViewTextBoxColumn colTotal = new DataGridViewTextBoxColumn();
            colTotal.HeaderText = "Total ($)";
            colTotal.DataPropertyName = "TotalCompra";
            colTotal.Width = 80;
            colTotal.DefaultCellStyle.Format = "C2"; // Formato Moneda
            dgvCompras.Columns.Add(colTotal);

            // 5. Usuario
            DataGridViewTextBoxColumn colUsu = new DataGridViewTextBoxColumn();
            colUsu.HeaderText = "Registrado Por";
            colUsu.DataPropertyName = "RegistradoPor";
            colUsu.Width = 120;
            dgvCompras.Columns.Add(colUsu);

            // 6. Estado Descripción (Texto: "PENDIENTE REVISIÓN")
            DataGridViewTextBoxColumn colEstDesc = new DataGridViewTextBoxColumn();
            colEstDesc.Name = "colEstadoDesc"; // Para buscarla luego en los colores
            colEstDesc.HeaderText = "Estado";
            colEstDesc.DataPropertyName = "EstadoDesc";
            colEstDesc.Width = 120;
            dgvCompras.Columns.Add(colEstDesc);

            // 7. Código Estado (Oculto: 'R' o 'C')
            DataGridViewTextBoxColumn colEstCod = new DataGridViewTextBoxColumn();
            colEstCod.Name = "colEstadoCod";
            colEstCod.DataPropertyName = "Estado";
            colEstCod.Visible = false;
            dgvCompras.Columns.Add(colEstCod);

            // 8. BOTÓN DE ACCIÓN (APROBAR)
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
            btn.Name = "btnAccion"; // Nombre interno del botón
            btn.HeaderText = "Acción";
            btn.Text = "APROBAR";
            btn.UseColumnTextForButtonValue = true;
            btn.Width = 100;
            btn.FlatStyle = FlatStyle.Popup;
            btn.DefaultCellStyle.BackColor = Color.LightGray;
            dgvCompras.Columns.Add(btn);

            // Estilos Generales
            dgvCompras.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCompras.AllowUserToAddRows = false;
            dgvCompras.ReadOnly = true;
            dgvCompras.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ConfigurarGridDetalles()
        {
            dgvDetalles.AutoGenerateColumns = false;
            dgvDetalles.Columns.Clear();

            // Producto
            DataGridViewTextBoxColumn colProd = new DataGridViewTextBoxColumn();
            colProd.HeaderText = "Producto";
            colProd.DataPropertyName = "Producto";
            colProd.Width = 200;
            dgvDetalles.Columns.Add(colProd);

            // Lote
            DataGridViewTextBoxColumn colLote = new DataGridViewTextBoxColumn();
            colLote.HeaderText = "Lote Físico";
            colLote.DataPropertyName = "NumeroLote";
            colLote.Width = 100;
            dgvDetalles.Columns.Add(colLote);

            // Vencimiento
            DataGridViewTextBoxColumn colVence = new DataGridViewTextBoxColumn();
            colVence.HeaderText = "Vencimiento";
            colVence.DataPropertyName = "FechaCaducidad";
            colVence.Width = 100;
            colVence.DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvDetalles.Columns.Add(colVence);

            // Cantidad
            DataGridViewTextBoxColumn colCant = new DataGridViewTextBoxColumn();
            colCant.HeaderText = "Cantidad";
            colCant.DataPropertyName = "CantidadComprada";
            colCant.Width = 80;
            dgvDetalles.Columns.Add(colCant);

            // Subtotal
            DataGridViewTextBoxColumn colSub = new DataGridViewTextBoxColumn();
            colSub.HeaderText = "Subtotal";
            colSub.DataPropertyName = "Subtotal";
            colSub.Width = 80;
            colSub.DefaultCellStyle.Format = "C2";
            dgvDetalles.Columns.Add(colSub);

            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalles.AllowUserToAddRows = false;
            dgvDetalles.ReadOnly = true;
            dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void CargarLista(string busqueda)
        {
            try
            {
                dgvCompras.DataSource = logica.ListarCompras(busqueda);
                dgvDetalles.DataSource = null; // Limpiar detalles al recargar
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando lista: " + ex.Message);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarLista(txtBuscar.Text);
        }

  
        private void fmGestionarLotes_Load(object sender, EventArgs e)
        {
            ConfigurarGridCompras();
            ConfigurarGridDetalles();
                                                                        

            CargarLista("");
        }

        private void dgvCompras_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Validar que no sea el encabezado (-1)
            if (e.RowIndex >= 0)
            {
                try
                {
                    // 2. Obtener el ID usando el nombre "colId" que le pusimos en ConfigurarGrid
                    int id = Convert.ToInt32(dgvCompras.Rows[e.RowIndex].Cells["colId"].Value);

                    // 3. Cargar
                    dgvDetalles.DataSource = logica.VerDetalleCompra(id);
                }
                catch (Exception ex)
                {
                    // Si sale error aquí, es porque la columna no se llama "colId"
                    MessageBox.Show("Error al seleccionar: " + ex.Message);
                }
            }
        }

        private void dgvCompras_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int id = Convert.ToInt32(dgvCompras.Rows[e.RowIndex].Cells["colId"].Value);
                dgvDetalles.DataSource = logica.VerDetalleCompra(id);
            }
        }

        private void dgvCompras_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificamos si la columna clicada es el botón "btnAccion"
            if (dgvCompras.Columns[e.ColumnIndex].Name == "btnAccion" && e.RowIndex >= 0)
            {
                string estado = dgvCompras.Rows[e.RowIndex].Cells["colEstadoCod"].Value.ToString();

                if (estado == "C")
                {
                    MessageBox.Show("Esta compra ya fue aprobada.");
                    return;
                }

                // Datos para el mensaje
                int id = Convert.ToInt32(dgvCompras.Rows[e.RowIndex].Cells["colId"].Value);
                // "Cells[3]" o buscar por nombre si usaste DataPropertyName
                decimal total = Convert.ToDecimal(dgvCompras.Rows[e.RowIndex].Cells[3].Value);

                DialogResult r = MessageBox.Show($"¿Desea APROBAR este ingreso?\nSe descontarán ${total} de caja.",
                    "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    var res = logica.AprobarCompra(id, IdSupervisorLogueado, total);
                    MessageBox.Show(res.Item2);
                    if (res.Item1)
                    {
                        CargarLista(txtBuscar.Text.Trim()); // Recargar Grid
                    }
                }
            }
        }

        private void dgvCompras_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            // 1. Pintar filas PENDIENTES de Amarillo
            if (dgvCompras.Columns[e.ColumnIndex].Name == "colEstadoDesc")
            {
                if (e.Value != null && e.Value.ToString().Contains("PENDIENTE"))
                {
                    e.CellStyle.BackColor = Color.LightYellow;
                    e.CellStyle.ForeColor = Color.DarkOrange;
                    e.CellStyle.Font = new Font(dgvCompras.Font, FontStyle.Bold);
                }
                else
                {
                    e.CellStyle.BackColor = Color.LightGreen;
                    e.CellStyle.ForeColor = Color.DarkGreen;
                }
            }

            // 2. Cambiar Texto del Botón (APROBAR vs OK)
            if (dgvCompras.Columns[e.ColumnIndex].Name == "btnAccion")
            {
                // Obtenemos el valor de la celda oculta de estado
                string estado = dgvCompras.Rows[e.RowIndex].Cells["colEstadoCod"].Value.ToString();

                DataGridViewButtonCell btn = (DataGridViewButtonCell)dgvCompras.Rows[e.RowIndex].Cells["btnAccion"];

                if (estado == "C")
                {
                    btn.UseColumnTextForButtonValue = false;
                    btn.Value = "OK"; // Ya aprobado
                }
                else
                {
                    btn.UseColumnTextForButtonValue = false;
                    btn.Value = "APROBAR"; // Pendiente
                }
            }
        }
    }
}
