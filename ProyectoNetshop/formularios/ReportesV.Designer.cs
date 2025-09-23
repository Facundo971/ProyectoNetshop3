namespace ProyectoNetshop.formularios
{
    partial class ReportesV
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
            panel2 = new Panel();
            tbNombreVendedorReporte = new TextBox();
            label2 = new Label();
            tbDniVendedorReporte = new TextBox();
            panel1 = new Panel();
            BGenerarReporteVendedor = new Button();
            label1 = new Label();
            label7 = new Label();
            fechaHastaVendedor = new DateTimePicker();
            fechaDesdeVendedor = new DateTimePicker();
            dgvReporteVentaVendedor = new DataGridView();
            idVenta = new DataGridViewTextBoxColumn();
            fechaVenta = new DataGridViewTextBoxColumn();
            tipoFactura = new DataGridViewTextBoxColumn();
            clienteVenta = new DataGridViewTextBoxColumn();
            totalVenta = new DataGridViewTextBoxColumn();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporteVentaVendedor).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(tbNombreVendedorReporte);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(tbDniVendedorReporte);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(288, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(889, 133);
            panel2.TabIndex = 4;
            panel2.Paint += panel2_Paint;
            // 
            // tbNombreVendedorReporte
            // 
            tbNombreVendedorReporte.Location = new Point(304, 51);
            tbNombreVendedorReporte.Margin = new Padding(3, 4, 3, 4);
            tbNombreVendedorReporte.Name = "tbNombreVendedorReporte";
            tbNombreVendedorReporte.ReadOnly = true;
            tbNombreVendedorReporte.Size = new Size(252, 27);
            tbNombreVendedorReporte.TabIndex = 22;
            tbNombreVendedorReporte.Text = "Nombre completo del vendedor";
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
            // tbDniVendedorReporte
            // 
            tbDniVendedorReporte.Location = new Point(146, 51);
            tbDniVendedorReporte.Margin = new Padding(3, 4, 3, 4);
            tbDniVendedorReporte.Name = "tbDniVendedorReporte";
            tbDniVendedorReporte.ReadOnly = true;
            tbDniVendedorReporte.Size = new Size(126, 27);
            tbDniVendedorReporte.TabIndex = 2;
            tbDniVendedorReporte.Text = "DNI del Vendodor";
            tbDniVendedorReporte.TextChanged += tbDniVendedorReporte_TextChanged;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(BGenerarReporteVendedor);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(fechaHastaVendedor);
            panel1.Controls.Add(fechaDesdeVendedor);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(288, 699);
            panel1.TabIndex = 3;
            // 
            // BGenerarReporteVendedor
            // 
            BGenerarReporteVendedor.Cursor = Cursors.Hand;
            BGenerarReporteVendedor.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            BGenerarReporteVendedor.Location = new Point(3, 541);
            BGenerarReporteVendedor.Margin = new Padding(3, 4, 3, 4);
            BGenerarReporteVendedor.Name = "BGenerarReporteVendedor";
            BGenerarReporteVendedor.Size = new Size(285, 50);
            BGenerarReporteVendedor.TabIndex = 21;
            BGenerarReporteVendedor.Text = "Generar Reporte";
            BGenerarReporteVendedor.UseVisualStyleBackColor = true;
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
            // fechaHastaVendedor
            // 
            fechaHastaVendedor.Location = new Point(40, 335);
            fechaHastaVendedor.Margin = new Padding(3, 4, 3, 4);
            fechaHastaVendedor.Name = "fechaHastaVendedor";
            fechaHastaVendedor.Size = new Size(209, 27);
            fechaHastaVendedor.TabIndex = 18;
            // 
            // fechaDesdeVendedor
            // 
            fechaDesdeVendedor.Location = new Point(40, 217);
            fechaDesdeVendedor.Margin = new Padding(3, 4, 3, 4);
            fechaDesdeVendedor.Name = "fechaDesdeVendedor";
            fechaDesdeVendedor.Size = new Size(209, 27);
            fechaDesdeVendedor.TabIndex = 17;
            // 
            // dgvReporteVentaVendedor
            // 
            dgvReporteVentaVendedor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporteVentaVendedor.Columns.AddRange(new DataGridViewColumn[] { idVenta, fechaVenta, tipoFactura, clienteVenta, totalVenta });
            dgvReporteVentaVendedor.Location = new Point(398, 184);
            dgvReporteVentaVendedor.Name = "dgvReporteVentaVendedor";
            dgvReporteVentaVendedor.RowHeadersWidth = 51;
            dgvReporteVentaVendedor.Size = new Size(679, 188);
            dgvReporteVentaVendedor.TabIndex = 5;
            dgvReporteVentaVendedor.CellContentClick += dgvReporteVentaVendedor_CellContentClick;
            // 
            // idVenta
            // 
            idVenta.HeaderText = "ID Venta";
            idVenta.MinimumWidth = 6;
            idVenta.Name = "idVenta";
            idVenta.Width = 125;
            // 
            // fechaVenta
            // 
            fechaVenta.HeaderText = "Fecha de Venta";
            fechaVenta.MinimumWidth = 6;
            fechaVenta.Name = "fechaVenta";
            fechaVenta.Width = 125;
            // 
            // tipoFactura
            // 
            tipoFactura.HeaderText = "Tipo de Factura";
            tipoFactura.MinimumWidth = 6;
            tipoFactura.Name = "tipoFactura";
            tipoFactura.Width = 125;
            // 
            // clienteVenta
            // 
            clienteVenta.HeaderText = "Cliente";
            clienteVenta.MinimumWidth = 6;
            clienteVenta.Name = "clienteVenta";
            clienteVenta.Width = 125;
            // 
            // totalVenta
            // 
            totalVenta.HeaderText = "Total";
            totalVenta.MinimumWidth = 6;
            totalVenta.Name = "totalVenta";
            totalVenta.Width = 125;
            // 
            // ReportesV
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(1177, 699);
            Controls.Add(dgvReporteVentaVendedor);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReportesV";
            Text = "Reporte del Vendedor";
            Load += ReportesV_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReporteVentaVendedor).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel2;
        private TextBox tbNombreVendedorReporte;
        private Label label2;
        private TextBox tbDniVendedorReporte;
        private Panel panel1;
        private Label label1;
        private Label label7;
        private DateTimePicker fechaHastaVendedor;
        private DateTimePicker fechaDesdeVendedor;
        private Button BGenerarReporteVendedor;
        private DataGridView dgvReporteVentaVendedor;
        private DataGridViewTextBoxColumn idVenta;
        private DataGridViewTextBoxColumn fechaVenta;
        private DataGridViewTextBoxColumn tipoFactura;
        private DataGridViewTextBoxColumn clienteVenta;
        private DataGridViewTextBoxColumn totalVenta;
    }
}