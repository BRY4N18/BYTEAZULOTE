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
    public partial class fmIvas : Form
    {
        CsMedicinas csmedicina;
        public fmIvas()
        {
            InitializeComponent();
        }

        private void fmIvas_Load(object sender, EventArgs e)
        {
            try
            {
                csmedicina = new CsMedicinas();
                dgvListarIva.DataSource = csmedicina.ListarIvas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvListarIva_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int fila = dgvListarIva.CurrentCell.RowIndex;
                fmAgregarCategorias categoria = Owner as fmAgregarCategorias;
                categoria.txtIva.Text = dgvListarIva.Rows[fila].Cells["Iva"].Value.ToString();
                categoria.idiva = int.Parse(dgvListarIva.Rows[fila].Cells["IdIva"].Value.ToString());
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar el iva: " + ex.Message);
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
