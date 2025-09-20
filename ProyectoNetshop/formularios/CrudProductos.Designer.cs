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
            lbMarca = new Label();
            tbMarca = new TextBox();
            lbIDProducto = new Label();
            tbiDProducto = new TextBox();
            lbCategoria = new Label();
            cbCategoria = new ComboBox();
            btnCargarImg = new FontAwesome.Sharp.IconButton();
            pbProducto = new PictureBox();
            lbEliminar = new Label();
            lbGuardar = new Label();
            btnEliminar = new FontAwesome.Sharp.IconButton();
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
            colMarca = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colDescripcion = new DataGridViewTextBoxColumn();
            colPrecio = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
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
            panel1.Controls.Add(lbMarca);
            panel1.Controls.Add(tbMarca);
            panel1.Controls.Add(lbIDProducto);
            panel1.Controls.Add(tbiDProducto);
            panel1.Controls.Add(lbCategoria);
            panel1.Controls.Add(cbCategoria);
            panel1.Controls.Add(btnCargarImg);
            panel1.Controls.Add(pbProducto);
            panel1.Controls.Add(lbEliminar);
            panel1.Controls.Add(lbGuardar);
            panel1.Controls.Add(btnEliminar);
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
            panel1.Name = "panel1";
            panel1.RightToLeft = RightToLeft.No;
            panel1.Size = new Size(1014, 219);
            panel1.TabIndex = 20;
            // 
            // lbMarca
            // 
            lbMarca.AutoSize = true;
            lbMarca.BackColor = Color.Transparent;
            lbMarca.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbMarca.ForeColor = SystemColors.ButtonFace;
            lbMarca.Location = new Point(92, 157);
            lbMarca.Name = "lbMarca";
            lbMarca.Size = new Size(44, 22);
            lbMarca.TabIndex = 32;
            lbMarca.Text = "Marca";
            // 
            // tbMarca
            // 
            tbMarca.Location = new Point(23, 182);
            tbMarca.Name = "tbMarca";
            tbMarca.Size = new Size(183, 23);
            tbMarca.TabIndex = 31;
            tbMarca.TextChanged += tbMarca_TextChanged;
            tbMarca.KeyPress += tbMarca_KeyPress;
            // 
            // lbIDProducto
            // 
            lbIDProducto.AutoSize = true;
            lbIDProducto.BackColor = Color.Transparent;
            lbIDProducto.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbIDProducto.ForeColor = SystemColors.ButtonFace;
            lbIDProducto.Location = new Point(388, 5);
            lbIDProducto.Name = "lbIDProducto";
            lbIDProducto.Size = new Size(77, 22);
            lbIDProducto.TabIndex = 30;
            lbIDProducto.Text = "ID Producto";
            // 
            // tbiDProducto
            // 
            tbiDProducto.Location = new Point(340, 30);
            tbiDProducto.Name = "tbiDProducto";
            tbiDProducto.Size = new Size(183, 23);
            tbiDProducto.TabIndex = 29;
            tbiDProducto.TextChanged += tbiDProducto_TextChanged;
            tbiDProducto.KeyPress += tbiDProducto_KeyPress;
            // 
            // lbCategoria
            // 
            lbCategoria.AutoSize = true;
            lbCategoria.BackColor = Color.Transparent;
            lbCategoria.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbCategoria.ForeColor = SystemColors.ButtonFace;
            lbCategoria.Location = new Point(402, 105);
            lbCategoria.Name = "lbCategoria";
            lbCategoria.Size = new Size(63, 22);
            lbCategoria.TabIndex = 26;
            lbCategoria.Text = "Categoria";
            // 
            // cbCategoria
            // 
            cbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCategoria.FormattingEnabled = true;
            cbCategoria.Items.AddRange(new object[] { "Hogar", "Trabajo", "Educación", "Gaming", "Diseño y edición multimedia" });
            cbCategoria.Location = new Point(340, 130);
            cbCategoria.Name = "cbCategoria";
            cbCategoria.Size = new Size(180, 23);
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
            btnCargarImg.Location = new Point(650, 159);
            btnCargarImg.Name = "btnCargarImg";
            btnCargarImg.Size = new Size(137, 46);
            btnCargarImg.TabIndex = 28;
            btnCargarImg.Text = "Cargar imagen";
            btnCargarImg.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCargarImg.UseVisualStyleBackColor = true;
            btnCargarImg.Click += btnCargarImg_Click;
            // 
            // pbProducto
            // 
            pbProducto.BackColor = Color.SlateGray;
            pbProducto.Location = new Point(605, 12);
            pbProducto.Name = "pbProducto";
            pbProducto.Size = new Size(224, 141);
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
            lbEliminar.Location = new Point(909, 117);
            lbEliminar.Name = "lbEliminar";
            lbEliminar.Size = new Size(54, 22);
            lbEliminar.TabIndex = 26;
            lbEliminar.Text = "Eliminar";
            // 
            // lbGuardar
            // 
            lbGuardar.AutoSize = true;
            lbGuardar.BackColor = Color.Transparent;
            lbGuardar.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbGuardar.ForeColor = SystemColors.ButtonFace;
            lbGuardar.Location = new Point(911, 17);
            lbGuardar.Name = "lbGuardar";
            lbGuardar.Size = new Size(54, 22);
            lbGuardar.TabIndex = 25;
            lbGuardar.Text = "Guardar";
            // 
            // btnEliminar
            // 
            btnEliminar.Cursor = Cursors.Hand;
            btnEliminar.IconChar = FontAwesome.Sharp.IconChar.Trash;
            btnEliminar.IconColor = Color.Black;
            btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnEliminar.IconSize = 40;
            btnEliminar.Location = new Point(904, 142);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(75, 60);
            btnEliminar.TabIndex = 18;
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // lbStock
            // 
            lbStock.AutoSize = true;
            lbStock.BackColor = Color.Transparent;
            lbStock.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbStock.ForeColor = SystemColors.ButtonFace;
            lbStock.Location = new Point(92, 105);
            lbStock.Name = "lbStock";
            lbStock.Size = new Size(42, 22);
            lbStock.TabIndex = 13;
            lbStock.Text = "Stock";
            // 
            // tbStock
            // 
            tbStock.Location = new Point(23, 130);
            tbStock.Name = "tbStock";
            tbStock.Size = new Size(183, 23);
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
            lbDescripcion.Location = new Point(75, 54);
            lbDescripcion.Name = "lbDescripcion";
            lbDescripcion.Size = new Size(75, 22);
            lbDescripcion.TabIndex = 11;
            lbDescripcion.Text = "Descripcion";
            // 
            // tbDescripcion
            // 
            tbDescripcion.Location = new Point(23, 79);
            tbDescripcion.Name = "tbDescripcion";
            tbDescripcion.Size = new Size(183, 23);
            tbDescripcion.TabIndex = 10;
            tbDescripcion.TextChanged += tbDescripcion_TextChanged;
            // 
            // lbPrecio
            // 
            lbPrecio.AutoSize = true;
            lbPrecio.BackColor = Color.Transparent;
            lbPrecio.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbPrecio.ForeColor = SystemColors.ButtonFace;
            lbPrecio.Location = new Point(402, 56);
            lbPrecio.Name = "lbPrecio";
            lbPrecio.Size = new Size(44, 22);
            lbPrecio.TabIndex = 5;
            lbPrecio.Text = "Precio";
            // 
            // tbPrecio
            // 
            tbPrecio.Location = new Point(340, 79);
            tbPrecio.Name = "tbPrecio";
            tbPrecio.Size = new Size(183, 23);
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
            lbNombre.Location = new Point(82, 5);
            lbNombre.Name = "lbNombre";
            lbNombre.Size = new Size(54, 22);
            lbNombre.TabIndex = 3;
            lbNombre.Text = "Nombre";
            // 
            // btnGuardar
            // 
            btnGuardar.Cursor = Cursors.Hand;
            btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            btnGuardar.IconColor = Color.Black;
            btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnGuardar.IconSize = 40;
            btnGuardar.Location = new Point(904, 42);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(75, 60);
            btnGuardar.TabIndex = 2;
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // tbNombre
            // 
            tbNombre.Location = new Point(21, 30);
            tbNombre.Name = "tbNombre";
            tbNombre.Size = new Size(183, 23);
            tbNombre.TabIndex = 1;
            tbNombre.KeyPress += tbNombre_KeyPress;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(cbInactivos);
            panel2.Controls.Add(cbActivos);
            panel2.Controls.Add(dgvProductos);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 258);
            panel2.Name = "panel2";
            panel2.Size = new Size(1014, 231);
            panel2.TabIndex = 21;
            // 
            // cbInactivos
            // 
            cbInactivos.AutoSize = true;
            cbInactivos.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            cbInactivos.ForeColor = SystemColors.ButtonFace;
            cbInactivos.Location = new Point(232, 16);
            cbInactivos.Name = "cbInactivos";
            cbInactivos.Size = new Size(79, 26);
            cbInactivos.TabIndex = 30;
            cbInactivos.Text = "Inactivos";
            cbInactivos.UseVisualStyleBackColor = true;
            // 
            // cbActivos
            // 
            cbActivos.AutoSize = true;
            cbActivos.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            cbActivos.ForeColor = SystemColors.ButtonFace;
            cbActivos.Location = new Point(75, 16);
            cbActivos.Name = "cbActivos";
            cbActivos.Size = new Size(71, 26);
            cbActivos.TabIndex = 29;
            cbActivos.Text = "Activos";
            cbActivos.UseVisualStyleBackColor = true;
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
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { colIdProducto, colMarca, colNombre, colDescripcion, colPrecio, colStock, colCategoria, colImagen });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvProductos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvProductos.Location = new Point(21, 47);
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
            dgvProductos.Size = new Size(971, 170);
            dgvProductos.TabIndex = 0;
            // 
            // colIdProducto
            // 
            colIdProducto.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colIdProducto.FillWeight = 50F;
            colIdProducto.HeaderText = "idProducto";
            colIdProducto.MinimumWidth = 6;
            colIdProducto.Name = "colIdProducto";
            // 
            // colMarca
            // 
            colMarca.HeaderText = "Marca";
            colMarca.Name = "colMarca";
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
            // colCategoria
            // 
            colCategoria.HeaderText = "Categoría";
            colCategoria.MinimumWidth = 6;
            colCategoria.Name = "colCategoria";
            colCategoria.Width = 125;
            // 
            // colImagen
            // 
            colImagen.HeaderText = "Imagen";
            colImagen.ImageLayout = DataGridViewImageCellLayout.Stretch;
            colImagen.Name = "colImagen";
            // 
            // CrudProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(1014, 489);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
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
        private FontAwesome.Sharp.IconButton btnEliminar;
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
        private Label lbIDProducto;
        private TextBox tbiDProducto;
        private Label lbMarca;
        private TextBox tbMarca;
        private DataGridViewTextBoxColumn colIdProducto;
        private DataGridViewTextBoxColumn colMarca;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colDescripcion;
        private DataGridViewTextBoxColumn colPrecio;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewImageColumn colImagen;
    }
}