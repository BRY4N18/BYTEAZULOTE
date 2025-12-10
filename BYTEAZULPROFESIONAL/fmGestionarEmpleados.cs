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
    public partial class fmGestionarEmpleados : Form
    {
        CsEmpleados logica = new CsEmpleados();
        public fmGestionarEmpleados()
        {
            InitializeComponent();
            CargarLista("");
            ConfigurarGrid();
        }
        // --- MÉTODO CLAVE PARA CONFIGURAR COLUMNAS
        private void ConfigurarGrid()
        {
            dgvVerEmpleados.AutoGenerateColumns = false;
            dgvVerEmpleados.Columns.Clear();

            // 1. Columna ID (Oculta)
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "colId";
            colId.DataPropertyName = "IdEmpleado"; // Coincide con tu SQL
            colId.Visible = false;
            dgvVerEmpleados.Columns.Add(colId);

            // 2. Columna Documento 
            DataGridViewTextBoxColumn colDoc = new DataGridViewTextBoxColumn();
            colDoc.HeaderText = "Documento";
            // EN TU SQL SE LLAMA "Identificacion", ASÍ QUE AQUÍ TAMBIÉN:
            colDoc.DataPropertyName = "Identificacion";
            colDoc.Width = 100;
            dgvVerEmpleados.Columns.Add(colDoc);

            // COLUMNA TELÉFONO
            DataGridViewTextBoxColumn colTel = new DataGridViewTextBoxColumn();
            colTel.HeaderText = "Teléfono";
            colTel.DataPropertyName = "Telefono"; // Nombre exacto en SQL
            colTel.Width = 80;
            dgvVerEmpleados.Columns.Add(colTel);

            // COLUMNA CORREO
            DataGridViewTextBoxColumn colCorreo = new DataGridViewTextBoxColumn();
            colCorreo.HeaderText = "Correo";
            colCorreo.DataPropertyName = "Correo"; // Nombre exacto en SQL
            colCorreo.Width = 150; // Un poco más ancho
            dgvVerEmpleados.Columns.Add(colCorreo);

            // 3. Columna Nombre Completo 
            DataGridViewTextBoxColumn colNombre = new DataGridViewTextBoxColumn();
            colNombre.HeaderText = "Nombre del Empleado";
            // EN TU SQL SE LLAMA "NombreCompleto" (Sin espacio):
            colNombre.DataPropertyName = "NombreCompleto";
            colNombre.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvVerEmpleados.Columns.Add(colNombre);

            // 4. Columna Cargo
            DataGridViewTextBoxColumn colCargo = new DataGridViewTextBoxColumn();
            colCargo.HeaderText = "Cargo";
            colCargo.DataPropertyName = "Cargo"; // Coincide
            colCargo.Width = 120;
            dgvVerEmpleados.Columns.Add(colCargo);

            // 5. Columna Empresa
            DataGridViewTextBoxColumn colEmpresa = new DataGridViewTextBoxColumn();
            colEmpresa.HeaderText = "Empresa";
            colEmpresa.DataPropertyName = "Empresa"; // Coincide
            colEmpresa.Width = 120;
            dgvVerEmpleados.Columns.Add(colEmpresa);

            // 6. Columna Estado
            DataGridViewTextBoxColumn colEstado = new DataGridViewTextBoxColumn();
            colEstado.HeaderText = "Estado";
            colEstado.DataPropertyName = "Estado"; 
            colEstado.Width = 70;
            dgvVerEmpleados.Columns.Add(colEstado);

            // 7. Columna Botón Editar
            DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
            btnEditar.Name = "btnEditar";
            btnEditar.HeaderText = "Acciones";
            btnEditar.Text = "Editar";
            btnEditar.UseColumnTextForButtonValue = true;
            btnEditar.Width = 80;
            btnEditar.FlatStyle = FlatStyle.Popup;
            btnEditar.DefaultCellStyle.BackColor = Color.LightGray;

            dgvVerEmpleados.Columns.Add(btnEditar);
        }
        private void CargarLista(string filtro)
        {
            try
            {
                dgvVerEmpleados.DataSource = logica.BuscarEmpleados(filtro);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            CargarLista(txtBuscar.Text.Trim());
        }

        private void dgvVerEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvVerEmpleados.Columns[e.ColumnIndex].Name == "btnEditar" && e.RowIndex >= 0)
            {
                int idSeleccionado = Convert.ToInt32(dgvVerEmpleados.Rows[e.RowIndex].Cells["colId"].Value);

                fmAgregarEmpleados frm = new fmAgregarEmpleados();
                frm.IdEmpleadoEditar = idSeleccionado;
                frm.ShowDialog();

                CargarLista(txtBuscar.Text.Trim());
            }
        }

        private void dgvVerEmpleados_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvVerEmpleados.Columns[e.ColumnIndex].HeaderText == "Estado" && e.Value != null)
            {
                bool estado;
                if (e.Value is bool)
                {
                    estado = (bool)e.Value;
                }
                else
                {
                    estado = e.Value.ToString() == "1" || e.Value.ToString().ToLower() == "true";
                }
                e.Value = estado ? "Activo" : "Inactivo";
                e.FormattingApplied = true;
            }
        }
    }
}
