using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace BYTEAZULPROFESIONAL
{
    public partial class fmCaja : Form
    {
        FmMenu menu;
        CsEmpleados csempleados;
        CsClientes csclientes;
        public fmCaja()
        {
            InitializeComponent();
        }
        private void ApellidoEmpleado()
        {
            try
            {
                int idusuario = int.Parse(menu.IdUsuario);
                bool resultado;
                string apellidoempleado = "";
                csempleados = new CsEmpleados();
                (resultado, apellidoempleado) = csempleados.ApellidoEmpleado(idusuario);
                if (!resultado)
                    MessageBox.Show(idusuario.ToString(), resultado ? "Éxito" : "Error", MessageBoxButtons.OK, resultado ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                else
                    txtNombreEmpleado.Text = apellidoempleado.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fmCaja_Load(object sender, EventArgs e)
        {
            menu = new FmMenu();
            txtFecha.Text = DateTime.Now.ToString().Split(' ')[0];
            txtidEmpleado.Text = menu.IdUsuario.ToString();
            ApellidoEmpleado();
        }      
    }
}
