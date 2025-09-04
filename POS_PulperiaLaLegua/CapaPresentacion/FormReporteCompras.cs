using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
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
    public partial class FormReporteCompras : Form
    {
        public FormReporteCompras()
        {
            InitializeComponent();
        }

        private void FormReporteCompras_Load(object sender, EventArgs e)
        {
            // Botón Buscar
            btnbuscarresultado.IconChar = IconChar.Search;
            btnbuscarresultado.IconColor = Color.Black;
            btnbuscarresultado.IconSize = 18;
            btnbuscarresultado.Text = "Buscar";
            btnbuscarresultado.TextImageRelation = TextImageRelation.ImageBeforeText;

            // Botón Filtro
            btnfiltro.IconChar = IconChar.Search;
            btnfiltro.IconColor = Color.Black;
            btnfiltro.IconSize = 18;

            // ComboBox de Resultado por Proveedor
            List<Proveedor> lista = new CapaNegocio_Proveedor().Listar();

            comboxProveedor.Items.Add(new OpcionCombo() { Valor = 0, Texto = "TODOS" });
            foreach (Proveedor item in lista)
            {
                comboxProveedor.Items.Add(new OpcionCombo() { Valor = item.IdProveedor, Texto = item.NombreComercial });
            }
            comboxProveedor.DisplayMember = "Texto";
            comboxProveedor.ValueMember = "Valor";
            comboxProveedor.SelectedIndex = 0;

            // ComboBox de Filtro
            foreach (DataGridViewColumn columna in dgv_Data.Columns)
            {
                comboxBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
            }
            comboxBusqueda.DisplayMember = "Texto";
            comboxBusqueda.ValueMember = "Valor";
            comboxBusqueda.SelectedIndex = 0;

        }

        private void btnfiltro_Click(object sender, EventArgs e)
        {
            string columnaFiltro = ((OpcionCombo)comboxBusqueda.SelectedItem).Valor.ToString();
            string textoBusqueda = txtBusqueda.Text.Trim().ToUpper();

            if (dgv_Data.Rows.Count > 0)
            {
                foreach (DataGridViewRow row in dgv_Data.Rows)
                {
                    bool visible = false;

                    if (row.Cells[columnaFiltro].Value != null)
                    {
                        string valorCelda = row.Cells[columnaFiltro].Value.ToString().Trim().ToUpper();

                        if (columnaFiltro == "Estado")
                        {
                            visible = valorCelda.Equals(textoBusqueda);
                        }
                        else
                        {
                            visible = valorCelda.Contains(textoBusqueda);
                        }
                    }

                    row.Visible = visible;
                }
            }
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            comboxBusqueda.SelectedIndex = 0;

            // Restaurar visibilidad de todas las filas
            foreach (DataGridViewRow row in dgv_Data.Rows)
            {
                row.Visible = true;
            }
        }

        private void btnbuscarresultado_Click(object sender, EventArgs e)
        {
            int IdProveedor = Convert.ToInt32(((OpcionCombo)comboxProveedor.SelectedItem).Valor.ToString());

            List<ReporteCompra> lista = new List<ReporteCompra>();

            lista = new CapaNegocio_Reporte().Compra(
                txtfechainicio.Value.ToString(),
                txtfechafin.Value.ToString(),
                IdProveedor);

            if (lista == null || lista.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados para el rango de fechas seleccionado.",
                                "Sin Resultados",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
                return;
            }

            dgv_Data.Rows.Clear();

            foreach (ReporteCompra rc in lista)
            {
                dgv_Data.Rows.Add(new object[]
                {
                    rc.FechaRegistro,
                    rc.Hora,
                    rc.TipoCompra,
                    rc.NumeroCompra,
                    rc.UsuarioRegistro,
                    rc.NumeroIdentidadProveedor,
                    rc.NombreProveedor,
                    rc.CodigoProducto,
                    rc.NombreProducto,
                    rc.DescripcionProducto,
                    rc.Categoria,
                    rc.PrecioCompra,
                    rc.PrecioVenta,
                    rc.Cantidad,
                    rc.SubTotalProductos,
                    rc.MontoNeto,
                    rc.Descuento,
                    rc.SubTotal,
                    rc.IVA,
                    rc.Total,
                });
            }
        }

        private void btnexportar_Click(object sender, EventArgs e)
        {
            if (dgv_Data.Rows.Count < 1)
            {
                MessageBox.Show("No hay datos para exportar", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                DataTable dt = new DataTable();
                foreach (DataGridViewColumn columna in dgv_Data.Columns)
                {
                    dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in dgv_Data.Rows)
                {
                    if (row.Visible)
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[0].Value.ToString(),
                            row.Cells[1].Value.ToString(),
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[5].Value.ToString(),
                            row.Cells[6].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                            row.Cells[8].Value.ToString(),
                            row.Cells[9].Value.ToString(),
                            row.Cells[10].Value.ToString(),
                            row.Cells[11].Value.ToString(),
                            row.Cells[12].Value.ToString(),
                            row.Cells[13].Value.ToString(),
                            row.Cells[14].Value.ToString(),
                            row.Cells[15].Value.ToString(),
                            row.Cells[16].Value.ToString(),
                            row.Cells[17].Value.ToString(),
                            row.Cells[18].Value.ToString(),
                            row.Cells[19].Value.ToString(),
                        });
                }
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Reporte de Compras_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
                savefile.Filter = "Excel Files | *.xlsx";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        XLWorkbook wb = new XLWorkbook();
                        var hoja = wb.Worksheets.Add(dt, "Informe");
                        hoja.ColumnsUsed().AdjustToContents();
                        wb.SaveAs(savefile.FileName);
                        MessageBox.Show("Reporte Generado", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Error al generar el reporte", "Mensaje", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }
    }
}
