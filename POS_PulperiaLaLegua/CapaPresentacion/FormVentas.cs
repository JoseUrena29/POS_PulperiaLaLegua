using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
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
    public partial class FormVentas : Form
    {
        private Usuario _Usuario;
        public FormVentas(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            comboxTipoPago.Items.Add(new OpcionCombo() { Valor = "Efectivo", Texto = "Efectivo" });
            comboxTipoPago.Items.Add(new OpcionCombo() { Valor = "Tarjeta", Texto = "Tarjeta" });
            comboxTipoPago.Items.Add(new OpcionCombo() { Valor = "Sinpe", Texto = "Sinpe" });
            comboxTipoPago.Items.Add(new OpcionCombo() { Valor = "Otro", Texto = "Otro" });
            comboxTipoPago.DisplayMember = "Texto";
            comboxTipoPago.ValueMember = "Valor";
            comboxTipoPago.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtIdCliente.Text = "0";
            txtIdProducto.Text = "0";
            txtMontoNeto.Text =
            txtMontoNeto.Text = "";
            txtDescuento.Text = "";
            txtSubTotal.Text = "";
            txtIVA.Text = "";
            txtTotal.Text = "";
            txtPago.Text = "";
            txtCambio.Text = "";
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            using (var modal = new Modal_Clientes())
            {
                var result = modal.ShowDialog();

                if (result == DialogResult.OK)
                {
                    txtIdCliente.Text = modal._Cliente.IdCliente.ToString();
                    txtNumeroIdentidad.Text = modal._Cliente.NumeroIdentidad;
                    txtNombreCliente.Text = modal._Cliente.NombreCompleto;
                }
                else
                {
                    txtNumeroIdentidad.Select();
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
                    txtPrecio.Text = modal._Producto.PrecioVenta.ToString("0.00");
                    txtStock.Text = modal._Producto.Stock.ToString();
                    txtCantidad.Select();
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
                    txtPrecio.Text = "0";
                    txtStock.Text = "0";
                    MessageBox.Show("Producto no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!oProducto.Estado)
                {
                    txtCodigoProducto.BackColor = System.Drawing.Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtNombreProducto.Text = "";
                    txtPrecio.Text = "0";
                    txtStock.Text = "0";
                    MessageBox.Show("El producto está inactivo.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtCodigoProducto.BackColor = System.Drawing.Color.Honeydew;
                    txtIdProducto.Text = oProducto.IdProducto.ToString();
                    txtNombreProducto.Text = oProducto.Nombre;
                    txtPrecio.Text = oProducto.PrecioVenta.ToString();
                    txtStock.Text = oProducto.Stock.ToString();
                    txtCantidad.Select();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            decimal precio = 0;
            bool productoExiste = false;

            if (int.Parse(txtIdProducto.Text) == 0)
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out precio))
            {
                MessageBox.Show("Precio - Formato moneda incorrecto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Convert.ToInt32(txtStock.Text) < Convert.ToInt32(txtCantidad.Value.ToString()))
            {
                MessageBox.Show("La cantidad no puede ser mayor al stock", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            int cantidadNueva = (int)txtCantidad.Value;

            foreach (DataGridViewRow fila in dgv_Data.Rows)
            {
                if (fila.Cells["IdProducto"].Value.ToString() == txtIdProducto.Text)
                {
                    int cantidadActual = Convert.ToInt32(fila.Cells["Cantidad"].Value);
                    int nuevaCantidad = cantidadActual + cantidadNueva;

                    decimal nuevoSubtotal = nuevaCantidad * precio;

                    fila.Cells["Cantidad"].Value = nuevaCantidad;
                    fila.Cells["Subtotal"].Value = nuevoSubtotal.ToString("0.00");

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
                decimal subtotal = cantidadNueva * precio;

                dgv_Data.Rows.Add(new object[]
                {
            txtIdProducto.Text,
            txtNombreProducto.Text,
            precio.ToString("0.00"),
            cantidadNueva,
            subtotal.ToString("0.00"),
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
            txtPrecio.Text = "";
            txtStock.Text = "";
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
                    if (row.Cells["Cantidad"].Value != null && row.Cells["Precio"].Value != null)
                    {
                        int cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value);
                        decimal precio = Convert.ToDecimal(row.Cells["Precio"].Value);

                        decimal subtotalFila = cantidad * precio;
                        montoNeto += subtotalFila;
                    }
                }

                subtotal = montoNeto - totalDescuento;
                iva = subtotal * 0.13m;
                totalFinal = subtotal + iva;
            }

            // Mostrar resultados en los TextBox
            txtMontoNeto.Text = "₡" + montoNeto.ToString("N2");
            txtDescuento.Text = "₡" + totalDescuento.ToString("N2");
            txtSubTotal.Text = "₡" + subtotal.ToString("N2");
            txtIVA.Text = "₡" + iva.ToString("N2");
            txtTotal.Text = "₡" + totalFinal.ToString("N2");

            // Calcular cambio si hay valor en txtpago
            decimal pagoCliente = 0;
            if (decimal.TryParse(txtPago.Text, out pagoCliente))
            {
                decimal cambio = pagoCliente - totalFinal;

                // Asegurar que no se muestren cambios negativos (opcional)
                if (cambio < 0)
                {
                    txtCambio.Text = "₡0.00";
                }
                else
                {
                    txtCambio.Text = "₡" + cambio.ToString("N2");
                }
            }
            else
            {
                txtCambio.Text = "₡0.00"; // Si no se ingresó pago válido
            }
        }

        private void txtPago_TextChanged_1(object sender, EventArgs e)
        {
            CalcularTotal();
        }

        private void dgv_Data_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 5)
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

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPrecio.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        private void txtPago_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                if (txtPago.Text.Trim().Length == 0 && e.KeyChar.ToString() == ".")
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

        }
    }   
}
