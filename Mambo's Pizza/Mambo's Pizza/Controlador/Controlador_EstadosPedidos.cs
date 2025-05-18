using Mambo_s_Pizza.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Controlador
{
    class Controlador_EstadosPedidos
    {
        public int IdEstadoPedido { get; set; }
        public string Estado { get; set; }

        // Constructor
        public Controlador_EstadosPedidos(string pEstado)
        {
            Estado = pEstado;
        }

        // Constructor sobrecargado para cuando necesitemos el ID
        public Controlador_EstadosPedidos(int pIdEstadoPedido, string pEstado)
        {
            IdEstadoPedido = pIdEstadoPedido;
            Estado = pEstado;
        }

        // Métodos
        public static DataTable ObtenerEstadosPedidos()
        {
            return Modelo_EstadosPedidos.MostrarEstadosPedidos();
        }

        public bool InsertarEstadoPedido()
        {
            return Modelo_EstadosPedidos.AgregarEstadoPedido(Estado);
        }

        public bool ActualizarEstadoPedido()
        {
            return Modelo_EstadosPedidos.ActualizarEstadoPedido(IdEstadoPedido, Estado);
        }

        public static bool EliminarEstadoPedido(int idEstadoPedido)
        {
            return Modelo_EstadosPedidos.EliminarEstadoPedido(idEstadoPedido);
        }
    }
}
