namespace BYTEAZULPROFESIONAL
{
    partial class fmGestionarCategorias
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmGestionarCategorias));
            this.dgvListarIva = new System.Windows.Forms.DataGridView();
            this.btnBuscarIva = new System.Windows.Forms.Button();
            this.txtNombreCategoria = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarIva)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListarIva
            // 
            this.dgvListarIva.AllowUserToAddRows = false;
            this.dgvListarIva.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(81)))), ((int)(((byte)(159)))));
            this.dgvListarIva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarIva.Location = new System.Drawing.Point(40, 147);
            this.dgvListarIva.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListarIva.MultiSelect = false;
            this.dgvListarIva.Name = "dgvListarIva";
            this.dgvListarIva.ReadOnly = true;
            this.dgvListarIva.RowHeadersVisible = false;
            this.dgvListarIva.RowHeadersWidth = 51;
            this.dgvListarIva.RowTemplate.Height = 24;
            this.dgvListarIva.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListarIva.Size = new System.Drawing.Size(764, 346);
            this.dgvListarIva.TabIndex = 23;
            // 
            // btnBuscarIva
            // 
            this.btnBuscarIva.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscarIva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscarIva.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscarIva.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(176)))), ((int)(((byte)(211)))));
            this.btnBuscarIva.FlatAppearance.BorderSize = 0;
            this.btnBuscarIva.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBuscarIva.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBuscarIva.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarIva.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(176)))), ((int)(((byte)(211)))));
            this.btnBuscarIva.Location = new System.Drawing.Point(616, 72);
            this.btnBuscarIva.Name = "btnBuscarIva";
            this.btnBuscarIva.Size = new System.Drawing.Size(22, 21);
            this.btnBuscarIva.TabIndex = 22;
            this.btnBuscarIva.UseVisualStyleBackColor = false;
            // 
            // txtNombreCategoria
            // 
            this.txtNombreCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.txtNombreCategoria.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombreCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCategoria.Location = new System.Drawing.Point(210, 75);
            this.txtNombreCategoria.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreCategoria.MaxLength = 30;
            this.txtNombreCategoria.Name = "txtNombreCategoria";
            this.txtNombreCategoria.Size = new System.Drawing.Size(398, 16);
            this.txtNombreCategoria.TabIndex = 21;
            // 
            // fmGestionarCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(831, 544);
            this.Controls.Add(this.dgvListarIva);
            this.Controls.Add(this.btnBuscarIva);
            this.Controls.Add(this.txtNombreCategoria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmGestionarCategorias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fmGestionarCategorias";
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarIva)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListarIva;
        private System.Windows.Forms.Button btnBuscarIva;
        private System.Windows.Forms.TextBox txtNombreCategoria;
    }
}