namespace ProyectoNetshop.formularios
{
    partial class ventas
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            groupBox1 = new GroupBox();
            label4 = new Label();
            label3 = new Label();
            tbNombreVendedorVenta = new TextBox();
            tbDniVendedorVenta = new TextBox();
            groupBox2 = new GroupBox();
            label5 = new Label();
            label6 = new Label();
            ibBotonBuscarClienteVenta = new FontAwesome.Sharp.IconButton();
            tbNombreClienteVenta = new TextBox();
            tbDniClienteVenta = new TextBox();
            label12 = new Label();
            label11 = new Label();
            ibBotonBorrarVenta = new FontAwesome.Sharp.IconButton();
            ibBotonGuardarVenta = new FontAwesome.Sharp.IconButton();
            groupBox3 = new GroupBox();
            ibBotonAgregarProductoVenta = new FontAwesome.Sharp.IconButton();
            label9 = new Label();
            tbCantidadProductoVenta = new TextBox();
            tbPrecioVtaProductoVenta = new TextBox();
            label7 = new Label();
            label8 = new Label();
            tbStockProductoVenta = new TextBox();
            label1 = new Label();
            label2 = new Label();
            ibBotonBuscarProductoVenta = new FontAwesome.Sharp.IconButton();
            tbDescripcionProductoVenta = new TextBox();
            tbNombreProductoVenta = new TextBox();
            groupBox4 = new GroupBox();
            dtpFechaVenta = new DateTimePicker();
            groupBox5 = new GroupBox();
            cbTipoFacturaVenta = new ComboBox();
            groupBox6 = new GroupBox();
            dgvVentas = new DataGridView();
            codIdProducto = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colCantidad = new DataGridViewTextBoxColumn();
            colSubtotal = new DataGridViewTextBoxColumn();
            totalVenta = new DataGridViewTextBoxColumn();
            fechaVenta = new DataGridViewTextBoxColumn();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(0, 0, 64);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(tbNombreVendedorVenta);
            groupBox1.Controls.Add(tbDniVendedorVenta);
            groupBox1.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            groupBox1.ForeColor = SystemColors.ButtonFace;
            groupBox1.Location = new Point(14, 16);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(593, 133);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Vendedor";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(241, 33);
            label4.Name = "label4";
            label4.Size = new Size(72, 29);
            label4.TabIndex = 28;
            label4.Text = "Nombre";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(39, 36);
            label3.Name = "label3";
            label3.Size = new Size(42, 29);
            label3.TabIndex = 27;
            label3.Text = "DNI";
            // 
            // tbNombreVendedorVenta
            // 
            tbNombreVendedorVenta.Font = new Font("Segoe UI", 9F);
            tbNombreVendedorVenta.Location = new Point(131, 69);
            tbNombreVendedorVenta.Margin = new Padding(3, 4, 3, 4);
            tbNombreVendedorVenta.Name = "tbNombreVendedorVenta";
            tbNombreVendedorVenta.ReadOnly = true;
            tbNombreVendedorVenta.Size = new Size(290, 27);
            tbNombreVendedorVenta.TabIndex = 1;
            // 
            // tbDniVendedorVenta
            // 
            tbDniVendedorVenta.Font = new Font("Segoe UI", 9F);
            tbDniVendedorVenta.Location = new Point(19, 69);
            tbDniVendedorVenta.Margin = new Padding(3, 4, 3, 4);
            tbDniVendedorVenta.Name = "tbDniVendedorVenta";
            tbDniVendedorVenta.ReadOnly = true;
            tbDniVendedorVenta.Size = new Size(84, 27);
            tbDniVendedorVenta.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(0, 0, 64);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(ibBotonBuscarClienteVenta);
            groupBox2.Controls.Add(tbNombreClienteVenta);
            groupBox2.Controls.Add(tbDniClienteVenta);
            groupBox2.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            groupBox2.ForeColor = SystemColors.ButtonFace;
            groupBox2.Location = new Point(632, 16);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(531, 133);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cliente";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(216, 33);
            label5.Name = "label5";
            label5.Size = new Size(72, 29);
            label5.TabIndex = 30;
            label5.Text = "Nombre";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(43, 33);
            label6.Name = "label6";
            label6.Size = new Size(42, 29);
            label6.TabIndex = 29;
            label6.Text = "DNI";
            // 
            // ibBotonBuscarClienteVenta
            // 
            ibBotonBuscarClienteVenta.Cursor = Cursors.Hand;
            ibBotonBuscarClienteVenta.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            ibBotonBuscarClienteVenta.ForeColor = SystemColors.ActiveCaptionText;
            ibBotonBuscarClienteVenta.IconChar = FontAwesome.Sharp.IconChar.Search;
            ibBotonBuscarClienteVenta.IconColor = Color.Black;
            ibBotonBuscarClienteVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibBotonBuscarClienteVenta.IconSize = 30;
            ibBotonBuscarClienteVenta.Location = new Point(393, 44);
            ibBotonBuscarClienteVenta.Margin = new Padding(3, 4, 3, 4);
            ibBotonBuscarClienteVenta.Name = "ibBotonBuscarClienteVenta";
            ibBotonBuscarClienteVenta.Size = new Size(120, 64);
            ibBotonBuscarClienteVenta.TabIndex = 24;
            ibBotonBuscarClienteVenta.Text = "Buscar";
            ibBotonBuscarClienteVenta.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibBotonBuscarClienteVenta.UseVisualStyleBackColor = true;
            ibBotonBuscarClienteVenta.Click += ibBotonBuscarClienteVenta_Click;
            // 
            // tbNombreClienteVenta
            // 
            tbNombreClienteVenta.Font = new Font("Segoe UI", 9F);
            tbNombreClienteVenta.Location = new Point(131, 69);
            tbNombreClienteVenta.Margin = new Padding(3, 4, 3, 4);
            tbNombreClienteVenta.Name = "tbNombreClienteVenta";
            tbNombreClienteVenta.Size = new Size(239, 27);
            tbNombreClienteVenta.TabIndex = 1;
            // 
            // tbDniClienteVenta
            // 
            tbDniClienteVenta.Font = new Font("Segoe UI", 9F);
            tbDniClienteVenta.Location = new Point(21, 69);
            tbDniClienteVenta.Margin = new Padding(3, 4, 3, 4);
            tbDniClienteVenta.Name = "tbDniClienteVenta";
            tbDniClienteVenta.Size = new Size(81, 27);
            tbDniClienteVenta.TabIndex = 0;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.Transparent;
            label12.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label12.ForeColor = SystemColors.ButtonFace;
            label12.Location = new Point(66, 141);
            label12.Name = "label12";
            label12.Size = new Size(61, 29);
            label12.TabIndex = 30;
            label12.Text = "Borrar";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.Transparent;
            label11.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label11.ForeColor = SystemColors.ButtonFace;
            label11.Location = new Point(61, 23);
            label11.Name = "label11";
            label11.Size = new Size(72, 29);
            label11.TabIndex = 29;
            label11.Text = "Guardar";
            // 
            // ibBotonBorrarVenta
            // 
            ibBotonBorrarVenta.Cursor = Cursors.Hand;
            ibBotonBorrarVenta.IconChar = FontAwesome.Sharp.IconChar.Trash;
            ibBotonBorrarVenta.IconColor = Color.Black;
            ibBotonBorrarVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibBotonBorrarVenta.IconSize = 40;
            ibBotonBorrarVenta.Location = new Point(37, 177);
            ibBotonBorrarVenta.Margin = new Padding(3, 4, 3, 4);
            ibBotonBorrarVenta.Name = "ibBotonBorrarVenta";
            ibBotonBorrarVenta.Size = new Size(114, 57);
            ibBotonBorrarVenta.TabIndex = 28;
            ibBotonBorrarVenta.UseVisualStyleBackColor = true;
            ibBotonBorrarVenta.Click += ibBotonBorrarVenta_Click;
            // 
            // ibBotonGuardarVenta
            // 
            ibBotonGuardarVenta.Cursor = Cursors.Hand;
            ibBotonGuardarVenta.IconChar = FontAwesome.Sharp.IconChar.Save;
            ibBotonGuardarVenta.IconColor = Color.Black;
            ibBotonGuardarVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibBotonGuardarVenta.IconSize = 40;
            ibBotonGuardarVenta.Location = new Point(37, 56);
            ibBotonGuardarVenta.Margin = new Padding(3, 4, 3, 4);
            ibBotonGuardarVenta.Name = "ibBotonGuardarVenta";
            ibBotonGuardarVenta.Size = new Size(114, 57);
            ibBotonGuardarVenta.TabIndex = 27;
            ibBotonGuardarVenta.UseVisualStyleBackColor = true;
            ibBotonGuardarVenta.Click += ibBotonGuardarVenta_Click;
            // 
            // groupBox3
            // 
            groupBox3.BackColor = Color.FromArgb(0, 0, 64);
            groupBox3.Controls.Add(ibBotonAgregarProductoVenta);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(tbCantidadProductoVenta);
            groupBox3.Controls.Add(tbPrecioVtaProductoVenta);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(tbStockProductoVenta);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(ibBotonBuscarProductoVenta);
            groupBox3.Controls.Add(tbDescripcionProductoVenta);
            groupBox3.Controls.Add(tbNombreProductoVenta);
            groupBox3.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            groupBox3.ForeColor = SystemColors.ButtonFace;
            groupBox3.Location = new Point(14, 169);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(593, 251);
            groupBox3.TabIndex = 26;
            groupBox3.TabStop = false;
            groupBox3.Text = "Productos";
            // 
            // ibBotonAgregarProductoVenta
            // 
            ibBotonAgregarProductoVenta.Cursor = Cursors.Hand;
            ibBotonAgregarProductoVenta.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            ibBotonAgregarProductoVenta.ForeColor = SystemColors.ActiveCaptionText;
            ibBotonAgregarProductoVenta.IconChar = FontAwesome.Sharp.IconChar.PlusSquare;
            ibBotonAgregarProductoVenta.IconColor = Color.Black;
            ibBotonAgregarProductoVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibBotonAgregarProductoVenta.IconSize = 26;
            ibBotonAgregarProductoVenta.Location = new Point(440, 153);
            ibBotonAgregarProductoVenta.Margin = new Padding(3, 4, 3, 4);
            ibBotonAgregarProductoVenta.Name = "ibBotonAgregarProductoVenta";
            ibBotonAgregarProductoVenta.Size = new Size(126, 64);
            ibBotonAgregarProductoVenta.TabIndex = 35;
            ibBotonAgregarProductoVenta.Text = "Agregar";
            ibBotonAgregarProductoVenta.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibBotonAgregarProductoVenta.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ButtonFace;
            label9.Location = new Point(299, 141);
            label9.Name = "label9";
            label9.Size = new Size(76, 29);
            label9.TabIndex = 34;
            label9.Text = "Cantidad";
            // 
            // tbCantidadProductoVenta
            // 
            tbCantidadProductoVenta.Font = new Font("Segoe UI", 9F);
            tbCantidadProductoVenta.Location = new Point(299, 177);
            tbCantidadProductoVenta.Margin = new Padding(3, 4, 3, 4);
            tbCantidadProductoVenta.Name = "tbCantidadProductoVenta";
            tbCantidadProductoVenta.Size = new Size(84, 27);
            tbCantidadProductoVenta.TabIndex = 33;
            // 
            // tbPrecioVtaProductoVenta
            // 
            tbPrecioVtaProductoVenta.Font = new Font("Segoe UI", 9F);
            tbPrecioVtaProductoVenta.Location = new Point(133, 177);
            tbPrecioVtaProductoVenta.Margin = new Padding(3, 4, 3, 4);
            tbPrecioVtaProductoVenta.Name = "tbPrecioVtaProductoVenta";
            tbPrecioVtaProductoVenta.Size = new Size(105, 27);
            tbPrecioVtaProductoVenta.TabIndex = 32;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(131, 141);
            label7.Name = "label7";
            label7.Size = new Size(123, 29);
            label7.TabIndex = 31;
            label7.Text = "Precio de venta";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ButtonFace;
            label8.Location = new Point(37, 143);
            label8.Name = "label8";
            label8.Size = new Size(55, 29);
            label8.TabIndex = 30;
            label8.Text = "Stock";
            // 
            // tbStockProductoVenta
            // 
            tbStockProductoVenta.Font = new Font("Segoe UI", 9F);
            tbStockProductoVenta.Location = new Point(19, 177);
            tbStockProductoVenta.Margin = new Padding(3, 4, 3, 4);
            tbStockProductoVenta.Name = "tbStockProductoVenta";
            tbStockProductoVenta.Size = new Size(84, 27);
            tbStockProductoVenta.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(229, 33);
            label1.Name = "label1";
            label1.Size = new Size(98, 29);
            label1.TabIndex = 27;
            label1.Text = "Descripcion";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(30, 35);
            label2.Name = "label2";
            label2.Size = new Size(72, 29);
            label2.TabIndex = 26;
            label2.Text = "Nombre";
            // 
            // ibBotonBuscarProductoVenta
            // 
            ibBotonBuscarProductoVenta.Cursor = Cursors.Hand;
            ibBotonBuscarProductoVenta.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            ibBotonBuscarProductoVenta.ForeColor = SystemColors.ActiveCaptionText;
            ibBotonBuscarProductoVenta.IconChar = FontAwesome.Sharp.IconChar.Search;
            ibBotonBuscarProductoVenta.IconColor = Color.Black;
            ibBotonBuscarProductoVenta.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ibBotonBuscarProductoVenta.IconSize = 30;
            ibBotonBuscarProductoVenta.Location = new Point(440, 44);
            ibBotonBuscarProductoVenta.Margin = new Padding(3, 4, 3, 4);
            ibBotonBuscarProductoVenta.Name = "ibBotonBuscarProductoVenta";
            ibBotonBuscarProductoVenta.Size = new Size(126, 64);
            ibBotonBuscarProductoVenta.TabIndex = 25;
            ibBotonBuscarProductoVenta.Text = "Buscar";
            ibBotonBuscarProductoVenta.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibBotonBuscarProductoVenta.UseVisualStyleBackColor = true;
            // 
            // tbDescripcionProductoVenta
            // 
            tbDescripcionProductoVenta.Font = new Font("Segoe UI", 9F);
            tbDescripcionProductoVenta.Location = new Point(131, 69);
            tbDescripcionProductoVenta.Margin = new Padding(3, 4, 3, 4);
            tbDescripcionProductoVenta.Name = "tbDescripcionProductoVenta";
            tbDescripcionProductoVenta.Size = new Size(290, 27);
            tbDescripcionProductoVenta.TabIndex = 1;
            // 
            // tbNombreProductoVenta
            // 
            tbNombreProductoVenta.Font = new Font("Segoe UI", 9F);
            tbNombreProductoVenta.Location = new Point(19, 69);
            tbNombreProductoVenta.Margin = new Padding(3, 4, 3, 4);
            tbNombreProductoVenta.Name = "tbNombreProductoVenta";
            tbNombreProductoVenta.Size = new Size(84, 27);
            tbNombreProductoVenta.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.FromArgb(0, 0, 64);
            groupBox4.Controls.Add(dtpFechaVenta);
            groupBox4.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            groupBox4.ForeColor = SystemColors.ButtonFace;
            groupBox4.Location = new Point(632, 169);
            groupBox4.Margin = new Padding(3, 4, 3, 4);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(3, 4, 3, 4);
            groupBox4.Size = new Size(337, 121);
            groupBox4.TabIndex = 29;
            groupBox4.TabStop = false;
            groupBox4.Text = "Fecha";
            // 
            // dtpFechaVenta
            // 
            dtpFechaVenta.Font = new Font("Segoe UI", 9F);
            dtpFechaVenta.Location = new Point(21, 56);
            dtpFechaVenta.Margin = new Padding(3, 4, 3, 4);
            dtpFechaVenta.Name = "dtpFechaVenta";
            dtpFechaVenta.Size = new Size(228, 27);
            dtpFechaVenta.TabIndex = 0;
            // 
            // groupBox5
            // 
            groupBox5.BackColor = Color.FromArgb(0, 0, 64);
            groupBox5.Controls.Add(cbTipoFacturaVenta);
            groupBox5.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            groupBox5.ForeColor = SystemColors.ButtonFace;
            groupBox5.Location = new Point(632, 299);
            groupBox5.Margin = new Padding(3, 4, 3, 4);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 4, 3, 4);
            groupBox5.Size = new Size(337, 120);
            groupBox5.TabIndex = 30;
            groupBox5.TabStop = false;
            groupBox5.Text = "Factura";
            // 
            // cbTipoFacturaVenta
            // 
            cbTipoFacturaVenta.DropDownStyle = ComboBoxStyle.DropDownList;
            cbTipoFacturaVenta.Font = new Font("Segoe UI", 9F);
            cbTipoFacturaVenta.FormattingEnabled = true;
            cbTipoFacturaVenta.Items.AddRange(new object[] { "A", "B", "C", "E", "M", "T" });
            cbTipoFacturaVenta.Location = new Point(21, 48);
            cbTipoFacturaVenta.Margin = new Padding(3, 4, 3, 4);
            cbTipoFacturaVenta.Name = "cbTipoFacturaVenta";
            cbTipoFacturaVenta.Size = new Size(228, 28);
            cbTipoFacturaVenta.TabIndex = 0;
            cbTipoFacturaVenta.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // groupBox6
            // 
            groupBox6.BackColor = Color.FromArgb(0, 0, 64);
            groupBox6.Controls.Add(ibBotonBorrarVenta);
            groupBox6.Controls.Add(ibBotonGuardarVenta);
            groupBox6.Controls.Add(label11);
            groupBox6.Controls.Add(label12);
            groupBox6.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            groupBox6.ForeColor = SystemColors.ButtonFace;
            groupBox6.Location = new Point(976, 169);
            groupBox6.Margin = new Padding(3, 4, 3, 4);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(3, 4, 3, 4);
            groupBox6.Size = new Size(187, 251);
            groupBox6.TabIndex = 31;
            groupBox6.TabStop = false;
            // 
            // dgvVentas
            // 
            dgvVentas.BackgroundColor = Color.SlateGray;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvVentas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvVentas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentas.Columns.AddRange(new DataGridViewColumn[] { codIdProducto, colDescripcion, colCantidad, colSubtotal, totalVenta, fechaVenta });
            dgvVentas.Location = new Point(14, 477);
            dgvVentas.Margin = new Padding(3, 4, 3, 4);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.Size = new Size(1149, 127);
            dgvVentas.TabIndex = 32;
            dgvVentas.CellContentClick += dataGridView1_CellContentClick;
            // 
            // codIdProducto
            // 
            codIdProducto.HeaderText = "Nombre";
            codIdProducto.MinimumWidth = 6;
            codIdProducto.Name = "codIdProducto";
            codIdProducto.Width = 125;
            // 
            // colDescripcion
            // 
            colDescripcion.HeaderText = "Descripcion";
            colDescripcion.MinimumWidth = 320;
            colDescripcion.Name = "colDescripcion";
            colDescripcion.Width = 470;
            // 
            // colCantidad
            // 
            colCantidad.HeaderText = "Cantidad";
            colCantidad.MinimumWidth = 6;
            colCantidad.Name = "colCantidad";
            colCantidad.Width = 125;
            // 
            // colSubtotal
            // 
            colSubtotal.HeaderText = "Subtotal";
            colSubtotal.MinimumWidth = 6;
            colSubtotal.Name = "colSubtotal";
            colSubtotal.Width = 125;
            // 
            // totalVenta
            // 
            totalVenta.HeaderText = "Total Venta";
            totalVenta.MinimumWidth = 6;
            totalVenta.Name = "totalVenta";
            totalVenta.Width = 125;
            // 
            // fechaVenta
            // 
            fechaVenta.HeaderText = "Fecha";
            fechaVenta.MinimumWidth = 6;
            fechaVenta.Name = "fechaVenta";
            fechaVenta.Width = 125;
            // 
            // ventas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(1177, 699);
            Controls.Add(dgvVentas);
            Controls.Add(groupBox6);
            Controls.Add(groupBox5);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "ventas";
            Text = "ventas";
            Load += ventas_Load;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox tbNombreVendedorVenta;
        private TextBox tbDniVendedorVenta;
        private GroupBox groupBox2;
        private TextBox tbNombreClienteVenta;
        private TextBox tbDniClienteVenta;
        private FontAwesome.Sharp.IconButton ibBotonBuscarClienteVenta;
        private Label label12;
        private Label label11;
        private FontAwesome.Sharp.IconButton ibBotonBorrarVenta;
        private FontAwesome.Sharp.IconButton ibBotonGuardarVenta;
        private GroupBox groupBox3;
        private FontAwesome.Sharp.IconButton ibBotonBuscarProductoVenta;
        private TextBox tbDescripcionProductoVenta;
        private TextBox tbNombreProductoVenta;
        private Label label4;
        private Label label3;
        private Label label5;
        private Label label6;
        private Label label9;
        private TextBox tbCantidadProductoVenta;
        private TextBox tbPrecioVtaProductoVenta;
        private Label label7;
        private Label label8;
        private TextBox tbStockProductoVenta;
        private Label label1;
        private Label label2;
        private FontAwesome.Sharp.IconButton ibBotonAgregarProductoVenta;
        private GroupBox groupBox4;
        private DateTimePicker dtpFechaVenta;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private ComboBox cbTipoFacturaVenta;
        private DataGridView dgvVentas;
        private DataGridViewTextBoxColumn codIdProducto;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colCantidad;
        private DataGridViewTextBoxColumn colSubtotal;
        private DataGridViewTextBoxColumn totalVenta;
        private DataGridViewTextBoxColumn fechaVenta;
    }
}