using CapaEntidad;
using CapaNegocio;
using CapaPresentacion.Modales;
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
        private static Usuario UsuarioActual;
        private static IconMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;

        public Inicio(Usuario objusuario)
        {
            UsuarioActual = objusuario;
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
            timer1.Tick += Timer1_Tick;
            timer1.Start();

            List<Permiso> ListaPermisos = new CapaNegocio_Permiso().Listar(UsuarioActual.IdUsuario);

            foreach (IconMenuItem iconmenu in menu.Items)
            {
                bool tienePermisoMenu = ListaPermisos.Any(m => m.NombreMenu == iconmenu.Name);
                iconmenu.Visible = tienePermisoMenu;

                // Revisar los submenús dentro del menú principal
                foreach (ToolStripItem subItem in iconmenu.DropDownItems)
                {
                    bool tienePermisoSubMenu = ListaPermisos.Any(m => m.NombreMenu == subItem.Name);
                    subItem.Visible = tienePermisoSubMenu;
                }
            }
                lblusuario.Text = UsuarioActual.NombreCompleto;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            string fechaHora = DateTime.Now.ToString("dddd, dd MMMM yyyy  HH:mm:ss");
            lblFechaHora.Text = char.ToUpper(fechaHora[0]) + fechaHora.Substring(1);
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
            AbrirFormulario(menuventas, new FormVentas(UsuarioActual));
        }
        private void SubMenuConsultarVenta_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuventas, new FormDetalleVentas());
        }

        private void SubMenuRegistrarCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new FormCompras(UsuarioActual));
        }

        private void SubMenuConsultarCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menucompras, new FormDetalleCompras());
        }

        private void SubMenuRegistrarAjuste_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuajustes, new FormAjustes());
        }

        private void menuventas_Click(object sender, EventArgs e)
        {

        }

        private void SubMenuReporteVentas_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menureportes, new FormReporteVentas());
        }

        private void SubMenuReporteCompras_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menureportes, new FormReporteCompras());
        }

        private void menuacercade_Click(object sender, EventArgs e)
        {
            Modal_Ayuda md = new Modal_Ayuda();
            md.ShowDialog();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Está seguro de que desea salir del programa?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
            {
                this.Close();             
            }
        }

        private void SubMenuConsultarAjuste_Click(object sender, EventArgs e)
        {
            AbrirFormulario(menuajustes, new FormDetalleAjustes());
        }
    }
}
