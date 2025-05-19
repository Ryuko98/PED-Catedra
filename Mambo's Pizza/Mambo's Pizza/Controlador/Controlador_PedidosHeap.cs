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

        // Método para obtener todos los pedidos pendientes y construir el heap
        public static void CargarPedidosPendientes()
        {
            var pedidos = Modelo_PedidosHeap.ObtenerPedidosPendientes();
            ConstruirHeap(pedidos);
        }

        // Construye el heap maximizante basado en IdMembresia
        private static void ConstruirHeap(List<(int IdPedido, int IdMembresia, string Direccion)> pedidos)
        {
            heapPedidos = new List<(int, int, string)>();

            foreach (var pedido in pedidos)
            {
                InsertarEnHeap(pedido);
            }
        }

        // Inserta un nuevo elemento en el heap
        private static void InsertarEnHeap((int IdPedido, int IdMembresia, string Direccion) pedido)
        {
            heapPedidos.Add(pedido);
            int i = heapPedidos.Count - 1;

            while (i > 0 && heapPedidos[(i - 1) / 2].IdMembresia < heapPedidos[i].IdMembresia)
            {
                // Intercambiar con el padre
                var temp = heapPedidos[i];
                heapPedidos[i] = heapPedidos[(i - 1) / 2];
                heapPedidos[(i - 1) / 2] = temp;

                i = (i - 1) / 2;
            }
        }

        // Extrae el pedido con mayor prioridad
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
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < heapPedidos.Count && heapPedidos[left].IdMembresia > heapPedidos[largest].IdMembresia)
                largest = left;

            if (right < heapPedidos.Count && heapPedidos[right].IdMembresia > heapPedidos[largest].IdMembresia)
                largest = right;

            if (largest != i)
            {
                var temp = heapPedidos[i];
                heapPedidos[i] = heapPedidos[largest];
                heapPedidos[largest] = temp;

                Heapify(largest);
            }
        }

        public static bool DespacharPedido()
        {
            var pedido = ExtraerPedidoMaxPrioridad();
            if (pedido == null) return false;

            return Modelo_PedidosHeap.MarcarPedidoEnviado(pedido.Value.IdPedido, ObtenerIdRepartidorPorUsuario(Controlador_InicioSesion.IdUsuario)); // 3 = "En camino"
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
