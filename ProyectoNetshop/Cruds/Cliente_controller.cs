using Microsoft.Data.SqlClient;
using ProyectoNetshop.BD;
using System;
using System.Collections.Generic;
using System.Data;

namespace ProyectoNetshop.Cruds
{
    internal class Cliente_controller
    {
        public static int agregarCliente(Cliente_model p_cliente)
        {
            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();
            cmd.CommandText = @"INSERT INTO cliente (nombre, apellido, email, sexo, fecha_nacimiento, telefono, dni, activo)
                                VALUES (@nombre, @apellido, @email, @sexo, @fecha_nacimiento, @telefono, @dni, @activo);";
            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = p_cliente.nombre;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 100).Value = p_cliente.apellido;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 200).Value = p_cliente.email;
            cmd.Parameters.Add("@sexo", SqlDbType.VarChar, 20).Value = p_cliente.sexo;
            cmd.Parameters.Add("@fecha_nacimiento", SqlDbType.Date).Value = p_cliente.fecha_nacimiento.HasValue ? (object)p_cliente.fecha_nacimiento.Value.Date : DBNull.Value;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 20).Value = string.IsNullOrWhiteSpace(p_cliente.telefono) ? DBNull.Value : p_cliente.telefono;
            cmd.Parameters.Add("@dni", SqlDbType.Int).Value = p_cliente.dni;
            cmd.Parameters.Add("@activo", SqlDbType.Int).Value = p_cliente.activo;
            return cmd.ExecuteNonQuery();
        }

        public static int actualizarCliente(Cliente_model p_cliente)
        {
            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();

            cmd.CommandText = @"UPDATE cliente SET nombre = @nombre, apellido = @apellido, email = @email, sexo = @sexo, 
                                fecha_nacimiento = @fecha_nacimiento, telefono = @telefono, dni = @dni, activo = @activo
                                WHERE id_cliente = @id_cliente;";

            cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 100).Value = p_cliente.nombre;
            cmd.Parameters.Add("@apellido", SqlDbType.VarChar, 100).Value = p_cliente.apellido;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 200).Value = p_cliente.email;
            cmd.Parameters.Add("@sexo", SqlDbType.VarChar, 20).Value = p_cliente.sexo;
            cmd.Parameters.Add("@fecha_nacimiento", SqlDbType.Date).Value = p_cliente.fecha_nacimiento.HasValue ? (object)p_cliente.fecha_nacimiento.Value.Date : DBNull.Value;
            cmd.Parameters.Add("@telefono", SqlDbType.VarChar, 20).Value = string.IsNullOrWhiteSpace(p_cliente.telefono) ? DBNull.Value : p_cliente.telefono;
            cmd.Parameters.Add("@dni", SqlDbType.Int).Value = p_cliente.dni;
            cmd.Parameters.Add("@id_cliente", SqlDbType.Int).Value = p_cliente.id_cliente;
            cmd.Parameters.Add("@activo", SqlDbType.Int).Value = p_cliente.activo;
            return cmd.ExecuteNonQuery();
        }

        public static int eliminarCliente(int idCliente)
        {
            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();
            cmd.CommandText = @"UPDATE cliente SET activo = 0 WHERE id_cliente = @idCliente AND activo = 1;";
            cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;

            return cmd.ExecuteNonQuery();
        }

        public static bool ExisteEmailODni(int dni, string email, int idCliente = 0)
        {
            using var conexion = BD.BaseDeDatos.obtenerConexion();
            using var cmd = conexion.CreateCommand();
            cmd.CommandText = @"SELECT COUNT(*) FROM cliente WHERE (dni = @dni OR email = @email) AND (@idCliente = 0 OR id_cliente <> @idCliente);";
            cmd.Parameters.Add("@dni", SqlDbType.Int).Value = dni;
            cmd.Parameters.Add("@email", SqlDbType.VarChar, 200).Value = email;
            cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;

            int count = Convert.ToInt32(cmd.ExecuteScalar());
            return count > 0;
        }
    }
}