namespace CapaPresentacion
{
    partial class FormReporteAjustes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnbuscarresultado = new FontAwesome.Sharp.IconButton();
            this.txtfechafin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.txtfechainicio = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnexportar = new FontAwesome.Sharp.IconButton();
            this.btnfiltro = new FontAwesome.Sharp.IconButton();
            this.btnlimpiar = new FontAwesome.Sharp.IconButton();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.comboxBusqueda = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgv_Data = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.FechaRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hora = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoAjuste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroAjuste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MotivoGeneral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Observaciones = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsuarioRegistro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CodigoProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionProducto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Categoria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockAnterior = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadAjuste = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StockNuevo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 25);
            this.label1.TabIndex = 66;
            this.label1.Text = "Reporte de Ajustes";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 125);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1063, 389);
            this.label4.TabIndex = 72;
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnbuscarresultado
            // 
            this.btnbuscarresultado.BackColor = System.Drawing.Color.White;
            this.btnbuscarresultado.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbuscarresultado.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnbuscarresultado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarresultado.ForeColor = System.Drawing.Color.Black;
            this.btnbuscarresultado.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnbuscarresultado.IconColor = System.Drawing.Color.Black;
            this.btnbuscarresultado.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnbuscarresultado.IconSize = 18;
            this.btnbuscarresultado.Location = new System.Drawing.Point(485, 59);
            this.btnbuscarresultado.Name = "btnbuscarresultado";
            this.btnbuscarresultado.Size = new System.Drawing.Size(95, 24);
            this.btnbuscarresultado.TabIndex = 71;
            this.btnbuscarresultado.Text = "Buscar";
            this.btnbuscarresultado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbuscarresultado.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnbuscarresultado.UseVisualStyleBackColor = false;
            this.btnbuscarresultado.Click += new System.EventHandler(this.btnbuscarresultado_Click);
            // 
            // txtfechafin
            // 
            this.txtfechafin.CustomFormat = "dd/MM/yyyy";
            this.txtfechafin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfechafin.Location = new System.Drawing.Point(326, 62);
            this.txtfechafin.Name = "txtfechafin";
            this.txtfechafin.Size = new System.Drawing.Size(143, 20);
            this.txtfechafin.TabIndex = 68;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(263, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 69;
            this.label2.Text = "Fecha Fin:";
            // 
            // txtfechainicio
            // 
            this.txtfechainicio.CustomFormat = "dd/MM/yyyy";
            this.txtfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtfechainicio.Location = new System.Drawing.Point(101, 62);
            this.txtfechainicio.Name = "txtfechainicio";
            this.txtfechainicio.Size = new System.Drawing.Size(143, 20);
            this.txtfechainicio.TabIndex = 64;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(27, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 67;
            this.label3.Text = "Fecha Inicio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(495, 65);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 70;
            this.label6.Text = "Proveedor:";
            // 
            // btnexportar
            // 
            this.btnexportar.BackColor = System.Drawing.Color.White;
            this.btnexportar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnexportar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnexportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexportar.ForeColor = System.Drawing.Color.Black;
            this.btnexportar.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnexportar.IconColor = System.Drawing.Color.ForestGreen;
            this.btnexportar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnexportar.IconSize = 22;
            this.btnexportar.Location = new System.Drawing.Point(30, 137);
            this.btnexportar.Name = "btnexportar";
            this.btnexportar.Size = new System.Drawing.Size(119, 33);
            this.btnexportar.TabIndex = 79;
            this.btnexportar.Text = "Descargar Excel";
            this.btnexportar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnexportar.UseVisualStyleBackColor = false;
            this.btnexportar.Click += new System.EventHandler(this.btnexportar_Click);
            // 
            // btnfiltro
            // 
            this.btnfiltro.BackColor = System.Drawing.Color.White;
            this.btnfiltro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnfiltro.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnfiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfiltro.ForeColor = System.Drawing.Color.White;
            this.btnfiltro.IconChar = FontAwesome.Sharp.IconChar.SearchMinus;
            this.btnfiltro.IconColor = System.Drawing.Color.Black;
            this.btnfiltro.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnfiltro.IconSize = 18;
            this.btnfiltro.Location = new System.Drawing.Point(953, 144);
            this.btnfiltro.Name = "btnfiltro";
            this.btnfiltro.Size = new System.Drawing.Size(50, 21);
            this.btnfiltro.TabIndex = 78;
            this.btnfiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfiltro.UseVisualStyleBackColor = false;
            this.btnfiltro.Click += new System.EventHandler(this.btnfiltro_Click);
            // 
            // btnlimpiar
            // 
            this.btnlimpiar.BackColor = System.Drawing.Color.White;
            this.btnlimpiar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiar.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnlimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiar.ForeColor = System.Drawing.Color.White;
            this.btnlimpiar.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiar.IconColor = System.Drawing.Color.Black;
            this.btnlimpiar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiar.IconSize = 18;
            this.btnlimpiar.Location = new System.Drawing.Point(1009, 144);
            this.btnlimpiar.Name = "btnlimpiar";
            this.btnlimpiar.Size = new System.Drawing.Size(50, 21);
            this.btnlimpiar.TabIndex = 77;
            this.btnlimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlimpiar.UseVisualStyleBackColor = false;
            this.btnlimpiar.Click += new System.EventHandler(this.btnlimpiar_Click);
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(794, 145);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(153, 20);
            this.txtBusqueda.TabIndex = 76;
            // 
            // comboxBusqueda
            // 
            this.comboxBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxBusqueda.FormattingEnabled = true;
            this.comboxBusqueda.Location = new System.Drawing.Point(650, 145);
            this.comboxBusqueda.Name = "comboxBusqueda";
            this.comboxBusqueda.Size = new System.Drawing.Size(138, 21);
            this.comboxBusqueda.TabIndex = 75;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(586, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 13);
            this.label7.TabIndex = 74;
            this.label7.Text = "Buscar por";
            // 
            // dgv_Data
            // 
            this.dgv_Data.AllowUserToAddRows = false;
            this.dgv_Data.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FechaRegistro,
            this.Hora,
            this.TipoAjuste,
            this.NumeroAjuste,
            this.MotivoGeneral,
            this.Observaciones,
            this.UsuarioRegistro,
            this.CodigoProducto,
            this.NombreProducto,
            this.DescripcionProducto,
            this.Categoria,
            this.StockAnterior,
            this.CantidadAjuste,
            this.StockNuevo});
            this.dgv_Data.Location = new System.Drawing.Point(30, 188);
            this.dgv_Data.MultiSelect = false;
            this.dgv_Data.Name = "dgv_Data";
            this.dgv_Data.ReadOnly = true;
            this.dgv_Data.RowTemplate.Height = 28;
            this.dgv_Data.Size = new System.Drawing.Size(1032, 300);
            this.dgv_Data.TabIndex = 73;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1063, 99);
            this.label5.TabIndex = 65;
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FechaRegistro
            // 
            this.FechaRegistro.HeaderText = "FechaRegistro";
            this.FechaRegistro.Name = "FechaRegistro";
            this.FechaRegistro.ReadOnly = true;
            // 
            // Hora
            // 
            this.Hora.HeaderText = "Hora";
            this.Hora.Name = "Hora";
            this.Hora.ReadOnly = true;
            // 
            // TipoAjuste
            // 
            this.TipoAjuste.HeaderText = "TipoAjuste";
            this.TipoAjuste.Name = "TipoAjuste";
            this.TipoAjuste.ReadOnly = true;
            // 
            // NumeroAjuste
            // 
            this.NumeroAjuste.HeaderText = "NumeroAjuste";
            this.NumeroAjuste.Name = "NumeroAjuste";
            this.NumeroAjuste.ReadOnly = true;
            // 
            // MotivoGeneral
            // 
            this.MotivoGeneral.HeaderText = "MotivoGeneral";
            this.MotivoGeneral.Name = "MotivoGeneral";
            this.MotivoGeneral.ReadOnly = true;
            // 
            // Observaciones
            // 
            this.Observaciones.HeaderText = "Observaciones";
            this.Observaciones.Name = "Observaciones";
            this.Observaciones.ReadOnly = true;
            // 
            // UsuarioRegistro
            // 
            this.UsuarioRegistro.HeaderText = "UsuarioRegistro";
            this.UsuarioRegistro.Name = "UsuarioRegistro";
            this.UsuarioRegistro.ReadOnly = true;
            // 
            // CodigoProducto
            // 
            this.CodigoProducto.HeaderText = "CodigoProducto";
            this.CodigoProducto.Name = "CodigoProducto";
            this.CodigoProducto.ReadOnly = true;
            // 
            // NombreProducto
            // 
            this.NombreProducto.HeaderText = "NombreProducto";
            this.NombreProducto.Name = "NombreProducto";
            this.NombreProducto.ReadOnly = true;
            // 
            // DescripcionProducto
            // 
            this.DescripcionProducto.HeaderText = "DescripcionProducto";
            this.DescripcionProducto.Name = "DescripcionProducto";
            this.DescripcionProducto.ReadOnly = true;
            // 
            // Categoria
            // 
            this.Categoria.HeaderText = "Categoria";
            this.Categoria.Name = "Categoria";
            this.Categoria.ReadOnly = true;
            // 
            // StockAnterior
            // 
            this.StockAnterior.HeaderText = "StockAnterior";
            this.StockAnterior.Name = "StockAnterior";
            this.StockAnterior.ReadOnly = true;
            // 
            // CantidadAjuste
            // 
            this.CantidadAjuste.HeaderText = "CantidadAjuste";
            this.CantidadAjuste.Name = "CantidadAjuste";
            this.CantidadAjuste.ReadOnly = true;
            // 
            // StockNuevo
            // 
            this.StockNuevo.HeaderText = "StockNuevo";
            this.StockNuevo.Name = "StockNuevo";
            this.StockNuevo.ReadOnly = true;
            // 
            // FormReporteAjustes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1088, 529);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnbuscarresultado);
            this.Controls.Add(this.txtfechafin);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtfechainicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnexportar);
            this.Controls.Add(this.btnfiltro);
            this.Controls.Add(this.btnlimpiar);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.comboxBusqueda);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgv_Data);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Name = "FormReporteAjustes";
            this.Text = "FormReporteAjustes";
            this.Load += new System.EventHandler(this.FormReporteAjustes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private FontAwesome.Sharp.IconButton btnbuscarresultado;
        private System.Windows.Forms.DateTimePicker txtfechafin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker txtfechainicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private FontAwesome.Sharp.IconButton btnexportar;
        private FontAwesome.Sharp.IconButton btnfiltro;
        private FontAwesome.Sharp.IconButton btnlimpiar;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.ComboBox comboxBusqueda;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgv_Data;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hora;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoAjuste;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroAjuste;
        private System.Windows.Forms.DataGridViewTextBoxColumn MotivoGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn Observaciones;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsuarioRegistro;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodigoProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionProducto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Categoria;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockAnterior;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadAjuste;
        private System.Windows.Forms.DataGridViewTextBoxColumn StockNuevo;
    }
}