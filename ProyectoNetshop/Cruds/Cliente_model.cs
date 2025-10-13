using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetshop.Cruds
{
    internal class Cliente_model
    {
        public int id_cliente { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string email { get; set; }
        public string sexo { get; set; }
        public DateTime? fecha_nacimiento { get; set; }
        public string telefono { get; set; }
        public int dni { get; set; }
        public int activo { get; set; }
        public Cliente_model() { }

        public Cliente_model(int p_id_cliente, string p_nombre, string p_apellido, string p_email, string p_sexo, 
            DateTime p_fecha_nacimiento, string p_telefono, int p_dni, int p_activo)
        {
            this.id_cliente = p_id_cliente;
            this.nombre = p_nombre;
            this.apellido = p_apellido;
            this.email = p_email;
            this.sexo = p_sexo;
            this.fecha_nacimiento = p_fecha_nacimiento;
            this.telefono = p_telefono;
            this.dni = p_dni;
            this.activo = p_activo;
        }
    }
}