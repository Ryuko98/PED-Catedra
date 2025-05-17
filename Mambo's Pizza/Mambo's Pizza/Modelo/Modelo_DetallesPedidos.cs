using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Modelo
{
    public class Modelo_DetallesPedidos
    {
        public static bool AgregarDetalle(int pIdPedido, int pIdMenu, int pCantidad, double pPrecioUnitario)

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
