using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetshop.Cruds
{
    internal class Usuario_model
    {
        public int id_usuario { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public byte[] pass { get; set; }
        public int activo { get; set; }
        public string sexo { get; set; }
        public DateTime? fecha_nacimiento { get; set; }
        public int? telefono { get; set; }
        public int dni { get; set; }
        public int id_perfil { get; set; }

        // Esta es la propiedad donde volcarás el texto del perfil
        public string descripcion { get; set; }

        public string ActivoTexto => activo == 1 ? "SI" : "NO";

        public Usuario_model() { }

        public Usuario_model(int p_id_usuario, string p_nombre, string p_apellido, string p_email, byte[] p_pass, int p_activo, string p_sexo, DateTime p_fecha_nacimiento,
                             int p_telefono, int p_dni, int p_id_perfil)
        {
            this.id_usuario = p_id_usuario;
            this.nombre = p_nombre;
            this.apellido = p_apellido;
            this.email = p_email;
            this.pass = p_pass;
            this.activo = p_activo;
            this.sexo = p_sexo;
            this.fecha_nacimiento = p_fecha_nacimiento;
            this.telefono = p_telefono;
            this.dni = p_dni;
            this.id_perfil = p_id_perfil;
        }
    }
}
