# BYTEAZULOTE

## Descripción

**BYTEAZULOTE** es un sistema de escritorio para la gestión integral de una farmacia o negocio dedicado a la comercialización de medicamentos y productos relacionados. La aplicación permite administrar clientes, empleados, proveedores, medicinas, categorías, lotes, compras, ventas, caja, movimientos y reportes.

El sistema está desarrollado en **C# con Windows Forms** y utiliza **SQL Server** como motor de base de datos. Su código está organizado en una arquitectura de tres capas:

- **Capa de presentación:** formularios y controles visuales.
- **Capa lógica:** reglas de negocio y validaciones.
- **Capa de datos:** conexión con SQL Server y ejecución de procedimientos almacenados.

## Funcionalidades principales

### Inicio de sesión y usuarios

- Inicio de la aplicación mediante un formulario de login.
- Gestión de cuentas de usuario.
- Visualización de usuarios.
- Gestión de empleados.
- Cambio de contraseña.
- Identificación del empleado que inició sesión para asociarlo con las operaciones de caja y ventas.

### Gestión de clientes

- Registro de nuevos clientes.
- Consulta y gestión de clientes existentes.
- Uso de los clientes como destinatarios de las ventas.
- Generación de reportes de clientes.

### Gestión de empleados

- Registro de empleados.
- Consulta y administración de empleados.
- Asociación del empleado con las sesiones de caja y las ventas.
- Administración de usuarios relacionados con los empleados.

### Medicinas e inventario

- Registro de medicinas o productos.
- Gestión de productos existentes.
- Organización por categorías.
- Manejo de unidades de medida.
- Gestión de precios.
- Administración de lotes.
- Control de productos existentes y movimientos de inventario.

### Proveedores y compras

- Registro de proveedores.
- Gestión de proveedores existentes.
- Registro y administración de compras.
- Relación de productos con proveedores.
- Actualización del inventario mediante las operaciones de compra.

### Caja

El sistema controla la operación diaria de caja mediante sesiones asociadas a los empleados:

- Apertura de caja con un monto inicial.
- Validación de que la caja esté abierta antes de vender.
- Consulta del estado actual de la caja.
- Registro de ventas y movimientos.
- Cierre de caja con el monto físico final.
- Control de movimientos y transacciones de caja.

Antes de acceder a determinadas operaciones, como ventas o ingreso de lotes, el sistema verifica si el empleado tiene una sesión de caja abierta.

### Ventas

- Creación de una venta.
- Asociación de la venta con un cliente y un empleado.
- Registro de los detalles de la venta.
- Cálculo del total por producto y cantidad.
- Consulta de ventas realizadas.
- Consulta de los detalles de una venta.
- Devolución de detalles de venta.
- Actualización del inventario mediante los procedimientos de la base de datos.

### Categorías, descuentos y suscripciones

- Registro y gestión de categorías.
- Administración de descuentos.
- Gestión de información relacionada con suscripciones y detalles de ventas.

### Reportes

La aplicación utiliza archivos **RDLC** y controles de ReportViewer para generar informes, entre ellos:

- Reporte de compras.
- Reporte de ventas.
- Listado de clientes.
- Movimientos de inventario.
- Productos existentes.
- Productos más vendidos.
- Ventas por empleado.
- Gráficos mensuales.

## Arquitectura del sistema

El proyecto utiliza una arquitectura de tres capas. El flujo general de una operación es el siguiente:

```text
Formulario de Windows Forms
            │
            ▼
       CapaLogica
            │
            ▼
        CapaDatos
            │
            ▼
 SQL Server + procedimientos almacenados
```

### 1. Capa de presentación: `BYTEAZULPROFESIONAL`

Es la aplicación principal y contiene la interfaz gráfica que utiliza el usuario.

Responsabilidades principales:

- Mostrar formularios y controles.
- Recibir datos del usuario.
- Validar datos básicos de entrada.
- Navegar entre módulos.
- Mostrar mensajes de éxito o error.
- Invocar las clases de la capa lógica.

El punto de entrada se encuentra en `Program.cs`. La aplicación inicia mostrando el formulario `fmLogin`.

El formulario `FmMenu.cs` funciona como menú principal. Administra los submenús y carga los formularios dentro de un panel contenedor para evitar abrir varias ventanas principales al mismo tiempo.

Entre los formularios principales se encuentran:

- `fmLogin`: inicio de sesión.
- `fmCrearCuentas`: creación de cuentas.
- `fmVerUsuarios`: consulta de usuarios.
- `fmCambiarContrasena`: cambio de contraseña.
- `fmGestionarClientes` y `fmAgregarClientes`: clientes.
- `fmGestionarEmpleados` y `fmAgregarEmpleados`: empleados.
- `fmGestionarProveedores` y `fmAgregarProveedores`: proveedores.
- `fmGestionarMedicina` y `fmAgregarMedicina`: medicinas.
- `fmGestionarCategorias` y `fmAgregarCategorias`: categorías.
- `fmGestionarLotes` y `fmAgregarLotes`: lotes.
- `fmAbrirCaja`, `fmCaja` y `fmCerrar`: operaciones de caja.
- `fmVentas`: ventas.
- `fmMovimientos`: movimientos de caja o inventario.
- `fmReportesVentas`: reportes de ventas.
- `fmGestionarDetallesVentas`: gestión de detalles de ventas.
- `fmAgregarDescuentos`: descuentos o suscripciones.

