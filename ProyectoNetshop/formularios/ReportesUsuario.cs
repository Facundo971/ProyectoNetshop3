using ProyectoNetshop.Cruds;
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
    public partial class FReporteUsuario : Form
    {
        public FReporteUsuario()
        {
            InitializeComponent();

            // Asegurarte de no duplicar la suscripción
            BGenerarReporteUsuario.Click -= BGenerarReporteUsuario_Click;
            BGenerarReporteUsuario.Click += BGenerarReporteUsuario_Click;
        }

        private void LReporteDeUsuarios_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FReporteUsuario_Load(object sender, EventArgs e)
        {
            dgvReporteUsuarios.Visible = false;
        }

        private void BGenerarReporteUsuario_Click(object sender, EventArgs e)
        {
            // 1) Hacer visible el grid
            dgvReporteUsuarios.Visible = true;

            // 2) Definir columnas si aún no existen
            //if (dgvReporteUsuarios.Columns.Count == 0)
            //{
            //    dgvReporteUsuarios.Columns.Add("colId", "ID Cliente");
            //    dgvReporteUsuarios.Columns.Add("colNombre", "Nombre");
            //    dgvReporteUsuarios.Columns.Add("colApellido", "Apellido");
            //    dgvReporteUsuarios.Columns.Add("colEmail", "Email");
            //    dgvReporteUsuarios.Columns.Add("colDni", "DNI");
            //    dgvReporteUsuarios.Columns.Add("colTelefono", "Teléfono");
            //    dgvReporteUsuarios.Columns.Add("colSexo", "Sexo");
            //    dgvReporteUsuarios.Columns.Add("colFecha", "Fecha Nacimiento");
            //    dgvReporteUsuarios.Columns.Add("colPerfil", "Perfil");
            //    dgvReporteUsuarios.Columns.Add("colActivo", "Activo");
            //}

            // 3) Limpiar filas y agregar ejemplos
            dgvReporteUsuarios.Rows.Clear();
            dgvReporteUsuarios.Rows.Add("1", "Juan", "Pérez", "juan.perez@correo.com", "12345678", "5550123456", "Masculino", DateTime.Today.AddYears(-30).ToShortDateString(), "Administrador", "SI");
            dgvReporteUsuarios.Rows.Add("2", "María", "Gómez", "maria.gomez@correo.com", "87654321", "6660123456", "Femenino", DateTime.Today.AddYears(-25).ToShortDateString(), "Vendedor", "SI");
            dgvReporteUsuarios.Rows.Add("3", "Ramón", "López", "ramon.lopez@correo.com", "23456789", "", "Otros", DateTime.Today.AddYears(-40).ToShortDateString(), "Gerente", "SI");

            // 4) Feedback
            MessageBox.Show(
                "Usuarios cargados con éxito.",
                "Reporte de Usuarios",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }


        //private List<Usuario_model> ObtenerUsuarios()
        //{
        //    var lista = new List<Usuario_model>();

        //    using var con = BaseDeDatos.obtenerConexion();
        //    using var cmd = con.CreateCommand();
        //    cmd.CommandText = @"
        //    SELECT id_usuario, nombre, apellido, email, pass, activo,
        //           sexo, fecha_nacimiento, telefono, dni, id_perfil
        //    FROM usuario";

        //    using var rd = cmd.ExecuteReader();
        //    while (rd.Read())
        //    {
        //        DateTime? fn = rd.IsDBNull(7)
        //            ? (DateTime?)null
        //            : rd.GetDateTime(7);

        //        int? tel = rd.IsDBNull(8)
        //            ? (int?)null
        //            : rd.GetInt32(8);

        //        lista.Add(new Usuario_model
        //        {
        //            id_usuario = rd.GetInt32(0),
        //            nombre = rd.GetString(1),
        //            apellido = rd.GetString(2),
        //            email = rd.GetString(3),
        //            pass = (byte[])rd["pass"],
        //            activo = rd.GetInt32(5),
        //            sexo = rd.GetString(6),
        //            fecha_nacimiento = fn,
        //            telefono = tel,
        //            dni = rd.GetInt32(9),
        //            id_perfil = rd.GetInt32(10)
        //        });
        //    }

        //    return lista;
        //}
    }
}
