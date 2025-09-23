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
            gbActivoCliente = new GroupBox();
            rbActivoClienteSi = new RadioButton();
            rbActivoClienteNo = new RadioButton();
            lbEliminar = new Label();
            lbGuardar = new Label();
            gbSexo = new GroupBox();
            rbOtros = new RadioButton();
            rbMasculino = new RadioButton();
            rbFemenino = new RadioButton();
            btnBorrar = new FontAwesome.Sharp.IconButton();
            lbFechaNacimiento = new Label();
            fechaNacimiento = new DateTimePicker();
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
            lbBuscadorUsuario = new Label();
            tbBusquedaNombreCliente = new TextBox();
            tbBusquedaDniCliente = new TextBox();
            cbInactivos = new CheckBox();
            cbActivos = new CheckBox();
            dgvClientes = new DataGridView();
            idCliente = new DataGridViewTextBoxColumn();
            nombreCliente = new DataGridViewTextBoxColumn();
            apellidoCliente = new DataGridViewTextBoxColumn();
            dniCliente = new DataGridViewTextBoxColumn();
            telefonoCliente = new DataGridViewTextBoxColumn();
            emailCliente = new DataGridViewTextBoxColumn();
            sexoCliente = new DataGridViewTextBoxColumn();
            fechaNacimientoCliente = new DataGridViewTextBoxColumn();
            activoCliente = new DataGridViewTextBoxColumn();
            panel1.SuspendLayout();
            gbActivoCliente.SuspendLayout();
            gbSexo.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(gbActivoCliente);
            panel1.Controls.Add(lbEliminar);
            panel1.Controls.Add(lbGuardar);
            panel1.Controls.Add(gbSexo);
            panel1.Controls.Add(btnBorrar);
            panel1.Controls.Add(lbFechaNacimiento);
            panel1.Controls.Add(fechaNacimiento);
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
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.RightToLeft = RightToLeft.No;
            panel1.Size = new Size(1159, 292);
            panel1.TabIndex = 19;
            panel1.Paint += panel1_Paint;
            // 
            // gbActivoCliente
            // 
            gbActivoCliente.BackColor = Color.Transparent;
            gbActivoCliente.Controls.Add(rbActivoClienteSi);
            gbActivoCliente.Controls.Add(rbActivoClienteNo);
            gbActivoCliente.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            gbActivoCliente.ForeColor = SystemColors.ButtonFace;
            gbActivoCliente.Location = new Point(744, 189);
            gbActivoCliente.Margin = new Padding(3, 4, 3, 4);
            gbActivoCliente.Name = "gbActivoCliente";
            gbActivoCliente.Padding = new Padding(3, 4, 3, 4);
            gbActivoCliente.Size = new Size(229, 59);
            gbActivoCliente.TabIndex = 27;
            gbActivoCliente.TabStop = false;
            gbActivoCliente.Text = "Activo";
            gbActivoCliente.Visible = false;
            // 
            // rbActivoClienteSi
            // 
            rbActivoClienteSi.AutoSize = true;
            rbActivoClienteSi.Checked = true;
            rbActivoClienteSi.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            rbActivoClienteSi.ForeColor = SystemColors.ButtonFace;
            rbActivoClienteSi.Location = new Point(19, 22);
            rbActivoClienteSi.Margin = new Padding(3, 4, 3, 4);
            rbActivoClienteSi.Name = "rbActivoClienteSi";
            rbActivoClienteSi.Size = new Size(48, 33);
            rbActivoClienteSi.TabIndex = 1;
            rbActivoClienteSi.TabStop = true;
            rbActivoClienteSi.Text = "Si";
            rbActivoClienteSi.UseVisualStyleBackColor = true;
            // 
            // rbActivoClienteNo
            // 
            rbActivoClienteNo.AutoSize = true;
            rbActivoClienteNo.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            rbActivoClienteNo.ForeColor = SystemColors.ButtonFace;
            rbActivoClienteNo.Location = new Point(133, 22);
            rbActivoClienteNo.Margin = new Padding(3, 4, 3, 4);
            rbActivoClienteNo.Name = "rbActivoClienteNo";
            rbActivoClienteNo.Size = new Size(55, 33);
            rbActivoClienteNo.TabIndex = 21;
            rbActivoClienteNo.Text = "No";
            rbActivoClienteNo.UseVisualStyleBackColor = true;
            // 
            // lbEliminar
            // 
            lbEliminar.AutoSize = true;
            lbEliminar.BackColor = Color.Transparent;
            lbEliminar.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbEliminar.ForeColor = SystemColors.ButtonFace;
            lbEliminar.Location = new Point(1049, 157);
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
            lbGuardar.Location = new Point(1043, 21);
            lbGuardar.Name = "lbGuardar";
            lbGuardar.Size = new Size(72, 29);
            lbGuardar.TabIndex = 25;
            lbGuardar.Text = "Guardar";
            // 
            // gbSexo
            // 
            gbSexo.Controls.Add(rbOtros);
            gbSexo.Controls.Add(rbMasculino);
            gbSexo.Controls.Add(rbFemenino);
            gbSexo.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            gbSexo.ForeColor = SystemColors.ButtonFace;
            gbSexo.Location = new Point(744, 21);
            gbSexo.Margin = new Padding(3, 4, 3, 4);
            gbSexo.Name = "gbSexo";
            gbSexo.Padding = new Padding(3, 4, 3, 4);
            gbSexo.Size = new Size(229, 148);
            gbSexo.TabIndex = 22;
            gbSexo.TabStop = false;
            gbSexo.Text = "Sexo";
            // 
            // rbOtros
            // 
            rbOtros.AutoSize = true;
            rbOtros.Checked = true;
            rbOtros.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            rbOtros.ForeColor = SystemColors.ButtonFace;
            rbOtros.Location = new Point(19, 105);
            rbOtros.Margin = new Padding(3, 4, 3, 4);
            rbOtros.Name = "rbOtros";
            rbOtros.Size = new Size(75, 33);
            rbOtros.TabIndex = 22;
            rbOtros.TabStop = true;
            rbOtros.Text = "Otros";
            rbOtros.UseVisualStyleBackColor = true;
            rbOtros.CheckedChanged += rbOtros_CheckedChanged;
            // 
            // rbMasculino
            // 
            rbMasculino.AutoSize = true;
            rbMasculino.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            rbMasculino.ForeColor = SystemColors.ButtonFace;
            rbMasculino.Location = new Point(19, 29);
            rbMasculino.Margin = new Padding(3, 4, 3, 4);
            rbMasculino.Name = "rbMasculino";
            rbMasculino.Size = new Size(106, 33);
            rbMasculino.TabIndex = 1;
            rbMasculino.Text = "Masculino";
            rbMasculino.UseVisualStyleBackColor = true;
            rbMasculino.CheckedChanged += rbMasculino_CheckedChanged;
            // 
            // rbFemenino
            // 
            rbFemenino.AutoSize = true;
            rbFemenino.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            rbFemenino.ForeColor = SystemColors.ButtonFace;
            rbFemenino.Location = new Point(19, 65);
            rbFemenino.Margin = new Padding(3, 4, 3, 4);
            rbFemenino.Name = "rbFemenino";
            rbFemenino.Size = new Size(104, 33);
            rbFemenino.TabIndex = 21;
            rbFemenino.Text = "Femenino";
            rbFemenino.UseVisualStyleBackColor = true;
            rbFemenino.CheckedChanged += rbFemenino_CheckedChanged;
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
            // lbFechaNacimiento
            // 
            lbFechaNacimiento.AutoSize = true;
            lbFechaNacimiento.BackColor = Color.Transparent;
            lbFechaNacimiento.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbFechaNacimiento.ForeColor = SystemColors.ButtonFace;
            lbFechaNacimiento.Location = new Point(418, 142);
            lbFechaNacimiento.Name = "lbFechaNacimiento";
            lbFechaNacimiento.Size = new Size(159, 29);
            lbFechaNacimiento.TabIndex = 17;
            lbFechaNacimiento.Text = "Fecha de nacimiento";
            // 
            // fechaNacimiento
            // 
            fechaNacimiento.Location = new Point(389, 173);
            fechaNacimiento.Margin = new Padding(3, 4, 3, 4);
            fechaNacimiento.Name = "fechaNacimiento";
            fechaNacimiento.Size = new Size(209, 27);
            fechaNacimiento.TabIndex = 16;
            fechaNacimiento.ValueChanged += fechaNacimiento_ValueChanged;
            // 
            // lbTelefono
            // 
            lbTelefono.AutoSize = true;
            lbTelefono.BackColor = Color.Transparent;
            lbTelefono.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbTelefono.ForeColor = SystemColors.ButtonFace;
            lbTelefono.Location = new Point(459, 72);
            lbTelefono.Name = "lbTelefono";
            lbTelefono.Size = new Size(80, 29);
            lbTelefono.TabIndex = 13;
            lbTelefono.Text = "Telefono ";
            // 
            // tbTelefono
            // 
            tbTelefono.Location = new Point(389, 105);
            tbTelefono.Margin = new Padding(3, 4, 3, 4);
            tbTelefono.Name = "tbTelefono";
            tbTelefono.Size = new Size(209, 27);
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
            lbEmail.Location = new Point(462, 7);
            lbEmail.Name = "lbEmail";
            lbEmail.Size = new Size(76, 29);
            lbEmail.TabIndex = 11;
            lbEmail.Text = "Email (*)";
            // 
            // tbEmail
            // 
            tbEmail.Location = new Point(389, 40);
            tbEmail.Margin = new Padding(3, 4, 3, 4);
            tbEmail.Name = "tbEmail";
            tbEmail.Size = new Size(209, 27);
            tbEmail.TabIndex = 10;
            tbEmail.TextChanged += tbEmail_TextChanged;
            // 
            // lbDNI
            // 
            lbDNI.AutoSize = true;
            lbDNI.BackColor = Color.Transparent;
            lbDNI.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbDNI.ForeColor = SystemColors.ButtonFace;
            lbDNI.Location = new Point(94, 140);
            lbDNI.Name = "lbDNI";
            lbDNI.Size = new Size(66, 29);
            lbDNI.TabIndex = 7;
            lbDNI.Text = "DNI (*)";
            // 
            // tbDNI
            // 
            tbDNI.Location = new Point(25, 173);
            tbDNI.Margin = new Padding(3, 4, 3, 4);
            tbDNI.Name = "tbDNI";
            tbDNI.Size = new Size(209, 27);
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
            lbApellido.Location = new Point(86, 72);
            lbApellido.Name = "lbApellido";
            lbApellido.Size = new Size(95, 29);
            lbApellido.TabIndex = 5;
            lbApellido.Text = "Apellido (*)";
            // 
            // tbApellido
            // 
            tbApellido.Location = new Point(24, 105);
            tbApellido.Margin = new Padding(3, 4, 3, 4);
            tbApellido.Name = "tbApellido";
            tbApellido.Size = new Size(209, 27);
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
            lbNombre.Location = new Point(87, 7);
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
            panel2.Controls.Add(lbBuscadorUsuario);
            panel2.Controls.Add(tbBusquedaNombreCliente);
            panel2.Controls.Add(tbBusquedaDniCliente);
            panel2.Controls.Add(cbInactivos);
            panel2.Controls.Add(cbActivos);
            panel2.Controls.Add(dgvClientes);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 291);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1159, 361);
            panel2.TabIndex = 20;
            // 
            // lbBuscadorUsuario
            // 
            lbBuscadorUsuario.AutoSize = true;
            lbBuscadorUsuario.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            lbBuscadorUsuario.ForeColor = SystemColors.ButtonFace;
            lbBuscadorUsuario.Location = new Point(808, 6);
            lbBuscadorUsuario.Name = "lbBuscadorUsuario";
            lbBuscadorUsuario.Size = new Size(95, 29);
            lbBuscadorUsuario.TabIndex = 36;
            lbBuscadorUsuario.Text = "Buscar por:";
            // 
            // tbBusquedaNombreCliente
            // 
            tbBusquedaNombreCliente.Location = new Point(877, 38);
            tbBusquedaNombreCliente.Multiline = true;
            tbBusquedaNombreCliente.Name = "tbBusquedaNombreCliente";
            tbBusquedaNombreCliente.PlaceholderText = "Busqueda por Nombre";
            tbBusquedaNombreCliente.Size = new Size(209, 27);
            tbBusquedaNombreCliente.TabIndex = 35;
            // 
            // tbBusquedaDniCliente
            // 
            tbBusquedaDniCliente.Location = new Point(619, 38);
            tbBusquedaDniCliente.Multiline = true;
            tbBusquedaDniCliente.Name = "tbBusquedaDniCliente";
            tbBusquedaDniCliente.PlaceholderText = "Busqueda por DNI";
            tbBusquedaDniCliente.Size = new Size(209, 27);
            tbBusquedaDniCliente.TabIndex = 34;
            tbBusquedaDniCliente.TextChanged += tbBusquedaDniCliente_TextChanged;
            // 
            // cbInactivos
            // 
            cbInactivos.AutoSize = true;
            cbInactivos.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            cbInactivos.ForeColor = SystemColors.ButtonFace;
            cbInactivos.Location = new Point(135, 38);
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
            cbActivos.Location = new Point(25, 38);
            cbActivos.Margin = new Padding(3, 4, 3, 4);
            cbActivos.Name = "cbActivos";
            cbActivos.Size = new Size(88, 33);
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
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { idCliente, nombreCliente, apellidoCliente, dniCliente, telefonoCliente, emailCliente, sexoCliente, fechaNacimientoCliente, activoCliente });
            dgvClientes.Location = new Point(24, 79);
            dgvClientes.Margin = new Padding(3, 4, 3, 4);
            dgvClientes.Name = "dgvClientes";
            dgvClientes.RowHeadersWidth = 51;
            dgvClientes.Size = new Size(1110, 264);
            dgvClientes.TabIndex = 0;
            dgvClientes.CellContentClick += dgvClientes_CellContentClick;
            // 
            // idCliente
            // 
            idCliente.HeaderText = "ID Cliente";
            idCliente.MinimumWidth = 6;
            idCliente.Name = "idCliente";
            idCliente.Width = 125;
            // 
            // nombreCliente
            // 
            nombreCliente.HeaderText = "Nombre";
            nombreCliente.MinimumWidth = 6;
            nombreCliente.Name = "nombreCliente";
            nombreCliente.Width = 125;
            // 
            // apellidoCliente
            // 
            apellidoCliente.HeaderText = "Apellido";
            apellidoCliente.MinimumWidth = 6;
            apellidoCliente.Name = "apellidoCliente";
            apellidoCliente.Width = 125;
            // 
            // dniCliente
            // 
            dniCliente.HeaderText = "DNI";
            dniCliente.MinimumWidth = 6;
            dniCliente.Name = "dniCliente";
            dniCliente.Width = 125;
            // 
            // telefonoCliente
            // 
            telefonoCliente.HeaderText = "Telefono";
            telefonoCliente.MinimumWidth = 6;
            telefonoCliente.Name = "telefonoCliente";
            telefonoCliente.Width = 125;
            // 
            // emailCliente
            // 
            emailCliente.HeaderText = "Email";
            emailCliente.MinimumWidth = 6;
            emailCliente.Name = "emailCliente";
            emailCliente.Width = 125;
            // 
            // sexoCliente
            // 
            sexoCliente.HeaderText = "Sexo";
            sexoCliente.MinimumWidth = 6;
            sexoCliente.Name = "sexoCliente";
            sexoCliente.Width = 125;
            // 
            // fechaNacimientoCliente
            // 
            fechaNacimientoCliente.HeaderText = "Fecha Nacimiento";
            fechaNacimientoCliente.MinimumWidth = 6;
            fechaNacimientoCliente.Name = "fechaNacimientoCliente";
            fechaNacimientoCliente.Width = 125;
            // 
            // activoCliente
            // 
            activoCliente.HeaderText = "Activo";
            activoCliente.MinimumWidth = 6;
            activoCliente.Name = "activoCliente";
            activoCliente.Width = 125;
            // 
            // FRegistrarCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(1159, 652);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FRegistrarCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Registrar Cliente";
            Load += FRegistrarCliente_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            gbActivoCliente.ResumeLayout(false);
            gbActivoCliente.PerformLayout();
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
        private FontAwesome.Sharp.IconButton btnBorrar;
        private Label lbFechaNacimiento;
        private DateTimePicker fechaNacimiento;
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
        private RadioButton rbOtros;
        private Label lbBuscadorUsuario;
        private TextBox tbBusquedaNombreCliente;
        private TextBox tbBusquedaDniCliente;
        private GroupBox gbActivoCliente;
        private RadioButton rbActivoClienteSi;
        private RadioButton rbActivoClienteNo;
        private DataGridViewTextBoxColumn idCliente;
        private DataGridViewTextBoxColumn nombreCliente;
        private DataGridViewTextBoxColumn apellidoCliente;
        private DataGridViewTextBoxColumn dniCliente;
        private DataGridViewTextBoxColumn telefonoCliente;
        private DataGridViewTextBoxColumn emailCliente;
        private DataGridViewTextBoxColumn sexoCliente;
        private DataGridViewTextBoxColumn fechaNacimientoCliente;
        private DataGridViewTextBoxColumn activoCliente;
    }
}