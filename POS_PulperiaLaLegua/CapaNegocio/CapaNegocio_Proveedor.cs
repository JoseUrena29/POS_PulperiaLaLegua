using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CapaNegocio_Proveedor
    {
        private CapaDatos_Proveedor objcd_Proveedor = new CapaDatos_Proveedor();

        public List<Proveedor> Listar()
        {
            return objcd_Proveedor.Listar();
        }

        public int Registrar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.NumeroIdentidad == "")
            {
                Mensaje += "Por favor digitar el número de identidad del proveedor";
            }

            if (obj.NombreComercial == "")
            {
                Mensaje += "Por favor digitar el nombre comnpleto del proveedor";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Por favor digitar el correo del proveedor";
            }

            if (obj.Telefono == "")
            {
                Mensaje += "Por favor digitar el número de teléfono del proveedor";
            }

            if (obj.Direccion == "")
            {
                Mensaje += "Por favor digitar la dirección del proveedor";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }

            else
            {
                return objcd_Proveedor.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.NumeroIdentidad == "")
            {
                Mensaje += "Por favor digitar el número de identidad del proveedor";
            }

            if (obj.NombreComercial == "")
            {
                Mensaje += "Por favor digitar el nombre comnpleto del proveedor";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Por favor digitar el correo del proveedor";
            }

            if (obj.Telefono == "")
            {
                Mensaje += "Por favor digitar el número de teléfono del proveedor";
            }

            if (obj.Direccion == "")
            {
                Mensaje += "Por favor digitar la dirección del proveedor";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }

            else
            {
                return objcd_Proveedor.Editar(obj, out Mensaje);
            }
        }
    }
}
