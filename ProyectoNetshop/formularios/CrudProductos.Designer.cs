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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CrudProductos));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            lbPrecioVenta = new Label();
            tbPrecioVenta = new TextBox();
            cbMarca = new ComboBox();
            lbMarca = new Label();
            lbCategoria = new Label();
            cbCategoria = new ComboBox();
            btnCargarImg = new FontAwesome.Sharp.IconButton();
            pbProducto = new PictureBox();
            lbEliminar = new Label();
            lbGuardar = new Label();
            btnBorrar = new FontAwesome.Sharp.IconButton();
            lbStock = new Label();
            tbStock = new TextBox();
            lbDescripcion = new Label();
            tbDescripcion = new TextBox();
            lbPrecio = new Label();
            tbPrecio = new TextBox();
            lbNombre = new Label();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            tbNombre = new TextBox();
            panel2 = new Panel();
            cbInactivos = new CheckBox();
            cbActivos = new CheckBox();
            dgvProductos = new DataGridView();
            colIdProducto = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colPrecioVenta = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colMarca = new DataGridViewTextBoxColumn();
            colImagen = new DataGridViewImageColumn();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbProducto).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(lbPrecioVenta);
            panel1.Controls.Add(tbPrecioVenta);
            panel1.Controls.Add(cbMarca);
            panel1.Controls.Add(lbMarca);
            panel1.Controls.Add(lbCategoria);
            panel1.Controls.Add(cbCategoria);
            panel1.Controls.Add(btnCargarImg);
            panel1.Controls.Add(pbProducto);
            panel1.Controls.Add(lbEliminar);
            panel1.Controls.Add(lbGuardar);
            panel1.Controls.Add(btnBorrar);
            panel1.Controls.Add(lbStock);
            panel1.Controls.Add(tbStock);
            panel1.Controls.Add(lbDescripcion);
            panel1.Controls.Add(tbDescripcion);
            panel1.Controls.Add(lbPrecio);
            panel1.Controls.Add(tbPrecio);
            panel1.Controls.Add(lbNombre);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(tbNombre);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.RightToLeft = RightToLeft.No;
            panel1.Size = new Size(1159, 292);
            panel1.TabIndex = 20;
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
            // tbPrecioVenta
            // 
            tbPrecioVenta.Location = new Point(24, 173);
            tbPrecioVenta.Margin = new Padding(3, 4, 3, 4);
            tbPrecioVenta.Name = "tbPrecioVenta";
            tbPrecioVenta.Size = new Size(209, 27);
            tbPrecioVenta.TabIndex = 34;
            tbPrecioVenta.TextChanged += tbPrecioVenta_TextChanged;
            tbPrecioVenta.KeyPress += tbPrecioVenta_KeyPress;
            // 
            // cbMarca
            // 
            cbMarca.DropDownStyle = ComboBoxStyle.DropDownList;
            cbMarca.FormattingEnabled = true;
            cbMarca.Items.AddRange(new object[] { "HP", "Apple", "Lenovo", "Asus", "Acer", "MSI", "Huawei" });
            cbMarca.Location = new Point(24, 242);
            cbMarca.Margin = new Padding(3, 4, 3, 4);
            cbMarca.Name = "cbMarca";
            cbMarca.Size = new Size(209, 28);
            cbMarca.TabIndex = 33;
            cbMarca.SelectedIndexChanged += cbMarca_SelectedIndexChanged;
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
            // cbCategoria
            // 
            cbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Items.AddRange(new object[] { "Hogar", "Trabajo", "Educación", "Gaming", "Diseño y edición multimedia" });
            cbCategoria.Location = new Point(389, 173);
            cbCategoria.Margin = new Padding(3, 4, 3, 4);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(205, 28);
            cbCategoria.TabIndex = 25;
            cbCategoria.SelectedIndexChanged += cbCategoria_SelectedIndexChanged;
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
            // pbProducto
            // 
            pbProducto.BackColor = Color.SlateGray;
            pbProducto.ErrorImage = null;
            pbProducto.Image = (Image)resources.GetObject("pbProducto.Image");
            pbProducto.InitialImage = null;
            pbProducto.Location = new Point(691, 16);
            pbProducto.Margin = new Padding(3, 4, 3, 4);
            pbProducto.Name = "pbProducto";
            pbProducto.Size = new Size(256, 188);
            pbProducto.SizeMode = PictureBoxSizeMode.StretchImage;
            pbProducto.TabIndex = 27;
            pbProducto.TabStop = false;
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
            // btnBorrar
            // 
            btnBorrar.Cursor = Cursors.Hand;
            btnBorrar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnBorrar.IconColor = Color.Black;
            btnBorrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBorrar.IconSize = 40;
            btnBorrar.Location = new Point(1033, 189);
            btnBorrar.Margin = new Padding(3, 4, 3, 4);
            btnBorrar.Name = "btnBorrar";
            btnBorrar.Size = new Size(86, 80);
            btnBorrar.TabIndex = 18;
            btnBorrar.UseVisualStyleBackColor = true;
            btnBorrar.Click += btnEliminar_Click;
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
            // tbStock
            // 
            tbStock.Location = new Point(389, 40);
            tbStock.Margin = new Padding(3, 4, 3, 4);
            tbStock.Name = "tbStock";
            tbStock.Size = new Size(209, 27);
            tbStock.TabIndex = 12;
            tbStock.TextChanged += tbStock_TextChanged;
            tbStock.KeyPress += tbStock_KeyPress;
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
            // tbDescripcion
            // 
            tbDescripcion.Location = new Point(26, 105);
            tbDescripcion.Margin = new Padding(3, 4, 3, 4);
            tbDescripcion.Name = "tbDescripcion";
            tbDescripcion.Size = new Size(209, 27);
            tbDescripcion.TabIndex = 10;
            tbDescripcion.TextChanged += tbDescripcion_TextChanged;
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
            // tbPrecio
            // 
            tbPrecio.Location = new Point(389, 105);
            tbPrecio.Margin = new Padding(3, 4, 3, 4);
            tbPrecio.Name = "tbPrecio";
            tbPrecio.Size = new Size(209, 27);
            tbPrecio.TabIndex = 4;
            tbPrecio.TextChanged += tbPrecio_TextChanged;
            tbPrecio.KeyPress += tbPrecio_KeyPress;
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
            // btnGuardar
            // 
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardar.IconSize = 40;
            btnGuardar.Location = new Point(1033, 56);
            btnGuardar.Margin = new Padding(3, 4, 3, 4);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(86, 80);
            btnGuardar.TabIndex = 2;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // tbNombre
            // 
            tbNombre.Location = new Point(24, 40);
            tbNombre.Margin = new Padding(3, 4, 3, 4);
            tbNombre.Name = "tbNombre";
            tbNombre.Size = new Size(209, 27);
            tbNombre.TabIndex = 1;
            tbNombre.TextChanged += tbNombre_TextChanged;
            tbNombre.KeyPress += tbNombre_KeyPress;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(cbInactivos);
            panel2.Controls.Add(cbActivos);
            panel2.Controls.Add(dgvProductos);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 344);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1159, 308);
            panel2.TabIndex = 21;
            // 
            // cbInactivos
            // 
            cbInactivos.AutoSize = true;
            cbInactivos.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            cbInactivos.ForeColor = SystemColors.ButtonFace;
            cbInactivos.Location = new Point(134, 56);
            cbInactivos.Margin = new Padding(3, 4, 3, 4);
            cbInactivos.Name = "cbInactivos";
            cbInactivos.Size = new Size(99, 33);
            cbInactivos.TabIndex = 30;
            cbInactivos.Text = "Inactivos";
            cbInactivos.UseVisualStyleBackColor = true;
            // 
            // cbActivos
            // 
            cbActivos.AutoSize = true;
            cbActivos.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            cbActivos.ForeColor = SystemColors.ButtonFace;
            cbActivos.Location = new Point(24, 56);
            cbActivos.Margin = new Padding(3, 4, 3, 4);
            cbActivos.Name = "cbActivos";
            cbActivos.Size = new Size(88, 33);
            cbActivos.TabIndex = 29;
            cbActivos.Text = "Activos";
            cbActivos.UseVisualStyleBackColor = true;
            cbActivos.CheckedChanged += cbActivos_CheckedChanged;
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
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { colIdProducto, colNombre, colDescripcion, colPrecio, colStock, colPrecioVenta, colCategoria, colMarca, colImagen });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvProductos.Location = new Point(24, 87);
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
            dgvProductos.Size = new Size(1110, 203);
            dgvProductos.TabIndex = 0;
            // 
            // colIdProducto
            // 
            colIdProducto.HeaderText = "ID Producto";
            colIdProducto.MinimumWidth = 6;
            colIdProducto.Name = "colIdProducto";
            colIdProducto.Width = 140;
            // 
            // colNombre
            // 
            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 6;
            colNombre.Name = "colNombre";
            colNombre.Width = 125;
            // 
            // colDescripcion
            // 
            colDescripcion.HeaderText = "Descripción";
            colDescripcion.MinimumWidth = 125;
            colDescripcion.Name = "colDescripcion";
            colDescripcion.Width = 125;
            // 
            // colPrecio
            // 
            colPrecio.HeaderText = "Precio";
            colPrecio.MinimumWidth = 6;
            colPrecio.Name = "colPrecio";
            colPrecio.Width = 125;
            // 
            // colStock
            // 
            colStock.HeaderText = "Stock";
            colStock.MinimumWidth = 6;
            colStock.Name = "colStock";
            colStock.Width = 125;
            // 
            // colPrecioVenta
            // 
            colPrecioVenta.HeaderText = "Precio de venta";
            colPrecioVenta.MinimumWidth = 6;
            colPrecioVenta.Name = "colPrecioVenta";
            colPrecioVenta.Width = 125;
            // 
            // colCategoria
            // 
            colCategoria.HeaderText = "Categoría";
            colCategoria.MinimumWidth = 6;
            colCategoria.Name = "colCategoria";
            colCategoria.Width = 125;
            // 
            // colMarca
            // 
            colMarca.HeaderText = "Marca";
            colMarca.MinimumWidth = 6;
            colMarca.Name = "colMarca";
            colMarca.Width = 125;
            // 
            // colImagen
            // 
            colImagen.HeaderText = "Imagen";
            colImagen.ImageLayout = DataGridViewImageCellLayout.Stretch;
            colImagen.MinimumWidth = 6;
            colImagen.Name = "colImagen";
            colImagen.Width = 125;
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
            ((System.ComponentModel.ISupportInitialize)pbProducto).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lbEliminar;
        private Label lbGuardar;
        private FontAwesome.Sharp.IconButton btnBorrar;
        private Label lbStock;
        private TextBox tbStock;
        private Label lbDescripcion;
        private TextBox tbDescripcion;
        private Label lbPrecio;
        private TextBox tbPrecio;
        private Label lbNombre;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private TextBox tbNombre;
        private PictureBox pbProducto;
        private FontAwesome.Sharp.IconButton btnCargarImg;
        private Panel panel2;
        private CheckBox cbInactivos;
        private CheckBox cbActivos;
        private DataGridView dgvProductos;
        private Label lbCategoria;
        private ComboBox cbCategoria;
        private Label lbMarca;
        private ComboBox cbMarca;
        private Label lbPrecioVenta;
        private TextBox tbPrecioVenta;
        private DataGridViewTextBoxColumn colIdProducto;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colPrecioVenta;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colMarca;
        private DataGridViewImageColumn colImagen;
    }
}