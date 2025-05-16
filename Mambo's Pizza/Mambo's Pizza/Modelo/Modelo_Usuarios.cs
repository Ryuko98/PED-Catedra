using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mambo_s_Pizza.Controlador;

namespace Mambo_s_Pizza.Modelo
{
    class Modelo_Usuarios
    {

        private static List<Controlador_Usuarios> articulosDeLimpieza = new List<Controlador_Usuarios>();

        public static int AgregarUsuarios(Controlador_Usuarios usuario)
        {
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = "INSERT INTO Usuarios (Nombre, Apellido, FechaNacimiento, Correo, Usuario, Contraseña, Rol) " +
                                 "VALUES (@Nombre, @Apellido, @FechaNacimiento, @Correo, @Usuario, @Contraseña, @Rol)";

                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    comando.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    comando.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    comando.Parameters.AddWithValue("@Correo", usuario.Correo);
                    comando.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                    comando.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                    comando.Parameters.AddWithValue("@Rol", usuario.Rol);

                    comando.ExecuteNonQuery();
                    msg.exitoInsercion("Tabla: Usuarios. ");
                    return 1; // Retorna 1 si se agrega correctamente
                }
                catch (SqlException ex)
                {
                    msg.errorInsercion(ex.Message, "Tabla: Usuarios. ");
                    return 0; // Retorna 0 si hay un error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }

        public static int ActualizarUsuario(Controlador_Usuarios usuario)
        {
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = @"UPDATE Usuarios 
                           SET Nombre = @Nombre, 
                               Apellido = @Apellido, 
                               FechaNacimiento = @FechaNacimiento, 
                               Correo = @Correo, 
                               Usuario = @Usuario, 
                               Contraseña = @Contraseña, 
                               Rol = @Rol 
                           WHERE IdUsuario = @IdUsuario";

                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                    comando.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                    comando.Parameters.AddWithValue("@Apellido", usuario.Apellido);
                    comando.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    comando.Parameters.AddWithValue("@Correo", usuario.Correo);
                    comando.Parameters.AddWithValue("@Usuario", usuario.Usuario);
                    comando.Parameters.AddWithValue("@Contraseña", usuario.Contraseña);
                    comando.Parameters.AddWithValue("@Rol", usuario.Rol);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    msg.exitoActualizacion("Tabla: Usuarios.");
                    return filasAfectadas; // Retorna el número de filas afectadas
                }
                catch (SqlException ex)
                {
                    msg.errorActualizacion(ex.Message, "Tabla: Usuarios.");
                    return 0; // Retorna 0 si hay un error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }
        public static int EliminarUsuario(int idUsuario)
        {
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = "DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario";
                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@IdUsuario", idUsuario);

                try
                {
                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        msg.exitoEliminacion("Tabla: Usuarios.");
                    }

                    return filasAfectadas; // Retorna el número de filas afectadas
                }
                catch (SqlException ex)
                {
                    msg.errorEliminacion(ex.Message, "Tabla: Usuarios.");
                    return 0; // Retorna 0 si hay un error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }

        public static DataTable MostrarUsuarios()
        {
            DataTable dt = new DataTable();

            // Columnas basadas en tu modelo de usuarios
            dt.Columns.Add("IdUsuario");
            dt.Columns.Add("Nombre");
            dt.Columns.Add("Apellido");
            dt.Columns.Add("FechaNacimiento", typeof(DateTime));
            dt.Columns.Add("Correo");
            dt.Columns.Add("Usuario");
            dt.Columns.Add("Contraseña");
            dt.Columns.Add("Rol");

            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = @"SELECT IdUsuario, Nombre, Apellido, FechaNacimiento, 
                        Correo, Usuario, Contraseña ,Rol FROM Usuarios";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader["IdUsuario"],
                                reader["Nombre"],
                                reader["Apellido"],
                                reader["FechaNacimiento"],
                                reader["Correo"],
                                reader["Usuario"],
                                reader["Contraseña"],
                                reader["Rol"]
                            );
                        }
                    }
                }
            }
            return dt;
        }

    }
}
