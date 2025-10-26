using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoNetshop.Cruds
{
    internal class Venta_controller
    {
        public static int CrearVentaPendiente(DateTime fecha, string tipoFactura, int idUsuario, int idCliente)
        {
            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();

            cmd.CommandText = @"INSERT INTO venta_cabecera (fecha, total_venta, tipo_factura, id_usuario, id_cliente, id_estado)
                        VALUES (@fecha, 0, @tipo, @usuario, @cliente, 1);
                        SELECT SCOPE_IDENTITY();";

            cmd.Parameters.AddWithValue("@fecha", fecha);
            cmd.Parameters.AddWithValue("@tipo", tipoFactura);
            cmd.Parameters.AddWithValue("@usuario", idUsuario);
            cmd.Parameters.AddWithValue("@cliente", idCliente);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        public static bool AgregarDetalleVenta(int idVenta, int idProducto, int cantidad, decimal precioUnitario)
        {
            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();

            cmd.CommandText = @"INSERT INTO venta_detalle (cantidad, precio_unitario, id_venta, id_producto)
                        VALUES (@cantidad, @precio, @venta, @producto);";

            cmd.Parameters.AddWithValue("@cantidad", cantidad);
            cmd.Parameters.AddWithValue("@precio", precioUnitario);
            cmd.Parameters.AddWithValue("@venta", idVenta);
            cmd.Parameters.AddWithValue("@producto", idProducto);

            return cmd.ExecuteNonQuery() > 0;
        }

        public static int GuardarVenta(Venta_model venta)
        {
            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO venta_cabecera (id_cliente, id_usuario, fecha, tipo_factura, total_venta, id_estado)
                OUTPUT INSERTED.id_venta
                VALUES (@id_cliente, @id_usuario, @fecha, @tipo_factura, @total_venta, @id_estado);";
            cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = venta.id_cliente;
            cmd.Parameters.Add("@id_usuario", SqlDbType.Int).Value = venta.id_vendedor;
            cmd.Parameters.Add("@fecha", SqlDbType.Date).Value = venta.fecha;
            cmd.Parameters.Add("@tipo_factura", SqlDbType.Char, 1).Value = venta.tipo_factura;
            cmd.Parameters.Add("@total_venta", SqlDbType.Decimal).Value = venta.total_venta;
            cmd.Parameters.Add("@id_estado", SqlDbType.Int).Value = venta.id_estado;

            return (int)cmd.ExecuteScalar();
        }

        public static int GuardarDetalleVenta(Venta_detalle_model detalle)
        {
            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();
            cmd.CommandText = @"
        INSERT INTO venta_detalle (id_venta, id_producto, cantidad, precio_unitario)
        VALUES (@id_venta, @id_producto, @cantidad, @precio_unitario);";

            cmd.Parameters.Add("@id_venta", SqlDbType.Int).Value = detalle.id_venta;
            cmd.Parameters.Add("@id_producto", SqlDbType.Int).Value = detalle.id_producto;
            cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = detalle.cantidad;
            cmd.Parameters.Add("@precio_unitario", SqlDbType.Decimal).Value = detalle.precio_unitario;

            return cmd.ExecuteNonQuery();
        }

        //public static List<Venta_model> ObtenerVentasFinalizadas()
        //{
        //    var lista = new List<Venta_model>();

        //    using var conexion = BD.BaseDeDatos.obtenerConexion();
        //    using var cmd = conexion.CreateCommand();
        //    cmd.CommandText = @"
        //SELECT v.id_venta, v.fecha, v.tipo_factura, v.total_venta, v.id_estado,
        //       c.nombre + ' ' + c.apellido AS nombre_cliente,
        //       u.nombre + ' ' + u.apellido AS nombre_vendedor
        //FROM venta_cabecera v
        //JOIN cliente c ON v.id_cliente = c.id_cliente
        //JOIN usuario u ON v.id_usuario = u.id_usuario
        //WHERE v.id_estado IN (2, 3) -- Finalizado o Cancelado
        //ORDER BY v.fecha DESC;";

        //    using var reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        var venta = new Venta_model
        //        {
        //            id_venta = reader.GetInt32(0),
        //            fecha = reader.GetDateTime(1),
        //            tipo_factura = reader.GetString(2),
        //            total_venta = reader.GetDecimal(3),
        //            id_estado = reader.GetInt32(4),
        //            nombre_cliente = reader.GetString(5),
        //            nombre_vendedor = reader.GetString(6)
        //        };
        //        lista.Add(venta);
        //    }

        //    return lista;
        //}

        //public static List<Venta_model> ObtenerVentasPorEstado(int estado)
        //{
        //    var lista = new List<Venta_model>();

        //    using var conexion = BD.BaseDeDatos.obtenerConexion();
        //    using var cmd = conexion.CreateCommand();
        //    cmd.CommandText = @"
        //SELECT v.id_venta, v.fecha, v.tipo_factura, v.total_venta, v.id_estado,
        //       c.nombre + ' ' + c.apellido AS nombre_cliente,
        //       u.nombre + ' ' + u.apellido AS nombre_vendedor
        //FROM venta_cabecera v
        //JOIN cliente c ON v.id_cliente = c.id_cliente
        //JOIN usuario u ON v.id_usuario = u.id_usuario
        //WHERE v.id_estado = @estado
        //ORDER BY v.fecha DESC;";
        //    cmd.Parameters.AddWithValue("@estado", estado);

        //    using var reader = cmd.ExecuteReader();
        //    while (reader.Read())
        //    {
        //        var venta = new Venta_model
        //        {
        //            id_venta = reader.GetInt32(0),
        //            fecha = reader.GetDateTime(1),
        //            tipo_factura = reader.GetString(2),
        //            total_venta = reader.GetDecimal(3),
        //            id_estado = reader.GetInt32(4),
        //            nombre_cliente = reader.GetString(5),
        //            nombre_vendedor = reader.GetString(6)
        //        };
        //        lista.Add(venta);
        //    }

        //    return lista;
        //}

        public static List<Venta_model> ObtenerVentasPorEstadoYVendedor(int estado, int idUsuario)
        {
            var lista = new List<Venta_model>();

            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();
            cmd.CommandText = @"
SELECT v.id_venta, v.fecha, v.tipo_factura, v.total_venta, v.id_estado,
       c.nombre + ' ' + c.apellido AS nombre_cliente,
       u.nombre + ' ' + u.apellido AS nombre_vendedor
FROM venta_cabecera v
JOIN cliente c ON v.id_cliente = c.id_cliente
JOIN usuario u ON v.id_usuario = u.id_usuario
WHERE v.id_estado = @estado AND v.id_usuario = @idUsuario
ORDER BY v.fecha DESC;";
            cmd.Parameters.AddWithValue("@estado", estado);
            cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var venta = new Venta_model
                {
                    id_venta = reader.GetInt32(0),
                    fecha = reader.GetDateTime(1),
                    tipo_factura = reader.GetString(2),
                    total_venta = reader.GetDecimal(3),
                    id_estado = reader.GetInt32(4),
                    nombre_cliente = reader.GetString(5),
                    nombre_vendedor = reader.GetString(6)
                };
                lista.Add(venta);
            }

            return lista;
        }

        public static decimal ObtenerTotalVentasPorEstado(int estado)
        {
            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();
            cmd.CommandText = @"SELECT ISNULL(SUM(total_venta), 0) FROM venta_cabecera WHERE id_estado = @estado";
            cmd.Parameters.AddWithValue("@estado", estado);
            return (decimal)cmd.ExecuteScalar();
        }

        public static bool CancelarVentaDuplicando(int idVentaOriginal)
        {
            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var transaccion = conexion.BeginTransaction();

            try
            {
                // 1. Obtener cabecera original
                var cmdCab = conexion.CreateCommand();
                cmdCab.Transaction = transaccion;
                cmdCab.CommandText = @"SELECT id_cliente, id_usuario, fecha, tipo_factura, total_venta FROM venta_cabecera WHERE id_venta = @id";
                cmdCab.Parameters.AddWithValue("@id", idVentaOriginal);

                int idCliente = 0, idUsuario = 0;
                DateTime fecha = DateTime.Today;
                string tipoFactura = "";
                decimal total = 0;

                using (var reader = cmdCab.ExecuteReader())
                {
                    if (!reader.Read())
                    {
                        MessageBox.Show("No se encontró la venta original.");
                        return false;
                    }

                    idCliente = reader.GetInt32(0);
                    idUsuario = reader.GetInt32(1);
                    fecha = reader.GetDateTime(2);
                    tipoFactura = reader.GetString(3);
                    total = reader.GetDecimal(4);
                }

                MessageBox.Show("Cabecera original leída correctamente.");

                // 2. Insertar nueva cabecera con total negativo y estado Cancelado (3)
                var cmdNuevaCab = conexion.CreateCommand();
                cmdNuevaCab.Transaction = transaccion;
                cmdNuevaCab.CommandText = @"
            INSERT INTO venta_cabecera (id_cliente, id_usuario, fecha, tipo_factura, total_venta, id_estado)
            OUTPUT INSERTED.id_venta
            VALUES (@cliente, @usuario, GETDATE(), @tipo, @total, 3)";
                cmdNuevaCab.Parameters.AddWithValue("@cliente", idCliente);
                cmdNuevaCab.Parameters.AddWithValue("@usuario", idUsuario);
                cmdNuevaCab.Parameters.AddWithValue("@tipo", tipoFactura);
                cmdNuevaCab.Parameters.AddWithValue("@total", -total); // monto negativo

                int idVentaNueva = (int)cmdNuevaCab.ExecuteScalar();

                MessageBox.Show("Nueva cabecera insertada con ID: " + idVentaNueva);

                // 3. Obtener detalles originales
                var cmdDet = conexion.CreateCommand();
                cmdDet.Transaction = transaccion;
                cmdDet.CommandText = @"SELECT id_producto, cantidad, precio_unitario FROM venta_detalle WHERE id_venta = @id";
                cmdDet.Parameters.AddWithValue("@id", idVentaOriginal);

                var detalles = new List<(int id_producto, int cantidad, decimal precio_unitario)>();
                using (var reader = cmdDet.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        detalles.Add((
                            reader.GetInt32(0),
                            reader.GetInt32(1),
                            reader.GetDecimal(2)
                        ));
                    }
                }

                MessageBox.Show("Cantidad de detalles encontrados: " + detalles.Count);

                if (detalles.Count == 0)
                {
                    MessageBox.Show("La venta no tiene productos asociados.");
                    return false;
                }

                // 4. Insertar detalles y devolver stock
                foreach (var d in detalles)
                {
                    var cmdIns = conexion.CreateCommand();
                    cmdIns.Transaction = transaccion;
                    cmdIns.CommandText = @"
                INSERT INTO venta_detalle (id_venta, id_producto, cantidad, precio_unitario)
                VALUES (@venta, @producto, @cantidad, @precio)";
                    cmdIns.Parameters.AddWithValue("@venta", idVentaNueva);
                    cmdIns.Parameters.AddWithValue("@producto", d.id_producto);
                    cmdIns.Parameters.AddWithValue("@cantidad", d.cantidad);
                    cmdIns.Parameters.AddWithValue("@precio", d.precio_unitario);
                    cmdIns.ExecuteNonQuery();

                    var cmdStock = conexion.CreateCommand();
                    cmdStock.Transaction = transaccion;
                    cmdStock.CommandText = @"UPDATE producto SET stock = stock + @cantidad WHERE id_producto = @id";
                    cmdStock.Parameters.AddWithValue("@cantidad", d.cantidad);
                    cmdStock.Parameters.AddWithValue("@id", d.id_producto);
                    cmdStock.ExecuteNonQuery();
                }

                transaccion.Commit();
                MessageBox.Show("Venta cancelada correctamente.");
                return true;
            }
            catch (Exception ex)
            {
                transaccion.Rollback();
                MessageBox.Show("Error técnico: " + ex.Message);
                return false;
            }
        }

        //public static DataTable ObtenerVentasPorVendedor(List<int> vendedores, DateTime desde, DateTime hasta)
        //{
        //    var tabla = new DataTable();
        //    string ids = string.Join(",", vendedores);
        //    MessageBox.Show("IDs usados en la consulta: " + ids);

        //    using var conexion = BD.BaseDeDatos.obtenerConexion();
        //    using var cmd = conexion.CreateCommand();

        //    cmd.CommandText = $@"
        //SELECT v.fecha,
        //       u.nombre + ' ' + u.apellido AS vendedor,
        //       c.nombre + ' ' + c.apellido AS cliente,
        //       v.tipo_factura,
        //       v.total_venta,
        //       ev.descripcion AS estado
        //FROM venta_cabecera v
        //JOIN usuario u ON v.id_usuario = u.id_usuario
        //JOIN cliente c ON v.id_cliente = c.id_cliente
        //JOIN estado_venta ev ON v.id_estado = ev.id_estado
        //WHERE v.id_usuario IN ({ids})
        //  AND v.fecha BETWEEN @desde AND @hasta
        //ORDER BY v.fecha DESC";

        //    cmd.Parameters.AddWithValue("@desde", desde);
        //    cmd.Parameters.AddWithValue("@hasta", hasta);

        //    using var reader = cmd.ExecuteReader();
        //    tabla.Load(reader);

        //    return tabla;
        //}

        //public static DataTable ObtenerVentasPorVendedorYEstado(List<int> vendedores, DateTime desde, DateTime hasta, List<int> estados)
        //{
        //    var tabla = new DataTable();
        //    string ids = string.Join(",", vendedores);
        //    string estadosStr = string.Join(",", estados);

        //    using var conexion = BD.BaseDeDatos.obtenerConexion();
        //    using var cmd = conexion.CreateCommand();

        //    cmd.CommandText = $@"
        //SELECT v.fecha,
        //       u.nombre + ' ' + u.apellido AS vendedor,
        //       c.nombre + ' ' + c.apellido AS cliente,
        //       v.tipo_factura,
        //       v.total_venta,
        //       ev.descripcion AS estado
        //FROM venta_cabecera v
        //JOIN usuario u ON v.id_usuario = u.id_usuario
        //JOIN cliente c ON v.id_cliente = c.id_cliente
        //JOIN estado_venta ev ON v.id_estado = ev.id_estado
        //WHERE v.id_usuario IN ({ids})
        //  AND v.id_estado IN ({estadosStr})
        //  AND v.fecha BETWEEN @desde AND @hasta
        //ORDER BY v.fecha DESC";

        //    cmd.Parameters.AddWithValue("@desde", desde);
        //    cmd.Parameters.AddWithValue("@hasta", hasta);

        //    using var reader = cmd.ExecuteReader();
        //    tabla.Load(reader);

        //    return tabla;
        //}
        //public static DataTable ObtenerVentasPorVendedorYEstado(List<int> vendedores, DateTime desde, DateTime hasta, List<int> estados)
        //{
        //    var tabla = new DataTable();
        //    string ids = string.Join(",", vendedores);

        //    using var conexion = BD.BaseDeDatos.obtenerConexion();
        //    using var cmd = conexion.CreateCommand();

        //    // Construir cláusula IN para estados
        //    var estadoParams = estados.Select((e, i) => $"@estado{i}").ToList();
        //    string estadosInClause = string.Join(",", estadoParams);

        //    cmd.CommandText = $@"
        //SELECT v.fecha,
        //       u.nombre + ' ' + u.apellido AS vendedor,
        //       c.nombre + ' ' + c.apellido AS cliente,
        //       v.tipo_factura,
        //       v.total_venta,
        //       ev.descripcion AS estado
        //FROM venta_cabecera v
        //JOIN usuario u ON v.id_usuario = u.id_usuario
        //JOIN cliente c ON v.id_cliente = c.id_cliente
        //JOIN estado_venta ev ON v.id_estado = ev.id_estado
        //WHERE v.id_usuario IN ({ids})
        //  AND v.id_estado IN ({estadosInClause})
        //  AND v.fecha BETWEEN @desde AND @hasta
        //ORDER BY v.fecha DESC";

        //    cmd.Parameters.AddWithValue("@desde", desde);
        //    cmd.Parameters.AddWithValue("@hasta", hasta);

        //    for (int i = 0; i < estados.Count; i++)
        //        cmd.Parameters.AddWithValue($"@estado{i}", estados[i]);

        //    using var reader = cmd.ExecuteReader();
        //    tabla.Load(reader);

        //    return tabla;
        //}

        public static DataTable ObtenerVentasPorVendedorYEstado(List<int> vendedores, DateTime desde, DateTime hasta, List<int> estados)
        {
            var tabla = new DataTable();
            string ids = string.Join(",", vendedores);

            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();

            // Construir cláusula IN con parámetros
            var estadoParams = estados.Select((e, i) => $"@estado{i}").ToList();
            string estadosInClause = string.Join(",", estadoParams);

            cmd.CommandText = $@"
        SELECT v.fecha,
               u.nombre + ' ' + u.apellido AS vendedor,
               c.nombre + ' ' + c.apellido AS cliente,
               v.tipo_factura,
               v.total_venta,
               ev.descripcion AS estado
        FROM venta_cabecera v
        JOIN usuario u ON v.id_usuario = u.id_usuario
        JOIN cliente c ON v.id_cliente = c.id_cliente
        JOIN estado_venta ev ON v.id_estado = ev.id_estado
        WHERE v.id_usuario IN ({ids})
          AND v.id_estado IN ({estadosInClause})
          AND v.fecha BETWEEN @desde AND @hasta
        ORDER BY v.fecha DESC";

            cmd.Parameters.AddWithValue("@desde", desde);
            cmd.Parameters.AddWithValue("@hasta", hasta);

            for (int i = 0; i < estados.Count; i++)
                cmd.Parameters.AddWithValue($"@estado{i}", estados[i]);

            using var reader = cmd.ExecuteReader();
            tabla.Load(reader);

            return tabla;
        }

        public static DataTable ObtenerProductosVendidosPorVendedorYEstado(List<int> vendedores, DateTime desde, DateTime hasta, List<int> estados)
        {
            var tabla = new DataTable();
            string ids = string.Join(",", vendedores);
            string estadosStr = string.Join(",", estados);

            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();

            cmd.CommandText = $@"
        SELECT v.fecha,
               u.nombre + ' ' + u.apellido AS vendedor,
               p.nombre AS producto,
               dv.cantidad AS cantidad_vendida,
               dv.precio_unitario,
               (dv.cantidad * dv.precio_unitario) AS total_por_producto
        FROM venta_cabecera v
        JOIN venta_detalle dv ON v.id_venta = dv.id_venta
        JOIN producto p ON dv.id_producto = p.id_producto
        JOIN usuario u ON v.id_usuario = u.id_usuario
        WHERE v.id_usuario IN ({ids})
          AND v.id_estado IN ({estadosStr})
          AND v.fecha BETWEEN @desde AND @hasta
        ORDER BY v.fecha DESC";

            cmd.Parameters.AddWithValue("@desde", desde);
            cmd.Parameters.AddWithValue("@hasta", hasta);

            using var reader = cmd.ExecuteReader();
            tabla.Load(reader);

            return tabla;
        }

        public static DataTable ObtenerResumenTotalVentas(List<int> vendedores, DateTime desde, DateTime hasta, List<int> estados)
        {
            var tabla = new DataTable();
            string ids = string.Join(",", vendedores);
            string estadosStr = string.Join(",", estados);

            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();

            cmd.CommandText = $@"
    SELECT 
        u.nombre + ' ' + u.apellido AS vendedor,
        COUNT(v.id_venta) AS cantidad_ventas,
        ISNULL(SUM(v.total_venta), 0) AS total
    FROM usuario u
    LEFT JOIN venta_cabecera v ON u.id_usuario = v.id_usuario
        AND v.id_estado IN ({estadosStr})
        AND v.fecha BETWEEN @desde AND @hasta
    WHERE u.id_usuario IN ({ids})
    GROUP BY u.nombre, u.apellido
    ORDER BY total DESC";

            cmd.Parameters.AddWithValue("@desde", desde);
            cmd.Parameters.AddWithValue("@hasta", hasta);

            using var reader = cmd.ExecuteReader();
            tabla.Load(reader);

            return tabla;
        }
    }
}
