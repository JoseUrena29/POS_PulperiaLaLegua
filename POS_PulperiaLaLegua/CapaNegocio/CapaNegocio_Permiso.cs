using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CapaNegocio_Permiso
    {
        private CapaDatos_Permiso objcd_Permiso = new CapaDatos_Permiso();

        public List<Permiso> Listar(int IdUsuario)
        {
            return objcd_Permiso.Listar(IdUsuario);
        }
    }
}
