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
    public partial class Reportes : Form
    {
        private readonly int idPerfil;
        private int alturaOriginalChecklist = 40;   // o el valor que tenías inicialmente
        private int alturaExpandidaChecklist = 100; // altura deseada al desplegar
        private Button ultimoBotonPresionado;

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

            List<int> estadosSeleccionados = new List<int>();

            if (cbVentasFinalizadasReporteGerentes.Checked)
                estadosSeleccionados.Add(2); // Finalizado

            if (cbVentasCanceladasReporteGerentes.Checked)
                estadosSeleccionados.Add(3); // Cancelado

            //MessageBox.Show("Estados seleccionados: " + string.Join(",", estadosSeleccionados));

            if (estadosSeleccionados.Count == 0)
            {
                MessageBox.Show("Debés seleccionar al menos un estado de venta.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var boton = sender as Button;

            if (boton == BGenerarVentasPorVendedorGerente)
                //GenerarReporteVentasPorVendedor(vendedoresSeleccionados, fechaDesde, fechaHasta);
                GenerarReporteVentasPorVendedor(vendedoresSeleccionados, fechaDesde, fechaHasta, estadosSeleccionados);
            else if (boton == BGenerarProductosVendidosGerente)
                GenerarReporteProductosVendidos(vendedoresSeleccionados, fechaDesde, fechaHasta, estadosSeleccionados);
            else if (boton == BGenerarTotalVentasGerente)
                GenerarReporteTotalVentas(vendedoresSeleccionados, fechaDesde, fechaHasta, estadosSeleccionados);
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

            dgvReporteGerente.Columns.Clear(); // ✅ Limpiar columnas antes de asignar nuevas
            dgvReporteGerente.DataSource = tabla;
            dgvReporteGerente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ✅ Negrita en encabezados
            dgvReporteGerente.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

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

            // ✅ Agregar columna de botón PDF si no existe
            if (!dgvReporteGerente.Columns.Contains("colPDF"))
            {
                var colPDF = new DataGridViewButtonColumn
                {
                    Name = "colPDF",
                    HeaderText = "PDF",
                    Text = "Descargar",
                    UseColumnTextForButtonValue = true
                };
                dgvReporteGerente.Columns.Add(colPDF);
            }

            decimal total = tabla.AsEnumerable().Sum(r => r.Field<decimal>("total_venta"));
            lbTotalVendidoReporteGerente.Text = total.ToString("C", culturaAR);

            lbTotalVendidoReporteGerente.Visible = true;
            lTotalInfoReporteGerente.Visible = true;
            cbVentasFinalizadasReporteGerentes.Visible = true;
            cbVentasCanceladasReporteGerentes.Visible = true;
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

        private void GenerarReporteProductosVendidos(List<int> vendedoresSeleccionados, DateTime fechaDesde, DateTime fechaHasta, List<int> estadosSeleccionados)
        {
            var tabla = Venta_controller.ObtenerProductosVendidosPorVendedorYEstado(vendedoresSeleccionados, fechaDesde, fechaHasta, estadosSeleccionados);

            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron productos vendidos en el rango seleccionado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvReporteGerente.Columns.Clear();
            dgvReporteGerente.DataSource = tabla;
            dgvReporteGerente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporteGerente.AllowUserToAddRows = false;
            dgvReporteGerente.ReadOnly = true;

            dgvReporteGerente.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
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

            decimal total = tabla.AsEnumerable().Sum(r => r.Field<decimal>("total_por_producto"));
            lbTotalVendidoReporteGerente.Text = total.ToString("C", culturaAR);

            lbTotalVendidoReporteGerente.Visible = true;
            lTotalInfoReporteGerente.Visible = true;
            cbVentasFinalizadasReporteGerentes.Visible = true;
            cbVentasCanceladasReporteGerentes.Visible = true;
            dgvReporteGerente.Visible = true;
        }

        private void GenerarReporteTotalVentas(List<int> vendedoresSeleccionados, DateTime fechaDesde, DateTime fechaHasta, List<int> estadosSeleccionados)
        {
            var tabla = Venta_controller.ObtenerResumenTotalVentas(vendedoresSeleccionados, fechaDesde, fechaHasta, estadosSeleccionados);

            if (tabla.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron ventas en el rango seleccionado.", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            dgvReporteGerente.Columns.Clear();
            dgvReporteGerente.DataSource = tabla;
            dgvReporteGerente.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvReporteGerente.AllowUserToAddRows = false;
            dgvReporteGerente.ReadOnly = true;

            dgvReporteGerente.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
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
            cbVentasFinalizadasReporteGerentes.Visible = true;
            cbVentasCanceladasReporteGerentes.Visible = true;
            dgvReporteGerente.Visible = true;
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
