using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySqlConnector;

namespace PuntoVentaApp.Datos
{
    public class ClientesDAO
    {
        private string cadenaConexion;

        public ClientesDAO(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        public DataTable ObtenerClientes(string filtro = "")
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string consulta = @"SELECT id_cliente, nombre, apellidos, telefono, correo, direccion, fecha_registro
                                   FROM clientes
                                   WHERE nombre LIKE @filtro
                                      OR apellidos LIKE @filtro
                                      OR telefono LIKE @filtro
                                      OR correo LIKE @filtro
                                   ORDER BY id_cliente";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
                adaptador.SelectCommand.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                return tabla;
            }
        }

        public void AgregarCliente(string nombre, string apellidos, string telefono,
                                  string correo, string direccion)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string consulta = @"INSERT INTO clientes
                                   (nombre, apellidos, telefono, correo, direccion)
                                   VALUES
                                   (@nombre, @apellidos, @telefono, @correo, @direccion)";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@apellidos", apellidos);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@correo",
                    string.IsNullOrWhiteSpace(correo) ? DBNull.Value : correo);
                comando.Parameters.AddWithValue("@direccion", direccion);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void EditarCliente(int idCliente, string nombre, string apellidos,
                                  string telefono, string correo, string direccion)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string consulta = @"UPDATE clientes
                                   SET nombre = @nombre,
                                       apellidos = @apellidos,
                                       telefono = @telefono,
                                       correo = @correo,
                                       direccion = @direccion
                                   WHERE id_cliente = @id";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);

                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@apellidos", apellidos);
                comando.Parameters.AddWithValue("@telefono", telefono);
                comando.Parameters.AddWithValue("@correo",
                    string.IsNullOrWhiteSpace(correo) ? DBNull.Value : correo);
                comando.Parameters.AddWithValue("@direccion", direccion);
                comando.Parameters.AddWithValue("@id", idCliente);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void EliminarCliente(int idCliente)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string consulta = "DELETE FROM clientes WHERE id_cliente = @id";

                MySqlCommand comando = new MySqlCommand(consulta, conexion);
                comando.Parameters.AddWithValue("@id", idCliente);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }
    }
}