using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class ReporteCompra
    {
        public string FechaRegistro { get; set; }
        public string Hora { get; set; }
        public string TipoCompra { get; set; }
        public string NumeroCompra { get; set; }
        public string MontoNeto { get; set; }
        public string Descuento { get; set; }
        public string SubTotal { get; set; }
        public string IVA { get; set; }
        public string Total { get; set; }
        public string UsuarioRegistro { get; set; }
        public string NumeroIdentidadProveedor { get; set; }
        public string NombreProveedor { get; set; }
        public string CodigoProducto { get; set; }
        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string Categoria { get; set; }
        public string PrecioCompra { get; set; }
        public string PrecioVenta { get; set; }
        public string Cantidad { get; set; }
        public string SubTotalProductos { get; set; }
    }
}
