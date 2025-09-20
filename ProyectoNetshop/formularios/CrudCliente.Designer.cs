namespace vistaDeProyectoC
{
    partial class FRegistrarCliente
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
            panel1 = new Panel();
            lbEliminar = new Label();
            lbGuardar = new Label();
            gbSexo = new GroupBox();
            rbMasculino = new RadioButton();
            rbFemenino = new RadioButton();
            btnEliminar = new FontAwesome.Sharp.IconButton();
            lbFechaNacimiento = new Label();
            fechaNacimiento = new DateTimePicker();
            lbDireccion = new Label();
            tbDireccion = new TextBox();
            lbTelefono = new Label();
            tbTelefono = new TextBox();
            lbEmail = new Label();
            tbEmail = new TextBox();
            lbDNI = new Label();
            tbDNI = new TextBox();
            lbApellido = new Label();
            tbApellido = new TextBox();
            lbNombre = new Label();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            tbNombre = new TextBox();
            panel2 = new Panel();
            cbInactivos = new CheckBox();
            cbActivos = new CheckBox();
            dgvClientes = new DataGridView();
            colDNI = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colApellido = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colTelefono = new DataGridViewTextBoxColumn();
            colDireccion = new DataGridViewTextBoxColumn();
            colFechaNacimiento = new DataGridViewTextBoxColumn();
            colSexo = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            gbSexo.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(lbEliminar);
            panel1.Controls.Add(lbGuardar);
            panel1.Controls.Add(gbSexo);
            panel1.Controls.Add(btnEliminar);
            panel1.Controls.Add(lbFechaNacimiento);
            panel1.Controls.Add(fechaNacimiento);
            panel1.Controls.Add(lbDireccion);
            panel1.Controls.Add(tbDireccion);
            panel1.Controls.Add(lbTelefono);
            panel1.Controls.Add(tbTelefono);
            panel1.Controls.Add(lbEmail);
            panel1.Controls.Add(tbEmail);
            panel1.Controls.Add(lbDNI);
            panel1.Controls.Add(tbDNI);
            panel1.Controls.Add(lbApellido);
            panel1.Controls.Add(tbApellido);
            panel1.Controls.Add(lbNombre);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(tbNombre);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.RightToLeft = RightToLeft.No;
            panel1.Size = new Size(1014, 219);
            panel1.TabIndex = 19;
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
            // gbSexo
            // 
            gbSexo.Controls.Add(rbMasculino);
            gbSexo.Controls.Add(rbFemenino);
            gbSexo.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            gbSexo.ForeColor = SystemColors.ButtonFace;
            gbSexo.Location = new Point(645, 79);
            gbSexo.Name = "gbSexo";
            gbSexo.Size = new Size(200, 60);
            gbSexo.TabIndex = 22;
            gbSexo.TabStop = false;
            gbSexo.Text = "Sexo";
            // 
            // rbMasculino
            // 
            rbMasculino.AutoSize = true;
            rbMasculino.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            rbMasculino.ForeColor = SystemColors.ButtonFace;
            rbMasculino.Location = new Point(17, 22);
            rbMasculino.Name = "rbMasculino";
            rbMasculino.Size = new Size(84, 26);
            rbMasculino.TabIndex = 1;
            rbMasculino.TabStop = true;
            rbMasculino.Text = "Masculino";
            rbMasculino.UseVisualStyleBackColor = true;
            rbMasculino.CheckedChanged += rbMasculino_CheckedChanged;
            // 
            // rbFemenino
            // 
            rbFemenino.AutoSize = true;
            rbFemenino.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            rbFemenino.ForeColor = SystemColors.ButtonFace;
            rbFemenino.Location = new Point(116, 22);
            rbFemenino.Name = "rbFemenino";
            rbFemenino.Size = new Size(81, 26);
            rbFemenino.TabIndex = 21;
            rbFemenino.TabStop = true;
            rbFemenino.Text = "Femenino";
            rbFemenino.UseVisualStyleBackColor = true;
            rbFemenino.CheckedChanged += rbFemenino_CheckedChanged;
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
            // lbFechaNacimiento
            // 
            lbFechaNacimiento.AutoSize = true;
            lbFechaNacimiento.BackColor = Color.Transparent;
            lbFechaNacimiento.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbFechaNacimiento.ForeColor = SystemColors.ButtonFace;
            lbFechaNacimiento.Location = new Point(693, 5);
            lbFechaNacimiento.Name = "lbFechaNacimiento";
            lbFechaNacimiento.Size = new Size(121, 22);
            lbFechaNacimiento.TabIndex = 17;
            lbFechaNacimiento.Text = "Fecha de nacimiento";
            // 
            // fechaNacimiento
            // 
            fechaNacimiento.Location = new Point(662, 30);
            fechaNacimiento.Name = "fechaNacimiento";
            fechaNacimiento.Size = new Size(183, 23);
            fechaNacimiento.TabIndex = 16;
            fechaNacimiento.ValueChanged += fechaNacimiento_ValueChanged;
            // 
            // lbDireccion
            // 
            lbDireccion.AutoSize = true;
            lbDireccion.BackColor = Color.Transparent;
            lbDireccion.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbDireccion.ForeColor = SystemColors.ButtonFace;
            lbDireccion.Location = new Point(397, 105);
            lbDireccion.Name = "lbDireccion";
            lbDireccion.Size = new Size(62, 22);
            lbDireccion.TabIndex = 15;
            lbDireccion.Text = "Direccion";
            // 
            // tbDireccion
            // 
            tbDireccion.Location = new Point(341, 130);
            tbDireccion.Name = "tbDireccion";
            tbDireccion.Size = new Size(183, 23);
            tbDireccion.TabIndex = 14;
            tbDireccion.TextChanged += tbDireccion_TextChanged;
            tbDireccion.KeyPress += tbDireccion_KeyPress;
            // 
            // lbTelefono
            // 
            lbTelefono.AutoSize = true;
            lbTelefono.BackColor = Color.Transparent;
            lbTelefono.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbTelefono.ForeColor = SystemColors.ButtonFace;
            lbTelefono.Location = new Point(402, 54);
            lbTelefono.Name = "lbTelefono";
            lbTelefono.Size = new Size(58, 22);
            lbTelefono.TabIndex = 13;
            lbTelefono.Text = "Telefono";
            // 
            // tbTelefono
            // 
            tbTelefono.Location = new Point(340, 79);
            tbTelefono.Name = "tbTelefono";
            tbTelefono.Size = new Size(183, 23);
            tbTelefono.TabIndex = 12;
            tbTelefono.TextChanged += tbTelefono_TextChanged;
            tbTelefono.KeyPress += tbTelefono_KeyPress;
            // 
            // lbEmail
            // 
            lbEmail.AutoSize = true;
            lbEmail.BackColor = Color.Transparent;
            lbEmail.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbEmail.ForeColor = SystemColors.ButtonFace;
            lbEmail.Location = new Point(412, 5);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(39, 22);
            lbEmail.TabIndex = 11;
            lbEmail.Text = "Email";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(340, 30);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(183, 23);
            tbEmail.TabIndex = 10;
            tbEmail.TextChanged += tbEmail_TextChanged;
            // 
            // lbDNI
            // 
            lbDNI.AutoSize = true;
            lbDNI.BackColor = Color.Transparent;
            lbDNI.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbDNI.ForeColor = SystemColors.ButtonFace;
            lbDNI.Location = new Point(94, 105);
            lbDNI.Name = "lbDNI";
            lbDNI.Size = new Size(32, 22);
            lbDNI.TabIndex = 7;
            lbDNI.Text = "DNI";
            // 
            // tbDNI
            // 
            tbDNI.Location = new Point(22, 130);
            tbDNI.Name = "tbDNI";
            tbDNI.Size = new Size(183, 23);
            tbDNI.TabIndex = 6;
            tbDNI.TextChanged += tbDNI_TextChanged;
            tbDNI.KeyPress += tbDNI_KeyPress;
            // 
            // lbApellido
            // 
            lbApellido.AutoSize = true;
            lbApellido.BackColor = Color.Transparent;
            lbApellido.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbApellido.ForeColor = SystemColors.ButtonFace;
            lbApellido.Location = new Point(82, 54);
            lbApellido.Name = "lbApellido";
            lbApellido.Size = new Size(55, 22);
            lbApellido.TabIndex = 5;
            lbApellido.Text = "Apellido";
            // 
            // tbApellido
            // 
            tbApellido.Location = new Point(21, 79);
            tbApellido.Name = "tbApellido";
            tbApellido.Size = new Size(183, 23);
            tbApellido.TabIndex = 4;
            tbApellido.TextChanged += tbApellido_TextChanged;
            tbApellido.KeyPress += tbApellido_KeyPress;
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
            tbNombre.TextChanged += tbNombre_TextChanged;
            tbNombre.KeyPress += tbNombre_KeyPress;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(cbInactivos);
            panel2.Controls.Add(cbActivos);
            panel2.Controls.Add(dgvClientes);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 258);
            panel2.Name = "panel2";
            panel2.Size = new Size(1014, 231);
            panel2.TabIndex = 20;
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
            // dgvClientes
            // 
            dgvClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvClientes.BackgroundColor = Color.SlateGray;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvClientes.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { colDNI, colNombre, colApellido, colEmail, colTelefono, colDireccion, colFechaNacimiento, colSexo });
            dgvClientes.Location = new Point(21, 47);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(971, 170);
            dgvClientes.TabIndex = 0;
            // 
            // colDNI
            // 
            colDNI.HeaderText = "DNI";
            colDNI.MinimumWidth = 6;
            colDNI.Name = "colDNI";
            colDNI.Width = 125;
            // 
            // colNombre
            // 
            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 6;
            colNombre.Name = "colNombre";
            colNombre.Width = 125;
            // 
            // colApellido
            // 
            colApellido.HeaderText = "Apellido";
            colApellido.MinimumWidth = 6;
            colApellido.Name = "colApellido";
            colApellido.Width = 125;
            // 
            // colEmail
            // 
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            colEmail.Width = 125;
            // 
            // colTelefono
            // 
            colTelefono.HeaderText = "Telefono";
            colTelefono.MinimumWidth = 6;
            colTelefono.Name = "colTelefono";
            colTelefono.Width = 125;
            // 
            // colDireccion
            // 
            colDireccion.HeaderText = "Direccion";
            colDireccion.MinimumWidth = 6;
            colDireccion.Name = "colDireccion";
            colDireccion.Width = 125;
            // 
            // colFechaNacimiento
            // 
            colFechaNacimiento.HeaderText = "Fecha de nacimiento";
            colFechaNacimiento.MinimumWidth = 6;
            colFechaNacimiento.Name = "colFechaNacimiento";
            colFechaNacimiento.Width = 125;
            // 
            // colSexo
            // 
            colSexo.HeaderText = "Sexo";
            colSexo.MinimumWidth = 6;
            colSexo.Name = "colSexo";
            colSexo.Width = 125;
            // 
            // FRegistrarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(1014, 489);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FRegistrarCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar Cliente";
            Load += FRegistrarCliente_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            gbSexo.ResumeLayout(false);
            gbSexo.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            ResumeLayout(false);

        }

        #endregion
        private Panel panel1;
        private Label lbEliminar;
        private Label lbGuardar;
        private GroupBox gbSexo;
        private RadioButton rbMasculino;
        private RadioButton rbFemenino;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private Label lbFechaNacimiento;
        private DateTimePicker fechaNacimiento;
        private Label lbDireccion;
        private TextBox tbDireccion;
        private Label lbTelefono;
        private TextBox tbTelefono;
        private Label lbEmail;
        private TextBox tbEmail;
        private Label lbDNI;
        private TextBox tbDNI;
        private Label lbApellido;
        private TextBox tbApellido;
        private Label lbNombre;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private TextBox tbNombre;
        private Panel panel2;
        private CheckBox cbInactivos;
        private CheckBox cbActivos;
        private DataGridView dgvClientes;
        private DataGridViewTextBoxColumn colDNI;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colApellido;
        private DataGridViewTextBoxColumn colEmail;
        private DataGridViewTextBoxColumn colTelefono;
        private DataGridViewTextBoxColumn colDireccion;
        private DataGridViewTextBoxColumn colFechaNacimiento;
        private DataGridViewTextBoxColumn colSexo;
    }
}