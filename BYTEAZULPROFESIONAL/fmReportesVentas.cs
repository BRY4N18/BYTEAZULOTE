using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BYTEAZULPROFESIONAL
{
    public partial class fmReportesVentas : Form
    {
        public fmReportesVentas()
        {
            InitializeComponent();
            dtpFechaInicio.Value = DateTime.Now;
            dtpFechafin.Value = DateTime.Now;
        }       
        private void btnGenerarReportes_Click(object sender, EventArgs e)
        {

        }
        private void cbTipodeReportes_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
