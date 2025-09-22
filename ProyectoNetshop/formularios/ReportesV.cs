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
        }

        private void ReportesV_Load(object sender, EventArgs e)
        {
            tbDniVendedorReporte.Text = dni.ToString();
            tbNombreVendedorReporte.Text = nombreCompleto;
        }
    }
}
