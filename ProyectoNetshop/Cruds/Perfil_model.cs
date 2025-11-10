// Importa librerías.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetshop.Cruds
{
    internal class Perfil_model
    {
        // Modelo de perfil de usuario que representa el rol, su descripción y estado de actividad.
        public int id_perfil { get; set; }
        public string descripcion { get; set; }
        public int activo { get; set; }

        // Constructor del modelo de perfil que inicializa el ID, la descripción y el estado de actividad del perfil.
        public Perfil_model(int p_id_perfil, string p_descripcion, int p_activo)
        {
            this.id_perfil = p_id_perfil;
            this.descripcion = p_descripcion;
            this.activo = p_activo;
        }
    }
}
