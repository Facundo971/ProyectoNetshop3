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
    public partial class ReportesV : Form
    {
        private readonly int dni;
        private readonly string nombreCompleto;

        public ReportesV(int p_dni, string p_nombreCompleto)
        {
            InitializeComponent();
            dni = p_dni;
            nombreCompleto = p_nombreCompleto;
            this.Load += ReportesV_Load;

            BGenerarReporteVendedor.Click -= BGenerarReporteVendedor_Click;
            BGenerarReporteVendedor.Click += BGenerarReporteVendedor_Click;
        }

        private void ReportesV_Load(object sender, EventArgs e)
        {
            tbDniVendedorReporte.Text = dni.ToString();
            tbNombreVendedorReporte.Text = nombreCompleto;
            dgvReporteVentaVendedor.Visible = false;
        }

        private void tbDniVendedorReporte_TextChanged(object sender, EventArgs e)
        {

        }

        private void BGenerarReporteVendedor_Click(object sender, EventArgs e)
        {
            DateTime desde = fechaDesdeVendedor.Value.Date;
            DateTime hasta = fechaHastaVendedor.Value.Date;

            if (hasta < desde)
            {
                MessageBox.Show("La fecha 'Hasta' debe ser igual o posterior a la fecha 'Desde'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Rango de fechas válido. Generando reporte de vendedores…", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

            CargarReporte();
        }

        private void CargarReporte()
        {
            dgvReporteVentaVendedor.Rows.Clear();
            dgvReporteVentaVendedor.Rows.Add(1, "22/09/2025", "A", "Juan Perez", 100000);
            dgvReporteVentaVendedor.Rows.Add(2, "22/09/2025", "B", "María Pérez", 120000);
            dgvReporteVentaVendedor.Rows.Add(3, "22/09/2025", "A", "Ramón Pérez", 200000);
            dgvReporteVentaVendedor.Visible = true;
        }


        private void dgvReporteVentaVendedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
