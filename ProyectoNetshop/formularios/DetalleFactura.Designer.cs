namespace ProyectoNetshop.formularios
{
    partial class DetalleFactura
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
            label1 = new Label();
            tbNombreVendedorDetalleFactura = new TextBox();
            tbDniVendedorDetalleFactura = new TextBox();
            dgvDetalleFactura = new DataGridView();
            label2 = new Label();
            lbTotalVendidoDetalleFactura = new Label();
            label3 = new Label();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            sqlCommand2 = new Microsoft.Data.SqlClient.SqlCommand();
            tbBusquedaNombreProductoDF = new TextBox();
            tbBusquedaPrecioMaxProductoDF = new TextBox();
            tbBusquedaNroFProductoDF = new TextBox();
            tbBusquedaPrecioMinProductoDF = new TextBox();
            label4 = new Label();
            dgvVentaCabeceraFactura = new DataGridView();
            label5 = new Label();
            lbTotalVendidoCabeceraFactura = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvDetalleFactura).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentaCabeceraFactura).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            label1.ForeColor = SystemColors.ButtonFace;
            label1.Location = new Point(24, 31);
            label1.Name = "label1";
            label1.Size = new Size(83, 29);
            label1.TabIndex = 0;
            label1.Text = "Vendedor";
            // 
            // tbNombreVendedorDetalleFactura
            // 
            tbNombreVendedorDetalleFactura.Location = new Point(279, 30);
            tbNombreVendedorDetalleFactura.Name = "tbNombreVendedorDetalleFactura";
            tbNombreVendedorDetalleFactura.Size = new Size(200, 27);
            tbNombreVendedorDetalleFactura.TabIndex = 1;
            // 
            // tbDniVendedorDetalleFactura
            // 
            tbDniVendedorDetalleFactura.Location = new Point(125, 30);
            tbDniVendedorDetalleFactura.Name = "tbDniVendedorDetalleFactura";
            tbDniVendedorDetalleFactura.Size = new Size(125, 27);
            tbDniVendedorDetalleFactura.TabIndex = 2;
            // 
            // dgvDetalleFactura
            // 
            dgvDetalleFactura.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetalleFactura.Location = new Point(24, 501);
            dgvDetalleFactura.Name = "dgvDetalleFactura";
            dgvDetalleFactura.RowHeadersWidth = 51;
            dgvDetalleFactura.Size = new Size(1149, 225);
            dgvDetalleFactura.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(966, 348);
            label2.Name = "label2";
            label2.Size = new Size(81, 34);
            label2.TabIndex = 4;
            label2.Text = "TOTAL:";
            // 
            // lbTotalVendidoDetalleFactura
            // 
            lbTotalVendidoDetalleFactura.AutoSize = true;
            lbTotalVendidoDetalleFactura.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lbTotalVendidoDetalleFactura.ForeColor = SystemColors.ButtonFace;
            lbTotalVendidoDetalleFactura.Location = new Point(1053, 729);
            lbTotalVendidoDetalleFactura.Name = "lbTotalVendidoDetalleFactura";
            lbTotalVendidoDetalleFactura.Size = new Size(63, 34);
            lbTotalVendidoDetalleFactura.TabIndex = 5;
            lbTotalVendidoDetalleFactura.Text = "$0,00";
            lbTotalVendidoDetalleFactura.Click += lbTotalDetalleFactura_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(789, 88);
            label3.Name = "label3";
            label3.Size = new Size(95, 29);
            label3.TabIndex = 6;
            label3.Text = "Buscar por:";
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // sqlCommand2
            // 
            sqlCommand2.CommandTimeout = 30;
            sqlCommand2.EnableOptimizedParameterBinding = false;
            // 
            // tbBusquedaNombreProductoDF
            // 
            tbBusquedaNombreProductoDF.Location = new Point(789, 468);
            tbBusquedaNombreProductoDF.Name = "tbBusquedaNombreProductoDF";
            tbBusquedaNombreProductoDF.PlaceholderText = "Nombre del producto";
            tbBusquedaNombreProductoDF.Size = new Size(200, 27);
            tbBusquedaNombreProductoDF.TabIndex = 7;
            // 
            // tbBusquedaPrecioMaxProductoDF
            // 
            tbBusquedaPrecioMaxProductoDF.Location = new Point(1023, 468);
            tbBusquedaPrecioMaxProductoDF.Name = "tbBusquedaPrecioMaxProductoDF";
            tbBusquedaPrecioMaxProductoDF.PlaceholderText = "Precio maximo";
            tbBusquedaPrecioMaxProductoDF.Size = new Size(150, 27);
            tbBusquedaPrecioMaxProductoDF.TabIndex = 8;
            // 
            // tbBusquedaNroFProductoDF
            // 
            tbBusquedaNroFProductoDF.Location = new Point(897, 90);
            tbBusquedaNroFProductoDF.Name = "tbBusquedaNroFProductoDF";
            tbBusquedaNroFProductoDF.PlaceholderText = "Numero de factura";
            tbBusquedaNroFProductoDF.Size = new Size(150, 27);
            tbBusquedaNroFProductoDF.TabIndex = 9;
            // 
            // tbBusquedaPrecioMinProductoDF
            // 
            tbBusquedaPrecioMinProductoDF.Location = new Point(1023, 432);
            tbBusquedaPrecioMinProductoDF.Name = "tbBusquedaPrecioMinProductoDF";
            tbBusquedaPrecioMinProductoDF.PlaceholderText = "Precio minimo";
            tbBusquedaPrecioMinProductoDF.Size = new Size(150, 27);
            tbBusquedaPrecioMinProductoDF.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(24, 84);
            label4.Name = "label4";
            label4.Size = new Size(185, 34);
            label4.TabIndex = 11;
            label4.Text = "Resumen de Ventas";
            // 
            // dgvVentaCabeceraFactura
            // 
            dgvVentaCabeceraFactura.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvVentaCabeceraFactura.Location = new Point(24, 120);
            dgvVentaCabeceraFactura.Name = "dgvVentaCabeceraFactura";
            dgvVentaCabeceraFactura.RowHeadersWidth = 51;
            dgvVentaCabeceraFactura.Size = new Size(1149, 225);
            dgvVentaCabeceraFactura.TabIndex = 12;
            dgvVentaCabeceraFactura.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            label5.ForeColor = SystemColors.ButtonFace;
            label5.Location = new Point(966, 729);
            label5.Name = "label5";
            label5.Size = new Size(81, 34);
            label5.TabIndex = 13;
            label5.Text = "TOTAL:";
            // 
            // lbTotalVendidoCabeceraFactura
            // 
            lbTotalVendidoCabeceraFactura.AutoSize = true;
            lbTotalVendidoCabeceraFactura.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            lbTotalVendidoCabeceraFactura.ForeColor = SystemColors.ButtonFace;
            lbTotalVendidoCabeceraFactura.Location = new Point(1053, 348);
            lbTotalVendidoCabeceraFactura.Name = "lbTotalVendidoCabeceraFactura";
            lbTotalVendidoCabeceraFactura.Size = new Size(63, 34);
            lbTotalVendidoCabeceraFactura.TabIndex = 14;
            lbTotalVendidoCabeceraFactura.Text = "$0,00";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            label6.ForeColor = SystemColors.ButtonFace;
            label6.Location = new Point(789, 430);
            label6.Name = "label6";
            label6.Size = new Size(95, 29);
            label6.TabIndex = 15;
            label6.Text = "Buscar por:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            label7.ForeColor = SystemColors.ButtonFace;
            label7.Location = new Point(24, 465);
            label7.Name = "label7";
            label7.Size = new Size(282, 34);
            label7.TabIndex = 16;
            label7.Text = "Detalle de Productos Vendidos";
            // 
            // DetalleFactura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(1200, 800);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(lbTotalVendidoCabeceraFactura);
            Controls.Add(label5);
            Controls.Add(dgvVentaCabeceraFactura);
            Controls.Add(label4);
            Controls.Add(tbBusquedaPrecioMinProductoDF);
            Controls.Add(tbBusquedaNroFProductoDF);
            Controls.Add(tbBusquedaPrecioMaxProductoDF);
            Controls.Add(tbBusquedaNombreProductoDF);
            Controls.Add(label3);
            Controls.Add(lbTotalVendidoDetalleFactura);
            Controls.Add(label2);
            Controls.Add(dgvDetalleFactura);
            Controls.Add(tbDniVendedorDetalleFactura);
            Controls.Add(tbNombreVendedorDetalleFactura);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DetalleFactura";
            Text = "Detalles de Facturas";
            Load += DetalleFactura_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDetalleFactura).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvVentaCabeceraFactura).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox tbNombreVendedorDetalleFactura;
        private TextBox tbDniVendedorDetalleFactura;
        private DataGridView dgvDetalleFactura;
        private Label label2;
        private Label lbTotalVendidoDetalleFactura;
        private Label label3;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand2;
        private TextBox tbBusquedaNombreProductoDF;
        private TextBox tbBusquedaPrecioMaxProductoDF;
        private TextBox tbBusquedaNroFProductoDF;
        private TextBox tbBusquedaPrecioMinProductoDF;
        private Label label4;
        private DataGridView dgvVentaCabeceraFactura;
        private Label label5;
        private Label lbTotalVendidoCabeceraFactura;
        private Label label6;
        private Label label7;
    }
}