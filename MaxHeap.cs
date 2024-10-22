using System;
using System.Collections.Generic;

namespace tpfinal {

    class MaxHeap {

        private List<Proceso> heap;

        public MaxHeap() {

            heap = new List<Proceso> { };

        }


        public void ConstruirHeap(List<Proceso> procesos){

            heap = new List<Proceso> { };
            heap.AddRange(procesos);

            // Empezar desde el último nodo no hoja
            for (int i = (heap.Count - 1) / 2; i >= 1; i--)
            {
                MaxHeapify(i);
            }

        }


        private void MaxHeapify(int index)
        {
            int izq = 2 * index; // Hijo izquierdo
            int der = 2 * index + 1; // Hijo derecho
            int max = index;

            if (izq < heap.Count && heap[izq].prioridad > heap[max].prioridad)
                max = izq;

            if (der < heap.Count && heap[der].prioridad > heap[max].prioridad)
                max = der;

            if (max != index)
            {
                var temp = heap[index];
                heap[index] = heap[max];
                heap[max] = temp;
                MaxHeapify(max);
            }
        }


        public void Insertar(Proceso nuevoProceso) {
            heap.Add(nuevoProceso); // Añadir al final
            int index = heap.Count - 1;
            while (index > 1 && heap[index].prioridad > heap[index / 2].prioridad) {
                var temp = heap[index];
                heap[index] = heap[index / 2];
                heap[index / 2] = temp;
                
                index = index / 2; // Sube al padre
            }
        }

        public Proceso Eliminar() {
            if (heap.Count == 1) {
                throw new InvalidOperationException("El heap está vacío.");
            }

            Proceso max = heap[1]; // Elemento con mayor prioridad (raíz)
            
            heap[1] = heap[heap.Count - 1]; // Reemplazar raíz con el último elemento
            heap.RemoveAt(heap.Count - 1); // Eliminar el último elemento
            MaxHeapify(1); // Reordenar

            return max; // Retornar el elemento eliminado (de mayor prioridad)
        }

        public bool EsVacia() {
            return heap.Count == 1; 
        }

        public int Tamaño() {
            return heap.Count - 1;
        }




        



    }



}