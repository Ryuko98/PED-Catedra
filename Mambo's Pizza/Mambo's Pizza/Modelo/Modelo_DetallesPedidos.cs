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
        public static bool AgregarDetalle(int pIdPedido, int pIdMenu, int pCantidad, float pPrecioUnitario)

        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = "INSERT INTO DetallePedidos ([IdPedido], [IdMenu], [Cantidad], [PrecioUnitario]) " +
                                 "VALUES (@IdPedido, @IdMenu, @Cantidad, @PrecioUnitario)";

                    SqlCommand comando = new SqlCommand(query, con);

                    comando.Parameters.AddWithValue("@IdPedido", pIdPedido);
                    comando.Parameters.AddWithValue("@IdMenu", pIdMenu);
                    comando.Parameters.AddWithValue("@Cantidad", pCantidad);
                    comando.Parameters.AddWithValue("@PrecioUnitario", pPrecioUnitario);

                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());
                    msg.exitoInsercion("Tabla: DetallePedido. ");
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

    }
}
