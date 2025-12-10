using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BYTEAZULPROFESIONAL
{
    public partial class fmAgregarProveedores : Form
    {
        CsProveedores csProveedores;
        CsMedicinas csMedicinas;
        public fmAgregarProveedores()
        {
            InitializeComponent();
        }

        private void fmAgregarProveedores_Load(object sender, EventArgs e)
        {
            ConfigurarGridServicios();
            CargarListaServicios();
            ConfigurarGridProductos();
            CargarListaProductos();
            cmbEstado.SelectedIndex = 0; // Activo por defecto
        }

        private void ConfigurarGridServicios()
        {
            dgvServicios.AutoGenerateColumns = false;
            dgvServicios.Columns.Clear();

            // Columna ID (Oculta)
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "IdServicio";
            colId.DataPropertyName = "IdServicio"; // Debe coincidir con SQL
            colId.Visible = false;
            dgvServicios.Columns.Add(colId);

            // Columna Servicio
            DataGridViewTextBoxColumn colDoc = new DataGridViewTextBoxColumn();
            colDoc.HeaderText = "Servicio";
            colDoc.DataPropertyName = "Servicio";
            colDoc.Width = 100;
            dgvServicios.Columns.Add(colDoc);

            // Columna Descripcion
            DataGridViewTextBoxColumn colTel = new DataGridViewTextBoxColumn();
            colTel.HeaderText = "Descripcion";
            colTel.DataPropertyName = "Descripcion";
            colTel.Width = 90;
            dgvServicios.Columns.Add(colTel);

            // Columna Estado
            DataGridViewTextBoxColumn colDir = new DataGridViewTextBoxColumn();
            colDir.HeaderText = "Estado";
            colDir.DataPropertyName = "Estado";
            colDir.Width = 150;
            dgvServicios.Columns.Add(colDir);
        }

        private void CargarListaServicios()
        {
            try
            {
                csProveedores = new CsProveedores();
                dgvServicios.DataSource = csProveedores.ListarServicios();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void ConfigurarGridProductos()
        {
            dgvProductos.AutoGenerateColumns = false;
            dgvProductos.Columns.Clear();

            // Columna ID (Oculta)
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "IdProducto";
            colId.DataPropertyName = "IdProducto"; // Debe coincidir con SQL
            colId.Visible = false;
            dgvProductos.Columns.Add(colId);

            // Columna Producto
            DataGridViewTextBoxColumn colProducto = new DataGridViewTextBoxColumn();
            colProducto.HeaderText = "Medicina";
            colProducto.DataPropertyName = "Medicina";
            colProducto.Width = 100;
            dgvProductos.Columns.Add(colProducto);

            // Columna Descripcion
            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
            colDesc.HeaderText = "Descripcion";
            colDesc.DataPropertyName = "Descripcion";
            colDesc.Width = 90;
            dgvProductos.Columns.Add(colDesc);

            // Columna Categoria
            DataGridViewTextBoxColumn colCat = new DataGridViewTextBoxColumn();
            colCat.HeaderText = "Categoria";
            colCat.DataPropertyName = "Categoria";
            colCat.Width = 90;
            dgvProductos.Columns.Add(colCat);

            // Columna Stock
            DataGridViewTextBoxColumn colStock = new DataGridViewTextBoxColumn();
            colStock.HeaderText = "Stock";
            colStock.DataPropertyName = "Stock";
            colStock.Width = 90;
            dgvProductos.Columns.Add(colStock);

            // Columna CostoPromedio
            DataGridViewTextBoxColumn colCosProm = new DataGridViewTextBoxColumn();
            colCosProm.HeaderText = "CostoPromedio";
            colCosProm.DataPropertyName = "CostoPromedio";
            colCosProm.Width = 90;
            dgvProductos.Columns.Add(colCosProm);

            // Columna Precio
            DataGridViewTextBoxColumn colPrecio = new DataGridViewTextBoxColumn();
            colPrecio.HeaderText = "Precio";
            colPrecio.DataPropertyName = "Precio";
            colPrecio.Width = 90;
            dgvProductos.Columns.Add(colPrecio);

            // Columna Estado
            DataGridViewTextBoxColumn colEst = new DataGridViewTextBoxColumn();
            colEst.HeaderText = "EstadoDesc";
            colEst.DataPropertyName = "EstadoDesc";
            colEst.Width = 150;
            dgvProductos.Columns.Add(colEst);
        }

        private void CargarListaProductos()
        {
            try
            {
                csMedicinas = new CsMedicinas();
                dgvProductos.DataSource = csMedicinas.Buscar("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnAgregarProveedor_Click(object sender, EventArgs e)
        {
            try
            {
                csProveedores = new CsProveedores();
                if (txtNombre.Text.Trim() == "" || txtEmail.Text.Trim() == "" || txtCelular.Text.Trim() == "" || txtDireccion.Text.Trim() == "" || txtRUC.Text.Trim() == "")
                {
                    MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if(dgvProductos.SelectedRows.Count == 0 || dgvServicios.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Por favor, seleccione al menos un producto y un servicio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                var resultado = csProveedores.AgregarProveedor(txtNombre.Text.Trim(), txtRUC.Text.Trim(), txtCelular.Text.Trim(), txtDireccion.Text.Trim(), txtEmail.Text.Trim());
                int idProveedor = resultado.Item3;

                // B. RECORRER Y GUARDAR SERVICIOS SELECCIONADOS
                // ---------------------------------------------------------
                foreach (DataGridViewRow row in dgvServicios.SelectedRows)
                {
                    int idServicio = Convert.ToInt32(row.Cells["IdServicio"].Value);
                    csProveedores.AgregarProveedorServicio(idProveedor, idServicio);

                }
                foreach (DataGridViewRow row in dgvProductos.SelectedRows)
                {
                    // Cambia "IdProducto" por el nombre real de tu columna de ID
                    int idProducto = Convert.ToInt32(row.Cells["IdProducto"].Value);
                    csProveedores.AgregarProveedorProducto(idProveedor, idProducto);
                }
                MessageBox.Show("Proveedor agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar proveedor: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void txtRUC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
