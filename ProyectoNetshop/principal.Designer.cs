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
            btnReportes = new FontAwesome.Sharp.IconButton();
            btnProductos = new FontAwesome.Sharp.IconButton();
            btnClientes = new FontAwesome.Sharp.IconButton();
            btnVentas = new FontAwesome.Sharp.IconButton();
            btnBackup = new FontAwesome.Sharp.IconButton();
            btnUsuarios = new FontAwesome.Sharp.IconButton();
            panelLogo = new Panel();
            panelContenedor = new Panel();
            panelSuperior = new Panel();
            panelIzquierdo.SuspendLayout();
            SuspendLayout();
            // 
            // panelIzquierdo
            // 
            panelIzquierdo.BackColor = Color.FromArgb(0, 0, 64);
            panelIzquierdo.Controls.Add(btnSalir);
            panelIzquierdo.Controls.Add(btnReportes);
            panelIzquierdo.Controls.Add(btnProductos);
            panelIzquierdo.Controls.Add(btnClientes);
            panelIzquierdo.Controls.Add(btnVentas);
            panelIzquierdo.Controls.Add(btnBackup);
            panelIzquierdo.Controls.Add(btnUsuarios);
            panelIzquierdo.Controls.Add(panelLogo);
            panelIzquierdo.Dock = DockStyle.Left;
            panelIzquierdo.Location = new Point(0, 0);
            panelIzquierdo.Name = "panelIzquierdo";
            panelIzquierdo.Size = new Size(200, 681);
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
            btnSalir.Location = new Point(0, 621);
            btnSalir.Name = "btnSalir";
            btnSalir.Padding = new Padding(10, 0, 20, 0);
            btnSalir.Size = new Size(200, 60);
            btnSalir.TabIndex = 7;
            btnSalir.Text = "Salir";
            btnSalir.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += iconButton6_Click;
            // 
            // btnReportes
            // 
            btnReportes.Cursor = Cursors.Hand;
            btnReportes.Dock = DockStyle.Top;
            btnReportes.FlatStyle = FlatStyle.Flat;
            btnReportes.Font = new Font("Dubai", 14.2499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnReportes.ForeColor = SystemColors.ButtonFace;
            btnReportes.IconChar = FontAwesome.Sharp.IconChar.Readme;
            btnReportes.IconColor = Color.White;
            btnReportes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnReportes.IconSize = 40;
            btnReportes.ImageAlign = ContentAlignment.MiddleLeft;
            btnReportes.Location = new Point(0, 400);
            btnReportes.Name = "btnReportes";
            btnReportes.Padding = new Padding(10, 0, 20, 0);
            btnReportes.Size = new Size(200, 60);
            btnReportes.TabIndex = 6;
            btnReportes.Text = "Reportes";
            btnReportes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnReportes.UseVisualStyleBackColor = true;
            btnReportes.Click += btnReportes_Click;
            // 
            // btnProductos
            // 
            btnProductos.Cursor = Cursors.Hand;
            btnProductos.Dock = DockStyle.Top;
            btnProductos.FlatStyle = FlatStyle.Flat;
            btnProductos.Font = new Font("Dubai", 14.2499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnProductos.ForeColor = SystemColors.ButtonFace;
            btnProductos.IconChar = FontAwesome.Sharp.IconChar.ShoppingBag;
            btnProductos.IconColor = Color.White;
            btnProductos.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnProductos.IconSize = 40;
            btnProductos.ImageAlign = ContentAlignment.MiddleLeft;
            btnProductos.Location = new Point(0, 340);
            btnProductos.Name = "btnProductos";
            btnProductos.Padding = new Padding(10, 0, 20, 0);
            btnProductos.Size = new Size(200, 60);
            btnProductos.TabIndex = 5;
            btnProductos.Text = "Productos";
            btnProductos.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnProductos.UseVisualStyleBackColor = true;
            btnProductos.Click += btnProductos_Click;
            // 
            // btnClientes
            // 
            btnClientes.Cursor = Cursors.Hand;
            btnClientes.Dock = DockStyle.Top;
            btnClientes.FlatStyle = FlatStyle.Flat;
            btnClientes.Font = new Font("Dubai", 14.2499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnClientes.ForeColor = SystemColors.ButtonFace;
            btnClientes.IconChar = FontAwesome.Sharp.IconChar.Users;
            btnClientes.IconColor = Color.White;
            btnClientes.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnClientes.IconSize = 40;
            btnClientes.ImageAlign = ContentAlignment.MiddleLeft;
            btnClientes.Location = new Point(0, 280);
            btnClientes.Name = "btnClientes";
            btnClientes.Padding = new Padding(10, 0, 20, 0);
            btnClientes.Size = new Size(200, 60);
            btnClientes.TabIndex = 4;
            btnClientes.Text = "Clientes";
            btnClientes.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnClientes.UseVisualStyleBackColor = true;
            btnClientes.Click += btnClientes_Click;
            // 
            // btnVentas
            // 
            btnVentas.Cursor = Cursors.Hand;
            btnVentas.Dock = DockStyle.Top;
            btnVentas.FlatStyle = FlatStyle.Flat;
            btnVentas.Font = new Font("Dubai", 14.2499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnVentas.ForeColor = SystemColors.ButtonFace;
            btnVentas.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            btnVentas.IconColor = Color.White;
            btnVentas.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnVentas.IconSize = 40;
            btnVentas.ImageAlign = ContentAlignment.MiddleLeft;
            btnVentas.Location = new Point(0, 220);
            btnVentas.Name = "btnVentas";
            btnVentas.Padding = new Padding(10, 0, 20, 0);
            btnVentas.Size = new Size(200, 60);
            btnVentas.TabIndex = 3;
            btnVentas.Text = "Ventas";
            btnVentas.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnVentas.UseVisualStyleBackColor = true;
            btnVentas.Click += btnVentas_Click_1;
            // 
            // btnBackup
            // 
            btnBackup.Cursor = Cursors.Hand;
            btnBackup.Dock = DockStyle.Top;
            btnBackup.FlatStyle = FlatStyle.Flat;
            btnBackup.Font = new Font("Dubai", 14.2499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnBackup.ForeColor = SystemColors.ButtonFace;
            btnBackup.IconChar = FontAwesome.Sharp.IconChar.Database;
            btnBackup.IconColor = Color.White;
            btnBackup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnBackup.IconSize = 40;
            btnBackup.ImageAlign = ContentAlignment.MiddleLeft;
            btnBackup.Location = new Point(0, 160);
            btnBackup.Name = "btnBackup";
            btnBackup.Padding = new Padding(10, 0, 20, 0);
            btnBackup.Size = new Size(200, 60);
            btnBackup.TabIndex = 2;
            btnBackup.Text = "Backup";
            btnBackup.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBackup.UseVisualStyleBackColor = true;
            btnBackup.Click += btnBackup_Click;
            // 
            // btnUsuarios
            // 
            btnUsuarios.Cursor = Cursors.Hand;
            btnUsuarios.Dock = DockStyle.Top;
            btnUsuarios.FlatStyle = FlatStyle.Flat;
            btnUsuarios.Font = new Font("Dubai", 14.2499981F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            btnUsuarios.ForeColor = SystemColors.ButtonFace;
            btnUsuarios.IconChar = FontAwesome.Sharp.IconChar.User;
            btnUsuarios.IconColor = Color.White;
            btnUsuarios.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnUsuarios.IconSize = 40;
            btnUsuarios.ImageAlign = ContentAlignment.MiddleLeft;
            btnUsuarios.Location = new Point(0, 100);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Padding = new Padding(10, 0, 20, 0);
            btnUsuarios.Size = new Size(200, 60);
            btnUsuarios.TabIndex = 1;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.SlateGray;
            panelLogo.BackgroundImage = (Image)resources.GetObject("panelLogo.BackgroundImage");
            panelLogo.BackgroundImageLayout = ImageLayout.Stretch;
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(200, 100);
            panelLogo.TabIndex = 0;
            // 
            // panelContenedor
            // 
            panelContenedor.Dock = DockStyle.Bottom;
            panelContenedor.Location = new Point(200, 118);
            panelContenedor.Name = "panelContenedor";
            panelContenedor.Size = new Size(1064, 563);
            panelContenedor.TabIndex = 2;
            // 
            // panelSuperior
            // 
            panelSuperior.BackColor = Color.FromArgb(0, 0, 64);
            panelSuperior.Dock = DockStyle.Top;
            panelSuperior.Location = new Point(200, 0);
            panelSuperior.Name = "panelSuperior";
            panelSuperior.Size = new Size(1064, 100);
            panelSuperior.TabIndex = 1;
            // 
            // principal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.SlateGray;
            ClientSize = new Size(1264, 681);
            Controls.Add(panelContenedor);
            Controls.Add(panelSuperior);
            Controls.Add(panelIzquierdo);
            Name = "principal";
            Text = "Netshop";
            panelIzquierdo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panelIzquierdo;
        private FontAwesome.Sharp.IconButton btnUsuarios;
        private Panel panelLogo;
        private FontAwesome.Sharp.IconButton btnBackup;
        private FontAwesome.Sharp.IconButton btnClientes;
        private FontAwesome.Sharp.IconButton btnVentas;
        private FontAwesome.Sharp.IconButton btnReportes;
        private FontAwesome.Sharp.IconButton btnProductos;
        private FontAwesome.Sharp.IconButton btnSalir;
        private Panel panelSuperior;
        private Panel panelContenedor;
    }
}
