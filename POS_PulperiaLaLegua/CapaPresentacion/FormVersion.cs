using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormVersion : Form
    {
        public FormVersion()
        {
            InitializeComponent();
        }

        private Image ByteToImage(byte[] imagenByte)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imagenByte, 0, imagenByte.Length);
            ms.Position = 0; // importante: reiniciar posición del stream
            Image imagen = new Bitmap(ms);
            return imagen;
        }

        private void FormVersion_Load(object sender, EventArgs e)
        {
            txtTitulo.Text = "Sistema POS – Pulpería La Legua";
            txtVersion.Text = "Versión: " + Application.ProductVersion + " (Octubre 2025)";
            txtAutor.Text = "Desarrollado por: Jose Ureña Aguilar - Proyecto Universitario – Ingeniería Informática";

            txtDescripcion.Text =
                "\r\n" +
                "Sistema de Punto de Venta desarrollado para la Pulpería La Legua.\r\n\r\n" +
                "Funciones principales:\r\n" +
                "- Registro y gestión de usuarios.\r\n" +
                "- Registro y administración de clientes.\r\n" +
                "- Control de productos y categorías.\r\n" +
                "- Gestión de proveedores.\r\n" +
                "- Registro y consulta de ventas.\r\n" +
                "- Registro y consulta de compras.\r\n" +
                "- Registro y consulta de ajustes.\r\n" +
                "- Generación de reportes administrativos.\r\n\r\n" +
                "El sistema integra periféricos como lector de código de barras para mayor eficiencia.";

            // Cargar logo desde la BD
            byte[] logoBytes = new CapaNegocio_Negocio().ObtenerLogo(out bool obtenidoLogo);

            if (obtenidoLogo && logoBytes != null && logoBytes.Length > 0)
            {
                picLogo.Image = ByteToImage(logoBytes);
                picLogo.SizeMode = PictureBoxSizeMode.Zoom;  
                picLogo.Width = 100;   
                picLogo.Height = 100;  
            }
        }
    }
}
