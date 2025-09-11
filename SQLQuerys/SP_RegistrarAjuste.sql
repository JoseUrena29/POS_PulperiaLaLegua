use DB_POSPulperiaLaLegua

/* ----------------- PROCEDIMIENTOS PARA REGISTRAR AJUTES ------------------*/

--PROCEDIMIENTO PARA REGISTRAR AJUSTE

-- Tipo de tabla para los detalles del ajuste
CREATE TYPE [dbo].[EDetalle_Ajuste] AS TABLE(
    IdProducto INT,
    StockNuevo INT
);
GO

CREATE PROCEDURE SP_RegistrarAjuste
(
    @IdUsuario INT,
    @TipoAjuste NVARCHAR(10),  -- 'ENTRADA' o 'SALIDA'
    @NumeroAjuste VARCHAR(50), -- Lo envías desde C#
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

        -- Insertar cabecera del ajuste
        INSERT INTO AJUSTE (IdUsuario, TipoAjuste, NumeroAjuste, MotivoGeneral, Observaciones)
        VALUES (@IdUsuario, @TipoAjuste, @NumeroAjuste, @MotivoGeneral, @Observaciones);

        SET @IdAjuste = SCOPE_IDENTITY();

        -- Insertar detalle del ajuste y guardar stock anterior
        INSERT INTO DETALLE_AJUSTE
        (IdAjuste, IdProducto, StockAnterior, StockNuevo)
        SELECT
            @IdAjuste,
            da.IdProducto,
            p.Stock AS StockAnterior,
            da.StockNuevo AS StockNuevo
        FROM @DetalleAjuste da
        INNER JOIN PRODUCTO p ON p.IdProducto = da.IdProducto;

        -- Actualizar PRODUCTO con nuevo stock
        UPDATE p
        SET p.Stock = da.StockNuevo
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