using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ProyectoNetshop.formularios
{
    public partial class ventas : Form
    {
        private readonly int vendedorDni;
        private readonly string vendedorNombre;

        public ventas(int p_dni, string p_nombre)
        {
            InitializeComponent();

            vendedorDni = p_dni;
            vendedorNombre = p_nombre;

            this.Load += ventas_Load;

            tbDniClienteVenta.KeyPress += TextBox_OnlyDigits_KeyPress;
            tbNombreClienteVenta.KeyPress += TextBox_OnlyLetters_KeyPress;
            ibBotonBuscarClienteVenta.Click += IbBotonBuscarClienteVenta_Click;

            tbNombreProductoVenta.KeyPress += TextBox_OnlyLetters_KeyPress;
            //tbDescripcionProductoVenta.KeyPress += TextBox_OnlyLetters_KeyPress;
            tbStockProductoVenta.KeyPress += TextBox_OnlyDigits_KeyPress;
            tbPrecioVtaProductoVenta.KeyPress += TextBox_OnlyDigits_KeyPress;
            tbCantidadProductoVenta.KeyPress += TextBox_OnlyDigits_KeyPress;

            ibBotonBuscarProductoVenta.Click += IbBotonBuscarProductoVenta_Click;
            ibBotonAgregarProductoVenta.Click += IbBotonAgregarProductoVenta_Click;

            ibBotonAgregarProductoVenta.Enabled = false;

            dtpFechaVenta.ShowCheckBox = true;

            ibBotonGuardarVenta.Click -= ibBotonGuardarVenta_Click;
            ibBotonGuardarVenta.Click += ibBotonGuardarVenta_Click;
            ibBotonBorrarVenta.Click += ibBotonBorrarVenta_Click;
        }

        private void TextBox_OnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void TextBox_OnlyLetters_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar)
                && !char.IsLetter(e.KeyChar)
                && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void IbBotonBuscarClienteVenta_Click(object sender, EventArgs e)
        {
            string dniText = tbDniClienteVenta.Text.Trim();
            string nombreTxt = tbNombreClienteVenta.Text.Trim();

            if (string.IsNullOrWhiteSpace(dniText) || string.IsNullOrWhiteSpace(nombreTxt))
            {
                MessageBox.Show("Debe ingresar el DNI y el nombre del cliente para buscar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                if (string.IsNullOrWhiteSpace(dniText))
                    tbDniClienteVenta.Focus();
                else
                    tbNombreClienteVenta.Focus();

                return;
            }

            if (!Regex.IsMatch(dniText, @"^\d{8}$"))
            {
                MessageBox.Show("El DNI debe contener exactamente 8 dígitos numéricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbDniClienteVenta.Focus();
                return;
            }

            if (Regex.IsMatch(nombreTxt, @"\d"))
            {
                MessageBox.Show("El nombre no puede contener dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNombreClienteVenta.Focus();
                return;
            }

            MessageBox.Show("Datos válidos. Iniciando búsqueda del cliente…", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {

        }

        private void ventas_Load(object sender, EventArgs e)
        {
            tbDniVendedorVenta.Text = vendedorDni.ToString();
            tbNombreVendedorVenta.Text = vendedorNombre;

            // Marcar como solo lectura para evitar edición
            tbDniVendedorVenta.ReadOnly = true;
            tbNombreVendedorVenta.ReadOnly = true;

            // Limpiamos cualquier fila previa
            dgvVentas.Rows.Clear();

            // Agregamos una fila de ejemplo:
            dgvVentas.Rows.Add("Dell Inspiron 15", "Notebook 15.6'' i5 8GB RAM", 2, 350000, 700000, "22/09/2025");
            dgvVentas.Rows.Add("Lenovo IdeaPad 3", "Notebook 14'' Ryzen 5 16GB", 1, 420000, 420000, "22/09/2025");
            dgvVentas.Rows.Add("HP Pavilion x360", "Convertible Touch 13'' i7", 3, 480000, 1440000, "22/09/2025");
        }

        private void IbBotonBuscarProductoVenta_Click(object sender, EventArgs e)
        {
            string nombreProd = tbNombreProductoVenta.Text.Trim();
            //string descripcion = tbDescripcionProductoVenta.Text.Trim();
            string stockText = tbStockProductoVenta.Text.Trim();
            string precioText = tbPrecioVtaProductoVenta.Text.Trim();
            string cantidadText = tbCantidadProductoVenta.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombreProd))
            {
                MessageBox.Show("El nombre del producto no puede quedar vacío.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNombreProductoVenta.Focus();
                return;
            }

            //if (string.IsNullOrWhiteSpace(descripcion))
            //{
            //    MessageBox.Show("La descripción del producto no puede quedar vacía.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    tbDescripcionProductoVenta.Focus();
            //    return;
            //}

            if (string.IsNullOrWhiteSpace(stockText))
            {
                MessageBox.Show("Debe ingresar el stock del producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbStockProductoVenta.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(precioText))
            {
                MessageBox.Show("Debe ingresar el precio de venta del producto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPrecioVtaProductoVenta.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(cantidadText))
            {
                MessageBox.Show("Debe ingresar la cantidad a vender.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCantidadProductoVenta.Focus();
                return;
            }

            if (!int.TryParse(stockText, out int stock) || stock < 0)
            {
                MessageBox.Show("El stock debe ser un número entero no negativo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbStockProductoVenta.Focus();
                return;
            }
            if (!decimal.TryParse(precioText, out decimal precio) || precio < 0)
            {
                MessageBox.Show("El precio debe ser un número no negativo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPrecioVtaProductoVenta.Focus();
                return;
            }
            if (!int.TryParse(cantidadText, out int cantidad) || cantidad < 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero no negativo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCantidadProductoVenta.Focus();
                return;
            }

            if (cantidad > stock)
            {
                MessageBox.Show("La cantidad a vender no puede superar el stock disponible.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbCantidadProductoVenta.Focus();
                return;
            }

            MessageBox.Show("Datos válidos. Ya puede agregar el producto.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ibBotonAgregarProductoVenta.Enabled = true;
        }

        private void IbBotonAgregarProductoVenta_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Producto agregado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ibBotonAgregarProductoVenta.Enabled = false;
        }

        private void ibBotonBuscarClienteVenta_Click(object sender, EventArgs e)
        {

        }

        private void ibBotonGuardarVenta_Click(object sender, EventArgs e)
        {
            if (cbTipoFacturaVenta.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Debe seleccionar un tipo de factura.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (dtpFechaVenta.ShowCheckBox && dtpFechaVenta.Checked)
            {
                DateTime fecha = dtpFechaVenta.Value.Date;
                if (fecha > DateTime.Now.Date)
                {
                    MessageBox.Show("La fecha de venta no puede ser mayor al día de hoy.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            MessageBox.Show("Tipo de factura y fecha válidos. Procediendo a guardar la venta…", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void ibBotonBorrarVenta_Click(object sender, EventArgs e)
        {
            tbDniClienteVenta.Clear();
            tbNombreClienteVenta.Clear();
            tbNombreProductoVenta.Clear();
            //tbDescripcionProductoVenta.Clear();
            tbStockProductoVenta.Clear();
            tbPrecioVtaProductoVenta.Clear();
            tbCantidadProductoVenta.Clear();

            cbTipoFacturaVenta.SelectedIndex = -1;

            dtpFechaVenta.Value = DateTime.Today;
            dtpFechaVenta.Checked = false;
        }

        private void tbPrecioVtaProductoVenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbDescripcionProductoVenta_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
