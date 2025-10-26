using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetshop.Cruds
{
    internal class Venta_cabecera_model
    {
        public int id_venta { get; set; }
        public DateTime fecha { get; set; }
        public decimal total_venta { get; set; }
        public string tipo_factura { get; set; }
        public int id_usuario { get; set; }   // Vendedor
        public int id_cliente { get; set; }
        public int id_estado { get; set; }

        // Extras para mostrar en pantalla
        public string estado_descripcion { get; set; }
        public string cliente_nombre { get; set; }
        public string vendedor_nombre { get; set; }

        public Venta_cabecera_model() { }

        public Venta_cabecera_model(int p_id_venta, DateTime p_fecha, decimal p_total_venta, string p_tipo_factura,
                                    int p_id_usuario, int p_id_cliente, int p_id_estado)
        {
            this.id_venta = p_id_venta;
            this.fecha = p_fecha;
            this.total_venta = p_total_venta;
            this.tipo_factura = p_tipo_factura;
            this.id_usuario = p_id_usuario;
            this.id_cliente = p_id_cliente;
            this.id_estado = p_id_estado;
        }
    }
}
