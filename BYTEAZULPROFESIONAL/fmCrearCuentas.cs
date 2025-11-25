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
using CapaLogica;

namespace BYTEAZULPROFESIONAL
{
    public partial class fmCrearCuentas : Form
    {
        CsEmpleados csempleados;
        FmMenu fmMenu;

        public fmCrearCuentas()
        {
            InitializeComponent();
        }

        private void CrearCuenta()
        {
            try
            {
                if (txtContraseña.Text == txtConfirmarContraseña.Text)
                {
                    csempleados = new CsEmpleados();
                    (bool resultado, string mensaje) = csempleados.CrearCuenta(txtusuario.Text.Trim(), txtContraseña.Text);
                    MessageBox.Show(mensaje, resultado ? "Éxito" : "Error", MessageBoxButtons.OK, resultado ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void VerificarIdentificacion()
        {
            if (txtusuario.Text.Length > 0)
            {
                csempleados = new CsEmpleados();
                (bool resultado, string mensaje) = csempleados.VerificarIdentificacionEmpleado(txtusuario.Text.Trim());
                if (!resultado) MessageBox.Show(mensaje, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    txtContraseña.Enabled = true;
                    txtConfirmarContraseña.Enabled = true;
                    txtContraseña.Focus();
                    MessageBox.Show("Ingresa la contraseña", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnCrearCuentaEmpleado_Click(object sender, EventArgs e)
        {
            CrearCuenta();
            txtusuario.Clear();
            txtContraseña.Clear();
            txtConfirmarContraseña.Clear();
        }
        private void btnVerificar_Click(object sender, EventArgs e)
        {
            VerificarIdentificacion();
        }

        private void txtusuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) VerificarIdentificacion();
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) txtConfirmarContraseña.Focus();
        }

        private void txtConfirmarContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) CrearCuenta();
        }
    }
}
