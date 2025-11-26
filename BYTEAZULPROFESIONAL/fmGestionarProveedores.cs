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

        public fmGestionarProveedores() // Constructor default
        {
            InitializeComponent();
        }

        private void fmGestionarProveedores_Load(object sender, EventArgs e)
        {
            csProveedores = new CsProveedores();
            dgvVerProveedores.DataSource = csProveedores.BuscarProveedores(btnBuscar.Text);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            csProveedores = new CsProveedores();
            dgvVerProveedores.DataSource = csProveedores.BuscarProveedores(btnBuscar.Text);
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
    }
}
