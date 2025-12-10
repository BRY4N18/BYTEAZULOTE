using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;

namespace BYTEAZULPROFESIONAL
{
    public partial class fmAgregarEmpleados : Form
    {
        CsEmpleados logicaEmpleado = new CsEmpleados();
        public int IdEmpleadoEditar = 0;
        public fmAgregarEmpleados()
        {
            InitializeComponent();
        }
        private void CargarCombos()
        {
            try
            {
                // --- 1. CARGOS ---
                DataTable dtCargos = logicaEmpleado.ListarCargos();
                cmbCargo.DataSource = null; // Limpiamos primero

                if (dtCargos.Rows.Count > 0)
                {
                    cmbCargo.DataSource = dtCargos;
                    cmbCargo.DisplayMember = "Cargo";   // Debe coincidir con SQL
                    cmbCargo.ValueMember = "IdCargo";   // El valor oculto
                    cmbCargo.SelectedIndex = -1;        // Dejar vacío al inicio
                }

                // --- 2. GÉNEROS ---
                DataTable dtGeneros = logicaEmpleado.ListarGeneros();
                cmbGenero.DataSource = null;

                if (dtGeneros.Rows.Count > 0)
                {
                    cmbGenero.DataSource = dtGeneros;
                    cmbGenero.DisplayMember = "Genero";
                    cmbGenero.ValueMember = "IdGenero";
                    cmbGenero.SelectedIndex = -1;
                }

                // --- 3. EMPRESAS ---
                DataTable dtEmpresas = logicaEmpleado.ListarEmpresas();
                cmbEmpresa.DataSource = null;

                if (dtEmpresas.Rows.Count > 0)
                {
                    cmbEmpresa.DataSource = dtEmpresas;
                    cmbEmpresa.DisplayMember = "Empresa";
                    cmbEmpresa.ValueMember = "IdEmpresa";
                    cmbEmpresa.SelectedIndex = -1; 
                }
                int index = cmbEmpresa.FindStringExact("Byte Azul S.A.");
                if (index >= 0)
                {
                    cmbEmpresa.SelectedIndex = index;
                }
                cmbEmpresa.Enabled = false; 
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las listas: " + ex.Message);
            }

        }
        // --- CARGAR DATOS EN TEXTBOXES ---
        private void CargarDatosParaEditar()
        {
            try
            {
                DataTable dt = logicaEmpleado.TraerDatosEmpleado(IdEmpleadoEditar);
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];

                    // Textos
                    txtIdentificacion.Text = row["Identificacion"].ToString();
                    txtNombres.Text = row["Nombres"].ToString();
                    txtApellidos.Text = row["Apellidos"].ToString();
                    txtCelular.Text = row["Telefono"].ToString();
                    txtDireccion.Text = row["Direccion"].ToString();
                    txtCorreo.Text = row["Correo"].ToString();

                    // Fechas
                    if (row["FechaNacimiento"] != DBNull.Value)
                        dtpFechaNacimiento.Value = Convert.ToDateTime(row["FechaNacimiento"]);
                    if (row["FechaContratacion"] != DBNull.Value)
                        dtpFechaIngreso.Value = Convert.ToDateTime(row["FechaContratacion"]);

                    // Combos BD
                    cmbCargo.SelectedValue = Convert.ToInt32(row["IdCargo"]);
                    cmbGenero.SelectedValue = Convert.ToInt32(row["IdGenero"]);
                    cmbEmpresa.SelectedValue = Convert.ToInt32(row["IdEmpresa"]);

                    // Combo Estado (Convertimos el bool de la BD a 1 o 0 para el Combo)
                    if (row["Estado"] != DBNull.Value)
                    {
                        bool esActivo = Convert.ToBoolean(row["Estado"]);
                        cmbEstado.SelectedValue = esActivo ? 1 : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar datos: " + ex.Message);
            }
        }

