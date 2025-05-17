using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mambo_s_Pizza.Clases
{
    public class Monticulo
    {
        private int totnodos; 

        ClienteMonticulo[] matriz;

        private int[] valoresHeapSort;

        public Monticulo()
        {
            totnodos = 0;
            matriz = new ClienteMonticulo[1000];
        }

        public int TotNodos()
        {
            return totnodos;
        }

        public void Vaciar()
        {
            // Vacia contenido del Heap
            totnodos = 0;
        }

        public void IntercambiarNodos(int id1, int id2)
        {
            int valortemp;

            valortemp = matriz[id1].valor;
            matriz[id1].valor = matriz[id2].valor;
            matriz[id2].valor = valortemp;
        }

        private void SubirNodo(int id, bool continuar = true)
        {
            // Si nodo actual es mayor que su nodo padre, lo intercambia
            int idpadre;
            // Evalua si nodo hijo debe ser intercambiado con su nodo padre y si
            // requiere, continuar recirsuvamente hasta ordenar nodo id en heap
            // Este prc de ordenamiento se repetira hasta que llegue al nodo raiz
            if (id > 1)
            {
                // Calcula id del nodo padre de nodo actual
                idpadre = matriz[id].Padre();
                //resalta nodo padre
                if (matriz[id].valor > matriz[idpadre].valor)
                {
                    IntercambiarNodos(id, idpadre);
                    // Resaura nodos ya intercambiados
                    //proc. de ordenamiento sigue con nuevo nodo padre
                    id = idpadre;
                    // Continua ordenando al nuevo nodo padre en monticulo
                    if (continuar)
                    {
                        SubirNodo(id);
                    }
                }
            }
        }

        private void Descender(int idpadre, bool continuar = true)
        {
            //determina si debe descender nodo padre, intercambiando su valor
            //con el mayor de sus hijos
            int idhijo; //indice de hijo izquierdo
            int idhijomayor = 0; //indice de hijo con supuesto valor mayor que nodo padre

            // Determina si nodo idpadre existe en Heap
            if (idpadre > 0 && idpadre <= totnodos)
            {
                // Proc lo hara solo si nodo padre no es hoja
                idhijo = 2 * idpadre;
                if (idhijo <= totnodos)
                {
                    //resalta a nodo padre
                    //determina el idhijo con valor mayor
                    idhijomayor = idhijo;

                    // Prueba si existe hijo derecho
                    if (idhijo + 1 <= totnodos)
                    {
                        //prueba si valor hijo derecho es menor que de hijo izquierdo
                        if (matriz[idhijo + 1].valor > matriz[idhijo].valor)
                            idhijomayor = idhijo + 1;
                        //hijo con menor valor es nodo derecho
                    }

                    // Determina si se hara intercambio de valor nodo padre - hijo menor
                    if (matriz[idhijomayor].valor > matriz[idpadre].valor)
                    {
                        IntercambiarNodos(idpadre, idhijomayor);
                    }
                    // Restaura formato a nodo padre

                    // Continua proceso de descenso de valor de raiz
                    if (continuar)
                    {
                        Descender(idhijomayor);
                    }
                }
            }
        }

        //Operaciones para remover valor maximo de un Heap
        private int BorrarRaiz()
        {
            // Remueve y retorna valor de nodo raiz (claveminima del heap)
            int valorraiz = -1; // Asume que monticulo esta vacio

            if (totnodos > 0)
            {
                // Extrae copia de valor del nodo a borrar
                valorraiz = matriz[1].valor;

                //Copia valordeultimo nodo,que sera elnuevo raiz
                matriz[1].valor = matriz[totnodos].valor;
                //Luego copia valor de nodo extraidon al ultimo nodo
                matriz[totnodos].valor = valorraiz;

                // Borra ultimo nodo
                totnodos--;
            }
            return valorraiz;
        }

        public int BorrarMaximo()
        {
            int numborrar = BorrarRaiz();
            if (totnodos > 0)
            {
                Descender(1);
            }
            return numborrar;
        }

        public int[] EjecutarHeapSort()
        {
            int i; // Contador de indice de posiciones del vector ya ordenado
            int valorRaiz; // Valor de nodo raiz de monticulo
            if (totnodos > 0)
            {
                // Metodo de ordenamiento rapido de prioridad (HeapSort)
                // Crea vector y longitud igual a cantidad nodos del heap
                valoresHeapSort = new int[0];

                i = 0; // Contador de elementos extraidos de heap
                while (totnodos > 0)
                {
                    // Extrae raiz (clave menor, heap minimizante)
                    valorRaiz = BorrarRaiz();

                    // Agregar una posicion mas a la longitud de vector
                    Array.Resize(ref valoresHeapSort, i + 1);
                    // Copia valor maximo (raiz) de monticulo en
                    // prox. posicion de vector final
                    valoresHeapSort[i] = valorRaiz;
                    Descender(1); // Ordena nuevo raiz en nuevo Heap

                    // Actualiza conteo de valores ordenados en vector final
                    i++;

                }
            }
            else
            {
                return null; // Heap vacio
            }
            // Retorna vector resultante de metodo HeapSort
            return valoresHeapSort;
        }

        public int[] OrdenarVector()
        {
            // Utiliza metodo HeapSort para ordenar vector ingresado por usuario
            // Contador de indice de posic. dentro de vector ya ordenado
            int c = 0;
            if (totnodos == 0)
            {
                return null; // Heap esta vacio
            }
            // Crea vector, que tendra valores del heap ya ordenados
            valoresHeapSort = new int[0]; // Vector vacio

            while (totnodos > 0)
            {
                // id del ultimo nodo padre a ordenar del heap actual
                int id = totnodos / 2;
                // Ordena a ultimo nodo padre y sus hijos
                while (id > 0)
                {
                    Descender(id, false); // No aplicara recursividad
                    // Determina el padre anterior al actual para ordenarlo
                    id = id - 1;
                }

                // Agrega una posicion mas a la longitud de vector
                Array.Resize(ref valoresHeapSort, c + 1);

                // Borra valor de raiz y lo retorna al vector ya ordenado
                valoresHeapSort[c] = BorrarRaiz();


                c++;// Incrementa conteo de indice posic.
            }
            return valoresHeapSort;
        }
    }
}
