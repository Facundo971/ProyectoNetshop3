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
            BGenerarReporte = new Button();
            dataGridView1 = new DataGridView();
            IdUsuario = new DataGridViewTextBoxColumn();
            nombreUsuario = new DataGridViewTextBoxColumn();
            apellidoUsuario = new DataGridViewTextBoxColumn();
            emailUsuario = new DataGridViewTextBoxColumn();
            perfilUsuario = new DataGridViewTextBoxColumn();
            activoUsuario = new DataGridViewTextBoxColumn();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            // BGenerarReporte
            // 
            BGenerarReporte.Cursor = Cursors.Hand;
            BGenerarReporte.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            BGenerarReporte.Location = new Point(480, 135);
            BGenerarReporte.Margin = new Padding(3, 4, 3, 4);
            BGenerarReporte.Name = "BGenerarReporte";
            BGenerarReporte.Size = new Size(200, 50);
            BGenerarReporte.TabIndex = 1;
            BGenerarReporte.Text = "Generar Reporte";
            BGenerarReporte.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.BackgroundColor = Color.SlateGray;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IdUsuario, nombreUsuario, apellidoUsuario, emailUsuario, perfilUsuario, activoUsuario });
            dataGridView1.Location = new Point(177, 231);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(803, 402);
            dataGridView1.TabIndex = 2;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // IdUsuario
            // 
            IdUsuario.HeaderText = "IdUsuario";
            IdUsuario.MinimumWidth = 6;
            IdUsuario.Name = "IdUsuario";
            IdUsuario.Width = 125;
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
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(BGenerarReporte);
            panel1.Location = new Point(22, 24);
            panel1.Name = "panel1";
            panel1.Size = new Size(1133, 657);
            panel1.TabIndex = 3;
            // 
            // FReporteUsuario
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(1177, 699);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FReporteUsuario";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte Usuario";
            Load += FReporteUsuario_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LReporteDeUsuarios;
        private System.Windows.Forms.Button BGenerarReporte;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn IdUsuario;
        private DataGridViewTextBoxColumn nombreUsuario;
        private DataGridViewTextBoxColumn apellidoUsuario;
        private DataGridViewTextBoxColumn emailUsuario;
        private DataGridViewTextBoxColumn perfilUsuario;
        private DataGridViewTextBoxColumn activoUsuario;
        private Panel panel1;
    }
}