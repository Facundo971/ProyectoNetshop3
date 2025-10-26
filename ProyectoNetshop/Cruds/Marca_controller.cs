using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetshop.Cruds
{
    internal class Marca_controller
    {
        public static string ObtenerDescripcion(int id_marca)
        {
            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();
            cmd.CommandText = "SELECT descripcion FROM marca WHERE id_marca = @id;";
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = id_marca;

            var resultado = cmd.ExecuteScalar();
            return resultado != null ? resultado.ToString() : "Sin marca";
        }
    }
}
