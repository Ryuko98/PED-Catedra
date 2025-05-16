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
    class Modelo_Repartidores
    {
        private static List<Controlador_Repartidores> articulosDeLimpieza = new List<Controlador_Repartidores>();

        public static int AgregarRepartidor(Controlador_Repartidores repartidor)
        {
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = "INSERT INTO Repartidores (DUI, CalificacionPromedio, TotalCalificaciones, FechaRegistro, IdUsuario, Disponibilidad) " +
                                 "VALUES (@DUI, @CalificacionPromedio, @TotalCalificaciones, @FechaRegistro, @IdUsuario, @Disponibilidad)";

                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.AddWithValue("@DUI", repartidor.DUI);
                    comando.Parameters.AddWithValue("@CalificacionPromedio", repartidor.CalificacionPromedio);
                    comando.Parameters.AddWithValue("@TotalCalificaciones", repartidor.TotalCalificaciones);
                    comando.Parameters.AddWithValue("@FechaRegistro", repartidor.FechaRegistro);
                    comando.Parameters.AddWithValue("@IdUsuario", repartidor.IdUsuario);
                    comando.Parameters.AddWithValue("@Disponibilidad", repartidor.Disponibilidad);

                    comando.ExecuteNonQuery();
                    msg.exitoInsercion("Tabla: Repartidores. ");
                    return 1; // Retorna 1 si se agrega correctamente
                }
                catch (SqlException ex)
                {
                    msg.errorInsercion(ex.Message, "Tabla: Repartidores. ");
                    return 0; // Retorna 0 si hay un error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }

        public static int ActualizarRepartidor(Controlador_Repartidores repartidor)
        {
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = @"UPDATE Repartidores 
                   SET DUI = @DUI, 
                       CalificacionPromedio = @CalificacionPromedio, 
                       TotalCalificaciones = @TotalCalificaciones, 
                       FechaRegistro = @FechaRegistro, 
                       IdUsuario = @IdUsuario, 
                       Disponibilidad = @Disponibilidad 
                   WHERE IdRepartidor = @IdRepartidor";

                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.AddWithValue("@IdRepartidor", repartidor.IdRepartidor);
                    comando.Parameters.AddWithValue("@DUI", repartidor.DUI);
                    comando.Parameters.AddWithValue("@CalificacionPromedio", repartidor.CalificacionPromedio);
                    comando.Parameters.AddWithValue("@TotalCalificaciones", repartidor.TotalCalificaciones);
                    comando.Parameters.AddWithValue("@FechaRegistro", repartidor.FechaRegistro);
                    comando.Parameters.AddWithValue("@IdUsuario", repartidor.IdUsuario);
                    comando.Parameters.AddWithValue("@Disponibilidad", repartidor.Disponibilidad);

                    int filasAfectadas = comando.ExecuteNonQuery();
                    msg.exitoActualizacion("Tabla: Repartidores.");
                    return filasAfectadas; // Retorna el número de filas afectadas
                }
                catch (SqlException ex)
                {
                    msg.errorActualizacion(ex.Message, "Tabla: Repartidores.");
                    return 0; // Retorna 0 si hay un error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }
        public static int EliminarRepartidor(int idRepartidor)
        {
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = "DELETE FROM Repartidores WHERE IdRepartidor = @IdRepartidor";
                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@IdRepartidor", idRepartidor);

                try
                {
                    int filasAfectadas = comando.ExecuteNonQuery();

                    if (filasAfectadas > 0)
                    {
                        msg.exitoEliminacion("Tabla: Repartidores.");
                    }

                    return filasAfectadas; // Retorna el número de filas afectadas
                }
                catch (SqlException ex)
                {
                    msg.errorEliminacion(ex.Message, "Tabla: Repartidores.");
                    return 0; // Retorna 0 si hay un error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }
        public static DataTable MostrarRepartidores()
        {
            DataTable dt = new DataTable();

            // Columnas basadas en la tabla Repartidores
            dt.Columns.Add("IdRepartidor");
            dt.Columns.Add("DUI");
            dt.Columns.Add("CalificacionPromedio");
            dt.Columns.Add("TotalCalificaciones");
            dt.Columns.Add("FechaRegistro");
            dt.Columns.Add("IdUsuario");
            dt.Columns.Add("Disponibilidad");

            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = @"SELECT r.IdRepartidor, r.DUI, r.CalificacionPromedio, 
                        r.TotalCalificaciones, r.FechaRegistro, 
                        u.Usuario, r.Disponibilidad 
                        FROM Repartidores r
                        INNER JOIN Usuarios u ON r.IdUsuario = u.IdUsuario";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader["IdRepartidor"],
                                reader["DUI"],
                                reader["CalificacionPromedio"],
                                reader["TotalCalificaciones"],
                                reader["FechaRegistro"],
                                reader["Usuario"],
                                reader["Disponibilidad"]
                            );
                        }
                    }
                }
            }
            return dt;
        }
        public static DataTable MostrarUsuarios()
        {
            DataTable dt = new DataTable();

            // Definir columnas con tipos de datos específicos
            dt.Columns.Add("IdUsuario", typeof(int));
            dt.Columns.Add("Nombre", typeof(string));

            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = @"SELECT IdUsuario, Nombre 
                       FROM Usuarios 
                       ORDER BY Nombre";

                SqlCommand comando = new SqlCommand(query, con);

                using (SqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dt.Rows.Add(
                            reader.GetInt32(0),    // IdUsuario
                            reader.GetString(1)    // Nombre
                        );
                    }
                }
            }
            return dt;
        }
    }
}
