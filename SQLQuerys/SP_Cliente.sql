use DB_POSPulperiaLaLegua

/* ----------------- PROCEDIMIENTOS PARA CLIENTE ------------------*/

--PROCEDIMIENTO PARA GUARDAR CLIENTE
CREATE PROCEDURE SP_RegistrarCliente(
    @NumeroIdentidad VARCHAR(50),
	@NombreCompleto VARCHAR(50),
	@Correo VARCHAR(50),
	@Telefono VARCHAR(50),
	@Estado BIT,
    @Resultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @Resultado = 0
    SET @Mensaje = ''

    IF NOT EXISTS (SELECT * FROM CLIENTE WHERE NumeroIdentidad = @NumeroIdentidad)
    BEGIN
        INSERT INTO CLIENTE (NumeroIdentidad,NombreCompleto,Correo,Telefono,Estado) VALUES (@NumeroIdentidad,@NombreCompleto,@Correo,@Telefono,@Estado)

        SET @Resultado = SCOPE_IDENTITY()
        SET @Mensaje = 'Cliente creado con éxito.'
    END
    ELSE
    BEGIN
        SET @Mensaje = 'Ya existe un cliente con ese numero de identidad.'
    END
END
GO

--PROCEDIMIENTO PARA EDITAR CLIENTE
CREATE PROCEDURE SP_EditarCliente(
    @IdCliente INT,
    @NumeroIdentidad VARCHAR(50),
	@NombreCompleto VARCHAR(50),
	@Correo VARCHAR(50),
	@Telefono VARCHAR(50),
	@Estado BIT,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @Resultado = 1
    SET @Mensaje = ''

    IF NOT EXISTS (
        SELECT * FROM CLIENTE 
        WHERE NumeroIdentidad = @NumeroIdentidad AND IdCliente != @IdCliente
    )
    BEGIN
        UPDATE CLIENTE SET 
		NumeroIdentidad = @NumeroIdentidad, 
		NombreCompleto = @NombreCompleto, 
		Correo = @Correo, 
		Telefono = @Telefono, 
		Estado = @Estado
        WHERE IdCliente = @IdCliente

        SET @Mensaje = 'Cliente editado con éxito.'
    END
    ELSE
    BEGIN
        SET @Resultado = 0
        SET @Mensaje = 'Ya existe un cliente con ese numero de indentidad.'
    END
END
GO