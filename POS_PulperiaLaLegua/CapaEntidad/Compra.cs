using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public Usuario oUsuario { get; set; }
        public Proveedor oProveedor { get; set; }
        public List<DetalleCompra> oDetalleCompra { get; set; }
        public string TipoCompra { get; set; }
        public string NumeroCompra { get; set; }
        public decimal MontoNeto { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public string FechaRegistro { get; set; }
    }
}
