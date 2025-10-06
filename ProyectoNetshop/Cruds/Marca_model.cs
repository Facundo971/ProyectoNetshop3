using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetshop.Cruds
{
    internal class Marca_model
    {
        public int id_marca { get; set; }
        public string descripcion { get; set; }
        public int activo { get; set; }

        public Marca_model(int p_id_marca, string p_descripcion, int p_activo)
        {
            this.id_marca = p_id_marca;
            this.descripcion = p_descripcion;
            this.activo = p_activo;
        }
    }
}
