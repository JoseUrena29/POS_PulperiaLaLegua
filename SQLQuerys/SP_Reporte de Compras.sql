use DB_POSPulperiaLaLegua

----- PROCEDIMIENTO PARA REPORTES DE COMPRAS -----

select 
CONVERT(char(10),c.FechaRegistro,103)[FechaRegistro],c.TipoCompra[TipoCompra],c.NumeroCompra[NumeroCompra],c.MontoNeto,c.Descuento,c.Subtotal[SubTotal],c.IVA,c.Total,
u.NombreCompleto[UsuarioRegistro],
pr.NumeroIdentidad[NumeroIdentidadProveedor],pr.NombreComercial[NombreProveedor],
p.Codigo[CodigoProducto],p.Nombre[NombreProducto],p.Descripcion[DescripcionProducto],
ca.Descripcion[Categoria],
dc.PrecioCompra,dc.PrecioVenta,dc.Cantidad,dc.MontoTotal[SubTotalProductos]
from COMPRA c
inner join USUARIO u on u.IdUsuario = c.IdUsuario
inner join PROVEEDOR pr on pr.IdProveedor = c.IdProveedor
inner join DETALLE_COMPRA dc on dc.IdCompra = c.IdCompra
inner join PRODUCTO p on p.IdProducto = dc.IdProducto
inner join CATEGORIA ca on ca.IdCategoria = p.IdCategoria
where CONVERT(date,c.FechaRegistro) between '01/07/2025' and '30/07/2025'
and pr.IdProveedor = 1


CREATE PROCEDURE SP_ReporteCompras(
	@FechaInicio varchar(10),
	@FechaFin varchar(10),
	@IdProveedor int
)
as
begin

SET DATEFORMAT dmy;
select 
CONVERT(char(10),c.FechaRegistro,103)[FechaRegistro],c.TipoCompra[TipoCompra],c.NumeroCompra[NumeroCompra],c.MontoNeto,c.Descuento,c.Subtotal[SubTotal],c.IVA,c.Total,
u.NombreCompleto[UsuarioRegistro],
pr.NumeroIdentidad[NumeroIdentidadProveedor],pr.NombreComercial[NombreProveedor],
p.Codigo[CodigoProducto],p.Nombre[NombreProducto],p.Descripcion[DescripcionProducto],
ca.Descripcion[Categoria],
dc.PrecioCompra,dc.PrecioVenta,dc.Cantidad,dc.MontoTotal[SubTotalProductos]
from COMPRA c
inner join USUARIO u on u.IdUsuario = c.IdUsuario
inner join PROVEEDOR pr on pr.IdProveedor = c.IdProveedor
inner join DETALLE_COMPRA dc on dc.IdCompra = c.IdCompra
inner join PRODUCTO p on p.IdProducto = dc.IdProducto
inner join CATEGORIA ca on ca.IdCategoria = p.IdCategoria
where CONVERT(date,c.FechaRegistro) between @FechaInicio and @FechaFin
and pr.IdProveedor = IIF(@IdProveedor = 0,pr.IdProveedor,@IdProveedor)
end

exec SP_ReporteCompras '01/07/2025','30/07/2025',0