using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Clase estática para guardar datos de sesión del usuario
namespace ProyectoNetshop
{
    public static class Sesion
    {
        // ID del usuario actualmente logueado en la aplicación
        public static int UsuarioActualId { get; set; }
    }
}
