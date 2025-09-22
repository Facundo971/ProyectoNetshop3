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

        // Nuevo constructor con parámetros
        public ventas(int p_dni, string p_nombre)
        {
            InitializeComponent();

            vendedorDni = p_dni;
            vendedorNombre = p_nombre;

            // Cargar datos del vendedor al iniciarse
            this.Load += ventas_Load;

            // --- Configuración de TextBoxes de cliente ---
            tbDniClienteVenta.KeyPress += TextBox_OnlyDigits_KeyPress;
            tbNombreClienteVenta.KeyPress += TextBox_OnlyLetters_KeyPress;
            ibBotonBuscarClienteVenta.Click += IbBotonBuscarClienteVenta_Click;

            // --- Configuración de TextBoxes de producto ---
            tbNombreProductoVenta.KeyPress += TextBox_OnlyLetters_KeyPress;
            tbDescripcionProductoVenta.KeyPress += TextBox_OnlyLetters_KeyPress;
            tbStockProductoVenta.KeyPress += TextBox_OnlyDigits_KeyPress;
            tbPrecioVtaProductoVenta.KeyPress += TextBox_OnlyDigits_KeyPress;
            tbCantidadProductoVenta.KeyPress += TextBox_OnlyDigits_KeyPress;

            ibBotonBuscarProductoVenta.Click += IbBotonBuscarProductoVenta_Click;
            ibBotonAgregarProductoVenta.Click += IbBotonAgregarProductoVenta_Click;

            // El botón “Agregar producto” queda deshabilitado hasta validación
            ibBotonAgregarProductoVenta.Enabled = false;

            // Hacemos que la fecha sea opcional
            dtpFechaVenta.ShowCheckBox = true;

            // Antes de volver a suscribir, quitamos cualquier suscripción previa
            ibBotonGuardarVenta.Click -= ibBotonGuardarVenta_Click;
            // Ahora sí, suscribimos una sola vez
            ibBotonGuardarVenta.Click += ibBotonGuardarVenta_Click;

            ibBotonBorrarVenta.Click += ibBotonBorrarVenta_Click;
        }

        // Permite únicamente dígitos y teclas de control
        private void TextBox_OnlyDigits_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        // Permite únicamente letras, espacios y teclas de control
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

            // 0) Ambos campos son obligatorios
            if (string.IsNullOrWhiteSpace(dniText)
                || string.IsNullOrWhiteSpace(nombreTxt))
            {
                MessageBox.Show(
                    "Debe ingresar el DNI y el nombre del cliente para buscar.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                // Enfocar el primer campo vacío
                if (string.IsNullOrWhiteSpace(dniText))
                    tbDniClienteVenta.Focus();
                else
                    tbNombreClienteVenta.Focus();

                return;
            }

            // 1) Validar que el DNI tenga exactamente 8 dígitos
            if (!Regex.IsMatch(dniText, @"^\d{8}$"))
            {
                MessageBox.Show(
                    "El DNI debe contener exactamente 8 dígitos numéricos.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbDniClienteVenta.Focus();
                return;
            }

            // 2) Validar que el nombre no contenga números
            if (Regex.IsMatch(nombreTxt, @"\d"))
            {
                MessageBox.Show(
                    "El nombre no puede contener dígitos.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbNombreClienteVenta.Focus();
                return;
            }

            // 3) Si llegamos hasta aquí, todo pasó
            MessageBox.Show(
                "Datos válidos. Iniciando búsqueda del cliente…",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
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
            // Asumiendo que tus TextBox se llaman así:
            tbDniVendedorVenta.Text = vendedorDni.ToString();
            tbNombreVendedorVenta.Text = vendedorNombre;

            // Marcar como solo lectura para evitar edición
            tbDniVendedorVenta.ReadOnly = true;
            tbNombreVendedorVenta.ReadOnly = true;
        }

        // Validaciones de producto + habilitar botón “Agregar”
        private void IbBotonBuscarProductoVenta_Click(object sender, EventArgs e)
        {
            string nombreProd = tbNombreProductoVenta.Text.Trim();
            string descripcion = tbDescripcionProductoVenta.Text.Trim();
            string stockText = tbStockProductoVenta.Text.Trim();
            string precioText = tbPrecioVtaProductoVenta.Text.Trim();
            string cantidadText = tbCantidadProductoVenta.Text.Trim();

            // Nombre y descripción no vacíos
            if (string.IsNullOrWhiteSpace(nombreProd))
            {
                MessageBox.Show(
                    "El nombre del producto no puede quedar vacío.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbNombreProductoVenta.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show(
                    "La descripción del producto no puede quedar vacía.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbDescripcionProductoVenta.Focus();
                return;
            }

            // Campos numéricos no vacíos
            if (string.IsNullOrWhiteSpace(stockText))
            {
                MessageBox.Show(
                    "Debe ingresar el stock del producto.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbStockProductoVenta.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(precioText))
            {
                MessageBox.Show(
                    "Debe ingresar el precio de venta del producto.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbPrecioVtaProductoVenta.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(cantidadText))
            {
                MessageBox.Show(
                    "Debe ingresar la cantidad a vender.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbCantidadProductoVenta.Focus();
                return;
            }

            // Parseo y no negativos
            if (!int.TryParse(stockText, out int stock) || stock < 0)
            {
                MessageBox.Show(
                    "El stock debe ser un número entero no negativo.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbStockProductoVenta.Focus();
                return;
            }
            if (!decimal.TryParse(precioText, out decimal precio) || precio < 0)
            {
                MessageBox.Show(
                    "El precio debe ser un número no negativo.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbPrecioVtaProductoVenta.Focus();
                return;
            }
            if (!int.TryParse(cantidadText, out int cantidad) || cantidad < 0)
            {
                MessageBox.Show(
                    "La cantidad debe ser un número entero no negativo.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbCantidadProductoVenta.Focus();
                return;
            }

            // Cantidad no mayor que stock
            if (cantidad > stock)
            {
                MessageBox.Show(
                    "La cantidad a vender no puede superar el stock disponible.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                tbCantidadProductoVenta.Focus();
                return;
            }

            // Todo OK: habilitar “Agregar” y mostrar mensaje
            MessageBox.Show(
                "Datos válidos. Ya puede agregar el producto.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            ibBotonAgregarProductoVenta.Enabled = true;
        }

        // Al pulsar “Agregar producto” solo muestro mensaje de confirmación
        private void IbBotonAgregarProductoVenta_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Producto agregado correctamente.",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Si quieres, vuelves a deshabilitar el botón
            ibBotonAgregarProductoVenta.Enabled = false;
        }

        private void ibBotonBuscarClienteVenta_Click(object sender, EventArgs e)
        {

        }

        private void ibBotonGuardarVenta_Click(object sender, EventArgs e)
        {
            // 1) Validar que el tipo de factura esté seleccionado
            if (cbTipoFacturaVenta.SelectedIndex < 0)
            {
                MessageBox.Show(
                    "Debe seleccionar un tipo de factura.",
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 2) Si el usuario marcó la casilla de fecha, comprobamos que no sea futura
            if (dtpFechaVenta.ShowCheckBox && dtpFechaVenta.Checked)
            {
                DateTime fecha = dtpFechaVenta.Value.Date;
                if (fecha > DateTime.Now.Date)
                {
                    MessageBox.Show(
                        "La fecha de venta no puede ser mayor al día de hoy.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }
            }

            // 3) Todo OK: mostramos mensaje de éxito y ejecutamos la lógica de guardado
            MessageBox.Show(
                "Tipo de factura y fecha válidos. Procediendo a guardar la venta…",
                "Información",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Aquí va tu código real para guardar la venta
        }

        private void ibBotonBorrarVenta_Click(object sender, EventArgs e)
        {
            // Limpiar datos de cliente
            tbDniClienteVenta.Clear();
            tbNombreClienteVenta.Clear();

            // Limpiar datos de producto
            tbNombreProductoVenta.Clear();
            tbDescripcionProductoVenta.Clear();
            tbStockProductoVenta.Clear();
            tbPrecioVtaProductoVenta.Clear();
            tbCantidadProductoVenta.Clear();

            // Restablecer ComboBox
            cbTipoFacturaVenta.SelectedIndex = -1;

            // Restablecer DateTimePicker
            // (si usas ShowCheckBox para hacer la fecha opcional)
            dtpFechaVenta.Value = DateTime.Today;
            dtpFechaVenta.Checked = false;
        }
    }
}
