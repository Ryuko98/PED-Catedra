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
    class Modelo_EstadosPedidos
    {
        private static List<Controlador_EstadosPedidos> articulosDeLimpieza = new List<Controlador_EstadosPedidos>();

        public static bool AgregarEstadoPedido(string pEstado)
        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = "INSERT INTO EstadosPedidos (Estado) " +
                                 "VALUES (@Estado)";

                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.AddWithValue("@Estado", pEstado);

                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());
                    msg.exitoInsercion("Tabla: EstadosPedidos. ");
                    return retorno; // Retorna true si se agrega correctamente
                }
                catch (SqlException ex)
                {
                    msg.errorInsercion(ex.Message, "Tabla: EstadosPedidos. ");
                    return retorno; // Retorna false si hay un error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }

        public static bool ActualizarEstadoPedido(int pIdEstadoPedido, string pEstado)
        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                try
                {
                    string query = @"UPDATE EstadosPedidos 
                           SET Estado = @Estado 
                           WHERE IdEstadoPedido = @IdEstadoPedido";

                    SqlCommand comando = new SqlCommand(query, con);
                    comando.Parameters.AddWithValue("@IdEstadoPedido", pIdEstadoPedido);
                    comando.Parameters.AddWithValue("@Estado", pEstado);

                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());
                    msg.exitoActualizacion("Tabla: EstadosPedidos.");
                    return retorno; // Returns true if update was successful
                }
                catch (SqlException ex)
                {
                    msg.errorActualizacion(ex.Message, "Tabla: EstadosPedidos.");
                    return retorno; // Returns false if there was an error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }

        public static bool EliminarEstadoPedido(int idEstadoPedido)
        {
            bool retorno = false;
            mensajes msg = new mensajes();
            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = "DELETE FROM EstadosPedidos WHERE IdEstadoPedido = @IdEstadoPedido";
                SqlCommand comando = new SqlCommand(query, con);
                comando.Parameters.AddWithValue("@IdEstadoPedido", idEstadoPedido);

                try
                {
                    retorno = Convert.ToBoolean(comando.ExecuteNonQuery());

                    if (retorno == true)
                    {
                        msg.exitoEliminacion("Tabla: EstadosPedidos.");
                    }

                    return retorno; // Returns true if deletion was successful
                }
                catch (SqlException ex)
                {
                    msg.errorEliminacion(ex.Message, "Tabla: EstadosPedidos.");
                    return retorno; // Returns false if there was an error
                }
                finally
                {
                    conexionBD.CerrarConexion();
                }
            }
        }

        public static DataTable MostrarEstadosPedidos()
        {
            DataTable dt = new DataTable();

            // Columnas basadas en la tabla EstadosPedidos
            dt.Columns.Add("IdEstadoPedido", typeof(int));
            dt.Columns.Add("Estado", typeof(string));

            Conexion conexionBD = new Conexion();

            using (SqlConnection con = conexionBD.AbrirConexion())
            {
                string query = "SELECT IdEstadoPedido, Estado FROM EstadosPedidos";

                using (SqlCommand comando = new SqlCommand(query, con))
                {
                    using (SqlDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dt.Rows.Add(
                                reader.GetInt32(0),    // IdEstadoPedido
                                reader.GetString(1)    // Estado
                            );
                        }
                    }
                }
            }
            return dt;
        }
    }
}
