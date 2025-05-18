using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mambo_s_Pizza.Clases;

namespace Mambo_s_Pizza.Modelo
{
    class Modelo_PerfilRepartidor
    {
        private static int ObtenerIdRepartidorPorUsuario(int IdUsuario)
        {
            int idRepartidor = 0;
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
                        idRepartidor = Convert.ToInt32(result);
                    }
                }
            }
            return idRepartidor;
        }

        public static DataTable ObtenerInformacionRepartidor(int IdUsuario)
        {
            int IdRepartidor = ObtenerIdRepartidorPorUsuario(IdUsuario);

            if (IdRepartidor == 0)
            {
                throw new Exception("El usuario no está asociado a un repartidor");
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("NombreCompleto", typeof(string));
            dt.Columns.Add("Correo", typeof(string));
            dt.Columns.Add("Usuario", typeof(string));
            dt.Columns.Add("DUI", typeof(string));
            dt.Columns.Add("CalificacionPromedio", typeof(float));
            dt.Columns.Add("FechaRegistro", typeof(DateTime));

            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = @"SELECT 
                        u.Nombre + ' ' + u.Apellido AS NombreCompleto,
                        u.Correo,
                        u.Usuario,
                        r.DUI,
                        r.CalificacionPromedio,
                        r.FechaRegistro
                     FROM 
                        Repartidores r
                     INNER JOIN 
                        Usuarios u ON r.IdUsuario = u.IdUsuario
                     WHERE 
                        r.IdRepartidor = @IdRepartidor";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    comando.Parameters.AddWithValue("@IdRepartidor", IdRepartidor);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader["NombreCompleto"].ToString(),
                                reader["Correo"].ToString(),
                                reader["Usuario"].ToString(),
                                reader["DUI"].ToString(),
                                Convert.ToSingle(reader["CalificacionPromedio"]),
                                Convert.ToDateTime(reader["FechaRegistro"])
                            );
                        }
                    }
                }
            }
            return dt;
        }

        public static DataTable CargarReseñasRepartidor(int IdUsuario)
        {
            int IdRepartidor = ObtenerIdRepartidorPorUsuario(IdUsuario);

            if (IdRepartidor == 0)
            {
                throw new Exception("El usuario no está asociado a un repartidor");
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("Calificacion", typeof(string));
            dt.Columns.Add("Comentario", typeof(string));
            dt.Columns.Add("FechaReview", typeof(DateTime));

            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = @"SELECT Calificacion, Comentario, FechaReview FROM Reviews WHERE IdRepartidor = @IdRepartidor";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    comando.Parameters.AddWithValue("@IdRepartidor", IdRepartidor);

                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader["Calificacion"].ToString(),
                                reader["Comentario"].ToString(),
                                Convert.ToDateTime(reader["FechaReview"])
                            );
                        }
                    }
                }
            }
            return dt;
        }
        // Metodo para ordenar de mayor a menor en base a prioridad
        public static int PrioridadMembresia()
        {
            int repartidor = 0;
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = "SELECT a.IdMembresia FROM DetallesPedidos b INNER JOIN Pedidos c ON b.IdPedido = c.IdPedido INNER JOIN Clientes d ON c.IdCliente = d.IdCliente INNER JOIN Membresias a ON d.IdMembresia = a.IdMembresia ORDER BY a.Membresia DESC";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    object result = comando.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        repartidor = Convert.ToInt32(result);
                    }
                }
            }
            return repartidor;
        }
        // Metodo para cargar los pedidos con estado "Esperando Confirmacion"
        public static DataTable MostrarPedidosEnEspera()
        {
            DataTable dt = new DataTable();
            mensajes msg = new mensajes();
            try
            {
                // Columnas basadas en tu modelo de usuarios
                dt.Columns.Add("Descripcion");
                dt.Columns.Add("Menu");
                dt.Columns.Add("Direccion");
                dt.Columns.Add("Membresia");
                dt.Columns.Add("TotalPrecio");

                Conexion conexionBD = new Conexion();

                using (SqlConnection con = conexionBD.AbrirConexion())
                {
                    string query = "SELECT a.Descripcion, b.NombreMenu, c.Direccion, d.Membresia, a.TotalPrecio FROM DetallesPedidos e INNER JOIN Pedidos a ON e.IdPedido = a.IdPedido INNER JOIN Menus b ON e.IdMenu = b.IdMenu INNER JOIN Clientes c ON a.IdCliente = c.IdCliente INNER JOIN Membresias d ON c.IdMembresia = d.IdMembresia INNER JOIN EstadosPedidos f ON a.IdEstadoPedido = f.IdEstadoPedido WHERE f.IdEstadoPedido = 2";

                    using (SqlCommand comando = new SqlCommand(query, con))
                    {
                        using (SqlDataReader reader = comando.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dt.Rows.Add(
                                    reader["Descripcion"],
                                    reader["NombreMenu"],
                                    reader["Direccion"],
                                    reader["Membresia"],
                                    reader["TotalPrecio"]
                                );
                            }
                        }
                    }
                }
                return dt;
            }
            catch (Exception)
            {

                msg.formularioNoCarga();
                return dt = null;
            }

        }

    }
}
