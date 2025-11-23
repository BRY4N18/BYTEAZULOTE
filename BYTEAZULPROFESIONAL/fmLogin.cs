using CapaLogica;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BYTEAZULPROFESIONAL
{
    public partial class fmLogin : Form
    {
        CsEmpleados csempleados;
        string idusuario;

        public fmLogin()
        {
            InitializeComponent();
            btnOcultar.Visible = false;
        }

        private void IniciarSesion()
        {
            try
            {
                //bool resultado;
                //csempleados = new CsEmpleados();
                //(resultado, idusuario) = csempleados.IniciarSesion(txtUsuario.Text.Trim(), txtPassword.Text.Trim());
                //if (!resultado) MessageBox.Show(idusuario, resultado ? "Éxito" : "Error", MessageBoxButtons.OK, resultado ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                //else
                //{
                    FmMenu menu = new FmMenu();
                    menu.IdUsuario = idusuario;
                    this.Hide();
                    menu.ShowDialog();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            IniciarSesion();
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOcultar_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = true;
            btnOcultar.Visible = false;
            btnOcultar.Enabled = false;          
            btnVer.Visible = true;
            btnVer.Enabled = true;
        }

        private void btnVer_Click(object sender, EventArgs e)
        {
            txtPassword.UseSystemPasswordChar = false;
            btnVer.Visible = false;
            btnVer.Enabled = false; 
            btnOcultar.Visible = true;
            btnOcultar.Enabled = true;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) IniciarSesion();
        }
    }
}
