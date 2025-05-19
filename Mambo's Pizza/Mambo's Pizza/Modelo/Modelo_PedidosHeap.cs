using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Modelo
{
    public class Modelo_PedidosHeap
    {
        public static List<(int IdPedido, int IdMembresia)> ObtenerPedidosPendientes()
        {
            var pedidos = new List<(int, int)>();
            Conexion conexionBD = new Conexion();
            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = @"
                SELECT p.idPedido, c.IdMembresia 
                FROM Pedidos p
                JOIN Clientes c ON p.IdCliente = c.idCliente
                WHERE p.IdEstadoPedido = 2";

                SqlCommand command = new SqlCommand(query, con);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        pedidos.Add((reader.GetInt32(0), reader.GetInt32(1)));
                    }
                }
            }

            return pedidos;
        }

        public static bool MarcarPedidoEnviado(int IdPedido, int IdRepartidor)
        {
            Conexion conexionBD = new Conexion();
            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = "UPDATE Pedidos SET IdEstadoPedido = 3, HoraEntrega = @HoraEntrega, IdRepartidor = @IdRepartidor WHERE IdPedido = @IdPedido";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@IdPedido", IdPedido);
                command.Parameters.AddWithValue("@HoraEntrega", DateTime.Now.AddMinutes(1));
                command.Parameters.AddWithValue("@IdRepartidor", IdRepartidor);

                return command.ExecuteNonQuery() > 0;
            }
        }

        public static int ObtenerIdRepartidorPorUsuario(int IdUsuario)
        {
            int IdRepartidor = 0;
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = "SELECT IdRepartidor FROM Repartidores WHERE IdUsuario = @IdUsuario";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    comando.Parameters.AddWithValue("@IdUsuario", IdUsuario);
                    object result = comando.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        IdRepartidor = Convert.ToInt32(result);
                    }
                }
            }
            return IdRepartidor;
        }
    }
}
