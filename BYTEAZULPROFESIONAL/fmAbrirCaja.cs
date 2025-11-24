using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BYTEAZULPROFESIONAL
{
    public partial class fmAbrirCaja : Form
    {
        CsCaja logicaCaja = new CsCaja();
        // Variable para recibir el ID del empleado que va a abrir la caja
        public int IdEmpleadoRecibido;

        public fmAbrirCaja()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e) { this.Close(); }

        private void fmAbrirCaja_Load(object sender, EventArgs e)
        {
            // Ponemos un valor por defecto y el foco para escribir rápido
            txtSueldoInicial.Text = "0.00";
            txtSueldoInicial.SelectAll();
            txtSueldoInicial.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validar que el monto no esté vacío
                if (string.IsNullOrWhiteSpace(txtSueldoInicial.Text))
                {
                    MessageBox.Show("Por favor ingresa un monto inicial.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Intentar Abrir la Caja usando la Capa Lógica
                // Nota: El método AbrirCaja valida internamente si es número
                var respuesta = logicaCaja.AbrirCaja(IdEmpleadoRecibido, txtSueldoInicial.Text);

                if (respuesta.Item1) // Item1 es el bool (True = Éxito)
                {
                    MessageBox.Show("¡Caja Abierta Correctamente!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Le dice al formulario padre (Menu) que todo salió bien
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error: " + respuesta.Item2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private void txtSueldoInicial_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Solo permitir un punto decimal
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
