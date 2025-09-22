namespace ProyectoNetshop.formularios
{
    partial class usuarios
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
            cbOcultalContraseniaUser = new CheckBox();
            lbDniUsuario = new Label();
            tbDniUsuario = new TextBox();
            gbActivoUsuario = new GroupBox();
            rbActivoUsuarioSi = new RadioButton();
            rbActivoUsuarioNo = new RadioButton();
            lbBorrar = new Label();
            lbGuardar = new Label();
            lbPerfilUsuario = new Label();
            cbPerfilUsuario = new ComboBox();
            gbSexoUsuario = new GroupBox();
            rbOtrosUsuario = new RadioButton();
            rbMasculinoUsuario = new RadioButton();
            rbFemeninoUsuario = new RadioButton();
            btnBorrar = new FontAwesome.Sharp.IconButton();
            lbFechaNacimientoUsuario = new Label();
            fechaNacimientoUsuario = new DateTimePicker();
            lbEmailUsuario = new Label();
            tbEmailUsuario = new TextBox();
            lbContraseniaUsuario = new Label();
            tbContraseniaUsuario = new TextBox();
            lbTelefonoUsuario = new Label();
            tbTelefonoUsuario = new TextBox();
            lbApellidoUsuario = new Label();
            tbApellidoUsuario = new TextBox();
            lbNombreUsuario = new Label();
            btnGuardar = new FontAwesome.Sharp.IconButton();
            tbNombreUsuario = new TextBox();
            panel2 = new Panel();
            lbBuscadorUsuario = new Label();
            tbBusquedaNombreUsuario = new TextBox();
            tbBusquedaDniUsuario = new TextBox();
            cbInactivosUsuarios = new CheckBox();
            cbActivosUsuarios = new CheckBox();
            dgvUsuarios = new DataGridView();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            panel1.SuspendLayout();
            gbActivoUsuario.SuspendLayout();
            gbSexoUsuario.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(cbOcultalContraseniaUser);
            panel1.Controls.Add(lbDniUsuario);
            panel1.Controls.Add(tbDniUsuario);
            panel1.Controls.Add(gbActivoUsuario);
            panel1.Controls.Add(lbBorrar);
            panel1.Controls.Add(lbGuardar);
            panel1.Controls.Add(lbPerfilUsuario);
            panel1.Controls.Add(cbPerfilUsuario);
            panel1.Controls.Add(gbSexoUsuario);
            panel1.Controls.Add(btnBorrar);
            panel1.Controls.Add(lbFechaNacimientoUsuario);
            panel1.Controls.Add(fechaNacimientoUsuario);
            panel1.Controls.Add(lbEmailUsuario);
            panel1.Controls.Add(tbEmailUsuario);
            panel1.Controls.Add(lbContraseniaUsuario);
            panel1.Controls.Add(tbContraseniaUsuario);
            panel1.Controls.Add(lbTelefonoUsuario);
            panel1.Controls.Add(tbTelefonoUsuario);
            panel1.Controls.Add(lbApellidoUsuario);
            panel1.Controls.Add(tbApellidoUsuario);
            panel1.Controls.Add(lbNombreUsuario);
            panel1.Controls.Add(btnGuardar);
            panel1.Controls.Add(tbNombreUsuario);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.RightToLeft = RightToLeft.No;
            panel1.Size = new Size(1159, 292);
            panel1.TabIndex = 0;
            // 
            // cbOcultalContraseniaUser
            // 
            cbOcultalContraseniaUser.AutoSize = true;
            cbOcultalContraseniaUser.Location = new Point(604, 111);
            cbOcultalContraseniaUser.Name = "cbOcultalContraseniaUser";
            cbOcultalContraseniaUser.Size = new Size(18, 17);
            cbOcultalContraseniaUser.TabIndex = 29;
            cbOcultalContraseniaUser.UseVisualStyleBackColor = true;
            cbOcultalContraseniaUser.CheckedChanged += cbOcultalContraseniaUser_CheckedChanged;
            // 
            // lbDniUsuario
            // 
            lbDniUsuario.AutoSize = true;
            lbDniUsuario.BackColor = Color.Transparent;
            lbDniUsuario.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbDniUsuario.ForeColor = SystemColors.ButtonFace;
            lbDniUsuario.Location = new Point(97, 207);
            lbDniUsuario.Name = "lbDniUsuario";
            lbDniUsuario.Size = new Size(66, 29);
            lbDniUsuario.TabIndex = 28;
            lbDniUsuario.Text = "DNI (*)";
            // 
            // tbDniUsuario
            // 
            tbDniUsuario.Location = new Point(24, 239);
            tbDniUsuario.Multiline = true;
            tbDniUsuario.Name = "tbDniUsuario";
            tbDniUsuario.Size = new Size(210, 27);
            tbDniUsuario.TabIndex = 27;
            // 
            // gbActivoUsuario
            // 
            gbActivoUsuario.BackColor = Color.Transparent;
            gbActivoUsuario.Controls.Add(rbActivoUsuarioSi);
            gbActivoUsuario.Controls.Add(rbActivoUsuarioNo);
            gbActivoUsuario.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            gbActivoUsuario.ForeColor = SystemColors.ButtonFace;
            gbActivoUsuario.Location = new Point(737, 176);
            gbActivoUsuario.Margin = new Padding(3, 4, 3, 4);
            gbActivoUsuario.Name = "gbActivoUsuario";
            gbActivoUsuario.Padding = new Padding(3, 4, 3, 4);
            gbActivoUsuario.Size = new Size(229, 59);
            gbActivoUsuario.TabIndex = 23;
            gbActivoUsuario.TabStop = false;
            gbActivoUsuario.Text = "Activo";
            gbActivoUsuario.Visible = false;
            // 
            // rbActivoUsuarioSi
            // 
            rbActivoUsuarioSi.AutoSize = true;
            rbActivoUsuarioSi.Checked = true;
            rbActivoUsuarioSi.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            rbActivoUsuarioSi.ForeColor = SystemColors.ButtonFace;
            rbActivoUsuarioSi.Location = new Point(19, 21);
            rbActivoUsuarioSi.Margin = new Padding(3, 4, 3, 4);
            rbActivoUsuarioSi.Name = "rbActivoUsuarioSi";
            rbActivoUsuarioSi.Size = new Size(48, 33);
            rbActivoUsuarioSi.TabIndex = 1;
            rbActivoUsuarioSi.TabStop = true;
            rbActivoUsuarioSi.Text = "Si";
            rbActivoUsuarioSi.UseVisualStyleBackColor = true;
            // 
            // rbActivoUsuarioNo
            // 
            rbActivoUsuarioNo.AutoSize = true;
            rbActivoUsuarioNo.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            rbActivoUsuarioNo.ForeColor = SystemColors.ButtonFace;
            rbActivoUsuarioNo.Location = new Point(133, 21);
            rbActivoUsuarioNo.Margin = new Padding(3, 4, 3, 4);
            rbActivoUsuarioNo.Name = "rbActivoUsuarioNo";
            rbActivoUsuarioNo.Size = new Size(55, 33);
            rbActivoUsuarioNo.TabIndex = 21;
            rbActivoUsuarioNo.Text = "No";
            rbActivoUsuarioNo.UseVisualStyleBackColor = true;
            // 
            // lbBorrar
            // 
            lbBorrar.AutoSize = true;
            lbBorrar.BackColor = Color.Transparent;
            lbBorrar.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbBorrar.ForeColor = SystemColors.ButtonFace;
            lbBorrar.Location = new Point(1045, 157);
            lbBorrar.Name = "lbBorrar";
            lbBorrar.Size = new Size(61, 29);
            lbBorrar.TabIndex = 26;
            lbBorrar.Text = "Borrar";
            // 
            // lbGuardar
            // 
            lbGuardar.AutoSize = true;
            lbGuardar.BackColor = Color.Transparent;
            lbGuardar.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbGuardar.ForeColor = SystemColors.ButtonFace;
            lbGuardar.Location = new Point(1040, 23);
            lbGuardar.Name = "lbGuardar";
            lbGuardar.Size = new Size(72, 29);
            lbGuardar.TabIndex = 25;
            lbGuardar.Text = "Guardar";
            // 
            // lbPerfilUsuario
            // 
            lbPerfilUsuario.AutoSize = true;
            lbPerfilUsuario.BackColor = Color.Transparent;
            lbPerfilUsuario.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbPerfilUsuario.ForeColor = SystemColors.ButtonFace;
            lbPerfilUsuario.Location = new Point(460, 206);
            lbPerfilUsuario.Name = "lbPerfilUsuario";
            lbPerfilUsuario.Size = new Size(76, 29);
            lbPerfilUsuario.TabIndex = 24;
            lbPerfilUsuario.Text = "Perfil (*)";
            // 
            // cbPerfilUsuario
            // 
            cbPerfilUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPerfilUsuario.FormattingEnabled = true;
            cbPerfilUsuario.Location = new Point(389, 238);
            cbPerfilUsuario.Margin = new Padding(3, 4, 3, 4);
            cbPerfilUsuario.Name = "cbPerfilUsuario";
            cbPerfilUsuario.Size = new Size(209, 28);
            cbPerfilUsuario.TabIndex = 23;
            cbPerfilUsuario.SelectedIndexChanged += cbPerfilUsuario_SelectedIndexChanged;
            // 
            // gbSexoUsuario
            // 
            gbSexoUsuario.Controls.Add(rbOtrosUsuario);
            gbSexoUsuario.Controls.Add(rbMasculinoUsuario);
            gbSexoUsuario.Controls.Add(rbFemeninoUsuario);
            gbSexoUsuario.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            gbSexoUsuario.ForeColor = SystemColors.ButtonFace;
            gbSexoUsuario.Location = new Point(737, 23);
            gbSexoUsuario.Margin = new Padding(3, 4, 3, 4);
            gbSexoUsuario.Name = "gbSexoUsuario";
            gbSexoUsuario.Padding = new Padding(3, 4, 3, 4);
            gbSexoUsuario.Size = new Size(229, 145);
            gbSexoUsuario.TabIndex = 22;
            gbSexoUsuario.TabStop = false;
            gbSexoUsuario.Text = "Sexo";
            // 
            // rbOtrosUsuario
            // 
            rbOtrosUsuario.AutoSize = true;
            rbOtrosUsuario.Checked = true;
            rbOtrosUsuario.Location = new Point(19, 99);
            rbOtrosUsuario.Name = "rbOtrosUsuario";
            rbOtrosUsuario.Size = new Size(75, 33);
            rbOtrosUsuario.TabIndex = 22;
            rbOtrosUsuario.TabStop = true;
            rbOtrosUsuario.Text = "Otros";
            rbOtrosUsuario.UseVisualStyleBackColor = true;
            // 
            // rbMasculinoUsuario
            // 
            rbMasculinoUsuario.AutoSize = true;
            rbMasculinoUsuario.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            rbMasculinoUsuario.ForeColor = SystemColors.ButtonFace;
            rbMasculinoUsuario.Location = new Point(19, 21);
            rbMasculinoUsuario.Margin = new Padding(3, 4, 3, 4);
            rbMasculinoUsuario.Name = "rbMasculinoUsuario";
            rbMasculinoUsuario.Size = new Size(106, 33);
            rbMasculinoUsuario.TabIndex = 1;
            rbMasculinoUsuario.Text = "Masculino";
            rbMasculinoUsuario.UseVisualStyleBackColor = true;
            // 
            // rbFemeninoUsuario
            // 
            rbFemeninoUsuario.AutoSize = true;
            rbFemeninoUsuario.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            rbFemeninoUsuario.ForeColor = SystemColors.ButtonFace;
            rbFemeninoUsuario.Location = new Point(19, 61);
            rbFemeninoUsuario.Margin = new Padding(3, 4, 3, 4);
            rbFemeninoUsuario.Name = "rbFemeninoUsuario";
            rbFemeninoUsuario.Size = new Size(104, 33);
            rbFemeninoUsuario.TabIndex = 21;
            rbFemeninoUsuario.Text = "Femenino";
            rbFemeninoUsuario.UseVisualStyleBackColor = true;
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
            // lbFechaNacimientoUsuario
            // 
            lbFechaNacimientoUsuario.AutoSize = true;
            lbFechaNacimientoUsuario.BackColor = Color.Transparent;
            lbFechaNacimientoUsuario.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbFechaNacimientoUsuario.ForeColor = SystemColors.ButtonFace;
            lbFechaNacimientoUsuario.Location = new Point(418, 140);
            lbFechaNacimientoUsuario.Name = "lbFechaNacimientoUsuario";
            lbFechaNacimientoUsuario.Size = new Size(159, 29);
            lbFechaNacimientoUsuario.TabIndex = 17;
            lbFechaNacimientoUsuario.Text = "Fecha de nacimiento";
            // 
            // fechaNacimientoUsuario
            // 
            fechaNacimientoUsuario.Location = new Point(389, 171);
            fechaNacimientoUsuario.Margin = new Padding(3, 4, 3, 4);
            fechaNacimientoUsuario.Name = "fechaNacimientoUsuario";
            fechaNacimientoUsuario.Size = new Size(209, 27);
            fechaNacimientoUsuario.TabIndex = 16;
            fechaNacimientoUsuario.Value = new DateTime(2025, 9, 20, 0, 8, 37, 0);
            fechaNacimientoUsuario.ValueChanged += fechaNacimiento_ValueChanged;
            // 
            // lbEmailUsuario
            // 
            lbEmailUsuario.AutoSize = true;
            lbEmailUsuario.BackColor = Color.Transparent;
            lbEmailUsuario.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbEmailUsuario.ForeColor = SystemColors.ButtonFace;
            lbEmailUsuario.Location = new Point(93, 139);
            lbEmailUsuario.Name = "lbEmailUsuario";
            lbEmailUsuario.Size = new Size(76, 29);
            lbEmailUsuario.TabIndex = 11;
            lbEmailUsuario.Text = "Email (*)";
            lbEmailUsuario.Click += lbEmail_Click;
            // 
            // tbEmailUsuario
            // 
            tbEmailUsuario.Location = new Point(25, 171);
            tbEmailUsuario.Margin = new Padding(3, 4, 3, 4);
            tbEmailUsuario.Name = "tbEmailUsuario";
            tbEmailUsuario.Size = new Size(209, 27);
            tbEmailUsuario.TabIndex = 10;
            // 
            // lbContraseniaUsuario
            // 
            lbContraseniaUsuario.AutoSize = true;
            lbContraseniaUsuario.BackColor = Color.Transparent;
            lbContraseniaUsuario.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbContraseniaUsuario.ForeColor = SystemColors.ButtonFace;
            lbContraseniaUsuario.Location = new Point(437, 72);
            lbContraseniaUsuario.Name = "lbContraseniaUsuario";
            lbContraseniaUsuario.Size = new Size(118, 29);
            lbContraseniaUsuario.TabIndex = 9;
            lbContraseniaUsuario.Text = "Contraseña (*)";
            // 
            // tbContraseniaUsuario
            // 
            tbContraseniaUsuario.Location = new Point(389, 105);
            tbContraseniaUsuario.Margin = new Padding(3, 4, 3, 4);
            tbContraseniaUsuario.Name = "tbContraseniaUsuario";
            tbContraseniaUsuario.Size = new Size(209, 27);
            tbContraseniaUsuario.TabIndex = 8;
            // 
            // lbTelefonoUsuario
            // 
            lbTelefonoUsuario.AutoSize = true;
            lbTelefonoUsuario.BackColor = Color.Transparent;
            lbTelefonoUsuario.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbTelefonoUsuario.ForeColor = SystemColors.ButtonFace;
            lbTelefonoUsuario.Location = new Point(459, 7);
            lbTelefonoUsuario.Name = "lbTelefonoUsuario";
            lbTelefonoUsuario.Size = new Size(76, 29);
            lbTelefonoUsuario.TabIndex = 7;
            lbTelefonoUsuario.Text = "Telefono";
            // 
            // tbTelefonoUsuario
            // 
            tbTelefonoUsuario.Location = new Point(389, 40);
            tbTelefonoUsuario.Margin = new Padding(3, 4, 3, 4);
            tbTelefonoUsuario.Name = "tbTelefonoUsuario";
            tbTelefonoUsuario.Size = new Size(209, 27);
            tbTelefonoUsuario.TabIndex = 6;
            // 
            // lbApellidoUsuario
            // 
            lbApellidoUsuario.AutoSize = true;
            lbApellidoUsuario.BackColor = Color.Transparent;
            lbApellidoUsuario.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbApellidoUsuario.ForeColor = SystemColors.ButtonFace;
            lbApellidoUsuario.Location = new Point(85, 72);
            lbApellidoUsuario.Name = "lbApellidoUsuario";
            lbApellidoUsuario.Size = new Size(95, 29);
            lbApellidoUsuario.TabIndex = 5;
            lbApellidoUsuario.Text = "Apellido (*)";
            // 
            // tbApellidoUsuario
            // 
            tbApellidoUsuario.Location = new Point(25, 105);
            tbApellidoUsuario.Margin = new Padding(3, 4, 3, 4);
            tbApellidoUsuario.Name = "tbApellidoUsuario";
            tbApellidoUsuario.Size = new Size(209, 27);
            tbApellidoUsuario.TabIndex = 4;
            tbApellidoUsuario.KeyPress += tbApellido_KeyPress;
            // 
            // lbNombreUsuario
            // 
            lbNombreUsuario.AutoSize = true;
            lbNombreUsuario.BackColor = Color.Transparent;
            lbNombreUsuario.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbNombreUsuario.ForeColor = SystemColors.ButtonFace;
            lbNombreUsuario.Location = new Point(85, 7);
            lbNombreUsuario.Name = "lbNombreUsuario";
            lbNombreUsuario.Size = new Size(96, 29);
            lbNombreUsuario.TabIndex = 3;
            lbNombreUsuario.Text = "Nombre (*)";
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
            // tbNombreUsuario
            // 
            tbNombreUsuario.Location = new Point(24, 40);
            tbNombreUsuario.Margin = new Padding(3, 4, 3, 4);
            tbNombreUsuario.Name = "tbNombreUsuario";
            tbNombreUsuario.Size = new Size(209, 27);
            tbNombreUsuario.TabIndex = 1;
            tbNombreUsuario.TextChanged += tbNombreUsuario_TextChanged;
            tbNombreUsuario.KeyPress += tbNombre_KeyPress;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(lbBuscadorUsuario);
            panel2.Controls.Add(tbBusquedaNombreUsuario);
            panel2.Controls.Add(tbBusquedaDniUsuario);
            panel2.Controls.Add(cbInactivosUsuarios);
            panel2.Controls.Add(cbActivosUsuarios);
            panel2.Controls.Add(dgvUsuarios);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 345);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1159, 307);
            panel2.TabIndex = 1;
            // 
            // lbBuscadorUsuario
            // 
            lbBuscadorUsuario.AutoSize = true;
            lbBuscadorUsuario.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            lbBuscadorUsuario.ForeColor = SystemColors.ButtonFace;
            lbBuscadorUsuario.Location = new Point(840, 1);
            lbBuscadorUsuario.Name = "lbBuscadorUsuario";
            lbBuscadorUsuario.Size = new Size(95, 29);
            lbBuscadorUsuario.TabIndex = 33;
            lbBuscadorUsuario.Text = "Buscar por:";
            // 
            // tbBusquedaNombreUsuario
            // 
            tbBusquedaNombreUsuario.Location = new Point(910, 33);
            tbBusquedaNombreUsuario.Multiline = true;
            tbBusquedaNombreUsuario.Name = "tbBusquedaNombreUsuario";
            tbBusquedaNombreUsuario.PlaceholderText = "Busqueda por Nombre";
            tbBusquedaNombreUsuario.Size = new Size(209, 27);
            tbBusquedaNombreUsuario.TabIndex = 32;
            tbBusquedaNombreUsuario.TextChanged += tbBusquedaNombreUsuario_TextChanged;
            // 
            // tbBusquedaDniUsuario
            // 
            tbBusquedaDniUsuario.Location = new Point(653, 33);
            tbBusquedaDniUsuario.Multiline = true;
            tbBusquedaDniUsuario.Name = "tbBusquedaDniUsuario";
            tbBusquedaDniUsuario.PlaceholderText = "Busqueda por DNI";
            tbBusquedaDniUsuario.Size = new Size(209, 27);
            tbBusquedaDniUsuario.TabIndex = 31;
            tbBusquedaDniUsuario.TextChanged += tbBusquedaDniUsuario_TextChanged;
            // 
            // cbInactivosUsuarios
            // 
            cbInactivosUsuarios.AutoSize = true;
            cbInactivosUsuarios.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            cbInactivosUsuarios.ForeColor = SystemColors.ButtonFace;
            cbInactivosUsuarios.Location = new Point(134, 27);
            cbInactivosUsuarios.Margin = new Padding(3, 4, 3, 4);
            cbInactivosUsuarios.Name = "cbInactivosUsuarios";
            cbInactivosUsuarios.Size = new Size(99, 33);
            cbInactivosUsuarios.TabIndex = 30;
            cbInactivosUsuarios.Text = "Inactivos";
            cbInactivosUsuarios.UseVisualStyleBackColor = true;
            // 
            // cbActivosUsuarios
            // 
            cbActivosUsuarios.AutoSize = true;
            cbActivosUsuarios.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            cbActivosUsuarios.ForeColor = SystemColors.ButtonFace;
            cbActivosUsuarios.Location = new Point(25, 27);
            cbActivosUsuarios.Margin = new Padding(3, 4, 3, 4);
            cbActivosUsuarios.Name = "cbActivosUsuarios";
            cbActivosUsuarios.Size = new Size(88, 33);
            cbActivosUsuarios.TabIndex = 29;
            cbActivosUsuarios.Text = "Activos";
            cbActivosUsuarios.UseVisualStyleBackColor = true;
            cbActivosUsuarios.CheckedChanged += cbActivosUsuarios_CheckedChanged;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.AllowUserToAddRows = false;
            dgvUsuarios.AllowUserToDeleteRows = false;
            dgvUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvUsuarios.BackgroundColor = Color.SlateGray;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvUsuarios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvUsuarios.Location = new Point(24, 68);
            dgvUsuarios.Margin = new Padding(3, 4, 3, 4);
            dgvUsuarios.MultiSelect = false;
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.ReadOnly = true;
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsuarios.Size = new Size(1112, 213);
            dgvUsuarios.TabIndex = 0;
            dgvUsuarios.CellContentClick += dgvUsuarios_CellContentClick;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // usuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(1159, 652);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "usuarios";
            Text = "usuarios";
            Load += usuarios_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            gbActivoUsuario.ResumeLayout(false);
            gbActivoUsuario.PerformLayout();
            gbSexoUsuario.ResumeLayout(false);
            gbSexoUsuario.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private TextBox tbNombreUsuario;
        private Label lbNombreUsuario;
        private Label lbContraseniaUsuario;
        private TextBox tbContraseniaUsuario;
        private Label lbTelefonoUsuario;
        private TextBox tbTelefonoUsuario;
        private Label lbApellidoUsuario;
        private TextBox tbApellidoUsuario;
        private Label lbEmailUsuario;
        private TextBox tbEmailUsuario;
        private FontAwesome.Sharp.IconButton btnBorrar;
        private RadioButton rbFemeninoUsuario;
        private RadioButton rbMasculinoUsuario;
        private Panel panel2;
        private DataGridView dgvUsuarios;
        private GroupBox gbSexoUsuario;
        private Label lbPerfilUsuario;
        private ComboBox cbPerfilUsuario;
        private Label lbBorrar;
        private Label lbGuardar;
        private CheckBox cbInactivosUsuarios;
        private CheckBox cbActivosUsuarios;
        private Label lbFechaNacimientoUsuario;
        private DateTimePicker fechaNacimientoUsuario;
        private GroupBox gbActivoUsuario;
        private RadioButton rbActivoUsuarioSi;
        private RadioButton rbActivoUsuarioNo;
        private TextBox tbDniUsuario;
        private Label lbDniUsuario;
        private RadioButton rbOtrosUsuario;
        private Label lbBuscadorUsuario;
        private TextBox tbBusquedaNombreUsuario;
        private TextBox tbBusquedaDniUsuario;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private CheckBox cbOcultalContraseniaUser;
    }
}