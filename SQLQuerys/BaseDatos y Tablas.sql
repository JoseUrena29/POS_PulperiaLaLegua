CREATE DATABASE DB_POSPulperiaLaLegua

GO

USE DB_POSPulperiaLaLegua

GO

-- Tabla de Roles
CREATE TABLE ROL(
IdRol INT PRIMARY KEY IDENTITY,
Descripcion varchar(50),
FechaRegistro datetime default getdate()
)
GO

-- Tabla de Permisos por rol
CREATE TABLE PERMISO(
IdPermiso INT PRIMARY KEY IDENTITY,
IdRol INT FOREIGN KEY REFERENCES ROL(IdRol),
NombreMenu varchar(100),
FechaRegistro datetime default getdate()
)
GO


-- Tabla de Proveedores
CREATE TABLE PROVEEDOR(
IdProveedor INT PRIMARY KEY IDENTITY,
NumeroIdentidad varchar(50),
NombreComercial varchar(50),
Correo varchar(50),
Telefono varchar(50),
Direccion varchar(150),
Estado bit,
FechaRegistro datetime default getdate()
)
GO

--NOTAS DE CORRECCIONES POR PROFESOR: Agregar direcciòn en tabla proveedores --> LISTO!

-- Tabla de Clientes
CREATE TABLE CLIENTE(
IdCliente INT PRIMARY KEY IDENTITY,
NumeroIdentidad varchar(50),
NombreCompleto varchar(50),
Correo varchar(50),
Telefono varchar(50),
Estado bit,
FechaRegistro datetime default getdate()
)
GO

-- Tabla de Usuarios
CREATE TABLE USUARIO(
IdUsuario INT PRIMARY KEY IDENTITY,
NumeroIdentidad varchar(50),
NombreCompleto varchar(50),
Correo varchar(50),
Telefono varchar(50),
Usuario varchar(50),
Contraseña varchar(50),
IdRol INT FOREIGN KEY REFERENCES ROL(IdRol),
Estado bit,
FechaRegistro datetime default getdate()
)
GO

-- Tabla de Categorías
CREATE TABLE CATEGORIA(
IdCategoria INT PRIMARY KEY IDENTITY,
Descripcion varchar(100),
Estado bit,
FechaRegistro datetime default getdate()
)
GO

-- Tabla de Productos
CREATE TABLE PRODUCTO(
IdProducto INT PRIMARY KEY IDENTITY,
Codigo varchar(50),
Nombre varchar(50),
Descripcion varchar(200),
IdCategoria INT FOREIGN KEY REFERENCES CATEGORIA(IdCategoria),
Stock int not null default 0,
PrecioCompra decimal(10,2) default 0, --Eliminar
PrecioVenta decimal(10,2) default 0,
Estado bit,
FechaRegistro datetime default getdate()
)
GO
--NOTAS DE CORRECCIONES POR PROFESOR: Precio compra está en la tabla compras, agregar ID Usuario y registrar los cambios que se realizaron

-- Tabla de Compras
CREATE TABLE COMPRA(
IdCompra INT PRIMARY KEY IDENTITY,
IdUsuario INT FOREIGN KEY REFERENCES USUARIO(IdUsuario),
IdProveedor INT FOREIGN KEY REFERENCES PROVEEDOR(IdProveedor),
TipoCompra varchar(50),
NumeroCompra varchar(50),
MontoTotal decimal(10,2),
FechaRegistro datetime default getdate()
)
GO
--NOTAS DE CORRECCIONES POR PROFESOR: Eliminar MontoTotal y agregar los campos (monto neto, descuento, iva, total)

-- Detalle de cada compra
CREATE TABLE DETALLE_COMPRA(
IdDetalleCompra INT PRIMARY KEY IDENTITY,
IdCompra INT FOREIGN KEY REFERENCES COMPRA(IdCompra),
IdProducto INT FOREIGN KEY REFERENCES PRODUCTO(IdProducto),
PrecioCompra decimal(10,2) default 0,
PrecioVenta decimal(10,2) default 0, --Eliminar
Cantidad int,
MontoTotal decimal(10,2),
FechaRegistro datetime default getdate()
)
GO
--NOTAS DE CORRECCIONES POR PROFESOR: Eliminar Precio venta, ya que esta en la tabla productos

-- Tabla de Ventas
CREATE TABLE VENTA(
IdVenta INT PRIMARY KEY IDENTITY,
IdUsuario INT FOREIGN KEY REFERENCES USUARIO(IdUsuario),
IdCliente INT NULL FOREIGN KEY REFERENCES CLIENTE(IdCliente),
TipoVenta varchar(50), --Modificar por Tipo de Pago (Efectivo, Sinpe, Tarjeta)
NumeroVenta varchar(50),
MontoPago decimal(10,2),
MontoCambio decimal(10,2),
MontoTotal decimal(10,2),
FechaRegistro datetime default getdate()
)
GO
--NOTAS DE CORRECCIONES POR PROFESOR: Modificar por Tipo de Pago (Efectivo, Sinpe, Tarjeta) / Agregar los campos (monto neto, descuento, iva, total)

-- Detalle de cada venta
CREATE TABLE DETALLE_VENTA(
IdDetalleVenta INT PRIMARY KEY IDENTITY,
IdVenta INT FOREIGN KEY REFERENCES VENTA(IdVenta),
IdProducto INT FOREIGN KEY REFERENCES PRODUCTO(IdProducto),
PrecioVenta decimal(10,2),
Cantidad int,
SubTotal decimal(10,2),
FechaRegistro datetime default getdate()
)
GO

-- Cabecera del ajuste
CREATE TABLE AJUSTE(
    IdAjuste INT PRIMARY KEY IDENTITY,
    IdUsuario INT FOREIGN KEY REFERENCES USUARIO(IdUsuario),
    MotivoGeneral nvarchar(255),
    FechaRegistro datetime default getdate()
)
GO

-- Detalle por producto
CREATE TABLE DETALLE_AJUSTE(
    IdDetalleAjuste INT PRIMARY KEY IDENTITY,
    IdAjuste INT FOREIGN KEY REFERENCES AJUSTE(IdAjuste),
    IdProducto INT FOREIGN KEY REFERENCES PRODUCTO(IdProducto),
    TipoAjuste NVARCHAR(10), -- 'ENTRADA' o 'SALIDA'
    Cantidad INT,
    Motivo NVARCHAR(255)
)
GO

-- Tabla de Información del Negocio
CREATE TABLE NEGOCIO(
IdNegocio INT PRIMARY KEY IDENTITY,
Nombre varchar(60),
NumeroIdentificacion varchar(60),
Direccion varchar(100),
Logo varbinary(max) NULL
)
GO








