using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySqlConnector;

namespace PuntoVentaApp.Datos
{
    public class ReportesDAO
    {
        private string cadenaConexion;

        public ReportesDAO(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        public DataTable ObtenerVentas(
            string filtro,
            bool filtrarFechaInicio,
            DateTime fechaInicio,
            bool filtrarFechaFin,
            DateTime fechaFin)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string consulta = @"
                    SELECT
                        v.id_venta,
                        v.fecha,
                        CONCAT(c.nombre, ' ', c.apellidos) AS cliente,
                        v.metodo_pago,
                        v.total
                    FROM Ventas v
                    INNER JOIN Clientes c ON v.id_cliente = c.id_cliente
                    WHERE 1 = 1";

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    consulta += @" AND (
                        CAST(v.id_venta AS CHAR) LIKE @buscar
                        OR CONCAT(c.nombre, ' ', c.apellidos) LIKE @buscar
                        OR c.nombre LIKE @buscar
                        OR c.apellidos LIKE @buscar
                        OR v.metodo_pago LIKE @buscar
                    )";
                }

                if (filtrarFechaInicio)
                {
                    consulta += " AND v.fecha >= @fechaInicio";
                }

                if (filtrarFechaFin)
                {
                    consulta += " AND v.fecha < @fechaFin";
                }

                consulta += " ORDER BY v.fecha DESC";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    if (!string.IsNullOrWhiteSpace(filtro))
                    {
                        comando.Parameters.AddWithValue("@buscar", "%" + filtro.Trim() + "%");
                    }

                    if (filtrarFechaInicio)
                    {
                        comando.Parameters.AddWithValue("@fechaInicio", fechaInicio.Date);
                    }

                    if (filtrarFechaFin)
                    {
                        comando.Parameters.AddWithValue("@fechaFin", fechaFin.Date.AddDays(1));
                    }

                    DataTable tabla = new DataTable();

                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }

                    return tabla;
                }
            }
        }

        public DataTable ObtenerDetalleVenta(int idVenta)
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string consulta = @"
                    SELECT
                        p.nombre AS producto,
                        dv.cantidad,
                        dv.precio_unitario,
                        dv.subtotal
                    FROM DetalleVenta dv
                    INNER JOIN Productos p ON dv.id_producto = p.id_producto
                    WHERE dv.id_venta = @idVenta";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@idVenta", idVenta);

                    DataTable tabla = new DataTable();

                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }

                    return tabla;
                }
            }
        }
        public DataTable ObtenerInventario()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string consulta = @"
            SELECT
                id_producto,
                nombre,
                categoria,
                precio,
                stock,
                stock_minimo,
                activo,
                estado_stock
            FROM vw_productos_inventario
            ORDER BY nombre";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    DataTable tabla = new DataTable();

                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }

                    return tabla;
                }
            }
        }
        public DataTable ObtenerProductosMasVendidos()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string consulta = @"
            SELECT
                p.id_producto,
                p.nombre,
                p.categoria,
                SUM(dv.cantidad) AS cantidad_vendida,
                SUM(dv.subtotal) AS total_generado
            FROM DetalleVenta dv
            INNER JOIN Productos p ON dv.id_producto = p.id_producto
            GROUP BY p.id_producto, p.nombre, p.categoria
            ORDER BY cantidad_vendida DESC";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    DataTable tabla = new DataTable();

                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }

                    return tabla;
                }
            }
        }
        public DataTable ObtenerVentasPorMetodoPago()
        {
            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string consulta = @"
            SELECT
                metodo_pago,
                COUNT(*) AS cantidad_ventas,
                SUM(total) AS total_vendido,
                AVG(total) AS promedio_venta
            FROM Ventas
            GROUP BY metodo_pago
            ORDER BY total_vendido DESC";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    DataTable tabla = new DataTable();

                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }

                    return tabla;
                }
            }
        }
        public DataTable ObtenerVentasPorMes()
        {
            DataTable tabla = new DataTable();

            using (MySqlConnection conexion = new MySqlConnection(cadenaConexion))
            {
                string consulta = @"
            SELECT 
                DATE_FORMAT(fecha, '%Y-%m') AS mes,
                COUNT(id_venta) AS cantidad_ventas,
                SUM(total) AS total_vendido,
                AVG(total) AS promedio_venta
            FROM Ventas
            GROUP BY DATE_FORMAT(fecha, '%Y-%m')
            ORDER BY mes DESC;";

                using (MySqlCommand comando = new MySqlCommand(consulta, conexion))
                {
                    using (MySqlDataAdapter adaptador = new MySqlDataAdapter(comando))
                    {
                        adaptador.Fill(tabla);
                    }
                }
            }

            return tabla;
        }
    }
}