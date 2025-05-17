using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mambo_s_Pizza.Controlador;
using System.Drawing;
using System.Security.Cryptography;

namespace Mambo_s_Pizza.Modelo
{
    class Modelo_Usuarios
    {

        private static List<Modelo_Usuarios> articulosDeLimpieza = new List<Modelo_Usuarios>();

        public static bool AgregarUsuarios(string pNombre, string pApellido, DateTime pFechaNacimiento, string pCorreo, string pUsuario, string pContraseña, string pRol)

        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = "INSERT INTO Usuarios (Nombre, Apellido, FechaNacimiento, Correo, Usuario, Contraseña, Rol) " +
                                 "VALUES (@Nombre, @Apellido, @FechaNacimiento, @Correo, @Usuario, @Contraseña, @Rol)";

                    SqlCommand comando = new SqlCommand(query, con);

                    comando.Parameters.AddWithValue("@Nombre", pNombre);
                    comando.Parameters.AddWithValue("@Apellido", pApellido);
                    comando.Parameters.AddWithValue("@FechaNacimiento", pFechaNacimiento);
                    comando.Parameters.AddWithValue("@Correo", pCorreo);
                    comando.Parameters.AddWithValue("@Usuario", pUsuario);
                    comando.Parameters.AddWithValue("@Contraseña", pContraseña);
                    comando.Parameters.AddWithValue("@Rol", pRol);

                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());
                    msg.exitoInsercion("Tabla: Usuarios. ");
                    return retorno; // Retorna 1 si se agrega correctamente
                }
                catch (SqlException ex)
                {
                    msg.errorInsercion(ex.Message, "Tabla: Usuarios. ");
                    return retorno; // Retorna 0 si hay un error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }

        public static bool ActualizarUsuario(int pIdUsuario, string pNombre, string pApellido, DateTime pFechaNacimiento, string pCorreo, string pUsuario, string pContraseña, string pRol)
        {
            bool retorno = false;
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
                   WHERE idUsuario = @idUsuario";

                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.AddWithValue("@idUsuario", pIdUsuario);
                    comando.Parameters.AddWithValue("@Nombre", pNombre);
                    comando.Parameters.AddWithValue("@Apellido", pApellido);
                    comando.Parameters.AddWithValue("@FechaNacimiento", pFechaNacimiento);
                    comando.Parameters.AddWithValue("@Correo", pCorreo);
                    comando.Parameters.AddWithValue("@Usuario", pUsuario);
                    comando.Parameters.AddWithValue("@Contraseña", pContraseña);
                    comando.Parameters.AddWithValue("@Rol", pRol);

                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());
                    msg.exitoActualizacion("Tabla: Repartidores.");
                    return retorno; // Retorna el número de filas afectadas
                }
                catch (SqlException ex)
                {
                    return retorno; // Retorna 0 si hay un error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }
        public static bool EliminarUsuario(int idUsuario)
        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                

                try
                {
                    string query = "DELETE FROM Usuarios WHERE IdUsuario = @IdUsuario";
                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    retorno = Convert.ToBoolean( comando.ExecuteNonQuery());
                    return retorno;
                    
                }
                catch (SqlException ex)
                {
                    msg.errorEliminacion(ex.Message, "Tabla: Usuarios.");
                    return retorno = false; // Retorna 0 si hay un error
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
                string query = "SELECT * FROM Usuarios";

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
        public static bool IniciarSesion(string Usuario, string Contraseña)
        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
              
                try
                {
                    string query = "SELECT * FROM Usuarios WHERE Usuario = @Usuario AND Contraseña = @Contraseña";
                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.AddWithValue("@Usuario", Usuario);
                    comando.Parameters.AddWithValue("@Contraseña", Contraseña);
                    if (comando.ExecuteScalar() == null)
                    {
                        return retorno;
                    }
                    else
                    {
                        retorno = Convert.ToBoolean(comando.ExecuteScalar());
                        return retorno;
                    }
                }
                catch (SqlException ex)
                {
                    msg.errorInicioSesion(ex.Message);
                    return retorno; // Retorna 0 si hay un error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }

        public static List<string> DatosUsuario(string usuario)
        {
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();
            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                List<string> lista = new List<string>();
                string a, b, c;
                try
                {
                    string query = "SELECT IdUsuario, Nombre, Rol FROM Usuarios WHERE Usuario = @Usuario";
                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.Add(new SqlParameter("@Usuario",usuario));
                    SqlDataReader reader = comando.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No se encontraron resultados para el usuario: " + usuario);
                        return lista;
                    }

                    while (reader.Read())
                    {
                        lista.Add(reader["IdUsuario"].ToString());
                        lista.Add(reader["Nombre"].ToString());
                        lista.Add(reader["Rol"].ToString());
                    }

                    return lista;

                }

                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                    return null;
                }

            }

        }

        public static bool Registro(string pNombre, string pApellido, DateTime pFechaNacimiento, string pCorreo, string pUsuario, string pContraseña, string pRol)

        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = "INSERT INTO Usuarios (Nombre, Apellido, FechaNacimiento, Correo, Usuario, Contraseña, Rol) " +
                                 "VALUES (@Nombre, @Apellido, @FechaNacimiento, @Correo, @Usuario, @Contraseña, @Rol)";

                    SqlCommand comando = new SqlCommand(query, con);

                    comando.Parameters.AddWithValue("@Nombre", pNombre);
                    comando.Parameters.AddWithValue("@Apellido", pApellido);
                    comando.Parameters.AddWithValue("@FechaNacimiento", pFechaNacimiento);
                    comando.Parameters.AddWithValue("@Correo", pCorreo);
                    comando.Parameters.AddWithValue("@Usuario", pUsuario);
                    comando.Parameters.AddWithValue("@Contraseña", pContraseña);
                    comando.Parameters.AddWithValue("@Rol", pRol);

                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());
                    return retorno; // Retorna 1 si se agrega correctamente
                }
                catch (SqlException ex)
                {
                    msg.errorInsercion(ex.Message, "Tabla: Usuarios. ");
                    return retorno; // Retorna 0 si hay un error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }
    }
}
