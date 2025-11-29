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
    public partial class fmAgregarCategorias : Form
    {
        CsMedicinas csmedicina;
        public int idiva = 0;
        public char ingreso = 'I';
        public int idcategoria = 0;
        public fmAgregarCategorias()
        {
            InitializeComponent();
        }

        private void AgregarCategoria()
        {
            try
            {
                if (txtNombreCategoria.Text.Trim().Length > 0 && txtIva.Text.Trim().Length > 0 && txtDescripcion.Text.Trim().Length > 0)
                {
                    csmedicina = new CsMedicinas();
                    (bool resultado, string mensaje) = csmedicina.AgregarCategoria(txtNombreCategoria.Text.Trim(), idiva, txtDescripcion.Text.Trim());
                    MessageBox.Show(mensaje, resultado ? "Éxito" : "Error", MessageBoxButtons.OK, resultado ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                    if (resultado)
                    {
                        txtNombreCategoria.Clear();
                        txtIva.Clear();
                        txtDescripcion.Clear();
                        cmbEstado.SelectedIndex = 0;
                    }
                }
                else MessageBox.Show("Llene todos los campos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ModificarCategoria()
        {
            try
            {
                if (txtNombreCategoria.Text.Trim().Length > 0 && txtIva.Text.Trim().Length > 0 && txtDescripcion.Text.Trim().Length > 0)
                {
                    csmedicina = new CsMedicinas();
                    bool estado = cmbEstado.SelectedIndex == 0 ? true : false;
                    (bool resultado, string mensaje) = csmedicina.ModificarCategoria(idcategoria, txtNombreCategoria.Text.Trim(), txtDescripcion.Text.Trim(),idiva,estado);
                    MessageBox.Show(mensaje, resultado ? "Éxito" : "Error", MessageBoxButtons.OK, resultado ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                    if (resultado) this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            AgregarCategoria();
        }

        private void fmAgregarCategorias_Load(object sender, EventArgs e)
        {
            cmbEstado.SelectedIndex = 0;
            txtIva.Enabled = false;
            cmbEstado.Enabled = false;
            if(ingreso=='M')
            {
                btnModificarCategoria.Enabled = true;
                btnAgregarCategoria.Enabled = false;
                cmbEstado.Enabled = true;
            }
            else btnModificarCategoria.Enabled = false;
        }

        private void btnBuscarIva_Click(object sender, EventArgs e)
        {
            fmIvas fmiva = new fmIvas();
            this.AddOwnedForm(fmiva);
            fmiva.ShowDialog();
        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            ModificarCategoria();
        }
    }
}
