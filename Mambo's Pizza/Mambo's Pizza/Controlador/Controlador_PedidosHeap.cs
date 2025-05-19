using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mambo_s_Pizza.Modelo;

namespace Mambo_s_Pizza.Controlador
{
    class Controlador_PedidosHeap
    {
        private static List<(int IdPedido, int IdMembresia, string Direccion)> heapPedidos = new List<(int, int, string)>();
        private static int IdRepartidor = ObtenerIdRepartidorPorUsuario(Controlador_InicioSesion.IdUsuario);

        // Método para obtener todos los pedidos pendientes y construir el heap
        public static void CargarPedidosPendientes()
        {
            var pedidos = Modelo_PedidosHeap.ObtenerPedidosPendientes();
            ConstruirHeap(pedidos);
        }

        // Construye el heap maximizante basado en IdMembresia (Nivel de la membresia)
        private static void ConstruirHeap(List<(int IdPedido, int IdMembresia, string Direccion)> pedidos)
        {
            heapPedidos = new List<(int, int, string)>();

            foreach (var pedido in pedidos)
            {
                InsertarEnHeap(pedido);
            }
        }

        // Inserta un nuevo elemento en el heap (Se inserta al final)
        private static void InsertarEnHeap((int IdPedido, int IdMembresia, string Direccion) pedido)
        {
            heapPedidos.Add(pedido);
            int i = heapPedidos.Count - 1;

            // Loop para ver si el valor determinante del heap es mayor a sus padres
            while (i > 0 && heapPedidos[(i - 1) / 2].IdMembresia < heapPedidos[i].IdMembresia)
            {
                // Intercambiar con el padre en caso de ser necesario
                var temp = heapPedidos[i];
                heapPedidos[i] = heapPedidos[(i - 1) / 2];
                heapPedidos[(i - 1) / 2] = temp;

                i = (i - 1) / 2;
            }
        }

        // Extrae el pedido con mayor prioridad (con IdMembresia como prioridad)
        // Nota: el ? sirve para que el método pueda devolver null sin problemas :D
        public static (int IdPedido, int IdMembresia, string Direccion)? ExtraerPedidoMaxPrioridad()
        {
            if (heapPedidos.Count == 0) return null;

            var max = heapPedidos[0];
            heapPedidos[0] = heapPedidos[heapPedidos.Count - 1];
            heapPedidos.RemoveAt(heapPedidos.Count - 1);

            Heapify(0);

            return max;
        }

        // Reorganiza el heap desde la posición i, para reacomodar según la prioridad
        private static void Heapify(int i)
        {
            int padre = i;
            int izq = 2 * i + 1;
            int der = 2 * i + 2;

            if (izq < heapPedidos.Count && heapPedidos[izq].IdMembresia > heapPedidos[padre].IdMembresia)
                padre = izq;

            if (der < heapPedidos.Count && heapPedidos[der].IdMembresia > heapPedidos[padre].IdMembresia)
                padre = der;

            if (padre != i)
            {
                var temp = heapPedidos[i];
                heapPedidos[i] = heapPedidos[padre];
                heapPedidos[padre] = temp;

                Heapify(padre);
            }
        }

        public static bool RepartidorTienePedidoEnCurso()
        {
            return Modelo_PedidosHeap.RepartidorTienePedidoEnCurso(IdRepartidor);
        }

        public static bool DespacharPedido()
        {
            var pedido = ExtraerPedidoMaxPrioridad();
            if (pedido == null) return false;

            return Modelo_PedidosHeap.MarcarPedidoEnviado(pedido.Value.IdPedido, IdRepartidor);
        }

        public static List<(int IdPedido, int IdMembresia, string Direccion)> ObtenerPedidosOrdenados()
        {
            return new List<(int, int, string)>(heapPedidos);
        }

        public static int ObtenerIdRepartidorPorUsuario(int IdUsuario)
        {
            return Modelo_PedidosHeap.ObtenerIdRepartidorPorUsuario(IdUsuario);
        }
    }
}
