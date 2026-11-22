USE punto_venta;

-- SQL Procedural
-- 5.1 Stored procedures
-- 5.2 Funciones
-- 5.3 Triggers

-- Vistas

-- Vista 1: productos e inventario
CREATE OR REPLACE VIEW vw_productos_inventario AS
SELECT
    id_producto,
    nombre,
    categoria,
    precio,
    stock,
    stock_minimo,
    activo,
    CASE
        WHEN stock = 0 THEN 'AGOTADO'
        WHEN stock <= stock_minimo THEN 'STOCK BAJO'
        ELSE 'DISPONIBLE'
    END AS estado_stock
FROM Productos;

-- Vista 2: ventas con nombre de cliente
CREATE OR REPLACE VIEW vw_ventas_resumen AS
SELECT
    v.id_venta,
    v.fecha,
    v.id_cliente,
    CONCAT(c.nombre, ' ', c.apellidos) AS cliente,
    v.metodo_pago,
    v.total
FROM Ventas v
INNER JOIN Clientes c ON c.id_cliente = v.id_cliente;

-- Funciones

-- Funcion 1: estado de inventario de un producto
DELIMITER $$
CREATE FUNCTION fn_estado_stock(p_id_producto INT)
RETURNS VARCHAR(20)
READS SQL DATA
BEGIN
    DECLARE v_stock INT;
    DECLARE v_minimo INT;

    SELECT stock, stock_minimo
    INTO v_stock, v_minimo
    FROM Productos
    WHERE id_producto = p_id_producto;

    IF v_stock IS NULL THEN
        RETURN 'NO EXISTE';
    ELSEIF v_stock = 0 THEN
        RETURN 'AGOTADO';
    ELSEIF v_stock <= v_minimo THEN
        RETURN 'STOCK BAJO';
    ELSE
        RETURN 'DISPONIBLE';
    END IF;
END $$
DELIMITER ;

-- Funcion 2: total gastado por cliente
DELIMITER $$
CREATE FUNCTION fn_total_gastado_cliente(p_id_cliente INT)
RETURNS DECIMAL(10,2)
READS SQL DATA
BEGIN
    DECLARE v_total DECIMAL(10,2);

    SELECT COALESCE(SUM(total), 0)
    INTO v_total
    FROM Ventas
    WHERE id_cliente = p_id_cliente;

    RETURN v_total;
END $$
DELIMITER ;

-- Triggers

-- Trigger 1: validacion antes de insertar detalle de venta
DELIMITER $$
CREATE TRIGGER trg_validar_detalle_venta
BEFORE INSERT ON DetalleVenta
FOR EACH ROW
BEGIN
    DECLARE v_stock INT;
    DECLARE v_activo BOOLEAN;

    SELECT stock, activo
    INTO v_stock, v_activo
    FROM Productos
    WHERE id_producto = NEW.id_producto;

    IF v_activo = FALSE THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El producto se encuentra inactivo';
    END IF;

    IF NEW.cantidad <= 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'La cantidad debe ser mayor a cero';
    END IF;

    IF NEW.cantidad > v_stock THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Stock insuficiente para realizar la venta';
    END IF;

    IF NEW.precio_unitario < 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El precio no puede ser negativo';
    END IF;

    SET NEW.subtotal = NEW.cantidad * NEW.precio_unitario;
END $$
DELIMITER ;

-- Trigger 2: descuento automatico de inventario al registrar detalle
DELIMITER $$
CREATE TRIGGER trg_descontar_stock
AFTER INSERT ON DetalleVenta
FOR EACH ROW
BEGIN
    UPDATE Productos
    SET stock = stock - NEW.cantidad
    WHERE id_producto = NEW.id_producto;
END $$
DELIMITER ;

-- Trigger 3: restaurar inventario al eliminar detalle manualmente
-- mysql no ejecuta triggers de la tabla hija cuando el borrado ocurre por ON DELETE CASCADE
DELIMITER $$
CREATE TRIGGER trg_restaurar_stock
AFTER DELETE ON DetalleVenta
FOR EACH ROW
BEGIN
    UPDATE Productos
    SET stock = stock + OLD.cantidad
    WHERE id_producto = OLD.id_producto;
END $$
DELIMITER ;

-- Stored procedures

