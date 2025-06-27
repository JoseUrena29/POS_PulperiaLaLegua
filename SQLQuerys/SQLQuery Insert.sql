use DB_POSPulperiaLaLegua

select * from USUARIO
select * from ROL
select * from CATEGORIA
select * from PRODUCTO

select IdUsuario,NumeroIdentidad,NombreCompleto,Correo,Telefono,Usuario,Contraseña,Estado from USUARIO

select IdCategoria,Descripcion,Estado from CATEGORIA

Select IdProducto,Codigo,Nombre,p.Descripcion,c.IdCategoria,c.Descripcion[DescripcionCategoria],Stock,PrecioCompra,PrecioVenta from PRODUCTO p
INNER JOIN CATEGORIA c on c.IdCategoria = p.IdCategoria

insert into ROL(Descripcion)
values ('ADMINISTRADOR')

insert into ROL(Descripcion)
values ('EMPLEADO')

insert into USUARIO(NumeroIdentidad,NombreCompleto,Correo,Telefono,Usuario,Contraseña,IdRol,Estado)
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

Select p.IdProducto,p.Codigo,p.Nombre,p.Descripcion,c.IdProducto, c.Descripcion[DescripcionProducto],p.Stock,p.PrecioCompra,p.PrecioVenta,p.Estado from Producto p 
INNER JOIN Producto c on c.IdProducto = p.IdProducto



