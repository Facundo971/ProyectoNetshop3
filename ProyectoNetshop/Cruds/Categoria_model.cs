using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetshop.Cruds
{
    internal class Categoria_model
    {
        public int id_categoria { get; set; }
        public string descripcion { get; set; }
        public int activo { get; set; }

        public Categoria_model(int p_id_categoria, string p_descripcion, int p_activo)
        {
            this.id_categoria = p_id_categoria;
            this.descripcion = p_descripcion;
            this.activo = p_activo;
        }
    }
}
