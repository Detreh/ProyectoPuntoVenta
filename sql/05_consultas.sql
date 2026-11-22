USE punto_venta;

-- Consultas

-- 4.1 Listar todos los productos ordenados por categoria y nombre
SELECT id_producto, nombre, categoria, precio, stock
FROM Productos
ORDER BY categoria, nombre;

-- 4.2 Productos con stock bajo (por debajo o igual al minimo)
SELECT nombre, stock, stock_minimo
FROM Productos
WHERE stock <= stock_minimo;

-- 4.3 Ventas con el nombre del cliente (JOIN)
SELECT v.id_venta, v.fecha,
       CONCAT(c.nombre, ' ', c.apellidos) AS cliente,
       v.metodo_pago, v.total
FROM Ventas v
JOIN Clientes c ON c.id_cliente = v.id_cliente
ORDER BY v.fecha;

-- 4.4 Detalle completo de una venta (JOIN de 3 tablas), ejemplo: venta 4
SELECT v.id_venta, p.nombre AS producto, d.cantidad,
       d.precio_unitario, d.subtotal
FROM DetalleVenta d
JOIN Ventas v ON v.id_venta = d.id_venta
JOIN Productos p ON p.id_producto = d.id_producto
WHERE v.id_venta = 4;

-- 4.5 Total vendido por producto (GROUP BY)
SELECT p.nombre, SUM(d.cantidad) AS unidades_vendidas,
       SUM(d.subtotal) AS ingreso_total
FROM DetalleVenta d
JOIN Productos p ON p.id_producto = d.id_producto
GROUP BY p.id_producto, p.nombre
ORDER BY ingreso_total DESC;

-- 4.6 Producto mas vendido
SELECT p.nombre, SUM(d.cantidad) AS unidades_vendidas
FROM DetalleVenta d
JOIN Productos p ON p.id_producto = d.id_producto
GROUP BY p.id_producto, p.nombre
ORDER BY unidades_vendidas DESC
LIMIT 1;

-- 4.7 Total gastado por cliente
SELECT CONCAT(c.nombre, ' ', c.apellidos) AS cliente,
       COUNT(v.id_venta) AS num_compras,
       SUM(v.total) AS total_gastado
FROM Clientes c
JOIN Ventas v ON v.id_cliente = c.id_cliente
GROUP BY c.id_cliente, cliente
ORDER BY total_gastado DESC;

-- 4.8 Ventas por metodo de pago
SELECT metodo_pago, COUNT(*) AS num_ventas, SUM(total) AS monto
FROM Ventas
GROUP BY metodo_pago;

-- 4.9 Ventas dentro de un rango de fechas
SELECT id_venta, fecha, total
FROM Ventas
WHERE fecha BETWEEN '2026-11-10 00:00:00' AND '2026-11-19 23:59:59';

-- 4.10 Productos que nunca se han vendido (LEFT JOIN)
SELECT p.nombre
FROM Productos p
LEFT JOIN DetalleVenta d ON d.id_producto = p.id_producto
WHERE d.id_detalle IS NULL;

-- 4.11 Clientes que han gastado mas que el promedio (subconsulta)
SELECT CONCAT(c.nombre, ' ', c.apellidos) AS cliente,
       SUM(v.total) AS total_gastado
FROM Clientes c
JOIN Ventas v ON v.id_cliente = c.id_cliente
GROUP BY c.id_cliente, cliente
HAVING SUM(v.total) > (SELECT AVG(total) FROM Ventas);

-- 4.12 Verificar que el total de cada venta coincide con la suma de su detalle
SELECT v.id_venta, v.total AS total_registrado,
       SUM(d.subtotal) AS suma_detalle,
       v.total = SUM(d.subtotal) AS coincide
FROM Ventas v
JOIN DetalleVenta d ON d.id_venta = v.id_venta
GROUP BY v.id_venta, v.total;

-- 4.13 Busqueda por texto (LIKE)
SELECT id_producto,nombre,categoria,precio,stock
FROM Productos
WHERE nombre LIKE '%leche%';

-- 4.14 Filtro por categoria (IN)
SELECT id_producto,nombre,categoria,precio,stock
FROM Productos
WHERE categoria IN ('Bebidas','Botanas','Abarrotes');

-- 4.15 Filtro por rango de precios (BETWEEN)
SELECT id_producto,nombre,precio
FROM Productos
WHERE precio BETWEEN 20 AND 50
ORDER BY precio;

-- 4.16 Subconsulta en WHERE: productos con precio superior al promedio
SELECT nombre,precio
FROM Productos
WHERE precio > (SELECT AVG(precio) FROM Productos);

-- 4.17 Subconsulta correlacionada: clientes con al menos una venta
SELECT c.id_cliente,c.nombre,c.apellidos
FROM Clientes c
WHERE EXISTS (
    SELECT 1 FROM Ventas v
    WHERE v.id_cliente = c.id_cliente
);

-- 4.18 Vista de inventario
SELECT * FROM vw_productos_inventario ORDER BY categoria,nombre;

-- 4.19 Vista de ventas
SELECT * FROM vw_ventas_resumen ORDER BY fecha;

-- 4.20 Reporte con GROUP BY, HAVING, SUM, COUNT, AVG, funciones de fecha/cadena, CAST y ORDER BY
SELECT
    DATE_FORMAT(v.fecha,'%Y-%m') AS periodo,
    UPPER(v.metodo_pago) AS metodo,
    COUNT(*) AS cantidad_ventas,
    SUM(v.total) AS total_vendido,
    AVG(v.total) AS promedio_venta,
    CAST(SUM(v.total) AS CHAR) AS total_texto
FROM Ventas v
GROUP BY DATE_FORMAT(v.fecha,'%Y-%m'),v.metodo_pago
HAVING COUNT(*) >= 1
ORDER BY periodo, total_vendido DESC;
