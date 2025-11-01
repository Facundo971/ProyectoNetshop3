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
            ((System.ComponentModel.ISupportInitialize)dgvDetalleFactura).BeginInit();
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
            dgvDetalleFactura.Location = new Point(24, 250);
            dgvDetalleFactura.Name = "dgvDetalleFactura";
            dgvDetalleFactura.RowHeadersWidth = 51;
            dgvDetalleFactura.Size = new Size(1149, 454);
            dgvDetalleFactura.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(958, 706);
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
            lbTotalVendidoDetalleFactura.Location = new Point(1034, 706);
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
            label3.Location = new Point(789, 182);
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
            tbBusquedaNombreProductoDF.Location = new Point(789, 217);
            tbBusquedaNombreProductoDF.Name = "tbBusquedaNombreProductoDF";
            tbBusquedaNombreProductoDF.PlaceholderText = "Nombre del producto";
            tbBusquedaNombreProductoDF.Size = new Size(200, 27);
            tbBusquedaNombreProductoDF.TabIndex = 7;
            // 
            // tbBusquedaPrecioMaxProductoDF
            // 
            tbBusquedaPrecioMaxProductoDF.Location = new Point(1023, 217);
            tbBusquedaPrecioMaxProductoDF.Name = "tbBusquedaPrecioMaxProductoDF";
            tbBusquedaPrecioMaxProductoDF.PlaceholderText = "Precio maximo";
            tbBusquedaPrecioMaxProductoDF.Size = new Size(150, 27);
            tbBusquedaPrecioMaxProductoDF.TabIndex = 8;
            // 
            // tbBusquedaNroFProductoDF
            // 
            tbBusquedaNroFProductoDF.Location = new Point(603, 217);
            tbBusquedaNroFProductoDF.Name = "tbBusquedaNroFProductoDF";
            tbBusquedaNroFProductoDF.PlaceholderText = "Numero de Factura";
            tbBusquedaNroFProductoDF.Size = new Size(150, 27);
            tbBusquedaNroFProductoDF.TabIndex = 9;
            // 
            // tbBusquedaPrecioMinProductoDF
            // 
            tbBusquedaPrecioMinProductoDF.Location = new Point(1023, 181);
            tbBusquedaPrecioMinProductoDF.Name = "tbBusquedaPrecioMinProductoDF";
            tbBusquedaPrecioMinProductoDF.PlaceholderText = "Precio minimo";
            tbBusquedaPrecioMinProductoDF.Size = new Size(150, 27);
            tbBusquedaPrecioMinProductoDF.TabIndex = 10;
            // 
            // DetalleFactura
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(1200, 800);
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
    }
}