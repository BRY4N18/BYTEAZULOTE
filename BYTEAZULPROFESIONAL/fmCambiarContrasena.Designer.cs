namespace BYTEAZULPROFESIONAL
{
    partial class fmCambiarContrasena
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmCambiarContrasena));
            this.btnConfirmar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.txtConfirmarContra = new System.Windows.Forms.TextBox();
            this.txtNuevaContra = new System.Windows.Forms.TextBox();
            this.txtContraActual = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnConfirmar
            // 
            this.btnConfirmar.BackColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnConfirmar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnConfirmar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(185)))));
            this.btnConfirmar.FlatAppearance.BorderSize = 0;
            this.btnConfirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConfirmar.ForeColor = System.Drawing.Color.Transparent;
            this.btnConfirmar.Location = new System.Drawing.Point(12, 244);
            this.btnConfirmar.Name = "btnConfirmar";
            this.btnConfirmar.Size = new System.Drawing.Size(130, 29);
            this.btnConfirmar.TabIndex = 81;
            this.btnConfirmar.TabStop = false;
            this.btnConfirmar.UseVisualStyleBackColor = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancelar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancelar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(185)))));
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.ForeColor = System.Drawing.Color.Transparent;
            this.btnCancelar.Location = new System.Drawing.Point(167, 244);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 29);
            this.btnCancelar.TabIndex = 82;
            this.btnCancelar.TabStop = false;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click_1);
            // 
            // txtConfirmarContra
            // 
            this.txtConfirmarContra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(214)))), ((int)(((byte)(216)))));
            this.txtConfirmarContra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmarContra.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirmarContra.Location = new System.Drawing.Point(38, 187);
            this.txtConfirmarContra.MaxLength = 10;
            this.txtConfirmarContra.Name = "txtConfirmarContra";
            this.txtConfirmarContra.Size = new System.Drawing.Size(224, 21);
            this.txtConfirmarContra.TabIndex = 3;
            // 
            // txtNuevaContra
            // 
            this.txtNuevaContra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(214)))), ((int)(((byte)(216)))));
            this.txtNuevaContra.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNuevaContra.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNuevaContra.Location = new System.Drawing.Point(38, 117);
            this.txtNuevaContra.MaxLength = 10;
            this.txtNuevaContra.Name = "txtNuevaContra";
            this.txtNuevaContra.Size = new System.Drawing.Size(224, 21);
            this.txtNuevaContra.TabIndex = 2;
            // 
            // txtContraActual
            // 
            this.txtContraActual.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(214)))), ((int)(((byte)(216)))));
            this.txtContraActual.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtContraActual.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContraActual.Location = new System.Drawing.Point(38, 43);
            this.txtContraActual.MaxLength = 10;
            this.txtContraActual.Name = "txtContraActual";
            this.txtContraActual.Size = new System.Drawing.Size(224, 21);
            this.txtContraActual.TabIndex = 1;
            // 
            // fmCambiarContrasena
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.txtContraActual);
            this.Controls.Add(this.txtNuevaContra);
            this.Controls.Add(this.txtConfirmarContra);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnConfirmar);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmCambiarContrasena";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fmCambiarContrasena";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConfirmar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtConfirmarContra;
        private System.Windows.Forms.TextBox txtNuevaContra;
        private System.Windows.Forms.TextBox txtContraActual;
    }
}