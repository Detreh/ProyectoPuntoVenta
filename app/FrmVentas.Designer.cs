namespace PuntoVentaApp
{
    partial class FrmVentas
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
            gbDatos = new GroupBox();
            cmbMetodoPago = new ComboBox();
            lblMetodoPago = new Label();
            cmbClientes = new ComboBox();
            lblCliente = new Label();
            gbAgregarProductos = new GroupBox();
            btnAgregarProducto = new Button();
            txtCantidad = new TextBox();
            lblCantidad = new Label();
            cmbProductos = new ComboBox();
            lblProducto = new Label();
            btnQuitarProducto = new Button();
            txtDetalleVenta = new Label();
            dgvDetalleVenta = new DataGridView();
            lblTotal = new Label();
            btnRegistrarVenta = new Button();
            btnVolver = new Button();
            btnLimpiar = new Button();
            gbDatos.SuspendLayout();
            gbAgregarProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(477, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(52, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Ventas";
            // 
            // gbDatos
            // 
            gbDatos.Controls.Add(cmbMetodoPago);
            gbDatos.Controls.Add(lblMetodoPago);
            gbDatos.Controls.Add(cmbClientes);
            gbDatos.Controls.Add(lblCliente);
            gbDatos.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbDatos.ForeColor = SystemColors.ActiveCaptionText;
            gbDatos.Location = new Point(12, 42);
            gbDatos.Name = "gbDatos";
            gbDatos.RightToLeft = RightToLeft.No;
            gbDatos.Size = new Size(958, 118);
            gbDatos.TabIndex = 1;
            gbDatos.TabStop = false;
            gbDatos.Text = "Datos de la venta";
            // 
            // cmbMetodoPago
            // 
            cmbMetodoPago.FormattingEnabled = true;
            cmbMetodoPago.Location = new Point(491, 55);
            cmbMetodoPago.Name = "cmbMetodoPago";
            cmbMetodoPago.Size = new Size(461, 28);
            cmbMetodoPago.TabIndex = 3;
            // 
            // lblMetodoPago
            // 
            lblMetodoPago.AutoSize = true;
            lblMetodoPago.Location = new Point(491, 32);
            lblMetodoPago.Name = "lblMetodoPago";
            lblMetodoPago.Size = new Size(120, 20);
            lblMetodoPago.TabIndex = 2;
            lblMetodoPago.Text = "Método de Pago";
            // 
            // cmbClientes
            // 
            cmbClientes.FormattingEnabled = true;
            cmbClientes.Location = new Point(6, 55);
            cmbClientes.Name = "cmbClientes";
            cmbClientes.Size = new Size(454, 28);
            cmbClientes.TabIndex = 1;
            // 
            // lblCliente
            // 
            lblCliente.AutoSize = true;
            lblCliente.Location = new Point(6, 32);
            lblCliente.Name = "lblCliente";
            lblCliente.Size = new Size(55, 20);
            lblCliente.TabIndex = 0;
            lblCliente.Text = "Cliente";
            // 
            // gbAgregarProductos
            // 
            gbAgregarProductos.Controls.Add(btnAgregarProducto);
            gbAgregarProductos.Controls.Add(txtCantidad);
            gbAgregarProductos.Controls.Add(lblCantidad);
            gbAgregarProductos.Controls.Add(cmbProductos);
            gbAgregarProductos.Controls.Add(lblProducto);
            gbAgregarProductos.Location = new Point(18, 183);
            gbAgregarProductos.Name = "gbAgregarProductos";
            gbAgregarProductos.Size = new Size(946, 115);
            gbAgregarProductos.TabIndex = 2;
            gbAgregarProductos.TabStop = false;
            gbAgregarProductos.Text = "Agregar productos";
            // 
            // btnAgregarProducto
            // 
            btnAgregarProducto.Location = new Point(790, 55);
            btnAgregarProducto.Name = "btnAgregarProducto";
            btnAgregarProducto.Size = new Size(94, 29);
            btnAgregarProducto.TabIndex = 4;
            btnAgregarProducto.Text = "Agregar";
            btnAgregarProducto.UseVisualStyleBackColor = true;
            btnAgregarProducto.Click += btnAgregarProducto_Click;
            // 
            // txtCantidad
            // 
            txtCantidad.Location = new Point(461, 57);
            txtCantidad.Name = "txtCantidad";
            txtCantidad.Size = new Size(270, 27);
            txtCantidad.TabIndex = 3;
            // 
            // lblCantidad
            // 
            lblCantidad.AutoSize = true;
            lblCantidad.Location = new Point(461, 33);
            lblCantidad.Name = "lblCantidad";
            lblCantidad.Size = new Size(69, 20);
            lblCantidad.TabIndex = 2;
            lblCantidad.Text = "Cantidad";
            // 
            // cmbProductos
            // 
            cmbProductos.FormattingEnabled = true;
            cmbProductos.Location = new Point(8, 56);
            cmbProductos.Name = "cmbProductos";
            cmbProductos.Size = new Size(439, 28);
            cmbProductos.TabIndex = 1;
            // 
            // lblProducto
            // 
            lblProducto.AutoSize = true;
            lblProducto.Location = new Point(8, 33);
            lblProducto.Name = "lblProducto";
            lblProducto.Size = new Size(69, 20);
            lblProducto.TabIndex = 0;
            lblProducto.Text = "Producto";
            // 
            // btnQuitarProducto
            // 
            btnQuitarProducto.Location = new Point(783, 313);
            btnQuitarProducto.Name = "btnQuitarProducto";
            btnQuitarProducto.Size = new Size(181, 29);
            btnQuitarProducto.TabIndex = 5;
            btnQuitarProducto.Text = "Quitar producto";
            btnQuitarProducto.UseVisualStyleBackColor = true;
            btnQuitarProducto.Click += btnQuitarProducto_Click;
            // 
            // txtDetalleVenta
            // 
            txtDetalleVenta.AutoSize = true;
            txtDetalleVenta.Location = new Point(26, 325);
            txtDetalleVenta.Name = "txtDetalleVenta";
            txtDetalleVenta.Size = new Size(134, 20);
            txtDetalleVenta.TabIndex = 3;
            txtDetalleVenta.Text = "Detalle de la venta";
            // 
            // dgvDetalleVenta
            // 
            dgvDetalleVenta.AllowUserToAddRows = false;
            dgvDetalleVenta.AllowUserToDeleteRows = false;
            dgvDetalleVenta.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleVenta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleVenta.Location = new Point(26, 348);
            dgvDetalleVenta.MultiSelect = false;
            dgvDetalleVenta.Name = "dgvDetalleVenta";
            dgvDetalleVenta.ReadOnly = true;
            dgvDetalleVenta.RowHeadersVisible = false;
            dgvDetalleVenta.RowHeadersWidth = 51;
            dgvDetalleVenta.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDetalleVenta.Size = new Size(938, 135);
            dgvDetalleVenta.TabIndex = 4;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(26, 515);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(84, 20);
            lblTotal.TabIndex = 5;
            lblTotal.Text = "Total: $0.00";
            // 
            // btnRegistrarVenta
            // 
            btnRegistrarVenta.Location = new Point(26, 553);
            btnRegistrarVenta.Name = "btnRegistrarVenta";
            btnRegistrarVenta.Size = new Size(139, 29);
            btnRegistrarVenta.TabIndex = 6;
            btnRegistrarVenta.Text = "Registrar venta";
            btnRegistrarVenta.UseVisualStyleBackColor = true;
            btnRegistrarVenta.Click += btnRegistrarVenta_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(870, 553);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(94, 29);
            btnVolver.TabIndex = 7;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(743, 553);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(94, 29);
            btnLimpiar.TabIndex = 8;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // FrmVentas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 603);
            Controls.Add(btnQuitarProducto);
            Controls.Add(btnLimpiar);
            Controls.Add(btnVolver);
            Controls.Add(btnRegistrarVenta);
            Controls.Add(lblTotal);
            Controls.Add(dgvDetalleVenta);
            Controls.Add(txtDetalleVenta);
            Controls.Add(gbAgregarProductos);
            Controls.Add(gbDatos);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmVentas";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ventas - Punto de Venta";
            Load += FrmVentas_Load;
            gbDatos.ResumeLayout(false);
            gbDatos.PerformLayout();
            gbAgregarProductos.ResumeLayout(false);
            gbAgregarProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleVenta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private GroupBox gbDatos;
        private Label lblCliente;
        private Label lblMetodoPago;
        private ComboBox cmbClientes;
        private ComboBox cmbMetodoPago;
        private GroupBox gbAgregarProductos;
        private Label lblProducto;
        private Button btnAgregarProducto;
        private TextBox txtCantidad;
        private Label lblCantidad;
        private ComboBox cmbProductos;
        private Label txtDetalleVenta;
        private DataGridView dgvDetalleVenta;
        private Label lblTotal;
        private Button btnRegistrarVenta;
        private Button btnVolver;
        private Button btnLimpiar;
        private Button btnQuitarProducto;
    }
}