Los archivos `.Designer.cs` contienen los controles generados por el diseñador de Windows Forms y los archivos `.resx` contienen recursos visuales y configuraciones de los formularios.

### 2. Capa lógica: `CapaLogica`

Esta capa contiene las clases que representan las operaciones y reglas de negocio del sistema. Su función es servir como intermediaria entre los formularios y la base de datos.

Clases principales:

| Clase | Responsabilidad |
|---|---|
| `CsCaja` | Apertura, cierre y validación de caja; ventas y detalles de venta. |
| `CsCategorias` | Operaciones relacionadas con categorías. |
| `CsClientes` | Registro, consulta y gestión de clientes. |
| `CsCompras` | Gestión de compras. |
| `CsEmpleados` | Gestión de empleados y usuarios. |
| `CsMedicinas` | Gestión de medicinas y productos. |
| `CsMovimientos` | Consulta y gestión de movimientos. |
| `CsPrecios` | Operaciones relacionadas con precios. |
| `CsProveedores` | Gestión de proveedores. |
| `CsUnidadMedida` | Gestión de unidades de medida. |

Por ejemplo, `CsCaja` valida que el monto inicial sea numérico y no negativo antes de solicitar a la capa de datos la apertura de una caja. También expone el método `EstaCajaAbierta`, utilizado para impedir el acceso a ventas cuando no existe una sesión de caja activa.

### 3. Capa de datos: `CapaDatos`

Esta capa se encarga de comunicarse con SQL Server. Sus clases abren conexiones, preparan comandos, envían parámetros y recuperan los resultados de los procedimientos almacenados.

Clases principales:

| Clase | Responsabilidad |
|---|---|
| `BdConexionSQL` | Construcción de la conexión con SQL Server. |
| `BdCaja` | Apertura, cierre de caja, ventas, detalles, devoluciones y consultas. |
| `BdCategorias` | Acceso a datos de categorías. |
| `BdClientes` | Acceso a datos de clientes. |
| `BdCompra` | Acceso a datos de compras. |
| `BdEmpleados` | Acceso a datos de empleados y usuarios. |
| `BdMedicinas` | Acceso a datos de medicinas. |
| `BdMovimientos` | Acceso a datos de movimientos. |
| `BdPrecios` | Acceso a datos de precios. |
| `BdProveedores` | Acceso a datos de proveedores. |
| `BdUnidadMedida` | Acceso a datos de unidades de medida. |

La comunicación con la base de datos se realiza principalmente mediante procedimientos almacenados. Algunos de los procedimientos utilizados por el módulo de caja y ventas son:

- `SP_IN_AbrirCaja`
- `SP_SL_VerificarEstadoCaja`
- `SP_UP_CerrarCaja`
- `SP_IN_VENTAS`
- `SP_IN_DETALLES_VENTA`
- `SP_SL_ListarVentas`
- `SP_SL_DETALLESVENTAS`
- `SP_UP_DevolverDetalleVenta`
- `SP_SL_ObtenerTotalDetalleVenta`

## Estructura del repositorio

```text
BYTEAZULOTE/
├── BYTEAZULPROFESIONAL.sln          # Solución de Visual Studio
├── README.md                        # Documentación del proyecto
├── BYTEAZULPROFESIONAL/             # Aplicación Windows Forms
│   ├── Program.cs                   # Punto de entrada
│   ├── FmMenu.cs                    # Menú principal
│   ├── fmLogin.cs                   # Inicio de sesión
│   ├── fmVentas.cs                  # Módulo de ventas
│   ├── fmCaja.cs                    # Gestión de caja
│   ├── fmAbrirCaja.cs               # Apertura de caja
│   ├── fmCerrar.cs                  # Cierre de caja
│   ├── fmGestionar*.cs              # Formularios de gestión
│   ├── fmAgregar*.cs                # Formularios de registro
│   ├── Reportes/                    # Informes RDLC
│   ├── Imagenes/                    # Imágenes, fondos e iconos
│   ├── Properties/                  # Recursos y configuración
│   ├── SqlServerTypes/              # Tipos auxiliares de SQL Server
│   └── packages.config              # Dependencias NuGet
├── CapaLogica/                      # Reglas de negocio
│   ├── CsCaja.cs
│   ├── CsClientes.cs
│   ├── CsCompras.cs
│   ├── CsEmpleados.cs
│   ├── CsMedicinas.cs
│   ├── CsMovimientos.cs
│   ├── CsPrecios.cs
│   ├── CsProveedores.cs
│   ├── CsCategorias.cs
│   └── CsUnidadMedida.cs
├── CapaDatos/                       # Acceso a SQL Server
│   ├── BdConexionSQL.cs
│   ├── BdCaja.cs
│   ├── BdClientes.cs
│   ├── BdCompra.cs
│   ├── BdEmpleados.cs
│   ├── BdMedicinas.cs
│   ├── BdMovimientos.cs
│   ├── BdPrecios.cs
│   ├── BdProveedores.cs
│   ├── BdCategorias.cs
│   └── BdUnidadMedida.cs
└── packages/                        # Dependencias descargadas
```

