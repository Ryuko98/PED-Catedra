using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Modelo
{
    public class Modelo_Membresias
    {
        public static DataTable MostrarMembresias()
        {
            DataTable dt = new DataTable();

            // Columnas basadas en tu modelo de usuarios
            dt.Columns.Add("IdMembresia");
            dt.Columns.Add("Membresia");
            dt.Columns.Add("Descripcion");

            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = "SELECT * FROM Membresias";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader["IdMembresia"],
                                reader["Membresia"],
                                reader["Descripcion"]
                            );
                        }
                    }
                }
            }
            return dt;
        }

        public static bool AgregarMembresia(string pMembresia, string pDescripcion)
        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = "INSERT INTO Membresias (Membresia, Descripcion) " +
                                 "VALUES (@Membresia, @Descripcion)";

                    SqlCommand comando = new SqlCommand(query, con);

                    comando.Parameters.AddWithValue("@Membresia", pMembresia);
                    comando.Parameters.AddWithValue("@Descripcion", pDescripcion);

                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());
                    msg.exitoInsercion("Tabla: Membresias. ");
                    return retorno; // Retorna 1 si se agrega correctamente
                }
                catch (SqlException ex)
                {
                    msg.errorInsercion(ex.Message, "Tabla: Membresias. ");
                    return retorno; // Retorna 0 si hay un error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }
        public static bool ActualizarMembresia(int pIdMembresia, string pMembresia, string pDescripcion)
        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = @"UPDATE Membresias 
                   SET Membresia = @Membresia, 
                       Descripcion = @Descripcion
                   WHERE idMembresia = @idMembresia";

                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.AddWithValue("@IdMembresia", pIdMembresia);
                    comando.Parameters.AddWithValue("@Membresia", pMembresia);
                    comando.Parameters.AddWithValue("@Descripcion", pDescripcion);

                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());
                    msg.exitoActualizacion("Tabla: Membresias.");
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

        public static bool EliminarMembresia(int idMembresia)
        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = "DELETE FROM Membresias WHERE IdMembresia = @IdMembresia";
                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.AddWithValue("@IdMembresia", idMembresia);
                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());
                    return retorno;

                }
                catch (SqlException ex)
                {
                    msg.errorEliminacion(ex.Message, "Tabla: Membresias.");
                    return retorno = false; // Retorna 0 si hay un error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }
    }
}
