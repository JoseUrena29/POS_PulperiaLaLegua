using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Ajuste
    {
        public int IdAjuste { get; set; }
        public Usuario oUsuario { get; set; }
        public List<DetalleAjuste> oDetalleAjuste { get; set; }
        public string TipoAjuste { get; set; }
        public string NumeroAjuste { get; set; }
        public string MotivoGeneral { get; set; }
        public string Observaciones { get; set; }
        public string FechaRegistro { get; set; }
        public string HoraRegistro { get; set; }
    }
}
