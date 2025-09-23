using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;

namespace ProyectoNetshop.formularios
{
    public partial class CrudProductos : Form
    {
        public CrudProductos()
        {
            InitializeComponent();

            tbDescripcion.KeyPress -= TbDescripcion_KeyPress;
            tbDescripcion.KeyPress += TbDescripcion_KeyPress;
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
                    pbProducto.SizeMode = PictureBoxSizeMode.StretchImage;
                    validarCampos();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Producto agregado con éxito.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        private void tbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void TbDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsLetter(e.KeyChar)
                && e.KeyChar != ' ')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten letras en la descripción.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números y un punto.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números y un punto.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void tbPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números y un punto.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números y un punto.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbiDProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CrudProductos_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;

            dgvProductos.Rows.Clear();

            dgvProductos.Rows.Add(1, "Dell Inspiron 15", "Notebook 15.6'' i5 8GB RAM", 350000, 2, 150000, "Hogar", "HP");
            dgvProductos.Rows.Add(2, "Lenovo IdeaPad 3", "Notebook 14'' Ryzen 5 16GB RAM", 150000, 5, 110000, "Trabajo", "Apple");
            dgvProductos.Rows.Add(3, "HP Pavilion x360", "Convertible Touch 13'' i7 16GB SSD 512GB", 250000, 7, 200000, "Educación", "Lenovo");
        }

        private void validarCampos()
        {
            bool baseValida = !string.IsNullOrWhiteSpace(tbNombre.Text) && 
                              !string.IsNullOrWhiteSpace(tbPrecio.Text) && 
                              !string.IsNullOrWhiteSpace(tbPrecioVenta.Text) && 
                              !string.IsNullOrWhiteSpace(tbStock.Text) && 
                              cbMarca.SelectedItem != null && 
                              cbCategoria.SelectedItem != null && 
                              pbProducto.Image != null;

            if (!baseValida)
            {
                btnGuardar.Enabled = false;
                return;
            }

            bool precioOk = decimal.TryParse(
                               tbPrecio.Text,
                               NumberStyles.Number,
                               CultureInfo.InvariantCulture,
                               out decimal precioOriginal);

            bool ventaOk = decimal.TryParse(
                               tbPrecioVenta.Text,
                               NumberStyles.Number,
                               CultureInfo.InvariantCulture,
                               out decimal precioVenta);

            if (precioOk && ventaOk && precioVenta < precioOriginal)
            {
                btnGuardar.Enabled = true;
            }
            else
            {
                btnGuardar.Enabled = false;
            }
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

        private void tbPrecioVenta_TextChanged(object sender, EventArgs e)
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

        private void cbMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void tbMarca_TextChanged(object sender, EventArgs e)
        {
            validarCampos();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            tbNombre.Text = "";
            tbPrecio.Text = "";
            tbPrecioVenta.Text = "";
            tbDescripcion.Text = "";
            tbStock.Text = "";
            cbMarca.SelectedIndex = -1;
            cbCategoria.SelectedIndex = -1;
            btnGuardar.Enabled = false;
        }

        private void cbActivos_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvProductos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

