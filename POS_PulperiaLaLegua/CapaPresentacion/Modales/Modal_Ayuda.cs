using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion.Modales
{
    public partial class Modal_Ayuda : Form
    {
        public Modal_Ayuda()
        {
            InitializeComponent();

            lblDescripcion.Text =
            "Sistema POS – Pulpería La Legua\r\n" +
            "Versión 1.0 (Agosto 2025)\r\n\r\n" +
            "Desarrollado por: Jose Ureña Aguilar\r\n" +
            "Proyecto universitario – Ingeniería Informática\r\n\r\n" +
            "Descripción:\r\n" +
            "Sistema de Punto de Venta desarrollado para la Pulpería La Legua.\r\n" +
            "Sus funciones principales son:\r\n\r\n" +
            "- Registro y gestión de usuarios del sistema.\r\n" +
            "- Registro y administración de clientes.\r\n" +
            "- Control de productos y categorías.\r\n" +
            "- Gestión de proveedores.\r\n" +
            "- Registro y consulta de ventas.\r\n" +
            "- Registro y consulta de compras.\r\n" +
            "- Generación de reportes administrativos.\r\n\r\n" +
            "El sistema está diseñado para optimizar la gestión del negocio e\r\n" +
            "integrar periféricos como lector de código de barras para mayor eficiencia.\r\n";
        }
    }
}
