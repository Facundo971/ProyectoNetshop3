using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoNetshop.BD;


namespace vistaDeProyectoC
{
    public partial class FInicioSesion : Form
    {
        public int IdPerfil { get; private set; }

        public FInicioSesion()
        {
            InitializeComponent();
        }

        private void FInicioSesion_Load(object sender, EventArgs e)
        {

        }

        private void LUsuario_Click(object sender, EventArgs e)
        {

        }

        private void BIngresar_Click(object sender, EventArgs e)
        {
            // 1) Validar campos obligatorios
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

            // 2) Intentar autenticación contra la base
            try
            {
                // 1) Obtener conexión desde tu helper
                using var conexion = BaseDeDatos.obtenerConexion();
                if (conexion.State != ConnectionState.Open)
                    conexion.Open();

                // 2) Preparar comando: filtramos por 'nombre'
                using var cmd = new SqlCommand(@"SELECT pass, activo, id_perfil FROM usuario WHERE nombre = @usuario", conexion);

                // VARCHAR(100) coincide con tu definición de columna nombre
                cmd.Parameters.Add("@usuario", SqlDbType.VarChar, 100).Value = TBUsuarioLogin.Text.Trim();

                // 3) Ejecutar y leer
                using var reader = cmd.ExecuteReader();
                if (!reader.Read())
                {
                    MessageBox.Show("Usuario no encontrado.", "Login fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TBUsuarioLogin.Focus();
                    return;
                }

                // 4) Verificar si la cuenta está activa
                bool activo = reader.GetInt32(reader.GetOrdinal("activo")) == 1;
                int idPerfil = reader.GetInt32(reader.GetOrdinal("id_perfil"));
                if (!activo)
                {
                    MessageBox.Show("La cuenta está inactiva.", "Login fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 5) Comparar la contraseña
                byte[] hashBD = (byte[])reader["pass"];
                byte[] hashIngresado = Encoding.UTF8.GetBytes(TBContraseniaLogin.Text);
                if (!hashBD.SequenceEqual(hashIngresado))
                {
                    MessageBox.Show("Contraseña incorrecta.","Login fallido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    TBContraseniaLogin.Clear();
                    TBContraseniaLogin.Focus();
                    return;
                }
                // Ejemplo: tras reader.Read()
                // reader ya apuntó al registro del usuario

                // 6) Login exitoso: guardamos el idPerfil y cerramos
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

        private void BCancelar_Click(object sender, EventArgs e)
        {
            var resp = MessageBox.Show("¿Seguro que deseas salir?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resp == DialogResult.Yes) this.DialogResult = DialogResult.Cancel;
        }
    }
}
