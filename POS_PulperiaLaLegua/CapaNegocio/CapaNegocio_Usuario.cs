using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CapaNegocio_Usuario
    {
        private CapaDatos_Usuario objcd_Usuario = new CapaDatos_Usuario();

        public List<Usuario> Listar()
        {
            return objcd_Usuario.Listar();
        }

        public int Registrar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.NumeroIdentidad == "")
            {
                Mensaje += "Por favor digitar el número de identidad del usuario\n";
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje += "Por favor digitar el nombre comnpleto del usuario\n";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Por favor digitar el correo del usuario\n";
            }

            if (obj.Telefono == "")
            {
                Mensaje += "Por favor digitar el número de teléfono del usuario\n";
            }

            if (obj.Clave == "")
            {
                Mensaje += "Por favor digitar la clave del usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }

            else
            {
                return objcd_Usuario.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Usuario obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.NumeroIdentidad == "")
            {
                Mensaje += "Por favor digitar el número de identidad del usuario\n";
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje += "Por favor digitar el nombre comnpleto del usuario\n";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Por favor digitar el correo del usuario\n";
            }

            if (obj.Telefono == "")
            {
                Mensaje += "Por favor digitar el número de teléfono del usuario\n";
            }

            if (obj.Clave == "")
            {
                Mensaje += "Por favor digitar la clave del usuario\n";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }

            else
            {
                return objcd_Usuario.Editar(obj, out Mensaje);
            }
        }
    }
}
