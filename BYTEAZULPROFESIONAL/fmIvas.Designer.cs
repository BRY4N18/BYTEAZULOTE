namespace BYTEAZULPROFESIONAL
{
    partial class fmIvas
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
            this.dgvListarIva = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarIva)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvListarIva
            // 
            this.dgvListarIva.AllowUserToAddRows = false;
            this.dgvListarIva.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(81)))), ((int)(((byte)(159)))));
            this.dgvListarIva.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListarIva.Location = new System.Drawing.Point(30, 39);
            this.dgvListarIva.Margin = new System.Windows.Forms.Padding(2);
            this.dgvListarIva.MultiSelect = false;
            this.dgvListarIva.Name = "dgvListarIva";
            this.dgvListarIva.ReadOnly = true;
            this.dgvListarIva.RowHeadersVisible = false;
            this.dgvListarIva.RowHeadersWidth = 51;
            this.dgvListarIva.RowTemplate.Height = 24;
            this.dgvListarIva.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvListarIva.Size = new System.Drawing.Size(335, 390);
            this.dgvListarIva.TabIndex = 1;
            this.dgvListarIva.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListarIva_CellContentDoubleClick);
            // 
            // fmIvas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 445);
            this.Controls.Add(this.dgvListarIva);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmIvas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fmIvas";
            this.Load += new System.EventHandler(this.fmIvas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvListarIva)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvListarIva;
    }
}