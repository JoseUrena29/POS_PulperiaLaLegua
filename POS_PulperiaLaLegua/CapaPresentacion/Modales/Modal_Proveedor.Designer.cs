namespace CapaPresentacion.Modales
{
    partial class Modal_Proveedor
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.txtBusqueda = new System.Windows.Forms.TextBox();
            this.comboxBusqueda = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_Data = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NumeroIdentidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NombreComercial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnfiltro = new FontAwesome.Sharp.IconButton();
            this.btnlimpiarfiltro = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.Location = new System.Drawing.Point(207, 67);
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.Size = new System.Drawing.Size(153, 20);
            this.txtBusqueda.TabIndex = 93;
            // 
            // comboxBusqueda
            // 
            this.comboxBusqueda.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboxBusqueda.FormattingEnabled = true;
            this.comboxBusqueda.Location = new System.Drawing.Point(85, 67);
            this.comboxBusqueda.Name = "comboxBusqueda";
            this.comboxBusqueda.Size = new System.Drawing.Size(116, 21);
            this.comboxBusqueda.TabIndex = 92;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(21, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 13);
            this.label6.TabIndex = 91;
            this.label6.Text = "Buscar por";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 19);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(6);
            this.label5.Size = new System.Drawing.Size(525, 82);
            this.label5.TabIndex = 90;
            this.label5.Text = "Lista de Proveedores";
            // 
            // dgv_Data
            // 
            this.dgv_Data.AllowUserToAddRows = false;
            this.dgv_Data.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Data.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.NumeroIdentidad,
            this.NombreComercial});
            this.dgv_Data.Location = new System.Drawing.Point(12, 113);
            this.dgv_Data.MultiSelect = false;
            this.dgv_Data.Name = "dgv_Data";
            this.dgv_Data.ReadOnly = true;
            this.dgv_Data.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgv_Data.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgv_Data.RowTemplate.Height = 28;
            this.dgv_Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Data.Size = new System.Drawing.Size(525, 337);
            this.dgv_Data.TabIndex = 96;
            this.dgv_Data.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Data_CellDoubleClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Visible = false;
            // 
            // NumeroIdentidad
            // 
            this.NumeroIdentidad.HeaderText = "Número Identidad";
            this.NumeroIdentidad.Name = "NumeroIdentidad";
            this.NumeroIdentidad.ReadOnly = true;
            this.NumeroIdentidad.Width = 120;
            // 
            // NombreComercial
            // 
            this.NombreComercial.HeaderText = "Nombre Comercial";
            this.NombreComercial.Name = "NombreComercial";
            this.NombreComercial.ReadOnly = true;
            this.NombreComercial.Width = 150;
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
            this.btnfiltro.Location = new System.Drawing.Point(366, 67);
            this.btnfiltro.Name = "btnfiltro";
            this.btnfiltro.Size = new System.Drawing.Size(50, 21);
            this.btnfiltro.TabIndex = 95;
            this.btnfiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnfiltro.UseVisualStyleBackColor = false;
            this.btnfiltro.Click += new System.EventHandler(this.btnfiltro_Click);
            // 
            // btnlimpiarfiltro
            // 
            this.btnlimpiarfiltro.BackColor = System.Drawing.Color.White;
            this.btnlimpiarfiltro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnlimpiarfiltro.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btnlimpiarfiltro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnlimpiarfiltro.ForeColor = System.Drawing.Color.White;
            this.btnlimpiarfiltro.IconChar = FontAwesome.Sharp.IconChar.Broom;
            this.btnlimpiarfiltro.IconColor = System.Drawing.Color.Black;
            this.btnlimpiarfiltro.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnlimpiarfiltro.IconSize = 18;
            this.btnlimpiarfiltro.Location = new System.Drawing.Point(422, 67);
            this.btnlimpiarfiltro.Name = "btnlimpiarfiltro";
            this.btnlimpiarfiltro.Size = new System.Drawing.Size(50, 21);
            this.btnlimpiarfiltro.TabIndex = 94;
            this.btnlimpiarfiltro.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnlimpiarfiltro.UseVisualStyleBackColor = false;
            this.btnlimpiarfiltro.Click += new System.EventHandler(this.btnlimpiarfiltro_Click);
            // 
            // Modal_Proveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(575, 478);
            this.Controls.Add(this.dgv_Data);
            this.Controls.Add(this.btnfiltro);
            this.Controls.Add(this.btnlimpiarfiltro);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.comboxBusqueda);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Name = "Modal_Proveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Modal_Proveedor";
            this.Load += new System.EventHandler(this.Modal_Proveedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Data)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnfiltro;
        private FontAwesome.Sharp.IconButton btnlimpiarfiltro;
        private System.Windows.Forms.TextBox txtBusqueda;
        private System.Windows.Forms.ComboBox comboxBusqueda;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroIdentidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn NombreComercial;
    }
}