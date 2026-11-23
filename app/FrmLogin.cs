using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MySqlConnector;
using PuntoVentaApp.Datos;

namespace PuntoVentaApp
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            EstiloUI.Aplicar(this);
            EstiloUI.AgregarFranjaSuperior(this);
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
                LoginDAO loginDAO = new LoginDAO();

                string perfil;
                string cadenaConexion;

                bool acceso = loginDAO.IniciarSesion(
                    usuario,
                    password,
                    out perfil,
                    out cadenaConexion
                );

                if (!acceso)
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
                    cadenaConexion
                );

                menu.Show();

                // Ocultar ventana de Login
                this.Hide();
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
