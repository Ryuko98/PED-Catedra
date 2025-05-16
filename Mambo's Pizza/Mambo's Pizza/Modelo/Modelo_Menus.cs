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

        public static DataTable MostrarHistorialMenus(int idUsuario)
        {
            int idCliente = ObtenerIdClientePorUsuario(idUsuario);

            if (idCliente == 0)
            {
                throw new Exception("El usuario no está asociado a un cliente");
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Nombre de Menu");
            dt.Columns.Add("Precio");
            dt.Columns.Add("Descripción");
            dt.Columns.Add("Veces pedido");
            dt.Columns.Add("Ultima vez pedido");

            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = @"SELECT m.NombreMenu, m.Precio, m.Descripcion, 
                           COUNT(*) AS VecesPedido, MAX(p.HoraPedido) AS UltimaVezPedido
                           FROM Menus m
                           INNER JOIN DetallesPedidos dp ON m.IdMenu = dp.IdMenu
                           INNER JOIN Pedidos p ON dp.IdPedido = p.IdPedido
                           WHERE p.IdCliente = @IdCliente
                           GROUP BY m.NombreMenu, m.Precio, m.Descripcion
                           ORDER BY VecesPedido DESC, UltimaVezPedido DESC;";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    comando.Parameters.AddWithValue("@IdCliente", idCliente);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader["NombreMenu"].ToString(),
                                reader["Precio"].ToString(),
                                reader["Descripcion"].ToString(),
                                Convert.ToInt32(reader["VecesPedido"]),
                                Convert.ToDateTime(reader["UltimaVezPedido"])
                            );
                        }
                    }
                }
            }
            return dt;
        }

        private static int ObtenerIdClientePorUsuario(int idUsuario)
        {
            int idCliente = 0;
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = "SELECT IdCliente FROM Clientes WHERE IdUsuario = @IdUsuario";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    comando.Parameters.AddWithValue("@IdUsuario", idUsuario);
                    object result = comando.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        idCliente = Convert.ToInt32(result);
                    }
                }
            }
            return idCliente;
        }
    }
}
