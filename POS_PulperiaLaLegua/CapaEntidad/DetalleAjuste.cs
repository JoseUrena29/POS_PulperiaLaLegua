using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class DetalleAjuste
    {
        public int IdDetalleAjuste { get; set; }
        public Ajuste oAjuste { get; set; }
        public Producto oProducto { get; set; }
        public int StockAnterior { get; set; }
        public int StockNuevo { get; set; }
        public int Cantidad { get; set; }
        public string FechaRegistro { get; set; }
    }
}
