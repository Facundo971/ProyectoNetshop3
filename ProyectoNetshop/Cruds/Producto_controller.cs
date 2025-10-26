using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetshop.Cruds
{
    internal class Producto_controller
    {
        public static int agregarProducto(Producto_model p_producto)
        {
            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();

            cmd.CommandText = @"INSERT INTO producto (nombre, descripcion, precio, stock, imagen, eliminado, precio_vta, id_marca, id_categoria) 
                              VALUES (@nombre, @descripcion, @precio, @stock, @imagen, @eliminado, @precio_vta, @id_marca, @id_categoria);";

            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = p_producto.nombre;
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 200).Value = string.IsNullOrWhiteSpace(p_producto.descripcion) ? (object)DBNull.Value : p_producto.descripcion;
            
            var pPrecio = cmd.Parameters.Add("@precio", SqlDbType.Decimal);
            pPrecio.Precision = 10;
            pPrecio.Scale = 2;
            pPrecio.Value = p_producto.precio;
            
            cmd.Parameters.Add("@stock", SqlDbType.Int).Value = p_producto.stock;
            cmd.Parameters.Add("@imagen", SqlDbType.VarChar, 200).Value = string.IsNullOrWhiteSpace(p_producto.imagen) ? (object)DBNull.Value : p_producto.imagen;
            cmd.Parameters.Add("@eliminado", SqlDbType.Int).Value = p_producto.eliminado;

            var pPrecioVta = cmd.Parameters.Add("@precio_vta", SqlDbType.Decimal);
            pPrecioVta.Precision = 10;
            pPrecioVta.Scale = 2;
            pPrecioVta.Value = p_producto.precio_vta;

            cmd.Parameters.Add("@id_marca", SqlDbType.Int).Value = p_producto.id_marca;
            cmd.Parameters.Add("@id_categoria", SqlDbType.Int).Value = p_producto.id_categoria;

            return cmd.ExecuteNonQuery();
        }

        public static int actualizarProducto(Producto_model p_producto)
        {
            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();

            cmd.CommandText = @"UPDATE producto SET nombre = @nombre, descripcion = @descripcion, precio = @precio, stock = @stock, imagen = @imagen, 
                                                    eliminado = @eliminado, precio_vta = @precio_vta, id_marca = @id_marca, 
                                                    id_categoria = @id_categoria WHERE id_producto = @id_producto;";

            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = p_producto.nombre;

            // descripcion e imagen opcionales: si son null o vacías, guardamos DBNull
            cmd.Parameters.Add("@descripcion", SqlDbType.VarChar, 200).Value = string.IsNullOrWhiteSpace(p_producto.descripcion) ? (object)DBNull.Value : p_producto.descripcion;
            cmd.Parameters.Add("@imagen", SqlDbType.VarChar, 200).Value = string.IsNullOrWhiteSpace(p_producto.imagen) ? (object)DBNull.Value : p_producto.imagen;

            var pPrecio = cmd.Parameters.Add("@precio", SqlDbType.Decimal);
            pPrecio.Precision = 10;
            pPrecio.Scale = 2;
            pPrecio.Value = p_producto.precio;

            var pPrecioVta = cmd.Parameters.Add("@precio_vta", SqlDbType.Decimal);
            pPrecioVta.Precision = 10;
            pPrecioVta.Scale = 2;
            pPrecioVta.Value = p_producto.precio_vta;

            cmd.Parameters.Add("@stock", SqlDbType.Int).Value = p_producto.stock;
            cmd.Parameters.Add("@eliminado", SqlDbType.Int).Value = p_producto.eliminado;
            cmd.Parameters.Add("@id_marca", SqlDbType.Int).Value = p_producto.id_marca;
            cmd.Parameters.Add("@id_categoria", SqlDbType.Int).Value = p_producto.id_categoria;

            // id_producto para el WHERE
            cmd.Parameters.Add("@id_producto", SqlDbType.Int).Value = p_producto.id_producto;

            return cmd.ExecuteNonQuery();
        }

        public static int CambiarEstadoEliminado(int id_producto, int eliminado)
        {
            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();
            cmd.CommandText = @"UPDATE producto SET eliminado = @eliminado WHERE id_producto = @id_producto;";
            cmd.Parameters.Add("@eliminado", SqlDbType.Int).Value = eliminado;
            cmd.Parameters.Add("@id_producto", SqlDbType.Int).Value = id_producto;
            return cmd.ExecuteNonQuery();
        }

        public static List<Producto_model> BuscarProductos(string nombre, string id)
        {
            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();

            cmd.CommandText = @"
    SELECT * FROM producto 
    WHERE eliminado = 1 AND 
          (@nombre = '' OR nombre LIKE '%' + @nombre + '%') AND 
          (@id IS NULL OR id_producto = @id);";

            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = nombre;

            if (int.TryParse(id, out int idNum))
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = idNum;
            else
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = DBNull.Value;

            using var reader = cmd.ExecuteReader();
            var lista = new List<Producto_model>();

            while (reader.Read())
            {
                var p = new Producto_model
                {
                    id_producto = reader.GetInt32(reader.GetOrdinal("id_producto")),
                    nombre = reader.GetString(reader.GetOrdinal("nombre")),
                    descripcion = reader.IsDBNull(reader.GetOrdinal("descripcion"))
                                  ? null
                                  : reader.GetString(reader.GetOrdinal("descripcion")),
                    precio_vta = reader.GetDecimal(reader.GetOrdinal("precio_vta")),
                    stock = reader.GetInt32(reader.GetOrdinal("stock")),
                    imagen = reader.IsDBNull(reader.GetOrdinal("imagen"))
                             ? null
                             : reader.GetString(reader.GetOrdinal("imagen")),
                    id_marca = reader.GetInt32(reader.GetOrdinal("id_marca")),
                    id_categoria = reader.GetInt32(reader.GetOrdinal("id_categoria"))
                };

                // ✅ Agregar descripciones legibles de categoría y marca
                p.descripcionCategoria = Categoria_controller.ObtenerDescripcion(p.id_categoria);
                p.descripcionMarca = Marca_controller.ObtenerDescripcion(p.id_marca);

                lista.Add(p);
            }

            return lista;
        }

        public static int ObtenerStockActual(int id_producto)
        {
            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();
            cmd.CommandText = @"SELECT stock FROM producto WHERE id_producto = @id_producto;";
            cmd.Parameters.Add("@id_producto", SqlDbType.Int).Value = id_producto;
            var resultado = cmd.ExecuteScalar();
            return resultado != null ? Convert.ToInt32(resultado) : 0;
        }

        public static int ActualizarStock(int id_producto, int cantidadDelta)
        {
            int stockActual = ObtenerStockActual(id_producto);
            int nuevoStock = stockActual + cantidadDelta;

            if (nuevoStock < 0)
            {
                throw new InvalidOperationException("No se puede actualizar el stock: resultaría en un valor negativo.");
            }

            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();
            cmd.CommandText = @"UPDATE producto SET stock = stock + @delta WHERE id_producto = @id_producto;";
            cmd.Parameters.Add("@delta", SqlDbType.Int).Value = cantidadDelta;
            cmd.Parameters.Add("@id_producto", SqlDbType.Int).Value = id_producto;
            return cmd.ExecuteNonQuery();
        }


    }
}
