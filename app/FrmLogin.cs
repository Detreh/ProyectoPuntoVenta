using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySqlConnector;

namespace PuntoVentaApp
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Text;

            if (usuario == "" || password == "")
            {
                MessageBox.Show("Ingresa usuario y contraseña.");
                return;
            }

            try
            {
                MySqlConnectionStringBuilder conexion =
                    new MySqlConnectionStringBuilder();

                conexion.Server = "localhost";
                conexion.Port = 3306;
                conexion.Database = "punto_venta";
                conexion.UserID = usuario;
                conexion.Password = password;

                using (MySqlConnection conn =
                    new MySqlConnection(conexion.ConnectionString))
                {
                    conn.Open();

                    string perfil = "";

                    if (usuario == "admin_pv")
                    {
                        perfil = "Administrador";
                    }
                    else if (usuario == "operador_pv")
                    {
                        perfil = "Operador";
                    }
                    else
                    {
                        MessageBox.Show("Usuario no autorizado.");
                        return;
                    }

                    MessageBox.Show(
                        "Bienvenido, " + perfil + ".",
                        "Inicio de sesión exitoso"
                    );

                    // Abrir menú principal
                    FrmMenuPrincipal menu = new FrmMenuPrincipal(
                        usuario,
                        perfil,
                        this,
                        conexion.ConnectionString
                    );
                    menu.Show();

                    // Ocultar ventana de Login
                    this.Hide();
                }
            }
            catch (MySqlException)
            {
                MessageBox.Show(
                    "Usuario o contraseña incorrectos, o no fue posible conectar con MySQL.",
                    "Error de inicio de sesión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
