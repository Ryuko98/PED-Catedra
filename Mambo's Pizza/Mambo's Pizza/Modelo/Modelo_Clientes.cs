using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mambo_s_Pizza.Modelo
{
    public class Modelo_Clientes
    {
        public static DataTable MostrarClientes()
        {
            DataTable dt = new DataTable();

            // Columnas basadas en tu modelo de usuarios
            dt.Columns.Add("IdCliente");
            dt.Columns.Add("IdUsuario");
            dt.Columns.Add("Direccion");
            dt.Columns.Add("IdMembresia");
            dt.Columns.Add("FechaExpiracion");

            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = @"SELECT IdCliente, IdUsuario, Direccion, IdMembresia, FechaExpiracion FROM Clientes";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader["IdCliente"],
                                reader["IdUsuario"],
                                reader["Direccion"],
                                reader["IdMembresia"],
                                reader["FechaExpiracion"]
                            );
                        }
                    }
                }
            }
            return dt;
        }

    }
}
