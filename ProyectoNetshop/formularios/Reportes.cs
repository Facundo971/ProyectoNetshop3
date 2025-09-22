using ProyectoNetshop.Cruds;
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
    public partial class Reportes : Form
    {
        private readonly int idPerfil;
        public Reportes(int p_idPerfil)
        {
            InitializeComponent();
            idPerfil = p_idPerfil;
            this.Load += Reportes_Load;

            // Desuscribimos por si hubiera duplicados en el Designer
            BGenerarRecaudacionGerente.Click -= OnGenerarGerente_Click;
            BGenerarReporteGerente.Click -= OnGenerarGerente_Click;
            BGenerarTotalVentasGerente.Click -= OnGenerarGerente_Click;

            // Suscribimos los tres botones al mismo handler
            BGenerarRecaudacionGerente.Click += OnGenerarGerente_Click;
            BGenerarReporteGerente.Click += OnGenerarGerente_Click;
            BGenerarTotalVentasGerente.Click += OnGenerarGerente_Click;
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            fechaDesdeGerente.Format = DateTimePickerFormat.Custom;
            fechaDesdeGerente.CustomFormat = "dd/MM/yyyy";

            fechaHastaGerente.Format = DateTimePickerFormat.Custom;
            fechaHastaGerente.CustomFormat = "dd/MM/yyyy";

            if (idPerfil == 3)
                CargarComboVendedores();
            //else
            // ocultas o deshabilitas los combos si no es gerente
            //panelVendedores.Visible = false;
        }

        private void CargarComboVendedores()
        {
            // 1) Traer lista de vendedores
            var vendedores = Usuario_controller.ObtenerVendedores();

            // 2) Proyectar a objeto anónimo que tenga dni y nombre completo
            var data = vendedores
                .Select(v => new
                {
                    v.dni,
                    NombreCompleto = $"{v.nombre} {v.apellido}"
                })
                .ToList();

            // 3) Crear un BindingSource compartido
            var bs = new BindingSource { DataSource = data };

            // 4) Asignar a los ComboBox con distintos DisplayMember
            cbVendedoresDniReporte.DataSource = bs;
            cbVendedoresDniReporte.DisplayMember = "dni";
            cbVendedoresDniReporte.ValueMember = "dni";

            cbVendedoresNombreReporte.DataSource = bs;
            cbVendedoresNombreReporte.DisplayMember = "NombreCompleto";
            cbVendedoresNombreReporte.ValueMember = "dni";

            // 5) (Opcional) estilo y texto de ayuda
            cbVendedoresDniReporte.SelectedIndex = -1;
            cbVendedoresNombreReporte.SelectedIndex = -1;
            cbVendedoresDniReporte.Text = "Selecciona DNI...";
            cbVendedoresNombreReporte.Text = "Selecciona nombre completo...";
        }

        private void BGenerarReporteGerente_Click(object sender, EventArgs e)
        {

        }


        private void OnGenerarGerente_Click(object sender, EventArgs e)
        {
            // 1) Validar rango de fechas
            if (!ValidarRangoFechas())
                return;

            // 2) Saber qué botón disparó el evento
            var boton = sender as Button;
            string accion = boton == BGenerarRecaudacionGerente
                ? "recaudación"
                : boton == BGenerarReporteGerente
                    ? "reporte"
                    : "total de ventas";

            // 3) Mostrar mensaje de éxito
            MessageBox.Show(
                $"Rango de fechas válido. Generando {accion} para Gerente…",
                "Éxito",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            // Aquí iría la lógica real de generación según el botón
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

            // Opcional: prohibir rangos demasiado largos, fechas futuras, etc.
            // if ((hasta - desde).TotalDays > 365) { … }

            return true;
        }
    }
}
