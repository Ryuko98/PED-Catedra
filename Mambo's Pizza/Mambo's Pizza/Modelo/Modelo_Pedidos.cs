using Mambo_s_Pizza.Controlador;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Modelo
{
    class Modelo_Pedidos
    {

        public static bool AgregarPedido(string pDescripcion, int pIdCliente, DateTime pHoraPedido, DateTime pHoraEntrega, int pIdRepartidor, int pIdEstadoPedido, double pTotalPrecio)
        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = @"INSERT INTO Pedidos (Descripcion, IdCliente, HoraPedido, HoraEntrega, IdRepartidor, IdEstadoPedido, TotalPrecio) 
                           VALUES (@Descripcion, @IdCliente, @HoraPedido, @HoraEntrega, @IdRepartidor, @IdEstadoPedido, @TotalPrecio)";

                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.AddWithValue("@Descripcion", pDescripcion);
                    comando.Parameters.AddWithValue("@IdCliente", pIdCliente);
                    comando.Parameters.AddWithValue("@HoraPedido", pHoraPedido);
                    comando.Parameters.AddWithValue("@HoraEntrega", (object)pHoraEntrega ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@IdRepartidor", pIdRepartidor);
                    comando.Parameters.AddWithValue("@IdEstadoPedido", pIdEstadoPedido);
                    comando.Parameters.AddWithValue("@TotalPrecio", pTotalPrecio);

                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());
                    msg.exitoInsercion("Tabla: Pedidos.");
                    return retorno;
                }
                catch (SqlException ex)
                {
                    msg.errorInsercion(ex.Message, "Tabla: Pedidos.");
                    return retorno;
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }

        public static bool ActualizarPedido(int IdPedido, string pDescripcion, int pIdCliente, DateTime pHoraPedido, DateTime pHoraEntrega, int pIdRepartidor, int pIdEstadoPedido, double pTotalPrecio)
        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = @"UPDATE Pedidos 
                           SET Descripcion = @Descripcion,
                               IdCliente = @IdCliente,
                               HoraPedido = @HoraPedido,
                               HoraEntrega = @HoraEntrega,
                               IdRepartidor = @IdRepartidor,
                               IdEstadoPedido = @IdEstadoPedido,
                               TotalPrecio = @TotalPrecio
                           WHERE IdPedido = @IdPedido";

                    SqlCommand comando = new SqlCommand(query, con);

                    comando.Parameters.AddWithValue("@IdPedido", IdPedido);
                    comando.Parameters.AddWithValue("@Descripcion", pDescripcion);
                    comando.Parameters.AddWithValue("@IdCliente", pIdCliente);
                    comando.Parameters.AddWithValue("@HoraPedido", pHoraPedido);
                    comando.Parameters.AddWithValue("@HoraEntrega", (object)pHoraEntrega ?? DBNull.Value);
                    comando.Parameters.AddWithValue("@IdRepartidor", pIdRepartidor);
                    comando.Parameters.AddWithValue("@IdEstadoPedido", pIdEstadoPedido);
                    comando.Parameters.AddWithValue("@TotalPrecio", pTotalPrecio);

                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());
                    msg.exitoActualizacion("Tabla: Pedidos.");
                    return retorno;
                }
                catch (SqlException ex)
                {
                    msg.errorActualizacion(ex.Message, "Tabla: Pedidos.");
                    return retorno;
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }

        public static bool EliminarPedido(int idPedido)
        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = "DELETE FROM Pedidos WHERE IdPedido = @IdPedido";
                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@IdPedido", idPedido);

                try
                {
                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());

                    if (retorno == true)
                    {
                        msg.exitoEliminacion("Tabla: Pedidos.");
                    }

                    return retorno;
                }
                catch (SqlException ex)
                {
                    msg.errorEliminacion(ex.Message, "Tabla: Pedidos.");
                    return retorno;
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }
        public static DataTable MostrarPedidos()
        {
            DataTable dt = new DataTable();

            // Configurar columnas
            dt.Columns.Add("IdPedido");
            dt.Columns.Add("Descripcion");
            dt.Columns.Add("Cliente");  // Nombre del cliente (desde Usuarios)
            dt.Columns.Add("HoraPedido");
            dt.Columns.Add("HoraEntrega");
            dt.Columns.Add("Repartidor");  // Nombre del repartidor
            dt.Columns.Add("EstadoPedido");  // Nombre del estado
            dt.Columns.Add("TotalPrecio");

            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = @"SELECT p.IdPedido, p.Descripcion, 
                        u.Nombre + ' ' + u.Apellido AS Cliente,
                        p.HoraPedido, p.HoraEntrega,
                        ur.Nombre AS Repartidor,
                        ep.Estado AS EstadoPedido,
                        p.TotalPrecio
                        FROM Pedidos p
                        INNER JOIN Clientes c ON p.IdCliente = c.IdCliente
                        INNER JOIN Usuarios u ON c.IdUsuario = u.IdUsuario
                        LEFT JOIN Repartidores r ON p.IdRepartidor = r.IdRepartidor
                        LEFT JOIN Usuarios ur ON r.IdUsuario = ur.IdUsuario
                        INNER JOIN EstadosPedidos ep ON p.IdEstadoPedido = ep.IdEstadoPedido";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader["IdPedido"],
                                reader["Descripcion"],
                                reader["Cliente"],
                                reader["HoraPedido"],
                                reader["HoraEntrega"],
                                reader["Repartidor"] ,
                                reader["EstadoPedido"],
                                reader["TotalPrecio"]
                            );
                        }
                    }
                }
            }
            return dt;
        }

        public static DataTable MostrarClientes()
        {
            DataTable dt = new DataTable();

            // Columnas solicitadas
            dt.Columns.Add("IdCliente", typeof(int));
            dt.Columns.Add("NombreUsuario", typeof(string)); // Nombre del usuario asociado

            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = @"SELECT c.IdCliente, u.Nombre + ' ' + u.Apellido AS NombreUsuario
                        FROM Clientes c
                        INNER JOIN Usuarios u ON c.IdUsuario = u.IdUsuario
                        ORDER BY u.Nombre";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader.GetInt32(0),     // IdCliente
                                reader.GetString(1)     // NombreUsuario (Nombre + Apellido)
                            );
                        }
                    }
                }
            }
            return dt;
        }

        public static DataTable MostrarRepartidor()
        {
            DataTable dt = new DataTable();

            // Configurar columnas
            dt.Columns.Add("IdRepartidor", typeof(int));
            dt.Columns.Add("IdUsuario", typeof(string));

            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = @"SELECT r.IdRepartidor, u.Nombre + ' ' + u.Apellido AS NombreRepartidor
                        FROM Repartidores r
                        INNER JOIN Usuarios u ON r.IdUsuario = u.IdUsuario
                        ORDER BY u.Nombre";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader.GetInt32(0),    // IdRepartidor
                                reader.GetString(1)    // NombreRepartidor
                            );
                        }
                    }
                }
            }
            return dt;
        }

        public static DataTable MostrarEstados()
        {
            DataTable dt = new DataTable();

            // Configurar columnas
            dt.Columns.Add("IdEstadoPedido", typeof(int));
            dt.Columns.Add("Estado", typeof(string));

            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = @"SELECT IdEstadoPedido, Estado 
                        FROM EstadosPedidos 
                        ORDER BY Estado";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader.GetInt32(0),    // IdEstadoRepartidor
                                reader.GetString(1)    // NombreEstado
                            );
                        }
                    }
                }
            }
            return dt;
        }

        public static List<string> VerificarCarrito(int idCliente)
        {
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();
            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                List<string> lista = new List<string>();
                try
                {
                    string query = "SELECT * FROM [Pedidos] WHERE [IdCliente] = @idCliente AND [IdEstadoPedido] = 1";
                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.Add(new SqlParameter("@idCliente", idCliente));
                    SqlDataReader reader = comando.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        //Carrito no existia, por lo tanto hay que crearlo
                        return lista;
                    }

                    while (reader.Read())
                    {
                        //Carrito ya existe
                        lista.Add(reader["idPedido"].ToString());
                        lista.Add(reader["Descripcion"].ToString());
                        lista.Add(reader["IdCliente"].ToString());
                        lista.Add(reader["HoraPedido"].ToString());
                        lista.Add(reader["HoraEntrega"].ToString());
                        lista.Add(reader["IdRepartidor"].ToString());
                        lista.Add(reader["IdEstadoPedido"].ToString());
                        lista.Add(reader["TotalPrecio"].ToString());
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

        // Metodo para crear carrito 

        public static int CrearCarrito(int pIdCliente)
        {
            int id = 0;
            Conexion conexionBD = new Conexion();
            mensajes msg = new mensajes();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = @"INSERT INTO [Pedidos] ([Descripcion], [IdCliente], [HoraPedido], 
                                       [HoraEntrega], [IdRepartidor], [IdEstadoPedido], [TotalPrecio]) 
                                        VALUES (NULL, @IdCliente, NULL, NULL, NULL, 1, 0);
                                        SELECT SCOPE_IDENTITY();"; // Esto devuelve el ID recién insertado

                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.AddWithValue("@IdCliente", pIdCliente);

                    object resultado = comando.ExecuteScalar(); // Usamos ExecuteScalar para obtener el ID

                    if (resultado != null)
                    {
                        id = Convert.ToInt32(resultado);
                    }
                    return id;
                }
                catch (SqlException ex)
                {
                    msg.errorInsercion(ex.Message, "Carrito");
                    return 0; // Devuelve 0 si hubo error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }


        public static DataTable CargarCarrito(int idPedido)
        {
            DataTable dt = new DataTable();
            // Columnas de la Tabla
            dt.Columns.Add("Nombre Menu", typeof(string));
            dt.Columns.Add("Cantidad Total", typeof(int));
            dt.Columns.Add("Precio Unitario", typeof(decimal));
            dt.Columns.Add("SubTotal", typeof(decimal));
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = @"SELECT M.NombreMenu, SUM(DP.Cantidad) AS CantidadTotal,
                                    DP.PrecioUnitario, SUM(DP.Cantidad * DP.PrecioUnitario) AS Subtotal FROM DetallesPedidos DP
                                    INNER JOIN Menus M ON DP.IdMenu = M.IdMenu WHERE DP.IdPedido = @idPedido 
                                    GROUP BY M.NombreMenu, DP.PrecioUnitario";

                    using (SqlCommand comando = new SqlCommand(query, con))
                    {
                        comando.Parameters.AddWithValue("@idPedido", idPedido);

                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                // No hay registros, simplemente devuelve el DataTable vacío
                                return dt;
                            }
                            while (reader.Read())
                            {
                                dt.Rows.Add(
                                reader["NombreMenu"],
                                reader["CantidadTotal"],
                                reader["PrecioUnitario"],
                                reader["Subtotal"]
                                );
                            }
                        }
                    }
                    return dt;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al obtener detalles del pedido: " + ex.Message);
                    return null;
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }

        }


        public static List<string> CarritoFinalizado(int idCliente)
        {
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();
            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                List<string> lista = new List<string>();
                try
                {
                    string query = "SELECT * FROM [Pedidos] WHERE [IdCliente] = @idCliente AND ([IdEstadoPedido] = 2 OR [IdEstadoPedido] = 3)";
                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.Add(new SqlParameter("@idCliente", idCliente));
                    SqlDataReader reader = comando.ExecuteReader();

                    if (!reader.HasRows)
                    {
                        //Carrito no existia, por lo tanto hay que crearlo
                        return lista;
                    }

                    while (reader.Read())
                    {
                        //Carrito ya existe
                        lista.Add(reader["idPedido"].ToString());
                        lista.Add(reader["Descripcion"].ToString());
                        lista.Add(reader["IdCliente"].ToString());
                        lista.Add(reader["HoraPedido"].ToString());
                        lista.Add(reader["HoraEntrega"].ToString());
                        lista.Add(reader["IdRepartidor"].ToString());
                        lista.Add(reader["IdEstadoPedido"].ToString());
                        lista.Add(reader["TotalPrecio"].ToString());
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


        public static string ObtenerDescripcion(int idpedido)
        {
            string descripcion = "";
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = "SELECT Descripcion FROM [Pedidos] WHERE IdPedido = @idPedido";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    comando.Parameters.AddWithValue("@idPedido", idpedido);
                    object result = comando.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        descripcion = Convert.ToString(result);
                    }
                }
            }
            return descripcion;
        }
        public static string ObtenerTotal(int idpedido)
        {
            string total = "";
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = "SELECT SUM(m.Precio * dp.Cantidad) AS TotalPedido FROM DetallesPedidos dp " +
                    "JOIN Menus m ON dp.IdMenu = m.IdMenu WHERE dp.IdPedido = @idPedido";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    comando.Parameters.AddWithValue("@idPedido", idpedido);
                    object result = comando.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        total = Convert.ToString(result);
                    }
                }
            }
            return total;
        }

        public static bool FinalizarPedido(int IdPedido, string pDescripcion, DateTime pHoraPedido, double pTotalPrecio)
        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = @"UPDATE Pedidos 
                           SET Descripcion = @Descripcion,
                               HoraPedido = @HoraPedido,
                               IdEstadoPedido = 2,
                               TotalPrecio = @TotalPrecio
                           WHERE IdPedido = @IdPedido";

                    SqlCommand comando = new SqlCommand(query, con);

                    comando.Parameters.AddWithValue("@IdPedido", IdPedido);
                    comando.Parameters.AddWithValue("@Descripcion", pDescripcion);
                    comando.Parameters.AddWithValue("@HoraPedido", pHoraPedido);
                    comando.Parameters.AddWithValue("@TotalPrecio", pTotalPrecio);

                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());
                    return retorno;
                }
                catch (SqlException ex)
                {
                    msg.errorActualizacion(ex.Message, "Tabla: Pedidos.");
                    return retorno;
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }


    }
}
