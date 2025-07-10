using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Utilidades;
using ClosedXML.Excel;
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
    public partial class FormClientes : Form
    {
        public FormClientes()
        {
            InitializeComponent();
        }

        private void FormClientes_Load(object sender, EventArgs e)
        {
            comboxEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            comboxEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            comboxEstado.DisplayMember = "Texto";
            comboxEstado.ValueMember = "Valor";
            comboxEstado.SelectedIndex = 0;

            //Filtro de Busqueda
            foreach (DataGridViewColumn columna in dgv_Data.Columns)
            {
                if (columna.Visible == true && columna.Name != "btnSeleccionar")
                {
                    comboxBusqueda.Items.Add(new OpcionCombo() { Valor = columna.Name, Texto = columna.HeaderText });
                }
            }
            comboxBusqueda.DisplayMember = "Texto";
            comboxBusqueda.ValueMember = "Valor";
            comboxBusqueda.SelectedIndex = 0;

            //Mostrar todos los Clientes de la Base de Datos
            List<Cliente> lista = new CapaNegocio_Cliente().Listar();

            foreach (Cliente item in lista)
            {
                dgv_Data.Rows.Add(new object[]
                {   "",
                    item.IdCliente,
                    item.NumeroIdentidad,
                    item.NombreCompleto,
                    item.Correo,
                    item.Telefono,
                    item.Estado == true ? "Activo" : "Inactivo",
                    item.Estado ? 1 : 0,
                });
            }
        }

        private void Limpiar()
        {
            textIndice.Text = "-1";
            textID.Text = "0";
            txtNumeroIdentidad.Text = "";
            txtNombreCompleto.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            comboxEstado.SelectedIndex = 0;

            txtNumeroIdentidad.Select();
        }

        private void btnLimpiarFormulario_Click_1(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnfiltro_Click_1(object sender, EventArgs e)
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            Cliente obj = new Cliente()
            {
                IdCliente = Convert.ToInt32(textID.Text),
                NumeroIdentidad = txtNumeroIdentidad.Text,
                NombreCompleto = txtNombreCompleto.Text,
                Correo = txtCorreo.Text,
                Telefono = txtTelefono.Text,
                Estado = Convert.ToInt32(((OpcionCombo)comboxEstado.SelectedItem).Valor) == 1 ? true : false
            };

            if (obj.IdCliente == 0)
            {
                int idgenerado = new CapaNegocio_Cliente().Registrar(obj, out mensaje);

                if (idgenerado != 0)
                {
                    dgv_Data.Rows.Add(new object[] {
                        "",
                        idgenerado,
                        txtNumeroIdentidad.Text,
                        txtNombreCompleto.Text,
                        txtCorreo.Text,
                        txtTelefono.Text,
                        ((OpcionCombo)comboxEstado.SelectedItem).Texto.ToString(),
                        ((OpcionCombo)comboxEstado.SelectedItem).Valor.ToString()
                    });

                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }

            }
            else
            {
                bool resultado = new CapaNegocio_Cliente().Editar(obj, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgv_Data.Rows[Convert.ToInt32(textIndice.Text)];
                    row.Cells["Id"].Value = textID.Text;
                    row.Cells["NumeroIdentidad"].Value = txtNumeroIdentidad.Text;
                    row.Cells["NombreCompleto"].Value = txtNombreCompleto.Text;
                    row.Cells["Correo"].Value = txtCorreo.Text;
                    row.Cells["Telefono"].Value = txtTelefono.Text;
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)comboxEstado.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)comboxEstado.SelectedItem).Texto.ToString();
                    Limpiar();
                }
                else
                {
                    MessageBox.Show(mensaje);
                }
            }
        }

        private void dgv_Data_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == 0)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                int iconSize = Math.Min(e.CellBounds.Width, e.CellBounds.Height) - 6;

                //var w = Properties.Resources.check20.Width;
                //var h = Properties.Resources.check20.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - iconSize) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - iconSize) / 2;

                e.Graphics.DrawImage(Properties.Resources.check20, new Rectangle(x, y, iconSize, iconSize));
                e.Handled = true;
            }
        }

        private void dgv_Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Data.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    textIndice.Text = indice.ToString();
                    textID.Text = dgv_Data.Rows[indice].Cells["Id"].Value.ToString();

                    txtNumeroIdentidad.Text = dgv_Data.Rows[indice].Cells["NumeroIdentidad"].Value.ToString();
                    txtNombreCompleto.Text = dgv_Data.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dgv_Data.Rows[indice].Cells["Correo"].Value.ToString();
                    txtTelefono.Text = dgv_Data.Rows[indice].Cells["Telefono"].Value.ToString();

                    foreach (OpcionCombo oc in comboxEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgv_Data.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            //int indice_combo = comboxEstado.Items.IndexOf(oc);
                            //comboxEstado.SelectedItem = indice_combo;
                            comboxEstado.SelectedItem = oc;
                            break;
                        }
                    }
                }
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
                    if (columna.HeaderText != "" && columna.Visible)
                        dt.Columns.Add(columna.HeaderText, typeof(string));
                }

                foreach (DataGridViewRow row in dgv_Data.Rows)
                {
                    if (row.Visible)
                        dt.Rows.Add(new object[]
                        {
                            row.Cells[2].Value.ToString(),
                            row.Cells[3].Value.ToString(),
                            row.Cells[4].Value.ToString(),
                            row.Cells[5].Value.ToString(),
                            row.Cells[7].Value.ToString(),
                        });
                }
                SaveFileDialog savefile = new SaveFileDialog();
                savefile.FileName = string.Format("Reporte de Clientes_{0}.xlsx", DateTime.Now.ToString("ddMMyyyyHHmmss"));
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
