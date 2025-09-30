use DB_POSPulperiaLaLegua

/* ----------------- PROCEDIMIENTOS PARA USUARIO ------------------*/

--PROCEDIMIENTO PARA REGISTRAR USUARIO
CREATE PROCEDURE SP_RegistrarUsuario(
    @NumeroIdentidad VARCHAR(50),
	@NombreCompleto VARCHAR(100),
	@Correo VARCHAR(100),
	@Telefono VARCHAR(100),
	@Clave VARCHAR(100),
	@IdRol INT,
	@Estado BIT,
    @Resultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @Resultado = 0
    SET @Mensaje = ''

    IF NOT EXISTS (SELECT * FROM USUARIO WHERE NumeroIdentidad = @NumeroIdentidad)
    BEGIN
        INSERT INTO USUARIO (NumeroIdentidad,NombreCompleto,Correo,Telefono,Clave,IdRol,Estado) VALUES (@NumeroIdentidad,@NombreCompleto,@Correo,@Telefono,@Clave,@IdRol,@Estado)

        SET @Resultado = SCOPE_IDENTITY()
        SET @Mensaje = 'Usuario creado con éxito.'
    END
    ELSE
    BEGIN
        SET @Mensaje = 'Ya existe un usuario con ese numero de identidad.'
    END
END
GO

--PROCEDIMIENTO PARA EDITAR USUARIO
CREATE PROCEDURE SP_EditarUsuario(
    @IdUsuario INT,
    @NumeroIdentidad VARCHAR(50),
	@NombreCompleto VARCHAR(100),
	@Correo VARCHAR(100),
	@Telefono VARCHAR(100),
	@Clave VARCHAR(100),
	@IdRol INT,
	@Estado BIT,
    @Resultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @Resultado = 1
    SET @Mensaje = ''

    IF NOT EXISTS (
        SELECT * FROM USUARIO 
        WHERE NumeroIdentidad = @NumeroIdentidad AND IdUsuario != @IdUsuario
    )
    BEGIN
        UPDATE USUARIO SET 
		NumeroIdentidad = @NumeroIdentidad, 
		NombreCompleto = @NombreCompleto, 
		Correo = @Correo, 
		Telefono = @Telefono,
		Clave = @Clave,
		IdRol = @IdRol,
		Estado = @Estado
        WHERE IdUsuario = @IdUsuario

        SET @Mensaje = 'Usuario editado con éxito.'
    END
    ELSE
    BEGIN
        SET @Resultado = 0
        SET @Mensaje = 'Ya existe un usuario con ese numero de indentidad.'
    END
END
GO