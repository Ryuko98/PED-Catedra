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

        public Controlador_Pedidos()
        {
            //IdPedido = IdPedido;
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
        public static string ObtenerDescripcion(int id_pedido)
        {
            return Modelo_Pedidos.ObtenerDescripcion(id_pedido);
        }
        public static string ObtenerTotal(int id_pedido)
        {
            return Modelo_Pedidos.ObtenerTotal(id_pedido);
        }
        public static bool FinalizarPedido(int id_pedido, string descipcion, DateTime hora_pedido,  double total_pedido)
        {
            return Modelo_Pedidos.FinalizarPedido(id_pedido, descipcion, hora_pedido, total_pedido);
        }
        public static int ObtenerEstado(int id_pedido)
        {
            return Modelo_Pedidos.ObtenerEstado(id_pedido);
        }
        public static string ObtenerRepartidorNombre(int id_pedido)
        {
            return Modelo_Pedidos.ObtenerRepartidorNombre(id_pedido);
        }
        public static DateTime ObtenerHoraEntrega(int id_pedido)
        {
            return Modelo_Pedidos.ObtenerHoraEntrega(id_pedido);
        }
        public static bool EntregarPedido(int id_pedido)
        {
            return Modelo_Pedidos.EntregarPedido(id_pedido);
        }
        public static DataTable ObtenerPedidosEntregados()
        {
            return Modelo_Pedidos.ObtenerPedidosCompletados();
        }

        public static List<string> DatosPedidoRepartidor()
        {
            return Modelo_Pedidos.DatosRepartidorPedido(IdCliente);
        }

        public bool ActualizarEstadoCalificado()
        {
            return Modelo_Pedidos.ActualizarEstadoCalificado(IdPedido);
        }
    }
}
