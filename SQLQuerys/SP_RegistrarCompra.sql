use DB_POSPulperiaLaLegua

/* ----------------- PROCEDIMIENTOS PARA REGISTRAR COMPRAS ------------------*/

--PROCEDIMIENTO PARA REGISTRAR COMPRA

CREATE TYPE [dbo].[EDetalle_Compra] AS TABLE(
	[IdProducto] int NULL,
	[PrecioCompra] decimal(10,2) NULL,
	[PrecioVenta] decimal(10,2) NULL,
	[Cantidad] int NULL,
	[MontoTotal] decimal(10,2) NULL
)
GO

SELECT COUNT(*) + 1 FROM COMPRA

CREATE PROCEDURE SP_RegistrarCompra(
	@IdUsuario int,
	@IdProveedor int,
	@TipoCompra varchar(500),
	@NumeroCompra varchar(500),
	@MontoNeto DECIMAL(10,2),
	@Descuento DECIMAL(10,2),
	@Subtotal DECIMAL(10,2),
	@IVA DECIMAL(10,2),
	@Total DECIMAL(10,2),
	@DetalleCompra [EDetalle_Compra] READONLY,
	@Resultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
	BEGIN TRY
		DECLARE @IdCompra int = 0;
		SET @Resultado = 1;
		SET @Mensaje = '';

		BEGIN TRANSACTION Registro

		insert into COMPRA(IdUsuario,IdProveedor,TipoCompra,NumeroCompra,MontoNeto,Descuento,Subtotal,IVA,Total)
		values(@IdUsuario,@IdProveedor,@TipoCompra,@NumeroCompra,@MontoNeto,@Descuento,@Subtotal,@IVA,@Total)

		set @IdCompra = SCOPE_IDENTITY()

		insert into DETALLE_COMPRA(IdCompra,IdProducto,PrecioCompra,PrecioVenta,Cantidad,MontoTotal)
		select @IdCompra,IdProducto,PrecioCompra,PrecioVenta,Cantidad,MontoTotal from @DetalleCompra

		UPDATE p set p.Stock = p.Stock + dc.Cantidad,
		p.PrecioCompra = dc.PrecioCompra,
		p.PrecioVenta = dc.PrecioVenta
		FROM PRODUCTO p
		INNER JOIN @DetalleCompra dc on dc.IdProducto = p.IdProducto

		COMMIT TRANSACTION Registro
	END TRY
	BEGIN CATCH
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()

		rollback transaction Registro
	END CATCH
END
GO
