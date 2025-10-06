namespace ProyectoNetshop.formularios
{
    partial class CrudProductos
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            gbEstadoProducto = new GroupBox();
            rbProductoEliminadoSi = new RadioButton();
            rbProductoEliminadoNo = new RadioButton();
            lbPrecioVenta = new Label();
            tbPrecioVentaProducto = new TextBox();
            cbMarcaProducto = new ComboBox();
            lbMarca = new Label();
            lbCategoria = new Label();
            cbCategoriaProducto = new ComboBox();
            btnCargarImg = new FontAwesome.Sharp.IconButton();
            pbImagenProducto = new PictureBox();
            lbEliminar = new Label();
            lbGuardar = new Label();
            btnBorrarProducto = new FontAwesome.Sharp.IconButton();
            lbStock = new Label();
            tbStockProducto = new TextBox();
            lbDescripcion = new Label();
            tbDescripcionProducto = new TextBox();
            lbPrecio = new Label();
            tbPrecioProducto = new TextBox();
            lbNombre = new Label();
            btnGuardarProducto = new FontAwesome.Sharp.IconButton();
            tbNombreProducto = new TextBox();
            panel2 = new Panel();
            label1 = new Label();
            tbBusquedaNombreProducto = new TextBox();
            tbBusquedaPrecioMinProducto = new TextBox();
            tbBusquedaPrecioMaxProducto = new TextBox();
            cbInactivosProductos = new CheckBox();
            cbActivosProductos = new CheckBox();
            dgvProductos = new DataGridView();
            panel1.SuspendLayout();
            gbEstadoProducto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbImagenProducto).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(gbEstadoProducto);
            panel1.Controls.Add(lbPrecioVenta);
            panel1.Controls.Add(tbPrecioVentaProducto);
            panel1.Controls.Add(cbMarcaProducto);
            panel1.Controls.Add(lbMarca);
            panel1.Controls.Add(lbCategoria);
            panel1.Controls.Add(cbCategoriaProducto);
            panel1.Controls.Add(btnCargarImg);
            panel1.Controls.Add(pbImagenProducto);
            panel1.Controls.Add(lbEliminar);
            panel1.Controls.Add(lbGuardar);
            panel1.Controls.Add(btnBorrarProducto);
            panel1.Controls.Add(lbStock);
            panel1.Controls.Add(tbStockProducto);
            panel1.Controls.Add(lbDescripcion);
            panel1.Controls.Add(tbDescripcionProducto);
            panel1.Controls.Add(lbPrecio);
            panel1.Controls.Add(tbPrecioProducto);
            panel1.Controls.Add(lbNombre);
            panel1.Controls.Add(btnGuardarProducto);
            panel1.Controls.Add(tbNombreProducto);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.RightToLeft = RightToLeft.No;
            panel1.Size = new Size(1159, 292);
            panel1.TabIndex = 20;
            // 
            // gbEstadoProducto
            // 
            gbEstadoProducto.BackColor = Color.Transparent;
            gbEstadoProducto.Controls.Add(rbProductoEliminadoSi);
            gbEstadoProducto.Controls.Add(rbProductoEliminadoNo);
            gbEstadoProducto.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            gbEstadoProducto.ForeColor = SystemColors.ButtonFace;
            gbEstadoProducto.Location = new Point(389, 214);
            gbEstadoProducto.Margin = new Padding(3, 4, 3, 4);
            gbEstadoProducto.Name = "gbEstadoProducto";
            gbEstadoProducto.Padding = new Padding(3, 4, 3, 4);
            gbEstadoProducto.Size = new Size(209, 59);
            gbEstadoProducto.TabIndex = 36;
            gbEstadoProducto.TabStop = false;
            gbEstadoProducto.Text = "Eliminado";
            gbEstadoProducto.Visible = false;
            // 
            // rbProductoEliminadoSi
            // 
            rbProductoEliminadoSi.AutoSize = true;
            rbProductoEliminadoSi.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            rbProductoEliminadoSi.ForeColor = SystemColors.ButtonFace;
            rbProductoEliminadoSi.Location = new Point(19, 22);
            rbProductoEliminadoSi.Margin = new Padding(3, 4, 3, 4);
            rbProductoEliminadoSi.Name = "rbProductoEliminadoSi";
            rbProductoEliminadoSi.Size = new Size(48, 33);
            rbProductoEliminadoSi.TabIndex = 1;
            rbProductoEliminadoSi.Text = "Si";
            rbProductoEliminadoSi.UseVisualStyleBackColor = true;
            // 
            // rbProductoEliminadoNo
            // 
            rbProductoEliminadoNo.AutoSize = true;
            rbProductoEliminadoNo.Checked = true;
            rbProductoEliminadoNo.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            rbProductoEliminadoNo.ForeColor = SystemColors.ButtonFace;
            rbProductoEliminadoNo.Location = new Point(133, 22);
            rbProductoEliminadoNo.Margin = new Padding(3, 4, 3, 4);
            rbProductoEliminadoNo.Name = "rbProductoEliminadoNo";
            rbProductoEliminadoNo.Size = new Size(55, 33);
            rbProductoEliminadoNo.TabIndex = 21;
            rbProductoEliminadoNo.TabStop = true;
            rbProductoEliminadoNo.Text = "No";
            rbProductoEliminadoNo.UseVisualStyleBackColor = true;
            // 
            // lbPrecioVenta
            // 
            lbPrecioVenta.AutoSize = true;
            lbPrecioVenta.BackColor = Color.Transparent;
            lbPrecioVenta.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbPrecioVenta.ForeColor = SystemColors.ButtonFace;
            lbPrecioVenta.Location = new Point(66, 140);
            lbPrecioVenta.Name = "lbPrecioVenta";
            lbPrecioVenta.Size = new Size(147, 29);
            lbPrecioVenta.TabIndex = 35;
            lbPrecioVenta.Text = "Precio de venta (*)";
            // 
            // tbPrecioVentaProducto
            // 
            tbPrecioVentaProducto.Location = new Point(24, 173);
            tbPrecioVentaProducto.Margin = new Padding(3, 4, 3, 4);
            tbPrecioVentaProducto.Name = "tbPrecioVentaProducto";
            tbPrecioVentaProducto.Size = new Size(209, 27);
            tbPrecioVentaProducto.TabIndex = 34;
            tbPrecioVentaProducto.TextChanged += tbPrecioVenta_TextChanged;
            tbPrecioVentaProducto.KeyPress += tbPrecioVenta_KeyPress;
            // 
            // cbMarcaProducto
            // 
            cbMarcaProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMarcaProducto.FormattingEnabled = true;
            cbMarcaProducto.Location = new Point(24, 242);
            cbMarcaProducto.Margin = new Padding(3, 4, 3, 4);
            cbMarcaProducto.Name = "cbMarcaProducto";
            cbMarcaProducto.Size = new Size(209, 28);
            cbMarcaProducto.TabIndex = 33;
            cbMarcaProducto.SelectedIndexChanged += cbMarca_SelectedIndexChanged;
            // 
            // lbMarca
            // 
            lbMarca.AutoSize = true;
            lbMarca.BackColor = Color.Transparent;
            lbMarca.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbMarca.ForeColor = SystemColors.ButtonFace;
            lbMarca.Location = new Point(86, 209);
            lbMarca.Name = "lbMarca";
            lbMarca.Size = new Size(82, 29);
            lbMarca.TabIndex = 32;
            lbMarca.Text = "Marca (*)";
            // 
            // lbCategoria
            // 
            lbCategoria.AutoSize = true;
            lbCategoria.BackColor = Color.Transparent;
            lbCategoria.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbCategoria.ForeColor = SystemColors.ButtonFace;
            lbCategoria.Location = new Point(442, 140);
            lbCategoria.Name = "lbCategoria";
            lbCategoria.Size = new Size(106, 29);
            lbCategoria.TabIndex = 26;
            lbCategoria.Text = "Categoria (*)";
            // 
            // cbCategoriaProducto
            // 
            cbCategoriaProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategoriaProducto.FormattingEnabled = true;
            cbCategoriaProducto.Location = new Point(389, 173);
            cbCategoriaProducto.Margin = new Padding(3, 4, 3, 4);
            cbCategoriaProducto.Name = "cbCategoriaProducto";
            cbCategoriaProducto.Size = new Size(205, 28);
            cbCategoriaProducto.TabIndex = 25;
            cbCategoriaProducto.SelectedIndexChanged += cbCategoria_SelectedIndexChanged;
            // 
            // btnCargarImg
            // 
            btnCargarImg.Cursor = Cursors.Hand;
            btnCargarImg.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            btnCargarImg.IconChar = FontAwesome.Sharp.IconChar.Image;
            btnCargarImg.IconColor = Color.Black;
            btnCargarImg.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnCargarImg.IconSize = 40;
            btnCargarImg.Location = new Point(743, 212);
            btnCargarImg.Margin = new Padding(3, 4, 3, 4);
            btnCargarImg.Name = "btnCargarImg";
            btnCargarImg.Size = new Size(157, 61);
            btnCargarImg.TabIndex = 28;
            btnCargarImg.Text = "Cargar imagen";
            btnCargarImg.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCargarImg.UseVisualStyleBackColor = true;
            btnCargarImg.Click += btnCargarImg_Click;
            // 
            // pbImagenProducto
            // 
            pbImagenProducto.BackColor = Color.SlateGray;
            pbImagenProducto.ErrorImage = null;
            pbImagenProducto.Image = Properties.Resources.producto_defecto;
            pbImagenProducto.InitialImage = null;
            pbImagenProducto.Location = new Point(691, 16);
            pbImagenProducto.Margin = new Padding(3, 4, 3, 4);
            pbImagenProducto.Name = "pbImagenProducto";
            pbImagenProducto.Size = new Size(256, 188);
            pbImagenProducto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbImagenProducto.TabIndex = 27;
            pbImagenProducto.TabStop = false;
            // 
            // lbEliminar
            // 
            lbEliminar.AutoSize = true;
            lbEliminar.BackColor = Color.Transparent;
            lbEliminar.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbEliminar.ForeColor = SystemColors.ButtonFace;
            lbEliminar.Location = new Point(1050, 156);
            lbEliminar.Name = "lbEliminar";
            lbEliminar.Size = new Size(61, 29);
            lbEliminar.TabIndex = 26;
            lbEliminar.Text = "Borrar";
            // 
            // lbGuardar
            // 
            lbGuardar.AutoSize = true;
            lbGuardar.BackColor = Color.Transparent;
            lbGuardar.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbGuardar.ForeColor = SystemColors.ButtonFace;
            lbGuardar.Location = new Point(1045, 23);
            lbGuardar.Name = "lbGuardar";
            lbGuardar.Size = new Size(72, 29);
            lbGuardar.TabIndex = 25;
            lbGuardar.Text = "Guardar";
            // 
            // btnBorrarProducto
            // 
            btnBorrarProducto.Cursor = Cursors.Hand;
            btnBorrarProducto.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnBorrarProducto.IconColor = Color.Black;
            btnBorrarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBorrarProducto.IconSize = 40;
            btnBorrarProducto.Location = new Point(1033, 189);
            btnBorrarProducto.Margin = new Padding(3, 4, 3, 4);
            btnBorrarProducto.Name = "btnBorrarProducto";
            btnBorrarProducto.Size = new Size(86, 80);
            btnBorrarProducto.TabIndex = 18;
            btnBorrarProducto.UseVisualStyleBackColor = true;
            btnBorrarProducto.Click += btnEliminar_Click;
            // 
            // lbStock
            // 
            lbStock.AutoSize = true;
            lbStock.BackColor = Color.Transparent;
            lbStock.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbStock.ForeColor = SystemColors.ButtonFace;
            lbStock.Location = new Point(458, 7);
            lbStock.Name = "lbStock";
            lbStock.Size = new Size(79, 29);
            lbStock.TabIndex = 13;
            lbStock.Text = "Stock (*)";
            // 
            // tbStockProducto
            // 
            tbStockProducto.Location = new Point(389, 40);
            tbStockProducto.Margin = new Padding(3, 4, 3, 4);
            tbStockProducto.Name = "tbStockProducto";
            tbStockProducto.Size = new Size(209, 27);
            tbStockProducto.TabIndex = 12;
            tbStockProducto.TextChanged += tbStock_TextChanged;
            tbStockProducto.KeyPress += tbStock_KeyPress;
            // 
            // lbDescripcion
            // 
            lbDescripcion.AutoSize = true;
            lbDescripcion.BackColor = Color.Transparent;
            lbDescripcion.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbDescripcion.ForeColor = SystemColors.ButtonFace;
            lbDescripcion.Location = new Point(86, 72);
            lbDescripcion.Name = "lbDescripcion";
            lbDescripcion.Size = new Size(98, 29);
            lbDescripcion.TabIndex = 11;
            lbDescripcion.Text = "Descripcion";
            // 
            // tbDescripcionProducto
            // 
            tbDescripcionProducto.Location = new Point(26, 105);
            tbDescripcionProducto.Margin = new Padding(3, 4, 3, 4);
            tbDescripcionProducto.Name = "tbDescripcionProducto";
            tbDescripcionProducto.Size = new Size(209, 27);
            tbDescripcionProducto.TabIndex = 10;
            tbDescripcionProducto.TextChanged += tbDescripcion_TextChanged;
            // 
            // lbPrecio
            // 
            lbPrecio.AutoSize = true;
            lbPrecio.BackColor = Color.Transparent;
            lbPrecio.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbPrecio.ForeColor = SystemColors.ButtonFace;
            lbPrecio.Location = new Point(458, 72);
            lbPrecio.Name = "lbPrecio";
            lbPrecio.Size = new Size(83, 29);
            lbPrecio.TabIndex = 5;
            lbPrecio.Text = "Precio (*)";
            // 
            // tbPrecioProducto
            // 
            tbPrecioProducto.Location = new Point(389, 105);
            tbPrecioProducto.Margin = new Padding(3, 4, 3, 4);
            tbPrecioProducto.Name = "tbPrecioProducto";
            tbPrecioProducto.Size = new Size(209, 27);
            tbPrecioProducto.TabIndex = 4;
            tbPrecioProducto.TextChanged += tbPrecio_TextChanged;
            tbPrecioProducto.KeyPress += tbPrecio_KeyPress;
            // 
            // lbNombre
            // 
            lbNombre.AutoSize = true;
            lbNombre.BackColor = Color.Transparent;
            lbNombre.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbNombre.ForeColor = SystemColors.ButtonFace;
            lbNombre.Location = new Point(86, 7);
            lbNombre.Name = "lbNombre";
            lbNombre.Size = new Size(96, 29);
            lbNombre.TabIndex = 3;
            lbNombre.Text = "Nombre (*)";
            // 
            // btnGuardarProducto
            // 
            btnGuardarProducto.Cursor = Cursors.Hand;
            btnGuardarProducto.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnGuardarProducto.IconColor = Color.Black;
            btnGuardarProducto.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardarProducto.IconSize = 40;
            btnGuardarProducto.Location = new Point(1033, 56);
            btnGuardarProducto.Margin = new Padding(3, 4, 3, 4);
            btnGuardarProducto.Name = "btnGuardarProducto";
            btnGuardarProducto.Size = new Size(86, 80);
            btnGuardarProducto.TabIndex = 2;
            btnGuardarProducto.UseVisualStyleBackColor = true;
            btnGuardarProducto.Click += btnGuardar_Click;
            // 
            // tbNombreProducto
            // 
            tbNombreProducto.Location = new Point(24, 40);
            tbNombreProducto.Margin = new Padding(3, 4, 3, 4);
            tbNombreProducto.Name = "tbNombreProducto";
            tbNombreProducto.Size = new Size(209, 27);
            tbNombreProducto.TabIndex = 1;
            tbNombreProducto.TextChanged += tbNombre_TextChanged;
            tbNombreProducto.KeyPress += tbNombre_KeyPress;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(tbBusquedaNombreProducto);
            panel2.Controls.Add(tbBusquedaPrecioMinProducto);
            panel2.Controls.Add(tbBusquedaPrecioMaxProducto);
            panel2.Controls.Add(cbInactivosProductos);
            panel2.Controls.Add(cbActivosProductos);
            panel2.Controls.Add(dgvProductos);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 312);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1159, 340);
            panel2.TabIndex = 21;
            panel2.Paint += panel2_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(783, 52);
            label1.Name = "label1";
            label1.Size = new Size(95, 29);
            label1.TabIndex = 34;
            label1.Text = "Buscar por:";
            // 
            // tbBusquedaNombreProducto
            // 
            tbBusquedaNombreProducto.Location = new Point(783, 85);
            tbBusquedaNombreProducto.Multiline = true;
            tbBusquedaNombreProducto.Name = "tbBusquedaNombreProducto";
            tbBusquedaNombreProducto.PlaceholderText = "Nombre del producto";
            tbBusquedaNombreProducto.Size = new Size(209, 28);
            tbBusquedaNombreProducto.TabIndex = 33;
            // 
            // tbBusquedaPrecioMinProducto
            // 
            tbBusquedaPrecioMinProducto.Location = new Point(1033, 51);
            tbBusquedaPrecioMinProducto.Multiline = true;
            tbBusquedaPrecioMinProducto.Name = "tbBusquedaPrecioMinProducto";
            tbBusquedaPrecioMinProducto.PlaceholderText = "Precio minimo";
            tbBusquedaPrecioMinProducto.Size = new Size(86, 28);
            tbBusquedaPrecioMinProducto.TabIndex = 32;
            tbBusquedaPrecioMinProducto.TextChanged += tbBusquedaPrecioMinProducto_TextChanged;
            // 
            // tbBusquedaPrecioMaxProducto
            // 
            tbBusquedaPrecioMaxProducto.Location = new Point(1033, 85);
            tbBusquedaPrecioMaxProducto.Multiline = true;
            tbBusquedaPrecioMaxProducto.Name = "tbBusquedaPrecioMaxProducto";
            tbBusquedaPrecioMaxProducto.PlaceholderText = "Precio maximo";
            tbBusquedaPrecioMaxProducto.Size = new Size(86, 28);
            tbBusquedaPrecioMaxProducto.TabIndex = 31;
            tbBusquedaPrecioMaxProducto.TextChanged += tbBusquedaPrecioMaxProducto_TextChanged;
            // 
            // cbInactivosProductos
            // 
            cbInactivosProductos.AutoSize = true;
            cbInactivosProductos.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            cbInactivosProductos.ForeColor = SystemColors.ButtonFace;
            cbInactivosProductos.Location = new Point(136, 85);
            cbInactivosProductos.Margin = new Padding(3, 4, 3, 4);
            cbInactivosProductos.Name = "cbInactivosProductos";
            cbInactivosProductos.Size = new Size(99, 33);
            cbInactivosProductos.TabIndex = 30;
            cbInactivosProductos.Text = "Inactivos";
            cbInactivosProductos.UseVisualStyleBackColor = true;
            // 
            // cbActivosProductos
            // 
            cbActivosProductos.AutoSize = true;
            cbActivosProductos.Checked = true;
            cbActivosProductos.CheckState = CheckState.Checked;
            cbActivosProductos.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            cbActivosProductos.ForeColor = SystemColors.ButtonFace;
            cbActivosProductos.Location = new Point(28, 85);
            cbActivosProductos.Margin = new Padding(3, 4, 3, 4);
            cbActivosProductos.Name = "cbActivosProductos";
            cbActivosProductos.Size = new Size(88, 33);
            cbActivosProductos.TabIndex = 29;
            cbActivosProductos.Text = "Activos";
            cbActivosProductos.UseVisualStyleBackColor = true;
            cbActivosProductos.CheckedChanged += cbActivos_CheckedChanged;
            // 
            // dgvProductos
            // 
            dgvProductos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvProductos.BackgroundColor = Color.SlateGray;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvProductos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvProductos.Location = new Point(24, 120);
            dgvProductos.Margin = new Padding(3, 4, 3, 4);
            dgvProductos.Name = "dgvProductos";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            dataGridViewCellStyle3.ForeColor = SystemColors.Info;
            dataGridViewCellStyle3.SelectionBackColor = Color.Azure;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvProductos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvProductos.RowHeadersWidth = 51;
            dgvProductos.Size = new Size(1110, 202);
            dgvProductos.TabIndex = 0;
            dgvProductos.CellContentClick += dgvProductos_CellContentClick;
            // 
            // CrudProductos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(1159, 652);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "CrudProductos";
            Text = "CrudProductos";
            Load += CrudProductos_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            gbEstadoProducto.ResumeLayout(false);
            gbEstadoProducto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbImagenProducto).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lbEliminar;
        private Label lbGuardar;
        private FontAwesome.Sharp.IconButton btnBorrarProducto;
        private Label lbStock;
        private TextBox tbStockProducto;
        private Label lbDescripcion;
        private TextBox tbDescripcionProducto;
        private Label lbPrecio;
        private TextBox tbPrecioProducto;
        private Label lbNombre;
        private FontAwesome.Sharp.IconButton btnGuardarProducto;
        private TextBox tbNombreProducto;
        private PictureBox pbImagenProducto;
        private FontAwesome.Sharp.IconButton btnCargarImg;
        private Panel panel2;
        private CheckBox cbInactivosProductos;
        private CheckBox cbActivosProductos;
        private DataGridView dgvProductos;
        private Label lbCategoria;
        private ComboBox cbCategoriaProducto;
        private Label lbMarca;
        private ComboBox cbMarcaProducto;
        private Label lbPrecioVenta;
        private TextBox tbPrecioVentaProducto;
        private GroupBox gbEstadoProducto;
        private RadioButton rbProductoEliminadoSi;
        private RadioButton rbProductoEliminadoNo;
        private TextBox tbBusquedaNombreProducto;
        private TextBox tbBusquedaPrecioMinProducto;
        private TextBox tbBusquedaPrecioMaxProducto;
        private Label label1;
    }
}