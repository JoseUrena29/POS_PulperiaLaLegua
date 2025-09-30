use DB_POSPulperiaLaLegua

----- PROCEDIMIENTO PARA REPORTES DE AJUSTES -----

SELECT 
    CONVERT(char(10), a.FechaRegistro, 103) AS [FechaRegistro],
    CONVERT(char(8), a.FechaRegistro, 108) AS [Hora],
    a.TipoAjuste AS [TipoAjuste],               
    a.NumeroAjuste AS [NumeroAjuste],         
    a.MotivoGeneral,
    a.Observaciones,
    u.NombreCompleto AS [UsuarioRegistro],
    p.Codigo AS [CodigoProducto],
    p.Nombre AS [NombreProducto],
    p.Descripcion AS [DescripcionProducto],
    ca.Descripcion AS [Categoria],
    da.StockAnterior,
    da.Cantidad AS [CantidadAjuste],
    da.StockNuevo
FROM AJUSTE a
INNER JOIN USUARIO u ON u.IdUsuario = a.IdUsuario
INNER JOIN DETALLE_AJUSTE da ON da.IdAjuste = a.IdAjuste
INNER JOIN PRODUCTO p ON p.IdProducto = da.IdProducto
INNER JOIN CATEGORIA ca ON ca.IdCategoria = p.IdCategoria
WHERE CONVERT(date, a.FechaRegistro) BETWEEN '2025-09-01' AND '2025-09-30';


--PROCEDIMIENTO PARA REPORTES DE AJUSTES

CREATE PROCEDURE SP_ReporteAjustes
(
    @fechainicio VARCHAR(10),
    @fechafin    VARCHAR(10)
)
AS
BEGIN
    SET DATEFORMAT dmy;

    SELECT 
        CONVERT(CHAR(10), a.FechaRegistro, 103) AS [FechaRegistro],
        CONVERT(CHAR(8), a.FechaRegistro, 108)  AS [Hora],
        a.TipoAjuste       AS [TipoAjuste],
        a.NumeroAjuste     AS [NumeroAjuste],
        a.MotivoGeneral,
        a.Observaciones,
        u.NombreCompleto   AS [UsuarioRegistro],
        p.Codigo           AS [CodigoProducto],
        p.Nombre           AS [NombreProducto],
        p.Descripcion      AS [DescripcionProducto],
        ca.Descripcion     AS [Categoria],
        da.StockAnterior,
        da.Cantidad        AS [CantidadAjuste],
        da.StockNuevo
    FROM AJUSTE a
    INNER JOIN USUARIO u        ON u.IdUsuario = a.IdUsuario
    INNER JOIN DETALLE_AJUSTE da ON da.IdAjuste = a.IdAjuste
    INNER JOIN PRODUCTO p       ON p.IdProducto = da.IdProducto
    INNER JOIN CATEGORIA ca     ON ca.IdCategoria = p.IdCategoria
    WHERE CONVERT(DATE, a.FechaRegistro) 
          BETWEEN @fechainicio AND @fechafin;
END

exec SP_ReporteAjustes '01/09/2025','30/09/2025'