USE punto_venta;

-- Seguridad
-- 3.1 Tipos de usuario: administrador y operador
-- Administrador: acceso completo a los objetos de la base de datos
-- Operador: consulta de datos y ejecución de operaciones autorizadas del punto de venta

-- 3.2 Creación de usuarios y roles
CREATE ROLE IF NOT EXISTS 'rol_admin';
CREATE ROLE IF NOT EXISTS 'rol_operador';

CREATE USER IF NOT EXISTS 'admin_pv'@'localhost'
IDENTIFIED BY 'PASSWORDA';

CREATE USER IF NOT EXISTS 'operador_pv'@'localhost'
IDENTIFIED BY 'PASSWORDO';

-- 3.3 Privilegios
GRANT ALL PRIVILEGES ON punto_venta.* TO 'rol_admin';

GRANT SELECT ON punto_venta.Productos TO 'rol_operador';
GRANT SELECT ON punto_venta.Clientes TO 'rol_operador';
GRANT SELECT ON punto_venta.Ventas TO 'rol_operador';
GRANT SELECT ON punto_venta.DetalleVenta TO 'rol_operador';

-- 3.4 Roles de BD
GRANT 'rol_admin' TO 'admin_pv'@'localhost';
GRANT 'rol_operador' TO 'operador_pv'@'localhost';

SET DEFAULT ROLE 'rol_admin' TO 'admin_pv'@'localhost';
SET DEFAULT ROLE 'rol_operador' TO 'operador_pv'@'localhost';

-- Comprobación de permisos
SHOW GRANTS FOR 'rol_admin';
SHOW GRANTS FOR 'rol_operador';
SHOW GRANTS FOR 'admin_pv'@'localhost';
SHOW GRANTS FOR 'operador_pv'@'localhost';

-- Ejemplo de REVOKE (se deja comentado para conservar los permisos de consulta del operador)
-- REVOKE SELECT ON punto_venta.Productos FROM 'rol_operador';