        private void btnAgregarEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                // 1. Validar Combos Vacíos
                if (cmbCargo.SelectedIndex == -1 || cmbGenero.SelectedIndex == -1 || cmbEmpresa.SelectedIndex == -1)
                {
                    MessageBox.Show("Faltan seleccionar datos (Cargo, Género o Empresa).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. VALIDACIÓN DE EDAD (Mínimo 18 años)
                DateTime fechaNac = dtpFechaNacimiento.Value;
                int edad = DateTime.Today.Year - fechaNac.Year;

                // Ajuste por si aún no cumple años en el año actual
                if (fechaNac.Date > DateTime.Today.AddYears(-edad))
                    edad--;

                if (edad < 18)
                {
                    MessageBox.Show($"El empleado tiene {edad} años?????. Debe ser mayor de edad (18+) para ser contratado.", "Edad Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Detenemos el código aquí
                }

                // 3. Validación Fecha Contratación
                if (dtpFechaIngreso.Value < dtpFechaNacimiento.Value.AddYears(18))
                {
                    MessageBox.Show("La fecha de contratación es incoherente con la fecha de nacimiento.", "Fechas Incorrectas", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Guardar
                var resultado = logicaEmpleado.GuardarEmpleadoInteligente(
                    Convert.ToInt32(cmbCargo.SelectedValue),
                    Convert.ToInt32(cmbGenero.SelectedValue),
                    Convert.ToInt32(cmbEmpresa.SelectedValue),
                    txtIdentificacion.Text.Trim(),
                    txtApellidos.Text.Trim(),
                    txtNombres.Text.Trim(),
                    txtCelular.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    dtpFechaNacimiento.Value,
                    dtpFechaIngreso.Value,
                    txtCorreo.Text.Trim()
                );

                if (resultado.Item1)
                {
                    MessageBox.Show(resultado.Item2, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); 
                }
                else
                {
                    MessageBox.Show(resultado.Item2, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }
        // --- VALIDACIONES COMUNES ---
        private bool ValidarFormulario()
        {
            if (cmbCargo.SelectedValue == null || cmbGenero.SelectedValue == null || cmbEmpresa.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar Cargo, Género y Empresa.", "Faltan Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // Validar Edad > 18
            DateTime fechaNac = dtpFechaNacimiento.Value;
            int edad = DateTime.Today.Year - fechaNac.Year;
            if (fechaNac.Date > DateTime.Today.AddYears(-edad)) edad--;

            if (edad < 18)
            {
                MessageBox.Show("El empleado debe ser mayor de edad.", "Edad Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }
        private void btnModificarEmpleados_Click(object sender, EventArgs e)
        {
            if (!ValidarFormulario()) return;

            try
            {
                // Obtenemos el estado del ComboBox (1=true, 0=false)
                int valEstado = Convert.ToInt32(cmbEstado.SelectedValue);
                bool estadoBool = (valEstado == 1);

                var res = logicaEmpleado.EditarEmpleado(
                    IdEmpleadoEditar, // IMPORTANTE: Enviamos el ID
                    (int)cmbCargo.SelectedValue,
                    (int)cmbGenero.SelectedValue,
                    (int)cmbEmpresa.SelectedValue,
                    txtIdentificacion.Text.Trim(),
                    txtApellidos.Text.Trim(),
                    txtNombres.Text.Trim(),
                    txtCelular.Text.Trim(),
                    txtDireccion.Text.Trim(),
                    dtpFechaNacimiento.Value,
                    dtpFechaIngreso.Value,
                    txtCorreo.Text.Trim(),
                    estadoBool // Enviamos el estado seleccionado
                );

                MessageBox.Show(res.Item2, "Sistema", MessageBoxButtons.OK, res.Item1 ? MessageBoxIcon.Information : MessageBoxIcon.Warning);

                if (res.Item1) this.Close(); // Cierra si actualizó bien
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private void fmAgregarEmpleados_Load(object sender, EventArgs e)
        {
            CargarCombos(); // Primero cargamos los combos

            if (IdEmpleadoEditar > 0)
            {
                // === MODO MODIFICAR ===
                this.Text = "Modificar Empleado";

                // Gestión de Botones
                btnAgregarEmpleados.Visible = false;    // Ocultamos Guardar
                btnModificarEmpleados.Visible = true;   // Mostramos Modificar

                // Gestión de Estado
                cmbEstado.Enabled = true;       // Habilitamos cambiar estado

                // IMPORTANTE: Esto llena el combo de Estado manualmente antes de cargar datos
                LlenarComboEstado();

                CargarDatosParaEditar(); // Ahora sí cargamos los datos
            }
            else
            {
                // === MODO NUEVO ===
                this.Text = "Nuevo Empleado";

                // Gestión de Botones
                btnAgregarEmpleados.Visible = true;
                btnModificarEmpleados.Visible = false;

                // Gestión de Estado
                cmbEstado.Enabled = false;
                LlenarComboEstado(); // Llenamos el combo igual para evitar errores
                cmbEstado.SelectedValue = 1; // Por defecto Activo
            }
        }
        // Agrega este pequeño método auxiliar para que el combo Estado tenga datos
        private void LlenarComboEstado()
        {
            DataTable dtEstado = new DataTable();
            dtEstado.Columns.Add("Valor", typeof(int));
            dtEstado.Columns.Add("Texto", typeof(string));
            dtEstado.Rows.Add(1, "Activo");
            dtEstado.Rows.Add(0, "Inactivo");

            cmbEstado.DataSource = dtEstado;
            cmbEstado.DisplayMember = "Texto";
            cmbEstado.ValueMember = "Valor";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
