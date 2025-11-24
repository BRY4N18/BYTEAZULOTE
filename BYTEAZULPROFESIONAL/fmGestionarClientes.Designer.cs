namespace BYTEAZULPROFESIONAL
{
    partial class fmGestionarClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmGestionarClientes));
            this.btnBuscar = new System.Windows.Forms.Button();
            this.dgvVerClientes = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnBuscar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBuscar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(176)))), ((int)(((byte)(211)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(176)))), ((int)(((byte)(211)))));
            this.btnBuscar.Location = new System.Drawing.Point(616, 74);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(22, 21);
            this.btnBuscar.TabIndex = 13;
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // dgvVerClientes
            // 
            this.dgvVerClientes.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(81)))), ((int)(((byte)(159)))));
            this.dgvVerClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVerClientes.Location = new System.Drawing.Point(74, 138);
            this.dgvVerClientes.Margin = new System.Windows.Forms.Padding(2);
            this.dgvVerClientes.MultiSelect = false;
            this.dgvVerClientes.Name = "dgvVerClientes";
            this.dgvVerClientes.ReadOnly = true;
            this.dgvVerClientes.RowHeadersVisible = false;
            this.dgvVerClientes.RowHeadersWidth = 51;
            this.dgvVerClientes.RowTemplate.Height = 24;
            this.dgvVerClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvVerClientes.Size = new System.Drawing.Size(697, 321);
            this.dgvVerClientes.TabIndex = 14;
            this.dgvVerClientes.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVerClientes_CellContentDoubleClick);
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(214, 76);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscar.MaxLength = 30;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(386, 16);
            this.txtBuscar.TabIndex = 15;
            // 
            // fmGestionarClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(831, 544);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.dgvVerClientes);
            this.Controls.Add(this.btnBuscar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmGestionarClientes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fmGestionarClientes";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.dgvVerClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView dgvVerClientes;
        private System.Windows.Forms.TextBox txtBuscar;
    }
}