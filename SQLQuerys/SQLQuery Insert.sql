use DB_POSPulperiaLaLegua

select * from USUARIO
select * from ROL
select * from CATEGORIA

select IdUsuario,NumeroIdentidad,NombreCompleto,Correo,Telefono,Usuario,Contrase�a,Estado from USUARIO
select IdCategoria,Descripcion,Estado from CATEGORIA

insert into ROL(Descripcion)
values ('ADMINISTRADOR')

insert into ROL(Descripcion)
values ('EMPLEADO')

insert into USUARIO(NumeroIdentidad,NombreCompleto,Correo,Telefono,Usuario,Contrase�a,IdRol,Estado)
values 
('207770863','Jose Ure�a Aguilar','urea.jose29@gmail.com','86348556','207770863','1234',1,1)

INSERT INTO CATEGORIA (Descripcion, Estado)
VALUES 
('L�cteos', 1),
('Carnes y Embutidos', 0),
('Frutas y Verduras', 1),
('Panader�a', 1),
('Bebidas', 0);



