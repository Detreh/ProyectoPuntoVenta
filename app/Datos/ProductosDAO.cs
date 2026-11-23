using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySqlConnector;

namespace PuntoVentaApp.Datos
{
    public class ProductosDAO
    {
        private string cadenaConexion;
        public ProductosDAO(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }
        public DataTable ObtenerProductos(string filtro = "")
        {
            using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
            {
                conn.Open();

                string consulta = @"SELECT id_producto, nombre, descripcion_producto,
                                          categoria, precio, stock, stock_minimo, activo
                                   FROM Productos
                                   WHERE nombre LIKE @filtro
                                      OR categoria LIKE @filtro
                                      OR descripcion_producto LIKE @filtro";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");

                    DataTable tabla = new DataTable();

                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(cmd))
                    {
                        adaptador.Fill(tabla);
                    }

                    return tabla;
                }
            }
        }
        public void AgregarProducto(string nombre, string descripcion, string categoria,
                                  decimal precio, int stock, int stockMinimo)
        {
            using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
            {
                conn.Open();

                string consulta = @"INSERT INTO Productos
                                   (nombre, descripcion_producto, categoria,
                                    precio, stock, stock_minimo, activo)
                                   VALUES
                                   (@nombre, @descripcion, @categoria,
                                    @precio, @stock, @stockMinimo, TRUE)";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@categoria", categoria);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@stockMinimo", stockMinimo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EditarProducto(int idProducto, string nombre, string descripcion,
                                   string categoria, decimal precio, int stock,
                                   int stockMinimo)
        {
            using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
            {
                conn.Open();

                string consulta = @"UPDATE Productos
                                   SET nombre = @nombre,
                                       descripcion_producto = @descripcion,
                                       categoria = @categoria,
                                       precio = @precio,
                                       stock = @stock,
                                       stock_minimo = @stockMinimo
                                   WHERE id_producto = @id";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", nombre);
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                    cmd.Parameters.AddWithValue("@categoria", categoria);
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@stock", stock);
                    cmd.Parameters.AddWithValue("@stockMinimo", stockMinimo);
                    cmd.Parameters.AddWithValue("@id", idProducto);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarProducto(int idProducto)
        {
            using (MySqlConnection conn = new MySqlConnection(cadenaConexion))
            {
                conn.Open();

                string consulta = "DELETE FROM Productos WHERE id_producto = @id";

                using (MySqlCommand cmd = new MySqlCommand(consulta, conn))
                {
                    cmd.Parameters.AddWithValue("@id", idProducto);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