-- Procedimiento 1: registrar venta completa
DELIMITER $$
CREATE PROCEDURE sp_registrar_venta(
    IN p_id_cliente INT,
    IN p_metodo_pago VARCHAR(30),
    IN p_productos JSON,
    OUT p_id_venta INT
)
BEGIN
    DECLARE v_i INT DEFAULT 0;
    DECLARE v_cantidad INT;
    DECLARE v_id_producto INT;
    DECLARE v_precio DECIMAL(10,2);
    DECLARE v_total DECIMAL(10,2) DEFAULT 0;
    DECLARE v_num_productos INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    IF NOT EXISTS (SELECT 1 FROM Clientes WHERE id_cliente = p_id_cliente) THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El cliente no existe';
    END IF;

    IF p_metodo_pago NOT IN ('Efectivo','Tarjeta','Transferencia') THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Metodo de pago invalido';
    END IF;

    IF p_productos IS NULL OR JSON_TYPE(p_productos) <> 'ARRAY'
       OR JSON_LENGTH(p_productos) = 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'La venta debe contener productos';
    END IF;

    SET v_num_productos = JSON_LENGTH(p_productos);

    INSERT INTO Ventas(id_cliente, metodo_pago, total)
    VALUES(p_id_cliente, p_metodo_pago, 0);

    SET p_id_venta = LAST_INSERT_ID();

    WHILE v_i < v_num_productos DO
        SET v_id_producto = CAST(JSON_UNQUOTE(JSON_EXTRACT(
            p_productos, CONCAT('$[',v_i,'].id_producto'))) AS UNSIGNED);
        SET v_cantidad = CAST(JSON_UNQUOTE(JSON_EXTRACT(
            p_productos, CONCAT('$[',v_i,'].cantidad'))) AS UNSIGNED);

        -- Bloquear producto para coordinar ventas simultaneas
        SET v_precio = NULL;
        SELECT precio INTO v_precio
        FROM Productos
        WHERE id_producto = v_id_producto AND activo = TRUE
        FOR UPDATE;

        IF v_precio IS NULL THEN
            SIGNAL SQLSTATE '45000'
            SET MESSAGE_TEXT = 'Producto inexistente o inactivo';
        END IF;

        INSERT INTO DetalleVenta(id_venta,id_producto,cantidad,precio_unitario,subtotal)
        VALUES(p_id_venta,v_id_producto,v_cantidad,v_precio,v_cantidad*v_precio);

        SET v_i = v_i + 1;
    END WHILE;

    SELECT COALESCE(SUM(subtotal),0) INTO v_total
    FROM DetalleVenta WHERE id_venta = p_id_venta;

    UPDATE Ventas SET total = v_total WHERE id_venta = p_id_venta;

    COMMIT;
END $$
DELIMITER ;

-- Procedimiento 2: cancelar venta y recuperar inventario
DELIMITER $$
CREATE PROCEDURE sp_cancelar_venta(IN p_id_venta INT)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    IF NOT EXISTS (SELECT 1 FROM Ventas WHERE id_venta = p_id_venta) THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'La venta no existe';
    END IF;

    -- Recuperar stock antes de borrar la venta
    -- El borrado en cascada no activa el trigger AFTER DELETE de DetalleVenta
    UPDATE Productos p
    JOIN (
        SELECT id_producto, SUM(cantidad) AS cantidad_devuelta
        FROM DetalleVenta
        WHERE id_venta = p_id_venta
        GROUP BY id_producto
    ) d ON d.id_producto = p.id_producto
    SET p.stock = p.stock + d.cantidad_devuelta;

    DELETE FROM Ventas WHERE id_venta = p_id_venta;

    COMMIT;
END $$
DELIMITER ;

-- Procedimiento 3: ajuste de inventario
DELIMITER $$
CREATE PROCEDURE sp_ajustar_stock(IN p_id_producto INT, IN p_cantidad INT)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    IF NOT EXISTS (SELECT 1 FROM Productos WHERE id_producto = p_id_producto) THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El producto no existe';
    END IF;

    IF p_cantidad = 0 THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El ajuste no puede ser cero';
    END IF;

    UPDATE Productos
    SET stock = stock + p_cantidad
    WHERE id_producto = p_id_producto;

    COMMIT;
END $$
DELIMITER ;

-- Procedimiento 4: listar productos con stock bajo
DELIMITER $$
CREATE PROCEDURE sp_productos_stock_bajo()
BEGIN
    SELECT id_producto,nombre,categoria,stock,stock_minimo,
           fn_estado_stock(id_producto) AS estado
    FROM Productos
    WHERE stock <= stock_minimo AND activo = TRUE
    ORDER BY stock ASC;
END $$
DELIMITER ;

-- Permisos sobre vistas, funciones y procedimientos para el operador
GRANT SELECT ON punto_venta.vw_productos_inventario TO 'rol_operador';
GRANT SELECT ON punto_venta.vw_ventas_resumen TO 'rol_operador';
GRANT EXECUTE ON PROCEDURE punto_venta.sp_registrar_venta TO 'rol_operador';
GRANT EXECUTE ON PROCEDURE punto_venta.sp_productos_stock_bajo TO 'rol_operador';
GRANT EXECUTE ON FUNCTION punto_venta.fn_estado_stock TO 'rol_operador';
GRANT EXECUTE ON FUNCTION punto_venta.fn_total_gastado_cliente TO 'rol_operador';

-- Pruebas de vistas y funciones
-- SELECT * FROM vw_productos_inventario;
-- SELECT * FROM vw_ventas_resumen;
-- SELECT fn_estado_stock(1);
-- SELECT fn_total_gastado_cliente(1);
-- CALL sp_productos_stock_bajo();
