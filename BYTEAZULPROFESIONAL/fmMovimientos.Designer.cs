namespace BYTEAZULPROFESIONAL
{
    partial class fmMovimientos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmMovimientos));
            this.dgvMovimientos = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.imgTransaccionesCja = new System.Windows.Forms.PictureBox();
            this.imgMovimientosCaja = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTransaccionesCja)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMovimientosCaja)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMovimientos
            // 
            this.dgvMovimientos.AllowUserToAddRows = false;
            this.dgvMovimientos.AllowUserToDeleteRows = false;
            this.dgvMovimientos.AllowUserToResizeColumns = false;
            this.dgvMovimientos.AllowUserToResizeRows = false;
            this.dgvMovimientos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMovimientos.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(81)))), ((int)(((byte)(159)))));
            this.dgvMovimientos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMovimientos.Location = new System.Drawing.Point(36, 148);
            this.dgvMovimientos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvMovimientos.MultiSelect = false;
            this.dgvMovimientos.Name = "dgvMovimientos";
            this.dgvMovimientos.ReadOnly = true;
            this.dgvMovimientos.RowHeadersVisible = false;
            this.dgvMovimientos.RowHeadersWidth = 51;
            this.dgvMovimientos.RowTemplate.Height = 24;
            this.dgvMovimientos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMovimientos.Size = new System.Drawing.Size(772, 350);
            this.dgvMovimientos.TabIndex = 15;
            // 
            // txtBuscar
            // 
            this.txtBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.txtBuscar.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscar.Location = new System.Drawing.Point(216, 76);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.txtBuscar.MaxLength = 30;
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(386, 16);
            this.txtBuscar.TabIndex = 17;
            this.txtBuscar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBuscar_KeyPress);
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
            this.btnBuscar.Location = new System.Drawing.Point(616, 75);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(22, 21);
            this.btnBuscar.TabIndex = 16;
            this.btnBuscar.UseVisualStyleBackColor = false;
            // 
            // imgTransaccionesCja
            // 
            this.imgTransaccionesCja.BackColor = System.Drawing.Color.Transparent;
            this.imgTransaccionesCja.Image = ((System.Drawing.Image)(resources.GetObject("imgTransaccionesCja.Image")));
            this.imgTransaccionesCja.Location = new System.Drawing.Point(308, 2);
            this.imgTransaccionesCja.Margin = new System.Windows.Forms.Padding(2);
            this.imgTransaccionesCja.Name = "imgTransaccionesCja";
            this.imgTransaccionesCja.Size = new System.Drawing.Size(225, 41);
            this.imgTransaccionesCja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgTransaccionesCja.TabIndex = 19;
            this.imgTransaccionesCja.TabStop = false;
            this.imgTransaccionesCja.Visible = false;
            // 
            // imgMovimientosCaja
            // 
            this.imgMovimientosCaja.BackColor = System.Drawing.Color.Transparent;
            this.imgMovimientosCaja.Image = ((System.Drawing.Image)(resources.GetObject("imgMovimientosCaja.Image")));
            this.imgMovimientosCaja.Location = new System.Drawing.Point(308, 2);
            this.imgMovimientosCaja.Margin = new System.Windows.Forms.Padding(2);
            this.imgMovimientosCaja.Name = "imgMovimientosCaja";
            this.imgMovimientosCaja.Size = new System.Drawing.Size(225, 35);
            this.imgMovimientosCaja.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgMovimientosCaja.TabIndex = 20;
            this.imgMovimientosCaja.TabStop = false;
            this.imgMovimientosCaja.Visible = false;
            // 
            // fmMovimientos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(831, 544);
            this.Controls.Add(this.imgMovimientosCaja);
            this.Controls.Add(this.imgTransaccionesCja);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dgvMovimientos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fmMovimientos";
            this.Text = "fmMovimientos";
            this.Load += new System.EventHandler(this.fmMovimientos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMovimientos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTransaccionesCja)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgMovimientosCaja)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMovimientos;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.PictureBox imgTransaccionesCja;
        private System.Windows.Forms.PictureBox imgMovimientosCaja;
    }
}