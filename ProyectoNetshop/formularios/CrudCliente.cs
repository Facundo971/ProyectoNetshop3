using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vistaDeProyectoC
{
    public partial class FRegistrarCliente : Form
    {
        public FRegistrarCliente()
        {
            InitializeComponent();
        }

        private void tbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo letras y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void tbApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo letras y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void tbDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite letras, dígitos, espacios y algunos caracteres especiales comunes en direcciones
            if (!char.IsControl(e.KeyChar) && !char.IsLetterOrDigit(e.KeyChar) && e.KeyChar != ' ' && e.KeyChar != ',' && e.KeyChar != '.' && e.KeyChar != '-' && e.KeyChar != '#')
            {
                e.Handled = true;
            }
        }

        private void tbTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbDNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void FRegistrarCliente_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
        }

        private void validarCampos()
        {
            // Habilita el botón Guardar solo si todos los campos obligatorios están llenos
            btnGuardar.Enabled = !string.IsNullOrWhiteSpace(tbNombre.Text) &&
                               !string.IsNullOrWhiteSpace(tbApellido.Text) &&
                               !string.IsNullOrWhiteSpace(tbDNI.Text) &&
                               !string.IsNullOrWhiteSpace(tbEmail.Text) &&
                               !string.IsNullOrWhiteSpace(tbTelefono.Text) &&
                               !string.IsNullOrWhiteSpace(tbDireccion.Text) &&
                               (rbMasculino.Checked || rbFemenino.Checked) &&
                               fechaNacimiento.Value != fechaNacimiento.MinDate;
        }

        // Validaciones de entrada
        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void tbApellido_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void tbDNI_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void tbEmail_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void tbTelefono_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void tbDireccion_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void fechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void rbMasculino_CheckedChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void rbFemenino_CheckedChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            int rowIndex = dgvClientes.Rows.Add();
            dgvClientes.Rows[rowIndex].Cells["colDNI"].Value = tbDNI.Text;
            dgvClientes.Rows[rowIndex].Cells["colNombre"].Value = tbNombre.Text;
            dgvClientes.Rows[rowIndex].Cells["colApellido"].Value = tbApellido.Text;
            dgvClientes.Rows[rowIndex].Cells["colEmail"].Value = tbEmail.Text;
            dgvClientes.Rows[rowIndex].Cells["colTelefono"].Value = tbTelefono.Text;
            dgvClientes.Rows[rowIndex].Cells["colDireccion"].Value = tbDireccion.Text;
            dgvClientes.Rows[rowIndex].Cells["colSexo"].Value = rbMasculino.Checked ? "Masculino" : "Femenino";
            dgvClientes.Rows[rowIndex].Cells["colFechaNacimiento"].Value = fechaNacimiento.Value.ToShortDateString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            //Vacia los campos de entrada
            tbNombre.Text = "";
            tbApellido.Text = "";
            tbDNI.Text = "";
            tbEmail.Text = "";
            tbTelefono.Text = "";
            tbDireccion.Text = "";
            rbMasculino.Checked = false;
            rbFemenino.Checked = false;
            fechaNacimiento.Value = DateTime.Today;

            btnGuardar.Enabled = false;
        }
    }
}
