namespace vistaDeProyectoC
{
    partial class FInicioSesion
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FInicioSesion));
            LUsuario = new Label();
            LContraseña = new Label();
            BIngresar = new Button();
            BCancelar = new Button();
            TBUsuario = new TextBox();
            TBContraseña = new TextBox();
            panel1 = new Panel();
            panel2 = new Panel();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // LUsuario
            // 
            LUsuario.AutoSize = true;
            LUsuario.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            LUsuario.ForeColor = SystemColors.ButtonFace;
            LUsuario.Location = new Point(220, 114);
            LUsuario.Name = "LUsuario";
            LUsuario.Size = new Size(53, 22);
            LUsuario.TabIndex = 0;
            LUsuario.Text = "Usuario";
            LUsuario.Click += LUsuario_Click;
            // 
            // LContraseña
            // 
            LContraseña.AutoSize = true;
            LContraseña.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            LContraseña.ForeColor = SystemColors.ButtonFace;
            LContraseña.Location = new Point(209, 173);
            LContraseña.Name = "LContraseña";
            LContraseña.Size = new Size(73, 22);
            LContraseña.TabIndex = 1;
            LContraseña.Text = "Contraseña";
            // 
            // BIngresar
            // 
            BIngresar.Cursor = Cursors.Hand;
            BIngresar.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            BIngresar.ForeColor = SystemColors.ActiveCaptionText;
            BIngresar.Location = new Point(111, 239);
            BIngresar.Name = "BIngresar";
            BIngresar.Size = new Size(101, 48);
            BIngresar.TabIndex = 2;
            BIngresar.Text = "Ingresar";
            BIngresar.UseVisualStyleBackColor = true;
            // 
            // BCancelar
            // 
            BCancelar.Cursor = Cursors.Hand;
            BCancelar.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            BCancelar.ForeColor = SystemColors.ActiveCaptionText;
            BCancelar.Location = new Point(283, 239);
            BCancelar.Name = "BCancelar";
            BCancelar.Size = new Size(101, 48);
            BCancelar.TabIndex = 3;
            BCancelar.Text = "Cancelar";
            BCancelar.UseVisualStyleBackColor = true;
            // 
            // TBUsuario
            // 
            TBUsuario.Font = new Font("Segoe UI", 9F);
            TBUsuario.Location = new Point(160, 139);
            TBUsuario.Name = "TBUsuario";
            TBUsuario.Size = new Size(176, 23);
            TBUsuario.TabIndex = 4;
            // 
            // TBContraseña
            // 
            TBContraseña.Font = new Font("Segoe UI", 9F);
            TBContraseña.Location = new Point(160, 198);
            TBContraseña.Name = "TBContraseña";
            TBContraseña.Size = new Size(176, 23);
            TBContraseña.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGray;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(160, 12);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(175, 88);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(TBContraseña);
            panel2.Controls.Add(TBUsuario);
            panel2.Controls.Add(LUsuario);
            panel2.Controls.Add(BCancelar);
            panel2.Controls.Add(LContraseña);
            panel2.Controls.Add(BIngresar);
            panel2.Location = new Point(19, 16);
            panel2.Margin = new Padding(3, 2, 3, 2);
            panel2.Name = "panel2";
            panel2.Size = new Size(471, 298);
            panel2.TabIndex = 7;
            // 
            // FInicioSesion
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(509, 331);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FInicioSesion";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar Sesion";
            Load += FInicioSesion_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label LUsuario;
        private System.Windows.Forms.Label LContraseña;
        private System.Windows.Forms.Button BIngresar;
        private System.Windows.Forms.Button BCancelar;
        private System.Windows.Forms.TextBox TBUsuario;
        private System.Windows.Forms.TextBox TBContraseña;
        private Panel panel1;
        private Panel panel2;
    }
}

