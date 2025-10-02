using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
using CapaPresentacion.Utilidades;
using FontAwesome.Sharp;
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
        private Usuario _Usuario;

        public FormAjustes(Usuario oUsuario = null)
        {
            _Usuario = oUsuario;
            InitializeComponent();
        }

        private void FormAjustes_Load(object sender, EventArgs e)
        {
            // Botón Buscar
            btnBuscarProducto.IconChar = IconChar.Search;
            btnBuscarProducto.IconColor = Color.Black;
            btnBuscarProducto.IconSize = 18;
            btnBuscarProducto.TextImageRelation = TextImageRelation.ImageBeforeText;

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

            // Calcular StockNuevo según tipo de ajuste
            int stockAnterior = Convert.ToInt32(txtStock.Text);
            int stockNuevo = stockAnterior;

            if (((OpcionCombo)comboxTipoAjuste.SelectedItem).Valor.ToString() == "ENTRADA")
                stockNuevo += cantidad;
            else
            {
                stockNuevo -= cantidad;
                if (stockNuevo < 0)
                {
                    MessageBox.Show("La cantidad excede el stock disponible", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Agregar fila al DataGridView incluyendo StockNuevo
            dgv_Data.Rows.Add(new object[]
            {
            txtIdProducto.Text,
            txtCodigoProducto.Text,
            txtNombreProducto.Text,
            stockAnterior,
            cantidad,
            stockNuevo
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

            if (e.ColumnIndex == 6)
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

        private void btnRegistrar_Click(object sender, EventArgs e)
        {

            // Validar que haya al menos un producto
            if (dgv_Data.Rows.Count < 1)
            {
                MessageBox.Show("Debe agregar al menos un producto al ajuste de inventario.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que se haya ingresado un motivo
            if (string.IsNullOrWhiteSpace(txtMotivoGeneral.Text))
            {
                MessageBox.Show("Debe ingresar un motivo para el ajuste.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotivoGeneral.Focus();
                return;
            }

            // Validar que se hayan ingresado observaciones
            if (string.IsNullOrWhiteSpace(txtObservaciones.Text))
            {
                MessageBox.Show("Debe ingresar observaciones para el ajuste.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtObservaciones.Focus();
                return;
            }

            DataTable detalle_ajuste = new DataTable();

            detalle_ajuste.Columns.Add("IdProducto", typeof(int));
            detalle_ajuste.Columns.Add("Cantidad", typeof(int));

            foreach (DataGridViewRow row in dgv_Data.Rows)
            {
                detalle_ajuste.Rows.Add(
                    new object[]
                    {
                        Convert.ToInt32(row.Cells["IdProducto"].Value.ToString()),
                        Convert.ToInt32(row.Cells["Cantidad"].Value.ToString()),
                    });
            }

            int IdConsecutivo = new CapaNegocio_Ajuste().ObtenerConsecutivo();
            string numeroajuste = string.Format("{0:00000}", IdConsecutivo);

            Ajuste oajuste = new Ajuste()
            {
                oUsuario = new Usuario() { IdUsuario = _Usuario.IdUsuario },
                TipoAjuste = ((OpcionCombo)comboxTipoAjuste.SelectedItem).Valor.ToString(),
                NumeroAjuste = numeroajuste,
                MotivoGeneral = txtMotivoGeneral.Text,
                Observaciones = txtObservaciones.Text,
            };

            string mensaje = string.Empty;
            bool respuesta = new CapaNegocio_Ajuste().Registrar(oajuste, detalle_ajuste, out mensaje);

            if (respuesta)
            {
                var result = MessageBox.Show($"¡Ajuste registrado con éxito!\n\nNúmero de ajuste: {numeroajuste}\n\n¿Desea copiarlo al portapapeles?", "Registro Exitoso",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information);


                if (result == DialogResult.Yes)
                    Clipboard.SetText(numeroajuste);

                txtIdProducto.Text = "0";
                txtMotivoGeneral.Text = "";
                txtObservaciones.Text = "";
                dgv_Data.Rows.Clear();
            }
            else
            {
                MessageBox.Show(mensaje, "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void txtCodigoProducto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string codigoBuscado = txtCodigoProducto.Text.Trim().ToUpper();

                Producto oProducto = new CapaNegocio_Producto()
                    .Listar()
                    .FirstOrDefault(p => p.Codigo.Trim().ToUpper() == codigoBuscado);

                if (oProducto == null)
                {
                    txtCodigoProducto.BackColor = System.Drawing.Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtNombreProducto.Text = "";
                    txtStock.Text = "0";
                    MessageBox.Show("Producto no encontrado.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (!oProducto.Estado)
                {
                    txtCodigoProducto.BackColor = System.Drawing.Color.MistyRose;
                    txtIdProducto.Text = "0";
                    txtNombreProducto.Text = "";
                    txtStock.Text = "0";
                    MessageBox.Show("El producto está inactivo.", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    txtCodigoProducto.BackColor = System.Drawing.Color.Honeydew;
                    txtIdProducto.Text = oProducto.IdProducto.ToString();
                    txtNombreProducto.Text = oProducto.Nombre;
                    txtStock.Text = oProducto.Stock.ToString();
                    txtCantidad.Value = 1;

                    txtCodigoProducto.Focus();
                }

                //Evita el beep de Enter
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}   
