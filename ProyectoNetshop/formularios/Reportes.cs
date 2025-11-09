using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfiumViewer;
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
using System.Windows.Forms.DataVisualization.Charting;
using static iTextSharp.text.pdf.events.IndexEvents;

namespace ProyectoNetshop.formularios
{
    public partial class Reportes : Form
    {
        private readonly int idPerfil;
        private int alturaOriginalChecklist = 40;
        private int alturaExpandidaChecklist = 100;
        private Button ultimoBotonPresionado;

        private DataTable tablaOriginalReporteGerente;

        private Panel panelVisorPdf;
        private PdfViewer visorPdf;

        private Chart chartVentas;

        private Label lbTituloGraficoVentas;

        private Label lbProductoMasVendido;


        public Reportes(int p_idPerfil)
        {
            InitializeComponent();

            visorPdf = new PdfViewer { Dock = DockStyle.Fill };
            panelVisorPdf = new Panel
            {
                Name = "panelVisorPdf",
                Dock = DockStyle.Fill,
                Visible = false,
                BackColor = Color.FromArgb(0, 0, 64),
                BorderStyle = BorderStyle.None
            };

            var barra = new Panel
            {
                Size = new Size(panelVisorPdf.Width, 60),
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(0, 0, 64)
            };

            var btnCerrar = new Button
            {
                Text = "Cerrar",
                Size = new Size(120, 40),
                Location = new Point(10, 10),
                BackColor = Color.LightGray,
                Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold),
                Cursor = Cursors.Hand,
                FlatStyle = FlatStyle.Flat
            };
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Click += (s, e) =>
            {
                visorPdf.Document?.Dispose();
                panelVisorPdf.Visible = false;
            };

            barra.Controls.Add(btnCerrar);
            panelVisorPdf.Controls.Add(barra);
            panelVisorPdf.Controls.Add(visorPdf);
            this.Controls.Add(panelVisorPdf);
            panelVisorPdf.BringToFront();

            var clickFilter = new ClickMessageFilter();
            clickFilter.ClickFueraDetectado += (clickeado) =>
            {
                if (clickeado != clbVendedoresReporteGerente)
                {
                    clbVendedoresReporteGerente.Height = alturaOriginalChecklist;
                    clbVendedoresReporteGerente.TopIndex = 0;
                }
            };

            Application.AddMessageFilter(clickFilter);

            chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartVentas.Size = new Size(300, 200);
            chartVentas.Location = new Point(10, 430);
            chartVentas.BackColor = Color.FromArgb(0, 0, 64); // fondo del control Chart
            chartVentas.BorderlineDashStyle = ChartDashStyle.NotSet;
            chartVentas.BorderlineWidth = 0;
            chartVentas.BorderlineColor = Color.Transparent;
            chartVentas.Visible = false;

            ChartArea area = new ChartArea("MainArea");
            area.BackColor = Color.FromArgb(0, 0, 64); // fondo del área de gráfico
            area.BorderColor = Color.Transparent;
            area.BorderDashStyle = ChartDashStyle.NotSet;
            area.BorderWidth = 0;
            chartVentas.ChartAreas.Add(area);

            // Leyenda con fondo azul y texto blanco
            Legend leyenda = new Legend("Vendedores");
            leyenda.BackColor = Color.FromArgb(0, 0, 64);
            leyenda.ForeColor = Color.White;
            chartVentas.Legends.Add(leyenda);

            this.Controls.Add(chartVentas);

            // Título del gráfico
            lbTituloGraficoVentas = new Label
            {
                Text = "Distribución de Ventas por\nVendedor",
                Font = new System.Drawing.Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(0, 0, 64),
                AutoSize = true,
                Location = new Point(chartVentas.Location.X, chartVentas.Location.Y - 60),
                Visible = false
            };

            this.Controls.Add(lbTituloGraficoVentas);

            lbProductoMasVendido = new Label
            {
                Text = "",
                Font = new System.Drawing.Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(0, 0, 64),
                AutoSize = true,
                Location = new Point(chartVentas.Location.X, chartVentas.Location.Y + chartVentas.Height + 10),
                Visible = false
            };

            this.Controls.Add(lbProductoMasVendido);


            idPerfil = p_idPerfil;

            clbVendedoresReporteGerente.ItemCheck += clbVendedoresReporteGerente_ItemCheck;
            clbVendedoresReporteGerente.MouseClick += clbVendedoresReporteGerente_MouseClick;
            clbVendedoresReporteGerente.Leave += clbVendedoresReporteGerente_Leave;

            this.Load += Reportes_Load;

            BGenerarVentasPorVendedorGerente.Click += OnGenerarGerente_Click;
            dgvReporteGerente.CellClick += dgvReporteGerente_CellClick;

            BGenerarProductosVendidosGerente.Click += OnGenerarGerente_Click;

            BGenerarTotalVentasGerente.Click += OnGenerarGerente_Click;

            bGenerarPdfReporteGerente.Click += bGenerarPdfReporteGerente_Click;
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            fechaDesdeGerente.Format = DateTimePickerFormat.Custom;
            fechaDesdeGerente.CustomFormat = "dd/MM/yyyy";

