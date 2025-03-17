using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proto
{
    class Cola
    {
        Nodo inicio;
        Nodo final;
        private int tnodos;

        public Cola()
        {
            inicio = null;
            final = null;
        }

        public int Tnodos()
        {
            return this.tnodos;
        }

        // Inserción al final de la cola (O(1)) donde la complejidad es uno porque se realiza solo una vez por cada inserción
        public void Insertar(int dato)
        {
            Nodo nuevo = new Nodo(dato);
            if (inicio == null)
            {
                inicio = nuevo;
                final = nuevo;
            }
            else
            {
                final.Sig = nuevo;
                final = nuevo;
            }
        }

        // Extracción del máximo (O(n)) donde n = tnodos
        public void DesencolarMax()
        {
            if (Vacia())
            {
                MessageBox.Show("No se puede desencolar", "La cola se encuentra vacía", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Nodo puntero = inicio; // puntero y anterior son nodos que van a recorrer toda la cola
            Nodo anterior = null;
            Nodo mayor = inicio; // mayor y anteriorMayor son nodos para almacenar el 
            Nodo anteriorMayor = null;

            // Buscar el nodo con el mayor valor
            while (puntero != null)
            {
                if (puntero.Dato > mayor.Dato)
                {
                    mayor = puntero;
                    anteriorMayor = anterior;
                }
                anterior = puntero;
                puntero = puntero.Sig;
            }

            // Si el mayor está en el inicio
            if (anteriorMayor == null)
            {
                inicio = inicio.Sig;
                if (inicio == null)
                    final = null;  // Si la cola queda vacía, final debe ser null
            }
            else
            {
                anteriorMayor.Sig = mayor.Sig;
                if (mayor == final)
                    final = anteriorMayor;  // Si el mayor era el último nodo se actualiza el final
            }
        }


        // Mostrar los elementos encolados (O(n)) donde n = tnodos
        public void Mostrar(ListBox lb)
        {
            lb.Items.Clear(); // Limpiar el ListBox antes de mostrar los datos
            Nodo puntero = inicio;

            if (Vacia())
            {
                lb.Items.Add("La cola se encuentra vacía");
                return;
            }

            while (puntero != null)
            {
                lb.Items.Add(puntero.Dato); // Agregar cada elemento al ListBox
                puntero = puntero.Sig; // El puntero avanza a su siguiente
            }
        }

        bool Vacia()
        {
            if (inicio == null)
                return true;
            else
                return false;
        }
    }
}
