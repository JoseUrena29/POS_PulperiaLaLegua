using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CapaNegocio_Venta
    {
        private CapaDatos_Ventas objcd_Venta = new CapaDatos_Ventas();

        public bool RestarStock(int IdProducto, int cantidad)
        {
            return objcd_Venta.RestarStock(IdProducto, cantidad);
        }

        public bool SumarStock(int IdProducto, int cantidad)
        {
            return objcd_Venta.SumarStock(IdProducto, cantidad);
        }

        public int ObtenerConsecutivo()
        {
            return objcd_Venta.ObtenerConsecutivo();
        }

        public bool Registrar(Venta obj, DataTable DetalleVenta, out string Mensaje)
        {
            return objcd_Venta.Registrar(obj, DetalleVenta, out Mensaje);
        }

        /*public Venta ObtenerVenta(string numero)
        {
            Venta oVenta = objcd_Venta.ObtenerVenta(numero);

            if (oVenta != null && oVenta.IdVenta != 0)
            {
                List<DetalleVenta> oDetalleVenta = objcd_Venta.ObtenerDetalleVentaa(oVenta.IdVenta);
                oVenta.oDetalleVenta = oDetalleVenta;
            }
            return oVenta;
        }*/

    }
}
