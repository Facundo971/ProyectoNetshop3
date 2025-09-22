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

            // Suscribir eventos de carga y click
            this.Load += FRegistrarCliente_Load;
            //btnGuardar.Click += btnGuardar_Click;

            // KeyPress para filtrar sólo los caracteres permitidos
            // Elimina cualquier suscripción anterior que haya puesto el Designer
            tbTelefono.KeyPress -= tbTelefono_KeyPress;
            tbDNI.KeyPress -= tbDNI_KeyPress;
            tbNombre.KeyPress -= tbNombre_KeyPress;
            tbApellido.KeyPress -= tbApellido_KeyPress;

            // Ahora suscribe cada evento solo una vez
            tbTelefono.KeyPress += tbTelefono_KeyPress;
            tbDNI.KeyPress += tbDNI_KeyPress;
            tbNombre.KeyPress += tbNombre_KeyPress;
            tbApellido.KeyPress += tbApellido_KeyPress;

            // TextChanged y CheckedChanged para revalidar en cada cambio
            tbNombre.TextChanged += InputFields_Changed;
            tbApellido.TextChanged += InputFields_Changed;
            tbDNI.TextChanged += InputFields_Changed;
            tbEmail.TextChanged += InputFields_Changed;
            tbTelefono.TextChanged += InputFields_Changed;
            rbMasculino.CheckedChanged += InputFields_Changed;
            rbFemenino.CheckedChanged += InputFields_Changed;
            rbOtros.CheckedChanged += InputFields_Changed;
            fechaNacimiento.ValueChanged += InputFields_Changed;
            // Para el checkbox interno si usas ShowCheckBox:
            fechaNacimiento.MouseClick += InputFields_Changed;

            // Quitar suscripciones duplicadas (si las hubiera)
            tbBusquedaDniCliente.KeyPress -= tbBusquedaDniCliente_KeyPress;
            tbBusquedaNombreCliente.KeyPress -= tbBusquedaNombreCliente_KeyPress;

            // Ahora suscribo sólo una vez
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
                MessageBox.Show(
                    "Solo se permiten letras.",
                    "Carácter no permitido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void tbApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                 && !char.IsLetter(e.KeyChar)
                 && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show(
                    "Solo se permiten letras.",
                    "Carácter no permitido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        //private void tbDireccion_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    // Permite letras, dígitos, espacios y algunos caracteres especiales comunes en direcciones
        //    if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != ',' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '#')
        //    {
        //        e.Handled = true;
        //        MessageBox.Show("Solo se permiten letras y números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

        private void tbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show(
                    "Solo se permiten números.",
                    "Carácter no permitido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void tbDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show(
                    "Solo se permiten números.",
                    "Carácter no permitido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void FRegistrarCliente_Load(object sender, EventArgs e)
        {
            //btnGuardar.Enabled = false;
            // Estado inicial
            btnGuardar.Enabled = false;

            // Máximo de dígitos
            tbDNI.MaxLength = 8;
            tbTelefono.MaxLength = 10;

            // Hacer opcional la fecha y dejarla desmarcada
            fechaNacimiento.ShowCheckBox = true;
            fechaNacimiento.Checked = false;
            fechaNacimiento.Value = DateTime.Today;

            // Limpiamos cualquier fila previa
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
            //// Habilita el botón Guardar solo si todos los campos obligatorios están llenos
            //btnGuardar.Enabled = !string.IsNullOrWhiteSpace(tbNombre.Text) &&
            //                   !string.IsNullOrWhiteSpace(tbApellido.Text) &&
            //                   !string.IsNullOrWhiteSpace(tbDNI.Text) &&
            //                   !string.IsNullOrWhiteSpace(tbEmail.Text) &&
            //                   !string.IsNullOrWhiteSpace(tbTelefono.Text) &&
            //                   (rbMasculino.Checked || rbFemenino.Checked || rbOtros.Checked) &&
            //                   fechaNacimiento.Value != fechaNacimiento.MinDate;
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
            // Debe estar completo y tener al menos 8 dígitos
            return tbDNI.Text.Length >= 8;
        }

        private bool ValidarEmail()
        {
            if (string.IsNullOrWhiteSpace(tbEmail.Text))
                return false;

            // Terminación .com y formato básico de email
            return Regex.IsMatch(
                tbEmail.Text,
                @"^[^@\s]+@[^@\s]+\.com$",
                RegexOptions.IgnoreCase);
        }

        private bool ValidarTelefono()
        {
            // Vacío está OK (opcional). Si hay texto, al menos 10 dígitos
            return string.IsNullOrWhiteSpace(tbTelefono.Text)
                   || tbTelefono.Text.Length >= 10;
        }

        private bool ValidarFechaNacimiento()
        {
            // Si no usa fecha (checkbox desmarcado), está OK
            if (!fechaNacimiento.Checked)
                return true;

            DateTime hoy = DateTime.Today;
            DateTime fn = fechaNacimiento.Value.Date;
            if (fn > hoy)
                return false;

            // Calcular edad
            int edad = hoy.Year - fn.Year;
            if (fn > hoy.AddYears(-edad))
                edad--;

            return edad >= 18 && edad <= 100;
        }

        // Validaciones de entrada
        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            //validarCampos();
        }

        private void tbApellido_TextChanged(object sender, EventArgs e)
        {
            //validarCampos();
        }

        private void tbDNI_TextChanged(object sender, EventArgs e)
        {
            //validarCampos();
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            //validarCampos();
        }

        private void tbTelefono_TextChanged(object sender, EventArgs e)
        {
            //validarCampos();
        }

        //private void tbDireccion_TextChanged(object sender, EventArgs e)
        //{
        //    validarCampos();
        //}

        private void fechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            //validarCampos();
        }

        private void rbMasculino_CheckedChanged(object sender, EventArgs e)
        {
            //validarCampos();
        }

        private void rbFemenino_CheckedChanged(object sender, EventArgs e)
        {
            //validarCampos();
        }

        private void rbOtros_CheckedChanged(object sender, EventArgs e)
        {
            //validarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //int rowIndex = dgvClientes.Rows.Add();
            //dgvClientes.Rows[rowIndex].Cells["colDNI"].Value = tbDNI.Text;
            //dgvClientes.Rows[rowIndex].Cells["colNombre"].Value = tbNombre.Text;
            //dgvClientes.Rows[rowIndex].Cells["colApellido"].Value = tbApellido.Text;
            //dgvClientes.Rows[rowIndex].Cells["colEmail"].Value = tbEmail.Text;
            //dgvClientes.Rows[rowIndex].Cells["colTelefono"].Value = tbTelefono.Text;
            //dgvClientes.Rows[rowIndex].Cells["colSexo"].Value = rbMasculino.Checked ? "Masculino" : "Femenino";
            //dgvClientes.Rows[rowIndex].Cells["colFechaNacimiento"].Value = fechaNacimiento.Value.ToShortDateString();

            // Mostrar sólo mensaje de éxito, sin cargar nada
            MessageBox.Show(
                "Cliente registrado con éxito.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Vacia los campos de entrada
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

        // Sólo dígitos y control (backspace, flechas…)
        private void tbBusquedaDniCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show(
                    "Sólo se permiten números.",
                    "Carácter no permitido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        // Sólo letras, espacios y control
        private void tbBusquedaNombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsLetter(e.KeyChar)
                && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show(
                    "Sólo se permiten letras.",
                    "Carácter no permitido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
