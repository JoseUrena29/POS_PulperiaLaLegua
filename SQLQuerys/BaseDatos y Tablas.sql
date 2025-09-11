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
Clave varchar(50),
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
PrecioCompra decimal(10,2) default 0,
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

--TABLA CORREGIDA
CREATE TABLE COMPRA (
    IdCompra INT PRIMARY KEY IDENTITY,
    IdUsuario INT FOREIGN KEY REFERENCES USUARIO(IdUsuario),
    IdProveedor INT FOREIGN KEY REFERENCES PROVEEDOR(IdProveedor),
    TipoCompra VARCHAR(50),
    NumeroCompra VARCHAR(50),
    MontoNeto DECIMAL(10,2),     -- Suma total de productos sin impuestos ni descuentos
    Descuento DECIMAL(10,2),     -- Descuento total aplicado
    Subtotal DECIMAL(10,2),      -- MontoNeto - Descuento
    IVA DECIMAL(10,2),           -- Impuesto calculado sobre el subtotal
    Total DECIMAL(10,2),         -- Subtotal + IVA
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO

--TABLA CORREGIDA
CREATE TABLE DETALLE_COMPRA (
    IdDetalleCompra INT PRIMARY KEY IDENTITY,
    IdCompra INT FOREIGN KEY REFERENCES COMPRA(IdCompra),
    IdProducto INT FOREIGN KEY REFERENCES PRODUCTO(IdProducto),
    PrecioCompra DECIMAL(10,2) DEFAULT 0,  -- Precio por unidad
	PrecioVenta decimal(10,2) default 0,
    Cantidad INT,
    MontoTotal DECIMAL(10,2),              -- PrecioCompra × Cantidad
    FechaRegistro DATETIME DEFAULT GETDATE()
);
GO



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
TipoPago varchar(50),
NumeroVenta varchar(50) UNIQUE,
MontoNeto DECIMAL(10,2), 
Descuento DECIMAL(10,2),     
Subtotal DECIMAL(10,2),      
IVA DECIMAL(10,2),           
Total DECIMAL(10,2),
MontoPago decimal(10,2),
MontoCambio decimal(10,2),
FechaRegistro datetime default getdate()
)
GO
--NOTAS DE CORRECCIONES POR PROFESOR: Modificar por Tipo de Pago 
--(Efectivo, Sinpe, Tarjeta) / Agregar los campos (monto neto, descuento, iva, total) LISTO!

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


-- 1. Eliminar detalle primero (por FK)
IF OBJECT_ID('dbo.DETALLE_AJUSTE', 'U') IS NOT NULL
    DROP TABLE dbo.DETALLE_AJUSTE;
GO

-- 2. Luego eliminar cabecera
IF OBJECT_ID('dbo.AJUSTE', 'U') IS NOT NULL
    DROP TABLE dbo.AJUSTE;
GO

-- Cabecera del ajuste
CREATE TABLE AJUSTE (
    IdAjuste INT PRIMARY KEY IDENTITY,
    IdUsuario INT FOREIGN KEY REFERENCES USUARIO(IdUsuario),
	TipoAjuste NVARCHAR(10) NOT NULL CHECK (TipoAjuste IN ('ENTRADA','SALIDA')), -- Solo stock
	NumeroAjuste VARCHAR(50) UNIQUE NOT NULL,
    MotivoGeneral NVARCHAR(255) NOT NULL,    -- Ej: Ajuste de inventario, daño, pérdida
    Observaciones NVARCHAR(MAX) NULL,        -- Comentarios adicionales
    FechaRegistro datetime default getdate()
);
GO

-- Detalle por producto
CREATE TABLE DETALLE_AJUSTE (
    IdDetalleAjuste INT PRIMARY KEY IDENTITY,
    IdAjuste INT FOREIGN KEY REFERENCES AJUSTE(IdAjuste),
    IdProducto INT FOREIGN KEY REFERENCES PRODUCTO(IdProducto),
    StockAnterior INT NULL,
    StockNuevo INT NULL,
    FechaRegistro datetime default getdate()
);
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








