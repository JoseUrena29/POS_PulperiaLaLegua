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

namespace CapaPresentacion.Modales
{
    public partial class Modal_Proveedor : Form
    {
        public Proveedor _Proveedor {  get; set; }

        public Modal_Proveedor()
        {
            InitializeComponent();
        }

        private void Modal_Proveedor_Load(object sender, EventArgs e)
        {
            //Filtro de Busqueda
            foreach (DataGridViewColumn columna in dgv_Data.Columns)
            {
                if (columna.Visible && columna.Name != "btnSeleccionar")
                {
                    comboxBusqueda.Items.Add(new OpcionCombo()
                    {
                        Valor = columna.Name,
                        Texto = columna.HeaderText
                    });
                }
            }
            comboxBusqueda.DisplayMember = "Texto";
            comboxBusqueda.ValueMember = "Valor";
            comboxBusqueda.SelectedIndex = 0;

            //Mostrar todos los Proveedores de la Base de Datos
            List<Proveedor> lista = new CapaNegocio_Proveedor().Listar();

            foreach (Proveedor item in lista)
            {
                dgv_Data.Rows.Add(new object[]
                {
                    item.IdProveedor,
                    item.NumeroIdentidad,
                    item.NombreComercial,
                });
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

        private void btnlimpiarfiltro_Click(object sender, EventArgs e)
        {
            txtBusqueda.Text = "";
            comboxBusqueda.SelectedIndex = 0;

            // Restaurar visibilidad de todas las filas
            foreach (DataGridViewRow row in dgv_Data.Rows)
            {
                row.Visible = true;
            }
        }

        private void dgv_Data_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int iRow = e.RowIndex;
            int iColum = e.ColumnIndex;

            if (iRow >= 0 && iColum >= 0) 
            {
                _Proveedor = new Proveedor()
                {
                    IdProveedor = Convert.ToInt32(dgv_Data.Rows[iRow].Cells["Id"].Value.ToString()),
                    NumeroIdentidad = dgv_Data.Rows[iRow].Cells["NumeroIdentidad"].Value.ToString(),
                    NombreComercial = dgv_Data.Rows[iRow].Cells["NombreComercial"].Value.ToString()
                };

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
