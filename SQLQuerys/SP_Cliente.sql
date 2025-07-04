use DB_POSPulperiaLaLegua

/* ----------------- PROCEDIMIENTOS PARA CLIENTE ------------------*/

--PROCEDIMIENTO PARA GUARDAR CLIENTE
CREATE PROCEDURE SP_RegistrarCategoria(
    @Descripcion VARCHAR(100),
	@Estado BIT,
    @Resultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @Resultado = 0
    SET @Mensaje = ''

    IF NOT EXISTS (SELECT * FROM CATEGORIA WHERE Descripcion = @Descripcion)
    BEGIN
        INSERT INTO CATEGORIA (Descripcion,Estado) VALUES (@Descripcion,@Estado)

        SET @Resultado = SCOPE_IDENTITY()
        SET @Mensaje = 'Categor�a creada con �xito.'
    END
    ELSE
    BEGIN
        SET @Mensaje = 'Ya existe una categor�a con esa descripci�n.'
    END
END
GO

--PROCEDIMIENTO PARA EDITAR CLIENTE
CREATE PROCEDURE SP_EditarCategoria(
    @IdCategoria INT,
    @Descripcion VARCHAR(100),
	@Estado BIT,
    @Resultado BIT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @Resultado = 1
    SET @Mensaje = ''

    IF NOT EXISTS (
        SELECT 1 FROM CATEGORIA 
        WHERE Descripcion = @Descripcion AND IdCategoria != @IdCategoria
    )
    BEGIN
        UPDATE CATEGORIA
        SET Descripcion = @Descripcion, Estado = @Estado
        WHERE IdCategoria = @IdCategoria

        SET @Mensaje = 'Categor�a editada con �xito.'
    END
    ELSE
    BEGIN
        SET @Resultado = 0
        SET @Mensaje = 'Ya existe otra categor�a con esa descripci�n.'
    END
END
GO