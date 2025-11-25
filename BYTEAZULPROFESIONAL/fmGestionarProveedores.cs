using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace BYTEAZULPROFESIONAL
{
    public partial class fmGestionarProveedores : Form
    {
        public fmGestionarProveedores() // Constructor default
        {
            InitializeComponent();
        }
        CsProveedores csProveedores;
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            csProveedores = new CsProveedores();
            dgvVerProveedores.DataSource = csProveedores.BuscarProveedores(btnBuscar.Text);
        }

        private void fmGestionarProveedores_Load(object sender, EventArgs e)
        {
            csProveedores = new CsProveedores();
            dgvVerProveedores.DataSource = csProveedores.BuscarProveedores(btnBuscar.Text);
        }
    }
}
