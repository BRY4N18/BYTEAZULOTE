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
        DataTable dtMedicinas;
        DataTable dtServicios;
        public fmAgregarProveedores()
        {
            InitializeComponent();
        }

        private void fmAgregarProveedores_Load(object sender, EventArgs e)
        {
            dgvProductos.DataSource = CargarProductos();
            dgvServicios.DataSource = CargarServicios();
            cmbEstado.SelectedIndex = 0; // Activo por defecto
        }
        private DataTable CargarProductos()
        {
            csMedicinas = new CsMedicinas();
            dtMedicinas = new DataTable();
            dtMedicinas = csMedicinas.Buscar("");
            return dtMedicinas;

        }
        private DataTable CargarServicios()
        {
            csProveedores = new CsProveedores();
            dtServicios = new DataTable();
            dtServicios = csProveedores.ListarServicios();
            return dtServicios;
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
