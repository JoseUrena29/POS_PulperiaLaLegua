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
    public partial class FormAjustes : Form
    {
        public FormAjustes()
        {
            InitializeComponent();
        }

        private void FormAjustes_Load(object sender, EventArgs e)
        {
            comboxTipoAjuste.Items.Add(new OpcionCombo() { Valor = "ENTRADA", Texto = "Entrada de Inventario" });
            comboxTipoAjuste.Items.Add(new OpcionCombo() { Valor = "SALIDA", Texto = "Salida de Inventario" });
            comboxTipoAjuste.DisplayMember = "Texto";
            comboxTipoAjuste.ValueMember = "Valor";
            comboxTipoAjuste.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtIdProducto.Text = "0";
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
                    txtStock.Text = modal._Producto.Stock.ToString();
                }
                else
                {
                    txtCodigoProducto.Select();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (txtIdProducto.Text == "0" || string.IsNullOrWhiteSpace(txtCodigoProducto.Text))
            {
                MessageBox.Show("Debe seleccionar un producto", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCantidad.Text) || !int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Debe ingresar una cantidad válida", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            // Validar que no se repita el producto en el DataGridView
            foreach (DataGridViewRow row in dgv_Data.Rows)
            {
                if (row.Cells["IdProducto"].Value != null && row.Cells["IdProducto"].Value.ToString() == txtIdProducto.Text)
                {
                    MessageBox.Show("El producto ya fue agregado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    LimpiarProducto();
                    return;
                }
            }

            dgv_Data.Rows.Add(new object[]
            {
            txtIdProducto.Text,
            txtCodigoProducto.Text,
            txtNombreProducto.Text,
            txtStock.Text,
            cantidad,
            });

            MessageBox.Show("Producto agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarProducto();
        }

        private void LimpiarProducto()
        {
            txtIdProducto.Text = "0";
            txtCodigoProducto.Text = "";
            txtCodigoProducto.BackColor = System.Drawing.Color.White;
            txtNombreProducto.Text = "";
            txtStock.Text = "";
            txtCantidad.Value = 1;
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
                    }
                }
            }
        }
    }
}
