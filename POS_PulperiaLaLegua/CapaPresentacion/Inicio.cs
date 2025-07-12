using CapaEntidad;
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
    public partial class Inicio : Form
    {
        private static Usuarios UsuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;

        public Inicio()
        {
            InitializeComponent();
        }

        private void contenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Inicio_Load(object sender, EventArgs e)
        {

        }

        private void AbrirFormulario(IconMenuItem menu, Form formulario)
        {
            if (MenuActivo != null) 
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.Silver;
            MenuActivo = menu;

            if (FormularioActivo != null)
            { 
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.SteelBlue;
            
            contenedor.Controls.Add(formulario);
            formulario.Show();
        }

        private void menuusuarios_Click(object sender, EventArgs e)
        {
            AbrirFormulario((IconMenuItem)sender, new FormUsuarios());
        }

        private void SubMenuCategoría_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenimiento, new FormCategoria());
        }

        private void SubMenuProductos_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenimiento, new FormProducto());
        }

        private void SubMenuClientes_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenimiento, new FormClientes());
        }

        private void SubMenuProveedores_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenimiento, new FormProveedores());
        }

        private void SubMenuNegocio_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menumantenimiento, new FormNegocio());
        }

        private void SubMenuRegistrarVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new FormVentas());
        }
        private void SubMenuConsultarVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new FormDetalleVentas());
        }

        private void SubMenuRegistrarCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new FormCompras());
        }

        private void SubMenuConsultarCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new FormDetalleCompras());
        }

        private void SubMenuRegistrarAjuste_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuajustes, new FormAjustes());
        }

        private void SubMenuConsultarAjuste_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuajustes, new FormDetalleAjustes());
        }

        private void menuventas_Click(object sender, EventArgs e)
        {

        }
    }
}