            fechaHastaGerente.Format = DateTimePickerFormat.Custom;
            fechaHastaGerente.CustomFormat = "dd/MM/yyyy";

            dgvReporteGerente.AllowUserToAddRows = false;

            cbVentasFinalizadasReporteGerentes.Visible = false;
            cbVentasCanceladasReporteGerentes.Visible = false;

            tbBusquedaClienteReporteG.TextChanged += (s, e) => AplicarFiltrosReporteGerente();
            tbBusquedaProductoReporteG.TextChanged += (s, e) => AplicarFiltrosReporteGerente();
            tbBusquedaNroFacturaReporteG.TextChanged += (s, e) => AplicarFiltrosReporteGerente();
            tbBusquedaPrecioMinReporteG.TextChanged += (s, e) => AplicarFiltrosReporteGerente();
            tbBusquedaPrecioMaxReporteG.TextChanged += (s, e) => AplicarFiltrosReporteGerente();

            cbVentasFinalizadasReporteGerentes.CheckedChanged += (s, e) =>
            {
                if (cbVentasFinalizadasReporteGerentes.Checked)
                {
                    cbVentasCanceladasReporteGerentes.Checked = false;
                    ultimoBotonPresionado?.PerformClick();
                }
                else if (!cbVentasCanceladasReporteGerentes.Checked)
                {
                    cbVentasFinalizadasReporteGerentes.Checked = true;
                }
            };

            cbVentasCanceladasReporteGerentes.CheckedChanged += (s, e) =>
            {
                if (cbVentasCanceladasReporteGerentes.Checked)
                {
                    cbVentasFinalizadasReporteGerentes.Checked = false;
                    ultimoBotonPresionado?.PerformClick();
                }
                else if (!cbVentasFinalizadasReporteGerentes.Checked)
                {
                    cbVentasCanceladasReporteGerentes.Checked = true;
                }
            };

            if (idPerfil == 3)
                CargarChecklistVendedores();
        }

        private void CargarChecklistVendedores()
        {
            clbVendedoresReporteGerente.Items.Clear();

            clbVendedoresReporteGerente.Items.Add("Seleccioná algún vendedor");

            var vendedores = Usuario_controller.ObtenerVendedores();

            foreach (var v in vendedores)
            {
                string display = $"{v.dni} - {v.nombre} {v.apellido}";
                clbVendedoresReporteGerente.Items.Add(new ComboItem
                {
                    Text = display,
                    Value = v.id_usuario
                });
            }
        }

