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
        CsProveedores csProveedores;

        // --- BANDERITA DE MODO ---
        // false = Solo estoy viendo/gestionando (Valor por defecto)
        // true = Quiero seleccionar un proveedor para devolverlo
        public bool ModoSeleccion = false;
        public int IdRetorno { get; private set; }
        public string NombreRetorno { get; private set; }
        public string RucRetorno { get; private set; }

        DataTable CargarProveedor;
        public fmGestionarProveedores() // Constructor default
        {
            InitializeComponent();
        }

        private void fmGestionarProveedores_Load(object sender, EventArgs e)
        {
            ConfigurarGrid();
            CargarLista("");

        }
        private void ConfigurarGrid()
        {
            dgvVerProveedores.AutoGenerateColumns = false;
            dgvVerProveedores.Columns.Clear();

            // Columna ID (Oculta)
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "colId";
            colId.DataPropertyName = "IdProveedor"; // Debe coincidir con SQL
            colId.Visible = false;
            dgvVerProveedores.Columns.Add(colId);

            // Columna Proveedor
            DataGridViewTextBoxColumn colProveedor = new DataGridViewTextBoxColumn();
            colProveedor.HeaderText = "Proveedor";
            colProveedor.DataPropertyName = "Proveedor";
            colProveedor.Width = 100;
            dgvVerProveedores.Columns.Add(colProveedor);

            // Columna RUC
            DataGridViewTextBoxColumn colRUC = new DataGridViewTextBoxColumn();
            colRUC.Name = "RUC";
            colRUC.HeaderText = "RUC";
            colRUC.DataPropertyName = "RUC";
            colRUC.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvVerProveedores.Columns.Add(colRUC);

            // Columna Teléfono
            DataGridViewTextBoxColumn colTel = new DataGridViewTextBoxColumn();
            colTel.HeaderText = "Teléfono";
            colTel.DataPropertyName = "Telefono";
            colTel.Width = 90;
            dgvVerProveedores.Columns.Add(colTel);

            // Columna Dirección
            DataGridViewTextBoxColumn colDir = new DataGridViewTextBoxColumn();
            colDir.HeaderText = "Dirección";
            colDir.DataPropertyName = "Direccion";
            colDir.Width = 150;
            dgvVerProveedores.Columns.Add(colDir);

            // Columna Correo
            DataGridViewTextBoxColumn colCorreo = new DataGridViewTextBoxColumn();
            colCorreo.HeaderText = "Correo";
            colCorreo.DataPropertyName = "Correo";
            colCorreo.Width = 150;
            dgvVerProveedores.Columns.Add(colCorreo);

            // Columna Correo
            DataGridViewTextBoxColumn colEstado = new DataGridViewTextBoxColumn();
            colEstado.HeaderText = "Estado";
            colEstado.DataPropertyName = "Estado";
            colEstado.Width = 100;
            dgvVerProveedores.Columns.Add(colEstado);

            // Columna Botón Editar
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "btnEditar";
            btnEditar.HeaderText = "Acciones";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            btnEditar.Width = 80;
            btnEditar.FlatStyle = FlatStyle.Popup;
            btnEditar.DefaultCellStyle.BackColor = Color.LightGray;

            dgvVerProveedores.Columns.Add(btnEditar);
        }
        private void CargarLista(string filtro)
        {
            try
            {
                csProveedores = new CsProveedores();
                dgvVerProveedores.DataSource = csProveedores.BuscarProveedores(filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            csProveedores = new CsProveedores();
            dgvVerProveedores.DataSource = csProveedores.BuscarProveedores(txtBuscar.Text.Trim());
        }

        private void dgvVerProveedores_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. PRIMERO PREGUNTAMOS: ¿ESTOY EN MODO SELECCIÓN?
            if (ModoSeleccion == false)
            {
                // Si NO estoy seleccionando, no hago nada (o podrías abrir Editar aquí)
                return;
            }

            // 2. SI ESTOY EN MODO SELECCIÓN, ENTONCES SÍ EJECUTO ESTO:
            if (e.RowIndex >= 0)
            {
                try
                {
                    string estado = dgvVerProveedores.Rows[e.RowIndex].Cells["Estado"].Value.ToString();

                    if (estado == "True" || estado == "Activo" || estado == "1")
                    {
                        IdRetorno = Convert.ToInt32(dgvVerProveedores.Rows[e.RowIndex].Cells["IdProveedor"].Value);
                        NombreRetorno = dgvVerProveedores.Rows[e.RowIndex].Cells["Proveedor"].Value.ToString();
                        RucRetorno = dgvVerProveedores.Rows[e.RowIndex].Cells["RUC"].Value.ToString();

                        // 3. RETORNAR OK
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Proveedor inactivo.");
                    }
                }
                catch (Exception ex) { MessageBox.Show("Error: " + ex.Message); }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarLista(txtBuscar.Text.Trim());
        }
    }
}
