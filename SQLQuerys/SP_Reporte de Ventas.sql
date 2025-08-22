use DB_POSPulperiaLaLegua

----- PROCEDIMIENTO PARA REPORTES DE VENTAS -----

select 
CONVERT(char(10),v.FechaRegistro,103)[FechaRegistro],v.TipoPago[TipoPago],v.NumeroVenta[NumeroVenta],v.MontoNeto,v.Descuento,v.Subtotal[SubTotal],v.IVA,v.Total,
u.NombreCompleto[UsuarioRegistro],
c.NumeroIdentidad[NumeroIdentidadCliente],c.NombreCompleto[NombreCliente],
p.Codigo[CodigoProducto],p.Nombre[NombreProducto],p.Descripcion[DescripcionProducto],
ca.Descripcion[Categoria],
dv.PrecioVenta,dv.Cantidad,dv.SubTotal[SubTotalProductos]
from VENTA v
inner join USUARIO u on u.IdUsuario = v.IdUsuario
inner join CLIENTE c on c.IdCliente = v.IdCliente
inner join DETALLE_VENTA dv on dv.IdVenta = v.IdVenta
inner join PRODUCTO p on p.IdProducto = dv.IdProducto
inner join CATEGORIA ca on ca.IdCategoria = p.IdCategoria
where CONVERT(date,c.FechaRegistro) between '01/07/2025' and '30/07/2025'


CREATE PROCEDURE SP_ReporteVentas(
	@fechainicio varchar(10),
	@fechafin varchar(10)
)
as
begin

SET DATEFORMAT dmy;
select 
CONVERT(char(10),v.FechaRegistro,103)[FechaRegistro],v.TipoPago[TipoPago],v.NumeroVenta[NumeroVenta],v.MontoNeto,v.Descuento,v.Subtotal[SubTotal],v.IVA,v.Total,
u.NombreCompleto[UsuarioRegistro],
c.NumeroIdentidad[NumeroIdentidadCliente],c.NombreCompleto[NombreCliente],
p.Codigo[CodigoProducto],p.Nombre[NombreProducto],p.Descripcion[DescripcionProducto],
ca.Descripcion[Categoria],
dv.PrecioVenta,dv.Cantidad,dv.SubTotal[SubTotalProductos]
from VENTA v
inner join USUARIO u on u.IdUsuario = v.IdUsuario
inner join CLIENTE c on c.IdCliente = v.IdCliente
inner join DETALLE_VENTA dv on dv.IdVenta = v.IdVenta
inner join PRODUCTO p on p.IdProducto = dv.IdProducto
inner join CATEGORIA ca on ca.IdCategoria = p.IdCategoria
where CONVERT(date,v.FechaRegistro) between @fechainicio and @fechafin
end

exec SP_ReporteVentas '01/07/2025','30/08/2025'