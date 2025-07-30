using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormDetalleCompras : Form
    {
        public FormDetalleCompras()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Compra oCompra = new CapaNegocio_Compra().ObtenerCompra(txtBusqueda.Text);

            if (oCompra != null && oCompra.IdCompra != 0)
            {
                txtNumeroCompra.Text = oCompra.NumeroCompra;
                txtFecha.Text = oCompra.FechaRegistro;
                txtTipoCompra.Text = oCompra.TipoCompra;
                txtUsuario.Text = oCompra.oUsuario?.NombreCompleto ?? "";
                txtNumeroIdentidadProveedor.Text = oCompra.oProveedor?.NumeroIdentidad ?? "";
                txtNombreComercial.Text = oCompra.oProveedor?.NombreComercial ?? "";

                dgv_Data.Rows.Clear();
                foreach (DetalleCompra dc in oCompra.oDetalleCompra)
                {
                    dgv_Data.Rows.Add(new object[] 
                    {
                        dc.oProducto.Nombre,
                        dc.PrecioCompra.ToString("C", new CultureInfo("es-CR")),
                        dc.Cantidad,
                        dc.MontoTotal.ToString("C", new CultureInfo("es-CR"))
                    });
                }

                var culture = new System.Globalization.CultureInfo("es-CR");
                txtMontoNeto.Text = $"₡ {oCompra.MontoNeto.ToString("N2", culture)}";
                txtIVA.Text = $"₡ {oCompra.IVA.ToString("N2", culture)}";
                txtTotal.Text = $"₡ {oCompra.Total.ToString("N2", culture)}";
            }
            else
            {
                MessageBox.Show("No se encontró la compra.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FormDetalleCompras_Load(object sender, EventArgs e)
        {
            // Botón Buscar
            btnbuscar.IconChar = IconChar.Search;
            btnbuscar.IconColor = Color.Black;
            btnbuscar.IconSize = 18;
            btnbuscar.Text = "Buscar";
            btnbuscar.TextImageRelation = TextImageRelation.ImageBeforeText;

            // Botón Exportar a PDF
            btnexportar.IconChar = IconChar.FilePdf;
            btnexportar.IconColor = Color.Red;
            btnexportar.IconSize = 19;
            btnexportar.Text = "Exportar PDF";
            btnexportar.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnexportar.Cursor = Cursors.Hand;
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtNumeroCompra.Text = "";
            txtBusqueda.Text = "";
            txtFecha.Text = "";
            txtTipoCompra.Text = "";
            txtUsuario.Text = "";
            txtNumeroIdentidadProveedor.Text = "";
            txtNombreComercial.Text = "";

            dgv_Data.Rows.Clear();

            CultureInfo crCulture = new CultureInfo("es-CR");
            txtMontoNeto.Text = 0m.ToString("C", crCulture);
            txtIVA.Text = 0m.ToString("C", crCulture);
            txtTotal.Text = 0m.ToString("C", crCulture);
        }
    }
}
