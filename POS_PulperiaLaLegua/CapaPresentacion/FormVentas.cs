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
    public partial class FormVentas : Form
    {
        public FormVentas()
        {
            InitializeComponent();
        }

        private void FormVentas_Load(object sender, EventArgs e)
        {
            comboxTipoPago.Items.Add(new OpcionCombo() { Valor = "Efectivo", Texto = "Efectivo" });
            comboxTipoPago.Items.Add(new OpcionCombo() { Valor = "Tarjeta", Texto = "Tarjeta" });
            comboxTipoPago.Items.Add(new OpcionCombo() { Valor = "Sinpe", Texto = "Sinpe" });
            comboxTipoPago.Items.Add(new OpcionCombo() { Valor = "Otro", Texto = "Otro" });
            comboxTipoPago.DisplayMember = "Texto";
            comboxTipoPago.ValueMember = "Valor";
            comboxTipoPago.SelectedIndex = 0;

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            txtIdCliente.Text = "0";
            txtIdProducto.Text = "0";
            txtMontoNeto.Text =
            txtMontoNeto.Text = "";
            txtDescuento.Text = "";
            txtSubTotal.Text = "";
            txtIVA.Text = "";
            txtTotal.Text = "";
            txtpago.Text = "";
            txtcambio.Text = "";
        }
    }
}
