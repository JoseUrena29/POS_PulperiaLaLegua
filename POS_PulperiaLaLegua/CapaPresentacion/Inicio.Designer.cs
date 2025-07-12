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
            this.menuproveedores = new FontAwesome.Sharp.IconMenuItem();
            this.menureportes = new FontAwesome.Sharp.IconMenuItem();
            this.menuacercade = new FontAwesome.Sharp.IconMenuItem();
            this.menutitulo = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.contenedor = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblusuario = new System.Windows.Forms.Label();
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
            this.menuproveedores,
            this.menureportes,
            this.menuacercade});
            this.menu.Location = new System.Drawing.Point(0, 65);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1075, 73);
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
            this.SubMenuRegistrarVenta.Size = new System.Drawing.Size(180, 22);
            this.SubMenuRegistrarVenta.Text = "Registrar Venta";
            this.SubMenuRegistrarVenta.Click += new System.EventHandler(this.SubMenuRegistrarVenta_Click);
            // 
            // SubMenuConsultarVenta
            // 
            this.SubMenuConsultarVenta.IconChar = FontAwesome.Sharp.IconChar.None;
            this.SubMenuConsultarVenta.IconColor = System.Drawing.Color.Black;
            this.SubMenuConsultarVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.SubMenuConsultarVenta.Name = "SubMenuConsultarVenta";
            this.SubMenuConsultarVenta.Size = new System.Drawing.Size(180, 22);
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
            this.menuajustes.Size = new System.Drawing.Size(95, 69);
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
            // menuproveedores
            // 
            this.menuproveedores.AutoSize = false;
            this.menuproveedores.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.menuproveedores.IconColor = System.Drawing.Color.Black;
            this.menuproveedores.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.menuproveedores.IconSize = 50;
            this.menuproveedores.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.menuproveedores.Name = "menuproveedores";
            this.menuproveedores.Size = new System.Drawing.Size(95, 69);
            this.menuproveedores.Text = "----";
            this.menuproveedores.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // menureportes
            // 
            this.menureportes.AutoSize = false;
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
            // 
            // menutitulo
            // 
            this.menutitulo.AutoSize = false;
            this.menutitulo.BackColor = System.Drawing.Color.SteelBlue;
            this.menutitulo.Location = new System.Drawing.Point(0, 0);
            this.menutitulo.Name = "menutitulo";
            this.menutitulo.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menutitulo.Size = new System.Drawing.Size(1075, 65);
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
            this.contenedor.Size = new System.Drawing.Size(1075, 480);
            this.contenedor.TabIndex = 3;
            this.contenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.contenedor_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.SteelBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(855, 19);
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
            this.lblusuario.Location = new System.Drawing.Point(910, 19);
            this.lblusuario.Name = "lblusuario";
            this.lblusuario.Size = new System.Drawing.Size(65, 16);
            this.lblusuario.TabIndex = 5;
            this.lblusuario.Text = "lblusuario";
            // 
            // Inicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1075, 618);
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
        private FontAwesome.Sharp.IconMenuItem menuproveedores;
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
    }
}

