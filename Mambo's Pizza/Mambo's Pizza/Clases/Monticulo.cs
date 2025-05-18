using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Mambo_s_Pizza.Modelo;


namespace Mambo_s_Pizza.Clases
{
    public class Monticulo
    {
        private List<PedidosMonticulo> heap;
        public int totnodos;
        public Monticulo()
        {
            heap = new List<PedidosMonticulo>();
            heap.Add(null); // Índice 0 no se usa (para cálculos de padres/hijos)
        }


        private void IntercambiarNodos(int i, int j)
        {
            PedidosMonticulo temp = heap[i];
            heap[i] = heap[j];
            heap[j] = temp;
        }

        public int TotNodos()
        {
            return totnodos;
        }

        private void SubirNodo(int index)
        {
            while (index > 1 && heap[index].prioridad < heap[index / 2].prioridad)
            {
                IntercambiarNodos(index, index / 2);
                index /= 2;
            }
        }


        private void DescenderNodo(int index)
        {
            int hijoIzq = 2 * index;
            int hijoDer = 2 * index + 1;
            int menor = index;

            if (hijoIzq < heap.Count && heap[hijoIzq].prioridad < heap[menor].prioridad)
                menor = hijoIzq;

            if (hijoDer < heap.Count && heap[hijoDer].prioridad < heap[menor].prioridad)
                menor = hijoDer;

            if (menor != index)
            {
                IntercambiarNodos(index, menor);
                DescenderNodo(menor);
            }
        }

        public void Insertar(PedidosMonticulo pedido)
        {
            heap.Add(pedido);
            SubirNodo(heap.Count - 1);
        }
        public PedidosMonticulo AtenderPedido()
        {
            if (heap.Count <= 1) return null;

            PedidosMonticulo pedido = heap[1];
            heap[1] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            DescenderNodo(1);

            return pedido;
        }

        public DataTable CargarPedidos()
        {
            DataTable dtPedidos = Modelo_PerfilRepartidor.MostrarPedidosEnEspera(); // Obtiene datos de la BD

            // Instancia del Montículo
            Monticulo heapPedidos = new Monticulo();

            foreach (DataRow row in dtPedidos.Rows)
            {
                PedidosMonticulo pedido = new PedidosMonticulo(
                    heapPedidos.TotNodos() + 1,
                    row["Descripcion"].ToString(),
                    row["Menu"].ToString(),
                    row["Direccion"].ToString(),
                    row["Membresia"].ToString(),
                    Convert.ToDecimal(row["TotalPrecio"])
                );

                heapPedidos.Insertar(pedido); // Insertar en el montículo
            }

            // Retorno el `DataTable` ya procesado
            return dtPedidos;
        }

    }
}
