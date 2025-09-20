using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoNetshop.formularios
{
    public partial class CrudProductos : Form
    {
        public CrudProductos()
        {
            InitializeComponent();
        }

        private void btnCargarImg_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Title = "Seleccionar imagen";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbProducto.Image = Image.FromFile(openFileDialog.FileName);
                    pbProducto.SizeMode = PictureBoxSizeMode.StretchImage; // Opcional: ajusta la imagen al tamaño del PictureBox
                    validarCampos();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Crea una fila con los datos
            int rowIndex = dgvProductos.Rows.Add();
            dgvProductos.Rows[rowIndex].Cells["colIdProducto"].Value = tbiDProducto.Text;
            dgvProductos.Rows[rowIndex].Cells["colNombre"].Value = tbNombre.Text;
            dgvProductos.Rows[rowIndex].Cells["colPrecio"].Value = tbPrecio.Text;
            dgvProductos.Rows[rowIndex].Cells["colDescripcion"].Value = tbDescripcion.Text;
            dgvProductos.Rows[rowIndex].Cells["colStock"].Value = tbStock.Text;
            dgvProductos.Rows[rowIndex].Cells["colCategoria"].Value = cbCategoria.SelectedItem?.ToString();
            dgvProductos.Rows[rowIndex].Cells["colImagen"].Value = pbProducto.Image;
            dgvProductos.Rows[rowIndex].Cells["colMarca"].Value = tbMarca.Text;
        }

        // Validaciones de entrada

        private void tbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo letras y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void tbMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo letras y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void tbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos, el punto decimal y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
            // Permite solo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
            }
        }

        private void tbStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tbiDProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CrudProductos_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
        }

        private void validarCampos()
        {
            // Habilita el botón Guardar solo si todos los campos obligatorios están llenos
            btnGuardar.Enabled = !string.IsNullOrWhiteSpace(tbiDProducto.Text) &&
                               !string.IsNullOrWhiteSpace(tbNombre.Text) &&
                               !string.IsNullOrWhiteSpace(tbPrecio.Text) &&
                               !string.IsNullOrWhiteSpace(tbDescripcion.Text) &&
                               !string.IsNullOrWhiteSpace(tbStock.Text) &&
                               !string.IsNullOrWhiteSpace(tbMarca.Text) &&
                               cbCategoria.SelectedItem != null &&
                               pbProducto.Image != null;
        }

        private void tbNombre_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void tbiDProducto_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void tbDescripcion_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void tbPrecio_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void tbStock_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void cbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void tbMarca_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            // Vacia los campos de entrada
            tbiDProducto.Text = "";
            tbNombre.Text = "";
            tbPrecio.Text = "";
            tbDescripcion.Text = "";
            tbStock.Text = "";
            tbMarca.Text = "";
            cbCategoria.SelectedIndex = -1;
            pbProducto.Image = null;

            btnGuardar.Enabled = false;
        }
    }
}

