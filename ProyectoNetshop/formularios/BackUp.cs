using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vistaDeProyectoC
{
    public partial class FBackUp : Form
    {
        public FBackUp()
        {
            InitializeComponent();

            // Estado inicial
            TBBaseDeDatos.Clear();
            TBGuardarRuta.Clear();
            TBGuardarRuta.Enabled = false;
            BConectar.Enabled = false;
            BGuardarRuta.Enabled = false;
            BBackUp.Enabled = false;

            // Un único manejador para ambos TextChanged
            TBBaseDeDatos.TextChanged += Campos_TextChanged;
            TBGuardarRuta.TextChanged += Campos_TextChanged;

            // Clicks
            //BConectar.Click += BConectar_Click;
            //BGuardarRuta.Click += BGuardarRuta_Click;
            //BBackUp.Click += BBackUp_Click;
        }

        private void FBackUp_Load(object sender, EventArgs e)
        {

        }

        private void TBBaseDeDatos_TextChanged(object sender, EventArgs e)
        {

        }

        // Mismo método para actualizar estado de botones
        private void Campos_TextChanged(object sender, EventArgs e)
        {
            BConectar.Enabled = !string.IsNullOrWhiteSpace(TBBaseDeDatos.Text);

            BGuardarRuta.Enabled = TBGuardarRuta.Enabled && !string.IsNullOrWhiteSpace(TBGuardarRuta.Text);

            BBackUp.Enabled = !string.IsNullOrWhiteSpace(TBBaseDeDatos.Text) && !string.IsNullOrWhiteSpace(TBGuardarRuta.Text);
        }

        private void BConectar_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Se conectó a la base de datos '{TBBaseDeDatos.Text}'.", "Conexión exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            TBGuardarRuta.Enabled = true;
            Campos_TextChanged(this, EventArgs.Empty);
        }

        private void TBGuardarRuta_TextChanged(object sender, EventArgs e)
        {

        }

        private void BGuardarRuta_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Ruta guardada: {TBGuardarRuta.Text}", "Ruta válida", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Campos_TextChanged(this, EventArgs.Empty);
        }

        private void BBackUp_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TBBaseDeDatos.Text) || string.IsNullOrWhiteSpace(TBGuardarRuta.Text))
            {
                MessageBox.Show("Debes completar ambos campos antes de continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show(
                "¡Todos los campos están completos! Listo para el BackUp.", "Preparado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
