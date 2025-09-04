using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Venta
    {
        public int IdVenta { get; set; }
        public Usuario oUsuario { get; set; }
        public Cliente oCliente{ get; set; }
        public List<DetalleVenta> oDetalleVenta { get; set; }
        public string TipoPago { get; set; }
        public string NumeroVenta { get; set; }
        public decimal MontoNeto { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public decimal MontoPago { get; set; }
        public decimal MontoCambio { get; set; }
        public string FechaRegistro { get; set; }
        public string HoraRegistro { get; set; }

    }
}
