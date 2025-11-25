namespace BYTEAZULPROFESIONAL
{
    partial class fmCrearCuentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmCrearCuentas));
            this.btnCrearCuenta = new System.Windows.Forms.Button();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.btnCrearCuentaEmpleado = new System.Windows.Forms.Button();
            this.txtusuario = new System.Windows.Forms.TextBox();
            this.txtContraseña = new System.Windows.Forms.TextBox();
            this.txtConfirmarContraseña = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnCrearCuenta
            // 
            this.btnCrearCuenta.BackColor = System.Drawing.Color.Transparent;
            this.btnCrearCuenta.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrearCuenta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearCuenta.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(185)))));
            this.btnCrearCuenta.FlatAppearance.BorderSize = 0;
            this.btnCrearCuenta.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCrearCuenta.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCrearCuenta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearCuenta.ForeColor = System.Drawing.Color.Transparent;
            this.btnCrearCuenta.Location = new System.Drawing.Point(306, 420);
            this.btnCrearCuenta.Name = "btnCrearCuenta";
            this.btnCrearCuenta.Size = new System.Drawing.Size(260, 52);
            this.btnCrearCuenta.TabIndex = 75;
            this.btnCrearCuenta.UseVisualStyleBackColor = false;
            // 
            // btnVerificar
            // 
            this.btnVerificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(185)))));
            this.btnVerificar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnVerificar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnVerificar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(185)))));
            this.btnVerificar.FlatAppearance.BorderSize = 0;
            this.btnVerificar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnVerificar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnVerificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificar.ForeColor = System.Drawing.Color.Transparent;
            this.btnVerificar.Location = new System.Drawing.Point(598, 151);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(119, 42);
            this.btnVerificar.TabIndex = 76;
            this.btnVerificar.Text = "Verificar cédula";
            this.btnVerificar.UseVisualStyleBackColor = false;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // btnCrearCuentaEmpleado
            // 
            this.btnCrearCuentaEmpleado.BackColor = System.Drawing.Color.Transparent;
            this.btnCrearCuentaEmpleado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrearCuentaEmpleado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearCuentaEmpleado.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(176)))), ((int)(((byte)(211)))));
            this.btnCrearCuentaEmpleado.FlatAppearance.BorderSize = 0;
            this.btnCrearCuentaEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCrearCuentaEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCrearCuentaEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearCuentaEmpleado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(176)))), ((int)(((byte)(211)))));
            this.btnCrearCuentaEmpleado.Location = new System.Drawing.Point(307, 419);
            this.btnCrearCuentaEmpleado.Name = "btnCrearCuentaEmpleado";
            this.btnCrearCuentaEmpleado.Size = new System.Drawing.Size(253, 52);
            this.btnCrearCuentaEmpleado.TabIndex = 116;
            this.btnCrearCuentaEmpleado.TabStop = false;
            this.btnCrearCuentaEmpleado.UseVisualStyleBackColor = false;
            this.btnCrearCuentaEmpleado.Click += new System.EventHandler(this.btnCrearCuentaEmpleado_Click);
            // 
            // txtusuario
            // 
            this.txtusuario.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.txtusuario.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtusuario.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtusuario.Location = new System.Drawing.Point(317, 163);
            this.txtusuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtusuario.MaxLength = 30;
            this.txtusuario.Name = "txtusuario";
            this.txtusuario.Size = new System.Drawing.Size(234, 17);
            this.txtusuario.TabIndex = 118;
            // 
            // txtContraseña
            // 
            this.txtContraseña.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.txtContraseña.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContraseña.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraseña.Location = new System.Drawing.Point(317, 253);
            this.txtContraseña.Margin = new System.Windows.Forms.Padding(2);
            this.txtContraseña.MaxLength = 30;
            this.txtContraseña.Name = "txtContraseña";
            this.txtContraseña.Size = new System.Drawing.Size(234, 17);
            this.txtContraseña.TabIndex = 1;
            // 
            // txtConfirmarContraseña
            // 
            this.txtConfirmarContraseña.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.txtConfirmarContraseña.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmarContraseña.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmarContraseña.Location = new System.Drawing.Point(317, 345);
            this.txtConfirmarContraseña.Margin = new System.Windows.Forms.Padding(2);
            this.txtConfirmarContraseña.MaxLength = 30;
            this.txtConfirmarContraseña.Name = "txtConfirmarContraseña";
            this.txtConfirmarContraseña.Size = new System.Drawing.Size(234, 17);
            this.txtConfirmarContraseña.TabIndex = 2;
            // 
            // fmCrearCuentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(831, 544);
            this.Controls.Add(this.txtConfirmarContraseña);
            this.Controls.Add(this.txtContraseña);
            this.Controls.Add(this.txtusuario);
            this.Controls.Add(this.btnCrearCuentaEmpleado);
            this.Controls.Add(this.btnVerificar);
            this.Controls.Add(this.btnCrearCuenta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmCrearCuentas";
            this.Text = "fmCrearCuentas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCrearCuenta;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Button btnCrearCuentaEmpleado;
        private System.Windows.Forms.TextBox txtusuario;
        private System.Windows.Forms.TextBox txtContraseña;
        private System.Windows.Forms.TextBox txtConfirmarContraseña;
    }
}