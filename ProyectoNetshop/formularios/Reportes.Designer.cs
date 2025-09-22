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
            button1 = new Button();
            panel1 = new Panel();
            label1 = new Label();
            label7 = new Label();
            fechaHasta = new DateTimePicker();
            fechaDesde = new DateTimePicker();
            button3 = new Button();
            button2 = new Button();
            panel2 = new Panel();
            cbVendedoresNombreReporte = new ComboBox();
            cbVendedoresDniReporte = new ComboBox();
            label2 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Cursor = Cursors.Hand;
            button1.Dock = DockStyle.Bottom;
            button1.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.Location = new Point(0, 646);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(288, 53);
            button1.TabIndex = 0;
            button1.Text = "Total de ventas";
            button1.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(fechaHasta);
            panel1.Controls.Add(fechaDesde);
            panel1.Controls.Add(button3);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(288, 699);
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
            // fechaHasta
            // 
            fechaHasta.Location = new Point(40, 335);
            fechaHasta.Margin = new Padding(3, 4, 3, 4);
            fechaHasta.Name = "fechaHasta";
            fechaHasta.Size = new Size(209, 27);
            fechaHasta.TabIndex = 18;
            // 
            // fechaDesde
            // 
            fechaDesde.Location = new Point(40, 217);
            fechaDesde.Margin = new Padding(3, 4, 3, 4);
            fechaDesde.Name = "fechaDesde";
            fechaDesde.Size = new Size(209, 27);
            fechaDesde.TabIndex = 17;
            // 
            // button3
            // 
            button3.Cursor = Cursors.Hand;
            button3.Dock = DockStyle.Bottom;
            button3.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button3.Location = new Point(0, 540);
            button3.Margin = new Padding(3, 4, 3, 4);
            button3.Name = "button3";
            button3.Size = new Size(288, 53);
            button3.TabIndex = 2;
            button3.Text = "Recaudación";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Cursor = Cursors.Hand;
            button2.Dock = DockStyle.Bottom;
            button2.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button2.Location = new Point(0, 593);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(288, 53);
            button2.TabIndex = 1;
            button2.Text = "Prductos mas vendidos";
            button2.UseVisualStyleBackColor = true;
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
            panel2.Size = new Size(889, 133);
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
            ClientSize = new Size(1177, 699);
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

        private Button button1;
        private Panel panel1;
        private Button button3;
        private Button button2;
        private DateTimePicker fechaDesde;
        private DateTimePicker fechaHasta;
        private Label label1;
        private Label label7;
        private Panel panel2;
        private Label label2;
        private ComboBox cbVendedoresNombreReporte;
        private ComboBox cbVendedoresDniReporte;
    }
}