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
    public partial class fmGestionarClientes : Form
    {
        public fmGestionarClientes()
        {
            InitializeComponent();
        }

        private void dgvVerClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int fila = dgvVerClientes.CurrentCell.RowIndex;
                if (dgvVerClientes.Rows[fila].Cells["Estado"].Value.ToString().Trim() == "Activo")
                {
                    fmCaja caja = Owner as fmCaja;
                    caja.txtIdCliente.Text = dgvVerClientes.Rows[fila].Cells["ID Cliente"].Value.ToString();
                    caja.txtNombreCliente.Text = dgvVerClientes.Rows[fila].Cells["Apellidos"].Value.ToString();
                    caja.txtNombreCliente.Enabled = false;
                    caja.txtIdCliente.Enabled = false;
                    this.Hide();
                }
                else MessageBox.Show("Este cliente no se encuentra disponible");
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error al seleccionar el cliente: " + ex.Message);
            }
        }
    }
}
