// Importa librerías.
using FontAwesome.Sharp;
using Microsoft.Data.SqlClient;
using ProyectoNetshop.BD;
using ProyectoNetshop.Cruds;
using ProyectoNetshop.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoNetshop;

namespace vistaDeProyectoC
{
    public partial class FInicioSesion : Form
    {
        // Perfil
        public int IdPerfil { get; private set; }

        // Vendedor
        public int VendedorId { get; private set; }
        public int VendedorDni { get; private set; }
        public string VendedorNombre { get; private set; }


        // Constructor del formulario de inicio de sesión: inicializa componentes visuales, activa el modo oculto para la contraseña,
        // y enlaza eventos para alternar visibilidad del texto y validar que el nombre de usuario contenga solo letras.
        public FInicioSesion()
        {
            InitializeComponent();

            TBContraseniaLogin.UseSystemPasswordChar = true;

            cbOcultarContraseniaLoginUser.CheckedChanged += cbOcultarContraseniaLoginUser_CheckedChanged;

            TBUsuarioLogin.KeyPress += TextBox_OnlyLetters_KeyPress;
        }

        // Evento de carga del formulario de inicio de sesión: asegura que el campo de contraseña se muestre oculto al iniciar,
        // reforzando la privacidad del usuario desde el primer momento.
        private void FInicioSesion_Load(object sender, EventArgs e)
        {
            TBContraseniaLogin.UseSystemPasswordChar = true;
        }

        private void LUsuario_Click(object sender, EventArgs e)
        {

        }

        // Lógica de autenticación al presionar "Ingresar": valida campos obligatorios, consulta la base por el usuario ingresado,
        // verifica estado activo y compara la contraseña. Si es correcto, carga datos del vendedor (ID, DNI, nombre completo), asigna el perfil y
        // cierra el formulario con éxito. En caso de error, muestra mensajes claros según el
        // motivo (usuario inexistente, cuenta inactiva, contraseña incorrecta o error técnico).
        private void BIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBUsuarioLogin.Text))
            {
                MessageBox.Show("El usuario es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBUsuarioLogin.Focus();
                return;
            }

            if (string.IsNullOrEmpty(TBContraseniaLogin.Text))
            {
                MessageBox.Show("La contraseña es obligatoria.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                TBContraseniaLogin.Focus();
                return;
            }

            try
            {
                using var conexion = BaseDeDatos.obtenerConexion();
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                using var cmd = new SqlCommand(@"SELECT pass, activo, id_perfil, dni, nombre, apellido FROM usuario WHERE nombre = @usuario", conexion);

                cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 100).Value = TBUsuarioLogin.Text.Trim();

                using var reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Usuario no encontrado.", "Login fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TBUsuarioLogin.Focus();
                    return;
                }

                bool activo = reader.GetInt32(reader.GetOrdinal("activo")) == 1;
                int idPerfil = reader.GetInt32(reader.GetOrdinal("id_perfil"));
                if (!activo)
                {
                    MessageBox.Show("La cuenta está inactiva.", "Login fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                byte[] hashBD = (byte[])reader["pass"];
                byte[] hashIngresado = Encoding.UTF8.GetBytes(TBContraseniaLogin.Text);
                if (!hashBD.SequenceEqual(hashIngresado))
                {
                    MessageBox.Show("Contraseña incorrecta.", "Login fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TBContraseniaLogin.Clear();
                    TBContraseniaLogin.Focus();
                    return;
                }
                //Vendedor
                int dni = reader.GetInt32(reader.GetOrdinal("dni"));
                string nombre = reader.GetString(reader.GetOrdinal("nombre"));
                string apellido = reader.GetString(reader.GetOrdinal("apellido"));

                this.VendedorId = Usuario_controller.ObtenerIdUsuarioPorNombre(TBUsuarioLogin.Text);
                Sesion.UsuarioActualId = this.VendedorId;
                this.VendedorDni = dni;
                this.VendedorNombre = $"{nombre} {apellido}";

                //Perfil
                this.IdPerfil = idPerfil;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (SqlException ex)
            {
                MessageBox.Show(
                    $"Error al conectar a la base de datos:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TBUsuarioLogin_TextChanged(object sender, EventArgs e)
        {

        }

        // Maneja la acción de cancelar en el formulario de inicio de sesión: solicita confirmación al usuario antes de cerrar el formulario.
        // Si el usuario acepta, se establece el resultado como `Cancel`, permitiendo al formulario principal detectar que el login fue abortado.
        private void BCancelar_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show("¿Seguro que deseas salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (resp == DialogResult.Yes) this.DialogResult = DialogResult.Cancel;
        }

        private void btnOcultarContrasenia_Click(object sender, EventArgs e)
        {

        }

        // Restringe la entrada del TextBox a solo letras, espacios y teclas de control: bloquea números, símbolos y caracteres especiales para
        // asegurar que el campo (como el nombre de usuario) contenga únicamente texto alfabético.
        private void TextBox_OnlyLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            bool esControl = char.IsControl(e.KeyChar);
            bool esLetra = char.IsLetter(e.KeyChar);
            bool esEspacio = e.KeyChar == ' ';

            if (!esControl && !esLetra && !esEspacio)
                e.Handled = true;
        }

        // Alterna la visibilidad del campo de contraseña según el estado del checkbox: si está marcado, muestra el texto plano; si no,
        // lo oculta con caracteres seguros.
        private void cbOcultarContraseniaLoginUser_CheckedChanged(object sender, EventArgs e)
        {
            TBContraseniaLogin.UseSystemPasswordChar = !cbOcultarContraseniaLoginUser.Checked;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
