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

        private void ListarVentas()
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

        private void fmVentas_Load(object sender, EventArgs e)
        {
            ListarVentas();
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "btnDetalles";
            btnEditar.HeaderText = "Acciones";
            btnEditar.Text = "Ver detalles";
            btnEditar.UseColumnTextForButtonValue = true;
            btnEditar.Width = 80;
            btnEditar.FlatStyle = FlatStyle.Popup;
            btnEditar.DefaultCellStyle.BackColor = Color.LightGray;

            dgvVentas.Columns.Add(btnEditar);
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            ListarVentas();
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvVentas.Columns[e.ColumnIndex].Name == "btnEditar" && e.RowIndex >= 0)
                {
                    int fila = dgvVentas.CurrentCell.RowIndex;
                    fmGestionarDetallesVentas DetalleVenta = new fmGestionarDetallesVentas();
                    DetalleVenta.idventa = int.Parse(dgvVentas.Rows[fila].Cells["IdVenta"].Value.ToString());
                    DetalleVenta.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la categoria: " + ex.Message);
            }
        }
    }
}
