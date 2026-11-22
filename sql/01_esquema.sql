-- Creación de la base de datos
CREATE DATABASE punto_venta CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci;
USE punto_venta;

-- Tablas
CREATE TABLE Productos (
    id_producto  INT AUTO_INCREMENT PRIMARY KEY,
    nombre       VARCHAR(100) NOT NULL,
    descripcion  VARCHAR(255),
    categoria    VARCHAR(50),
    precio       DECIMAL(10,2) NOT NULL,
    stock        INT NOT NULL DEFAULT 0,
    stock_minimo INT NOT NULL DEFAULT 5
);

CREATE TABLE Clientes (
    id_cliente INT AUTO_INCREMENT PRIMARY KEY,
    nombre     VARCHAR(100) NOT NULL,
    apellidos  VARCHAR(100),
    telefono   VARCHAR(15),
    correo     VARCHAR(100),
    direccion  VARCHAR(255)
);

CREATE TABLE Ventas (
    id_venta    INT AUTO_INCREMENT PRIMARY KEY,
    id_cliente  INT NOT NULL,
    fecha       DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    metodo_pago VARCHAR(30) NOT NULL DEFAULT 'Efectivo',
    total       DECIMAL(10,2) NOT NULL,
    CONSTRAINT fk_ventas_clientes
        FOREIGN KEY (id_cliente) REFERENCES Clientes(id_cliente)
        ON DELETE RESTRICT ON UPDATE CASCADE
);

CREATE TABLE DetalleVenta (
    id_detalle      INT AUTO_INCREMENT PRIMARY KEY,
    id_venta        INT NOT NULL,
    id_producto     INT NOT NULL,
    cantidad        INT NOT NULL,
    precio_unitario DECIMAL(10,2) NOT NULL,
    subtotal        DECIMAL(10,2) NOT NULL,
    CONSTRAINT fk_detalle_ventas
        FOREIGN KEY (id_venta) REFERENCES Ventas(id_venta)
        ON DELETE CASCADE ON UPDATE CASCADE,
    CONSTRAINT fk_detalle_productos
        FOREIGN KEY (id_producto) REFERENCES Productos(id_producto)
        ON DELETE RESTRICT ON UPDATE CASCADE
);

-- Constraints y alter table

-- 2.1 Constraints UNIQUE
ALTER TABLE Clientes
    ADD CONSTRAINT uq_clientes_correo UNIQUE (correo);

ALTER TABLE Productos
    ADD CONSTRAINT uq_productos_nombre UNIQUE (nombre);

-- 2.2 Constraints CHECK (validaciones de datos)
ALTER TABLE Productos
    ADD CONSTRAINT chk_productos_precio CHECK (precio > 0),
    ADD CONSTRAINT chk_productos_stock CHECK (stock >= 0),
    ADD CONSTRAINT chk_productos_stock_minimo CHECK (stock_minimo >= 0);

ALTER TABLE Ventas
    ADD CONSTRAINT chk_ventas_total CHECK (total >= 0),
    ADD CONSTRAINT chk_ventas_pago CHECK (metodo_pago IN ('Efectivo', 'Tarjeta', 'Transferencia'));

ALTER TABLE DetalleVenta
    ADD CONSTRAINT chk_detalle_cantidad CHECK (cantidad > 0),
    ADD CONSTRAINT chk_detalle_precio CHECK (precio_unitario >= 0),
    ADD CONSTRAINT chk_detalle_subtotal CHECK (subtotal >= 0),
    ADD CONSTRAINT chk_detalle_subtotal_calculado CHECK (subtotal = cantidad * precio_unitario);

-- 2.3 Agregar columnas nuevas
ALTER TABLE Clientes
    ADD COLUMN fecha_registro DATE NOT NULL DEFAULT (CURRENT_DATE);

ALTER TABLE Productos
    ADD COLUMN activo BOOLEAN NOT NULL DEFAULT TRUE;

-- 2.4 Modificar una columna existente
ALTER TABLE Clientes
    MODIFY COLUMN telefono VARCHAR(20);

-- 2.5 Renombrar una columna
ALTER TABLE Productos
    RENAME COLUMN descripcion TO descripcion_producto;

-- 2.6 Crear indices para acelerar consultas
CREATE INDEX idx_ventas_fecha ON Ventas(fecha);
CREATE INDEX idx_detalle_id_venta ON DetalleVenta(id_venta);
CREATE INDEX idx_productos_categoria ON Productos(categoria);
CREATE INDEX idx_detalle_id_producto ON DetalleVenta(id_producto);

-- 2.7 Eliminar una columna
-- ALTER TABLE Productos DROP COLUMN activo;
