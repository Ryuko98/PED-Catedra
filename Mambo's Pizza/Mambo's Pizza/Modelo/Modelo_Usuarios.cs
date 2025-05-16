using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mambo_s_Pizza.Controlador;
using System.Drawing;

namespace Mambo_s_Pizza.Modelo
{
    class Modelo_Usuarios
    {

        private static List<Modelo_Usuarios> articulosDeLimpieza = new List<Modelo_Usuarios>();

        public static int AgregarUsuarios(string Nombre, string Apellido, DateTime FechaNacimiento, string Correo, string Usuario, string Contraseña, string Rol)

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

                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.Parameters.AddWithValue("@Apellido", Apellido);
                    comando.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
                    comando.Parameters.AddWithValue("@Correo", Correo);
                    comando.Parameters.AddWithValue("@Usuario", Usuario);
                    comando.Parameters.AddWithValue("@Contraseña", Contraseña);
                    comando.Parameters.AddWithValue("@Rol", Rol);


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

        public static int ActualizarUsuario(string Nombre, string Apellido, DateTime FechaNacimiento, string Correo, string Usuario, string Contraseña, string Rol, int IdUsuario)
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

                    comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.Parameters.AddWithValue("@Apellido", Apellido);
                    comando.Parameters.AddWithValue("@FechaNacimiento", FechaNacimiento);
                    comando.Parameters.AddWithValue("@Correo", Correo);
                    comando.Parameters.AddWithValue("@Usuario", Usuario);
                    comando.Parameters.AddWithValue("@Contraseña", Contraseña);
                    comando.Parameters.AddWithValue("@Rol", Rol);


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
        public static int IniciarSesion(string Usuario, string Contraseña)
        {
            int retorno = 0;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();
            Controlador_Usuarios controlador_Usuarios = new Controlador_Usuarios();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = "SELECT IdUsuario, Rol FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña";
                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@Usuario", Usuario);
                comando.Parameters.AddWithValue("@Contraseña", Contraseña);

                try
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                           controlador_Usuarios.IdUsuario = Convert.ToInt32( reader["IdUsuario"]);
                           controlador_Usuarios.Rol =  reader["Rol"].ToString();
                        }
                        msg.exitoInicioSesion();
                        return 1;

                    }
                   

                }
                catch (SqlException ex)
                {
                    msg.errorInicioSesion(ex.Message);
                    return 0; // Retorna 0 si hay un error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }

        //public static int GuardarUsuario(int Id)
        //{
        //    mensajes msg = new mensajes();
        //    Conexion conexionBD = new Conexion();
        //    Controlador_Usuarios controlador_Usuarios = new Controlador_Usuarios();

        //    using (SqlConnection con = conexionBD.AbrirConexion())
        //    {
        //        string query = "SELECT Rol FROM Usuarios WHERE IdUsuario = @IdUsuario";
        //        SqlCommand comando = new SqlCommand(query, con);
        //    }
        //}
    }
}
