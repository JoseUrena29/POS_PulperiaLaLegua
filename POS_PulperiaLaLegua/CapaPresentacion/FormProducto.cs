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
    public partial class FormProducto : Form
    {
        public FormProducto()
        {
            InitializeComponent();
        }

        private void FormProducto_Load(object sender, EventArgs e)
        {
            comboxEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            comboxEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            comboxEstado.DisplayMember = "Texto";
            comboxEstado.ValueMember = "Valor";
            comboxEstado.SelectedIndex = 0;

            List<Categoria> listacategoria = new CapaNegocio_Categoria().Listar();

            foreach (Categoria item in listacategoria)
            {
                comboxCategoria.Items.Add(new OpcionCombo() { Valor = item.IdCategoria, Texto = item.Descripcion });
            }
            comboxCategoria.DisplayMember = "Texto";
            comboxCategoria.ValueMember = "Valor";
            comboxCategoria.SelectedIndex = 0;

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

            //Mostrar todos los Productos de la Base de Datos
            List<Producto> lista = new CapaNegocio_Producto().Listar();

            foreach (Producto item in lista)
            {
                dgv_Data.Rows.Add(new object[]
                {   "",
                    item.IdProducto,
                    item.Codigo,
                    item.Nombre,
                    item.Descripcion,
                    item.oCategoria.IdCategoria,
                    item.oCategoria.Descripcion,
                    item.Stock,
                    item.PrecioCompra,
                    item.PrecioVenta,
                    item.Estado ? 1 : 0,
                    item.Estado == true ? "Activo" : "Inactivo",
                });
            }
        }
    }   
}
