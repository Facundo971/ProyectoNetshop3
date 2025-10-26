using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetshop.Cruds
{
    internal class Categoria_controller
    {
        public static string ObtenerDescripcion(int id_categoria)
        {
            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();
            cmd.CommandText = "SELECT descripcion FROM categoria WHERE id_categoria = @id;";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id_categoria;

            var resultado = cmd.ExecuteScalar();
            return resultado != null ? resultado.ToString() : "Sin categoría";
        }
    }
}
