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
namespace BYTEAZULPROFESIONAL
{
    public partial class fmGestionarClientes : Form
    {
        CsClientes logica = new CsClientes();
        public fmGestionarClientes()
        {
            InitializeComponent();
        }

        private void dgvVerClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int fila = dgvVerClientes.CurrentCell.RowIndex;
                fmCaja caja = Owner as fmCaja;
                caja.txtIdCliente.Text = dgvVerClientes.Rows[fila].Cells["colId"].Value.ToString();
                caja.txtNombreCliente.Text = dgvVerClientes.Rows[fila].Cells["NombreCliente"].Value.ToString();
                caja.txtNombreCliente.Enabled = false;
                caja.txtIdCliente.Enabled = false;
                this.Hide();
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al seleccionar el cliente: " + ex.Message);
            }
        }

        private void fmGestionarClientes_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarLista("");
        }
        // --- 1. CONFIGURACIÓN DEL GRID (Igual que empleados) ---
        private void ConfigurarGrid()
        {
            dgvVerClientes.AutoGenerateColumns = false;
            dgvVerClientes.Columns.Clear();

            // Columna ID (Oculta)
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "colId";
            colId.DataPropertyName = "IdCliente"; // Debe coincidir con SQL
            colId.Visible = false;
            dgvVerClientes.Columns.Add(colId);

            // Columna Documento
            DataGridViewTextBoxColumn colDoc = new DataGridViewTextBoxColumn();
            colDoc.HeaderText = "Documento";
            colDoc.DataPropertyName = "Identificacion";
            colDoc.Width = 100;
            dgvVerClientes.Columns.Add(colDoc);

            // Columna Nombre Completo
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.Name = "NombreCliente";
            colNombre.HeaderText = "Cliente";
            colNombre.DataPropertyName = "NombreCompleto";
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvVerClientes.Columns.Add(colNombre);

            // Columna Teléfono
            DataGridViewTextBoxColumn colTel = new DataGridViewTextBoxColumn();
            colTel.HeaderText = "Teléfono";
            colTel.DataPropertyName = "Telefono";
            colTel.Width = 90;
            dgvVerClientes.Columns.Add(colTel);

            // Columna Correo
            DataGridViewTextBoxColumn colCorreo = new DataGridViewTextBoxColumn();
            colCorreo.HeaderText = "Correo";
            colCorreo.DataPropertyName = "Correo";
            colCorreo.Width = 150;
            dgvVerClientes.Columns.Add(colCorreo);

            // Columna Dirección (Útil para clientes)
            DataGridViewTextBoxColumn colDir = new DataGridViewTextBoxColumn();
            colDir.HeaderText = "Dirección";
            colDir.DataPropertyName = "Direccion";
            colDir.Width = 150;
            dgvVerClientes.Columns.Add(colDir);

            // Columna Botón Editar
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "btnEditar";
            btnEditar.HeaderText = "Acciones";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            btnEditar.Width = 80;
            btnEditar.FlatStyle = FlatStyle.Popup;
            btnEditar.DefaultCellStyle.BackColor = Color.LightGray;

            dgvVerClientes.Columns.Add(btnEditar);
        }

        private void CargarLista(string filtro)
        {
            try
            {
                dgvVerClientes.DataSource = logica.BuscarClientes(filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarLista(txtBuscar.Text.Trim());
        }

        private void dgvVerClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVerClientes.Columns[e.ColumnIndex].Name == "btnEditar" && e.RowIndex >= 0)
            {
                // Obtenemos el ID de la fila seleccionada
                int idSeleccionado = Convert.ToInt32(dgvVerClientes.Rows[e.RowIndex].Cells["colId"].Value);

                // Abrimos el formulario en modo Editar
                fmAgregarClientes frm = new fmAgregarClientes();
                frm.IdClienteEditar = idSeleccionado; // Pasamos el ID
                frm.ShowDialog();

                // Refrescamos la lista al volver
                CargarLista(txtBuscar.Text.Trim());
            }
        }
    }
}
