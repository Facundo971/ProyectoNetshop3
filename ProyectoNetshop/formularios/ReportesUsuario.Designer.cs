namespace vistaDeProyectoC
{
    partial class FReporteUsuario
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
            LReporteDeUsuarios = new Label();
            BGenerarReporteUsuario = new Button();
            dgvReporteUsuarios = new DataGridView();
            idUsuario = new DataGridViewTextBoxColumn();
            nombreUsuario = new DataGridViewTextBoxColumn();
            apellidoUsuario = new DataGridViewTextBoxColumn();
            emailUsuario = new DataGridViewTextBoxColumn();
            dniUsuario = new DataGridViewTextBoxColumn();
            telefonoUsuario = new DataGridViewTextBoxColumn();
            sexoUsuario = new DataGridViewTextBoxColumn();
            fechaNacimientoUsuario = new DataGridViewTextBoxColumn();
            perfilUsuario = new DataGridViewTextBoxColumn();
            activoUsuario = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvReporteUsuarios).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // LReporteDeUsuarios
            // 
            LReporteDeUsuarios.AutoSize = true;
            LReporteDeUsuarios.Font = new Font("Dubai", 20F, FontStyle.Bold | FontStyle.Italic);
            LReporteDeUsuarios.ForeColor = SystemColors.ButtonFace;
            LReporteDeUsuarios.Location = new Point(413, 47);
            LReporteDeUsuarios.Name = "LReporteDeUsuarios";
            LReporteDeUsuarios.Size = new Size(321, 57);
            LReporteDeUsuarios.TabIndex = 0;
            LReporteDeUsuarios.Text = "Reporte de Usuarios";
            LReporteDeUsuarios.Click += LReporteDeUsuarios_Click;
            // 
            // BGenerarReporteUsuario
            // 
            BGenerarReporteUsuario.Cursor = Cursors.Hand;
            BGenerarReporteUsuario.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            BGenerarReporteUsuario.Location = new Point(480, 135);
            BGenerarReporteUsuario.Margin = new Padding(3, 4, 3, 4);
            BGenerarReporteUsuario.Name = "BGenerarReporteUsuario";
            BGenerarReporteUsuario.Size = new Size(200, 50);
            BGenerarReporteUsuario.TabIndex = 1;
            BGenerarReporteUsuario.Text = "Generar Reporte";
            BGenerarReporteUsuario.UseVisualStyleBackColor = true;
            BGenerarReporteUsuario.Click += BGenerarReporteUsuario_Click;
            // 
            // dgvReporteUsuarios
            // 
            dgvReporteUsuarios.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvReporteUsuarios.BackgroundColor = Color.SlateGray;
            dgvReporteUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporteUsuarios.Columns.AddRange(new DataGridViewColumn[] { idUsuario, nombreUsuario, apellidoUsuario, emailUsuario, dniUsuario, telefonoUsuario, sexoUsuario, fechaNacimientoUsuario, perfilUsuario, activoUsuario });
            dgvReporteUsuarios.Location = new Point(177, 231);
            dgvReporteUsuarios.Name = "dgvReporteUsuarios";
            dgvReporteUsuarios.RowHeadersWidth = 51;
            dgvReporteUsuarios.Size = new Size(803, 240);
            dgvReporteUsuarios.TabIndex = 2;
            dgvReporteUsuarios.CellContentClick += dataGridView1_CellContentClick;
            // 
            // idUsuario
            // 
            idUsuario.HeaderText = "ID Usuario";
            idUsuario.MinimumWidth = 6;
            idUsuario.Name = "idUsuario";
            idUsuario.Width = 125;
            // 
            // nombreUsuario
            // 
            nombreUsuario.HeaderText = "Nombre";
            nombreUsuario.MinimumWidth = 6;
            nombreUsuario.Name = "nombreUsuario";
            nombreUsuario.Width = 125;
            // 
            // apellidoUsuario
            // 
            apellidoUsuario.HeaderText = "Apellido";
            apellidoUsuario.MinimumWidth = 6;
            apellidoUsuario.Name = "apellidoUsuario";
            apellidoUsuario.Width = 125;
            // 
            // emailUsuario
            // 
            emailUsuario.HeaderText = "Email";
            emailUsuario.MinimumWidth = 6;
            emailUsuario.Name = "emailUsuario";
            emailUsuario.Width = 125;
            // 
            // dniUsuario
            // 
            dniUsuario.HeaderText = "DNI";
            dniUsuario.MinimumWidth = 6;
            dniUsuario.Name = "dniUsuario";
            dniUsuario.Width = 125;
            // 
            // telefonoUsuario
            // 
            telefonoUsuario.HeaderText = "Telefono";
            telefonoUsuario.MinimumWidth = 6;
            telefonoUsuario.Name = "telefonoUsuario";
            telefonoUsuario.Width = 125;
            // 
            // sexoUsuario
            // 
            sexoUsuario.HeaderText = "Sexo";
            sexoUsuario.MinimumWidth = 6;
            sexoUsuario.Name = "sexoUsuario";
            sexoUsuario.Width = 125;
            // 
            // fechaNacimientoUsuario
            // 
            fechaNacimientoUsuario.HeaderText = "Fecha de Nacimiento";
            fechaNacimientoUsuario.MinimumWidth = 6;
            fechaNacimientoUsuario.Name = "fechaNacimientoUsuario";
            fechaNacimientoUsuario.Width = 125;
            // 
            // perfilUsuario
            // 
            perfilUsuario.HeaderText = "Perfil";
            perfilUsuario.MinimumWidth = 6;
            perfilUsuario.Name = "perfilUsuario";
            perfilUsuario.Width = 125;
            // 
            // activoUsuario
            // 
            activoUsuario.HeaderText = "Activo";
            activoUsuario.MinimumWidth = 6;
            activoUsuario.Name = "activoUsuario";
            activoUsuario.Width = 125;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(LReporteDeUsuarios);
            panel1.Controls.Add(dgvReporteUsuarios);
            panel1.Controls.Add(BGenerarReporteUsuario);
            panel1.Location = new Point(22, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(1133, 657);
            panel1.TabIndex = 3;
            panel1.Paint += panel1_Paint;
            // 
            // FReporteUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(1177, 699);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FReporteUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte Usuario";
            Load += FReporteUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReporteUsuarios).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LReporteDeUsuarios;
        private System.Windows.Forms.Button BGenerarReporteUsuario;
        private DataGridView dgvReporteUsuarios;
        private Panel panel1;
        private DataGridViewTextBoxColumn idUsuario;
        private DataGridViewTextBoxColumn nombreUsuario;
        private DataGridViewTextBoxColumn apellidoUsuario;
        private DataGridViewTextBoxColumn emailUsuario;
        private DataGridViewTextBoxColumn dniUsuario;
        private DataGridViewTextBoxColumn telefonoUsuario;
        private DataGridViewTextBoxColumn sexoUsuario;
        private DataGridViewTextBoxColumn fechaNacimientoUsuario;
        private DataGridViewTextBoxColumn perfilUsuario;
        private DataGridViewTextBoxColumn activoUsuario;
    }
}