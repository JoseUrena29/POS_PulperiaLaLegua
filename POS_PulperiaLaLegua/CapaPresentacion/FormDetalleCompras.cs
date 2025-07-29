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
    public partial class FormDetalleCompras : Form
    {
        public FormDetalleCompras()
        {
            InitializeComponent();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {

        }

        private void FormDetalleCompras_Load(object sender, EventArgs e)
        {
            btnbuscar.IconChar = IconChar.Search;
            btnbuscar.IconColor = Color.Black;
            btnbuscar.IconSize = 18;
            btnbuscar.Text = "Buscar";
        }
    }
}
