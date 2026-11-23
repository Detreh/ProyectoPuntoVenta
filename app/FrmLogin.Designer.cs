namespace PuntoVentaApp
{
    partial class FrmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmLogin));
            lblTitulo = new Label();
            lblUsuario = new Label();
            txtUsuario = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnIniciarSesion = new Button();
            btnSalir = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(394, 104);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(109, 20);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Punto de Venta";
            // 
            // lblUsuario
            // 
            lblUsuario.AutoSize = true;
            lblUsuario.Location = new Point(394, 140);
            lblUsuario.Name = "lblUsuario";
            lblUsuario.Size = new Size(59, 20);
            lblUsuario.TabIndex = 1;
            lblUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            txtUsuario.Location = new Point(394, 163);
            txtUsuario.Name = "txtUsuario";
            txtUsuario.Size = new Size(208, 27);
            txtUsuario.TabIndex = 2;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(394, 203);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(70, 20);
            lblPassword.TabIndex = 3;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(394, 226);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(208, 27);
            txtPassword.TabIndex = 4;
            // 
            // btnIniciarSesion
            // 
            btnIniciarSesion.Location = new Point(394, 271);
            btnIniciarSesion.Name = "btnIniciarSesion";
            btnIniciarSesion.Size = new Size(109, 29);
            btnIniciarSesion.TabIndex = 5;
            btnIniciarSesion.Text = "Iniciar Sesión";
            btnIniciarSesion.UseVisualStyleBackColor = true;
            btnIniciarSesion.Click += btnIniciarSesion_Click;
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(509, 271);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(94, 29);
            btnSalir.TabIndex = 6;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(169, 94);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(190, 206);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(btnSalir);
            Controls.Add(btnIniciarSesion);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsuario);
            Controls.Add(lblUsuario);
            Controls.Add(lblTitulo);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FrmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de Sesión - Punto de Venta";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblUsuario;
        private TextBox txtUsuario;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnIniciarSesion;
        private Button btnSalir;
        private PictureBox pictureBox1;
    }
}