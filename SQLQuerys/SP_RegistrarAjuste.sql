use DB_POSPulperiaLaLegua

/* ----------------- PROCEDIMIENTOS PARA REGISTRAR AJUTES ------------------*/

--PROCEDIMIENTO PARA REGISTRAR AJUSTE

CREATE TYPE [dbo].[EDetalle_Ajuste] AS TABLE(
    IdProducto INT,
    TipoAjuste NVARCHAR(10),
    Cantidad INT,
    PrecioCompraNuevo DECIMAL(10,2),
    PrecioVentaNuevo DECIMAL(10,2),
    Motivo NVARCHAR(255)
)
GO

CREATE PROCEDURE SP_RegistrarAjuste
(
    @IdUsuario INT,
    @MotivoGeneral NVARCHAR(255),
    @Observaciones NVARCHAR(MAX) = NULL,
    @DetalleAjuste [EDetalle_Ajuste] READONLY,
    @Resultado INT OUTPUT,
    @Mensaje NVARCHAR(500) OUTPUT
)
AS
BEGIN
    BEGIN TRY
        SET NOCOUNT ON;
        SET @Resultado = 1;
        SET @Mensaje = '';

        DECLARE @IdAjuste INT = 0;

        BEGIN TRANSACTION RegistroAjuste;

        -- Insertar encabezado del ajuste
        INSERT INTO AJUSTE (IdUsuario, MotivoGeneral, Observaciones)
        VALUES (@IdUsuario, @MotivoGeneral, @Observaciones);

        SET @IdAjuste = SCOPE_IDENTITY();

        -- Insertar detalle del ajuste y calcular stock anterior/nuevo
        INSERT INTO DETALLE_AJUSTE 
        (IdAjuste, IdProducto, TipoAjuste, Cantidad, 
         PrecioCompraAnterior, PrecioCompraNuevo,
         PrecioVentaAnterior, PrecioVentaNuevo,
         StockAnterior, StockNuevo, Motivo)
        SELECT 
            @IdAjuste,
            da.IdProducto,
            da.TipoAjuste,
            da.Cantidad,
            p.PrecioCompra AS PrecioCompraAnterior,
            da.PrecioCompraNuevo,
            p.PrecioVenta AS PrecioVentaAnterior,
            da.PrecioVentaNuevo,
            p.Stock AS StockAnterior,
            CASE 
                WHEN da.TipoAjuste = 'ENTRADA' THEN p.Stock + da.Cantidad
                ELSE p.Stock - da.Cantidad
            END AS StockNuevo,
            da.Motivo
        FROM @DetalleAjuste da
        INNER JOIN PRODUCTO p ON p.IdProducto = da.IdProducto;

        -- Actualizar PRODUCTO con stock y precios
        UPDATE p
        SET 
            p.Stock = CASE 
                        WHEN da.TipoAjuste = 'ENTRADA' THEN p.Stock + da.Cantidad
                        ELSE p.Stock - da.Cantidad
                      END,
            p.PrecioCompra = da.PrecioCompraNuevo,
            p.PrecioVenta = da.PrecioVentaNuevo
        FROM PRODUCTO p
        INNER JOIN @DetalleAjuste da ON p.IdProducto = da.IdProducto;

        COMMIT TRANSACTION RegistroAjuste;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION RegistroAjuste;
        SET @Resultado = 0;
        SET @Mensaje = ERROR_MESSAGE();
    END CATCH
END
GO