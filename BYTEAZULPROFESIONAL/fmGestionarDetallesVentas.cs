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
    public partial class fmGestionarDetallesVentas : Form
    {
        public int idventa = 0;
        CsCaja cscaja;
        public fmGestionarDetallesVentas()
        {
            InitializeComponent();
        }

        private void ListarDetallesVentas()
        {
            try
            {
                cscaja = new CsCaja();
                dgvGestionarDetallesVentas.DataSource = cscaja.ListarDetallesVentas(idventa.ToString());
                dgvGestionarDetallesVentas.Columns["IdDetalleVenta"].Visible = false;
                dgvGestionarDetallesVentas.Columns["IdVenta"].Visible = false;
                dgvGestionarDetallesVentas.Columns["IdLote"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fmGestionarDescuentos_Load(object sender, EventArgs e)
        {
            ListarDetallesVentas();
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "btnDevolucion";
            btnEditar.HeaderText = "Acciones";
            btnEditar.Text = "Devolver";
            btnEditar.UseColumnTextForButtonValue = true;
            btnEditar.Width = 80;
            btnEditar.FlatStyle = FlatStyle.Popup;
            btnEditar.DefaultCellStyle.BackColor = Color.LightGray;

            dgvGestionarDetallesVentas.Columns.Add(btnEditar);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvGestionarDetallesVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int iddetalleventa = 0;
                if (dgvGestionarDetallesVentas.Columns[e.ColumnIndex].Name == "btnDevolucion" && e.RowIndex >= 0)
                {
                    int fila = dgvGestionarDetallesVentas.CurrentCell.RowIndex;
                    iddetalleventa = int.Parse(dgvGestionarDetallesVentas.Rows[fila].Cells["IdDetalleVenta"].Value.ToString());
                    (bool resultado, string mensaje) = cscaja.DevolverDetalleVenta(iddetalleventa);
                    MessageBox.Show(mensaje, resultado ? "Éxito" : "Error", MessageBoxButtons.OK, resultado ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                    ListarDetallesVentas();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar la venta: " + ex.Message);
            }
        }
    }
}
