﻿using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CapaNegocio_Rol
    {
        private CapaDatos_Rol objcd_rol = new CapaDatos_Rol();

        public List<Rol> Listar()
        {
            return objcd_rol.Listar();
        }
    }
}
