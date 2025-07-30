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
    public class CapaNegocio_Compra
    {
        private CapaDatos_Compras objcd_Compra = new CapaDatos_Compras();

        public int ObtenerConsecutivo()
        {
            return objcd_Compra.ObtenerConsecutivo();
        }

        public bool Registrar(Compra obj,DataTable DetalleCompra, out string Mensaje)
        {
                return objcd_Compra.Registrar(obj, DetalleCompra, out Mensaje);
        }

        public Compra ObtenerCompra(string numero) 
        {
            Compra oCompra = objcd_Compra.ObtenerCompra(numero);

            if (oCompra != null && oCompra.IdCompra != 0)
            {
                List<DetalleCompra> oDetalleCompra = objcd_Compra.ObtenerDetalleCompra(oCompra.IdCompra);
                oCompra.oDetalleCompra = oDetalleCompra;
            }
            return oCompra;
        }
    }
}
