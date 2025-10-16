namespace ProyectoNetshop.formularios
{
    partial class Reportes
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
            BGenerarTotalVentasGerente = new Button();
            panel1 = new Panel();
            label1 = new Label();
            label7 = new Label();
            fechaHastaGerente = new DateTimePicker();
            fechaDesdeGerente = new DateTimePicker();
            BGenerarRecaudacionGerente = new Button();
            BGenerarReporteGerente = new Button();
            panel2 = new Panel();
            cbVendedoresNombreReporte = new ComboBox();
            cbVendedoresDniReporte = new ComboBox();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // BGenerarTotalVentasGerente
            // 
            BGenerarTotalVentasGerente.Cursor = Cursors.Hand;
            BGenerarTotalVentasGerente.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            BGenerarTotalVentasGerente.Location = new Point(15, 747);
            BGenerarTotalVentasGerente.Margin = new Padding(3, 4, 3, 4);
            BGenerarTotalVentasGerente.Name = "BGenerarTotalVentasGerente";
            BGenerarTotalVentasGerente.Size = new Size(258, 53);
            BGenerarTotalVentasGerente.TabIndex = 0;
            BGenerarTotalVentasGerente.Text = "Total de ventas";
            BGenerarTotalVentasGerente.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(fechaHastaGerente);
            panel1.Controls.Add(fechaDesdeGerente);
            panel1.Controls.Add(BGenerarRecaudacionGerente);
            panel1.Controls.Add(BGenerarReporteGerente);
            panel1.Controls.Add(BGenerarTotalVentasGerente);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(288, 800);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(118, 184);
            label1.Name = "label1";
            label1.Size = new Size(57, 29);
            label1.TabIndex = 20;
            label1.Text = "Desde";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Transparent;
            label7.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(118, 301);
            label7.Name = "label7";
            label7.Size = new Size(54, 29);
            label7.TabIndex = 19;
            label7.Text = "Hasta";
            // 
            // fechaHastaGerente
            // 
            fechaHastaGerente.Location = new Point(40, 335);
            fechaHastaGerente.Margin = new Padding(3, 4, 3, 4);
            fechaHastaGerente.Name = "fechaHastaGerente";
            fechaHastaGerente.Size = new Size(209, 27);
            fechaHastaGerente.TabIndex = 18;
            // 
            // fechaDesdeGerente
            // 
            fechaDesdeGerente.Location = new Point(40, 217);
            fechaDesdeGerente.Margin = new Padding(3, 4, 3, 4);
            fechaDesdeGerente.Name = "fechaDesdeGerente";
            fechaDesdeGerente.Size = new Size(209, 27);
            fechaDesdeGerente.TabIndex = 17;
            // 
            // BGenerarRecaudacionGerente
            // 
            BGenerarRecaudacionGerente.Cursor = Cursors.Hand;
            BGenerarRecaudacionGerente.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            BGenerarRecaudacionGerente.Location = new Point(15, 641);
            BGenerarRecaudacionGerente.Margin = new Padding(3, 4, 3, 4);
            BGenerarRecaudacionGerente.Name = "BGenerarRecaudacionGerente";
            BGenerarRecaudacionGerente.Size = new Size(258, 53);
            BGenerarRecaudacionGerente.TabIndex = 2;
            BGenerarRecaudacionGerente.Text = "Recaudación";
            BGenerarRecaudacionGerente.UseVisualStyleBackColor = true;
            // 
            // BGenerarReporteGerente
            // 
            BGenerarReporteGerente.Cursor = Cursors.Hand;
            BGenerarReporteGerente.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            BGenerarReporteGerente.Location = new Point(15, 694);
            BGenerarReporteGerente.Margin = new Padding(3, 4, 3, 4);
            BGenerarReporteGerente.Name = "BGenerarReporteGerente";
            BGenerarReporteGerente.Size = new Size(258, 53);
            BGenerarReporteGerente.TabIndex = 1;
            BGenerarReporteGerente.Text = "Prductos mas vendidos";
            BGenerarReporteGerente.UseVisualStyleBackColor = true;
            BGenerarReporteGerente.Click += BGenerarReporteGerente_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(cbVendedoresNombreReporte);
            panel2.Controls.Add(cbVendedoresDniReporte);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(288, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(912, 133);
            panel2.TabIndex = 2;
            // 
            // cbVendedoresNombreReporte
            // 
            cbVendedoresNombreReporte.FormattingEnabled = true;
            cbVendedoresNombreReporte.Location = new Point(344, 53);
            cbVendedoresNombreReporte.Name = "cbVendedoresNombreReporte";
            cbVendedoresNombreReporte.Size = new Size(296, 28);
            cbVendedoresNombreReporte.TabIndex = 25;
            // 
            // cbVendedoresDniReporte
            // 
            cbVendedoresDniReporte.FormattingEnabled = true;
            cbVendedoresDniReporte.Location = new Point(154, 53);
            cbVendedoresDniReporte.Name = "cbVendedoresDniReporte";
            cbVendedoresDniReporte.Size = new Size(172, 28);
            cbVendedoresDniReporte.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(65, 52);
            label2.Name = "label2";
            label2.Size = new Size(83, 29);
            label2.TabIndex = 21;
            label2.Text = "Vendedor";
            // 
            // Reportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(1200, 800);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Reportes";
            Text = "Reportes";
            Load += Reportes_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button BGenerarTotalVentasGerente;
        private Panel panel1;
        private Button BGenerarRecaudacionGerente;
        private Button BGenerarReporteGerente;
        private DateTimePicker fechaDesdeGerente;
        private DateTimePicker fechaHastaGerente;
        private Label label1;
        private Label label7;
        private Panel panel2;
        private Label label2;
        private ComboBox cbVendedoresNombreReporte;
        private ComboBox cbVendedoresDniReporte;
    }
}