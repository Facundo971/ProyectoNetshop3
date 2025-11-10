// Importa librerías.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetshop.Cruds
{
    // Clase estática que mantiene en memoria la lista de ítems del carrito de venta durante la sesión actual.
    public static class CarritoVentaSession
    {
        internal static List<Venta_detalle_model> Carrito = new List<Venta_detalle_model>();
    }
}