using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CapaNegocio_Producto

    {
        private CapaDatos_Producto objcd_Producto = new CapaDatos_Producto();

        public List<Producto> Listar()
        {
            return objcd_Producto.Listar();
        }

        public int Registrar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Codigo == "")
            {
                Mensaje += "Por favor digitar el código del producto";
            }

            if (obj.Nombre == "")
            {
                Mensaje += "Por favor digitar el nombre del producto";
            }

            if (obj.Descripcion == "")
            {
                Mensaje += "Por favor digitar la descripción del producto";
            }

            if (obj.PrecioCompra < 0)
            {
                Mensaje += "El Precio de Compra no puede ser negativo.\n";
            }

            if (obj.PrecioVenta < 0)
            {
                Mensaje += "El Precio de Venta no puede ser negativo.\n";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }

            else
            {
                return objcd_Producto.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Codigo == "")
            {
                Mensaje += "Por favor digitar el Código del Producto";
            }

            if (obj.Nombre == "")
            {
                Mensaje += "Por favor digitar el Nombre del Producto";
            }

            if (obj.Descripcion == "")
            {
                Mensaje += "Por favor digitar la Descripción del Producto";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }

            else
            {
                return objcd_Producto.Editar(obj, out Mensaje);
            }
        }

    }
}
