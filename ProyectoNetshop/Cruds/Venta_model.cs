// Importa librerías.
using iTextSharp.text.pdf.codec.wmf;
using Microsoft.Win32;
using ProyectoNetshop.formularios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProyectoNetshop.Cruds
{
    internal class Venta_model
    {
        // Modelo de una venta registrada en el sistema:  
        // Representa los datos clave de una transacción, incluyendo IDs de cliente, vendedor, venta y estado, fecha, tipo y número de factura,
        // total vendido y nombres descriptivos.
        public int id_venta { get; set; }
        public int id_cliente { get; set; }
        public int id_vendedor { get; set; } // Este es el usuario que realiza la venta
        public DateTime fecha { get; set; }
        public string tipo_factura { get; set; }
        public decimal total_venta { get; set; }
        public string nombre_cliente { get; set; }
        public string nombre_vendedor { get; set; }
        public int id_estado { get; set; }
        public string nro_factura { get; set; }


        // Constructor del modelo de venta:  
        // Inicializa una instancia con los datos esenciales: cliente, vendedor, fecha, tipo de factura, total y estado.
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
