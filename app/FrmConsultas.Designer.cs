namespace PuntoVentaApp
{
    partial class FrmConsultas
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
            lblTitulo = new Label();
            lblBuscar = new Label();
            txtBuscar = new TextBox();
            lblFechaInicio = new Label();
            dtpFechaInicio = new DateTimePicker();
            lblFechaFin = new Label();
            dtpFechaFin = new DateTimePicker();
            btnBuscar = new Button();
            btnMostarTodas = new Button();
            dgvVentas = new DataGridView();
            dgvDetalleVenta = new DataGridView();
            lblTotalVentas = new Label();
            btnVolver = new Button();
            lblTituloHistorial = new Label();
            lblTituloDetalle = new Label();
            lblTipoReporte = new Label();
            cmbTipoReporte = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(420, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(142, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Consultas y reportes";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(13, 84);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(156, 20);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "Buscar venta o cliente:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(175, 81);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(652, 27);
            txtBuscar.TabIndex = 2;
            // 
            // lblFechaInicio
            // 
            lblFechaInicio.AutoSize = true;
            lblFechaInicio.Location = new Point(13, 146);
            lblFechaInicio.Name = "lblFechaInicio";
            lblFechaInicio.Size = new Size(54, 20);
            lblFechaInicio.TabIndex = 3;
            lblFechaInicio.Text = "Desde:";
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(73, 141);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.ShowCheckBox = true;
            dtpFechaInicio.Size = new Size(304, 27);
            dtpFechaInicio.TabIndex = 4;
            // 
            // lblFechaFin
            // 
            lblFechaFin.AutoSize = true;
            lblFechaFin.Location = new Point(408, 146);
            lblFechaFin.Name = "lblFechaFin";
            lblFechaFin.Size = new Size(50, 20);
            lblFechaFin.TabIndex = 5;
            lblFechaFin.Text = "Hasta:";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(464, 141);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.ShowCheckBox = true;
            dtpFechaFin.Size = new Size(363, 27);
            dtpFechaFin.TabIndex = 6;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(857, 110);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 7;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // btnMostarTodas
            // 
            btnMostarTodas.Location = new Point(857, 156);
            btnMostarTodas.Name = "btnMostarTodas";
            btnMostarTodas.Size = new Size(94, 52);
            btnMostarTodas.TabIndex = 8;
            btnMostarTodas.Text = "Mostar todas";
            btnMostarTodas.UseVisualStyleBackColor = true;
            btnMostarTodas.Click += btnMostarTodas_Click;
            // 
            // dgvVentas
            // 
            dgvVentas.AllowUserToAddRows = false;
            dgvVentas.AllowUserToDeleteRows = false;
            dgvVentas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Location = new Point(32, 237);
            dgvVentas.MultiSelect = false;
            dgvVentas.Name = "dgvVentas";
            dgvVentas.ReadOnly = true;
            dgvVentas.RowHeadersVisible = false;
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvVentas.Size = new Size(453, 188);
            dgvVentas.TabIndex = 9;
            // 
            // dgvDetalleVenta
            // 
            dgvDetalleVenta.AllowUserToAddRows = false;
            dgvDetalleVenta.AllowUserToDeleteRows = false;
            dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleVenta.Location = new Point(503, 237);
            dgvDetalleVenta.MultiSelect = false;
            dgvDetalleVenta.Name = "dgvDetalleVenta";
            dgvDetalleVenta.ReadOnly = true;
            dgvDetalleVenta.RowHeadersVisible = false;
            dgvDetalleVenta.RowHeadersWidth = 51;
            dgvDetalleVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleVenta.Size = new Size(448, 188);
            dgvDetalleVenta.TabIndex = 10;
            // 
            // lblTotalVentas
            // 
            lblTotalVentas.AutoSize = true;
            lblTotalVentas.Location = new Point(32, 463);
            lblTotalVentas.Name = "lblTotalVentas";
            lblTotalVentas.Size = new Size(142, 20);
            lblTotalVentas.TabIndex = 11;
            lblTotalVentas.Text = "Total vendido: $0.00";
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(856, 547);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(94, 29);
            btnVolver.TabIndex = 13;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // lblTituloHistorial
            // 
            lblTituloHistorial.AutoSize = true;
            lblTituloHistorial.Location = new Point(32, 214);
            lblTituloHistorial.Name = "lblTituloHistorial";
            lblTituloHistorial.Size = new Size(132, 20);
            lblTituloHistorial.TabIndex = 14;
            lblTituloHistorial.Text = "Historial de ventas";
            // 
            // lblTituloDetalle
            // 
            lblTituloDetalle.AutoSize = true;
            lblTituloDetalle.Location = new Point(503, 214);
            lblTituloDetalle.Name = "lblTituloDetalle";
            lblTituloDetalle.Size = new Size(134, 20);
            lblTituloDetalle.TabIndex = 15;
            lblTituloDetalle.Text = "Detalle de la venta";
            // 
            // lblTipoReporte
            // 
            lblTipoReporte.AutoSize = true;
            lblTipoReporte.Location = new Point(17, 31);
            lblTipoReporte.Name = "lblTipoReporte";
            lblTipoReporte.Size = new Size(116, 20);
            lblTipoReporte.TabIndex = 16;
            lblTipoReporte.Text = "Tipo de reporte:";
            // 
            // cmbTipoReporte
            // 
            cmbTipoReporte.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTipoReporte.FormattingEnabled = true;
            cmbTipoReporte.Location = new Point(139, 28);
            cmbTipoReporte.Name = "cmbTipoReporte";
            cmbTipoReporte.Size = new Size(220, 28);
            cmbTipoReporte.TabIndex = 17;
            cmbTipoReporte.SelectedIndexChanged += cmbTipoReporte_SelectedIndexChanged;
            // 
            // FrmConsultas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(cmbTipoReporte);
            Controls.Add(lblTipoReporte);
            Controls.Add(lblTituloDetalle);
            Controls.Add(lblTituloHistorial);
            Controls.Add(btnVolver);
            Controls.Add(lblTotalVentas);
            Controls.Add(dgvDetalleVenta);
            Controls.Add(dgvVentas);
            Controls.Add(btnMostarTodas);
            Controls.Add(btnBuscar);
            Controls.Add(dtpFechaFin);
            Controls.Add(lblFechaFin);
            Controls.Add(dtpFechaInicio);
            Controls.Add(lblFechaInicio);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmConsultas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Consultas y reportes - Punto de Venta";
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Label lblFechaInicio;
        private DateTimePicker dtpFechaInicio;
        private Label lblFechaFin;
        private DateTimePicker dtpFechaFin;
        private Button btnBuscar;
        private Button btnMostarTodas;
        private DataGridView dgvVentas;
        private DataGridView dgvDetalleVenta;
        private Label lblTotalVentas;
        private Button btnVolver;
        private Label lblTituloHistorial;
        private Label lblTituloDetalle;
        private Label lblTipoReporte;
        private ComboBox cmbTipoReporte;
    }
}