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
    public partial class FmMenu : Form
    {
        public string IdUsuario = "1";
        public FmMenu()
        {
            InitializeComponent();
            customizarDiseno();
        }
        private void customizarDiseno()
        {
            panelSubClientes.Visible = false;
            panelSubCaja.Visible = false;
            panelSubEmpleados.Visible = false;
            panelSubProveedores.Visible = false;
            panelSubReportes.Visible = false;
            panelSubMedicina.Visible = false;
            panelSubLotes.Visible = false;
            panelSubAdministracion.Visible = false;   
            panelsubSuscripciones.Visible = false;
        }
        private void ocultarMenu()
        {
            if (panelSubClientes.Visible==true) 
                panelSubClientes.Visible=false;
            if (panelSubCaja.Visible==true) 
                panelSubCaja.Visible=false;
            if (panelSubEmpleados.Visible==true) 
                panelSubEmpleados.Visible=false;
            if (panelSubProveedores.Visible == true)
                panelSubProveedores.Visible = false;
            if (panelSubReportes.Visible == true)
                panelSubReportes.Visible=false;
            if (panelSubMedicina.Visible==true)
                panelSubMedicina.Visible=false;
            if (panelSubLotes.Visible==true) 
                panelSubLotes.Visible=false;
            if (panelSubAdministracion.Visible==true)
                panelSubAdministracion.Visible=false;
            if (panelsubSuscripciones.Visible == true)
                panelsubSuscripciones.Visible=false;
        }
        private void mostrarSubMenu( Panel subMenu)
        {
            if (subMenu.Visible==false)
            {
                ocultarMenu();
                subMenu.Visible=true;
            }
            else 
                subMenu.Visible=false;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubClientes);
        }

        private void btnGestionarClientes_Click(object sender, EventArgs e)
        {
            PanelContenedorForm(new fmGestionarClientes());
            ocultarMenu();
        }

        private void btnAgregarClientes_Click(object sender, EventArgs e)
        {
            PanelContenedorForm(new fmAgregarClientes());
            ocultarMenu();
        }

        private void btnCaja_Click(object sender, EventArgs e)
        {         
            mostrarSubMenu(panelSubCaja);
        }

        private void btnAbrirCaja_Click(object sender, EventArgs e)
        {
            try
            {
                int idEmpleadoInt = 0;

                // Si IdUsuario es nulo o vacío, usaremos 1 por defecto para que no falle
                if (string.IsNullOrEmpty(this.IdUsuario) || !int.TryParse(this.IdUsuario, out idEmpleadoInt))
                {
                    idEmpleadoInt = 1;
                }

                CsCaja logica = new CsCaja();

                // 2. VERIFICAR
                if (logica.EstaCajaAbierta(idEmpleadoInt))
                {
                    MessageBox.Show("La caja YA está abierta.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PanelContenedorForm(new fmCaja());
                    ocultarMenu();
                }
                else
                {
                    // 3. ABRIR EL FORMULARIO PEQUEÑO
                    fmAbrirCaja frmPequeño = new fmAbrirCaja();

                    frmPequeño.IdEmpleadoRecibido = idEmpleadoInt;

                    // Mostramos el hijo y esperamos
                    if (frmPequeño.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Sesión iniciada. Ahora puedes ir a Ventas u compras.", "Sistema");     
                    }                   

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en menú: " + ex.Message);
            }
        }

        private void btnVerVentas_Click(object sender, EventArgs e)
        {
            try
            {
                int idEmpleadoInt = 0;

                // Si IdUsuario es nulo, vacío o no es número, usamos 1 por defecto para que no se rompa
                if (string.IsNullOrEmpty(this.IdUsuario) || !int.TryParse(this.IdUsuario, out idEmpleadoInt))
                {
                    idEmpleadoInt = 1;
                }

                // 2. LÓGICA DE CAJA
                CsCaja logica = new CsCaja();

                if (logica.EstaCajaAbierta(idEmpleadoInt))
                {
                    // === CAJA ABIERTA: ENTRAMOS A VENTAS ===

                    // Instanciamos el formulario de ventas
                    fmVentas formVentas = new fmVentas();
                    PanelContenedorForm(formVentas);
                    ocultarMenu();
                }
                else
                {
                    // === CAJA CERRADA: ALERTA ===
                    MessageBox.Show("ACCESO DENEGADO.\n\nLa caja está cerrada. " +
                                    "Por favor, ve al botón 'Abrir Caja' e inicia sesión primero.",
                                    "Caja Cerrada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al abrir ventas: " + ex.Message);
            }
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubEmpleados);
        }

        private void btnGestionarEmpleados_Click(object sender, EventArgs e)
        {
            PanelContenedorForm(new fmGestionarEmpleados());
            ocultarMenu();
        }

        private void btnAgregarEmpleados_Click(object sender, EventArgs e)
        {
            PanelContenedorForm(new fmAgregarEmpleados());
            ocultarMenu();
        }

        private void btnProveedores_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubProveedores);
        }

        private void btnGestionarProveedores_Click(object sender, EventArgs e)
        {
            PanelContenedorForm(new fmGestionarProveedores());
            ocultarMenu();
        }

        private void btnAgregarProveedores_Click(object sender, EventArgs e)
        {
            PanelContenedorForm(new fmAgregarProveedores());
            ocultarMenu();
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubReportes);
        }

        private void btnReportesDeVentas_Click(object sender, EventArgs e)
        {
            PanelContenedorForm(new fmReportesVentas());
            ocultarMenu();
        }

        private void btnMedicinas_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubMedicina);
        }

        private void btnGestionarMedicinas_Click(object sender, EventArgs e)
        {
            PanelContenedorForm(new fmGestionarMedicina());
            ocultarMenu();
        }

        private void btnAgregarMedicina_Click(object sender, EventArgs e)
        {
            PanelContenedorForm(new fmAgregarMedicina());
            ocultarMenu();
        }

        private void btnLotes_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubLotes);
        }

        private void btnGestionarLotes_Click(object sender, EventArgs e)
        {
            PanelContenedorForm(new fmGestionarLotes());
            ocultarMenu();
        }

        private void btnAgregarLotes_Click(object sender, EventArgs e)
        {
            try
            {
                // --- CORRECCIÓN 1: VALIDACIÓN DE ID ---
                // Evita el error "El valor no puede ser nulo"
                int idEmpleadoInt = 0;
                if (string.IsNullOrEmpty(IdUsuario) || !int.TryParse(IdUsuario, out idEmpleadoInt))
                {
                    idEmpleadoInt = 1; // ID de respaldo por si falla
                }

                CsCaja logica = new CsCaja();

                // 2. VERIFICAR SI LA CAJA ESTÁ ABIERTA
                if (logica.EstaCajaAbierta(idEmpleadoInt))
                {
                    // --- CORRECCIÓN 2: USAR LA MISMA INSTANCIA ---
                    fmAgregarLotes lotes = new fmAgregarLotes(); // Asegúrate que el nombre de la clase sea correcto (Singular o Plural)

                    // Le pasamos el ID a ESTA instancia
                    lotes.IdEmpleadoLogueado = idEmpleadoInt;

                    // Pasamos ESTA MISMA instancia al panel (NO hagas 'new' otra vez aquí)
                    PanelContenedorForm(lotes);

                    ocultarMenu();
                }
                else
                {
                    // 3. CAJA CERRADA -> ABRIR EL FORMULARIO PEQUEÑO
                    fmAbrirCaja frmPequeño = new fmAbrirCaja();
                    frmPequeño.IdEmpleadoRecibido = idEmpleadoInt;

                    if (frmPequeño.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Sesión iniciada. Ahora puedes ingresar.", "Sistema");
                        // Opcional: Podrías abrir lotes automáticamente aquí también si quieres
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en menú: " + ex.Message);
            }
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelSubAdministracion);
        }

        private void btnMovimientos_Click(object sender, EventArgs e)
        {
            PanelContenedorForm(new fmMovimientos());
            ocultarMenu();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            PanelContenedorForm(new fmMovimientos());
            ocultarMenu();
        }

        private void btnVerUsuarios_Click(object sender, EventArgs e)
        {
            PanelContenedorForm(new fmVerUsuarios());
            ocultarMenu();
        }

        private void btnCrearCuentas_Click(object sender, EventArgs e)
        {
            PanelContenedorForm(new fmCrearCuentas());
            ocultarMenu();
        }
        private Form activoForm = null;
        private void PanelContenedorForm(Form ContenedorForm)
        {
            if (activoForm != null)
                activoForm.Close();
            activoForm = ContenedorForm;
            ContenedorForm.TopLevel = false;
            ContenedorForm.FormBorderStyle = FormBorderStyle.None;
            ContenedorForm.Dock = DockStyle.Fill;            
            panelContenedor.Controls.Add(activoForm);
            panelContenedor.Tag = ContenedorForm;
            ContenedorForm.BringToFront();
            ContenedorForm.Show();
        }

        private void btnMovimientosCaja_Click(object sender, EventArgs e)
        {
            PanelContenedorForm(new fmMovimientos());
            ocultarMenu();
        }

        private void btnTrnassacionescaja_Click(object sender, EventArgs e)
        {
            PanelContenedorForm(new fmMovimientos());
            ocultarMenu();
        }

        private void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            fmCerrar fmCerrar = new fmCerrar();
            fmCerrar.ShowDialog();
        }

        private void btnSuscripciones_Click(object sender, EventArgs e)
        {
            mostrarSubMenu(panelsubSuscripciones);
        }

        private void btnGestionarSus_Click(object sender, EventArgs e)
        {
            PanelContenedorForm(new fmGestionarSuscripciones());
            ocultarMenu();
        }

        private void btnAgregarSus_Click(object sender, EventArgs e)
        {
            PanelContenedorForm(new fmSuscripciones());
            ocultarMenu();
        }
    }
}
