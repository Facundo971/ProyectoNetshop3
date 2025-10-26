using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetshop.Cruds
{
    internal class Venta_detalle_model
    {
        public int id_detalle { get; set; }
        public int cantidad { get; set; }
        public decimal precio_unitario { get; set; }
        public int id_venta { get; set; }
        public int id_producto { get; set; }

        // Extras para mostrar en pantalla
        public string producto_nombre { get; set; }
        public string producto_descripcion { get; set; }

        // Nuevos campos para recuperar datos completos
        public string descripcionCategoria { get; set; }
        public string descripcionMarca { get; set; }

        public int id_cliente { get; set; }
        public string nombre_cliente { get; set; }
        public string dni_cliente { get; set; }
        public string email_cliente { get; set; }

        public string tipo_factura { get; set; }
        public DateTime fecha_venta { get; set; }

        public Venta_detalle_model() { }

        public Venta_detalle_model(int p_id_detalle, int p_cantidad, decimal p_precio_unitario,
                                   int p_id_venta, int p_id_producto)
        {
            this.id_detalle = p_id_detalle;
            this.cantidad = p_cantidad;
            this.precio_unitario = p_precio_unitario;
            this.id_venta = p_id_venta;
            this.id_producto = p_id_producto;
        }
    }
}
