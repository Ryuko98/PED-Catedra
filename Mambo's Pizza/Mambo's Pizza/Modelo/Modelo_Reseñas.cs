using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Modelo
{
    public class Modelo_Reseñas
    {
        public static DataTable MostrarReseñas()
        {
            DataTable dt = new DataTable();

            // Columnas basadas en tu modelo de usuarios
            dt.Columns.Add("IdReview");
            dt.Columns.Add("IdRepartidor");
            dt.Columns.Add("IdPedido");
            dt.Columns.Add("Calificacion");
            dt.Columns.Add("Comentario");
            dt.Columns.Add("FechaReview", typeof(DateTime));

            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = "SELECT * FROM Reviews";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader["IdReview"],
                                reader["IdRepartidor"],
                                reader["IdPedido"],
                                reader["Calificacion"],
                                reader["Comentario"],
                                reader["FechaReview"]
                            );
                        }
                    }
                }
            }
            return dt;
        }

        public static bool AgregarReseña(int pIdRepartidor, int pIdPedido, int pCalificacion, string pComentario, DateTime pFechaReview)

        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = "INSERT INTO Reviews (IdRepartidor, IdPedido, Calificacion, Comentario, FechaReview) " +
                                 "VALUES (@IdRepartidor, @IdPedido, @Calificacion, @Comentario, @FechaReview)";

                    SqlCommand comando = new SqlCommand(query, con);

                    comando.Parameters.AddWithValue("@IdRepartidor", pIdRepartidor);
                    comando.Parameters.AddWithValue("@IdPedido", pIdPedido);
                    comando.Parameters.AddWithValue("@Calificacion", pCalificacion);
                    comando.Parameters.AddWithValue("@Comentario", pComentario);
                    comando.Parameters.AddWithValue("@FechaReview", pFechaReview);

                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());
                    msg.exitoInsercion("Tabla: Reviews. ");
                    return retorno; // Retorna 1 si se agrega correctamente
                }
                catch (SqlException ex)
                {
                    msg.errorInsercion(ex.Message, "Tabla: Reviews. ");
                    return retorno; // Retorna 0 si hay un error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }
        public static bool EliminarReseña(int idReview)
        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = "DELETE FROM Reviews WHERE IdReview = @IdReview";
                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.AddWithValue("@IdReview", idReview);
                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());
                    return retorno;

                }
                catch (SqlException ex)
                {
                    msg.errorEliminacion(ex.Message, "Tabla: Reviews.");
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
