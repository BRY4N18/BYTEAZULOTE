namespace BYTEAZULPROFESIONAL
{
    partial class fmReportesVentas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fmReportesVentas));
            this.btnGenerarReportes = new System.Windows.Forms.Button();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.dtpFechafin = new System.Windows.Forms.DateTimePicker();
            this.cbTipodeReportes = new System.Windows.Forms.ComboBox();
            this.rptReporte = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // btnGenerarReportes
            // 
            this.btnGenerarReportes.BackColor = System.Drawing.Color.Transparent;
            this.btnGenerarReportes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnGenerarReportes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerarReportes.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(92)))), ((int)(((byte)(185)))));
            this.btnGenerarReportes.FlatAppearance.BorderSize = 0;
            this.btnGenerarReportes.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnGenerarReportes.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnGenerarReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerarReportes.ForeColor = System.Drawing.Color.Transparent;
            this.btnGenerarReportes.Location = new System.Drawing.Point(463, 598);
            this.btnGenerarReportes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGenerarReportes.Name = "btnGenerarReportes";
            this.btnGenerarReportes.Size = new System.Drawing.Size(200, 48);
            this.btnGenerarReportes.TabIndex = 75;
            this.btnGenerarReportes.UseVisualStyleBackColor = false;
            this.btnGenerarReportes.Click += new System.EventHandler(this.btnGenerarReportes_Click);
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(214)))), ((int)(((byte)(216)))));
            this.dtpFechaInicio.CalendarTrailingForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(214)))), ((int)(((byte)(216)))));
            this.dtpFechaInicio.Location = new System.Drawing.Point(41, 124);
            this.dtpFechaInicio.Margin = new System.Windows.Forms.Padding(0);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(377, 22);
            this.dtpFechaInicio.TabIndex = 76;
            this.dtpFechaInicio.Visible = false;
            // 
            // dtpFechafin
            // 
            this.dtpFechafin.Location = new System.Drawing.Point(41, 164);
            this.dtpFechafin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFechafin.Name = "dtpFechafin";
            this.dtpFechafin.Size = new System.Drawing.Size(377, 22);
            this.dtpFechafin.TabIndex = 77;
            this.dtpFechafin.Visible = false;
            // 
            // cbTipodeReportes
            // 
            this.cbTipodeReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(186)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.cbTipodeReportes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTipodeReportes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTipodeReportes.ForeColor = System.Drawing.Color.Black;
            this.cbTipodeReportes.FormattingEnabled = true;
            this.cbTipodeReportes.Items.AddRange(new object[] {
            "Reportes de Productos mas vendidos",
            "Reportes de Productos menos vendidos",
            "Reportes De Ventas",
            "Reportes de Compras",
            "Reportes De Movimiento de Inventario (Medicinas)",
            "Reporte de Productos en Existencia",
            "Reporte de Listado de Clientes",
            "Reportes de Ventas de Empleados",
            "Reportes Graficos de Ventas Mensuales"});
            this.cbTipodeReportes.Location = new System.Drawing.Point(360, 73);
            this.cbTipodeReportes.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbTipodeReportes.Name = "cbTipodeReportes";
            this.cbTipodeReportes.Size = new System.Drawing.Size(409, 24);
            this.cbTipodeReportes.TabIndex = 78;
            this.cbTipodeReportes.SelectedIndexChanged += new System.EventHandler(this.cbTipodeReportes_SelectedIndexChanged);
            // 
            // rptReporte
            // 
            this.rptReporte.Location = new System.Drawing.Point(27, 196);
            this.rptReporte.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rptReporte.Name = "rptReporte";
            this.rptReporte.ServerReport.BearerToken = null;
            this.rptReporte.Size = new System.Drawing.Size(1053, 392);
            this.rptReporte.TabIndex = 79;
            this.rptReporte.Visible = false;
            // 
            // fmReportesVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1108, 670);
            this.Controls.Add(this.rptReporte);
            this.Controls.Add(this.cbTipodeReportes);
            this.Controls.Add(this.dtpFechafin);
            this.Controls.Add(this.dtpFechaInicio);
            this.Controls.Add(this.btnGenerarReportes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "fmReportesVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "fmReportesVentas";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGenerarReportes;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechafin;
        private System.Windows.Forms.ComboBox cbTipodeReportes;
        private Microsoft.Reporting.WinForms.ReportViewer rptReporte;
    }
}