        private void clbVendedoresReporteGerente_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.Index == 0)
            {
                e.NewValue = CheckState.Unchecked;
            }
        }

        private void clbVendedoresReporteGerente_MouseClick(object sender, MouseEventArgs e)
        {
            clbVendedoresReporteGerente.Height = alturaExpandidaChecklist;
            clbVendedoresReporteGerente.TopIndex = 1;
        }

        private void clbVendedoresReporteGerente_Leave(object sender, EventArgs e)
        {
            clbVendedoresReporteGerente.Height = alturaOriginalChecklist;
        }

        private void BGenerarReporteGerente_Click(object sender, EventArgs e)
        {

        }

        private void OnGenerarGerente_Click(object sender, EventArgs e)
        {
            ultimoBotonPresionado = sender as Button;

            if (!ValidarRangoFechas())
                return;

            List<int> vendedoresSeleccionados = new List<int>();

            foreach (var item in clbVendedoresReporteGerente.CheckedItems)
            {
                if (item is ComboItem combo)
                    vendedoresSeleccionados.Add(combo.Value);
            }

            if (vendedoresSeleccionados.Count == 0)
            {
                MessageBox.Show("Debés seleccionar al menos un vendedor.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime fechaDesde = fechaDesdeGerente.Value.Date;
            DateTime fechaHasta = fechaHastaGerente.Value.Date.AddDays(1);

            List<int> estadosSeleccionados = new List<int> { 2 };

            if (estadosSeleccionados.Count == 0)
            {
                MessageBox.Show("Debés seleccionar al menos un estado de venta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var boton = sender as Button;

            if (boton == BGenerarVentasPorVendedorGerente)
            {
                lBuscarPorReporteGerente.Visible = true;
                ConfigurarVisibilidadFiltros(
                    mostrarCliente: true,
                    mostrarProducto: false,
                    mostrarFactura: true,
                    mostrarPrecio: true
                );
                GenerarReporteVentasPorVendedor(vendedoresSeleccionados, fechaDesde, fechaHasta, estadosSeleccionados);
            }
            else if (boton == BGenerarProductosVendidosGerente)
            {
                lBuscarPorReporteGerente.Visible = true;
                ConfigurarVisibilidadFiltros(
                    mostrarCliente: false,
                    mostrarProducto: true,
                    mostrarFactura: true,
                    mostrarPrecio: true
                );
                GenerarReporteProductosVendidos(vendedoresSeleccionados, fechaDesde, fechaHasta, estadosSeleccionados);
            }
            else if (boton == BGenerarTotalVentasGerente)
            {
                lBuscarPorReporteGerente.Visible = false;
                ConfigurarVisibilidadFiltros(
                    mostrarCliente: false,
                    mostrarProducto: false,
                    mostrarFactura: false,
                    mostrarPrecio: false
                );
                GenerarReporteTotalVentas(vendedoresSeleccionados, fechaDesde, fechaHasta, estadosSeleccionados);
            }

            bGenerarPdfReporteGerente.Visible = true;
        }


        private bool ValidarRangoFechas()
        {
            DateTime desde = fechaDesdeGerente.Value.Date;
            DateTime hasta = fechaHastaGerente.Value.Date;

            if (hasta < desde)
            {
                MessageBox.Show(
                    "La fecha “Hasta” debe ser igual o posterior a la fecha “Desde”.",
                    "Validación de fechas",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                fechaDesdeGerente.Focus();
                return false;
            }
            return true;
        }

        private void cbVendedoresDniReporte_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbVendedoresNombreReporte_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void GenerarReporteVentasPorVendedor(List<int> vendedoresSeleccionados, DateTime fechaDesde, DateTime fechaHasta, List<int> estadosSeleccionados)
        {
            var tabla = Venta_controller.ObtenerVentasPorVendedorYEstado(vendedoresSeleccionados, fechaDesde, fechaHasta, estadosSeleccionados);

            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron ventas en el rango seleccionado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            tablaOriginalReporteGerente = tabla.Copy();

            dgvReporteGerente.Columns.Clear(); 

            string filtroCliente = tbBusquedaClienteReporteG.Text.Trim().ToLower();
            string filtroFactura = tbBusquedaNroFacturaReporteG.Text.Trim().ToLower();
            string filtroMin = tbBusquedaPrecioMinReporteG.Text.Trim();
            string filtroMax = tbBusquedaPrecioMaxReporteG.Text.Trim();

            decimal? precioMin = decimal.TryParse(filtroMin, out var min) ? min : (decimal?)null;
            decimal? precioMax = decimal.TryParse(filtroMax, out var max) ? max : (decimal?)null;

            var tablaFiltrada = tabla.AsEnumerable().Where(row =>
                row.Field<string>("cliente").ToLower().Contains(filtroCliente) &&
                row.Field<string>("nro_factura").ToLower().Contains(filtroFactura) &&
                (!precioMin.HasValue || row.Field<decimal>("total_venta") >= precioMin.Value) &&
                (!precioMax.HasValue || row.Field<decimal>("total_venta") <= precioMax.Value)
            ).ToList();

            if (tablaFiltrada.Count == 0)
            {
                //MessageBox.Show("No se encontraron resultados con los filtros aplicados.", "Sin coincidencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvReporteGerente.DataSource = tablaFiltrada.CopyToDataTable();

            dgvReporteGerente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvReporteGerente.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);

            CultureInfo culturaAR = new CultureInfo("es-AR");

            foreach (DataGridViewColumn col in dgvReporteGerente.Columns)
            {
                string texto = col.HeaderText;

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    string limpio = texto.Replace("_", " ");
                    col.HeaderText = char.ToUpper(limpio[0]) + limpio.Substring(1);
                }

                if (col.Name == "total_venta")
                {
                    col.DefaultCellStyle.FormatProvider = culturaAR;
                    col.DefaultCellStyle.Format = "C";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }

            decimal total = tabla.AsEnumerable().Sum(r => r.Field<decimal>("total_venta"));
            lbTotalVendidoReporteGerente.Text = total.ToString("C", culturaAR);

            // Estadísticos
            var tablaEstadistica = tablaFiltrada;

            int cantidadVentas = tablaEstadistica.Count;
            int cantidadClientes = tablaEstadistica.Select(r => r.Field<string>("cliente")).Distinct().Count();
            string clienteFrecuente = tablaEstadistica
                .GroupBy(r => r.Field<string>("cliente"))
                .OrderByDescending(g => g.Count())
                .First().Key;

            decimal totalVentas = tablaEstadistica.Sum(r => r.Field<decimal>("total_venta"));
            decimal promedioFactura = cantidadVentas > 0 ? totalVentas / cantidadVentas : 0;

            decimal mayorVenta = tablaEstadistica.Max(r => r.Field<decimal>("total_venta"));
            decimal menorVenta = tablaEstadistica.Min(r => r.Field<decimal>("total_venta"));

            var diaMayorFacturacion = tablaEstadistica
                .GroupBy(r => r.Field<DateTime>("fecha"))
                .Select(g => new { Fecha = g.Key, Total = g.Sum(r => r.Field<decimal>("total_venta")) })
                .OrderByDescending(g => g.Total)
                .First();

            lbCantidadVentasReporteGerente.Text = $"Cantidad de ventas: {cantidadVentas}";
            lbCantidadClientesReporteGerente.Text = $"Clientes de clientes: {cantidadClientes}";
            lbClienteFrecuenteReporteGerente.Text = $"Cliente más frecuente: {clienteFrecuente}";
            lbPromedioFacturasReporteGerente.Text = $"Promedio por factura: {promedioFactura.ToString("C", culturaAR)}";
            lbMayorVentaReporteGerente.Text = $"Venta más alta: {mayorVenta.ToString("C", culturaAR)}";
            lbMenorVentaReporteGerente.Text = $"Venta más baja: {menorVenta.ToString("C", culturaAR)}";
            lbMayorFacturacionReporteGerente.Text = $"Día con mayor facturación: {diaMayorFacturacion.Fecha:dd/MM/yyyy} ({diaMayorFacturacion.Total.ToString("C", culturaAR)})";

            // ✅ Mostrar los labels
            lbCantidadVentasReporteGerente.Visible = true;
            lbCantidadClientesReporteGerente.Visible = true;
            lbClienteFrecuenteReporteGerente.Visible = true;
            lbPromedioFacturasReporteGerente.Visible = true;
            lbMayorVentaReporteGerente.Visible = true;
            lbMenorVentaReporteGerente.Visible = true;
            lbMayorFacturacionReporteGerente.Visible = true;

            //  Diagrama de torta: distribución de ventas por vendedor
            chartVentas.Series.Clear();
            chartVentas.ChartAreas.Clear();
            chartVentas.Legends.Clear();

            chartVentas.ChartAreas.Add(new ChartArea("AreaPrincipal"));
            chartVentas.Legends.Add(new Legend("Vendedores"));

            Series serie = new Series
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Label = "#PERCENT{P0}",
                LegendText = "#VALX",
                Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Regular)
            };

            // Agrupar por vendedor y sumar total vendido
            var distribucion = tablaEstadistica
                .GroupBy(r => r.Field<string>("vendedor"))
                .Select(g => new
                {
                    Vendedor = g.Key,
                    Total = g.Sum(r => r.Field<decimal>("total_venta"))
                });

            foreach (var item in distribucion)
            {
                serie.Points.AddXY(item.Vendedor, item.Total);
            }

            chartVentas.Series.Add(serie);
            chartVentas.Visible = true;
            chartVentas.BringToFront();
            chartVentas.Invalidate();

            lbTituloGraficoVentas.Visible = true;
            lbTituloGraficoVentas.BringToFront();

            lbTotalVendidoReporteGerente.Visible = true;
            lTotalInfoReporteGerente.Visible = true;
            dgvReporteGerente.Visible = true;
        }

        private void dgvReporteGerente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReporteGerente.Columns[e.ColumnIndex].Name == "colPDF" && e.RowIndex >= 0)
            {
                var fila = dgvReporteGerente.Rows[e.RowIndex];
                int idVenta = Convert.ToInt32(fila.Cells["id_venta"].Value);
            }
        }

        private void GenerarReporteProductosVendidos(List<int> vendedoresSeleccionados, DateTime fechaDesde, DateTime fechaHasta, List<int> estadosSeleccionados)
        {
            var tabla = Venta_controller.ObtenerProductosVendidosPorVendedorYEstado(vendedoresSeleccionados, fechaDesde, fechaHasta, estadosSeleccionados);

            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron productos vendidos en el rango seleccionado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            tablaOriginalReporteGerente = tabla.Copy();

            // Aplicar filtros antes de mostrar
            string filtroProducto = tbBusquedaProductoReporteG.Text.Trim().ToLower();
            string filtroFactura = tbBusquedaNroFacturaReporteG.Text.Trim().ToLower();
            string filtroMin = tbBusquedaPrecioMinReporteG.Text.Trim();
            string filtroMax = tbBusquedaPrecioMaxReporteG.Text.Trim();

            decimal? precioMin = decimal.TryParse(filtroMin, out var min) ? min : (decimal?)null;
            decimal? precioMax = decimal.TryParse(filtroMax, out var max) ? max : (decimal?)null;

            var tablaFiltrada = tabla.AsEnumerable().Where(row =>
                row.Field<string>("producto").ToLower().Contains(filtroProducto) &&
                row.Field<string>("nro_factura").ToLower().Contains(filtroFactura) &&
                (!precioMin.HasValue || row.Field<decimal>("precio_unitario") >= precioMin.Value) &&
                (!precioMax.HasValue || row.Field<decimal>("precio_unitario") <= precioMax.Value)
            ).ToList();

            if (tablaFiltrada.Count == 0)
            {
                //MessageBox.Show("No se encontraron resultados con los filtros aplicados.", "Sin coincidencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvReporteGerente.Columns.Clear();
            dgvReporteGerente.DataSource = tablaFiltrada.CopyToDataTable();
            dgvReporteGerente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporteGerente.AllowUserToAddRows = false;
            dgvReporteGerente.ReadOnly = true;

            dgvReporteGerente.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
            CultureInfo culturaAR = new CultureInfo("es-AR");

            foreach (DataGridViewColumn col in dgvReporteGerente.Columns)
            {
                string texto = col.HeaderText;

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    string limpio = texto.Replace("_", " ");
                    col.HeaderText = char.ToUpper(limpio[0]) + limpio.Substring(1);
                }

                if (col.Name == "precio_unitario" || col.Name == "total_por_producto")
                {
                    col.DefaultCellStyle.FormatProvider = culturaAR;
                    col.DefaultCellStyle.Format = "C";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }

            decimal total = tablaFiltrada.Sum(r => r.Field<decimal>("total_por_producto"));
            lbTotalVendidoReporteGerente.Text = total.ToString("C", culturaAR);

            // Estadísticos
            var tablaEstadistica = tablaFiltrada;

            int cantidadVentas = tablaEstadistica.Count;
            int cantidadVendedores = tablaEstadistica.Select(r => r.Field<string>("vendedor")).Distinct().Count();

            string productoMasVendido = tablaEstadistica
                .GroupBy(r => r.Field<string>("producto"))
                .OrderByDescending(g => g.Sum(r => r.Field<decimal>("total_por_producto")))
                .First().Key;

            decimal promedioProducto = cantidadVentas > 0 ? total / cantidadVentas : 0;
            decimal mayorProducto = tablaEstadistica.Max(r => r.Field<decimal>("total_por_producto"));
            decimal menorProducto = tablaEstadistica.Min(r => r.Field<decimal>("total_por_producto"));

            var diaMayorFacturacion = tablaEstadistica
                .GroupBy(r => r.Field<DateTime>("fecha"))
                .Select(g => new { Fecha = g.Key, Total = g.Sum(r => r.Field<decimal>("total_por_producto")) })
                .OrderByDescending(g => g.Total)
                .First();

            lbCantidadVentasReporteGerente.Text = $"Cantidad de registros: {cantidadVentas}";
            lbCantidadClientesReporteGerente.Text = $"Cantidad de vendedores: {cantidadVendedores}";
            lbClienteFrecuenteReporteGerente.Text = $"Producto más vendido: {productoMasVendido}";
            lbPromedioFacturasReporteGerente.Text = $"Promedio por producto: {promedioProducto.ToString("C", culturaAR)}";
            lbMayorVentaReporteGerente.Text = $"Precio del producto más alto: {mayorProducto.ToString("C", culturaAR)}";
            lbMenorVentaReporteGerente.Text = $"Precio del producto más bajo: {menorProducto.ToString("C", culturaAR)}";
            lbMayorFacturacionReporteGerente.Text = $"Día con mayor facturación: {diaMayorFacturacion.Fecha:dd/MM/yyyy} ({diaMayorFacturacion.Total.ToString("C", culturaAR)})";

            lbCantidadVentasReporteGerente.Visible = true;
            lbCantidadClientesReporteGerente.Visible = true;
            lbClienteFrecuenteReporteGerente.Visible = true;
            lbPromedioFacturasReporteGerente.Visible = true;
            lbMayorVentaReporteGerente.Visible = true;
            lbMenorVentaReporteGerente.Visible = true;
            lbMayorFacturacionReporteGerente.Visible = true;

            //// Calcular el producto más vendido
            //var resumenProductoMasVendido = tablaEstadistica
            //    .GroupBy(r => r.Field<string>("producto"))
            //    .Select(g => new
            //    {
            //        Producto = g.Key,
            //        Total = g.Sum(r => r.Field<decimal>("total_por_producto"))
            //    })
            //    .OrderByDescending(g => g.Total)
            //    .FirstOrDefault();

            //if (resumenProductoMasVendido != null)
            //{
            //    lbClienteFrecuenteReporteGerente.Text = $"Producto más vendido: {resumenProductoMasVendido.Producto} ({resumenProductoMasVendido.Total.ToString("C", culturaAR)})";
            //    lbClienteFrecuenteReporteGerente.Visible = true;
            //    lbClienteFrecuenteReporteGerente.BringToFront();
            //}

            // Diagrama de torta: distribución de ventas por vendedor
            chartVentas.Series.Clear();
            chartVentas.ChartAreas.Clear();
            chartVentas.Legends.Clear();

            chartVentas.ChartAreas.Add(new ChartArea("AreaPrincipal"));
            chartVentas.Legends.Add(new Legend("Productos"));

            Series serie = new Series
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = false,
                //Label = "#PERCENT{P0}",
                //LegendText = "#VALX (#PERCENT{P0})",
                Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Regular)
            };

            // Agrupar por producto y sumar total vendido
            var distribucion = tablaEstadistica
                .GroupBy(r => r.Field<string>("producto"))
                .Select(g => new
                {
                    Producto = g.Key,
                    Total = g.Sum(r => r.Field<decimal>("total_por_producto"))
                });

            foreach (var item in distribucion)
            {
                serie.Points.AddXY(item.Producto, item.Total);
            }

            chartVentas.Series.Add(serie);
            chartVentas.Visible = true;
            chartVentas.BringToFront();
            chartVentas.Invalidate();

            lbTituloGraficoVentas.Text = "Distribución de Ventas por\nProducto";
            lbTituloGraficoVentas.Visible = true;
            lbTituloGraficoVentas.BringToFront();

            lbTotalVendidoReporteGerente.Visible = true;
            lTotalInfoReporteGerente.Visible = true;
            dgvReporteGerente.Visible = true;
        }

        private void GenerarReporteTotalVentas(List<int> vendedoresSeleccionados, DateTime fechaDesde, DateTime fechaHasta, List<int> estadosSeleccionados)
        {
            var tabla = Venta_controller.ObtenerResumenTotalVentas(vendedoresSeleccionados, fechaDesde, fechaHasta, estadosSeleccionados);

            if (tabla == null || tabla.Rows.Count == 0 || tabla.AsEnumerable().All(r => r.IsNull("total") || r.Field<decimal>("total") == 0))
            {
                MessageBox.Show("No se encontraron ventas en el rango seleccionado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvReporteGerente.Columns.Clear();
            dgvReporteGerente.DataSource = tabla;
            dgvReporteGerente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporteGerente.AllowUserToAddRows = false;
            dgvReporteGerente.ReadOnly = true;

            dgvReporteGerente.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);
            CultureInfo culturaAR = new CultureInfo("es-AR");

            foreach (DataGridViewColumn col in dgvReporteGerente.Columns)
            {
                string texto = col.HeaderText;

                if (!string.IsNullOrWhiteSpace(texto))
                {
                    string limpio = texto.Replace("_", " ");
                    col.HeaderText = char.ToUpper(limpio[0]) + limpio.Substring(1);
                }

                if (col.Name == "total")
                {
                    col.HeaderText = "Total vendido";
                    col.DefaultCellStyle.FormatProvider = culturaAR;
                    col.DefaultCellStyle.Format = "C";
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }

            decimal total = tabla.AsEnumerable().Sum(r => r.Field<decimal>("total"));
            lbTotalVendidoReporteGerente.Text = total.ToString("C", culturaAR);

            //Estadísticos
            var tablaEstadistica = tabla.AsEnumerable().ToList();

            int cantidadVentas = tablaEstadistica.Count;
            int cantidadVendedores = tablaEstadistica.Select(r => r.Field<string>("vendedor")).Distinct().Count();

            string vendedorTop = tablaEstadistica
                .GroupBy(r => r.Field<string>("vendedor"))
                .OrderByDescending(g => g.Sum(r => r.Field<decimal>("total")))
                .First().Key;

            decimal totalVentas = tablaEstadistica.Sum(r => r.Field<decimal>("total"));
            decimal promedioFactura = cantidadVentas > 0 ? totalVentas / cantidadVentas : 0;
            decimal mayorVenta = tablaEstadistica.Max(r => r.Field<decimal>("total"));
            decimal menorVenta = tablaEstadistica.Min(r => r.Field<decimal>("total"));

            //var diaMayorFacturacion = tablaEstadistica
            //    .GroupBy(r => r.Field<DateTime>("fecha"))
            //    .Select(g => new { Fecha = g.Key, Total = g.Sum(r => r.Field<decimal>("total")) })
            //    .OrderByDescending(g => g.Total)
            //    .First();

            //lbCantidadVentasReporteGerente.Text = $"Cantidad de ventas: {cantidadVentas}";
            int totalCantidadVentas = tablaEstadistica.Sum(r => r.Field<int>("cantidad_ventas"));
            lbCantidadVentasReporteGerente.Text = $"Cantidad de ventas: {totalCantidadVentas}";
            lbCantidadClientesReporteGerente.Text = $"Cantidad de vendedores: {cantidadVendedores}";
            lbClienteFrecuenteReporteGerente.Text = $"Vendedor con más ventas: {vendedorTop}";
            lbPromedioFacturasReporteGerente.Text = $"Promedio por venta: {promedioFactura.ToString("C", culturaAR)}";
            lbMayorVentaReporteGerente.Text = $"Venta más alta: {mayorVenta.ToString("C", culturaAR)}";
            lbMenorVentaReporteGerente.Text = $"Venta más baja: {menorVenta.ToString("C", culturaAR)}";
            //lbMayorFacturacionReporteGerente.Text = $"Día con mayor facturación: {diaMayorFacturacion.Fecha:dd/MM/yyyy} ({diaMayorFacturacion.Total.ToString("C", culturaAR)})";

            lbCantidadVentasReporteGerente.Visible = true;
            lbCantidadClientesReporteGerente.Visible = true;
            lbClienteFrecuenteReporteGerente.Visible = true;
            lbPromedioFacturasReporteGerente.Visible = true;
            lbMayorVentaReporteGerente.Visible = true;
            lbMenorVentaReporteGerente.Visible = true;
            lbMayorFacturacionReporteGerente.Visible = false;

            // Diagrama de torta: distribución de ventas por vendedor
            chartVentas.Series.Clear();
            chartVentas.ChartAreas.Clear();
            chartVentas.Legends.Clear();

            chartVentas.ChartAreas.Add(new ChartArea("AreaPrincipal"));
            chartVentas.Legends.Add(new Legend("Vendedores"));

            Series serie = new Series
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                Label = "#PERCENT{P0}",
                LegendText = "#VALX",
                Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Regular)
            };

            // Agrupar por vendedor y sumar total vendido
            var distribucion = tablaEstadistica
                .GroupBy(r => r.Field<string>("vendedor"))
                .Select(g => new
                {
                    Vendedor = g.Key,
                    Total = g.Sum(r => r.Field<decimal>("total"))
                });

            foreach (var item in distribucion)
            {
                serie.Points.AddXY(item.Vendedor, item.Total);
            }

            chartVentas.Series.Add(serie);
            chartVentas.Visible = true;
            chartVentas.BringToFront();
            chartVentas.Invalidate();

            lbTituloGraficoVentas.Text = "Distribución de Ventas por\nVendedor";
            lbTituloGraficoVentas.Visible = true;
            lbTituloGraficoVentas.BringToFront();

            lbTotalVendidoReporteGerente.Visible = true;
            lTotalInfoReporteGerente.Visible = true;
            dgvReporteGerente.Visible = true;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dgvReporteGerente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ConfigurarVisibilidadFiltros(bool mostrarCliente, bool mostrarProducto, bool mostrarFactura, bool mostrarPrecio)
        {
            tbBusquedaClienteReporteG.Visible = mostrarCliente;
            tbBusquedaProductoReporteG.Visible = mostrarProducto;
            tbBusquedaNroFacturaReporteG.Visible = mostrarFactura;
            tbBusquedaPrecioMinReporteG.Visible = mostrarPrecio;
            tbBusquedaPrecioMaxReporteG.Visible = mostrarPrecio;
        }

        private void AplicarFiltrosReporteGerente()
        {
            if (tablaOriginalReporteGerente == null || tablaOriginalReporteGerente.Rows.Count == 0)
                return;

            var tabla = tablaOriginalReporteGerente;

            string filtroCliente = tbBusquedaClienteReporteG.Visible ? tbBusquedaClienteReporteG.Text.Trim().ToLower() : "";
            string filtroProducto = tbBusquedaProductoReporteG.Visible ? tbBusquedaProductoReporteG.Text.Trim().ToLower() : "";
            string filtroFactura = tbBusquedaNroFacturaReporteG.Visible ? tbBusquedaNroFacturaReporteG.Text.Trim().ToLower() : "";
            string filtroMin = tbBusquedaPrecioMinReporteG.Visible ? tbBusquedaPrecioMinReporteG.Text.Trim() : "";
            string filtroMax = tbBusquedaPrecioMaxReporteG.Visible ? tbBusquedaPrecioMaxReporteG.Text.Trim() : "";

            decimal? precioMin = decimal.TryParse(filtroMin, out var min) ? min : (decimal?)null;
            decimal? precioMax = decimal.TryParse(filtroMax, out var max) ? max : (decimal?)null;

            var filtrada = tabla.AsEnumerable().Where(row =>
                (!tbBusquedaClienteReporteG.Visible || row.Table.Columns.Contains("cliente") && row.Field<string>("cliente").ToLower().Contains(filtroCliente)) &&
                (!tbBusquedaProductoReporteG.Visible || row.Table.Columns.Contains("producto") && row.Field<string>("producto").ToLower().Contains(filtroProducto)) &&
                (!tbBusquedaNroFacturaReporteG.Visible || row.Table.Columns.Contains("nro_factura") && row.Field<string>("nro_factura").ToLower().Contains(filtroFactura)) &&
                (!precioMin.HasValue || (
                    (row.Table.Columns.Contains("total_venta") && row.Field<decimal>("total_venta") >= precioMin.Value) ||
                    (row.Table.Columns.Contains("precio_unitario") && row.Field<decimal>("precio_unitario") >= precioMin.Value)
                )) &&
                (!precioMax.HasValue || (
                    (row.Table.Columns.Contains("total_venta") && row.Field<decimal>("total_venta") <= precioMax.Value) ||
                    (row.Table.Columns.Contains("precio_unitario") && row.Field<decimal>("precio_unitario") <= precioMax.Value)
                ))
            ).ToList();

            if (filtrada.Count == 0)
            {
                dgvReporteGerente.DataSource = null;
                lbTotalVendidoReporteGerente.Text = "$0";
                return;
            }

            dgvReporteGerente.DataSource = filtrada.CopyToDataTable();

            // Actualizar total si corresponde
            if (filtrada.First().Table.Columns.Contains("total_venta"))
            {
                decimal total = filtrada.Sum(r => r.Field<decimal>("total_venta"));
                lbTotalVendidoReporteGerente.Text = total.ToString("C", new CultureInfo("es-AR"));
            }
            else if (filtrada.First().Table.Columns.Contains("total_por_producto"))
            {
                decimal total = filtrada.Sum(r => r.Field<decimal>("total_por_producto"));
                lbTotalVendidoReporteGerente.Text = total.ToString("C", new CultureInfo("es-AR"));
            }
        }

        private void bGenerarPdfReporteGerente_Click(object sender, EventArgs e)
        {
            if (dgvReporteGerente.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Sin contenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string nombreArchivo = "";
            string tituloReporte = "";
            string columnaTotal = "";

            if (ultimoBotonPresionado == BGenerarVentasPorVendedorGerente)
            {
                nombreArchivo = "ReporteVentasPorVendedor.pdf";
                tituloReporte = "Reporte de Ventas por Vendedor";
                columnaTotal = "total_venta";
            }
            else if (ultimoBotonPresionado == BGenerarProductosVendidosGerente)
            {
                nombreArchivo = "ReporteProductosVendidos.pdf";
                tituloReporte = "Reporte de Productos Vendidos";
                columnaTotal = "total_por_producto";
            }
            else if (ultimoBotonPresionado == BGenerarTotalVentasGerente)
            {
                nombreArchivo = "ReporteTotalVentas.pdf";
                tituloReporte = "Resumen Total de Ventas";
                columnaTotal = "total";
            }
            else
            {
                MessageBox.Show("No se puede generar el PDF sin un reporte activo.", "Acción no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreArchivo);
                using (FileStream stream = new FileStream(ruta, FileMode.Create))
                {
                    Document doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
                    PdfWriter.GetInstance(doc, stream);
                    doc.Open();

                    var fuenteTitulo = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 16);
                    var fuenteEncabezado = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 10);
                    var fuenteFila = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 9);
                    CultureInfo culturaAR = new CultureInfo("es-AR");

                    doc.Add(new Paragraph(tituloReporte, fuenteTitulo));
                    doc.Add(new Paragraph($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm}", fuenteFila));
                    doc.Add(new Paragraph(" ")); // Espacio

                    PdfPTable tablaPdf = new PdfPTable(dgvReporteGerente.Columns.Count);
                    tablaPdf.WidthPercentage = 100;

                    // Encabezados
                    foreach (DataGridViewColumn col in dgvReporteGerente.Columns)
                    {
                        tablaPdf.AddCell(new PdfPCell(new Phrase(col.HeaderText, fuenteEncabezado)));
                    }

                    // Filas
                    foreach (DataGridViewRow fila in dgvReporteGerente.Rows)
                    {
                        if (fila.IsNewRow) continue;

                        foreach (DataGridViewCell celda in fila.Cells)
                        {
                            string texto = "";

                            if (celda.Value is DateTime fecha)
                            {
                                texto = fecha.ToString("dd/MM/yyyy");
                            }
                            else if (
                                celda.OwningColumn.Name.Trim().ToLower() == columnaTotal.Trim().ToLower() ||
                                celda.OwningColumn.Name.Trim().ToLower() == "precio_unitario"
                            )

                            {
                                if (decimal.TryParse(celda.Value?.ToString(), out var montoDecimal))
                                    texto = montoDecimal.ToString("C", culturaAR);
                                else if (long.TryParse(celda.Value?.ToString(), out var montoLong))
                                    texto = ((decimal)montoLong).ToString("C", culturaAR);
                                else if (int.TryParse(celda.Value?.ToString(), out var montoInt))
                                    texto = ((decimal)montoInt).ToString("C", culturaAR);
                                else
                                    texto = celda.Value?.ToString() ?? "";
                            }
                            else
                            {
                                texto = celda.Value?.ToString() ?? "";
                            }

                            tablaPdf.AddCell(new PdfPCell(new Phrase(texto, fuenteFila)));
                        }
                    }

                    doc.Add(tablaPdf);

                    // 🔢 Agregar resumen de total si corresponde
                    var columnaExiste = dgvReporteGerente.Columns
                        .Cast<DataGridViewColumn>()
                        .Any(c => c.Name.Trim().ToLower() == columnaTotal.Trim().ToLower());

                    if (!string.IsNullOrEmpty(columnaTotal) && columnaExiste)
                    {
                        decimal total = 0;

                        foreach (DataGridViewRow fila in dgvReporteGerente.Rows)
                        {
                            if (fila.IsNewRow) continue;

                            int indexColumnaTotal = dgvReporteGerente.Columns
                                                    .Cast<DataGridViewColumn>()
                                                    .First(c => c.Name.Trim().ToLower() == columnaTotal.Trim().ToLower())
                                                    .Index;
                            var celda = fila.Cells[indexColumnaTotal];

                            if (decimal.TryParse(celda.Value?.ToString(), out var montoDecimal))
                                total += montoDecimal;
                            else if (long.TryParse(celda.Value?.ToString(), out var montoLong))
                                total += montoLong;
                        }

                        string textoTotal = $"TOTAL: {total.ToString("C", culturaAR)}";
                        doc.Add(new Paragraph(" "));
                        doc.Add(new Paragraph(textoTotal, fuenteEncabezado));
                    }

                    doc.Close();
                    stream.Close();

                    var resultado = MessageBox.Show(
                        "El PDF fue generado correctamente en el escritorio.\n¿Deseás abrirlo ahora?",
                        "PDF generado",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information
                    );

                    if (resultado == DialogResult.Yes)
                    {
                        visorPdf.Document?.Dispose();
                        GC.Collect();
                        GC.WaitForPendingFinalizers();

                        string rutaTemporal = Path.Combine(Path.GetTempPath(), $"temp_{Guid.NewGuid()}.pdf");
                        File.Copy(ruta, rutaTemporal, true);

                        visorPdf.Document = PdfiumViewer.PdfDocument.Load(rutaTemporal);
                        visorPdf.ZoomMode = PdfViewerZoomMode.FitWidth;

                        // Ajuste visual del panel
                        panelVisorPdf.Size = new Size(this.ClientSize.Width - 20, this.ClientSize.Height - 10);
                        panelVisorPdf.Location = new Point(10, 10);
                        panelVisorPdf.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
                        panelVisorPdf.BringToFront();
                        panelVisorPdf.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
