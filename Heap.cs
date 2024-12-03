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
            int extremo = index; // raiz

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

        public void Insertar(Proceso nuevoProceso) { // No lo uso pero es un método básico de las Heap
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
        //* CONSULTA 1
        public List<Proceso> ObtenerHojas() {
            List<Proceso> hojas = new List<Proceso>();
            int n = Tamaño();

            // Las hojas están en los índices desde (n/2 + 1) hasta n
            for (int i = n / 2 + 1; i <= n; i++) {
                hojas.Add(heap[i]); // Acceder a las hojas
            }

            return hojas;
        }

        //* CONSULTA 2
        public int Altura() {
            int n = this.Tamaño();  // Si n= 100. 100 en binario es 1100100
            int altura = 0; 

            while (n > 1) {
                n >>= 1;  // Desplazar bits hacia la derecha (dividir entre 2). 
                altura++;
            }

            return altura;
        }

        //* CONSULTA 3
        public string ObtenerNiveles(){
            string resultado = "";
            int nivelActual = -1;  // Variable para rastrear el nivel actual.
            int n = this.Tamaño();

            for (int i = 1; i <= n; i++) { // Recorremos los nodos desde 1 hasta n
                int nivel = 0;
                int indice = i;

                // Calcular el nivel desplazando bits hasta que el índice sea 1
                while (indice > 1) {
                    indice >>= 1;
                    nivel++;
                }
                // Si el nivel del nodo actual es diferente del nivel anterior, agregamos una nueva línea.
                if (nivel != nivelActual) {
                    nivelActual = nivel; // Actualizamos el nivel actual.
                    resultado += "\nNivel " + nivelActual + ":\n";
                }
                // Obtenemos el proceso de la Heap (cambia su orden dependiendo si es max o min heap)
                Proceso proceso = heap[i];
                resultado += "Proceso: " + proceso.nombre + 
                            ", Tiempo: " + proceso.tiempo + 
                            ", Prioridad: " + proceso.prioridad + "\n";
            }

            return resultado;
        }



    }
}



