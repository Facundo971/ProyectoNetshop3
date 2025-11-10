// Importa librerías.
using ProyectoNetshop.Cruds;
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
    public partial class DetalleFactura : Form
    {
        // Vendedor
        private readonly int vendedorDni;
        private readonly string vendedorNombreCompleto;

        // Datos originales para filtros
        private List<(string nroFactura, string nombreProducto, int cantidad, decimal precioUnitario, decimal total)> detallesOriginales;
        private List<(string nroFactura, DateTime fecha, string tipoFactura, decimal totalVenta, string nombreCliente)> cabecerasOriginales;

        // Constructor del formulario de detalle de factura: inicializa componentes, configura validaciones de entrada para filtros (nombre y precios), y
        // enlaza eventos `TextChanged` para aplicar filtros dinámicos en tiempo real.
        // También recibe y almacena los datos del vendedor (DNI y nombre completo) para contextualizar la visualización.
        public DetalleFactura(int p_dni, string p_nombre)
        {
            InitializeComponent();

            tbBusquedaNombreProductoDF.KeyPress += txtFiltroNombreProducto_KeyPress;
            tbBusquedaPrecioMinProductoDF.KeyPress += txtFiltroPrecio_KeyPress;
            tbBusquedaPrecioMaxProductoDF.KeyPress += txtFiltroPrecio_KeyPress;

            //Vendedor
            vendedorDni = p_dni;
            vendedorNombreCompleto = p_nombre;

            tbBusquedaNombreProductoDF.TextChanged += (s, e) => AplicarFiltrosDetalleFactura();
            tbBusquedaNroFProductoDF.TextChanged += (s, e) => AplicarFiltrosDetalleFactura();
            tbBusquedaPrecioMinProductoDF.TextChanged += (s, e) => AplicarFiltrosDetalleFactura();
            tbBusquedaPrecioMaxProductoDF.TextChanged += (s, e) => AplicarFiltrosDetalleFactura();
        }

        // Restringe la entrada del filtro de nombre de producto: permite solo letras, números, espacios y teclas de control.
        // Bloquea símbolos y caracteres especiales para mantener la coherencia en la búsqueda textual.
        private void txtFiltroNombreProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsLetterOrDigit(e.KeyChar) &&
                e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        // Restringe la entrada en los campos de filtro de precio: permite solo dígitos y teclas de control (como borrar o tab).
        // Bloquea letras, símbolos y decimales para asegurar que el valor ingresado sea numérico entero.
        private void txtFiltroPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void lbTotalDetalleFactura_Click(object sender, EventArgs e)
        {

        }

        // Evento de carga del formulario de detalle de factura: asigna los datos del vendedor (DNI y nombre completo) a los campos correspondientes y
        // los bloquea para evitar edición. Luego invoca los métodos que muestran los detalles y cabeceras de facturas no canceladas asociadas al vendedor.
        private void DetalleFactura_Load(object sender, EventArgs e)
        {
            //Vendedor
            tbDniVendedorDetalleFactura.Text = vendedorDni.ToString();
            tbNombreVendedorDetalleFactura.Text = vendedorNombreCompleto;

            // Marcar como solo lectura para evitar edición (Vendedor)
            tbDniVendedorDetalleFactura.ReadOnly = true;
            tbNombreVendedorDetalleFactura.ReadOnly = true;

            MostrarDetallesDelVendedor();
            MostrarCabecerasDelVendedor();
        }

        // Muestra las cabeceras de facturas no canceladas asociadas al vendedor: configura el `DataGridView` con columnas personalizadas,
        // consulta los datos desde el controlador, y los carga en la grilla con formato regional argentino.
        // Calcula el total acumulado de ventas por factura y lo muestra en un label.
        private void MostrarCabecerasDelVendedor()
        {
            dgvVentaCabeceraFactura.Columns.Clear();
            dgvVentaCabeceraFactura.Rows.Clear();

            dgvVentaCabeceraFactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvVentaCabeceraFactura.AllowUserToAddRows = false;
            dgvVentaCabeceraFactura.ReadOnly = true;

            dgvVentaCabeceraFactura.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            dgvVentaCabeceraFactura.Columns.Add("colNroFactura", "Nro Factura");
            dgvVentaCabeceraFactura.Columns.Add("colFecha", "Fecha");
            dgvVentaCabeceraFactura.Columns.Add("colTipo", "Tipo Factura");
            dgvVentaCabeceraFactura.Columns.Add("colTotal", "Total");
            dgvVentaCabeceraFactura.Columns.Add("colCliente", "Cliente");

            cabecerasOriginales = Venta_controller.ObtenerCabecerasPorVendedorNoCanceladas(vendedorDni);

            decimal totalCabeceras = 0;
            var culturaAR = new CultureInfo("es-AR");

            foreach (var c in cabecerasOriginales)
            {
                dgvVentaCabeceraFactura.Rows.Add(
                    c.nroFactura,
                    c.fecha.ToString("dd/MM/yyyy"),
                    c.tipoFactura,
                    c.totalVenta.ToString("C", culturaAR),
                    c.nombreCliente
                );

                totalCabeceras += c.totalVenta;
            }

            // Mostrar total acumulado en el label
            lbTotalVendidoCabeceraFactura.Text = totalCabeceras.ToString("C", culturaAR);
        }

        // Muestra los detalles de facturas no canceladas del vendedor actual: configura el `DataGridView` con columnas personalizadas,
        // consulta los datos desde el controlador y los carga en la grilla con formato monetario argentino.
        // Calcula el total vendido sumando los importes por producto y lo muestra en el label correspondiente.
        public void MostrarDetallesDelVendedor()
        {
            dgvDetalleFactura.Columns.Clear();
            dgvDetalleFactura.Rows.Clear();

            dgvDetalleFactura.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDetalleFactura.AllowUserToAddRows = false;
            dgvDetalleFactura.ReadOnly = true;

            // Encabezados en negrita
            dgvDetalleFactura.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            dgvDetalleFactura.Columns.Add("colFactura", "Nro Factura");
            dgvDetalleFactura.Columns.Add("colProducto", "Producto");
            dgvDetalleFactura.Columns.Add("colCantidad", "Cantidad");
            dgvDetalleFactura.Columns.Add("colPrecio", "Precio Unitario");
            dgvDetalleFactura.Columns.Add("colTotal", "Total");

            // Guardar datos originales para aplicar filtros
            detallesOriginales = Venta_controller.ObtenerDetallesPorVendedorNoCancelados(vendedorDni);

            decimal totalVendido = 0;
            CultureInfo culturaAR = new CultureInfo("es-AR");

            foreach (var d in detallesOriginales)
            {
                dgvDetalleFactura.Rows.Add(
                    d.nroFactura,
                    d.nombreProducto,
                    d.cantidad,
                    d.precioUnitario.ToString("C", culturaAR),
                    d.total.ToString("C", culturaAR)
                );

                totalVendido += d.total;
            }

            // Mostrar total acumulado en el label
            lbTotalVendidoDetalleFactura.Text = totalVendido.ToString("C", culturaAR);
        }

        // Aplica filtros dinámicos sobre los detalles y cabeceras de facturas del vendedor: evalúa coincidencias por nombre de producto,
        // número de factura y rango de precios. Actualiza ambas grillas (`dgvDetalleFactura` y `dgvVentaCabeceraFactura`) con los resultados filtrados y
        // recalcula los totales correspondientes.
        private void AplicarFiltrosDetalleFactura()
        {
            string filtroNombre = tbBusquedaNombreProductoDF.Text.Trim().ToLower();
            string filtroFactura = tbBusquedaNroFProductoDF.Text.Trim().ToLower();
            string filtroMin = tbBusquedaPrecioMinProductoDF.Text.Trim();
            string filtroMax = tbBusquedaPrecioMaxProductoDF.Text.Trim();

            decimal? precioMin = decimal.TryParse(filtroMin, out var min) ? min : (decimal?)null;
            decimal? precioMax = decimal.TryParse(filtroMax, out var max) ? max : (decimal?)null;

            var culturaAR = new CultureInfo("es-AR");

            var filtrados = detallesOriginales.Where(d =>
                d.nombreProducto.ToLower().Contains(filtroNombre) &&
                d.nroFactura.ToLower().Contains(filtroFactura) &&
                (!precioMin.HasValue || d.precioUnitario >= precioMin.Value) &&
                (!precioMax.HasValue || d.precioUnitario <= precioMax.Value)
            ).ToList();

            dgvDetalleFactura.Rows.Clear();
            decimal totalFiltrado = 0;

            foreach (var d in filtrados)
            {
                dgvDetalleFactura.Rows.Add(
                    d.nroFactura,
                    d.nombreProducto,
                    d.cantidad,
                    d.precioUnitario.ToString("C", culturaAR),
                    d.total.ToString("C", culturaAR)
                );

                totalFiltrado += d.total;
            }

            lbTotalVendidoDetalleFactura.Text = totalFiltrado.ToString("C", culturaAR);

            var cabecerasFiltradas = cabecerasOriginales
                .Where(c => c.nroFactura.ToLower().Contains(filtroFactura))
                .ToList();

            dgvVentaCabeceraFactura.Rows.Clear();
            decimal totalCabecerasFiltradas = 0;

            foreach (var c in cabecerasFiltradas)
            {
                dgvVentaCabeceraFactura.Rows.Add(
                    c.nroFactura,
                    c.fecha.ToString("dd/MM/yyyy"),
                    c.tipoFactura,
                    c.totalVenta.ToString("C", culturaAR),
                    c.nombreCliente
                );

                totalCabecerasFiltradas += c.totalVenta;
            }

            lbTotalVendidoCabeceraFactura.Text = totalCabecerasFiltradas.ToString("C", culturaAR);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbBusquedaNombreProductoDF_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
