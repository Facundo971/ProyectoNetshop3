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
    public partial class FRegistrarCliente : Form
    {
        public FRegistrarCliente()
        {
            InitializeComponent();

            this.Load += FRegistrarCliente_Load;

            tbTelefono.KeyPress -= tbTelefono_KeyPress;
            tbDNI.KeyPress -= tbDNI_KeyPress;
            tbNombre.KeyPress -= tbNombre_KeyPress;
            tbApellido.KeyPress -= tbApellido_KeyPress;

            tbTelefono.KeyPress += tbTelefono_KeyPress;
            tbDNI.KeyPress += tbDNI_KeyPress;
            tbNombre.KeyPress += tbNombre_KeyPress;
            tbApellido.KeyPress += tbApellido_KeyPress;

            tbNombre.TextChanged += InputFields_Changed;
            tbApellido.TextChanged += InputFields_Changed;
            tbDNI.TextChanged += InputFields_Changed;
            tbEmail.TextChanged += InputFields_Changed;
            tbTelefono.TextChanged += InputFields_Changed;
            rbMasculino.CheckedChanged += InputFields_Changed;
            rbFemenino.CheckedChanged += InputFields_Changed;
            rbOtros.CheckedChanged += InputFields_Changed;
            fechaNacimiento.ValueChanged += InputFields_Changed;
            fechaNacimiento.MouseClick += InputFields_Changed;

            tbBusquedaDniCliente.KeyPress -= tbBusquedaDniCliente_KeyPress;
            tbBusquedaNombreCliente.KeyPress -= tbBusquedaNombreCliente_KeyPress;

            tbBusquedaDniCliente.KeyPress += tbBusquedaDniCliente_KeyPress;
            tbBusquedaNombreCliente.KeyPress += tbBusquedaNombreCliente_KeyPress;
        }

        private void tbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsLetter(e.KeyChar)
                && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                 && !char.IsLetter(e.KeyChar)
                 && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FRegistrarCliente_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;

            // Máximo de dígitos
            tbDNI.MaxLength = 8;
            tbTelefono.MaxLength = 10;

            fechaNacimiento.ShowCheckBox = true;
            fechaNacimiento.Checked = false;
            fechaNacimiento.Value = DateTime.Today;

            dgvClientes.Rows.Clear();

            // Agregamos una fila de ejemplo:
            dgvClientes.Rows.Add("1", "Juan", "Pérez", "12345678", "5550123456", "juan.perez@correo.com", "Masculino", DateTime.Today.AddYears(-30).ToShortDateString(), "1");
            dgvClientes.Rows.Add("2", "Maria", "Pérez", "12244678", "1110123456", "maria.perez@correo.com", "Femenino", DateTime.Today.AddYears(-30).ToShortDateString(), "1");
            dgvClientes.Rows.Add("3", "Ramon", "Pérez", "22344677", "2155012344", "ramon.perez@correo.com", "Otros", DateTime.Today.AddYears(-30).ToShortDateString(), "1");
        }
        private void InputFields_Changed(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void validarCampos()
        {
            btnGuardar.Enabled = 
                !string.IsNullOrWhiteSpace(tbNombre.Text) &&
                !string.IsNullOrWhiteSpace(tbApellido.Text) &&
                ValidarDNI() && 
                ValidarEmail() &&
                ValidarTelefono() && 
                (rbMasculino.Checked || rbFemenino.Checked || rbOtros.Checked) &&
                ValidarFechaNacimiento();
        }

        private bool ValidarDNI()
        {
            return tbDNI.Text.Length >= 8;
        }

        private bool ValidarEmail()
        {
            if (string.IsNullOrWhiteSpace(tbEmail.Text))
                return false;

            return Regex.IsMatch(
                tbEmail.Text,
                @"^[^@\s]+@[^@\s]+\.com$",
                RegexOptions.IgnoreCase);
        }

        private bool ValidarTelefono()
        {
            return string.IsNullOrWhiteSpace(tbTelefono.Text) || tbTelefono.Text.Length >= 10;
        }

        private bool ValidarFechaNacimiento()
        {
            if (!fechaNacimiento.Checked)
                return true;

            DateTime hoy = DateTime.Today;
            DateTime fn = fechaNacimiento.Value.Date;
            if (fn > hoy)
                return false;

            int edad = hoy.Year - fn.Year;
            if (fn > hoy.AddYears(-edad))
                edad--;

            return edad >= 18 && edad <= 100;
        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbApellido_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void tbDNI_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbTelefono_TextChanged(object sender, EventArgs e)
        {

        }

        private void fechaNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }

        private void rbMasculino_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbFemenino_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rbOtros_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cliente registrado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            tbNombre.Text = "";
            tbApellido.Text = "";
            tbDNI.Text = "";
            tbEmail.Text = "";
            tbTelefono.Text = "";
            rbMasculino.Checked = false;
            rbFemenino.Checked = false;
            rbOtros.Checked = true;
            fechaNacimiento.Value = DateTime.Today;

            btnGuardar.Enabled = false;
        }

        private void tbBusquedaDniCliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbBusquedaDniCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Sólo se permiten números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbBusquedaNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsLetter(e.KeyChar)
                && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Sólo se permiten letras.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
