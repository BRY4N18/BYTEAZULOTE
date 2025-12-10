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
        public int IdEmpleadoRecibido;

        public fmAbrirCaja()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e) { this.Close(); }

        private void fmAbrirCaja_Load(object sender, EventArgs e)
        {
            txtSueldoInicial.Text = "0.00";
            txtSueldoInicial.SelectAll();
            txtSueldoInicial.Focus();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSueldoInicial.Text))
                {
                    MessageBox.Show("Por favor ingresa un monto inicial.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var respuesta = logicaCaja.AbrirCaja(IdEmpleadoRecibido, txtSueldoInicial.Text);

                if (respuesta.Item1) 
                {
                    MessageBox.Show("¡Caja Abierta Correctamente!", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);

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

            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
