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
        }

        private void Reportes_Load(object sender, EventArgs e)
        {
            fechaDesde.Format = DateTimePickerFormat.Custom;
            fechaDesde.CustomFormat = "dd/MM/yyyy";

            fechaHasta.Format = DateTimePickerFormat.Custom;
            fechaHasta.CustomFormat = "dd/MM/yyyy";

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

    }
}
