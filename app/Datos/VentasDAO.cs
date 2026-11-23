using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySqlConnector;

namespace PuntoVentaApp.Datos
{
    public class VentasDAO
    {
        private string cadenaConexion;

        public VentasDAO(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        public DataTable ObtenerClientes()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string consulta = @"SELECT id_cliente,
                                   CONCAT(nombre, ' ', apellidos) AS nombre_completo
                                   FROM clientes
                                   ORDER BY nombre, apellidos";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);

                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                return tabla;
            }
        }

        public DataTable ObtenerProductos()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string consulta = @"SELECT id_producto, nombre, precio, stock
                                   FROM productos
                                   WHERE activo = TRUE
                                   ORDER BY nombre";

                MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);

                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                return tabla;
            }
        }

        public int RegistrarVenta(int idCliente, string metodoPago, string productosJson)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                conexion.Open();

                using (MySqlCommand comando = new MySqlCommand("sp_registrar_venta", conexion))
                {
                    comando.CommandType = CommandType.StoredProcedure;

                    comando.Parameters.AddWithValue("p_id_cliente", idCliente);
                    comando.Parameters.AddWithValue("p_metodo_pago", metodoPago);
                    comando.Parameters.AddWithValue("p_productos", productosJson);

                    MySqlParameter parametroVenta = new MySqlParameter(
                        "p_id_venta",
                        MySqlDbType.Int32
                    );

                    parametroVenta.Direction = ParameterDirection.Output;
                    comando.Parameters.Add(parametroVenta);

                    comando.ExecuteNonQuery();

                    return Convert.ToInt32(parametroVenta.Value);
                }
            }
        }
    }
}