using System;
using System.Collections.Generic;

namespace tpfinal {
    class Heap {
        private List<Proceso> heap;
        private bool esMaxHeap;

        public Heap(bool esMaxHeap) {
            this.esMaxHeap = esMaxHeap;
            heap = new List<Proceso> { };
        }

        public void ConstruirHeap(List<Proceso> procesos) {
            heap.AddRange(procesos);
            for (int i = (heap.Count - 1) / 2; i >= 1; i--) {
                Heapify(i);
            }
        }

        private void Heapify(int index) {
            int izq = 2 * index; 
            int der = 2 * index + 1; 
            int extremo = index;

            if (izq < heap.Count && Comparar(izq, extremo)) 
                extremo = izq;

            if (der < heap.Count && Comparar(der, extremo)) 
                extremo = der;

            if (extremo != index) {
                var temp = heap[index];
                heap[index] = heap[extremo];
                heap[extremo] = temp;
                Heapify(extremo);
            }
        }

        private bool Comparar(int hijo, int padre) {
            if (esMaxHeap) 
                return heap[hijo].prioridad > heap[padre].prioridad; //! prioridad (punto 2)
            else 
                return heap[hijo].tiempo < heap[padre].tiempo; //! tiempo (punto 1)
        }

        public void Insertar(Proceso nuevoProceso) {
            heap.Add(nuevoProceso); // agregar al final
            int index = heap.Count - 1;
            while (index > 1 && Comparar(index, index / 2)) { // determina si el proceso en el índice actual tiene una prioridad mayor (o menor, dependiendo de si es un MaxHeap o MinHeap) que el proceso en su posición padre
                var temp = heap[index];
                heap[index] = heap[index / 2];
                heap[index / 2] = temp;
                index = index / 2; // subir al padre
            }
        }

        public Proceso Eliminar() {
            if (heap.Count <= 1) {
                throw new InvalidOperationException("El heap está vacío.");
            }

            Proceso raiz = heap[1];
            heap[1] = heap[heap.Count - 1]; // cambiar raíz con el último elemento
            heap.RemoveAt(heap.Count - 1); // eliminar el último elemento
            Heapify(1); // filtrado

            return raiz; // retornar el elemento eliminado
        }

        public bool EsVacia() {
            return heap.Count <= 1; // menor o igual a 1 porque el índice 0 está ignorado (siguiendo la implementación de Heap de la cátedra)
        }

        public int Tamaño() {
            return heap.Count - 1; // restar 1 debido al índice 0 ignorado
        }

        //! <!-- METODOS PARA LAS CONSULTAS -->
        public List<Proceso> ObtenerHojas() {
            List<Proceso> hojas = new List<Proceso>();
            int n = Tamaño();

            // Las hojas están en los índices desde (n/2 + 1) hasta n
            for (int i = n / 2 + 1; i <= n; i++) {
                hojas.Add(heap[i]); // Acceder a las hojas
            }

            return hojas;
        }


    }
}
