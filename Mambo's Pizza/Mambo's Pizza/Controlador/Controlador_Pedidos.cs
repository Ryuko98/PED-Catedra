using Mambo_s_Pizza.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Controlador
{
    class Controlador_Pedidos
    {
        public static int IdPedido { get; set; }
        public static string Descripcion { get; set; }
        public static int IdCliente { get; set; }
        public static DateTime HoraPedido { get; set; }
        public static DateTime HoraEntrega { get; set; }
        public static int IdRepartidor { get; set; }
        public static int IdEstadoPedido { get; set; }
        public static double TotalPrecio { get; set; }

        public Controlador_Pedidos(string pDescripcion, int pIdCliente, DateTime pHoraPedido, DateTime pHoraEntrega, int pIdRepartidor, int pIdEstadoPedido, double pTotalPrecio)
        {
            Descripcion = pDescripcion;
            IdCliente = pIdCliente;
            HoraPedido = pHoraPedido;
            HoraEntrega = pHoraEntrega;
            IdRepartidor = pIdRepartidor;
            IdEstadoPedido = pIdEstadoPedido;
            TotalPrecio = pTotalPrecio;
        }

        public static DataTable ObtenerPedidos()
        {
            return Modelo_Pedidos.MostrarPedidos();
        }

        public bool InsertarUsuarios()
        {
            return Modelo_Pedidos.AgregarPedido(Descripcion, IdCliente, HoraPedido, HoraEntrega, IdRepartidor, IdEstadoPedido, TotalPrecio);
        }

        public bool ActualizarUsuarios()
        {
            return Modelo_Pedidos.ActualizarPedido(IdPedido, Descripcion, IdCliente, HoraPedido, HoraEntrega, IdRepartidor, IdEstadoPedido, TotalPrecio);
        }

        public static bool EliminarUsuarios()
        {
            return Modelo_Pedidos.EliminarPedido(IdPedido);
        }

        public static DataTable ObtenerCliente()
        {
            return Modelo_Pedidos.MostrarClientes();
        }

        public static DataTable ObtenerRepartidor()
        {
            return Modelo_Pedidos.MostrarRepartidor();
        }

        public static DataTable ObtenerEstadoPedido()
        {
            return Modelo_Pedidos.MostrarEstados();
        }

        public static List<string> VerificarCarrito(int id_cliente)
        {
            return Modelo_Pedidos.VerificarCarrito(id_cliente);
        }
        public static int CrearCarrito(int id_cliente)
        {
            return Modelo_Pedidos.CrearCarrito(id_cliente);
        }
        public static DataTable CargarCarrito(int id_pedido)
        {
            return Modelo_Pedidos.CargarCarrito(id_pedido);
        }
        public static List<string> CarritoFinalizado(int id_cliente)
        {
            return Modelo_Pedidos.CarritoFinalizado(id_cliente);
        }
    }
}
