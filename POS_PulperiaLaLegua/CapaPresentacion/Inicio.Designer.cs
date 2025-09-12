namespace CapaPresentacion
{
    partial class Inicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuusuarios = new FontAwesome.Sharp.IconMenuItem();
            this.menumantenimiento = new FontAwesome.Sharp.IconMenuItem();
            this.SubMenuCategoría = new FontAwesome.Sharp.IconMenuItem();
            this.SubMenuProductos = new FontAwesome.Sharp.IconMenuItem();
            this.SubMenuClientes = new FontAwesome.Sharp.IconMenuItem();
            this.SubMenuProveedores = new FontAwesome.Sharp.IconMenuItem();
            this.SubMenuNegocio = new FontAwesome.Sharp.IconMenuItem();
            this.menuventas = new FontAwesome.Sharp.IconMenuItem();
            this.SubMenuRegistrarVenta = new FontAwesome.Sharp.IconMenuItem();
            this.SubMenuConsultarVenta = new FontAwesome.Sharp.IconMenuItem();
            this.menucompras = new FontAwesome.Sharp.IconMenuItem();
            this.SubMenuRegistrarCompras = new FontAwesome.Sharp.IconMenuItem();
            this.SubMenuConsultarCompras = new FontAwesome.Sharp.IconMenuItem();
            this.menuajustes = new FontAwesome.Sharp.IconMenuItem();
            this.SubMenuRegistrarAjuste = new FontAwesome.Sharp.IconMenuItem();
            this.SubMenuConsultarAjuste = new FontAwesome.Sharp.IconMenuItem();
            this.menureportes = new FontAwesome.Sharp.IconMenuItem();
            this.SubMenuReporteVentas = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuReporteCompras = new System.Windows.Forms.ToolStripMenuItem();
            this.SubMenuReporteAjustes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuacercade = new FontAwesome.Sharp.IconMenuItem();
            this.menutitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblusuario = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblFechaHora = new System.Windows.Forms.Label();
            this.btnSalir = new FontAwesome.Sharp.IconButton();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.BackColor = System.Drawing.Color.White;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuusuarios,
            this.menumantenimiento,
            this.menuventas,
            this.menucompras,
            this.menuajustes,
            this.menureportes,
            this.menuacercade});
            this.menu.Location = new System.Drawing.Point(0, 65);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1151, 73);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // menuusuarios
            // 
            this.menuusuarios.AutoSize = false;
            this.menuusuarios.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.menuusuarios.IconColor = System.Drawing.Color.Black;
            this.menuusuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuusuarios.IconSize = 50;
            this.menuusuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuusuarios.Name = "menuusuarios";
            this.menuusuarios.Size = new System.Drawing.Size(95, 69);
            this.menuusuarios.Text = "Usuarios";
            this.menuusuarios.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuusuarios.Click += new System.EventHandler(this.menuusuarios_Click);
            // 
            // menumantenimiento
            // 
            this.menumantenimiento.AutoSize = false;
            this.menumantenimiento.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubMenuCategoría,
            this.SubMenuProductos,
            this.SubMenuClientes,
            this.SubMenuProveedores,
            this.SubMenuNegocio});
            this.menumantenimiento.IconChar = FontAwesome.Sharp.IconChar.ScrewdriverWrench;
            this.menumantenimiento.IconColor = System.Drawing.Color.Black;
            this.menumantenimiento.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menumantenimiento.IconSize = 50;
            this.menumantenimiento.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menumantenimiento.Name = "menumantenimiento";
            this.menumantenimiento.Size = new System.Drawing.Size(122, 69);
            this.menumantenimiento.Text = "Mantenimiento";
            this.menumantenimiento.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // SubMenuCategoría
            // 
            this.SubMenuCategoría.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubMenuCategoría.IconColor = System.Drawing.Color.Black;
            this.SubMenuCategoría.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubMenuCategoría.Name = "SubMenuCategoría";
            this.SubMenuCategoría.Size = new System.Drawing.Size(139, 22);
            this.SubMenuCategoría.Text = "Categoría";
            this.SubMenuCategoría.Click += new System.EventHandler(this.SubMenuCategoría_Click);
            // 
            // SubMenuProductos
            // 
            this.SubMenuProductos.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubMenuProductos.IconColor = System.Drawing.Color.Black;
            this.SubMenuProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubMenuProductos.Name = "SubMenuProductos";
            this.SubMenuProductos.Size = new System.Drawing.Size(139, 22);
            this.SubMenuProductos.Text = "Productos";
            this.SubMenuProductos.Click += new System.EventHandler(this.SubMenuProductos_Click);
            // 
            // SubMenuClientes
            // 
            this.SubMenuClientes.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubMenuClientes.IconColor = System.Drawing.Color.Black;
            this.SubMenuClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubMenuClientes.Name = "SubMenuClientes";
            this.SubMenuClientes.Size = new System.Drawing.Size(139, 22);
            this.SubMenuClientes.Text = "Clientes";
            this.SubMenuClientes.Click += new System.EventHandler(this.SubMenuClientes_Click);
            // 
            // SubMenuProveedores
            // 
            this.SubMenuProveedores.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubMenuProveedores.IconColor = System.Drawing.Color.Black;
            this.SubMenuProveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubMenuProveedores.Name = "SubMenuProveedores";
            this.SubMenuProveedores.Size = new System.Drawing.Size(139, 22);
            this.SubMenuProveedores.Text = "Proveedores";
            this.SubMenuProveedores.Click += new System.EventHandler(this.SubMenuProveedores_Click);
            // 
            // SubMenuNegocio
            // 
            this.SubMenuNegocio.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubMenuNegocio.IconColor = System.Drawing.Color.Black;
            this.SubMenuNegocio.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubMenuNegocio.Name = "SubMenuNegocio";
            this.SubMenuNegocio.Size = new System.Drawing.Size(139, 22);
            this.SubMenuNegocio.Text = "Negocio";
            this.SubMenuNegocio.Click += new System.EventHandler(this.SubMenuNegocio_Click);
            // 
            // menuventas
            // 
            this.menuventas.AutoSize = false;
            this.menuventas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubMenuRegistrarVenta,
            this.SubMenuConsultarVenta});
            this.menuventas.IconChar = FontAwesome.Sharp.IconChar.Tags;
            this.menuventas.IconColor = System.Drawing.Color.Black;
            this.menuventas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuventas.IconSize = 50;
            this.menuventas.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuventas.Name = "menuventas";
            this.menuventas.Size = new System.Drawing.Size(122, 69);
            this.menuventas.Text = "Ventas";
            this.menuventas.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuventas.Click += new System.EventHandler(this.menuventas_Click);
            // 
            // SubMenuRegistrarVenta
            // 
            this.SubMenuRegistrarVenta.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubMenuRegistrarVenta.IconColor = System.Drawing.Color.Black;
            this.SubMenuRegistrarVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubMenuRegistrarVenta.Name = "SubMenuRegistrarVenta";
            this.SubMenuRegistrarVenta.Size = new System.Drawing.Size(157, 22);
            this.SubMenuRegistrarVenta.Text = "Registrar Venta";
            this.SubMenuRegistrarVenta.Click += new System.EventHandler(this.SubMenuRegistrarVenta_Click);
            // 
            // SubMenuConsultarVenta
            // 
            this.SubMenuConsultarVenta.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubMenuConsultarVenta.IconColor = System.Drawing.Color.Black;
            this.SubMenuConsultarVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubMenuConsultarVenta.Name = "SubMenuConsultarVenta";
            this.SubMenuConsultarVenta.Size = new System.Drawing.Size(157, 22);
            this.SubMenuConsultarVenta.Text = "Consultar Venta";
            this.SubMenuConsultarVenta.Click += new System.EventHandler(this.SubMenuConsultarVenta_Click);
            // 
            // menucompras
            // 
            this.menucompras.AutoSize = false;
            this.menucompras.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubMenuRegistrarCompras,
            this.SubMenuConsultarCompras});
            this.menucompras.IconChar = FontAwesome.Sharp.IconChar.DollyFlatbed;
            this.menucompras.IconColor = System.Drawing.Color.Black;
            this.menucompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menucompras.IconSize = 50;
            this.menucompras.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menucompras.Name = "menucompras";
            this.menucompras.Size = new System.Drawing.Size(122, 69);
            this.menucompras.Text = "Compras";
            this.menucompras.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // SubMenuRegistrarCompras
            // 
            this.SubMenuRegistrarCompras.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubMenuRegistrarCompras.IconColor = System.Drawing.Color.Black;
            this.SubMenuRegistrarCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubMenuRegistrarCompras.Name = "SubMenuRegistrarCompras";
            this.SubMenuRegistrarCompras.Size = new System.Drawing.Size(171, 22);
            this.SubMenuRegistrarCompras.Text = "Registrar Compra";
            this.SubMenuRegistrarCompras.Click += new System.EventHandler(this.SubMenuRegistrarCompras_Click);
            // 
            // SubMenuConsultarCompras
            // 
            this.SubMenuConsultarCompras.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubMenuConsultarCompras.IconColor = System.Drawing.Color.Black;
            this.SubMenuConsultarCompras.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubMenuConsultarCompras.Name = "SubMenuConsultarCompras";
            this.SubMenuConsultarCompras.Size = new System.Drawing.Size(171, 22);
            this.SubMenuConsultarCompras.Text = "Consultar Compra";
            this.SubMenuConsultarCompras.Click += new System.EventHandler(this.SubMenuConsultarCompras_Click);
            // 
            // menuajustes
            // 
            this.menuajustes.AutoSize = false;
            this.menuajustes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubMenuRegistrarAjuste,
            this.SubMenuConsultarAjuste});
            this.menuajustes.IconChar = FontAwesome.Sharp.IconChar.StoreAlt;
            this.menuajustes.IconColor = System.Drawing.Color.Black;
            this.menuajustes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuajustes.IconSize = 50;
            this.menuajustes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuajustes.Name = "menuajustes";
            this.menuajustes.Size = new System.Drawing.Size(122, 69);
            this.menuajustes.Text = "Ajustes";
            this.menuajustes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // SubMenuRegistrarAjuste
            // 
            this.SubMenuRegistrarAjuste.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubMenuRegistrarAjuste.IconColor = System.Drawing.Color.Black;
            this.SubMenuRegistrarAjuste.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubMenuRegistrarAjuste.Name = "SubMenuRegistrarAjuste";
            this.SubMenuRegistrarAjuste.Size = new System.Drawing.Size(161, 22);
            this.SubMenuRegistrarAjuste.Text = "Registrar Ajuste";
            this.SubMenuRegistrarAjuste.Click += new System.EventHandler(this.SubMenuRegistrarAjuste_Click);
            // 
            // SubMenuConsultarAjuste
            // 
            this.SubMenuConsultarAjuste.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubMenuConsultarAjuste.IconColor = System.Drawing.Color.Black;
            this.SubMenuConsultarAjuste.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubMenuConsultarAjuste.Name = "SubMenuConsultarAjuste";
            this.SubMenuConsultarAjuste.Size = new System.Drawing.Size(161, 22);
            this.SubMenuConsultarAjuste.Text = "Consultar Ajuste";
            this.SubMenuConsultarAjuste.Click += new System.EventHandler(this.SubMenuConsultarAjuste_Click);
            // 
            // menureportes
            // 
            this.menureportes.AutoSize = false;
            this.menureportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubMenuReporteVentas,
            this.SubMenuReporteCompras,
            this.SubMenuReporteAjustes});
            this.menureportes.IconChar = FontAwesome.Sharp.IconChar.ChartBar;
            this.menureportes.IconColor = System.Drawing.Color.Black;
            this.menureportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menureportes.IconSize = 50;
            this.menureportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menureportes.Name = "menureportes";
            this.menureportes.Size = new System.Drawing.Size(122, 69);
            this.menureportes.Text = "Reportes";
            this.menureportes.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // SubMenuReporteVentas
            // 
            this.SubMenuReporteVentas.Name = "SubMenuReporteVentas";
            this.SubMenuReporteVentas.Size = new System.Drawing.Size(182, 22);
            this.SubMenuReporteVentas.Text = "Reporte de Ventas";
            this.SubMenuReporteVentas.Click += new System.EventHandler(this.SubMenuReporteVentas_Click);
            // 
            // SubMenuReporteCompras
            // 
            this.SubMenuReporteCompras.Name = "SubMenuReporteCompras";
            this.SubMenuReporteCompras.Size = new System.Drawing.Size(182, 22);
            this.SubMenuReporteCompras.Text = "Reporte de Compras";
            this.SubMenuReporteCompras.Click += new System.EventHandler(this.SubMenuReporteCompras_Click);
            // 
            // SubMenuReporteAjustes
            // 
            this.SubMenuReporteAjustes.Name = "SubMenuReporteAjustes";
            this.SubMenuReporteAjustes.Size = new System.Drawing.Size(182, 22);
            this.SubMenuReporteAjustes.Text = "Reporte de Ajustes";
            this.SubMenuReporteAjustes.Click += new System.EventHandler(this.SubMenuReporteAjustes_Click);
            // 
            // menuacercade
            // 
            this.menuacercade.AutoSize = false;
            this.menuacercade.IconChar = FontAwesome.Sharp.IconChar.CircleInfo;
            this.menuacercade.IconColor = System.Drawing.Color.Black;
            this.menuacercade.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuacercade.IconSize = 50;
            this.menuacercade.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuacercade.Name = "menuacercade";
            this.menuacercade.Size = new System.Drawing.Size(95, 69);
            this.menuacercade.Text = "Ayuda";
            this.menuacercade.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.menuacercade.Click += new System.EventHandler(this.menuacercade_Click);
            // 
            // menutitulo
            // 
            this.menutitulo.AutoSize = false;
            this.menutitulo.BackColor = System.Drawing.Color.SteelBlue;
            this.menutitulo.Location = new System.Drawing.Point(0, 0);
            this.menutitulo.Name = "menutitulo";
            this.menutitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menutitulo.Size = new System.Drawing.Size(1151, 65);
            this.menutitulo.TabIndex = 1;
            this.menutitulo.Text = "menuStrip2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(547, 36);
            this.label1.TabIndex = 2;
            this.label1.Text = "Sistema de Ventas Pulpería La Legua";
            // 
            // contenedor
            // 
            this.contenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contenedor.Location = new System.Drawing.Point(0, 138);
            this.contenedor.Name = "contenedor";
            this.contenedor.Size = new System.Drawing.Size(1151, 480);
            this.contenedor.TabIndex = 3;
            this.contenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.contenedor_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(925, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuario: ";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // lblusuario
            // 
            this.lblusuario.AutoSize = true;
            this.lblusuario.BackColor = System.Drawing.Color.SteelBlue;
            this.lblusuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblusuario.ForeColor = System.Drawing.Color.White;
            this.lblusuario.Location = new System.Drawing.Point(982, 23);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(65, 16);
            this.lblusuario.TabIndex = 5;
            this.lblusuario.Text = "lblusuario";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            // 
            // lblFechaHora
            // 
            this.lblFechaHora.AutoSize = true;
            this.lblFechaHora.BackColor = System.Drawing.Color.SteelBlue;
            this.lblFechaHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaHora.ForeColor = System.Drawing.Color.White;
            this.lblFechaHora.Location = new System.Drawing.Point(607, 19);
            this.lblFechaHora.Name = "lblFechaHora";
            this.lblFechaHora.Size = new System.Drawing.Size(97, 20);
            this.lblFechaHora.TabIndex = 6;
            this.lblFechaHora.Text = "Fecha/Hora:";
            // 
            // btnSalir
            // 
            this.btnSalir.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSalir.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalir.IconChar = FontAwesome.Sharp.IconChar.SignInAlt;
            this.btnSalir.IconColor = System.Drawing.Color.White;
            this.btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSalir.Location = new System.Drawing.Point(1084, 5);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.btnSalir.Size = new System.Drawing.Size(55, 53);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1151, 618);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.lblFechaHora);
            this.Controls.Add(this.lblusuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.contenedor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.menutitulo);
            this.MainMenuStrip = this.menu;
            this.Name = "Inicio";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Inicio_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.MenuStrip menutitulo;
        private System.Windows.Forms.Label label1;
        private FontAwesome.Sharp.IconMenuItem menureportes;
        private FontAwesome.Sharp.IconMenuItem menuusuarios;
        private FontAwesome.Sharp.IconMenuItem menumantenimiento;
        private FontAwesome.Sharp.IconMenuItem menuventas;
        private FontAwesome.Sharp.IconMenuItem menucompras;
        private FontAwesome.Sharp.IconMenuItem menuajustes;
        private FontAwesome.Sharp.IconMenuItem menuacercade;
        private System.Windows.Forms.Panel contenedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblusuario;
        private FontAwesome.Sharp.IconMenuItem SubMenuCategoría;
        private FontAwesome.Sharp.IconMenuItem SubMenuProductos;
        private FontAwesome.Sharp.IconMenuItem SubMenuClientes;
        private FontAwesome.Sharp.IconMenuItem SubMenuProveedores;
        private FontAwesome.Sharp.IconMenuItem SubMenuNegocio;
        private FontAwesome.Sharp.IconMenuItem SubMenuRegistrarVenta;
        private FontAwesome.Sharp.IconMenuItem SubMenuConsultarVenta;
        private FontAwesome.Sharp.IconMenuItem SubMenuRegistrarCompras;
        private FontAwesome.Sharp.IconMenuItem SubMenuConsultarCompras;
        private FontAwesome.Sharp.IconMenuItem SubMenuRegistrarAjuste;
        private FontAwesome.Sharp.IconMenuItem SubMenuConsultarAjuste;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblFechaHora;
        private System.Windows.Forms.ToolStripMenuItem SubMenuReporteVentas;
        private System.Windows.Forms.ToolStripMenuItem SubMenuReporteCompras;
        private FontAwesome.Sharp.IconButton btnSalir;
        private System.Windows.Forms.ToolStripMenuItem SubMenuReporteAjustes;
    }
}

