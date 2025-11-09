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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            panel2 = new Panel();
            bGenerarPdfReporteVendedor = new Button();
            tbBusquedaPrecioMinProductoDF = new TextBox();
            tbBusquedaNroFProductoDF = new TextBox();
            tbNombreVendedorReporte = new TextBox();
            tbBusquedaPrecioMaxProductoDF = new TextBox();
            label2 = new Label();
            tbBusquedaNombreProductoDF = new TextBox();
            tbDniVendedorReporte = new TextBox();
            label3 = new Label();
            panel1 = new Panel();
            lbTotalVendidoVendedor = new Label();
            lbTotal = new Label();
            label1 = new Label();
            label7 = new Label();
            fechaHastaVendedor = new DateTimePicker();
            fechaDesdeVendedor = new DateTimePicker();
            chReporteVendedor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            dgvReporteVentaVendedor = new DataGridView();
            nroFactura = new DataGridViewTextBoxColumn();
            fechaVenta = new DataGridViewTextBoxColumn();
            clienteVenta = new DataGridViewTextBoxColumn();
            tipoFactura = new DataGridViewTextBoxColumn();
            cantidad = new DataGridViewTextBoxColumn();
            precioUnitario = new DataGridViewTextBoxColumn();
            totalVenta = new DataGridViewTextBoxColumn();
            estado = new DataGridViewTextBoxColumn();
            producto = new DataGridViewTextBoxColumn();
            lCantidadVentas = new Label();
            lVentaMasAlta = new Label();
            lVentaMasBaja = new Label();
            lPromedioFactura = new Label();
            lClienteFrecuente = new Label();
            lDiaMayorFacturacion = new Label();
            lbCantidadVentas = new Label();
            lbVentaMasAlta = new Label();
            lbVentaMasBaja = new Label();
            lbPromedioFactura = new Label();
            lbClienteFrecuente = new Label();
            lbDiaMayorFacturacion = new Label();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)chReporteVendedor).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvReporteVentaVendedor).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(bGenerarPdfReporteVendedor);
            panel2.Controls.Add(tbBusquedaPrecioMinProductoDF);
            panel2.Controls.Add(tbBusquedaNroFProductoDF);
            panel2.Controls.Add(tbNombreVendedorReporte);
            panel2.Controls.Add(tbBusquedaPrecioMaxProductoDF);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(tbBusquedaNombreProductoDF);
            panel2.Controls.Add(tbDniVendedorReporte);
            panel2.Controls.Add(label3);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(288, 0);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(982, 192);
            panel2.TabIndex = 4;
            panel2.Paint += panel2_Paint;
            // 
            // bGenerarPdfReporteVendedor
            // 
            bGenerarPdfReporteVendedor.Cursor = Cursors.Hand;
            bGenerarPdfReporteVendedor.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            bGenerarPdfReporteVendedor.ForeColor = SystemColors.ActiveCaptionText;
            bGenerarPdfReporteVendedor.Location = new Point(761, 121);
            bGenerarPdfReporteVendedor.Name = "bGenerarPdfReporteVendedor";
            bGenerarPdfReporteVendedor.Size = new Size(136, 45);
            bGenerarPdfReporteVendedor.TabIndex = 38;
            bGenerarPdfReporteVendedor.Text = "Generar PDF";
            bGenerarPdfReporteVendedor.UseVisualStyleBackColor = true;
            // 
            // tbBusquedaPrecioMinProductoDF
            // 
            tbBusquedaPrecioMinProductoDF.Location = new Point(585, 101);
            tbBusquedaPrecioMinProductoDF.Name = "tbBusquedaPrecioMinProductoDF";
            tbBusquedaPrecioMinProductoDF.PlaceholderText = "Precio minimo";
            tbBusquedaPrecioMinProductoDF.Size = new Size(126, 27);
            tbBusquedaPrecioMinProductoDF.TabIndex = 15;
            // 
            // tbBusquedaNroFProductoDF
            // 
            tbBusquedaNroFProductoDF.Location = new Point(146, 137);
            tbBusquedaNroFProductoDF.Name = "tbBusquedaNroFProductoDF";
            tbBusquedaNroFProductoDF.PlaceholderText = "Numero de factura";
            tbBusquedaNroFProductoDF.Size = new Size(126, 27);
            tbBusquedaNroFProductoDF.TabIndex = 14;
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
            // tbBusquedaPrecioMaxProductoDF
            // 
            tbBusquedaPrecioMaxProductoDF.Location = new Point(585, 137);
            tbBusquedaPrecioMaxProductoDF.Name = "tbBusquedaPrecioMaxProductoDF";
            tbBusquedaPrecioMaxProductoDF.PlaceholderText = "Precio maximo";
            tbBusquedaPrecioMaxProductoDF.Size = new Size(126, 27);
            tbBusquedaPrecioMaxProductoDF.TabIndex = 13;
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
            // tbBusquedaNombreProductoDF
            // 
            tbBusquedaNombreProductoDF.Location = new Point(304, 137);
            tbBusquedaNombreProductoDF.Name = "tbBusquedaNombreProductoDF";
            tbBusquedaNombreProductoDF.PlaceholderText = "Nombre del producto";
            tbBusquedaNombreProductoDF.Size = new Size(247, 27);
            tbBusquedaNombreProductoDF.TabIndex = 12;
            // 
            // tbDniVendedorReporte
            // 
            tbDniVendedorReporte.Location = new Point(146, 51);
            tbDniVendedorReporte.Margin = new Padding(3, 4, 3, 4);
            tbDniVendedorReporte.Name = "tbDniVendedorReporte";
            tbDniVendedorReporte.ReadOnly = true;
            tbDniVendedorReporte.Size = new Size(126, 27);
            tbDniVendedorReporte.TabIndex = 2;
            tbDniVendedorReporte.Text = "DNI del Vendedor";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(55, 137);
            label3.Name = "label3";
            label3.Size = new Size(95, 29);
            label3.TabIndex = 11;
            label3.Text = "Buscar por:";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(lbTotalVendidoVendedor);
            panel1.Controls.Add(lbTotal);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(fechaHastaVendedor);
            panel1.Controls.Add(fechaDesdeVendedor);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(288, 851);
            panel1.TabIndex = 3;
            // 
            // lbTotalVendidoVendedor
            // 
            lbTotalVendidoVendedor.AutoSize = true;
            lbTotalVendidoVendedor.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lbTotalVendidoVendedor.ForeColor = SystemColors.ButtonFace;
            lbTotalVendidoVendedor.Location = new Point(120, 745);
            lbTotalVendidoVendedor.Name = "lbTotalVendidoVendedor";
            lbTotalVendidoVendedor.Size = new Size(63, 34);
            lbTotalVendidoVendedor.TabIndex = 30;
            lbTotalVendidoVendedor.Text = "$0,00";
            // 
            // lbTotal
            // 
            lbTotal.AutoSize = true;
            lbTotal.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lbTotal.ForeColor = SystemColors.ButtonFace;
            lbTotal.Location = new Point(40, 745);
            lbTotal.Name = "lbTotal";
            lbTotal.Size = new Size(81, 34);
            lbTotal.TabIndex = 29;
            lbTotal.Text = "TOTAL:";
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
            // chReporteVendedor
            // 
            chReporteVendedor.BackColor = Color.Linen;
            chartArea1.Name = "ChartArea1";
            chReporteVendedor.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            chReporteVendedor.Legends.Add(legend1);
            chReporteVendedor.Location = new Point(288, 485);
            chReporteVendedor.Margin = new Padding(3, 4, 3, 4);
            chReporteVendedor.Name = "chReporteVendedor";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            chReporteVendedor.Series.Add(series1);
            chReporteVendedor.Size = new Size(567, 365);
            chReporteVendedor.TabIndex = 21;
            chReporteVendedor.Text = "Grafico reporte vendedor";
            // 
            // dgvReporteVentaVendedor
            // 
            dgvReporteVentaVendedor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReporteVentaVendedor.Columns.AddRange(new DataGridViewColumn[] { nroFactura, fechaVenta, clienteVenta, tipoFactura, cantidad, precioUnitario, totalVenta, estado, producto });
            dgvReporteVentaVendedor.Location = new Point(288, 184);
            dgvReporteVentaVendedor.Name = "dgvReporteVentaVendedor";
            dgvReporteVentaVendedor.RowHeadersWidth = 51;
            dgvReporteVentaVendedor.Size = new Size(922, 295);
            dgvReporteVentaVendedor.TabIndex = 5;
            // 
            // nroFactura
            // 
            nroFactura.HeaderText = "Nro de Factura";
            nroFactura.MinimumWidth = 6;
            nroFactura.Name = "nroFactura";
            nroFactura.Width = 125;
            // 
            // fechaVenta
            // 
            fechaVenta.HeaderText = "Fecha de Venta";
            fechaVenta.MinimumWidth = 6;
            fechaVenta.Name = "fechaVenta";
            fechaVenta.Width = 125;
            // 
            // clienteVenta
            // 
            clienteVenta.HeaderText = "Cliente";
            clienteVenta.MinimumWidth = 6;
            clienteVenta.Name = "clienteVenta";
            clienteVenta.Width = 125;
            // 
            // tipoFactura
            // 
            tipoFactura.HeaderText = "Tipo de Factura";
            tipoFactura.MinimumWidth = 6;
            tipoFactura.Name = "tipoFactura";
            tipoFactura.Width = 125;
            // 
            // cantidad
            // 
            cantidad.HeaderText = "Cantidad";
            cantidad.MinimumWidth = 6;
            cantidad.Name = "cantidad";
            cantidad.Width = 125;
            // 
            // precioUnitario
            // 
            precioUnitario.HeaderText = "Precio Unitario";
            precioUnitario.MinimumWidth = 6;
            precioUnitario.Name = "precioUnitario";
            precioUnitario.Width = 125;
            // 
            // totalVenta
            // 
            totalVenta.HeaderText = "Total";
            totalVenta.MinimumWidth = 6;
            totalVenta.Name = "totalVenta";
            totalVenta.Width = 125;
            // 
            // estado
            // 
            estado.HeaderText = "Estado";
            estado.MinimumWidth = 6;
            estado.Name = "estado";
            estado.Width = 125;
            // 
            // producto
            // 
            producto.HeaderText = "Producto";
            producto.MinimumWidth = 6;
            producto.Name = "producto";
            producto.Width = 81;
            // 
            // lCantidadVentas
            // 
            lCantidadVentas.AutoSize = true;
            lCantidadVentas.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lCantidadVentas.ForeColor = SystemColors.ButtonFace;
            lCantidadVentas.Location = new Point(877, 485);
            lCantidadVentas.Name = "lCantidadVentas";
            lCantidadVentas.Size = new Size(184, 34);
            lCantidadVentas.TabIndex = 31;
            lCantidadVentas.Text = "Cantidad de ventas:";
            // 
            // lVentaMasAlta
            // 
            lVentaMasAlta.AutoSize = true;
            lVentaMasAlta.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lVentaMasAlta.ForeColor = SystemColors.ButtonFace;
            lVentaMasAlta.Location = new Point(877, 521);
            lVentaMasAlta.Name = "lVentaMasAlta";
            lVentaMasAlta.Size = new Size(147, 34);
            lVentaMasAlta.TabIndex = 32;
            lVentaMasAlta.Text = "Venta mas alta:";
            // 
            // lVentaMasBaja
            // 
            lVentaMasBaja.AutoSize = true;
            lVentaMasBaja.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lVentaMasBaja.ForeColor = SystemColors.ButtonFace;
            lVentaMasBaja.Location = new Point(877, 557);
            lVentaMasBaja.Name = "lVentaMasBaja";
            lVentaMasBaja.Size = new Size(151, 34);
            lVentaMasBaja.TabIndex = 33;
            lVentaMasBaja.Text = "Venta mas baja:";
            // 
            // lPromedioFactura
            // 
            lPromedioFactura.AutoSize = true;
            lPromedioFactura.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lPromedioFactura.ForeColor = SystemColors.ButtonFace;
            lPromedioFactura.Location = new Point(877, 593);
            lPromedioFactura.Name = "lPromedioFactura";
            lPromedioFactura.Size = new Size(205, 34);
            lPromedioFactura.TabIndex = 34;
            lPromedioFactura.Text = "Promedio por factura:";
            // 
            // lClienteFrecuente
            // 
            lClienteFrecuente.AutoSize = true;
            lClienteFrecuente.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lClienteFrecuente.ForeColor = SystemColors.ButtonFace;
            lClienteFrecuente.Location = new Point(877, 629);
            lClienteFrecuente.Name = "lClienteFrecuente";
            lClienteFrecuente.Size = new Size(212, 34);
            lClienteFrecuente.TabIndex = 35;
            lClienteFrecuente.Text = "Cliente mas frecuente: ";
            // 
            // lDiaMayorFacturacion
            // 
            lDiaMayorFacturacion.AutoSize = true;
            lDiaMayorFacturacion.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lDiaMayorFacturacion.ForeColor = SystemColors.ButtonFace;
            lDiaMayorFacturacion.Location = new Point(877, 709);
            lDiaMayorFacturacion.Name = "lDiaMayorFacturacion";
            lDiaMayorFacturacion.Size = new Size(251, 34);
            lDiaMayorFacturacion.TabIndex = 36;
            lDiaMayorFacturacion.Text = "Dia con mayor facturacion: ";
            // 
            // lbCantidadVentas
            // 
            lbCantidadVentas.AutoSize = true;
            lbCantidadVentas.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lbCantidadVentas.ForeColor = SystemColors.ButtonFace;
            lbCantidadVentas.Location = new Point(1067, 485);
            lbCantidadVentas.Name = "lbCantidadVentas";
            lbCantidadVentas.Size = new Size(26, 34);
            lbCantidadVentas.TabIndex = 37;
            lbCantidadVentas.Text = "0";
            // 
            // lbVentaMasAlta
            // 
            lbVentaMasAlta.AutoSize = true;
            lbVentaMasAlta.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lbVentaMasAlta.ForeColor = SystemColors.ButtonFace;
            lbVentaMasAlta.Location = new Point(1034, 521);
            lbVentaMasAlta.Name = "lbVentaMasAlta";
            lbVentaMasAlta.Size = new Size(26, 34);
            lbVentaMasAlta.TabIndex = 38;
            lbVentaMasAlta.Text = "0";
            // 
            // lbVentaMasBaja
            // 
            lbVentaMasBaja.AutoSize = true;
            lbVentaMasBaja.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lbVentaMasBaja.ForeColor = SystemColors.ButtonFace;
            lbVentaMasBaja.Location = new Point(1034, 559);
            lbVentaMasBaja.Name = "lbVentaMasBaja";
            lbVentaMasBaja.Size = new Size(26, 34);
            lbVentaMasBaja.TabIndex = 39;
            lbVentaMasBaja.Text = "0";
            // 
            // lbPromedioFactura
            // 
            lbPromedioFactura.AutoSize = true;
            lbPromedioFactura.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lbPromedioFactura.ForeColor = SystemColors.ButtonFace;
            lbPromedioFactura.Location = new Point(1088, 593);
            lbPromedioFactura.Name = "lbPromedioFactura";
            lbPromedioFactura.Size = new Size(26, 34);
            lbPromedioFactura.TabIndex = 40;
            lbPromedioFactura.Text = "0";
            // 
            // lbClienteFrecuente
            // 
            lbClienteFrecuente.AutoSize = true;
            lbClienteFrecuente.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lbClienteFrecuente.ForeColor = SystemColors.ButtonFace;
            lbClienteFrecuente.Location = new Point(1088, 627);
            lbClienteFrecuente.Name = "lbClienteFrecuente";
            lbClienteFrecuente.Size = new Size(26, 34);
            lbClienteFrecuente.TabIndex = 41;
            lbClienteFrecuente.Text = "0";
            // 
            // lbDiaMayorFacturacion
            // 
            lbDiaMayorFacturacion.AutoSize = true;
            lbDiaMayorFacturacion.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lbDiaMayorFacturacion.ForeColor = SystemColors.ButtonFace;
            lbDiaMayorFacturacion.Location = new Point(877, 745);
            lbDiaMayorFacturacion.Name = "lbDiaMayorFacturacion";
            lbDiaMayorFacturacion.Size = new Size(26, 34);
            lbDiaMayorFacturacion.TabIndex = 42;
            lbDiaMayorFacturacion.Text = "0";
            // 
            // ReportesV
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(1270, 851);
            Controls.Add(lbDiaMayorFacturacion);
            Controls.Add(lbClienteFrecuente);
            Controls.Add(lbPromedioFactura);
            Controls.Add(lbVentaMasBaja);
            Controls.Add(lbVentaMasAlta);
            Controls.Add(lbCantidadVentas);
            Controls.Add(lDiaMayorFacturacion);
            Controls.Add(lClienteFrecuente);
            Controls.Add(lPromedioFactura);
            Controls.Add(lVentaMasBaja);
            Controls.Add(lVentaMasAlta);
            Controls.Add(lCantidadVentas);
            Controls.Add(chReporteVendedor);
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
            ((System.ComponentModel.ISupportInitialize)chReporteVendedor).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvReporteVentaVendedor).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private DataGridView dgvReporteVentaVendedor;
        private TextBox tbBusquedaPrecioMinProductoDF;
        private TextBox tbBusquedaNroFProductoDF;
        private TextBox tbBusquedaPrecioMaxProductoDF;
        private TextBox tbBusquedaNombreProductoDF;
        private Label label3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chReporteVendedor;
        private Label lbTotalVendidoVendedor;
        private Label lbTotal;
        private DataGridViewTextBoxColumn nroFactura;
        private DataGridViewTextBoxColumn fechaVenta;
        private DataGridViewTextBoxColumn clienteVenta;
        private DataGridViewTextBoxColumn tipoFactura;
        private DataGridViewTextBoxColumn cantidad;
        private DataGridViewTextBoxColumn precioUnitario;
        private DataGridViewTextBoxColumn totalVenta;
        private DataGridViewTextBoxColumn estado;
        private DataGridViewTextBoxColumn producto;
        private Label lCantidadVentas;
        private Label lVentaMasAlta;
        private Label lVentaMasBaja;
        private Label lPromedioFactura;
        private Label lClienteFrecuente;
        private Label lDiaMayorFacturacion;
        private Label lbCantidadVentas;
        private Label lbVentaMasAlta;
        private Label lbVentaMasBaja;
        private Label lbPromedioFactura;
        private Label lbClienteFrecuente;
        private Label lbDiaMayorFacturacion;
        private Button bGenerarPdfReporteVendedor;
    }
}