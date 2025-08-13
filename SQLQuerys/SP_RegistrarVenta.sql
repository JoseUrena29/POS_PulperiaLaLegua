use DB_POSPulperiaLaLegua

/* ----------------- PROCEDIMIENTOS PARA REGISTRAR VENTAS ------------------*/

--PROCEDIMIENTO PARA REGISTRAR VENTA

CREATE TYPE [dbo].[EDetalle_Venta] AS TABLE(
	[IdProducto] int NULL,
	[PrecioVenta] decimal(10,2) NULL,
	[Cantidad] int NULL,
	[SubTotal] decimal(10,2) NULL
)
GO

SELECT COUNT(*) + 1 FROM VENTA

UPDATE PRODUCTO SET stock = stock - @cantidad where IdProducto = @IdProducto

CREATE PROCEDURE SP_RegistrarVenta(
	@IdUsuario int,
	@IdCliente int,
	@TipoPago varchar(500),
	@NumeroVenta varchar(500),
	@MontoNeto DECIMAL(10,2),
	@Descuento DECIMAL(10,2),
	@Subtotal DECIMAL(10,2),
	@IVA DECIMAL(10,2),
	@Total DECIMAL(10,2),
	@MontoPago DECIMAL(10,2),
	@MontoCambio DECIMAL(10,2),
	@DetalleVenta [EDetalle_Venta] READONLY,
	@Resultado INT OUTPUT,
    @Mensaje VARCHAR(500) OUTPUT
)
AS
BEGIN
	BEGIN TRY
		DECLARE @IdVenta int = 0;
		SET @Resultado = 1;
		SET @Mensaje = '';

		BEGIN TRANSACTION Registro

		insert into VENTA(IdUsuario,IdCliente,TipoPago,NumeroVenta,MontoNeto,Descuento,Subtotal,IVA,Total,MontoPago,MontoCambio)
		values(@IdUsuario,@IdCliente,@TipoPago,@NumeroVenta,@MontoNeto,@Descuento,@Subtotal,@IVA,@Total,@MontoPago,@MontoCambio)

		set @IdVenta = SCOPE_IDENTITY()

		insert into DETALLE_VENTA(IdVenta,IdProducto,PrecioVenta,Cantidad,SubTotal)
		select @IdVenta,IdProducto,PrecioVenta,Cantidad,SubTotal from @DetalleVenta

		UPDATE p set p.Stock = p.Stock - dv.Cantidad
		FROM PRODUCTO p
		INNER JOIN @DetalleVenta dv on dv.IdProducto = p.IdProducto

		COMMIT TRANSACTION Registro
	END TRY
	BEGIN CATCH
		set @Resultado = 0
		set @Mensaje = ERROR_MESSAGE()

		rollback transaction Registro
	END CATCH
END
GO