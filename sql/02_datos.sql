USE punto_venta;

-- Datos de prueba
-- Se cargan 15 registros iniciales en cada tabla de negocio.
-- Productos: 15 registros
INSERT INTO Productos (nombre, descripcion_producto, categoria, precio, stock, stock_minimo) VALUES
('Coca-Cola 600 ml','Refresco de cola','Bebidas',18.00,100,20),
('Sabritas Original 45 g','Papas fritas','Botanas',17.50,60,15),
('Pan blanco grande','Pan de caja','Panaderia',42.00,30,10),
('Leche entera 1 L','Leche pasteurizada','Lacteos',28.00,40,10),
('Huevo 12 piezas','Huevo blanco','Abarrotes',52.00,25,8),
('Detergente 1 kg','Detergente en polvo','Limpieza',48.00,15,5),
('Galletas Marias','Paquete de galletas','Botanas',15.00,40,5),
('Agua natural 1 L','Agua purificada','Bebidas',12.00,80,20),
('Frijol bayo 1 kg','Frijol a granel','Abarrotes',34.00,20,8),
('Arroz 1 kg','Arroz blanco','Abarrotes',29.00,35,8),
('Aceite vegetal 1 L','Aceite comestible','Abarrotes',43.00,25,6),
('Jabon de baño','Jabon en barra','Higiene',19.00,45,10),
('Papel higienico 4 rollos','Papel higienico','Higiene',36.00,30,8),
('Cafe soluble 100 g','Cafe instantaneo','Bebidas',58.00,18,5),
('Shampoo 400 ml','Shampoo uso diario','Higiene',65.00,20,5);

-- Clientes: 15 registros
INSERT INTO Clientes (nombre, apellidos, telefono, correo, direccion) VALUES
('Ana','Lopez Perez','6441234567','ana.lopez@correo.com','Calle Sonora 120, Cd. Obregon'),
('Luis','Ramirez Soto','6442345678','luis.ramirez@correo.com','Av. Miguel Aleman 455, Cd. Obregon'),
('Maria','Fernandez Ruiz','6443456789','maria.fernandez@correo.com','Calle Nainari 78, Cd. Obregon'),
('Carlos','Soto Navarro','6444567890','carlos.soto@correo.com','Blvd. Ruiz Cortines 900, Cd. Obregon'),
('Sofia','Navarro Garcia','6445678901','sofia.navarro@correo.com','Calle Hidalgo 33, Cd. Obregon'),
('Jorge','Mendoza Cruz','6446789012','jorge.mendoza@correo.com','Calle 5 de Febrero 210'),
('Valeria','Castro Luna','6447890123','valeria.castro@correo.com','Calle Guerrero 145'),
('Miguel','Torres Diaz','6448901234','miguel.torres@correo.com','Av. Yaqui 520'),
('Daniela','Morales Vega','6449012345','daniela.morales@correo.com','Calle Morelos 67'),
('Ricardo','Flores Rios','6440123456','ricardo.flores@correo.com','Calle Zaragoza 89'),
('Fernanda','Ortega Gil','6441122334','fernanda.ortega@correo.com','Calle Cajeme 333'),
('Roberto','Vazquez Leon','6442233445','roberto.vazquez@correo.com','Av. Sinaloa 101'),
('Paola','Jimenez Ruiz','6443344556','paola.jimenez@correo.com','Calle Tabasco 222'),
('Eduardo','Reyes Molina','6444455667','eduardo.reyes@correo.com','Calle Allende 76'),
('Andrea','Gutierrez Solis','6445566778','andrea.gutierrez@correo.com','Calle California 404');

-- Ventas: 15 registros
INSERT INTO Ventas (id_cliente, fecha, metodo_pago, total) VALUES
(1,'2026-11-10 10:15:00','Efectivo',89.00),
(2,'2026-11-10 12:40:00','Tarjeta',98.00),
(3,'2026-11-11 09:05:00','Efectivo',100.00),
(1,'2026-11-12 17:30:00','Tarjeta',129.00),
(4,'2026-11-13 11:20:00','Efectivo',112.00),
(5,'2026-11-14 16:10:00','Transferencia',146.00),
(6,'2026-11-15 10:00:00','Efectivo',82.00),
(7,'2026-11-15 13:25:00','Tarjeta',102.50),
(8,'2026-11-16 09:40:00','Efectivo',85.00),
(9,'2026-11-16 15:15:00','Transferencia',101.00),
(10,'2026-11-17 11:30:00','Tarjeta',94.50),
(11,'2026-11-17 18:05:00','Efectivo',129.00),
(12,'2026-11-18 12:10:00','Transferencia',109.00),
(13,'2026-11-18 16:45:00','Tarjeta',116.00),
(14,'2026-11-19 10:25:00','Efectivo',111.50);

-- Detalle de venta: 15 registros como minimo (se cargan 30)
INSERT INTO DetalleVenta (id_venta, id_producto, cantidad, precio_unitario, subtotal) VALUES
-- Venta 1
(1,1,3,18.00,54.00),(1,2,2,17.50,35.00),
-- Venta 2
(2,3,1,42.00,42.00),(2,4,2,28.00,56.00),
-- Venta 3
(3,5,1,52.00,52.00),(3,8,4,12.00,48.00),
-- Venta 4
(4,6,1,48.00,48.00),(4,1,2,18.00,36.00),(4,7,3,15.00,45.00),
-- Venta 5
(5,4,1,28.00,28.00),(5,3,2,42.00,84.00),
-- Venta 6
(6,2,4,17.50,70.00),(6,8,2,12.00,24.00),(6,5,1,52.00,52.00),
-- Venta 7
(7,9,1,34.00,34.00),(7,10,1,29.00,29.00),(7,12,1,19.00,19.00),
-- Venta 8
(8,11,1,43.00,43.00),(8,7,2,15.00,30.00),(8,8,1,12.00,12.00),(8,2,1,17.50,17.50),
-- Venta 9
(9,13,1,36.00,36.00),(9,1,1,18.00,18.00),(9,12,1,19.00,19.00),(9,8,1,12.00,12.00),
-- Venta 10
(10,14,1,58.00,58.00),(10,4,1,28.00,28.00),(10,7,1,15.00,15.00),
-- Venta 11
(11,15,1,65.00,65.00),(11,8,1,12.00,12.00),(11,2,1,17.50,17.50),
-- Venta 12
(12,10,2,29.00,58.00),(12,5,1,52.00,52.00),(12,12,1,19.00,19.00),
-- Venta 13
(13,6,1,48.00,48.00),(13,9,1,34.00,34.00),(13,8,1,12.00,12.00),(13,7,1,15.00,15.00),
-- Venta 14
(14,3,1,42.00,42.00),(14,11,1,43.00,43.00),(14,12,1,19.00,19.00),(14,8,1,12.00,12.00),
-- Venta 15
(15,13,1,36.00,36.00),(15,14,1,58.00,58.00),(15,2,1,17.50,17.50);

-- Actualizar el inventario segun lo vendido
UPDATE Productos p
JOIN (
    SELECT id_producto, SUM(cantidad) AS vendidos
    FROM DetalleVenta
    GROUP BY id_producto
) d ON d.id_producto = p.id_producto
SET p.stock = p.stock - d.vendidos;

-- Verificar cantidad de registros por tabla
SELECT 'Productos' AS tabla, COUNT(*) AS registros FROM Productos
UNION ALL SELECT 'Clientes', COUNT(*) FROM Clientes
UNION ALL SELECT 'Ventas', COUNT(*) FROM Ventas
UNION ALL SELECT 'DetalleVenta', COUNT(*) FROM DetalleVenta;
