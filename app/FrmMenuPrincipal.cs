using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PuntoVentaApp
{
    public partial class FrmMenuPrincipal : Form
    {
        private string usuario;
        private string perfil;
        private string cadenaConexion;
        private FrmLogin login;
        public FrmMenuPrincipal(string usuario, string perfil, FrmLogin login, string cadenaConexion)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.perfil = perfil;
            this.login = login;
            this.cadenaConexion = cadenaConexion;

            lblUsuario.Text = "Usuario: " + usuario + " | Rol: " + perfil;

            // Mostrar opciones según el rol
            if (perfil == "Administrador")
            {
                btnProductos.Visible = true;
                btnClientes.Visible = true;
                btnVentas.Visible = true;
                btnReportes.Visible = true;
            }
            else
            {
                btnProductos.Visible = true;
                btnClientes.Visible = true;
                btnVentas.Visible = true;
                btnReportes.Visible = true;
            }
        }

        private void FrmMenuPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            login.Show();
            this.Close();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            FrmProductos productos = new FrmProductos(cadenaConexion, perfil);
            productos.ShowDialog();
        }
    }
}
