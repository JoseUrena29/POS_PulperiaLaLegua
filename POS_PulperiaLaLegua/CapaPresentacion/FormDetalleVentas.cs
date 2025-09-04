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

using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

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
            txtHora.Text = "";
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
                txtHora.Text = oVenta.HoraRegistro;
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

        private void btnexportar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNumeroVenta.Text))
            {
                MessageBox.Show("Por favor seleccione una venta antes de generar el ticket.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF (*.pdf)|*.pdf", FileName = $"Venta_{txtNumeroVenta.Text}.pdf" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // Obtener datos del negocio
                        Negocio datosNegocio = new CapaNegocio_Negocio().ObtenerDatos();
                        byte[] logoBytes = new CapaNegocio_Negocio().ObtenerLogo(out bool obtenidoLogo);

                        // Documento tipo ticket
                        iTextSharp.text.Document doc = new iTextSharp.text.Document(new iTextSharp.text.Rectangle(230f, 600f), 10, 10, 10, 10);
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();

                        // Fuentes
                        var fuente = FontFactory.GetFont(FontFactory.COURIER, 8);
                        var negrita = FontFactory.GetFont(FontFactory.COURIER_BOLD, 8);

                        // Logo del negocio (si existe)
                        if (obtenidoLogo && logoBytes != null)
                        {
                            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoBytes);
                            logo.Alignment = Element.ALIGN_CENTER;
                            logo.ScaleAbsolute(50f, 50f); // Ajusta tamaño al ticket
                            doc.Add(logo);
                        }

                        // Encabezado dinámico con datos del negocio
                        Paragraph header = new Paragraph(datosNegocio.Nombre + "\n", negrita);
                        header.Alignment = Element.ALIGN_CENTER;
                        doc.Add(header);

                        Paragraph subHeader = new Paragraph(
                            $"Identificación: {datosNegocio.NumeroIdentificacion}\n" +
                            $"Dirección: {datosNegocio.Direccion}\n",
                            fuente
                        );
                        subHeader.Alignment = Element.ALIGN_CENTER;
                        doc.Add(subHeader);

                        doc.Add(new Paragraph("-------------------------------------------", fuente));

                        // Información de la venta
                        Paragraph info = new Paragraph(
                            $"Venta N°: {txtNumeroVenta.Text}\n" +
                            $"Fecha: {txtFecha.Text}\n" +
                            $"Hora: {txtHora.Text}\n" +
                            $"Cliente: {txtNombreCompletoCliente.Text}\n" +
                            $"Tipo de Pago: {txtTipoPago.Text}\n" +
                            $"Usuario: {txtUsuario.Text}\n",
                            fuente
                        );
                        doc.Add(info);

                        doc.Add(new Paragraph("-------------------------------------------", fuente));

                        // Encabezados de la tabla de productos
                        string headerProductos = string.Format("{0,-12} {1,6} {2,5} {3,10}", "Producto", "Precio", "Ctd", "Subtotal");
                        doc.Add(new Paragraph(headerProductos, negrita));
                        doc.Add(new Paragraph("-------------------------------------------", fuente));

                        // Productos
                        foreach (DataGridViewRow row in dgv_Data.Rows)
                        {
                            if (row.IsNewRow) continue;

                            string producto = row.Cells[0].Value?.ToString() ?? "";
                            string precio = row.Cells[1].Value?.ToString() ?? "0";
                            string cantidad = row.Cells[2].Value?.ToString() ?? "0";
                            string subtotal = row.Cells[3].Value?.ToString() ?? "0";

                            // Limitar longitud del nombre del producto
                            if (producto.Length > 12) producto = producto.Substring(0, 12);

                            string line = string.Format("{0,-12} {1,6} {2,5} {3,10}", producto, precio, cantidad, subtotal);
                            doc.Add(new Paragraph(line, fuente));
                        }

                        doc.Add(new Paragraph("-------------------------------------------", fuente));

                        // Totales alineados a la derecha con colón
                        Paragraph totals = new Paragraph(
                            string.Format("Monto Neto:      ₡{0}\nIVA:             ₡{1}\nTotal:           ₡{2}\nMonto Pagado:    ₡{3}\nCambio:          ₡{4}\n",
                            txtMontoNeto.Text, txtIVA.Text, txtTotal.Text, txtMontoPago.Text, txtMontoCambio.Text),
                            fuente
                        );
                        totals.Alignment = Element.ALIGN_RIGHT;
                        doc.Add(totals);

                        doc.Add(new Paragraph("-------------------------------------------", fuente));

                        // Pie de página
                        Paragraph footer = new Paragraph("¡Gracias por su compra!\nVuelva pronto", negrita);
                        footer.Alignment = Element.ALIGN_CENTER;
                        doc.Add(footer);

                        doc.Close();

                        MessageBox.Show("PDF tipo ticket generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
