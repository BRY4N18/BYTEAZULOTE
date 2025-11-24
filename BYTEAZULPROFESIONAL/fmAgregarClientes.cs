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
    public partial class fmAgregarClientes : Form
    {
        CsClientes logicaCliente = new CsClientes();
        public int IdClienteEditar = 0;
        public fmAgregarClientes()
        {
            InitializeComponent();
        }

        private void fmAgregarClientes_Load(object sender, EventArgs e)
        {
            CargarCombos();

            if (IdClienteEditar > 0)
            {
                // MODO EDITAR
                this.Text = "Modificar Cliente";
                btnAgregarClientes.Enabled = false;
                btnModificarClientes.Enabled = true;
                // Gestión de Estado
                cmbEstado.Enabled = true;
                CargarDatosParaEditar();
            }
            else
            {
                // MODO NUEVO
                this.Text = "Nuevo Cliente";
                btnAgregarClientes.Enabled = true;
                btnModificarClientes.Enabled = false;
                // Gestión de Estado
                cmbEstado.Enabled = false;
            }
        }
        private void CargarCombos()
        {
            try
            {
                cmbGenero.DataSource = logicaCliente.ListarGeneros();
                cmbGenero.DisplayMember = "Genero";
                cmbGenero.ValueMember = "IdGenero";
                cmbGenero.SelectedIndex = -1;
            }
            catch (Exception ex) { MessageBox.Show("Error cargando géneros: " + ex.Message); }
        }
        private void CargarDatosParaEditar()
        {
            try
            {
                DataTable dt = logicaCliente.TraerDatosCliente(IdClienteEditar);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    txtIdentificacion.Text = row["Identificacion"].ToString();
                    txtNombres.Text = row["Nombres"].ToString();
                    txtApellidos.Text = row["Apellidos"].ToString();
                    txtCelular.Text = row["Telefono"].ToString();
                    txtDireccion.Text = row["Direccion"].ToString();
                    txtEmail.Text = row["Correo"].ToString();

                    if (row["FechaNacimiento"] != DBNull.Value)
                        dtpFechaNacimiento.Value = Convert.ToDateTime(row["FechaNacimiento"]);

                    cmbGenero.SelectedValue = Convert.ToInt32(row["IdGenero"]);
                }
            }
            catch (Exception ex) { MessageBox.Show("Error al cargar datos: " + ex.Message); }
        }

        private void btnAgregarClientes_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            try
            {
                var res = logicaCliente.GuardarCliente(
                    (int)cmbGenero.SelectedValue,
                    txtIdentificacion.Text.Trim(),
                    txtApellidos.Text.Trim(),
                    txtNombres.Text.Trim(),
                    txtCelular.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    dtpFechaNacimiento.Value,
                    txtEmail.Text.Trim()
                );

                MessageBox.Show(res.Item2, "Sistema", MessageBoxButtons.OK, res.Item1 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                if (res.Item1) this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }

        private void btnModificarClientes_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            try
            {
                var res = logicaCliente.EditarCliente(
                    IdClienteEditar,
                    (int)cmbGenero.SelectedValue,
                    txtIdentificacion.Text.Trim(),
                    txtApellidos.Text.Trim(),
                    txtNombres.Text.Trim(),
                    txtCelular.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    dtpFechaNacimiento.Value,
                    txtEmail.Text.Trim()
                );

                MessageBox.Show(res.Item2, "Sistema", MessageBoxButtons.OK, res.Item1 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);
                if (res.Item1) this.Close();
            }
            catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
        }
        private bool ValidarFormulario()
        {
            if (cmbGenero.SelectedValue == null)
            {
                MessageBox.Show("Seleccione el Género.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIdentificacion.Text) || string.IsNullOrWhiteSpace(txtNombres.Text))
            {
                MessageBox.Show("Identificación y Nombre son obligatorios.", "Faltan datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DateTime fechaNac = dtpFechaNacimiento.Value;

            if (fechaNac.Date > DateTime.Today)
            {
                MessageBox.Show("La fecha de nacimiento no puede ser futura.", "Fecha Incorrecta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            int edad = DateTime.Today.Year - fechaNac.Year;

            if (fechaNac.Date > DateTime.Today.AddYears(-edad))
                edad--;

            if (edad < 18)
            {
                MessageBox.Show($"El cliente tiene {edad} años.\nPara fines de facturación debe ser mayor de edad (18+).",
                                "Menor de Edad", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
