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
    }
}
