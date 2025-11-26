namespace BYTEAZULPROFESIONAL
{
    partial class fmAgregarMedicina
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmAgregarMedicina));
            this.txtNombreMedicina = new System.Windows.Forms.TextBox();
            this.txtCantidadMedida = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.btnAgregarMedicina = new System.Windows.Forms.Button();
            this.btnModificarMedicina = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.cmbUnidadMedida = new System.Windows.Forms.ComboBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.txtPrecioMedida = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtNombreMedicina
            // 
            this.txtNombreMedicina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.txtNombreMedicina.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreMedicina.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreMedicina.Location = new System.Drawing.Point(104, 140);
            this.txtNombreMedicina.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombreMedicina.Name = "txtNombreMedicina";
            this.txtNombreMedicina.Size = new System.Drawing.Size(384, 20);
            this.txtNombreMedicina.TabIndex = 0;
            this.txtNombreMedicina.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtCantidadMedida
            // 
            this.txtCantidadMedida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.txtCantidadMedida.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCantidadMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadMedida.Location = new System.Drawing.Point(132, 441);
            this.txtCantidadMedida.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCantidadMedida.Name = "txtCantidadMedida";
            this.txtCantidadMedida.Size = new System.Drawing.Size(328, 20);
            this.txtCantidadMedida.TabIndex = 3;
            this.txtCantidadMedida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCantidadMedida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidadMedida_KeyPress);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.txtDescripcion.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDescripcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(620, 140);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(383, 20);
            this.txtDescripcion.TabIndex = 3;
            this.txtDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtPrecio
            // 
            this.txtPrecio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.txtPrecio.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrecio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(109, 240);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(371, 20);
            this.txtPrecio.TabIndex = 5;
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // btnAgregarMedicina
            // 
            this.btnAgregarMedicina.BackColor = System.Drawing.Color.Transparent;
            this.btnAgregarMedicina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnAgregarMedicina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarMedicina.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(185)))));
            this.btnAgregarMedicina.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(185)))));
            this.btnAgregarMedicina.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(185)))));
            this.btnAgregarMedicina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarMedicina.ForeColor = System.Drawing.Color.Transparent;
            this.btnAgregarMedicina.Location = new System.Drawing.Point(157, 542);
            this.btnAgregarMedicina.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregarMedicina.Name = "btnAgregarMedicina";
            this.btnAgregarMedicina.Size = new System.Drawing.Size(344, 74);
            this.btnAgregarMedicina.TabIndex = 8;
            this.btnAgregarMedicina.TabStop = false;
            this.btnAgregarMedicina.UseVisualStyleBackColor = false;
            this.btnAgregarMedicina.Click += new System.EventHandler(this.btnAgregarMedicina_Click);
            // 
            // btnModificarMedicina
            // 
            this.btnModificarMedicina.BackColor = System.Drawing.Color.Transparent;
            this.btnModificarMedicina.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnModificarMedicina.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnModificarMedicina.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(185)))));
            this.btnModificarMedicina.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(185)))));
            this.btnModificarMedicina.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(185)))));
            this.btnModificarMedicina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarMedicina.ForeColor = System.Drawing.Color.Transparent;
            this.btnModificarMedicina.Location = new System.Drawing.Point(605, 540);
            this.btnModificarMedicina.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnModificarMedicina.Name = "btnModificarMedicina";
            this.btnModificarMedicina.Size = new System.Drawing.Size(344, 78);
            this.btnModificarMedicina.TabIndex = 9;
            this.btnModificarMedicina.TabStop = false;
            this.btnModificarMedicina.UseVisualStyleBackColor = false;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(185)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(185)))));
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(185)))));
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.Transparent;
            this.btnBuscar.Location = new System.Drawing.Point(870, 463);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(40, 38);
            this.btnBuscar.TabIndex = 2;
            this.btnBuscar.TabStop = false;
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Visible = false;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.cmbCategoria.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(620, 236);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(383, 28);
            this.cmbCategoria.TabIndex = 4;
            // 
            // cmbUnidadMedida
            // 
            this.cmbUnidadMedida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.cmbUnidadMedida.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUnidadMedida.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbUnidadMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnidadMedida.FormattingEnabled = true;
            this.cmbUnidadMedida.Location = new System.Drawing.Point(620, 336);
            this.cmbUnidadMedida.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbUnidadMedida.Name = "cmbUnidadMedida";
            this.cmbUnidadMedida.Size = new System.Drawing.Size(383, 28);
            this.cmbUnidadMedida.TabIndex = 7;
            // 
            // cmbEstado
            // 
            this.cmbEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbEstado.Location = new System.Drawing.Point(107, 336);
            this.cmbEstado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(383, 28);
            this.cmbEstado.TabIndex = 6;
            // 
            // txtPrecioMedida
            // 
            this.txtPrecioMedida.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.txtPrecioMedida.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPrecioMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioMedida.Location = new System.Drawing.Point(648, 440);
            this.txtPrecioMedida.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecioMedida.Name = "txtPrecioMedida";
            this.txtPrecioMedida.Size = new System.Drawing.Size(328, 20);
            this.txtPrecioMedida.TabIndex = 10;
            this.txtPrecioMedida.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPrecioMedida.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecioMedida_KeyPress);
            // 
            // fmAgregarMedicina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1108, 670);
            this.Controls.Add(this.txtPrecioMedida);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.cmbUnidadMedida);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnModificarMedicina);
            this.Controls.Add(this.btnAgregarMedicina);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.txtCantidadMedida);
            this.Controls.Add(this.txtNombreMedicina);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "fmAgregarMedicina";
            this.Text = "fmAgregarMedicina";
            this.Load += new System.EventHandler(this.fmAgregarMedicina_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNombreMedicina;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button btnAgregarMedicina;
        private System.Windows.Forms.Button btnModificarMedicina;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.ComboBox cmbUnidadMedida;
        public System.Windows.Forms.TextBox txtCantidadMedida;
        private System.Windows.Forms.ComboBox cmbEstado;
        public System.Windows.Forms.TextBox txtPrecioMedida;
    }
}