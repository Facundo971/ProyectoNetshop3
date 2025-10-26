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
            BGenerarVentasPorVendedorGerente = new Button();
            BGenerarProductosVendidosGerente = new Button();
            panel2 = new Panel();
            clbVendedoresReporteGerente = new CheckedListBox();
            label2 = new Label();
            dgvReporteGerente = new DataGridView();
            lTotalInfoReporteGerente = new Label();
            lbTotalVendidoReporteGerente = new Label();
            cbVentasFinalizadasReporteGerentes = new CheckBox();
            cbVentasCanceladasReporteGerentes = new CheckBox();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporteGerente).BeginInit();
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
            BGenerarTotalVentasGerente.Text = "Total de Ventas";
            BGenerarTotalVentasGerente.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(fechaHastaGerente);
            panel1.Controls.Add(fechaDesdeGerente);
            panel1.Controls.Add(BGenerarVentasPorVendedorGerente);
            panel1.Controls.Add(BGenerarProductosVendidosGerente);
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
            // BGenerarVentasPorVendedorGerente
            // 
            BGenerarVentasPorVendedorGerente.Cursor = Cursors.Hand;
            BGenerarVentasPorVendedorGerente.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            BGenerarVentasPorVendedorGerente.Location = new Point(15, 641);
            BGenerarVentasPorVendedorGerente.Margin = new Padding(3, 4, 3, 4);
            BGenerarVentasPorVendedorGerente.Name = "BGenerarVentasPorVendedorGerente";
            BGenerarVentasPorVendedorGerente.Size = new Size(258, 53);
            BGenerarVentasPorVendedorGerente.TabIndex = 2;
            BGenerarVentasPorVendedorGerente.Text = "Ventas por Vendedor";
            BGenerarVentasPorVendedorGerente.UseVisualStyleBackColor = true;
            // 
            // BGenerarProductosVendidosGerente
            // 
            BGenerarProductosVendidosGerente.Cursor = Cursors.Hand;
            BGenerarProductosVendidosGerente.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            BGenerarProductosVendidosGerente.Location = new Point(15, 694);
            BGenerarProductosVendidosGerente.Margin = new Padding(3, 4, 3, 4);
            BGenerarProductosVendidosGerente.Name = "BGenerarProductosVendidosGerente";
            BGenerarProductosVendidosGerente.Size = new Size(258, 53);
            BGenerarProductosVendidosGerente.TabIndex = 1;
            BGenerarProductosVendidosGerente.Text = "Productos Vendidos";
            BGenerarProductosVendidosGerente.UseVisualStyleBackColor = true;
            BGenerarProductosVendidosGerente.Click += BGenerarReporteGerente_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(clbVendedoresReporteGerente);
            panel2.Controls.Add(label2);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(288, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(912, 133);
            panel2.TabIndex = 2;
            // 
            // clbVendedoresReporteGerente
            // 
            clbVendedoresReporteGerente.FormattingEnabled = true;
            clbVendedoresReporteGerente.Location = new Point(154, 22);
            clbVendedoresReporteGerente.Name = "clbVendedoresReporteGerente";
            clbVendedoresReporteGerente.Size = new Size(388, 26);
            clbVendedoresReporteGerente.TabIndex = 26;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(65, 22);
            label2.Name = "label2";
            label2.Size = new Size(83, 29);
            label2.TabIndex = 21;
            label2.Text = "Vendedor";
            // 
            // dgvReporteGerente
            // 
            dgvReporteGerente.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporteGerente.Location = new Point(314, 200);
            dgvReporteGerente.Name = "dgvReporteGerente";
            dgvReporteGerente.RowHeadersWidth = 51;
            dgvReporteGerente.Size = new Size(862, 501);
            dgvReporteGerente.TabIndex = 26;
            dgvReporteGerente.Visible = false;
            // 
            // lTotalInfoReporteGerente
            // 
            lTotalInfoReporteGerente.AutoSize = true;
            lTotalInfoReporteGerente.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lTotalInfoReporteGerente.ForeColor = SystemColors.ButtonFace;
            lTotalInfoReporteGerente.Location = new Point(927, 704);
            lTotalInfoReporteGerente.Name = "lTotalInfoReporteGerente";
            lTotalInfoReporteGerente.Size = new Size(81, 34);
            lTotalInfoReporteGerente.TabIndex = 27;
            lTotalInfoReporteGerente.Text = "TOTAL:";
            lTotalInfoReporteGerente.Visible = false;
            // 
            // lbTotalVendidoReporteGerente
            // 
            lbTotalVendidoReporteGerente.AutoSize = true;
            lbTotalVendidoReporteGerente.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lbTotalVendidoReporteGerente.ForeColor = SystemColors.ButtonFace;
            lbTotalVendidoReporteGerente.Location = new Point(1014, 704);
            lbTotalVendidoReporteGerente.Name = "lbTotalVendidoReporteGerente";
            lbTotalVendidoReporteGerente.Size = new Size(63, 34);
            lbTotalVendidoReporteGerente.TabIndex = 28;
            lbTotalVendidoReporteGerente.Text = "$0,00";
            lbTotalVendidoReporteGerente.Visible = false;
            // 
            // cbVentasFinalizadasReporteGerentes
            // 
            cbVentasFinalizadasReporteGerentes.AutoSize = true;
            cbVentasFinalizadasReporteGerentes.Checked = true;
            cbVentasFinalizadasReporteGerentes.CheckState = CheckState.Checked;
            cbVentasFinalizadasReporteGerentes.Cursor = Cursors.Hand;
            cbVentasFinalizadasReporteGerentes.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            cbVentasFinalizadasReporteGerentes.ForeColor = SystemColors.ButtonFace;
            cbVentasFinalizadasReporteGerentes.Location = new Point(314, 165);
            cbVentasFinalizadasReporteGerentes.Name = "cbVentasFinalizadasReporteGerentes";
            cbVentasFinalizadasReporteGerentes.Size = new Size(101, 33);
            cbVentasFinalizadasReporteGerentes.TabIndex = 29;
            cbVentasFinalizadasReporteGerentes.Text = "Vendidos";
            cbVentasFinalizadasReporteGerentes.UseVisualStyleBackColor = true;
            cbVentasFinalizadasReporteGerentes.Visible = false;
            // 
            // cbVentasCanceladasReporteGerentes
            // 
            cbVentasCanceladasReporteGerentes.AutoSize = true;
            cbVentasCanceladasReporteGerentes.Cursor = Cursors.Hand;
            cbVentasCanceladasReporteGerentes.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            cbVentasCanceladasReporteGerentes.ForeColor = SystemColors.ButtonFace;
            cbVentasCanceladasReporteGerentes.Location = new Point(431, 165);
            cbVentasCanceladasReporteGerentes.Name = "cbVentasCanceladasReporteGerentes";
            cbVentasCanceladasReporteGerentes.Size = new Size(115, 33);
            cbVentasCanceladasReporteGerentes.TabIndex = 30;
            cbVentasCanceladasReporteGerentes.Text = "Cancelados";
            cbVentasCanceladasReporteGerentes.UseVisualStyleBackColor = true;
            cbVentasCanceladasReporteGerentes.Visible = false;
            cbVentasCanceladasReporteGerentes.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // Reportes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(1200, 800);
            Controls.Add(cbVentasCanceladasReporteGerentes);
            Controls.Add(cbVentasFinalizadasReporteGerentes);
            Controls.Add(lbTotalVendidoReporteGerente);
            Controls.Add(lTotalInfoReporteGerente);
            Controls.Add(dgvReporteGerente);
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
            ((System.ComponentModel.ISupportInitialize)dgvReporteGerente).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button BGenerarTotalVentasGerente;
        private Panel panel1;
        private Button BGenerarVentasPorVendedorGerente;
        private Button BGenerarProductosVendidosGerente;
        private DateTimePicker fechaDesdeGerente;
        private DateTimePicker fechaHastaGerente;
        private Label label1;
        private Label label7;
        private Panel panel2;
        private Label label2;
        private CheckedListBox clbVendedoresReporteGerente;
        private DataGridView dgvReporteGerente;
        private Label lTotalInfoReporteGerente;
        private Label lbTotalVendidoReporteGerente;
        private CheckBox cbVentasFinalizadasReporteGerentes;
        private CheckBox cbVentasCanceladasReporteGerentes;
    }
}