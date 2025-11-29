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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmGestionarCategorias));
            this.btnBuscarIva = new System.Windows.Forms.Button();
            this.txtNombreCategoria = new System.Windows.Forms.TextBox();
            this.dgvVerCategorias = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerCategorias)).BeginInit();
            this.SuspendLayout();
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
            this.txtNombreCategoria.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNombreCategoria_KeyPress);
            // 
            // dgvVerCategorias
            // 
            this.dgvVerCategorias.AllowUserToAddRows = false;
            this.dgvVerCategorias.AllowUserToDeleteRows = false;
            this.dgvVerCategorias.AllowUserToResizeColumns = false;
            this.dgvVerCategorias.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvVerCategorias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvVerCategorias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVerCategorias.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(81)))), ((int)(((byte)(159)))));
            this.dgvVerCategorias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVerCategorias.Location = new System.Drawing.Point(35, 149);
            this.dgvVerCategorias.Margin = new System.Windows.Forms.Padding(2);
            this.dgvVerCategorias.MultiSelect = false;
            this.dgvVerCategorias.Name = "dgvVerCategorias";
            this.dgvVerCategorias.ReadOnly = true;
            this.dgvVerCategorias.RowHeadersVisible = false;
            this.dgvVerCategorias.RowHeadersWidth = 51;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvVerCategorias.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvVerCategorias.RowTemplate.Height = 24;
            this.dgvVerCategorias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVerCategorias.Size = new System.Drawing.Size(771, 347);
            this.dgvVerCategorias.TabIndex = 42;
            this.dgvVerCategorias.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVerCategorias_CellContentClick);
            // 
            // fmGestionarCategorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(831, 544);
            this.Controls.Add(this.dgvVerCategorias);
            this.Controls.Add(this.btnBuscarIva);
            this.Controls.Add(this.txtNombreCategoria);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmGestionarCategorias";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fmGestionarCategorias";
            this.Load += new System.EventHandler(this.fmGestionarCategorias_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerCategorias)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnBuscarIva;
        private System.Windows.Forms.TextBox txtNombreCategoria;
        private System.Windows.Forms.DataGridView dgvVerCategorias;
    }
}