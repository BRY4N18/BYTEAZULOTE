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
    public partial class fmGestionarCategorias : Form
    {
        public char ingreso = 'L';
        CsMedicinas csmedicina;
        public fmGestionarCategorias()
        {
            InitializeComponent();
        }
        private void ListarCategorias()
        {
            try
            {
                csmedicina = new CsMedicinas();
                dgvVerCategorias.DataSource = csmedicina.ListarCategorias(txtNombreCategoria.Text);
                dgvVerCategorias.Columns["IdCategoria"].Visible = false;
                dgvVerCategorias.Columns["IdIva"].Visible = false;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void fmGestionarCategorias_Load(object sender, EventArgs e)
        {
            ListarCategorias();
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "btnEditar";
            btnEditar.HeaderText = "Acciones";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            btnEditar.Width = 80;
            btnEditar.FlatStyle = FlatStyle.Popup;
            btnEditar.DefaultCellStyle.BackColor = Color.LightGray;

            dgvVerCategorias.Columns.Add(btnEditar);
        }
        private void txtNombreCategoria_KeyPress(object sender, KeyPressEventArgs e)
        {
            ListarCategorias();
        }
        private void dgvVerCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvVerCategorias.Columns[e.ColumnIndex].Name == "btnEditar" && e.RowIndex >= 0)
                {
                    int fila = dgvVerCategorias.CurrentCell.RowIndex;
                    fmAgregarCategorias categorias = new fmAgregarCategorias();
                    categorias.txtNombreCategoria.Text = dgvVerCategorias.Rows[fila].Cells["Nombre Categoria"].Value.ToString();
                    categorias.txtIva.Text = dgvVerCategorias.Rows[fila].Cells["Iva"].Value.ToString();
                    categorias.txtDescripcion.Text = dgvVerCategorias.Rows[fila].Cells["Descripción"].Value.ToString();
                    categorias.cmbEstado.SelectedIndex = dgvVerCategorias.Rows[fila].Cells["Estado"].Value.ToString() == "Activo" ? 1 : 0;
                    categorias.idiva = int.Parse(dgvVerCategorias.Rows[fila].Cells["IdIva"].Value.ToString());
                    categorias.idcategoria = int.Parse(dgvVerCategorias.Rows[fila].Cells["IdCategoria"].Value.ToString());
                    categorias.ingreso = 'M';
                    categorias.ShowDialog();
                    ListarCategorias();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la categoria: " + ex.Message);
            }
        }
    }
}
