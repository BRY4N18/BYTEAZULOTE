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
    public partial class fmGestionarMedicina : Form
    {
        CsMedicinas csmedicina;
        // --- BANDERITA DE MODO ---
        // false = Solo ver/gestionar (Por defecto)
        // true = Seleccionar para devolver datos
        public bool ModoSeleccion = false;
        public int IdRetorno { get; private set; }
        public string NombreRetorno { get; private set; }
        public decimal PrecioRetorno { get; private set; } // Útil para sugerir costo en compra
        public int StockRetorno { get; private set; }
        public char mcaja = 'N';
        /// <summary>
        /// //
        /// </summary>
        public fmGestionarMedicina()
        {
            InitializeComponent();
        }

        private void dgvVerMedicina_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. SI NO ESTOY EN MODO SELECCIÓN, ME SALGO (Protección contra clics accidentales)
            if (ModoSeleccion == false) return;

            if (e.RowIndex >= 0)
            {
                try
                {
                    if (mcaja == 'M')
                    {
                        int fila = dgvVerMedicina.CurrentCell.RowIndex;
                        if (dgvVerMedicina.Rows[fila].Cells["EstadoDesc"].Value.ToString().Trim() == "Activo")
                        {
                            fmCaja caja = Owner as fmCaja;
                            caja.txtIdProducto.Text = dgvVerMedicina.Rows[fila].Cells["Id"].Value.ToString();
                            caja.txtNombreProducto.Text = dgvVerMedicina.Rows[fila].Cells["Medicina"].Value.ToString();
                            //caja.txtPrecio.Text = dgvVerMedicina.Rows[fila].Cells["Precio unitario"].Value.ToString();
                            caja.stock = Convert.ToInt32(dgvVerMedicina.Rows[fila].Cells["Stock"].Value.ToString());
                            caja.txtIdProducto.Enabled = false;
                            caja.txtNombreProducto.Enabled = false;
                            caja.txtPrecio.Enabled = false;
                            this.Hide();
                        }
                        else MessageBox.Show("Este producto no se encuentra disponible");
                    }
                    else
                    {
                        // Validar estado (Activo/Inactivo)
                        string estado = dgvVerMedicina.Rows[e.RowIndex].Cells["EstadoDesc"].Value.ToString();
                        if (estado == "Activo" || estado == "True" || estado == "1")
                        {
                            // 2. LLENAMOS LA MOCHILA
                            IdRetorno = Convert.ToInt32(dgvVerMedicina.Rows[e.RowIndex].Cells["Id"].Value);
                            NombreRetorno = dgvVerMedicina.Rows[e.RowIndex].Cells["Medicina"].Value.ToString();

                            // Validar nulos en Precio y Stock
                            var valPrecio = dgvVerMedicina.Rows[e.RowIndex].Cells["CostoPromedio"].Value;
                            PrecioRetorno = valPrecio != DBNull.Value ? Convert.ToDecimal(valPrecio) : 0;

                            var valStock = dgvVerMedicina.Rows[e.RowIndex].Cells["Stock"].Value;
                            StockRetorno = valStock != DBNull.Value ? Convert.ToInt32(valStock) : 0;

                            /////////

                            // 3. RETORNAR OK
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Producto inactivo.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al seleccionar: " + ex.Message);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            csmedicina = new CsMedicinas();
            dgvVerMedicina.DataSource = csmedicina.Buscar(txtBuscar.Text.Trim());
        }

        private void fmGestionarMedicina_Load(object sender, EventArgs e)
        {
            ConfigurarGridProductos();
            CargarListaProductos();
        }
        private void ConfigurarGridProductos()
        {
            dgvVerMedicina.AutoGenerateColumns = false;
            dgvVerMedicina.Columns.Clear();

            // Columna ID (Oculta)
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "IdProducto";
            colId.DataPropertyName = "IdProducto"; // Debe coincidir con SQL
            colId.Visible = false;
            dgvVerMedicina.Columns.Add(colId);

            // Columna Producto
            DataGridViewTextBoxColumn colProducto = new DataGridViewTextBoxColumn();
            colProducto.HeaderText = "Medicina";
            colProducto.DataPropertyName = "Medicina";
            colProducto.Width = 100;
            dgvVerMedicina.Columns.Add(colProducto);

            // Columna Descripcion
            DataGridViewTextBoxColumn colDesc = new DataGridViewTextBoxColumn();
            colDesc.HeaderText = "Descripcion";
            colDesc.DataPropertyName = "Descripcion";
            colDesc.Width = 90;
            dgvVerMedicina.Columns.Add(colDesc);

            // Columna Categoria
            DataGridViewTextBoxColumn colCat = new DataGridViewTextBoxColumn();
            colCat.HeaderText = "Categoria";
            colCat.DataPropertyName = "Categoria";
            colCat.Width = 90;
            dgvVerMedicina.Columns.Add(colCat);

            // Columna Stock
            DataGridViewTextBoxColumn colStock = new DataGridViewTextBoxColumn();
            colStock.HeaderText = "Stock";
            colStock.DataPropertyName = "Stock";
            colStock.Width = 90;
            dgvVerMedicina.Columns.Add(colStock);

            // Columna CostoPromedio
            DataGridViewTextBoxColumn colCosProm = new DataGridViewTextBoxColumn();
            colCosProm.HeaderText = "CostoPromedio";
            colCosProm.DataPropertyName = "CostoPromedio";
            colCosProm.Width = 90;
            dgvVerMedicina.Columns.Add(colCosProm);

            // Columna Precio
            DataGridViewTextBoxColumn colPrecio = new DataGridViewTextBoxColumn();
            colPrecio.HeaderText = "Precio";
            colPrecio.DataPropertyName = "Precio";
            colPrecio.Width = 90;
            dgvVerMedicina.Columns.Add(colPrecio);

            // Columna Estado
            DataGridViewTextBoxColumn colEst = new DataGridViewTextBoxColumn();
            colEst.HeaderText = "EstadoDesc";
            colEst.DataPropertyName = "EstadoDesc";
            colEst.Width = 150;
            dgvVerMedicina.Columns.Add(colEst);
        }

        private void CargarListaProductos()
        {
            try
            {
                csmedicina = new CsMedicinas();
                dgvVerMedicina.DataSource = csmedicina.Buscar("");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            csmedicina = new CsMedicinas();
            dgvVerMedicina.DataSource = csmedicina.Buscar(txtBuscar.Text.Trim());
        }
    }
}
