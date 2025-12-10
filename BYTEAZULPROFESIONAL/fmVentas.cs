using CapaLogica;
using Microsoft.ReportingServices.Diagnostics.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BYTEAZULPROFESIONAL
{
    public partial class fmVentas : Form
    {
        public fmVentas()
        {
            InitializeComponent();
        }

        CsCaja cscaja;

        private void fmVentas_Load(object sender, EventArgs e)
        {
            try
            {
                cscaja = new CsCaja();
                dgvVentas.DataSource = cscaja.ListarVentas(txtBuscar.Text);
                dgvVentas.Columns["IdVenta"].Visible = false;
                dgvVentas.Columns["IdCliente"].Visible = false;
                dgvVentas.Columns["IdEmpleado"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
