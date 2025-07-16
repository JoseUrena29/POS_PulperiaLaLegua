use DB_POSPulperiaLaLegua

select * from USUARIO
select * from ROL
select * from CATEGORIA
select * from PRODUCTO
select * from CLIENTE
select * from PROVEEDOR
select * from NEGOCIO

DBCC CHECKIDENT ('CLIENTE', NORESEED);
DBCC CHECKIDENT ('CLIENTE', RESEED, 4);

DBCC CHECKIDENT ('PRODUCTO', NORESEED);
DBCC CHECKIDENT ('PRODUCTO', RESEED, 3);

DBCC CHECKIDENT ('CATEGORIA', NORESEED);
DBCC CHECKIDENT ('CATEGORIA', RESEED, 8);

/*USUARIOS*/
select IdUsuario,NumeroIdentidad,NombreCompleto,Correo,Telefono,Usuario,Clave,Estado from USUARIO

/*CATEGORIAS*/
select IdCategoria,Descripcion,Estado from CATEGORIA

/*PRODUCTOS*/
Select IdProducto,Codigo,Nombre,p.Descripcion,c.IdCategoria,c.Descripcion[DescripcionCategoria],Stock,PrecioCompra,PrecioVenta from PRODUCTO p
INNER JOIN CATEGORIA c on c.IdCategoria = p.IdCategoria

/*CLIENTES*/
select IdCliente,NumeroIdentidad,NombreCompleto,Correo,Telefono,Estado from CLIENTE

/*PROVEEDOR*/
Select IdProveedor,NumeroIdentidad,NombreComercial,Correo,Telefono,Direccion,Estado from PROVEEDOR

/*NEGOCIO*/
Select IdNegocio,Nombre,NumeroIdentificacion,Direccion from NEGOCIO

insert into ROL(Descripcion)
values ('ADMINISTRADOR')

insert into ROL(Descripcion)
values ('EMPLEADO')

insert into USUARIO(NumeroIdentidad,NombreCompleto,Correo,Telefono,Usuario,Clave,IdRol,Estado)
values 
('207770863','Jose Ureña Aguilar','urea.jose29@gmail.com','86348556','207770863','1234',1,1)

INSERT INTO CATEGORIA (Descripcion, Estado)
VALUES 
('Lácteos', 1),
('Carnes y Embutidos', 0),
('Frutas y Verduras', 1),
('Panadería', 1),
('Bebidas', 0);

INSERT INTO PRODUCTO (Codigo,Nombre,Descripcion,IdCategoria) VALUES ('7441003596122','Gaseosa Coca Cola','355 ml',5)
INSERT INTO PRODUCTO (Codigo,Nombre,Descripcion,IdCategoria) VALUES ('7441002601001','Sardina','Sardimal ',6)

INSERT INTO CLIENTE(NumeroIdentidad,NombreCompleto,Correo,Telefono,Estado)
VALUES 
('207770863','Jose Ureña Aguilar','urea.jose29@gmail.com','86348556',1)

INSERT INTO PROVEEDOR(NumeroIdentidad,NombreComercial,Correo,Telefono,Direccion,Estado)
VALUES 
('3-101-005212','Coca Cola FEMSA','info@coca-cola.co.cr','8000-26522','Calle Blancos, San José, Costa Rica',1)

INSERT INTO NEGOCIO(Nombre,NumeroIdentificacion,Direccion)
VALUES 
('Pulpería La Legua','101010','300m suroeste del Bar Linda Vista, La Legua, Mercedes Sur, Puriscal')



