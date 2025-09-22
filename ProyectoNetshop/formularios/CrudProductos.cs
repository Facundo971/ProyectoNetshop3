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
                    pbProducto.SizeMode = PictureBoxSizeMode.StretchImage; // Opcional: ajusta la imagen al tamaño del PictureBox
                    validarCampos();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Crea una fila con los datos
            //int rowIndex = dgvProductos.Rows.Add();
            //dgvProductos.Rows[rowIndex].Cells["colIdProducto"].Value = tbiDProducto.Text;
            //dgvProductos.Rows[rowIndex].Cells["colNombre"].Value = tbNombre.Text;
            //dgvProductos.Rows[rowIndex].Cells["colPrecio"].Value = tbPrecio.Text;
            //dgvProductos.Rows[rowIndex].Cells["colPrecioVenta"].Value = tbPrecioVenta.Text;
            //dgvProductos.Rows[rowIndex].Cells["colDescripcion"].Value = tbDescripcion.Text;
            //dgvProductos.Rows[rowIndex].Cells["colStock"].Value = tbStock.Text;
            //dgvProductos.Rows[rowIndex].Cells["colCategoria"].Value = cbCategoria.SelectedItem?.ToString();
            //dgvProductos.Rows[rowIndex].Cells["colImagen"].Value = pbProducto.Image;
            //dgvProductos.Rows[rowIndex].Cells["colMarca"].Value = cbMarca.SelectedItem?.ToString();

            // 4) Mostrar mensaje de éxito
            MessageBox.Show(
                "Producto agregado con éxito.",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        // Validaciones de entrada

        private void tbNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo letras y teclas de control
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
                MessageBox.Show(
                    "Solo se permiten letras en la descripción.",
                    "Carácter no permitido",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }
        }

        private void tbPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos, el punto decimal y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números y un punto.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Permite solo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números y un punto.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void tbPrecioVenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos, el punto decimal y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números y un punto.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            // Permite solo un punto decimal
            if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números y un punto.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void tbiDProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permite solo dígitos y teclas de control
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Solo se permiten números.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CrudProductos_Load(object sender, EventArgs e)
        {
            btnGuardar.Enabled = false;
        }

        private void validarCampos()
        {
            // 1) Validación de campos obligatorios “base”
            bool baseValida =
                   !string.IsNullOrWhiteSpace(tbNombre.Text)
                && !string.IsNullOrWhiteSpace(tbPrecio.Text)
                && !string.IsNullOrWhiteSpace(tbPrecioVenta.Text)
                && !string.IsNullOrWhiteSpace(tbStock.Text)
                && cbMarca.SelectedItem != null
                && cbCategoria.SelectedItem != null
                && pbProducto.Image != null;

            if (!baseValida)
            {
                btnGuardar.Enabled = false;
                return;
            }

            // 2) Intentar parsear a decimal usando InvariantCulture (punto decimal)
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

            // 3) Comparar precios sólo si ambos parsearon correctamente
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
            // Vacia los campos de entrada
            tbNombre.Text = "";
            tbPrecio.Text = "";
            tbPrecioVenta.Text = "";
            tbDescripcion.Text = "";
            tbStock.Text = "";
            cbMarca.SelectedIndex = -1;
            cbCategoria.SelectedIndex = -1;
            //pbProducto.Image = null;
            btnGuardar.Enabled = false;
        }

        private void cbActivos_CheckedChanged(object sender, EventArgs e)
        {

        }

        //private void tbBusquedaDniUsuario_TextChanged(object sender, EventArgs e)
        //{
        //    // Permite solo dígitos, el punto decimal y teclas de control
        //    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
        //    {
        //        e.Handled = true;
        //        MessageBox.Show("Solo se permiten números y un punto.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //    // Permite solo un punto decimal
        //    if (e.KeyChar == '.' && (sender as TextBox).Text.Contains("."))
        //    {
        //        e.Handled = true;
        //        MessageBox.Show("Solo se permiten números y un punto.", "Carácter no permitido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}
    }
}

