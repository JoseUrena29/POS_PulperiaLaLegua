use DB_POSPulperiaLaLegua

/* ----------------- PROCEDIMIENTOS PARA PROVEEDORES ------------------*/

--PROCEDIMIENTO PARA REGISTRAR PROVEEDOR
CREATE PROCEDURE SP_RegistrarProveedor(
    @NumeroIdentidad VARCHAR(50),
	@NombreComercial VARCHAR(50),
	@Correo VARCHAR(50),
	@Telefono VARCHAR(50),
	@Direccion VARCHAR(150),
	@Estado BIT,
    @Resultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @Resultado = 0
    SET @Mensaje = ''

    IF NOT EXISTS (SELECT * FROM PROVEEDOR WHERE NumeroIdentidad = @NumeroIdentidad)
    BEGIN
        INSERT INTO PROVEEDOR(NumeroIdentidad,NombreComercial,Correo,Telefono,Direccion,Estado) VALUES (@NumeroIdentidad,@NombreComercial,@Correo,@Telefono,@Direccion,@Estado)

        SET @Resultado = SCOPE_IDENTITY()
        SET @Mensaje = 'Proveedor creado con éxito.'
    END
    ELSE
    BEGIN
        SET @Mensaje = 'Ya existe un proveedor con ese numero de identidad.'
    END
END
GO

--PROCEDIMIENTO PARA EDITAR PROVEEDOR
CREATE PROCEDURE SP_EditarProveedor(
    @IdProveedor INT,
    @NumeroIdentidad VARCHAR(50),
	@NombreComercial VARCHAR(50),
	@Correo VARCHAR(50),
	@Telefono VARCHAR(50),
	@Direccion VARCHAR(150),
	@Estado BIT,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @Resultado = 1
    SET @Mensaje = ''

    IF NOT EXISTS (
        SELECT * FROM PROVEEDOR 
        WHERE NumeroIdentidad = @NumeroIdentidad AND IdProveedor != @IdProveedor
    )
    BEGIN
        UPDATE PROVEEDOR SET 
		NumeroIdentidad = @NumeroIdentidad, 
		NombreComercial = @NombreComercial, 
		Correo = @Correo, 
		Telefono = @Telefono,
		Direccion = @Direccion,
		Estado = @Estado
        WHERE IdProveedor = @IdProveedor

        SET @Mensaje = 'Proveedor editado con éxito.'
    END
    ELSE
    BEGIN
        SET @Resultado = 0
        SET @Mensaje = 'Ya existe un proveedor con ese numero de indentidad.'
    END
END
GO