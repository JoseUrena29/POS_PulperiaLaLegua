use DB_POSPulperiaLaLegua

select * from PRODUCTO

/* ----------------- PROCEDIMIENTOS PARA PRODUCTOS ------------------*/

--PROCEDIMIENTO PARA REGISTRAR PRODUCTOS
CREATE PROCEDURE SP_RegistrarProducto(
    @Codigo VARCHAR(30),
	@Nombre VARCHAR(30),
	@Descripcion VARCHAR(100),
	@IdCategoria INT,
	@PrecioCompra DECIMAL(10,2),
    @PrecioVenta DECIMAL(10,2),
	@Estado BIT,
    @Resultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @Resultado = 0
    IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE Codigo = @Codigo)
    BEGIN
        INSERT INTO PRODUCTO(Codigo,Nombre,Descripcion,IdCategoria,PrecioCompra,PrecioVenta,Estado) VALUES (@Codigo,@Nombre,@Descripcion,@IdCategoria,@PrecioCompra,@PrecioVenta,@Estado)
        SET @Resultado = SCOPE_IDENTITY()
        SET @Mensaje = 'Producto creado con éxito.'
    END
    ELSE
    BEGIN
        SET @Mensaje = 'Ya existe un producto con el mismo código.'
    END
END
GO

--PROCEDIMIENTO PARA EDITAR PRODUCTOS
CREATE PROCEDURE SP_EditarProducto(
    @IdProducto INT,
	@Codigo VARCHAR(30),
	@Nombre VARCHAR(30),
	@Descripcion VARCHAR(100),
	@IdCategoria INT,
	@PrecioCompra DECIMAL(10,2),
	@PrecioVenta DECIMAL(10,2),
	@Estado BIT,
    @Resultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
    SET @Resultado = 1
    IF NOT EXISTS (SELECT * FROM PRODUCTO WHERE Codigo = @Codigo AND IdProducto != @IdProducto)
	BEGIN
        UPDATE PRODUCTO SET
		Codigo = @Codigo,
		Nombre = @Nombre,
		Descripcion = @Descripcion,
		IdCategoria = @IdCategoria,
		PrecioCompra = @PrecioCompra,
		PrecioVenta = @PrecioVenta,
		Estado = @Estado
        WHERE IdProducto = @IdProducto

        SET @Mensaje = 'Producto editado con éxito.'
    END
	ELSE
    BEGIN
        SET @Resultado = 0
        SET @Mensaje = 'Ya existe un producto con el mismo código.'
    END
END
GO

Select IdProducto,Codigo,Nombre,p.Descripcion,c.IdCategoria,c.Descripcion[DescripcionCategoria],Stock,PrecioCompra,PrecioVenta,p.Estado from PRODUCTO p
INNER JOIN CATEGORIA c on c.IdCategoria = p.IdCategoria