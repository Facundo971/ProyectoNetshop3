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
        //Vendedor
        private readonly int vendedorDni;
        private readonly string vendedorNombreCompleto;

        private List<(string nroFactura, string nombreProducto, int cantidad, decimal precioUnitario, decimal total)> detallesOriginales;
        private List<(string nroFactura, DateTime fecha, string tipoFactura, decimal totalVenta, string nombreCliente)> cabecerasOriginales;

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

        private void txtFiltroNombreProducto_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) &&
                !char.IsLetterOrDigit(e.KeyChar) &&
                e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

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
