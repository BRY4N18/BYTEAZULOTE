using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace BYTEAZULPROFESIONAL
{
    public partial class fmAgregarMedicina : Form
    {
        CsMedicinas csMedicinas;
        CsPrecios csPrecios;
        CsCategorias csCategorias;
        CsUnidadMedida csUnidadMedida;
        public fmAgregarMedicina()
        {
            InitializeComponent();
            cmbEstado.Enabled = false;
            cmbEstado.SelectedIndex = 0; // Activo por defecto
        }

        private void btnAgregarMedicina_Click(object sender, EventArgs e)
        {
            csMedicinas = new CsMedicinas();
            csPrecios = new CsPrecios();
            int idProducto;
            try
            {
                if (cmbCategoria.SelectedIndex != -1 || cmbUnidadMedida.SelectedIndex != -1)
                {
                    // Lógica para agregar medicina

                    if (txtCantidadMedida.Text.Trim() == "" || txtPrecioMedida.Text.Trim() == "" || txtNombreMedicina.Text.Trim() == "" || txtDescripcion.Text.Trim() == "" || txtPrecio.Text.Trim() == "")
                    {
                        MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    var resultado = csMedicinas.AgregarMedicina(txtNombreMedicina.Text.Trim(), txtDescripcion.Text.Trim());
                    idProducto = csMedicinas.ObtenerUltimoProductoId();

                    var aggPrecio = csPrecios.AgregarPrecioMedicina(idProducto, Convert.ToDouble(txtPrecio.Text.Trim()));

                    var catAgregada = csCategorias.AgregarCategoriaProducto(idProducto, cmbCategoria.Text.Trim());

                    // UNIDADES DE MEDIDA
                    int IdUnidadMedida = csUnidadMedida.ObtenerIdUnidadMedidaId(cmbUnidadMedida.Text.Trim());

                    var UnidadMedidaAgregada = csUnidadMedida.AgregarUnidadMedidaProducto(idProducto, IdUnidadMedida, Convert.ToDouble(txtPrecioMedida.Text.Trim()));

                    MessageBox.Show("Medicina agregada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una categoría.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar medicina: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void CargarCategorias()
        {
            csCategorias = new CsCategorias();
            try
            {
                cmbCategoria.DataSource = csCategorias.ListarCategorias();
                cmbCategoria.DisplayMember = "Categoria";
                cmbCategoria.ValueMember = "IdCategoria";
                cmbCategoria.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Error cargando categorías: " + ex.Message); }
        }
        private void CargarUnidadMedidas()
        {
            csUnidadMedida = new CsUnidadMedida();
            try
            {
                cmbUnidadMedida.DataSource = csUnidadMedida.ListarUnidadMedidas();
                cmbUnidadMedida.DisplayMember = "NombreUnidad";
                cmbUnidadMedida.ValueMember = "IdUnidadMedida";
                cmbUnidadMedida.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Error cargando unidades de medida: " + ex.Message); }
        }

        private void fmAgregarMedicina_Load(object sender, EventArgs e)
        {
            CargarCategorias();
            CargarUnidadMedidas();
        }

        private void txtPrecioMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 1. Permitir números, borrar y el punto decimal (ASCII 46)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // 2. Evitar que pongan doble punto (ej: 10.5.5)
            // Preguntamos si ya existe un punto en el texto y si la tecla presionada es otro punto
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCantidadMedida_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 1. Permitir números, borrar y el punto decimal (ASCII 46)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 1. Permitir números, borrar y el punto decimal (ASCII 46)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // 2. Evitar que pongan doble punto (ej: 10.5.5)
            // Preguntamos si ya existe un punto en el texto y si la tecla presionada es otro punto
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
