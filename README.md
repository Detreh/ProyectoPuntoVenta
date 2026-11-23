# PuntoVentaApp – Sistema de Punto de Venta

## Descripción del proyecto

PuntoVentaApp es una aplicación de escritorio desarrollada en C# mediante Windows Forms y conectada a una base de datos MySQL. Su objetivo es facilitar la administración de un pequeño negocio mediante el control de productos, clientes, ventas e inventario.

El sistema permite gestionar los productos disponibles, registrar clientes, realizar ventas, actualizar las existencias automáticamente y consultar información mediante reportes. También cuenta con un sistema de inicio de sesión y permisos de usuario para diferenciar las funciones disponibles según el perfil.

## Funcionalidades

- Inicio de sesión y control de acceso por perfiles.
- Administración de productos (agregar, consultar, modificar y eliminar).
- Administración de clientes.
- Registro de ventas y cálculo de totales.
- Actualización automática del inventario al realizar ventas.
- Cancelación de ventas y recuperación de existencias.
- Control de productos con stock mínimo y productos agotados.
- Consulta del historial de ventas y sus detalles.
- Reportes de inventario, productos más vendidos, ventas por método de pago y ventas por mes.
- Restricción de funciones según el perfil del usuario.

## Tecnologías utilizadas

- **Lenguaje de programación:** C#
- **Framework**: .NET
- **Interfaz gráfica:** Windows Forms
- **IDE:** Visual Studio
- **Base de datos:** MySQL
- **Conector:** MySqlConnector
- **Control de versiones:** Git y GitHub

## Estructura del repositorio

El repositorio se encuentra organizado de la siguiente manera:

```text
ProyectoPuntoVenta/
│
├── README.md
├── .gitignore
│
├── app/
│   └── PuntoVentaApp/
│       ├── PuntoVentaApp.sln
│       ├── Proyecto/
│       └── ...
│
└── sql/
    ├── 01_esquema.sql
    ├── 02_datos.sql
    ├── 03_seguridad.sql
    ├── 04_procedural.sql
    ├── 05_consultas.sql
    └── 06_concurrencia.sql
```

## Instalación y ejecución

1. Descargar o clonar el repositorio.
2. Instalar Visual Studio con soporte para desarrollo de aplicaciones de escritorio con .NET.
3. Instalar MySQL Server y MySQL Workbench.
4. Abrir MySQL Workbench y ejecutar los scripts SQL del directorio `sql` en el orden correspondiente.
5. Abrir la solución del proyecto desde la carpeta `app` utilizando Visual Studio.
6. Verificar y configurar la cadena de conexión a MySQL en el archivo de configuración de la aplicación.
7. Compilar y ejecutar el proyecto.

## Base de datos

La base de datos almacena la información correspondiente a productos, clientes, usuarios, ventas y detalles de venta.

Los scripts SQL incluidos en el repositorio contienen la estructura de la base de datos, datos iniciales, configuración de seguridad, procedimientos almacenados, funciones, triggers, vistas, consultas y elementos relacionados con la concurrencia.

## Autores

Proyecto desarrollado por estudiantes de Ingeniería en Sistemas Computacionales como parte de un proyecto académico.

## Propósito académico

Este proyecto tiene como propósito aplicar conocimientos de programación, desarrollo de interfaces gráficas, bases de datos relacionales, SQL, control de inventarios, gestión de ventas y control de versiones mediante Git y GitHub.
