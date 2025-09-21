using vistaDeProyectoC;                 // para FReporteUsuario
using ProyectoNetshop.formularios;      // para ReportesV y Reportes

namespace ProyectoNetshop
{
    public partial class principal : Form
    {
        private readonly int idPerfil;

        public principal(int p_idPerfil)
        {
            InitializeComponent();

            // Aquí suscribo el evento Load al método Principal_Load
            this.Load += principal_Load;

            idPerfil = p_idPerfil;

            //MessageBox.Show($"Perfil en principal: {idPerfil}");

            AplicarPermisos();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AbrirFormularioEnPanel(object formulario)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);
            Form fh = formulario as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        // Reemplaza la línea en btnUsuarios_Click:
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new formularios.usuarios());
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            Form reporteARenderizar;

            switch (idPerfil)   // o idPerfil si ese es tu campo
            {
                case 1: // Administrador
                    reporteARenderizar = new FReporteUsuario();
                    break;

                case 2: // Vendedor
                    reporteARenderizar = new ReportesV();
                    break;

                case 3: // Gerente
                    reporteARenderizar = new Reportes();
                    break;

                default:
                    MessageBox.Show(
                        "Perfil de usuario no reconocido.",
                        "Error de permisos",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
            }

            AbrirFormularioEnPanel(reporteARenderizar);
        }

        private void btnVentas_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new formularios.ventas());
        }

        private void btnBackup_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new vistaDeProyectoC.FBackUp());
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new vistaDeProyectoC.FRegistrarCliente());
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new formularios.CrudProductos());
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void principal_Load(object sender, EventArgs e)
        {
            
        }

        private void AplicarPermisos()
        {
            // 1) Lista de todos los botones de la UI
            var botones = new[]
            {
                btnIconUsuarios, btnIconBackup, btnIconVentas, btnIconClientes, btnIconProductos, btnIconReportes
            };

            // 2) Deshabilitar todo al inicio
            foreach (var btn in botones)
                btn.Enabled = false;

            // 3) Habilitar según idPerfil (1=Admin, 2=Vendedor, 3=Gerente)
            switch (idPerfil)
            {
                case 1: // Administrador
                    btnIconUsuarios.Enabled = true;
                    btnIconBackup.Enabled = true;
                    btnIconReportes.Enabled = true;
                    break;

                case 2: // Vendedor
                    btnIconVentas.Enabled = true;
                    btnIconClientes.Enabled = true;
                    btnIconReportes.Enabled = true;
                    break;

                case 3: // Gerente
                    btnIconVentas.Enabled = true;
                    btnIconProductos.Enabled = true;
                    btnIconReportes.Enabled = true;
                    break;

                default:
                    // Opcional: mensaje o log de perfil desconocido
                    break;
            }
        }
    }
}
