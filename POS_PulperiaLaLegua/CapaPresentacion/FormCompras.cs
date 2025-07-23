using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormCompras : Form
    {
        private Usuario _Usuario;
        public FormCompras(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void FormCompras_Load(object sender, EventArgs e)
        {
            comboxTipoCompra.Items.Add(new OpcionCombo() { Valor = "Factura Electrónica", Texto = "Factura Electrónica" });
            comboxTipoCompra.Items.Add(new OpcionCombo() { Valor = "Nota de Crédito", Texto = "Nota de Crédito" });
            comboxTipoCompra.Items.Add(new OpcionCombo() { Valor = "Recibo", Texto = "Recibo" });
            comboxTipoCompra.Items.Add(new OpcionCombo() { Valor = "Otro", Texto = "Otro" });
            comboxTipoCompra.DisplayMember = "Texto";
            comboxTipoCompra.ValueMember = "Valor";
            comboxTipoCompra.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtIdProveedor.Text = "0";
            txtIdProducto.Text = "0";

        }

        private void btnBuscarProveedor_Click(object sender, EventArgs e)
        {
            using (var modal = new Modal_Proveedor())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProveedor.Text = modal._Proveedor.IdProveedor.ToString();
                    txtNumeroIdentidadProveedor.Text = modal._Proveedor.NumeroIdentidad;
                    txtNombreComercial.Text = modal._Proveedor.NombreComercial;
                }
                else
                {
                    txtNumeroIdentidadProveedor.Select();
                }
            }
        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            using (var modal = new Modal_Productos())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdProducto.Text = modal._Producto.IdProducto.ToString();
                    txtCodigoProducto.Text = modal._Producto.Codigo;
                    txtNombreProducto.Text = modal._Producto.Nombre;
                    txtPrecioCompra.Select();
                }
                else
                {
                    txtCodigoProducto.Select();
                }
            }
        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string codigoBuscado = txtCodigoProducto.Text.Trim().ToUpper();

                // Buscar el producto independientemente del estado
                Producto oProducto = new CapaNegocio_Producto()
                    .Listar()
                    .FirstOrDefault(p => p.Codigo.Trim().ToUpper() == codigoBuscado);

                if (oProducto == null)
                {
                    txtCodigoProducto.BackColor = System.Drawing.Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtNombreProducto.Text = "";
                    MessageBox.Show("Producto no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!oProducto.Estado)
                {
                    txtCodigoProducto.BackColor = System.Drawing.Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtNombreProducto.Text = "";
                    MessageBox.Show("El producto está inactivo.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtCodigoProducto.BackColor = System.Drawing.Color.Honeydew;
                    txtIdProducto.Text = oProducto.IdProducto.ToString();
                    txtNombreProducto.Text = oProducto.Nombre;
                    txtPrecioCompra.Select();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal precioCompra = 0;
            decimal precioVenta = 0;
            bool productoExiste = false;

            if (int.Parse(txtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtPrecioCompra.Text, out precioCompra))
            {
                MessageBox.Show("Precio Compra - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtPrecioVenta.Text, out precioVenta))
            {
                MessageBox.Show("Precio Venta - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            decimal descuentoPorcentaje = 0;
            decimal.TryParse(txtDescuento.Text, out descuentoPorcentaje); // textbox para descuento %

            int cantidadNueva = (int)txtCantidad.Value;

            foreach (DataGridViewRow fila in dgv_Data.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtIdProducto.Text)
                {
                    int cantidadActual = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    int nuevaCantidad = cantidadActual + cantidadNueva;

                    decimal montoNeto = nuevaCantidad * precioCompra;
                    decimal descuento = montoNeto * (descuentoPorcentaje / 100);
                    decimal subtotal = montoNeto - descuento;
                    decimal iva = subtotal * 0.13m;
                    decimal total = subtotal + iva;

                    fila.Cells["Cantidad"].Value = nuevaCantidad;
                    fila.Cells["MontoNeto"].Value = montoNeto.ToString("0.00");
                    fila.Cells["Descuento"].Value = descuento.ToString("0.00");
                    fila.Cells["Subtotal"].Value = subtotal.ToString("0.00");
                    fila.Cells["IVA"].Value = iva.ToString("0.00");
                    fila.Cells["Total"].Value = total.ToString("0.00");

                    productoExiste = true;
                    MessageBox.Show("Producto actualizado correctamente.", "Actualización", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CalcularTotal();
                    LimpiarProducto();
                    txtIdProducto.Select();
                    break;
                }
            }

            if (!productoExiste)
            {
                decimal montoNeto = cantidadNueva * precioCompra;
                decimal descuento = montoNeto * (descuentoPorcentaje / 100);
                decimal subtotal = montoNeto - descuento;
                decimal iva = subtotal * 0.13m;
                decimal totalLinea = subtotal + iva;

                dgv_Data.Rows.Add(new object[]
                {
            txtIdProducto.Text,
            txtNombreProducto.Text,
            precioCompra.ToString("0.00"),
            precioVenta.ToString("0.00"),
            cantidadNueva,
            montoNeto.ToString("0.00"),
            descuento.ToString("0.00"),
            subtotal.ToString("0.00"),
            iva.ToString("0.00"),
            totalLinea.ToString("0.00")
                });

                MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                CalcularTotal();
                LimpiarProducto();
                txtIdProducto.Select();
            }
        }

        private void LimpiarProducto()
        {
            txtIdProducto.Text = "0";
            txtCodigoProducto.Text = "";
            txtCodigoProducto.BackColor = System.Drawing.Color.White;
            txtNombreProducto.Text = "";
            txtPrecioCompra.Text = "";
            txtPrecioVenta.Text = "";
            txtCantidad.Value = 1;
        }
        private void CalcularTotal()
        {
            decimal montoNeto = 0;
            decimal totalDescuento = 0;
            decimal subtotal = 0;
            decimal iva = 0;
            decimal totalFinal = 0;

            if (dgv_Data.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv_Data.Rows)
                {
                    int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                    decimal precio = Convert.ToDecimal(row.Cells["PrecioCompra"].Value);
                    decimal descuentoPorcentaje = row.Cells["Descuento"] != null && row.Cells["Descuento"].Value != null
                        ? Convert.ToDecimal(row.Cells["Descuento"].Value)
                        : 0;

                    decimal bruto = cantidad * precio;
                    decimal descuento = bruto * (descuentoPorcentaje / 100);
                    decimal subtotalFila = bruto - descuento;

                    montoNeto += bruto;
                    totalDescuento += descuento;
                    subtotal += subtotalFila;
                }

                iva = subtotal * 0.13m; // 13% de IVA
                totalFinal = subtotal + iva;
            }

            // Mostrar resultados en los TextBox
            txtMontoNeto.Text = "₡" + montoNeto.ToString("0.00");
            txtDescuento.Text = totalDescuento.ToString("0.00");
            txtSubTotal.Text = "₡" + subtotal.ToString("0.00");
            txtIVA.Text = "₡" + iva.ToString("0.00");
            txtTotal.Text = "₡" + totalFinal.ToString("0.00");
        }

        private void dgv_Data_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 10)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                int iconSize = Math.Min(e.CellBounds.Width, e.CellBounds.Height) - 5;

                var x = e.CellBounds.Left + (e.CellBounds.Width - iconSize) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - iconSize) / 2;

                e.Graphics.DrawImage(Properties.Resources.delete32, new Rectangle(x, y, iconSize, iconSize));
                e.Handled = true;
            }
        }

        private void dgv_Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Data.Columns[e.ColumnIndex].Name == "btneliminar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    // Obtener el nombre del producto de la fila
                    string nombreProducto = dgv_Data.Rows[indice].Cells["Producto"].Value?.ToString() ?? "el producto";

                    // Confirmación antes de eliminar, mostrando el nombre
                    DialogResult resultado = MessageBox.Show(
                        $"¿Está seguro de que desea eliminar el producto {nombreProducto}?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        dgv_Data.Rows.RemoveAt(indice);
                        CalcularTotal();
                    }
                }
            }
        }

        private void txtPrecioCompra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar)) 
            { 
                e.Handled = false;
            }
            else
            {
                if(txtPrecioCompra.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled= true;
                }
                else
                {
                    if(Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled= false;
                    }
                    else
                    {
                        e.Handled= true;
                    }
                }
            }

        }

        private void txtPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecioVenta.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
                {
                    e.Handled = true;
                }
                else
                {
                    if (Char.IsControl(e.KeyChar) || e.KeyChar.ToString() == ".")
                    {
                        e.Handled = false;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
            }
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtIdProveedor.Text) == 0)
            {
                MessageBox.Show("Por favor, seleccione un proveedor antes de continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgv_Data.Rows.Count < 1)
            {
                MessageBox.Show("Debe agregar al menos un producto a la compra.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable detalle_compra = new DataTable();

            detalle_compra.Columns.Add("IdProducto", typeof(int));
            detalle_compra.Columns.Add("PrecioCompra", typeof(decimal));
            detalle_compra.Columns.Add("PrecioVenta", typeof(decimal));
            detalle_compra.Columns.Add("Cantidad", typeof(decimal));
            detalle_compra.Columns.Add("MontoTotal", typeof(decimal));

            foreach (DataGridViewRow row in dgv_Data.Rows)
            {
                detalle_compra.Rows.Add(
                    new object[]
                    {
                        Convert.ToInt32(row.Cells["IdProducto"].Value.ToString()),
                        row.Cells["PrecioCompra"].Value.ToString(),
                        row.Cells["PrecioVenta"].Value.ToString(),
                        row.Cells["Cantidad"].Value.ToString(),
                        row.Cells["MontoNeto"].Value.ToString()
                    });
            }

            int IdConsecutivo = new CapaNegocio_Compra().ObtenerConsecutivo();
            string numerocompra = string.Format("{0:00000}",IdConsecutivo);

            // Limpieza previa del formato antes de convertir
            string montoNetoTexto = txtMontoNeto.Text.Replace("₡", "").Trim();
            string subtotalTexto = txtSubTotal.Text.Replace("₡", "").Trim();
            string ivaTexto = txtIVA.Text.Replace("₡", "").Trim();
            string totalTexto = txtTotal.Text.Replace("₡", "").Trim();

            if (!decimal.TryParse(montoNetoTexto, out decimal montoNeto))
            {
                MessageBox.Show("El campo Monto Neto contiene un valor inválido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(txtDescuento.Text, out decimal descuento))
            {
                MessageBox.Show("El campo Descuento contiene un valor inválido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(subtotalTexto, out decimal subtotal))
            {
                MessageBox.Show("El campo Subtotal contiene un valor inválido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(ivaTexto, out decimal iva))
            {
                MessageBox.Show("El campo IVA contiene un valor inválido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!decimal.TryParse(totalTexto, out decimal total))
            {
                MessageBox.Show("El campo Total contiene un valor inválido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Compra ocompra = new Compra()
            {
                oUsuario = new Usuario() { IdUsuario = _Usuario.IdUsuario },
                oProveedor = new Proveedor() { IdProveedor = Convert.ToInt32(txtIdProveedor.Text) },
                TipoCompra = ((OpcionCombo)comboxTipoCompra.SelectedItem).Texto,
                NumeroCompra = numerocompra,
                MontoNeto = montoNeto,
                Descuento = descuento,
                Subtotal = subtotal,
                IVA = iva,
                Total = total
            };

            string mensaje = string.Empty;
            bool respuesta = new CapaNegocio_Compra().Registrar(ocompra,detalle_compra,out mensaje);

            if(respuesta)
            {
                var result = MessageBox.Show($"¡Compra registrada con éxito!\n\nNúmero de compra: {numerocompra}\n\n¿Desea copiarlo al portapapeles?","Registro Exitoso",
                MessageBoxButtons.YesNo,MessageBoxIcon.Information);


                if (result == DialogResult.Yes)
                    Clipboard.SetText(numerocompra);

                txtIdProducto.Text = "0";
                txtNumeroIdentidadProveedor.Text = "";
                txtNombreComercial.Text = "";
                dgv_Data.Rows.Clear();
                CalcularTotal();
            }
            else
            {
                MessageBox.Show(mensaje,"Mensaje",MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
