using CapaEntidad;
using CapaNegocio;
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
    public partial class FormUsuarios : Form
    {
        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            comboxEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            comboxEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            comboxEstado.DisplayMember = "Texto";
            comboxEstado.ValueMember = "Valor";
            comboxEstado.SelectedIndex = 0;

            List<Rol> listarol= new CapaNegocio_Rol().Listar();

            foreach (Rol item in listarol)
            {
                comboxRol.Items.Add(new OpcionCombo() { Valor = item.IdRol, Texto = item.Descripcion });
            }
            comboxRol.DisplayMember = "Texto";
            comboxRol.ValueMember = "Valor";
            comboxRol.SelectedIndex = 0;

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
            List<Usuario> lista = new CapaNegocio_Usuario().Listar();

            foreach (Usuario item in lista)
            {
                dgv_Data.Rows.Add(new object[]
                {   "",
                    item.IdUsuario,
                    item.NumeroIdentidad,
                    item.NombreCompleto,
                    item.Correo,
                    item.Telefono,
                    item.Clave,
                    item.oRol != null ? item.oRol.IdRol : 0,
                    item.oRol != null ? item.oRol.Descripcion : "Sin rol",
                    item.Estado == true ? "Activo" : "Inactivo",
                    item.Estado ? 1 : 0,
                });
            }
        }

        private void dgv_Data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_Data.Columns[e.ColumnIndex].Name == "btnSeleccionar")
            {
                int indice = e.RowIndex;

                if (indice >= 0)
                {
                    txtIndice.Text = indice.ToString();
                    txtID.Text = dgv_Data.Rows[indice].Cells["Id"].Value.ToString();

                    txtNumeroIdentidad.Text = dgv_Data.Rows[indice].Cells["NumeroIdentidad"].Value.ToString();
                    txtNombreCompleto.Text = dgv_Data.Rows[indice].Cells["NombreCompleto"].Value.ToString();
                    txtCorreo.Text = dgv_Data.Rows[indice].Cells["Correo"].Value.ToString();
                    txtTelefono.Text = dgv_Data.Rows[indice].Cells["Telefono"].Value.ToString();

                    foreach (OpcionCombo oc in comboxRol.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgv_Data.Rows[indice].Cells["Rol"].Value))
                        {
                            comboxRol.SelectedItem = oc;
                            break;
                        }
                    }

                    foreach (OpcionCombo oc in comboxEstado.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgv_Data.Rows[indice].Cells["EstadoValor"].Value))
                        {
                            comboxEstado.SelectedItem = oc;
                            break;
                        }
                    }
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

        private void btnLimpiarFormulario_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            txtIndice.Text = "-1";
            txtID.Text = "0";
            txtNumeroIdentidad.Text = "";
            txtNombreCompleto.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            comboxRol.SelectedIndex = 0;
            comboxEstado.SelectedIndex = 0;

            txtNumeroIdentidad.Select();
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
    }
}
