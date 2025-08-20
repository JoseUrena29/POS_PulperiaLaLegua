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
    public partial class FormDetalleVentas : Form
    {
        public FormDetalleVentas()
        {
            InitializeComponent();
        }

        private void FormDetalleVentas_Load(object sender, EventArgs e)
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

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtNumeroVenta.Text = "";
            txtBusqueda.Text = "";
            txtFecha.Text = "";
            txtTipoPago.Text = "";
            txtUsuario.Text = "";
            txtNumeroIdentidad.Text = "";
            txtNombreCompletoCliente.Text = "";

            dgv_Data.Rows.Clear();

            CultureInfo crCulture = new CultureInfo("es-CR");
            txtMontoNeto.Text = 0m.ToString("C", crCulture);
            txtIVA.Text = 0m.ToString("C", crCulture);
            txtTotal.Text = 0m.ToString("C", crCulture);
            txtMontoPago.Text = 0m.ToString("C", crCulture);
            txtMontoCambio.Text = 0m.ToString("C", crCulture);
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Venta oVenta = new CapaNegocio_Venta().ObtenerVenta(txtBusqueda.Text);

            if (oVenta != null && oVenta.IdVenta != 0)
            {
                txtNumeroVenta.Text = oVenta.NumeroVenta;
                txtFecha.Text = oVenta.FechaRegistro;
                txtTipoPago.Text = oVenta.TipoPago;
                txtUsuario.Text = oVenta.oUsuario?.NombreCompleto ?? "";
                txtNumeroIdentidad.Text = oVenta.oCliente?.NumeroIdentidad ?? "";
                txtNombreCompletoCliente.Text = oVenta.oCliente?.NombreCompleto ?? "";

                dgv_Data.Rows.Clear();
                foreach (DetalleVenta dv in oVenta.oDetalleVenta)
                {
                    dgv_Data.Rows.Add(new object[]
                    {
                        dv.oProducto.Nombre,
                        dv.PrecioVenta.ToString("C", new CultureInfo("es-CR")),
                        dv.Cantidad,
                        dv.SubTotal.ToString("C", new CultureInfo("es-CR"))
                    });
                }

                var culture = new System.Globalization.CultureInfo("es-CR");
                txtMontoNeto.Text = $"₡ {oVenta.MontoNeto.ToString("N2", culture)}";
                txtIVA.Text = $"₡ {oVenta.IVA.ToString("N2", culture)}";
                txtTotal.Text = $"₡ {oVenta.Total.ToString("N2", culture)}";
                txtMontoPago.Text = $"₡ {oVenta.MontoPago.ToString("N2", culture)}";
                txtMontoCambio.Text = $"₡ {oVenta.MontoCambio.ToString("N2", culture)}";
            }
            else
            {
                MessageBox.Show("No se encontró la venta.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
