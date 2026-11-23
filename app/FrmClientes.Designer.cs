namespace PuntoVentaApp
{
    partial class FrmClientes
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
            btnBuscar = new Button();
            dgvClientes = new DataGridView();
            lblNombre = new Label();
            txtNombre = new TextBox();
            lblApellidos = new Label();
            txtApellidos = new TextBox();
            txtTelefono = new TextBox();
            lblCorreo = new Label();
            txtCorreo = new TextBox();
            lblDireccion = new Label();
            lblTelefono = new Label();
            txtDireccion = new TextBox();
            btnAgregar = new Button();
            btnEditar = new Button();
            btnEliminar = new Button();
            btnLimpiar = new Button();
            btnVolver = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(421, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(136, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Gestión de Clientes";
            // 
            // lblBuscar
            // 
            lblBuscar.AutoSize = true;
            lblBuscar.Location = new Point(12, 47);
            lblBuscar.Name = "lblBuscar";
            lblBuscar.Size = new Size(103, 20);
            lblBuscar.TabIndex = 1;
            lblBuscar.Text = "Buscar cliente:";
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(121, 44);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(737, 27);
            txtBuscar.TabIndex = 2;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(864, 43);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(106, 29);
            btnBuscar.TabIndex = 3;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click;
            // 
            // dgvClientes
            // 
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Location = new Point(12, 77);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.Size = new Size(958, 257);
            dgvClientes.TabIndex = 4;
            dgvClientes.CellClick += dgvClientes_CellClick;
            dgvClientes.CellContentClick += dgvClientes_CellContentClick;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(12, 337);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(67, 20);
            lblNombre.TabIndex = 5;
            lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(12, 360);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(479, 27);
            txtNombre.TabIndex = 6;
            // 
            // lblApellidos
            // 
            lblApellidos.AutoSize = true;
            lblApellidos.Location = new Point(498, 337);
            lblApellidos.Name = "lblApellidos";
            lblApellidos.Size = new Size(75, 20);
            lblApellidos.TabIndex = 7;
            lblApellidos.Text = "Apellidos:";
            // 
            // txtApellidos
            // 
            txtApellidos.Location = new Point(498, 360);
            txtApellidos.Name = "txtApellidos";
            txtApellidos.Size = new Size(472, 27);
            txtApellidos.TabIndex = 8;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(12, 413);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(479, 27);
            txtTelefono.TabIndex = 10;
            // 
            // lblCorreo
            // 
            lblCorreo.AutoSize = true;
            lblCorreo.Location = new Point(498, 390);
            lblCorreo.Name = "lblCorreo";
            lblCorreo.Size = new Size(57, 20);
            lblCorreo.TabIndex = 11;
            lblCorreo.Text = "Correo:";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(498, 413);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(472, 27);
            txtCorreo.TabIndex = 12;
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(12, 443);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(75, 20);
            lblDireccion.TabIndex = 13;
            lblDireccion.Text = "Dirección:";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(12, 390);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(70, 20);
            lblTelefono.TabIndex = 14;
            lblTelefono.Text = "Teléfono:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(12, 466);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(479, 27);
            txtDireccion.TabIndex = 15;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 512);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 29);
            btnAgregar.TabIndex = 16;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnEditar
            // 
            btnEditar.Location = new Point(155, 512);
            btnEditar.Name = "btnEditar";
            btnEditar.Size = new Size(94, 29);
            btnEditar.TabIndex = 17;
            btnEditar.Text = "Editar";
            btnEditar.UseVisualStyleBackColor = true;
            btnEditar.Click += btnEditar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(302, 512);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(94, 29);
            btnEliminar.TabIndex = 18;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Location = new Point(452, 512);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(94, 29);
            btnLimpiar.TabIndex = 19;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            btnLimpiar.Click += btnLimpiar_Click;
            // 
            // btnVolver
            // 
            btnVolver.Location = new Point(864, 512);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(94, 29);
            btnVolver.TabIndex = 20;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            btnVolver.Click += btnVolver_Click;
            // 
            // FrmClientes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 553);
            Controls.Add(btnVolver);
            Controls.Add(btnLimpiar);
            Controls.Add(btnEliminar);
            Controls.Add(btnEditar);
            Controls.Add(btnAgregar);
            Controls.Add(txtDireccion);
            Controls.Add(lblTelefono);
            Controls.Add(lblDireccion);
            Controls.Add(txtCorreo);
            Controls.Add(lblCorreo);
            Controls.Add(txtTelefono);
            Controls.Add(txtApellidos);
            Controls.Add(lblApellidos);
            Controls.Add(txtNombre);
            Controls.Add(lblNombre);
            Controls.Add(dgvClientes);
            Controls.Add(btnBuscar);
            Controls.Add(txtBuscar);
            Controls.Add(lblBuscar);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            Name = "FrmClientes";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Gestión de Clientes - Punto de Venta";
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblBuscar;
        private TextBox txtBuscar;
        private Button btnBuscar;
        private DataGridView dgvClientes;
        private Label lblNombre;
        private TextBox txtNombre;
        private Label lblApellidos;
        private TextBox txtApellidos;
        private Label label1;
        private TextBox txtTelefono;
        private Label lblCorreo;
        private TextBox txtCorreo;
        private Label lblDireccion;
        private Label lblTelefono;
        private TextBox txtDireccion;
        private Button btnAgregar;
        private Button btnEditar;
        private Button btnEliminar;
        private Button btnLimpiar;
        private Button btnVolver;
    }
}