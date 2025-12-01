using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace BYTEAZULPROFESIONAL
{
    public partial class fmCaja : Form
    {
        FmMenu menu;
        CsEmpleados csempleados;
        CsCaja cscaja;
        CsClientes csclientes;

        public int stock = 0;
        public fmCaja()
        {
            InitializeComponent();
        }
        private void ApellidoEmpleado()
        {
            try
            {
                int idusuario = int.Parse(menu.IdUsuario.Trim());
                bool resultado;
                string apellidoempleado = "";
                csempleados = new CsEmpleados();
                (resultado, apellidoempleado) = csempleados.ApellidoEmpleado(idusuario);
                if (!resultado)
                    MessageBox.Show(apellidoempleado, resultado ? "Éxito" : "Error", MessageBoxButtons.OK, resultado ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                else
                    txtNombreEmpleado.Text = apellidoempleado.ToString();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApellidoCliente()
        {
            try
            {
                int idcliente = int.Parse(txtIdCliente.Text.ToString().Trim());
                bool resultado;
                string apellidocliente = "";
                csclientes = new CsClientes();
                (resultado, apellidocliente) = csclientes.ApellidoCliente(idcliente);
                if (!resultado)
                    MessageBox.Show(apellidocliente, resultado ? "Éxito" : "Error", MessageBoxButtons.OK, resultado ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                else
                    txtNombreCliente.Text = apellidocliente.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GenerarVenta()
        {
            try
            {
                cscaja = new CsCaja();
                int idempleado = int.Parse(txtidEmpleado.Text.ToString().Trim());
                int idcliente = int.Parse(txtIdCliente.Text.ToString().Trim());
                //decimal totalventa = decimal.Parse(txtTotal.Text.ToString().Replace(',', '.').Trim());
                decimal totalventa = 30;

                (int idventa, bool resultado, string mensaje) = cscaja.GenerarVenta(idempleado, idcliente, totalventa);
                if (resultado)
                {
                    foreach (DataGridViewRow row in dgvDetallesVentas.Rows)
                    {
                        (resultado, mensaje) = cscaja.GenerarDetallesVenta(idventa, int.Parse(row.Cells[0].Value.ToString()), int.Parse(row.Cells[2].Value.ToString()), decimal.Parse(row.Cells[3].Value.ToString()));
                    }
                }

                if (!resultado) MessageBox.Show(mensaje, resultado ? "Éxito" : "Error", MessageBoxButtons.OK, resultado ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                else
                {
                    MessageBox.Show("La venta se realizó con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtIdProducto.Clear();
                    txtNombreProducto.Clear();
                    txtPrecio.Clear();
                    txtCantidad.Clear();
                    txtIdCliente.Clear();
                    txtNombreCliente.Clear();
                    dgvDetallesVentas.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado al guardar la venta: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GuardarDetallesVenta()
        {
            try
            {
                if (stock < int.Parse(txtCantidad.Text.ToString().Trim()) || int.Parse(txtCantidad.Text.ToString().Trim()) == 0)
                    MessageBox.Show("La cantidad solicitada excede el stock disponible", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                {
                    double total = int.Parse(txtCantidad.Text) * double.Parse(txtPrecio.Text);
                    dgvDetallesVentas.Rows.Add(txtIdProducto.Text.Trim(), txtNombreProducto.Text.Trim(), txtCantidad.Text.Trim(), txtPrecio.Text.Replace(',', '.').Trim(), total.ToString().Replace(',', '.').Trim());
                    txtIdProducto.Clear();
                    txtNombreProducto.Clear();
                    txtPrecio.Clear();
                    txtCantidad.Clear();
                    txtPrecio.Text = "10";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fmCaja_Load(object sender, EventArgs e)
        {
            menu = new FmMenu();
            txtFecha.Text = DateTime.Now.ToString().Split(' ')[0];
            txtidEmpleado.Text = menu.IdUsuario.ToString();
            ApellidoEmpleado();
            txtFecha.Enabled = false;
            txtidEmpleado.Enabled = false;
            txtIdProducto.Enabled = false;
            txtNombreProducto.Enabled = false;
            txtPrecio.Enabled = false;
            txtSubtotal.Enabled = false;
            txtIva.Enabled = false;
            txtTotal.Enabled = false;
            txtCambio.Enabled = false;
            txtNombreEmpleado.Enabled = false;
            txtPrecio.Text = "10";
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            fmGestionarClientes Clientes = new fmGestionarClientes();
            this.AddOwnedForm(Clientes);
            Clientes.ShowDialog();
            ApellidoCliente();
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            fmGestionarMedicina Medicinas = new fmGestionarMedicina();
            Medicinas.ModoSeleccion = true;
            Medicinas.mcaja = 'M';
            this.AddOwnedForm(Medicinas);
            Medicinas.ShowDialog();
        }

        private void btnGenerarFactura_Click(object sender, EventArgs e)
        {
            GenerarVenta();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarDetallesVenta();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255)) e.Handled = true;
        }

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPago.Text.Length == 0)
            {
                if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255)) e.Handled = true;
            }
            else
                if (e.KeyChar != ',' && (e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != 8) e.Handled = true;
        }

        private void dgvDetallesVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
                if (txtCambio.Text.Length == 0)
                    if (dgvDetallesVentas.Columns[e.ColumnIndex] == dgvDetallesVentas.Columns[dgvDetallesVentas.Columns.Count - 1])
                    {
                        DialogResult res = MessageBox.Show("¿Esta seguro de que desea eliminar esta venta?", "Advertencia", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (res == DialogResult.Yes)
                        {
                            dgvDetallesVentas.Rows.Remove(dgvDetallesVentas.CurrentRow);
                        }
                    }
        }
    }
}
