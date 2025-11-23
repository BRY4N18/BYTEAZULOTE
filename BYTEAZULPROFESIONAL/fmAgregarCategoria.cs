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
    public partial class fmAgregarCategoria : Form
    {
        csMedicina medicina;
        public fmAgregarCategoria()
        {
            InitializeComponent();
        }
        private void Enteri()
        {
            if (txtCategoria.Text.Length > 0)
            {
                medicina = new csMedicina(txtCategoria.Text);
                if (medicina.AgregarCategoria())
                {
                    MessageBox.Show("Categoria agregada");
                    txtCategoria.Clear();
                }
                else MessageBox.Show("A ocurrido un error");
            }
            else MessageBox.Show("Ingrese una categoria");
        }
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            Enteri();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar==(char)Keys.Enter)Enteri();
        }
    }
}
