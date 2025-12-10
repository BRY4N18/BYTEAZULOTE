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
    public partial class fmMovimientos : Form
    {
        CsMovimientos csmovimientos;
        public fmMovimientos()
        {
            InitializeComponent();
        }

        private void ListarMovimientos()
        {
            try
            {
                csmovimientos = new CsMovimientos();
                dgvMovimientos.DataSource = csmovimientos.ListarMovimientos(txtBuscar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void fmMovimientos_Load(object sender, EventArgs e)
        {
            ListarMovimientos();
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ListarMovimientos();
        }
    }
}
