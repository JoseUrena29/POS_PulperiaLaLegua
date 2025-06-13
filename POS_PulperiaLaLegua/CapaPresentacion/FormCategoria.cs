using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaPresentacion.Utilidades;

namespace CapaPresentacion
{
    public partial class FormCategoria : Form
    {
        public FormCategoria()
        {
            InitializeComponent();
        }

        private void FormCategoria_Load(object sender, EventArgs e)
        {
            comboxEstado.Items.Add(new OpcionCombo() { Valor = 1, Texto = "Activo" });
            comboxEstado.Items.Add(new OpcionCombo() { Valor = 0, Texto = "Inactivo" });
            comboxEstado.DisplayMember = "Texto";
            comboxEstado.ValueMember = "Valor";
            comboxEstado.SelectedIndex = 0;




        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            dgv_Data.Rows.Add(new object[] { "",txtID.Text,txtDescripcion.Text,
            ((OpcionCombo)comboxEstado.SelectedItem).Texto.ToString(),
            ((OpcionCombo)comboxEstado.SelectedItem).Valor.ToString()
            });

            Limpiar();
        }

        private void Limpiar()
        {
            txtID.Text = "";
            txtDescripcion.Text = "";
            comboxEstado.SelectedIndex = 0;
        }
    }
}
