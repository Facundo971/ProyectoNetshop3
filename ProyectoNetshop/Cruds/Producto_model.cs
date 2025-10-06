using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetshop.Cruds
{
    internal class Producto_model
    {
        public int id_producto { get; set; }
        public string nombre { get; set; }
        public string? descripcion { get; set; }
        public decimal precio { get; set; }
        public int stock { get; set; }
        public string? imagen { get; set; }
        public int eliminado { get; set; }      // NO = 1, SI = 0
        public decimal precio_vta { get; set; }
        public int id_marca { get; set; }
        public int id_categoria { get; set; }

        // Obtenemos la descripcion de la marca 
        public string descripcionMarca { get; set; }

        // Obtenemos la descripcion de la categoria
        public string descripcionCategoria { get; set; }

        // Propiedad de solo lectura para mostrar texto legible del estado eliminado
        public string EliminadoTexto => eliminado == 1 ? "NO" : "SI";

        public Producto_model() { }

        public Producto_model(int p_id_producto, string p_nombre, string p_descripcion, decimal p_precio, int p_stock, 
                              string p_imagen, int p_eliminado, decimal p_precio_vta, int p_id_marca, int p_id_categoria)
        {
            this.id_producto = p_id_producto;
            this.nombre = p_nombre;
            this.descripcion = p_descripcion;
            this.precio = p_precio;
            this.stock = p_stock;
            this.imagen = p_imagen;
            this.eliminado = p_eliminado;
            this.precio_vta = p_precio_vta;
            this.id_marca = p_id_marca;
            this.id_categoria = p_id_categoria;
        }
    }
}
