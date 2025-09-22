namespace vistaDeProyectoC
{
    partial class FBackUp
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
            LBackUp = new Label();
            LBaseDeDatos = new Label();
            LGuardarRuta = new Label();
            TBBaseDeDatos = new TextBox();
            TBGuardarRuta = new TextBox();
            BConectar = new Button();
            BGuardarRuta = new Button();
            BBackUp = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // LBackUp
            // 
            LBackUp.AutoSize = true;
            LBackUp.Font = new Font("Dubai", 20F, FontStyle.Bold | FontStyle.Italic);
            LBackUp.ForeColor = SystemColors.ButtonFace;
            LBackUp.Location = new Point(465, 30);
            LBackUp.Name = "LBackUp";
            LBackUp.Size = new Size(146, 57);
            LBackUp.TabIndex = 0;
            LBackUp.Text = "Back Up";
            // 
            // LBaseDeDatos
            // 
            LBaseDeDatos.AutoSize = true;
            LBaseDeDatos.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            LBaseDeDatos.ForeColor = SystemColors.ButtonFace;
            LBaseDeDatos.Location = new Point(218, 155);
            LBaseDeDatos.Name = "LBaseDeDatos";
            LBaseDeDatos.Size = new Size(113, 29);
            LBaseDeDatos.TabIndex = 1;
            LBaseDeDatos.Text = "Base de Datos";
            // 
            // LGuardarRuta
            // 
            LGuardarRuta.AutoSize = true;
            LGuardarRuta.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            LGuardarRuta.ForeColor = SystemColors.ButtonFace;
            LGuardarRuta.Location = new Point(285, 250);
            LGuardarRuta.Name = "LGuardarRuta";
            LGuardarRuta.Size = new Size(46, 29);
            LGuardarRuta.TabIndex = 2;
            LGuardarRuta.Text = "Ruta";
            // 
            // TBBaseDeDatos
            // 
            TBBaseDeDatos.Font = new Font("Segoe UI", 9F);
            TBBaseDeDatos.Location = new Point(346, 157);
            TBBaseDeDatos.Margin = new Padding(3, 4, 3, 4);
            TBBaseDeDatos.Multiline = true;
            TBBaseDeDatos.Name = "TBBaseDeDatos";
            TBBaseDeDatos.Size = new Size(400, 27);
            TBBaseDeDatos.TabIndex = 3;
            TBBaseDeDatos.TextChanged += TBBaseDeDatos_TextChanged;
            // 
            // TBGuardarRuta
            // 
            TBGuardarRuta.Location = new Point(346, 252);
            TBGuardarRuta.Margin = new Padding(3, 4, 3, 4);
            TBGuardarRuta.Multiline = true;
            TBGuardarRuta.Name = "TBGuardarRuta";
            TBGuardarRuta.Size = new Size(400, 27);
            TBGuardarRuta.TabIndex = 4;
            TBGuardarRuta.TextChanged += TBGuardarRuta_TextChanged;
            // 
            // BConectar
            // 
            BConectar.Cursor = Cursors.Hand;
            BConectar.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            BConectar.ForeColor = SystemColors.ActiveCaptionText;
            BConectar.Location = new Point(779, 145);
            BConectar.Margin = new Padding(3, 4, 3, 4);
            BConectar.Name = "BConectar";
            BConectar.Size = new Size(120, 50);
            BConectar.TabIndex = 5;
            BConectar.Text = "Conectar";
            BConectar.UseVisualStyleBackColor = true;
            BConectar.Click += BConectar_Click;
            // 
            // BGuardarRuta
            // 
            BGuardarRuta.Cursor = Cursors.Hand;
            BGuardarRuta.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            BGuardarRuta.ForeColor = SystemColors.ActiveCaptionText;
            BGuardarRuta.Location = new Point(779, 243);
            BGuardarRuta.Margin = new Padding(3, 4, 3, 4);
            BGuardarRuta.Name = "BGuardarRuta";
            BGuardarRuta.Size = new Size(120, 50);
            BGuardarRuta.TabIndex = 6;
            BGuardarRuta.Text = "Guardar";
            BGuardarRuta.UseVisualStyleBackColor = true;
            BGuardarRuta.Click += BGuardarRuta_Click;
            // 
            // BBackUp
            // 
            BBackUp.Cursor = Cursors.Hand;
            BBackUp.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            BBackUp.ForeColor = SystemColors.ActiveCaptionText;
            BBackUp.Location = new Point(479, 399);
            BBackUp.Margin = new Padding(3, 4, 3, 4);
            BBackUp.Name = "BBackUp";
            BBackUp.Size = new Size(120, 50);
            BBackUp.TabIndex = 7;
            BBackUp.Text = "Back Up";
            BBackUp.UseVisualStyleBackColor = true;
            BBackUp.Click += BBackUp_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 0, 64);
            panel1.Controls.Add(TBBaseDeDatos);
            panel1.Controls.Add(BBackUp);
            panel1.Controls.Add(LBackUp);
            panel1.Controls.Add(BGuardarRuta);
            panel1.Controls.Add(LBaseDeDatos);
            panel1.Controls.Add(BConectar);
            panel1.Controls.Add(LGuardarRuta);
            panel1.Controls.Add(TBGuardarRuta);
            panel1.Location = new Point(22, 22);
            panel1.Name = "panel1";
            panel1.Size = new Size(1130, 655);
            panel1.TabIndex = 8;
            // 
            // FBackUp
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(1177, 699);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 4, 3, 4);
            Name = "FBackUp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Back Up";
            Load += FBackUp_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LBackUp;
        private System.Windows.Forms.Label LBaseDeDatos;
        private System.Windows.Forms.Label LGuardarRuta;
        private System.Windows.Forms.TextBox TBBaseDeDatos;
        private System.Windows.Forms.TextBox TBGuardarRuta;
        private System.Windows.Forms.Button BConectar;
        private System.Windows.Forms.Button BGuardarRuta;
        private System.Windows.Forms.Button BBackUp;
        private Panel panel1;
    }
}