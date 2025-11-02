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
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace ProyectoNetshop.formularios
{
    public partial class Reportes : Form
    {
        private readonly int idPerfil;
        private int alturaOriginalChecklist = 40;   // o el valor que tenías inicialmente
        private int alturaExpandidaChecklist = 100; // altura deseada al desplegar
        private Button ultimoBotonPresionado;

        private DataTable tablaOriginalReporteGerente;

        public Reportes(int p_idPerfil)
        {
            InitializeComponent();

            var clickFilter = new ClickMessageFilter();
            clickFilter.ClickFueraDetectado += (clickeado) =>
            {
                if (clickeado != clbVendedoresReporteGerente)
                {
                    clbVendedoresReporteGerente.Height = alturaOriginalChecklist;
                    clbVendedoresReporteGerente.TopIndex = 0;
                }
            };

            //var clickFilter = new ClickMessageFilter();
            //clickFilter.ClickFueraDetectado += (clickeado) =>
            //{
            //    if (clickeado != clbVendedoresReporteGerente)
            //    {
            //        clbVendedoresReporteGerente.Height = alturaOriginalChecklist;

            //        // Forzar que el primer ítem visible sea el encabezado
            //        clbVendedoresReporteGerente.TopIndex = 0;

            //        // Quitar el foco para evitar que el ítem seleccionado lo mantenga visible
            //        this.ActiveControl = null;
            //    }
            //};
            //Application.AddMessageFilter(clickFilter);


            Application.AddMessageFilter(clickFilter);

            idPerfil = p_idPerfil;

            clbVendedoresReporteGerente.ItemCheck += clbVendedoresReporteGerente_ItemCheck;
            clbVendedoresReporteGerente.MouseClick += clbVendedoresReporteGerente_MouseClick;
            clbVendedoresReporteGerente.Leave += clbVendedoresReporteGerente_Leave;

            this.Load += Reportes_Load;

            BGenerarVentasPorVendedorGerente.Click += OnGenerarGerente_Click;
            dgvReporteGerente.CellClick += dgvReporteGerente_CellClick;

            BGenerarProductosVendidosGerente.Click += OnGenerarGerente_Click;

            BGenerarTotalVentasGerente.Click += OnGenerarGerente_Click;

            //BGenerarVentasPorVendedorGerente.Click -= OnGenerarGerente_Click;
            //BGenerarProductosVendidosGerente.Click -= OnGenerarGerente_Click;
            //BGenerarTotalVentasGerente.Click -= OnGenerarGerente_Click;

            //BGenerarVentasPorVendedorGerente.Click += OnGenerarGerente_Click;
            //BGenerarProductosVendidosGerente.Click += OnGenerarGerente_Click;
            //BGenerarTotalVentasGerente.Click += OnGenerarGerente_Click;
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

            bGenerarPdfReporteGerente.Click += bGenerarPdfReporteGerente_Click;

            //// ✅ Exclusividad lógica entre checkboxes
            //cbVentasFinalizadasReporteGerentes.CheckedChanged += (s, e) =>
            //{
            //    if (cbVentasFinalizadasReporteGerentes.Checked)
            //    {
            //        cbVentasCanceladasReporteGerentes.Checked = false;
            //        BGenerarVentasPorVendedorGerente.PerformClick();
            //    }
            //    else if (!cbVentasCanceladasReporteGerentes.Checked)
            //    {
            //        cbVentasFinalizadasReporteGerentes.Checked = true; // No permitir que ambos estén desmarcados
            //    }
            //};

            //cbVentasCanceladasReporteGerentes.CheckedChanged += (s, e) =>
            //{
            //    if (cbVentasCanceladasReporteGerentes.Checked)
            //    {
            //        cbVentasFinalizadasReporteGerentes.Checked = false;
            //        BGenerarVentasPorVendedorGerente.PerformClick();
            //    }
            //    else if (!cbVentasFinalizadasReporteGerentes.Checked)
            //    {
            //        cbVentasCanceladasReporteGerentes.Checked = true; // No permitir que ambos estén desmarcados
            //    }
            //};

            cbVentasFinalizadasReporteGerentes.CheckedChanged += (s, e) =>
            {
                if (cbVentasFinalizadasReporteGerentes.Checked)
                {
                    cbVentasCanceladasReporteGerentes.Checked = false;
                    ultimoBotonPresionado?.PerformClick(); // ✅ Ejecuta el último botón presionado
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
                    ultimoBotonPresionado?.PerformClick(); // ✅ Ejecuta el último botón presionado
                }
                else if (!cbVentasFinalizadasReporteGerentes.Checked)
                {
                    cbVentasCanceladasReporteGerentes.Checked = true;
                }
            };

            if (idPerfil == 3)
                CargarChecklistVendedores();
        }

        //private void CargarComboVendedores()
        //{
        //    var vendedores = Usuario_controller.ObtenerVendedores();

        //    var data = vendedores
        //        .Select(v => new
        //        {
        //            v.dni,
        //            NombreCompleto = $"{v.nombre} {v.apellido}"
        //        }).ToList();

        //    var bs = new BindingSource { DataSource = data };

        //    cbVendedoresDniReporte.DataSource = bs;
        //    cbVendedoresDniReporte.DisplayMember = "dni";
        //    cbVendedoresDniReporte.ValueMember = "dni";

        //    cbVendedoresNombreReporte.DataSource = bs;
        //    cbVendedoresNombreReporte.DisplayMember = "NombreCompleto";
        //    cbVendedoresNombreReporte.ValueMember = "dni";

        //    cbVendedoresDniReporte.SelectedIndex = -1;
        //    cbVendedoresNombreReporte.SelectedIndex = -1;
        //    cbVendedoresDniReporte.Text = "Selecciona DNI...";
        //    cbVendedoresNombreReporte.Text = "Selecciona nombre completo...";
        //}

        private void CargarChecklistVendedores()
        {
            clbVendedoresReporteGerente.Items.Clear();

            // Agregar ítem de encabezado (no seleccionable)
            clbVendedoresReporteGerente.Items.Add("Seleccioná algún vendedor");

            var vendedores = Usuario_controller.ObtenerVendedores(); // Debe devolver id_usuario, dni, nombre, apellido

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
            // Evitar que se tildes el primer ítem (índice 0)
            if (e.Index == 0)
            {
                e.NewValue = CheckState.Unchecked;
            }
        }

        private void clbVendedoresReporteGerente_MouseClick(object sender, MouseEventArgs e)
        {
            //if (clbVendedoresReporteGerente.Items.Count > 1)
            //{
            //    clbVendedoresReporteGerente.TopIndex = 1; // Salta el ítem 0 (placeholder)
            //}
            clbVendedoresReporteGerente.Height = alturaExpandidaChecklist;
            clbVendedoresReporteGerente.TopIndex = 1; // desplaza para mostrar vendedores, salta el encabezado
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
            DateTime fechaHasta = fechaHastaGerente.Value.Date.AddDays(1); // ✅ Incluye el día completo

            //List<int> estadosSeleccionados = new List<int>();

            //if (cbVentasFinalizadasReporteGerentes.Checked)
            //    estadosSeleccionados.Add(2); // Finalizado

            //if (cbVentasCanceladasReporteGerentes.Checked)
            //    estadosSeleccionados.Add(3); // Cancelado

            List<int> estadosSeleccionados = new List<int> { 2 }; // ✅ Solo ventas finalizadas

            //MessageBox.Show("Estados seleccionados: " + string.Join(",", estadosSeleccionados));

            if (estadosSeleccionados.Count == 0)
            {
                MessageBox.Show("Debés seleccionar al menos un estado de venta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //var boton = sender as Button;

            //if (boton == BGenerarVentasPorVendedorGerente)
            //    //GenerarReporteVentasPorVendedor(vendedoresSeleccionados, fechaDesde, fechaHasta);
            //    GenerarReporteVentasPorVendedor(vendedoresSeleccionados, fechaDesde, fechaHasta, estadosSeleccionados);
            //else if (boton == BGenerarProductosVendidosGerente)
            //    GenerarReporteProductosVendidos(vendedoresSeleccionados, fechaDesde, fechaHasta, estadosSeleccionados);
            //else if (boton == BGenerarTotalVentasGerente)
            //    GenerarReporteTotalVentas(vendedoresSeleccionados, fechaDesde, fechaHasta, estadosSeleccionados);
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

            // ✅ Mostrar el botón PDF después de generar cualquier reporte
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

            // ✅ Guardar tabla original para filtrado dinámico
            tablaOriginalReporteGerente = tabla.Copy();

            dgvReporteGerente.Columns.Clear(); // ✅ Limpiar columnas antes de asignar nuevas

            //dgvReporteGerente.DataSource = tabla;
            // ✅ Aplicar filtros antes de mostrar
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

            // ✅ Evitar error si no hay coincidencias
            if (tablaFiltrada.Count == 0)
            {
                MessageBox.Show("No se encontraron resultados con los filtros aplicados.", "Sin coincidencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvReporteGerente.DataSource = tablaFiltrada.CopyToDataTable();

            dgvReporteGerente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ✅ Negrita en encabezados
            dgvReporteGerente.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9F, FontStyle.Bold);

            // ✅ Cultura argentina para formato moneda
            CultureInfo culturaAR = new CultureInfo("es-AR");

            // ✅ Formatear encabezados y aplicar formato moneda
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

            //// ❌ Eliminar columna PDF si existe
            //if (dgvReporteGerente.Columns.Contains("colPDF"))
            //    dgvReporteGerente.Columns.Remove("colPDF");

            //// ✅ Agregar columna "nro_factura" si no existe
            //if (!dgvReporteGerente.Columns.Contains("nro_factura"))
            //{
            //    var colFactura = new DataGridViewTextBoxColumn
            //    {
            //        Name = "nro_factura",
            //        HeaderText = "Nro Factura",
            //        ReadOnly = true
            //    };
            //    dgvReporteGerente.Columns.Insert(0, colFactura); // Insertar al principio si querés
            //}

            decimal total = tabla.AsEnumerable().Sum(r => r.Field<decimal>("total_venta"));
            lbTotalVendidoReporteGerente.Text = total.ToString("C", culturaAR);

            lbTotalVendidoReporteGerente.Visible = true;
            lTotalInfoReporteGerente.Visible = true;
            //cbVentasFinalizadasReporteGerentes.Visible = true;
            //cbVentasCanceladasReporteGerentes.Visible = true;
            dgvReporteGerente.Visible = true;
        }

        private void dgvReporteGerente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvReporteGerente.Columns[e.ColumnIndex].Name == "colPDF" && e.RowIndex >= 0)
            {
                var fila = dgvReporteGerente.Rows[e.RowIndex];
                int idVenta = Convert.ToInt32(fila.Cells["id_venta"].Value); // Asegurate de tener esta columna en el SELECT

                // Lógica para generar o abrir el PDF
                //Venta_controller.GenerarPdfVenta(idVenta); // Este método lo tenés que implementar
            }
        }

        //private void GenerarReporteProductosVendidos(List<int> vendedoresSeleccionados, DateTime fechaDesde, DateTime fechaHasta, List<int> estadosSeleccionados)
        //{
        //    var tabla = Venta_controller.ObtenerProductosVendidosPorVendedorYEstado(vendedoresSeleccionados, fechaDesde, fechaHasta, estadosSeleccionados);

        //    if (tabla.Rows.Count == 0)
        //    {
        //        MessageBox.Show("No se encontraron productos vendidos en el rango seleccionado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    dgvReporteGerente.Columns.Clear();

        //    //dgvReporteGerente.DataSource = tabla;


        //    dgvReporteGerente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    dgvReporteGerente.AllowUserToAddRows = false;
        //    dgvReporteGerente.ReadOnly = true;

        //    dgvReporteGerente.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        //    CultureInfo culturaAR = new CultureInfo("es-AR");

        //    foreach (DataGridViewColumn col in dgvReporteGerente.Columns)
        //    {
        //        string texto = col.HeaderText;

        //        if (!string.IsNullOrWhiteSpace(texto))
        //        {
        //            string limpio = texto.Replace("_", " ");
        //            col.HeaderText = char.ToUpper(limpio[0]) + limpio.Substring(1);
        //        }

        //        if (col.Name == "precio_unitario" || col.Name == "total_por_producto")
        //        {
        //            col.DefaultCellStyle.FormatProvider = culturaAR;
        //            col.DefaultCellStyle.Format = "C";
        //            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //        }
        //    }

        //    // ✅ Agregar columna "nro_factura" si no existe
        //    if (!dgvReporteGerente.Columns.Contains("nro_factura"))
        //    {
        //        var colFactura = new DataGridViewTextBoxColumn
        //        {
        //            Name = "nro_factura",
        //            HeaderText = "Nro Factura",
        //            ReadOnly = true
        //        };
        //        dgvReporteGerente.Columns.Insert(0, colFactura); // Insertar al principio si querés
        //    }

        //    decimal total = tabla.AsEnumerable().Sum(r => r.Field<decimal>("total_por_producto"));
        //    lbTotalVendidoReporteGerente.Text = total.ToString("C", culturaAR);

        //    lbTotalVendidoReporteGerente.Visible = true;
        //    lTotalInfoReporteGerente.Visible = true;
        //    //cbVentasFinalizadasReporteGerentes.Visible = true;
        //    //cbVentasCanceladasReporteGerentes.Visible = true;
        //    dgvReporteGerente.Visible = true;
        //}

        private void GenerarReporteProductosVendidos(List<int> vendedoresSeleccionados, DateTime fechaDesde, DateTime fechaHasta, List<int> estadosSeleccionados)
        {
            var tabla = Venta_controller.ObtenerProductosVendidosPorVendedorYEstado(vendedoresSeleccionados, fechaDesde, fechaHasta, estadosSeleccionados);

            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron productos vendidos en el rango seleccionado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // ✅ Guardar tabla original para filtrado dinámico
            tablaOriginalReporteGerente = tabla.Copy();

            // ✅ Aplicar filtros antes de mostrar
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
                MessageBox.Show("No se encontraron resultados con los filtros aplicados.", "Sin coincidencias", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            lbTotalVendidoReporteGerente.Visible = true;
            lTotalInfoReporteGerente.Visible = true;
            //cbVentasFinalizadasReporteGerentes.Visible = true;
            //cbVentasCanceladasReporteGerentes.Visible = true;
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

        //private void bGenerarPdfReporteGerente_Click(object sender, EventArgs e)
        //{
        //    if (ultimoBotonPresionado != BGenerarVentasPorVendedorGerente)
        //    {
        //        MessageBox.Show("Este PDF solo se genera para el reporte de ventas por vendedor.", "Acción no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    if (dgvReporteGerente.Rows.Count == 0)
        //    {
        //        MessageBox.Show("No hay datos para exportar.", "Sin contenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    try
        //    {
        //        string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ReporteVentasPorVendedor.pdf");
        //        using (FileStream stream = new FileStream(ruta, FileMode.Create))
        //        {
        //            Document doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
        //            PdfWriter.GetInstance(doc, stream);
        //            doc.Open();

        //            var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
        //            var fuenteEncabezado = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
        //            var fuenteFila = FontFactory.GetFont(FontFactory.HELVETICA, 9);

        //            doc.Add(new Paragraph("Reporte de Ventas por Vendedor", fuenteTitulo));
        //            doc.Add(new Paragraph($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm}", fuenteFila));
        //            doc.Add(new Paragraph(" ")); // Espacio

        //            PdfPTable tablaPdf = new PdfPTable(dgvReporteGerente.Columns.Count);
        //            tablaPdf.WidthPercentage = 100;

        //            // Encabezados
        //            foreach (DataGridViewColumn col in dgvReporteGerente.Columns)
        //            {
        //                tablaPdf.AddCell(new PdfPCell(new Phrase(col.HeaderText, fuenteEncabezado)));
        //            }

        //            // Filas
        //            foreach (DataGridViewRow fila in dgvReporteGerente.Rows)
        //            {
        //                if (fila.IsNewRow) continue;

        //                foreach (DataGridViewCell celda in fila.Cells)
        //                {
        //                    string texto = celda.Value?.ToString() ?? "";
        //                    tablaPdf.AddCell(new PdfPCell(new Phrase(texto, fuenteFila)));
        //                }
        //            }

        //            doc.Add(tablaPdf);
        //            doc.Close();
        //            stream.Close();

        //            MessageBox.Show("PDF generado correctamente en el escritorio.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //ESTE ES EL PRIMERO
        //private void bGenerarPdfReporteGerente_Click(object sender, EventArgs e)
        //{
        //    if (ultimoBotonPresionado != BGenerarVentasPorVendedorGerente)
        //    {
        //        MessageBox.Show("Este PDF solo se genera para el reporte de ventas por vendedor.", "Acción no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    if (dgvReporteGerente.Rows.Count == 0)
        //    {
        //        MessageBox.Show("No hay datos para exportar.", "Sin contenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    try
        //    {
        //        string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "ReporteVentasPorVendedor.pdf");
        //        using (FileStream stream = new FileStream(ruta, FileMode.Create))
        //        {
        //            Document doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
        //            PdfWriter.GetInstance(doc, stream);
        //            doc.Open();

        //            var fuenteTitulo = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 16);
        //            var fuenteEncabezado = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 10);
        //            var fuenteFila = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 9);
        //            CultureInfo culturaAR = new CultureInfo("es-AR");

        //            doc.Add(new Paragraph("Reporte de Ventas por Vendedor", fuenteTitulo));
        //            doc.Add(new Paragraph($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm}", fuenteFila));
        //            doc.Add(new Paragraph(" ")); // Espacio

        //            PdfPTable tablaPdf = new PdfPTable(dgvReporteGerente.Columns.Count);
        //            tablaPdf.WidthPercentage = 100;

        //            // Encabezados
        //            foreach (DataGridViewColumn col in dgvReporteGerente.Columns)
        //            {
        //                tablaPdf.AddCell(new PdfPCell(new Phrase(col.HeaderText, fuenteEncabezado)));
        //            }

        //            // Filas
        //            foreach (DataGridViewRow fila in dgvReporteGerente.Rows)
        //            {
        //                if (fila.IsNewRow) continue;

        //                foreach (DataGridViewCell celda in fila.Cells)
        //                {
        //                    string texto = "";

        //                    if (celda.Value is DateTime fecha)
        //                    {
        //                        texto = fecha.ToString("dd/MM/yyyy");
        //                    }
        //                    else if (celda.OwningColumn.Name == "total_venta" && decimal.TryParse(celda.Value?.ToString(), out var monto))
        //                    {
        //                        texto = monto.ToString("C", culturaAR); // "$ 113.200,00"
        //                    }
        //                    else
        //                    {
        //                        texto = celda.Value?.ToString() ?? "";
        //                    }

        //                    tablaPdf.AddCell(new PdfPCell(new Phrase(texto, fuenteFila)));
        //                }
        //            }

        //            doc.Add(tablaPdf);
        //            doc.Close();
        //            stream.Close();

        //            MessageBox.Show("PDF generado correctamente en el escritorio.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        //ESTE ES TAMBIEN EL CORRECTO
        //private void bGenerarPdfReporteGerente_Click(object sender, EventArgs e)
        //{
        //    if (dgvReporteGerente.Rows.Count == 0)
        //    {
        //        MessageBox.Show("No hay datos para exportar.", "Sin contenido", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        return;
        //    }

        //    string nombreArchivo = "";
        //    string tituloReporte = "";

        //    if (ultimoBotonPresionado == BGenerarVentasPorVendedorGerente)
        //    {
        //        nombreArchivo = "ReporteVentasPorVendedor.pdf";
        //        tituloReporte = "Reporte de Ventas por Vendedor";
        //    }
        //    else if (ultimoBotonPresionado == BGenerarProductosVendidosGerente)
        //    {
        //        nombreArchivo = "ReporteProductosVendidos.pdf";
        //        tituloReporte = "Reporte de Productos Vendidos";
        //    }
        //    else if (ultimoBotonPresionado == BGenerarTotalVentasGerente)
        //    {
        //        nombreArchivo = "ReporteTotalVentas.pdf";
        //        tituloReporte = "Resumen Total de Ventas";
        //    }
        //    else
        //    {
        //        MessageBox.Show("No se puede generar el PDF sin un reporte activo.", "Acción no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //        return;
        //    }

        //    try
        //    {
        //        string ruta = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), nombreArchivo);
        //        using (FileStream stream = new FileStream(ruta, FileMode.Create))
        //        {
        //            Document doc = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
        //            PdfWriter.GetInstance(doc, stream);
        //            doc.Open();

        //            var fuenteTitulo = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 16);
        //            var fuenteEncabezado = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA_BOLD, 10);
        //            var fuenteFila = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, 9);
        //            CultureInfo culturaAR = new CultureInfo("es-AR");

        //            doc.Add(new Paragraph(tituloReporte, fuenteTitulo));
        //            doc.Add(new Paragraph($"Generado el {DateTime.Now:dd/MM/yyyy HH:mm}", fuenteFila));
        //            doc.Add(new Paragraph(" ")); // Espacio

        //            PdfPTable tablaPdf = new PdfPTable(dgvReporteGerente.Columns.Count);
        //            tablaPdf.WidthPercentage = 100;

        //            // Encabezados
        //            foreach (DataGridViewColumn col in dgvReporteGerente.Columns)
        //            {
        //                tablaPdf.AddCell(new PdfPCell(new Phrase(col.HeaderText, fuenteEncabezado)));
        //            }

        //            // Filas
        //            foreach (DataGridViewRow fila in dgvReporteGerente.Rows)
        //            {
        //                if (fila.IsNewRow) continue;

        //                foreach (DataGridViewCell celda in fila.Cells)
        //                {
        //                    string texto = "";

        //                    if (celda.Value is DateTime fecha)
        //                    {
        //                        texto = fecha.ToString("dd/MM/yyyy");
        //                    }
        //                    else if ((celda.OwningColumn.Name == "total_venta" ||
        //                              celda.OwningColumn.Name == "precio_unitario" ||
        //                              celda.OwningColumn.Name == "total_por_producto") &&
        //                             decimal.TryParse(celda.Value?.ToString(), out var monto))
        //                    {
        //                        texto = monto.ToString("C", culturaAR); // "$ 113.200,00"
        //                    }
        //                    else
        //                    {
        //                        texto = celda.Value?.ToString() ?? "";
        //                    }

        //                    tablaPdf.AddCell(new PdfPCell(new Phrase(texto, fuenteFila)));
        //                }
        //            }

        //            doc.Add(tablaPdf);
        //            doc.Close();
        //            stream.Close();

        //            MessageBox.Show("PDF generado correctamente en el escritorio.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

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
                            //else if ((celda.OwningColumn.Name == "total_venta" ||
                            //          celda.OwningColumn.Name == "precio_unitario" ||
                            //          celda.OwningColumn.Name == "total_por_producto" ||
                            //          celda.OwningColumn.Name == "total_vendido"))
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

                    MessageBox.Show("PDF generado correctamente en el escritorio.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar el PDF: " + ex.Message, "Error técnico", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
