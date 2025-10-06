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

    }
}
