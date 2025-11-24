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
    public partial class fmGestionarMedicina : Form
    {
        public fmGestionarMedicina()
        {
            InitializeComponent();
        }

        private void dgvVerMedicina_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = dgvVerMedicina.CurrentCell.RowIndex;
            try
            {
                if (dgvVerMedicina.Rows[fila].Cells["Estado"].Value.ToString().Trim() == "Activo")
                {
                    fmCaja caja = Owner as fmCaja;
                    caja.txtIdProducto.Text = dgvVerMedicina.Rows[fila].Cells["Id"].Value.ToString();
                    caja.txtNombreProducto.Text = dgvVerMedicina.Rows[fila].Cells["Medicina"].Value.ToString();
                    caja.txtPrecio.Text = dgvVerMedicina.Rows[fila].Cells["Precio unitario"].Value.ToString();
                    caja.stock = Convert.ToInt32(dgvVerMedicina.Rows[fila].Cells["Stock"].Value.ToString());
                    caja.txtIdProducto.Enabled = false;
                    caja.txtNombreProducto.Enabled = false;
                    caja.txtPrecio.Enabled = false;
                    this.Hide();
                }
                else MessageBox.Show("Este producto no se encuentra disponible");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el producto: " + ex.Message);
            }
        }
    }
}
