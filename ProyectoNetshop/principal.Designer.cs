namespace ProyectoNetshop
{
    partial class principal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(principal));
            panelIzquierdo = new Panel();
            btnSalir = new FontAwesome.Sharp.IconButton();
            btnIconReportes = new FontAwesome.Sharp.IconButton();
            btnIconProductos = new FontAwesome.Sharp.IconButton();
            btnIconClientes = new FontAwesome.Sharp.IconButton();
            btnIconVentas = new FontAwesome.Sharp.IconButton();
            btnIconBackup = new FontAwesome.Sharp.IconButton();
            btnIconUsuarios = new FontAwesome.Sharp.IconButton();
            panelLogo = new Panel();
            panelSuperior = new Panel();
            panel1 = new Panel();
            panelContenedor = new Panel();
            panelIzquierdo.SuspendLayout();
            panelSuperior.SuspendLayout();
            SuspendLayout();
            // 
            // panelIzquierdo
            // 
            panelIzquierdo.BackColor = Color.FromArgb(0, 0, 64);
            panelIzquierdo.Controls.Add(btnSalir);
            panelIzquierdo.Controls.Add(btnIconReportes);
            panelIzquierdo.Controls.Add(btnIconProductos);
            panelIzquierdo.Controls.Add(btnIconClientes);
            panelIzquierdo.Controls.Add(btnIconVentas);
            panelIzquierdo.Controls.Add(btnIconBackup);
            panelIzquierdo.Controls.Add(btnIconUsuarios);
            panelIzquierdo.Controls.Add(panelLogo);
            panelIzquierdo.Dock = DockStyle.Left;
            panelIzquierdo.Location = new Point(0, 0);
            panelIzquierdo.Margin = new Padding(3, 4, 3, 4);
            panelIzquierdo.Name = "panelIzquierdo";
            panelIzquierdo.Size = new Size(229, 753);
            panelIzquierdo.TabIndex = 0;
            // 
            // btnSalir
            // 
            btnSalir.Cursor = Cursors.Hand;
            btnSalir.Dock = DockStyle.Bottom;
            btnSalir.FlatStyle = FlatStyle.Flat;
            btnSalir.Font = new Font("Dubai", 14.2499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnSalir.ForeColor = SystemColors.ButtonFace;
            btnSalir.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnSalir.IconColor = Color.White;
            btnSalir.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnSalir.IconSize = 40;
            btnSalir.ImageAlign = ContentAlignment.MiddleLeft;
            btnSalir.Location = new Point(0, 673);
            btnSalir.Margin = new Padding(3, 4, 3, 4);
            btnSalir.Name = "btnSalir";
            btnSalir.Padding = new Padding(11, 0, 23, 0);
            btnSalir.Size = new Size(229, 80);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += iconButton6_Click;
            // 
            // btnIconReportes
            // 
            btnIconReportes.Cursor = Cursors.Hand;
            btnIconReportes.Dock = DockStyle.Top;
            btnIconReportes.FlatStyle = FlatStyle.Flat;
            btnIconReportes.Font = new Font("Dubai", 14.2499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnIconReportes.ForeColor = SystemColors.ButtonFace;
            btnIconReportes.IconChar = FontAwesome.Sharp.IconChar.Readme;
            btnIconReportes.IconColor = Color.White;
            btnIconReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnIconReportes.IconSize = 40;
            btnIconReportes.ImageAlign = ContentAlignment.MiddleLeft;
            btnIconReportes.Location = new Point(0, 533);
            btnIconReportes.Margin = new Padding(3, 4, 3, 4);
            btnIconReportes.Name = "btnIconReportes";
            btnIconReportes.Padding = new Padding(11, 0, 23, 0);
            btnIconReportes.Size = new Size(229, 80);
            btnIconReportes.TabIndex = 6;
            btnIconReportes.Text = "Reportes";
            btnIconReportes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnIconReportes.UseVisualStyleBackColor = true;
            btnIconReportes.Click += btnReportes_Click;
            // 
            // btnIconProductos
            // 
            btnIconProductos.Cursor = Cursors.Hand;
            btnIconProductos.Dock = DockStyle.Top;
            btnIconProductos.FlatStyle = FlatStyle.Flat;
            btnIconProductos.Font = new Font("Dubai", 14.2499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnIconProductos.ForeColor = SystemColors.ButtonFace;
            btnIconProductos.IconChar = FontAwesome.Sharp.IconChar.ShoppingBag;
            btnIconProductos.IconColor = Color.White;
            btnIconProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnIconProductos.IconSize = 40;
            btnIconProductos.ImageAlign = ContentAlignment.MiddleLeft;
            btnIconProductos.Location = new Point(0, 453);
            btnIconProductos.Margin = new Padding(3, 4, 3, 4);
            btnIconProductos.Name = "btnIconProductos";
            btnIconProductos.Padding = new Padding(11, 0, 23, 0);
            btnIconProductos.Size = new Size(229, 80);
            btnIconProductos.TabIndex = 5;
            btnIconProductos.Text = "Productos";
            btnIconProductos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnIconProductos.UseVisualStyleBackColor = true;
            btnIconProductos.Click += btnProductos_Click;
            // 
            // btnIconClientes
            // 
            btnIconClientes.Cursor = Cursors.Hand;
            btnIconClientes.Dock = DockStyle.Top;
            btnIconClientes.FlatStyle = FlatStyle.Flat;
            btnIconClientes.Font = new Font("Dubai", 14.2499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnIconClientes.ForeColor = SystemColors.ButtonFace;
            btnIconClientes.IconChar = FontAwesome.Sharp.IconChar.Users;
            btnIconClientes.IconColor = Color.White;
            btnIconClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnIconClientes.IconSize = 40;
            btnIconClientes.ImageAlign = ContentAlignment.MiddleLeft;
            btnIconClientes.Location = new Point(0, 373);
            btnIconClientes.Margin = new Padding(3, 4, 3, 4);
            btnIconClientes.Name = "btnIconClientes";
            btnIconClientes.Padding = new Padding(11, 0, 23, 0);
            btnIconClientes.Size = new Size(229, 80);
            btnIconClientes.TabIndex = 4;
            btnIconClientes.Text = "Clientes";
            btnIconClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnIconClientes.UseVisualStyleBackColor = true;
            btnIconClientes.Click += btnClientes_Click;
            // 
            // btnIconVentas
            // 
            btnIconVentas.Cursor = Cursors.Hand;
            btnIconVentas.Dock = DockStyle.Top;
            btnIconVentas.FlatStyle = FlatStyle.Flat;
            btnIconVentas.Font = new Font("Dubai", 14.2499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnIconVentas.ForeColor = SystemColors.ButtonFace;
            btnIconVentas.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            btnIconVentas.IconColor = Color.White;
            btnIconVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnIconVentas.IconSize = 40;
            btnIconVentas.ImageAlign = ContentAlignment.MiddleLeft;
            btnIconVentas.Location = new Point(0, 293);
            btnIconVentas.Margin = new Padding(3, 4, 3, 4);
            btnIconVentas.Name = "btnIconVentas";
            btnIconVentas.Padding = new Padding(11, 0, 23, 0);
            btnIconVentas.Size = new Size(229, 80);
            btnIconVentas.TabIndex = 3;
            btnIconVentas.Text = "Ventas";
            btnIconVentas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnIconVentas.UseVisualStyleBackColor = true;
            btnIconVentas.Click += btnVentas_Click_1;
            // 
            // btnIconBackup
            // 
            btnIconBackup.Cursor = Cursors.Hand;
            btnIconBackup.Dock = DockStyle.Top;
            btnIconBackup.FlatStyle = FlatStyle.Flat;
            btnIconBackup.Font = new Font("Dubai", 14.2499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnIconBackup.ForeColor = SystemColors.ButtonFace;
            btnIconBackup.IconChar = FontAwesome.Sharp.IconChar.Database;
            btnIconBackup.IconColor = Color.White;
            btnIconBackup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnIconBackup.IconSize = 40;
            btnIconBackup.ImageAlign = ContentAlignment.MiddleLeft;
            btnIconBackup.Location = new Point(0, 213);
            btnIconBackup.Margin = new Padding(3, 4, 3, 4);
            btnIconBackup.Name = "btnIconBackup";
            btnIconBackup.Padding = new Padding(11, 0, 23, 0);
            btnIconBackup.Size = new Size(229, 80);
            btnIconBackup.TabIndex = 2;
            btnIconBackup.Text = "Backup";
            btnIconBackup.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnIconBackup.UseVisualStyleBackColor = true;
            btnIconBackup.Click += btnBackup_Click;
            // 
            // btnIconUsuarios
            // 
            btnIconUsuarios.Cursor = Cursors.Hand;
            btnIconUsuarios.Dock = DockStyle.Top;
            btnIconUsuarios.FlatStyle = FlatStyle.Flat;
            btnIconUsuarios.Font = new Font("Dubai", 14.2499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnIconUsuarios.ForeColor = SystemColors.ButtonFace;
            btnIconUsuarios.IconChar = FontAwesome.Sharp.IconChar.User;
            btnIconUsuarios.IconColor = Color.White;
            btnIconUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnIconUsuarios.IconSize = 40;
            btnIconUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            btnIconUsuarios.Location = new Point(0, 133);
            btnIconUsuarios.Margin = new Padding(3, 4, 3, 4);
            btnIconUsuarios.Name = "btnIconUsuarios";
            btnIconUsuarios.Padding = new Padding(11, 0, 23, 0);
            btnIconUsuarios.Size = new Size(229, 80);
            btnIconUsuarios.TabIndex = 1;
            btnIconUsuarios.Text = "Usuarios";
            btnIconUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnIconUsuarios.UseVisualStyleBackColor = true;
            btnIconUsuarios.Click += btnUsuarios_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.SlateGray;
            panelLogo.BackgroundImage = (Image)resources.GetObject("panelLogo.BackgroundImage");
            panelLogo.BackgroundImageLayout = ImageLayout.Stretch;
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Margin = new Padding(3, 4, 3, 4);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(229, 133);
            panelLogo.TabIndex = 0;
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.FromArgb(0, 0, 64);
            panelSuperior.Controls.Add(panel1);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(229, 0);
            panelSuperior.Margin = new Padding(3, 4, 3, 4);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1216, 133);
            panelSuperior.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.SlateGray;
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1216, 133);
            panel1.TabIndex = 3;
            // 
            // panelContenedor
            // 
            panelContenedor.Dock = DockStyle.Bottom;
            panelContenedor.Location = new Point(229, 133);
            panelContenedor.Margin = new Padding(3, 4, 3, 4);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1216, 620);
            panelContenedor.TabIndex = 2;
            panelContenedor.Paint += panelContenedor_Paint;
            // 
            // principal
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(1445, 753);
            Controls.Add(panelContenedor);
            Controls.Add(panelSuperior);
            Controls.Add(panelIzquierdo);
            Margin = new Padding(3, 4, 3, 4);
            Name = "principal";
            Text = "Netshop";
            Load += principal_Load;
            panelIzquierdo.ResumeLayout(false);
            panelSuperior.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelIzquierdo;
        private FontAwesome.Sharp.IconButton btnIconUsuarios;
        private Panel panelLogo;
        private FontAwesome.Sharp.IconButton btnIconBackup;
        private FontAwesome.Sharp.IconButton btnIconClientes;
        private FontAwesome.Sharp.IconButton btnIconVentas;
        private FontAwesome.Sharp.IconButton btnIconReportes;
        private FontAwesome.Sharp.IconButton btnIconProductos;
        private FontAwesome.Sharp.IconButton btnSalir;
        private Panel panelSuperior;
        private Panel panel1;
        private Panel panelContenedor;
    }
}
