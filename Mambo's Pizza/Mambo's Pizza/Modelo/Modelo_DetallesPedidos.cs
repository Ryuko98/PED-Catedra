using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Modelo
{
    public class Modelo_DetallesPedidos
    {
        public static bool AgregarDetallePedido(int pIdPedido, int pIdMenu, int pCantidad, decimal pPrecioUnitario)

        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = "INSERT INTO DetallesPedidos ([IdPedido], [IdMenu], [Cantidad], [PrecioUnitario]) " +
                                 "VALUES (@IdPedido, @IdMenu, @Cantidad, @PrecioUnitario)";

                    SqlCommand comando = new SqlCommand(query, con);

                    comando.Parameters.AddWithValue("@IdPedido", pIdPedido);
                    comando.Parameters.AddWithValue("@IdMenu", pIdMenu);
                    comando.Parameters.AddWithValue("@Cantidad", pCantidad);
                    comando.Parameters.AddWithValue("@PrecioUnitario", pPrecioUnitario);

                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());
                    //msg.exitoInsercion("Tabla: DetallePedido. ");
                    return retorno; // Retorna 1 si se agrega correctamente
                }
                catch (SqlException ex)
                {
                    msg.errorInsercion(ex.Message, " Tabla: DetallePedido. ");
                    return retorno; // Retorna 0 si hay un error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }

        public static bool ActualizarDetallePedido(int pIdDetallePedido, int pIdPedido, int pIdMenu, int pCantidad, decimal pPrecioUnitario)
        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = @"UPDATE DetallesPedidos 
                   SET IdPedido = @IdPedido,
                       IdMenu = @IdMenu,
                       Cantidad = @Cantidad,
                       PrecioUnitario = @PrecioUnitario
                   WHERE IdDetallePedido = @IdDetallePedido";

                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.AddWithValue("@IdDetallePedido", pIdDetallePedido);
                    comando.Parameters.AddWithValue("@IdPedido", pIdPedido);
                    comando.Parameters.AddWithValue("@IdMenu", pIdMenu);
                    comando.Parameters.AddWithValue("@Cantidad", pCantidad);
                    comando.Parameters.AddWithValue("@PrecioUnitario", pPrecioUnitario);

                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());
                    msg.exitoActualizacion("Tabla: DetallesPedidos.");
                    return retorno;
                }
                catch (SqlException ex)
                {
                    // Manejo especial para error de FK (si los menús o pedidos no existen)
                    if (ex.Number == 547) // FK constraint violation
                    {
                        msg.errorActualizacion("El menú o pedido asociado no existe", "Tabla: DetallesPedidos.");
                    }
                    else
                    {
                        msg.errorActualizacion(ex.Message, "Tabla: DetallesPedidos.");
                    }
                    return retorno;
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }
        public static bool EliminarDetallePedido(int idDetallePedido)
        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = "DELETE FROM DetallesPedidos WHERE IdDetallePedido = @IdDetallePedido";
                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@IdDetallePedido", idDetallePedido);

                try
                {
                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());

                    if (retorno)
                    {
                        msg.exitoEliminacion("Tabla: DetallesPedidos.");
                    }

                    return retorno;
                }
                catch (SqlException ex)
                {
                    // Manejo especial para error de integridad referencial
                    if (ex.Number == 547) // FK constraint violation
                    {
                        msg.errorEliminacion("No se puede eliminar - existe información relacionada", "Tabla: DetallesPedidos.");
                    }
                    else
                    {
                        msg.errorEliminacion(ex.Message, "Tabla: DetallesPedidos.");
                    }
                    return retorno;
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }
        public static DataTable MostrarDetallesPedidos()
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new Conexion().AbrirConexion())
            {
                string query = @"SELECT 
                            dp.IdDetallePedido AS ID_Detalle,
                            p.Descripcion AS Descripcion_Pedido, 
                            m.NombreMenu AS Nombre_Menu,
                            dp.Cantidad,
                            dp.PrecioUnitario,
                            (dp.Cantidad * dp.PrecioUnitario) AS Subtotal
                        FROM DetallesPedidos dp
                        INNER JOIN Pedidos p ON dp.IdPedido = p.IdPedido
                        INNER JOIN Menus m ON dp.IdMenu = m.IdMenu";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        // Crear columnas automáticamente desde el reader
                        for (int i = 0; i < dr.FieldCount; i++)
                        {
                            dt.Columns.Add(dr.GetName(i), dr.GetFieldType(i));
                        }

                        while (dr.Read())
                        {
                            DataRow row = dt.NewRow();
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                row[i] = dr.IsDBNull(i) ? DBNull.Value : dr.GetValue(i);
                            }
                            dt.Rows.Add(row);
                        }
                    }
                }
            }
            return dt;
        }

        public static DataTable MostrarPedidos()
        {
            DataTable dt = new DataTable();

            // Columnas básicas de pedidos
            dt.Columns.Add("IdPedido", typeof(int));
            dt.Columns.Add("Descripcion", typeof(string));

            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = "SELECT IdPedido, Descripcion FROM Pedidos";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader.GetInt32(0),    // IdPedido
                                reader.IsDBNull(1) ? string.Empty : reader.GetString(1) // Description (con manejo de NULL)
                            );
                        }
                    }
                }
            }
            return dt;
        }

        public static DataTable MostrarMenus()
        {
            DataTable dt = new DataTable();

            // Columnas básicas de menús
            dt.Columns.Add("IdMenu", typeof(int));
            dt.Columns.Add("NombreMenu", typeof(string));

            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = "SELECT IdMenu, NombreMenu FROM Menus";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader.GetInt32(0),    // IdMenu
                                reader.GetString(1)    // NombreMenu
                            );
                        }
                    }
                }
            }
            return dt;
        }


        public static bool AgregarDetalleCarrito(int pIdPedido, int pIdMenu, int pCantidad)
        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                // Proceso de creacion de detalle y calculo de subtotal
                try
                {
                    // Obtener el precio del menú seleccionado
                    string queryPrecio = "SELECT Precio FROM Menus WHERE IdMenu = @IdMenu";
                    SqlCommand cmdPrecio = new SqlCommand(queryPrecio, con);
                    cmdPrecio.Parameters.AddWithValue("@IdMenu", pIdMenu);

                    object resultado = cmdPrecio.ExecuteScalar();

                    if (resultado == null)
                    {
                        msg.errorInsercion("No se encontró el precio del menú.", "Detalle del carrito");
                        return false;
                    }

                    // Calculo de nuevo subtotal
                    float precio = Convert.ToSingle(resultado);
                    float subtotal = precio * pCantidad;

                    // Insertar el detalle del pedido
                    string queryInsert = @"INSERT INTO DetallePedidos ([IdPedido], [IdMenu], [Cantidad], [PrecioUnitario]) 
                                   VALUES (@IdPedido, @IdMenu, @Cantidad, @PrecioUnitario)";

                    SqlCommand comando = new SqlCommand(queryInsert, con);
                    comando.Parameters.AddWithValue("@IdPedido", pIdPedido);
                    comando.Parameters.AddWithValue("@IdMenu", pIdMenu);
                    comando.Parameters.AddWithValue("@Cantidad", pCantidad);
                    comando.Parameters.AddWithValue("@PrecioUnitario", subtotal);

                    retorno = comando.ExecuteNonQuery() > 0;
                    return retorno;
                }
                catch (SqlException ex)
                {
                    msg.errorInsercion(ex.Message, " Detalle del carrito");
                    return false;
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }





    }
}
