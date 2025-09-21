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
            TBUsuarioLogin = new TextBox();
            TBContraseniaLogin = new TextBox();
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
            LUsuario.Location = new Point(251, 152);
            LUsuario.Name = "LUsuario";
            LUsuario.Size = new Size(69, 29);
            LUsuario.TabIndex = 0;
            LUsuario.Text = "Usuario";
            LUsuario.Click += LUsuario_Click;
            // 
            // LContraseña
            // 
            LContraseña.AutoSize = true;
            LContraseña.Font = new Font("Dubai", 9.749999F, FontStyle.Bold | FontStyle.Italic);
            LContraseña.ForeColor = SystemColors.ButtonFace;
            LContraseña.Location = new Point(239, 231);
            LContraseña.Name = "LContraseña";
            LContraseña.Size = new Size(94, 29);
            LContraseña.TabIndex = 1;
            LContraseña.Text = "Contraseña";
            // 
            // BIngresar
            // 
            BIngresar.Cursor = Cursors.Hand;
            BIngresar.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            BIngresar.ForeColor = SystemColors.ActiveCaptionText;
            BIngresar.Location = new Point(127, 319);
            BIngresar.Margin = new Padding(3, 4, 3, 4);
            BIngresar.Name = "BIngresar";
            BIngresar.Size = new Size(115, 64);
            BIngresar.TabIndex = 2;
            BIngresar.Text = "Ingresar";
            BIngresar.UseVisualStyleBackColor = true;
            BIngresar.Click += BIngresar_Click;
            // 
            // BCancelar
            // 
            BCancelar.Cursor = Cursors.Hand;
            BCancelar.Font = new Font("Dubai", 12F, FontStyle.Bold | FontStyle.Italic);
            BCancelar.ForeColor = SystemColors.ActiveCaptionText;
            BCancelar.Location = new Point(323, 319);
            BCancelar.Margin = new Padding(3, 4, 3, 4);
            BCancelar.Name = "BCancelar";
            BCancelar.Size = new Size(115, 64);
            BCancelar.TabIndex = 3;
            BCancelar.Text = "Cancelar";
            BCancelar.UseVisualStyleBackColor = true;
            BCancelar.Click += BCancelar_Click;
            // 
            // TBUsuarioLogin
            // 
            TBUsuarioLogin.Font = new Font("Segoe UI", 9F);
            TBUsuarioLogin.Location = new Point(183, 185);
            TBUsuarioLogin.Margin = new Padding(3, 4, 3, 4);
            TBUsuarioLogin.Name = "TBUsuarioLogin";
            TBUsuarioLogin.PlaceholderText = "Ingrese su nombre...";
            TBUsuarioLogin.Size = new Size(201, 27);
            TBUsuarioLogin.TabIndex = 4;
            TBUsuarioLogin.TextChanged += TBUsuarioLogin_TextChanged;
            // 
            // TBContraseniaLogin
            // 
            TBContraseniaLogin.Font = new Font("Segoe UI", 9F);
            TBContraseniaLogin.Location = new Point(183, 264);
            TBContraseniaLogin.Margin = new Padding(3, 4, 3, 4);
            TBContraseniaLogin.Name = "TBContraseniaLogin";
            TBContraseniaLogin.PlaceholderText = "Ingrese su contraseña...";
            TBContraseniaLogin.Size = new Size(201, 27);
            TBContraseniaLogin.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkGray;
            panel1.BackgroundImage = (Image)resources.GetObject("panel1.BackgroundImage");
            panel1.BackgroundImageLayout = ImageLayout.Stretch;
            panel1.Location = new Point(183, 16);
            panel1.Name = "panel1";
            panel1.Size = new Size(200, 117);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(0, 0, 64);
            panel2.Controls.Add(panel1);
            panel2.Controls.Add(TBContraseniaLogin);
            panel2.Controls.Add(TBUsuarioLogin);
            panel2.Controls.Add(LUsuario);
            panel2.Controls.Add(BCancelar);
            panel2.Controls.Add(LContraseña);
            panel2.Controls.Add(BIngresar);
            panel2.Location = new Point(22, 21);
            panel2.Name = "panel2";
            panel2.Size = new Size(538, 397);
            panel2.TabIndex = 7;
            // 
            // FInicioSesion
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(0, 0, 64);
            ClientSize = new Size(582, 441);
            Controls.Add(panel2);
            Margin = new Padding(3, 4, 3, 4);
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
        private System.Windows.Forms.TextBox TBUsuarioLogin;
        private System.Windows.Forms.TextBox TBContraseniaLogin;
        private Panel panel1;
        private Panel panel2;
    }
}

