using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CapaNegocio_Reporte
    {
        private CapaDatos_Reporte objcd_reporte = new CapaDatos_Reporte();

        //Reporte de Compras
        public List<ReporteCompra> Compra(string fechainicio, string fechafin, int IdProveedor)
        {
            return objcd_reporte.Compra(fechainicio,fechafin,IdProveedor);
        }

        //Reporte de Ventas
        public List<ReporteVenta> Venta(string fechainicio, string fechafin)
        {
            return objcd_reporte.Venta(fechainicio, fechafin);
        }

        //Reporte de Ajustes
        public List<ReporteAjuste> Ajuste(string fechainicio, string fechafin)
        {
            return objcd_reporte.Ajuste(fechainicio, fechafin);
        }
    }
}
