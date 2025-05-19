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
            dt.Columns.Add("IdMenu");
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
                                reader["IdMenu"],
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
            //dt.Columns.Add("Ultima vez pedido");

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
                                Convert.ToInt32(reader["VecesPedido"])
                                //,Convert.ToDateTime(reader["UltimaVezPedido"])
                            );
                        }
                    }
                }
            }
            return dt;
        }

        public static int ObtenerIdClientePorUsuario(int idUsuario)
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

        public static bool AgregarMenus(string mNombreMenu, float mPrecio, string mDescripcion)

        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = "INSERT INTO Menus (NombreMenu, Precio, Descripcion) " +
                                 "VALUES (@Nombre, @Precio, @Descripcion)";

                    SqlCommand comando = new SqlCommand(query, con);

                    comando.Parameters.AddWithValue("@Nombre", mNombreMenu);
                    comando.Parameters.AddWithValue("@Precio", mPrecio);
                    comando.Parameters.AddWithValue("@Descripcion", mDescripcion);

                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());
                    msg.exitoInsercion("Tabla: Menus. ");
                    return retorno; // Retorna 1 si se agrega correctamente
                }
                catch (SqlException ex)
                {
                    msg.errorInsercion(ex.Message, "Tabla: Menus. ");
                    return retorno; // Retorna 0 si hay un error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }

        public static bool ActualizarMenu(int mIdMenu, string mNombreMenu, float mPrecio, string mDescripcion)
        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = @"UPDATE Menus 
                   SET NombreMenu = @Nombre, 
                       Precio = @Precio, 
                       Descripcion = @Descripcion
                   WHERE IdMenu = @IdMenu";

                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.AddWithValue("@IdMenu", mIdMenu);
                    comando.Parameters.AddWithValue("@Nombre", mNombreMenu);
                    comando.Parameters.AddWithValue("@Precio", mPrecio);
                    comando.Parameters.AddWithValue("@Descripcion", mDescripcion);

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

        public static bool EliminarMenu(int idMenu)
        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = "DELETE FROM Menus WHERE IdMenu = @IdMenu";
                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.AddWithValue("@IdMenu", idMenu);
                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());
                    return retorno;

                }
                catch (SqlException ex)
                {
                    msg.errorEliminacion(ex.Message, "Tabla: Menus.");
                    return retorno = false; // Retorna 0 si hay un error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }


        public static List<string> DatosMenu(int idMenu)
        {
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();
            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                List<string> lista = new List<string>();
                string a, b, c;
                try
                {
                    string query = "SELECT [IdMenu],[NombreMenu],[Precio],[Descripcion] FROM [Menus] WHERE idMenu = @idMenu";
                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.Add(new SqlParameter("@idMenu", idMenu));
                    SqlDataReader reader = comando.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        Console.WriteLine("No se encontraron resultados para el menu con id: " + idMenu);
                        return lista;
                    }

                    while (reader.Read())
                    {
                        lista.Add(reader["idMenu"].ToString());
                        lista.Add(reader["NombreMenu"].ToString());
                        lista.Add(reader["Precio"].ToString());
                        lista.Add(reader["Descripcion"].ToString());
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
    }
}
