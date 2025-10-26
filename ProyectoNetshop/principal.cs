using vistaDeProyectoC; // Importa el namespace con el formulario de login
using ProyectoNetshop.formularios; // Importa los formularios de la aplicación

namespace ProyectoNetshop
{
    public partial class principal : Form
    {
        // Datos del usuario autenticado
        //Perfil
        private int idPerfil;

        //Vendedor
        private int vendedorDni;
        private string vendedorNombre;
        private int vendedorId;

        ////Cliente
        //private int clienteDni;
        //private string clienteNombre;
        //private int clienteId;

        // Constructor
        public principal(int p_idPerfil, //Perfil
                         int p_dni, string p_nombre, int p_id_vendedor //Vendedor
                         //int p_dni_cliente, string p_nombre_cliente, int p_id_cliente //Cliente
                         )
        {
            InitializeComponent();

            // Llama a principal_Load al mostrarse
            this.Load += principal_Load;

            // Guardamos internamente los parámetros pasados desde el login
            //Perfil
            idPerfil = p_idPerfil;
            
            //Vendedor
            vendedorDni = p_dni;
            vendedorNombre = p_nombre;
            vendedorId = p_id_vendedor;

            ////Cliente
            //clienteDni = p_dni_cliente;
            //clienteNombre = p_nombre_cliente;
            //clienteId = p_id_cliente;

            // Validamos el acceso según el perfil del usuario
            AplicarPermisos();
        }

        // Evento del botón “Cerrar sesión”
        private void iconButton6_Click(object sender, EventArgs e)
        {
            // Se muestra un mensaje
            var respuesta = MessageBox.Show("¿Estás seguro que deseas cerrar sesión y volver al login?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Si el usuario dice Sí, reinicio la app
            if (respuesta == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        // Método para mostrar un Form dentro de un Panel
        private void AbrirFormularioEnPanel(object formulario)
        {
            // Si el panel ya tiene contenido, entonces se quita
            if (this.panelContenedor.Controls.Count > 0) this.panelContenedor.Controls.RemoveAt(0);

            // Convertimos el objeto a Form para tratarlo como control hijo
            Form fh = formulario as Form;

            // Indicamos que no sea ventana independiente
            fh.TopLevel = false;

            // Establecemos que ocupa todo el espacio disponible dentro del panel
            fh.Dock = DockStyle.Fill;

            // Agrega el formulario al panel y almacena una referencia en tag
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;

            // Se muestra
            fh.Show();
        }

        // Al hacer clic en el boton Usuarios, carga ese Form en el panel
        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new formularios.usuarios());
        }

        // Al hacer clic en “Reportes”, se pregunta qué formulario de reportes mostrar según el perfil de usuario
        private void btnReportes_Click(object sender, EventArgs e)
        {
            Form reporteARenderizar;

            switch (idPerfil)   // idPerfil indica rol: 1=Admin, 2=Vendedor, 3=Gerente…
            {
                case 1: // Administrador
                    reporteARenderizar = new FReporteUsuario();
                    break;

                case 2: // Vendedor
                    reporteARenderizar = new ReportesV(vendedorDni, vendedorNombre);
                    break;

                case 3: // Gerente
                    reporteARenderizar = new Reportes(idPerfil);
                    break;

                default:
                    MessageBox.Show("Perfil de usuario no reconocido.", "Error de permisos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            // Se agrega el formulario de reportes elegido en el panel principal
            AbrirFormularioEnPanel(reporteARenderizar);
        }

        // Al hacer clic en “Ventas”, abre la vista de ventas
        private void btnVentas_Click_1(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new formularios.ventas(vendedorDni, vendedorNombre, vendedorId));
        }

        // Al hacer clic en “Backup”, muestra el formulario de respaldo de la base de datos
        private void btnBackup_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new vistaDeProyectoC.FBackUp());
        }

        // Al hacer clic en “Clientes”, abre el formulario para registrar nuevos clientes
        private void btnClientes_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new vistaDeProyectoC.FRegistrarCliente());
        }

        // Al hacer clic en “Productos”, abre el formulario para registrar nuevos productos
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

        // Este metodo determina que secciones el usuario puede acceder dependiendo el rol del usuario
        private void AplicarPermisos()
        {
            // Se lista de todos los botones
            var botones = new[]
            {
                btnIconUsuarios, btnIconBackup, btnIconVentas, btnIconClientes, btnIconProductos, btnIconReportes
            };

            // Se deshabilita todo al inicio
            foreach (var btn in botones)
                btn.Enabled = false;

            // Habilitar según idPerfil (1=Admin, 2=Vendedor, 3=Gerente)
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
                    break;
            }
        }
    }
}
