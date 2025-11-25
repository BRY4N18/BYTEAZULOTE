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

        private void btnCrearCuentaEmpleado_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtContraseña.Text == txtConfirmarContraseña.Text)
                {
                    csempleados = new CsEmpleados();
                    (bool resultado, string mensaje) = csempleados.CrearCuenta(txtusuario.Text.Trim(), txtContraseña.Text);
                    MessageBox.Show(mensaje, resultado ? "Éxito" : "Error", MessageBoxButtons.OK, resultado ? MessageBoxIcon.Information : MessageBoxIcon.Error);                                   
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnVerificar_Click(object sender, EventArgs e)
        {
            //Crear SP para verificar si existe la cedula o ya tiene una cuenta creada
        }
    }
}
