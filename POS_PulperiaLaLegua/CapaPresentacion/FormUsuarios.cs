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

            //Mostrar todos los Usuarios de la Base de Datos
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
                    item.oRol.Descripcion,
                    item.oRol.IdRol,
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
                    txtClave.Text = dgv_Data.Rows[indice].Cells["Clave"].Value.ToString();
                    txtConfirmarClave.Text = dgv_Data.Rows[indice].Cells["Clave"].Value.ToString();

                    foreach (OpcionCombo oc in comboxRol.Items)
                    {
                        if (Convert.ToInt32(oc.Valor) == Convert.ToInt32(dgv_Data.Rows[indice].Cells["IdRol"].Value))
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
            txtClave.Text = "";
            txtConfirmarClave.Text = "";
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string mensaje = string.Empty;

            // Validaciones generales
            if (string.IsNullOrWhiteSpace(txtNumeroIdentidad.Text))
            {
                MessageBox.Show("Debe ingresar el número de identidad.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNumeroIdentidad.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text))
            {
                MessageBox.Show("Debe ingresar el nombre completo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCompleto.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Debe ingresar el correo electrónico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCorreo.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtTelefono.Text))
            {
                MessageBox.Show("Debe ingresar el número de teléfono.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTelefono.Focus();
                return;
            }

            if (comboxRol.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un rol.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboxRol.Focus();
                return;
            }

            if (comboxEstado.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el estado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboxEstado.Focus();
                return;
            }

            // Validación de contraseñas
            if (string.IsNullOrWhiteSpace(txtClave.Text) || string.IsNullOrWhiteSpace(txtConfirmarClave.Text))
            {
                MessageBox.Show("Debe ingresar y confirmar la contraseña.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClave.Focus();
                return;
            }

            if (txtClave.Text != txtConfirmarClave.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmarClave.Focus();
                return;
            }

            Usuario obj = new Usuario()
            {
                IdUsuario = string.IsNullOrWhiteSpace(txtID.Text) ? 0 : Convert.ToInt32(txtID.Text),
                NumeroIdentidad = txtNumeroIdentidad.Text.Trim(),
                NombreCompleto = txtNombreCompleto.Text.Trim(),
                Correo = txtCorreo.Text.Trim(),
                Telefono = txtTelefono.Text.Trim(),
                Clave = txtClave.Text.Trim(),
                oRol = new Rol() { IdRol = Convert.ToInt32(((OpcionCombo)comboxRol.SelectedItem).Valor) },
                Estado = Convert.ToInt32(((OpcionCombo)comboxEstado.SelectedItem).Valor) == 1
            };

            if (obj.IdUsuario == 0)
            {
                int idgenerado = new CapaNegocio_Usuario().Registrar(obj, out mensaje);

                if (idgenerado != 0)
                {
                    dgv_Data.Rows.Add(new object[] {
                "",
                idgenerado,
                obj.NumeroIdentidad,
                obj.NombreCompleto,
                obj.Correo,
                obj.Telefono,
                obj.Clave,
                ((OpcionCombo)comboxRol.SelectedItem).Texto,
                ((OpcionCombo)comboxRol.SelectedItem).Valor.ToString(),
                ((OpcionCombo)comboxEstado.SelectedItem).Texto,
                ((OpcionCombo)comboxEstado.SelectedItem).Valor.ToString()
            });

                    Limpiar();
                    MessageBox.Show("¡Usuario guardado exitosamente!", "Registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(mensaje, "Error al guardar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                bool resultado = new CapaNegocio_Usuario().Editar(obj, out mensaje);

                if (resultado)
                {
                    DataGridViewRow row = dgv_Data.Rows[Convert.ToInt32(txtIndice.Text)];
                    row.Cells["Id"].Value = obj.IdUsuario;
                    row.Cells["NumeroIdentidad"].Value = obj.NumeroIdentidad;
                    row.Cells["NombreCompleto"].Value = obj.NombreCompleto;
                    row.Cells["Correo"].Value = obj.Correo;
                    row.Cells["Telefono"].Value = obj.Telefono;
                    row.Cells["Clave"].Value = obj.Clave;
                    row.Cells["Rol"].Value = ((OpcionCombo)comboxRol.SelectedItem).Texto;
                    row.Cells["IdRol"].Value = ((OpcionCombo)comboxRol.SelectedItem).Valor.ToString();
                    row.Cells["Estado"].Value = ((OpcionCombo)comboxEstado.SelectedItem).Texto;
                    row.Cells["EstadoValor"].Value = ((OpcionCombo)comboxEstado.SelectedItem).Valor.ToString();

                    Limpiar();
                    MessageBox.Show("¡Usuario editado exitosamente!", "Edición", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(mensaje, "Error al editar", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
