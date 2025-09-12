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
    public class CapaNegocio_Ajuste
    {
        private CapaDatos_Ajuste objcd_Ajuste = new CapaDatos_Ajuste();

        public int ObtenerConsecutivo()
        {
            return objcd_Ajuste.ObtenerConsecutivo();
        }

        public bool Registrar(Ajuste obj, DataTable DetalleAjuste, out string Mensaje)
        {
            return objcd_Ajuste.Registrar(obj, DetalleAjuste, out Mensaje);
        }

        public Ajuste ObtenerAjuste(string numero)
        {
            Ajuste oAjuste = objcd_Ajuste.ObtenerAjuste(numero);

            if (oAjuste != null && oAjuste.IdAjuste != 0)
            {
                List<DetalleAjuste> oDetalleAjuste = objcd_Ajuste.ObtenerDetalleAjuste(oAjuste.IdAjuste);
                oAjuste.oDetalleAjuste = oDetalleAjuste;
            }
            return oAjuste;
        }
    }
}
