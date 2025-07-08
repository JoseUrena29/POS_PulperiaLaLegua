using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CapaNegocio_Cliente
    {
        private CapaDatos_Cliente objcd_Cliente = new CapaDatos_Cliente();

        public List<Cliente> Listar()
        {
            return objcd_Cliente.Listar();
        }

        public int Registrar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.NumeroIdentidad == "")
            {
                Mensaje += "Por favor digitar el número de identidad del cliente";
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje += "Por favor digitar el nombre comnpleto del cliente";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Por favor digitar el correo del cliente";
            }

            if (obj.Telefono == "")
            {
                Mensaje += "Por favor digitar el número de teléfono del cliente";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }

            else
            {
                return objcd_Cliente.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.NumeroIdentidad == "")
            {
                Mensaje += "Por favor digitar el número de identidad del cliente";
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje += "Por favor digitar el nombre comnpleto del cliente";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Por favor digitar el correo del cliente";
            }

            if (obj.Telefono == "")
            {
                Mensaje += "Por favor digitar el número de teléfono del cliente";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }

            else
            {
                return objcd_Cliente.Editar(obj, out Mensaje);
            }
        }

    }
}
