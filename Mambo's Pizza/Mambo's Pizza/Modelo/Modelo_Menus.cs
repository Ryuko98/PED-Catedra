using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Modelo
{
    public class Modelo_Menus
    {
        public static DataTable MostrarMenus()
        {
            DataTable dt = new DataTable();

            // Columnas basadas en tu modelo de usuarios
            //dt.Columns.Add("IdMenu");
            dt.Columns.Add("Nombre de Menu");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Descripción");

            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = @"SELECT IdMenu, NombreMenu, Precio, Descripcion FROM Menus";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader["NombreMenu"],
                                reader["Precio"],
                                reader["Descripcion"]
                            );
                        }
                    }
                }
            }
            return dt;
        }

    }
}
