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
                WHERE p.IdEstadoPedido = 5"; // Asumiendo que 2 es "esperando envío"

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

        public static bool MarcarPedidoEnviado(int IdPedido)
        {
            Conexion conexionBD = new Conexion();
            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = "UPDATE Pedidos SET IdEstadoPedido = 1 WHERE idPedido = @idPedido";
                SqlCommand command = new SqlCommand(query, con);
                command.Parameters.AddWithValue("@idPedido", IdPedido);

                return command.ExecuteNonQuery() > 0;
            }
        }
    }
}
