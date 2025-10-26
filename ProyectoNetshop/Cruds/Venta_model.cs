using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetshop.Cruds
{
    internal class Venta_model
    {
        public int id_venta { get; set; }
        public int id_cliente { get; set; }
        public int id_vendedor { get; set; } // Este es el usuario que realiza la venta
        public DateTime fecha { get; set; }
        public string tipo_factura { get; set; } // A, B, C, etc.
        public decimal total_venta { get; set; } // ✅ ESTA ES LA PROPIEDAD QUE FALTABA
        public string nombre_cliente { get; set; }
        public string nombre_vendedor { get; set; }
        public int id_estado { get; set; }

        public Venta_model() { }

        public Venta_model(int id_cliente, int id_vendedor, DateTime fecha, string tipo_factura, decimal total_venta, int id_estado)
        {
            this.id_cliente = id_cliente;
            this.id_vendedor = id_vendedor;
            this.fecha = fecha;
            this.tipo_factura = tipo_factura;
            this.total_venta = total_venta;
            this.id_estado = id_estado;
        }
    }
}
