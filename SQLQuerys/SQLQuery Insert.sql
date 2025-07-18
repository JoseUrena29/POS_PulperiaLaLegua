use DB_POSPulperiaLaLegua

select * from USUARIO
select * from ROL
select * from PERMISO
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
select u.IdUsuario,u.NumeroIdentidad,u.NombreCompleto,u.Correo,u.Telefono,u.UsuarioLogin,u.Clave,u.Estado,r.IdRol,r.Descripcion from USUARIO u
inner join ROl r on r.IdRol = u.IdRol

/*PERMISOS*/
select p.IdRol,p.NombreMenu from PERMISO p
inner join ROL r on r.IdRol = p.IdRol
inner join USUARIO u on u.IdRol = r.IdRol
where u.IdUsuario = 2


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

insert into USUARIO(NumeroIdentidad,NombreCompleto,Correo,Telefono,Clave,IdRol,Estado)
values 
('207770863','Jose Ureña Aguilar','urea.jose29@gmail.com','86348556','1234',1,1)

insert into USUARIO(NumeroIdentidad,NombreCompleto,Correo,Telefono,Clave,IdRol,Estado)
values 
('115620419','Cristian Ureña Aguilar','cristianurena@gmail.com','87429129','1234',2,1)

/*Rol Administrador*/
insert into PERMISO(IdRol,NombreMenu)
values 
(1,'menuusuarios'),(1,'menumantenimiento'),(1,'menuventas'),(1,'menucompras'),(1,'menuajustes'),(1,'menureportes'),(1,'menuacercade'),(1,'menupendiente'),
(1,'SubMenuCategoría'),(1,'SubMenuProductos'),(1,'SubMenuClientes'),(1,'SubMenuProveedores'),(1,'SubMenuNegocio'),(1,'SubMenuRegistrarVenta'),(1,'SubMenuConsultarVenta'),
(1,'SubMenuRegistrarCompras'),(1,'SubMenuConsultarCompras'),(1,'SubMenuRegistrarAjuste'),(1,'SubMenuConsultarAjuste')

/*Rol Empleado*/
insert into PERMISO(IdRol,NombreMenu)
values 
(2,'menumantenimiento'),(2,'menuventas'),(2,'menucompras'),(2,'menuajustes'),(2,'menuacercade'),
(2,'SubMenuClientes'),(2,'SubMenuProveedores'),(2,'SubMenuRegistrarVenta'),(2,'SubMenuConsultarVenta'),
(2,'SubMenuRegistrarCompras'),(2,'SubMenuConsultarCompras'),(2,'SubMenuRegistrarAjuste'),(2,'SubMenuConsultarAjuste')

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



