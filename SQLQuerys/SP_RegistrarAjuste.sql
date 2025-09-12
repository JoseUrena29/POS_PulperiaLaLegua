use DB_POSPulperiaLaLegua

/* ----------------- PROCEDIMIENTOS PARA REGISTRAR AJUTES ------------------*/

--PROCEDIMIENTO PARA REGISTRAR AJUSTE

SELECT COUNT(*) + 1 FROM AJUSTE

-- Tipo de tabla para los detalles del ajuste
CREATE TYPE [dbo].[EDetalle_Ajuste] AS TABLE(
    IdProducto INT,
    Cantidad INT
);
GO

CREATE PROCEDURE SP_RegistrarAjuste
(
    @IdUsuario INT,
    @TipoAjuste NVARCHAR(10),  -- 'ENTRADA' o 'SALIDA'
    @NumeroAjuste VARCHAR(50), -- Enviado desde C#
    @MotivoGeneral NVARCHAR(255),
    @Observaciones NVARCHAR(MAX) = NULL,
    @DetalleAjuste [EDetalle_Ajuste] READONLY, -- ahora solo lleva IdProducto, Cantidad
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

        -- Insertar detalle y calcular stocks
        INSERT INTO DETALLE_AJUSTE (IdAjuste, IdProducto, StockAnterior, StockNuevo, Cantidad)
        SELECT
            @IdAjuste,
            da.IdProducto,
            p.Stock AS StockAnterior,
            CASE 
                WHEN @TipoAjuste = 'ENTRADA' THEN p.Stock + da.Cantidad
                WHEN @TipoAjuste = 'SALIDA' THEN p.Stock - da.Cantidad
            END AS StockNuevo,
            da.Cantidad
        FROM @DetalleAjuste da
        INNER JOIN PRODUCTO p ON p.IdProducto = da.IdProducto;

        -- Actualizar PRODUCTO según el tipo de ajuste
        UPDATE p
        SET p.Stock =
            CASE 
                WHEN @TipoAjuste = 'ENTRADA' THEN p.Stock + da.Cantidad
                WHEN @TipoAjuste = 'SALIDA' THEN p.Stock - da.Cantidad
            END
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

--Elimnar tabla y SP

IF TYPE_ID(N'EDetalle_Ajuste') IS NOT NULL
    DROP TYPE EDetalle_Ajuste;
GO

DROP PROCEDURE IF EXISTS SP_RegistrarAjuste;