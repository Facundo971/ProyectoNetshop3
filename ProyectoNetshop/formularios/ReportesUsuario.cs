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
            dgvReporteUsuarios.Visible = true;
            dgvReporteUsuarios.Rows.Clear();
            dgvReporteUsuarios.Rows.Add("1", "Juan", "Pérez", "juan.perez@correo.com", "12345678", "5550123456", "Masculino", DateTime.Today.AddYears(-30).ToShortDateString(), "Administrador", "SI");
            dgvReporteUsuarios.Rows.Add("2", "María", "Gómez", "maria.gomez@correo.com", "87654321", "6660123456", "Femenino", DateTime.Today.AddYears(-25).ToShortDateString(), "Vendedor", "SI");
            dgvReporteUsuarios.Rows.Add("3", "Ramón", "López", "ramon.lopez@correo.com", "23456789", "", "Otros", DateTime.Today.AddYears(-40).ToShortDateString(), "Gerente", "SI");

            MessageBox.Show("Usuarios cargados con éxito.", "Reporte de Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
