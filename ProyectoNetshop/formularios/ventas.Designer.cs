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
            tbIdVendedorVenta = new TextBox();
            label4 = new Label();
            label3 = new Label();
            tbNombreVendedorVenta = new TextBox();
            tbDniVendedorVenta = new TextBox();
            groupBox2 = new GroupBox();
            tbIdClienteVenta = new TextBox();
            tbEmailClienteVenta = new TextBox();
            label14 = new Label();
            label5 = new Label();
            label6 = new Label();
            tbNombreClienteVenta = new TextBox();
            tbDniClienteVenta = new TextBox();
            label12 = new Label();
            label11 = new Label();
            ibBotonBorrarVenta = new FontAwesome.Sharp.IconButton();
            ibBotonGuardarVenta = new FontAwesome.Sharp.IconButton();
            groupBox3 = new GroupBox();
            gbEstadoVenta = new GroupBox();
            rbPendienteVenta = new RadioButton();
            tbCategoriaProductoVenta = new TextBox();
            label13 = new Label();
            label10 = new Label();
            label1 = new Label();
            tbIdProductoVenta = new TextBox();
            pbImagenProductoVenta = new PictureBox();
            tbMarcaProductoVenta = new TextBox();
            ibBotonAgregarProductoVenta = new FontAwesome.Sharp.IconButton();
            label9 = new Label();
            tbCantidadProductoVenta = new TextBox();
            tbPrecioVtaProductoVenta = new TextBox();
            label7 = new Label();
            label8 = new Label();
            tbStockProductoVenta = new TextBox();
            label2 = new Label();
            tbNombreProductoVenta = new TextBox();
            groupBox4 = new GroupBox();
            dtpFechaVenta = new DateTimePicker();
            groupBox5 = new GroupBox();
            cbTipoFacturaVenta = new ComboBox();
            groupBox6 = new GroupBox();
            dgvVentas = new DataGridView();
            label15 = new Label();
            lbTotalVendidoVenta = new Label();
            bListaProductosVenta = new Button();
            bListaClientesVenta = new Button();
            cbVentaProductoVendidos = new CheckBox();
            cbVentaProductoCancelados = new CheckBox();
            cbVentaProductoPendientes = new CheckBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            gbEstadoVenta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbImagenProductoVenta).BeginInit();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(0, 0, 64);
            groupBox1.Controls.Add(tbIdVendedorVenta);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(tbNombreVendedorVenta);
            groupBox1.Controls.Add(tbDniVendedorVenta);
            groupBox1.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            groupBox1.ForeColor = SystemColors.ButtonFace;
            groupBox1.Location = new Point(14, 60);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(593, 133);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            groupBox1.Text = "Vendedor";
            // 
            // tbIdVendedorVenta
            // 
            tbIdVendedorVenta.Font = new Font("Segoe UI", 9F);
            tbIdVendedorVenta.Location = new Point(518, 70);
            tbIdVendedorVenta.Multiline = true;
            tbIdVendedorVenta.Name = "tbIdVendedorVenta";
            tbIdVendedorVenta.Size = new Size(51, 27);
            tbIdVendedorVenta.TabIndex = 29;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(273, 38);
            label4.Name = "label4";
            label4.Size = new Size(145, 29);
            label4.TabIndex = 28;
            label4.Text = "Nombre Completo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(54, 37);
            label3.Name = "label3";
            label3.Size = new Size(42, 29);
            label3.TabIndex = 27;
            label3.Text = "DNI";
            // 
            // tbNombreVendedorVenta
            // 
            tbNombreVendedorVenta.Font = new Font("Segoe UI", 9F);
            tbNombreVendedorVenta.Location = new Point(203, 70);
            tbNombreVendedorVenta.Margin = new Padding(3, 4, 3, 4);
            tbNombreVendedorVenta.Name = "tbNombreVendedorVenta";
            tbNombreVendedorVenta.ReadOnly = true;
            tbNombreVendedorVenta.Size = new Size(290, 27);
            tbNombreVendedorVenta.TabIndex = 1;
            tbNombreVendedorVenta.TextChanged += tbNombreVendedorVenta_TextChanged;
            // 
            // tbDniVendedorVenta
            // 
            tbDniVendedorVenta.Font = new Font("Segoe UI", 9F);
            tbDniVendedorVenta.Location = new Point(26, 69);
            tbDniVendedorVenta.Margin = new Padding(3, 4, 3, 4);
            tbDniVendedorVenta.Name = "tbDniVendedorVenta";
            tbDniVendedorVenta.ReadOnly = true;
            tbDniVendedorVenta.Size = new Size(100, 27);
            tbDniVendedorVenta.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = Color.FromArgb(0, 0, 64);
            groupBox2.Controls.Add(tbIdClienteVenta);
            groupBox2.Controls.Add(tbEmailClienteVenta);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(tbNombreClienteVenta);
            groupBox2.Controls.Add(tbDniClienteVenta);
            groupBox2.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            groupBox2.ForeColor = SystemColors.ButtonFace;
            groupBox2.Location = new Point(632, 60);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(531, 133);
            groupBox2.TabIndex = 2;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cliente";
            // 
            // tbIdClienteVenta
            // 
            tbIdClienteVenta.Font = new Font("Segoe UI", 9F);
            tbIdClienteVenta.Location = new Point(420, 100);
            tbIdClienteVenta.Multiline = true;
            tbIdClienteVenta.Name = "tbIdClienteVenta";
            tbIdClienteVenta.Size = new Size(51, 26);
            tbIdClienteVenta.TabIndex = 33;
            // 
            // tbEmailClienteVenta
            // 
            tbEmailClienteVenta.Font = new Font("Segoe UI", 9F);
            tbEmailClienteVenta.Location = new Point(172, 87);
            tbEmailClienteVenta.Margin = new Padding(3, 4, 3, 4);
            tbEmailClienteVenta.Multiline = true;
            tbEmailClienteVenta.Name = "tbEmailClienteVenta";
            tbEmailClienteVenta.Size = new Size(200, 27);
            tbEmailClienteVenta.TabIndex = 1;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(20, 85);
            label14.Name = "label14";
            label14.Size = new Size(148, 29);
            label14.TabIndex = 31;
            label14.Text = "Correo Electronico";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Transparent;
            label5.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(21, 36);
            label5.Name = "label5";
            label5.Size = new Size(145, 29);
            label5.TabIndex = 30;
            label5.Text = "Nombre Completo";
            label5.Click += label5_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.Transparent;
            label6.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(426, 37);
            label6.Name = "label6";
            label6.Size = new Size(42, 29);
            label6.TabIndex = 29;
            label6.Text = "DNI";
            // 
            // tbNombreClienteVenta
            // 
            tbNombreClienteVenta.Font = new Font("Segoe UI", 9F);
            tbNombreClienteVenta.Location = new Point(172, 37);
            tbNombreClienteVenta.Margin = new Padding(3, 4, 3, 4);
            tbNombreClienteVenta.Name = "tbNombreClienteVenta";
            tbNombreClienteVenta.Size = new Size(200, 27);
            tbNombreClienteVenta.TabIndex = 1;
            tbNombreClienteVenta.TextChanged += tbNombreClienteVenta_TextChanged;
            // 
            // tbDniClienteVenta
            // 
            tbDniClienteVenta.Font = new Font("Segoe UI", 9F);
            tbDniClienteVenta.Location = new Point(400, 69);
            tbDniClienteVenta.Margin = new Padding(3, 4, 3, 4);
            tbDniClienteVenta.Name = "tbDniClienteVenta";
            tbDniClienteVenta.Size = new Size(95, 27);
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
            groupBox3.Controls.Add(gbEstadoVenta);
            groupBox3.Controls.Add(tbCategoriaProductoVenta);
            groupBox3.Controls.Add(label13);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label1);
            groupBox3.Controls.Add(tbIdProductoVenta);
            groupBox3.Controls.Add(pbImagenProductoVenta);
            groupBox3.Controls.Add(tbMarcaProductoVenta);
            groupBox3.Controls.Add(ibBotonAgregarProductoVenta);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(tbCantidadProductoVenta);
            groupBox3.Controls.Add(tbPrecioVtaProductoVenta);
            groupBox3.Controls.Add(label7);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(tbStockProductoVenta);
            groupBox3.Controls.Add(label2);
            groupBox3.Controls.Add(tbNombreProductoVenta);
            groupBox3.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            groupBox3.ForeColor = SystemColors.ButtonFace;
            groupBox3.Location = new Point(14, 213);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(593, 260);
            groupBox3.TabIndex = 26;
            groupBox3.TabStop = false;
            groupBox3.Text = "Productos";
            groupBox3.Enter += groupBox3_Enter;
            // 
            // gbEstadoVenta
            // 
            gbEstadoVenta.Controls.Add(rbPendienteVenta);
            gbEstadoVenta.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            gbEstadoVenta.ForeColor = SystemColors.ButtonFace;
            gbEstadoVenta.Location = new Point(443, 177);
            gbEstadoVenta.Margin = new Padding(3, 4, 3, 4);
            gbEstadoVenta.Name = "gbEstadoVenta";
            gbEstadoVenta.Padding = new Padding(3, 4, 3, 4);
            gbEstadoVenta.Size = new Size(126, 67);
            gbEstadoVenta.TabIndex = 42;
            gbEstadoVenta.TabStop = false;
            gbEstadoVenta.Text = "Estado";
            gbEstadoVenta.Visible = false;
            // 
            // rbPendienteVenta
            // 
            rbPendienteVenta.AutoSize = true;
            rbPendienteVenta.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            rbPendienteVenta.ForeColor = SystemColors.ButtonFace;
            rbPendienteVenta.Location = new Point(10, 24);
            rbPendienteVenta.Margin = new Padding(3, 4, 3, 4);
            rbPendienteVenta.Name = "rbPendienteVenta";
            rbPendienteVenta.Size = new Size(105, 33);
            rbPendienteVenta.TabIndex = 1;
            rbPendienteVenta.Text = "Pendiente";
            rbPendienteVenta.UseVisualStyleBackColor = true;
            // 
            // tbCategoriaProductoVenta
            // 
            tbCategoriaProductoVenta.Font = new Font("Segoe UI", 9F);
            tbCategoriaProductoVenta.Location = new Point(136, 136);
            tbCategoriaProductoVenta.Multiline = true;
            tbCategoriaProductoVenta.Name = "tbCategoriaProductoVenta";
            tbCategoriaProductoVenta.ReadOnly = true;
            tbCategoriaProductoVenta.Size = new Size(111, 27);
            tbCategoriaProductoVenta.TabIndex = 41;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(37, 177);
            label13.Name = "label13";
            label13.Size = new Size(58, 29);
            label13.TabIndex = 33;
            label13.Text = "Marca";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(26, 134);
            label10.Name = "label10";
            label10.Size = new Size(82, 29);
            label10.TabIndex = 40;
            label10.Text = "Categoria";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 38);
            label1.Name = "label1";
            label1.Size = new Size(30, 29);
            label1.TabIndex = 39;
            label1.Text = "ID";
            // 
            // tbIdProductoVenta
            // 
            tbIdProductoVenta.Font = new Font("Segoe UI", 9F);
            tbIdProductoVenta.Location = new Point(26, 70);
            tbIdProductoVenta.Multiline = true;
            tbIdProductoVenta.Name = "tbIdProductoVenta";
            tbIdProductoVenta.Size = new Size(42, 27);
            tbIdProductoVenta.TabIndex = 38;
            // 
            // pbImagenProductoVenta
            // 
            pbImagenProductoVenta.Image = Properties.Resources.producto_defecto;
            pbImagenProductoVenta.Location = new Point(265, 35);
            pbImagenProductoVenta.Name = "pbImagenProductoVenta";
            pbImagenProductoVenta.Size = new Size(156, 99);
            pbImagenProductoVenta.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImagenProductoVenta.TabIndex = 37;
            pbImagenProductoVenta.TabStop = false;
            // 
            // tbMarcaProductoVenta
            // 
            tbMarcaProductoVenta.Font = new Font("Segoe UI", 9F);
            tbMarcaProductoVenta.Location = new Point(136, 176);
            tbMarcaProductoVenta.Multiline = true;
            tbMarcaProductoVenta.Name = "tbMarcaProductoVenta";
            tbMarcaProductoVenta.ReadOnly = true;
            tbMarcaProductoVenta.Size = new Size(111, 27);
            tbMarcaProductoVenta.TabIndex = 36;
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
            ibBotonAgregarProductoVenta.Location = new Point(443, 35);
            ibBotonAgregarProductoVenta.Margin = new Padding(3, 4, 3, 4);
            ibBotonAgregarProductoVenta.Name = "ibBotonAgregarProductoVenta";
            ibBotonAgregarProductoVenta.Size = new Size(126, 64);
            ibBotonAgregarProductoVenta.TabIndex = 35;
            ibBotonAgregarProductoVenta.Text = "Agregar";
            ibBotonAgregarProductoVenta.TextImageRelation = TextImageRelation.ImageBeforeText;
            ibBotonAgregarProductoVenta.UseVisualStyleBackColor = true;
            ibBotonAgregarProductoVenta.Click += ibBotonAgregarProductoVenta_Click_1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.Transparent;
            label9.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label9.ForeColor = SystemColors.ButtonFace;
            label9.Location = new Point(277, 176);
            label9.Name = "label9";
            label9.Size = new Size(76, 29);
            label9.TabIndex = 34;
            label9.Text = "Cantidad";
            // 
            // tbCantidadProductoVenta
            // 
            tbCantidadProductoVenta.Font = new Font("Segoe UI", 9F);
            tbCantidadProductoVenta.Location = new Point(356, 176);
            tbCantidadProductoVenta.Margin = new Padding(3, 4, 3, 4);
            tbCantidadProductoVenta.Name = "tbCantidadProductoVenta";
            tbCantidadProductoVenta.Size = new Size(60, 27);
            tbCantidadProductoVenta.TabIndex = 33;
            // 
            // tbPrecioVtaProductoVenta
            // 
            tbPrecioVtaProductoVenta.Font = new Font("Segoe UI", 9F);
            tbPrecioVtaProductoVenta.Location = new Point(136, 217);
            tbPrecioVtaProductoVenta.Margin = new Padding(3, 4, 3, 4);
            tbPrecioVtaProductoVenta.Name = "tbPrecioVtaProductoVenta";
            tbPrecioVtaProductoVenta.ReadOnly = true;
            tbPrecioVtaProductoVenta.Size = new Size(111, 27);
            tbPrecioVtaProductoVenta.TabIndex = 32;
            tbPrecioVtaProductoVenta.TextChanged += tbPrecioVtaProductoVenta_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(6, 215);
            label7.Name = "label7";
            label7.Size = new Size(126, 29);
            label7.TabIndex = 31;
            label7.Text = "Precio de Venta";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.Transparent;
            label8.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label8.ForeColor = SystemColors.ButtonFace;
            label8.Location = new Point(286, 217);
            label8.Name = "label8";
            label8.Size = new Size(55, 29);
            label8.TabIndex = 30;
            label8.Text = "Stock";
            // 
            // tbStockProductoVenta
            // 
            tbStockProductoVenta.Font = new Font("Segoe UI", 9F);
            tbStockProductoVenta.Location = new Point(356, 217);
            tbStockProductoVenta.Margin = new Padding(3, 4, 3, 4);
            tbStockProductoVenta.Name = "tbStockProductoVenta";
            tbStockProductoVenta.ReadOnly = true;
            tbStockProductoVenta.Size = new Size(60, 27);
            tbStockProductoVenta.TabIndex = 28;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(131, 38);
            label2.Name = "label2";
            label2.Size = new Size(72, 29);
            label2.TabIndex = 26;
            label2.Text = "Nombre";
            // 
            // tbNombreProductoVenta
            // 
            tbNombreProductoVenta.Font = new Font("Segoe UI", 9F);
            tbNombreProductoVenta.Location = new Point(91, 70);
            tbNombreProductoVenta.Margin = new Padding(3, 4, 3, 4);
            tbNombreProductoVenta.Name = "tbNombreProductoVenta";
            tbNombreProductoVenta.Size = new Size(156, 27);
            tbNombreProductoVenta.TabIndex = 0;
            // 
            // groupBox4
            // 
            groupBox4.BackColor = Color.FromArgb(0, 0, 64);
            groupBox4.Controls.Add(dtpFechaVenta);
            groupBox4.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            groupBox4.ForeColor = SystemColors.ButtonFace;
            groupBox4.Location = new Point(632, 213);
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
            groupBox5.Location = new Point(632, 359);
            groupBox5.Margin = new Padding(3, 4, 3, 4);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(3, 4, 3, 4);
            groupBox5.Size = new Size(337, 114);
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
            cbTipoFacturaVenta.Location = new Point(21, 53);
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
            groupBox6.Location = new Point(976, 213);
            groupBox6.Margin = new Padding(3, 4, 3, 4);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(3, 4, 3, 4);
            groupBox6.Size = new Size(187, 260);
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
            dgvVentas.Location = new Point(14, 540);
            dgvVentas.Margin = new Padding(3, 4, 3, 4);
            dgvVentas.Name = "dgvVentas";
            dgvVentas.RowHeadersWidth = 51;
            dgvVentas.Size = new Size(1149, 233);
            dgvVentas.TabIndex = 32;
            dgvVentas.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            label15.ForeColor = SystemColors.ButtonFace;
            label15.Location = new Point(955, 775);
            label15.Name = "label15";
            label15.Size = new Size(81, 34);
            label15.TabIndex = 36;
            label15.Text = "TOTAL:";
            // 
            // lbTotalVendidoVenta
            // 
            lbTotalVendidoVenta.AutoSize = true;
            lbTotalVendidoVenta.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lbTotalVendidoVenta.ForeColor = SystemColors.ButtonFace;
            lbTotalVendidoVenta.Location = new Point(1032, 775);
            lbTotalVendidoVenta.Name = "lbTotalVendidoVenta";
            lbTotalVendidoVenta.Size = new Size(63, 34);
            lbTotalVendidoVenta.TabIndex = 37;
            lbTotalVendidoVenta.Text = "$0,00";
            lbTotalVendidoVenta.Click += lbTotalVendidoVenta_Click;
            // 
            // bListaProductosVenta
            // 
            bListaProductosVenta.Cursor = Cursors.Hand;
            bListaProductosVenta.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            bListaProductosVenta.ForeColor = SystemColors.ActiveCaptionText;
            bListaProductosVenta.Location = new Point(1037, 12);
            bListaProductosVenta.Name = "bListaProductosVenta";
            bListaProductosVenta.Size = new Size(126, 48);
            bListaProductosVenta.TabIndex = 30;
            bListaProductosVenta.Text = "Productos";
            bListaProductosVenta.UseVisualStyleBackColor = true;
            // 
            // bListaClientesVenta
            // 
            bListaClientesVenta.Cursor = Cursors.Hand;
            bListaClientesVenta.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            bListaClientesVenta.ForeColor = SystemColors.ActiveCaptionText;
            bListaClientesVenta.Location = new Point(878, 12);
            bListaClientesVenta.Name = "bListaClientesVenta";
            bListaClientesVenta.Size = new Size(126, 48);
            bListaClientesVenta.TabIndex = 38;
            bListaClientesVenta.Text = "Clientes";
            bListaClientesVenta.UseVisualStyleBackColor = true;
            // 
            // cbVentaProductoVendidos
            // 
            cbVentaProductoVendidos.AutoSize = true;
            cbVentaProductoVendidos.Cursor = Cursors.Hand;
            cbVentaProductoVendidos.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            cbVentaProductoVendidos.ForeColor = SystemColors.ButtonFace;
            cbVentaProductoVendidos.Location = new Point(14, 505);
            cbVentaProductoVendidos.Name = "cbVentaProductoVendidos";
            cbVentaProductoVendidos.Size = new Size(101, 33);
            cbVentaProductoVendidos.TabIndex = 39;
            cbVentaProductoVendidos.Text = "Vendidos";
            cbVentaProductoVendidos.UseVisualStyleBackColor = true;
            // 
            // cbVentaProductoCancelados
            // 
            cbVentaProductoCancelados.AutoSize = true;
            cbVentaProductoCancelados.Cursor = Cursors.Hand;
            cbVentaProductoCancelados.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            cbVentaProductoCancelados.ForeColor = SystemColors.ButtonFace;
            cbVentaProductoCancelados.Location = new Point(131, 505);
            cbVentaProductoCancelados.Name = "cbVentaProductoCancelados";
            cbVentaProductoCancelados.Size = new Size(115, 33);
            cbVentaProductoCancelados.TabIndex = 40;
            cbVentaProductoCancelados.Text = "Cancelados";
            cbVentaProductoCancelados.UseVisualStyleBackColor = true;
            // 
            // cbVentaProductoPendientes
            // 
            cbVentaProductoPendientes.AutoSize = true;
            cbVentaProductoPendientes.Checked = true;
            cbVentaProductoPendientes.CheckState = CheckState.Checked;
            cbVentaProductoPendientes.Cursor = Cursors.Hand;
            cbVentaProductoPendientes.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            cbVentaProductoPendientes.ForeColor = SystemColors.ButtonFace;
            cbVentaProductoPendientes.Location = new Point(260, 505);
            cbVentaProductoPendientes.Name = "cbVentaProductoPendientes";
            cbVentaProductoPendientes.Size = new Size(113, 33);
            cbVentaProductoPendientes.TabIndex = 41;
            cbVentaProductoPendientes.Text = "Pendientes";
            cbVentaProductoPendientes.UseVisualStyleBackColor = true;
            // 
            // ventas
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(1200, 840);
            Controls.Add(cbVentaProductoPendientes);
            Controls.Add(cbVentaProductoCancelados);
            Controls.Add(cbVentaProductoVendidos);
            Controls.Add(bListaClientesVenta);
            Controls.Add(bListaProductosVenta);
            Controls.Add(lbTotalVendidoVenta);
            Controls.Add(label15);
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
            gbEstadoVenta.ResumeLayout(false);
            gbEstadoVenta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbImagenProductoVenta).EndInit();
            groupBox4.ResumeLayout(false);
            groupBox5.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvVentas).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox1;
        private TextBox tbNombreVendedorVenta;
        private TextBox tbDniVendedorVenta;
        private GroupBox groupBox2;
        private TextBox tbNombreClienteVenta;
        private TextBox tbDniClienteVenta;
        private Label label12;
        private Label label11;
        private FontAwesome.Sharp.IconButton ibBotonBorrarVenta;
        private FontAwesome.Sharp.IconButton ibBotonGuardarVenta;
        private GroupBox groupBox3;
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
        private Label label2;
        private FontAwesome.Sharp.IconButton ibBotonAgregarProductoVenta;
        private GroupBox groupBox4;
        private DateTimePicker dtpFechaVenta;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private ComboBox cbTipoFacturaVenta;
        private DataGridView dgvVentas;
        private TextBox tbMarcaProductoVenta;
        private Label label1;
        private TextBox tbIdProductoVenta;
        private PictureBox pbImagenProductoVenta;
        private Label label13;
        private Label label10;
        private TextBox tbCategoriaProductoVenta;
        private Label label14;
        private TextBox tbEmailClienteVenta;
        private GroupBox gbEstadoVenta;
        private RadioButton rbPendienteVenta;
        private Label label15;
        private Label lbTotalVendidoVenta;
        private TextBox tbIdVendedorVenta;
        private TextBox tbIdClienteVenta;
        private Button bListaProductosVenta;
        private Button bListaClientesVenta;
        private CheckBox cbVentaProductoVendidos;
        private CheckBox cbVentaProductoCancelados;
        private CheckBox cbVentaProductoPendientes;
    }
}