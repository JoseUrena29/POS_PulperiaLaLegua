using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
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
                txtHora.Text = oCompra.HoraRegistro;
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
            if (string.IsNullOrEmpty(txtNumeroCompra.Text))
            {
                MessageBox.Show("Por favor busque una compra antes de generar el PDF.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog()
                {
                    Filter = "PDF (*.pdf)|*.pdf",
                    FileName = $"Compra_{txtNumeroCompra.Text}.pdf"
                })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        // Obtener datos del negocio
                        Negocio datosNegocio = new CapaNegocio_Negocio().ObtenerDatos();
                        byte[] logoBytes = new CapaNegocio_Negocio().ObtenerLogo(out bool obtenidoLogo);

                        // Documento tipo ticket
                        iTextSharp.text.Document doc = new iTextSharp.text.Document(
                            new iTextSharp.text.Rectangle(230f, 600f), 10, 10, 10, 10);
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();

                        // Fuentes
                        var fuente = FontFactory.GetFont(FontFactory.COURIER, 8);
                        var negrita = FontFactory.GetFont(FontFactory.COURIER_BOLD, 8);

                        // Logo del negocio
                        if (obtenidoLogo && logoBytes != null)
                        {
                            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoBytes);
                            logo.Alignment = Element.ALIGN_CENTER;
                            logo.ScaleAbsolute(50f, 50f);
                            doc.Add(logo);
                        }

                        // Encabezado con datos del negocio
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

                        // Información de la compra
                        Paragraph info = new Paragraph(
                            $"Compra N°: {txtNumeroCompra.Text}\n" +
                            $"Fecha: {txtFecha.Text}\n" +
                            $"Hora: {txtHora.Text}\n" +
                            $"Tipo de Compra: {txtTipoCompra.Text}\n" +
                            $"Proveedor: {txtNombreComercial.Text}\n" +
                            $"Identificación: {txtNumeroIdentidadProveedor.Text}\n" +
                            $"Usuario: {txtUsuario.Text}\n",
                            fuente
                        );
                        doc.Add(info);

                        doc.Add(new Paragraph("-------------------------------------------", fuente));

                        // Encabezados de la tabla de productos
                        string headerProductos = string.Format("{0,-12} {1,6} {2,5} {3,10}",
                            "Producto", "Precio", "Ctd", "Subtotal");
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

                            if (producto.Length > 12) producto = producto.Substring(0, 12);

                            string line = string.Format("{0,-12} {1,6} {2,5} {3,10}",
                                producto, precio, cantidad, subtotal);
                            doc.Add(new Paragraph(line, fuente));
                        }

                        doc.Add(new Paragraph("-------------------------------------------", fuente));

                        // Totales
                        Paragraph totals = new Paragraph(
                            string.Format("Monto Neto:      {0}\nIVA:             {1}\nTotal:           {2}\n",
                            txtMontoNeto.Text, txtIVA.Text, txtTotal.Text),
                            fuente
                        );
                        totals.Alignment = Element.ALIGN_RIGHT;
                        doc.Add(totals);

                        doc.Add(new Paragraph("-------------------------------------------", fuente));

                        // Pie de página
                        Paragraph footer = new Paragraph("¡Registro de Compra generado con éxito!", negrita);
                        footer.Alignment = Element.ALIGN_CENTER;
                        doc.Add(footer);

                        doc.Close();

                        MessageBox.Show("PDF de la compra generado correctamente.",
                            "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar PDF: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtNumeroCompra.Text = "";
            txtBusqueda.Text = "";
            txtFecha.Text = "";
            txtHora.Text = "";
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
