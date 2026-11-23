using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using System.Configuration;

namespace PuntoVentaApp.Datos
{
    public class LoginDAO
    {
        public bool IniciarSesion(string usuario, string password, out string perfil, out string cadenaConexion)
        {
            perfil = "";
            cadenaConexion = "";

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
                return false;
            }

            MySqlConnectionStringBuilder conexion = new MySqlConnectionStringBuilder();

            conexion.Server = ConfigurationManager.AppSettings["ServidorBD"];
            conexion.Port = Convert.ToUInt32(ConfigurationManager.AppSettings["PuertoBD"]);
            conexion.Database = ConfigurationManager.AppSettings["BaseDatos"];
            conexion.UserID = usuario;
            conexion.Password = password;

            using (MySqlConnection conn = new MySqlConnection(conexion.ConnectionString))
            {
                conn.Open();
            }

            cadenaConexion = conexion.ConnectionString;

            return true;
        }
    }
}
