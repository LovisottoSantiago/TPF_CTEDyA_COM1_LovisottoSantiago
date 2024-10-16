using System;
using System.Collections.Generic;

namespace tpfinal
{
    class MinHeap
    {
        private List<Proceso> heap;

        public MinHeap()
        {
            heap = new List<Proceso> { null }; 
        }

        public void ConstruirHeap(List<Proceso> procesos)
        {
            heap = new List<Proceso> { null }; // indice 0 = null
            heap.AddRange(procesos);

            // Empezar desde el último nodo no hoja
            for (int i = (heap.Count - 1) / 2; i >= 1; i--)
            {
                MinHeapify(i);
            }
        }

        private void MinHeapify(int index)
        {
            int izq = 2 * index; // Hijo izquierdo
            int der = 2 * index + 1; // Hijo derecho
            int min = index;

            if (izq < heap.Count && heap[izq].tiempo < heap[min].tiempo)
                min = izq;

            if (der < heap.Count && heap[der].tiempo < heap[min].tiempo)
                min = der;

            if (min != index)
            {
                var temp = heap[index];
                heap[index] = heap[min];
                heap[min] = temp;
                MinHeapify(min);
            }
        }

        public void Insertar(Proceso proceso)
        {
            heap.Add(proceso);
            int index = heap.Count - 1;

            while (index > 1)
            {
                int padre = index / 2;
                if (heap[index].tiempo >= heap[padre].tiempo)
                    break;

                var temp = heap[index];
                heap[index] = heap[padre];
                heap[padre] = temp;
                index = padre;
            }
        }

        public Proceso Eliminar()
        {
            if (heap.Count <= 1)
                throw new InvalidOperationException("Heap vacío");

            Proceso raiz = heap[1];
            heap[1] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);

            if (heap.Count > 1)
            {
                MinHeapify(1);
            }

            return raiz;
        }

        public bool EsVacia()
        {
            return heap.Count <= 1; // Menor o igual a 1 porque el índice 0 está ignorado
        }

        public int Tamaño()
        {
            return heap.Count - 1; // Restar 1 debido al índice 0 ignorado
        }
    }
}
