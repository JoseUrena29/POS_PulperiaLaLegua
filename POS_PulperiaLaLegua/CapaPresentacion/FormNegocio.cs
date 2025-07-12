using CapaEntidad;
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
    public partial class FormNegocio : Form
    {
        public FormNegocio()
        {
            InitializeComponent();
        }

        public Image ByteToImage(byte[] imagenByte)
        {
            MemoryStream ms = new MemoryStream();
            ms.Write(imagenByte, 0, imagenByte.Length);

            Image imagen = new Bitmap(ms);
            return imagen;
        }

        private void FormNegocio_Load(object sender, EventArgs e)
        {
            bool obtenido = true;
            byte[] bytesimagen = new CapaNegocio_Negocio().ObtenerLogo(out obtenido);

            if (obtenido)
                picLogo.Image = ByteToImage(bytesimagen);

            Negocio datos = new CapaNegocio_Negocio().ObtenerDatos();
            txtNombre.Text = datos.Nombre;
            txtNumeroIdentificacion.Text = datos.NumeroIdentificacion;
            txtDireccion.Text = datos.Direccion;

        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            String mensaje = String.Empty;

            OpenFileDialog oOpenFileDialog = new OpenFileDialog();
            oOpenFileDialog.FileName = "Files|*.jpg;*.jpeg;*.png";

            if(oOpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                byte[] byteimagen = File.ReadAllBytes(oOpenFileDialog.FileName);
                bool respuesta = new CapaNegocio_Negocio().ActualizarLogo(byteimagen, out mensaje);

                if(respuesta)
                    picLogo.Image = ByteToImage(byteimagen);
                else
                    MessageBox.Show(mensaje, "Mensaje",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }


        }

        private void btnGuardarCambios_Click(object sender, EventArgs e)
        {
            String mensaje = String.Empty;

            Negocio obj = new Negocio() 
            {
                Nombre = txtNombre.Text,
                NumeroIdentificacion = txtNumeroIdentificacion.Text,
                Direccion = txtDireccion.Text
            };

            bool respuesta = new CapaNegocio_Negocio().GuardarDatos(obj, out mensaje);

            if(respuesta)
                MessageBox.Show("¡Cambios guardados exitosamente!", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Error al guardar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