> Las carpetas `bin`, `obj` y `.vs` son archivos generados por Visual Studio. No contienen código funcional principal y normalmente no deberían versionarse en el repositorio.

## Tecnologías utilizadas

- **Lenguaje:** C#.
- **Interfaz:** Windows Forms.
- **Framework:** .NET Framework; el proyecto principal utiliza .NET Framework 4.8 y las bibliotecas auxiliares utilizan .NET Framework 4.7.2.
- **IDE recomendado:** Visual Studio 2022.
- **Base de datos:** Microsoft SQL Server.
- **Acceso a datos:** `System.Data.SqlClient`.
- **Reportes:** Microsoft ReportViewer y archivos RDLC.
- **Persistencia:** procedimientos almacenados de SQL Server.
- **Dependencias:** paquetes de ReportViewer y Microsoft SQL Server Types.

## Requisitos previos

Para ejecutar el proyecto se necesita:

1. Windows.
2. Visual Studio 2022 con desarrollo de escritorio .NET instalado.
3. .NET Framework compatible.
4. Microsoft SQL Server.
5. La base de datos `BYTEAZUL_REM` creada y configurada.
6. Los procedimientos almacenados requeridos por las clases de `CapaDatos`.
7. Permisos para conectarse a la instancia de SQL Server.

## Instalación y ejecución

1. Clonar el repositorio:

   ```bash
   git clone https://github.com/BRY4N18/BYTEAZULOTE.git
   ```

2. Abrir el archivo `BYTEAZULPROFESIONAL.sln` con Visual Studio.
3. Restaurar las dependencias NuGet si Visual Studio lo solicita.
4. Configurar la conexión de SQL Server en `CapaDatos/BdConexionSQL.cs` o mediante una configuración externa segura.
5. Confirmar que la base de datos y sus procedimientos almacenados estén disponibles.
6. Seleccionar el proyecto `BYTEAZULPROFESIONAL` como proyecto de inicio.
7. Compilar la solución.
8. Ejecutar con `F5` o desde el botón **Iniciar** de Visual Studio.

## Flujo de una operación de venta

El flujo típico de una venta es:

1. El usuario inicia sesión.
2. El sistema abre el menú principal.
3. El empleado abre una sesión de caja indicando el monto inicial.
4. El sistema valida que la caja esté abierta.
5. El usuario selecciona el cliente y los productos.
6. Se calcula el total de cada detalle y el total de la venta.
7. Se registra la cabecera de la venta.
8. Se registran los detalles de la venta.
9. La base de datos actualiza las existencias y los movimientos correspondientes.
10. La venta puede consultarse posteriormente desde los listados y reportes.
11. Al finalizar la jornada, el empleado cierra la caja indicando el monto físico final.

## Seguridad y configuración

La versión actual contiene datos de conexión directamente en `CapaDatos/BdConexionSQL.cs`. Antes de utilizar el sistema en un entorno real se recomienda:

- No almacenar contraseñas en el código fuente.
- No utilizar el usuario `sa` para la aplicación.
- Cambiar inmediatamente cualquier contraseña expuesta.
- Utilizar autenticación integrada de Windows o un usuario SQL con permisos mínimos.
- Guardar la cadena de conexión en `App.config`, variables de entorno o un gestor de secretos.
- No publicar credenciales reales en GitHub.
- Validar y controlar los permisos de cada tipo de usuario.
- Revisar que los procedimientos almacenados utilicen consultas parametrizadas.

## Estado actual del proyecto

El repositorio contiene la solución de Visual Studio, los proyectos de presentación, lógica y datos, los formularios, recursos gráficos, reportes RDLC y algunas dependencias compiladas.

Para una distribución más limpia y segura, se recomienda:

- Eliminar del control de versiones las carpetas `.vs`, `bin` y `obj`.
- Revisar el archivo `.gitignore`.
- Documentar o incluir el script de creación de la base de datos.
- Documentar todos los procedimientos almacenados requeridos.
- Separar las credenciales de conexión del código fuente.
- Incorporar pruebas para las operaciones de caja, ventas e inventario.

## Licencia

No se ha definido una licencia para este repositorio. Si el proyecto se va a distribuir, se recomienda agregar un archivo `LICENSE` con los términos de uso correspondientes.
