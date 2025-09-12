using CapaEntidad;
using CapaNegocio;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FormDetalleAjustes : Form
    {
        public FormDetalleAjustes()
        {
            InitializeComponent();
        }

        private void FormDetalleAjustes_Load(object sender, EventArgs e)
        {
            // Botón Buscar
            btnbuscar.IconChar = IconChar.Search;
            btnbuscar.IconColor = Color.Black;
            btnbuscar.IconSize = 18;
            btnbuscar.Text = "Buscar";
            btnbuscar.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtNumeroAjuste.Text = "";
            txtBusqueda.Text = "";
            txtFecha.Text = "";
            txtHora.Text = "";
            txtTipoAjuste.Text = "";
            txtUsuario.Text = "";
            txtMotivoGeneral.Text = "";
            txtObservaciones.Text = "";

            dgv_Data.Rows.Clear();
        }

        private void btnbuscar_Click(object sender, EventArgs e)
        {
            Ajuste oAjuste = new CapaNegocio_Ajuste().ObtenerAjuste(txtBusqueda.Text);

            if (oAjuste != null && oAjuste.IdAjuste != 0)
            {
                txtNumeroAjuste.Text = oAjuste.NumeroAjuste;
                txtFecha.Text = oAjuste.FechaRegistro;
                txtHora.Text = oAjuste.HoraRegistro;
                txtTipoAjuste.Text = oAjuste.TipoAjuste;
                txtUsuario.Text = oAjuste.oUsuario?.NombreCompleto ?? "";
                txtMotivoGeneral.Text = oAjuste.MotivoGeneral;
                txtObservaciones.Text = oAjuste.Observaciones;

                dgv_Data.Rows.Clear();
                foreach (DetalleAjuste da in oAjuste.oDetalleAjuste)
                {
                    dgv_Data.Rows.Add(new object[]
                    {
                        da.oProducto.Codigo,
                        da.oProducto.Nombre,
                        da.StockAnterior,
                        da.Cantidad,
                        da.StockNuevo,
                    });
                }
            }
            else
            {
                MessageBox.Show("No se encontró el ajuste.", "Resultado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
