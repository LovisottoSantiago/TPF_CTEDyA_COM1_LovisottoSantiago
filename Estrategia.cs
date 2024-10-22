﻿
using System;
using System.Collections.Generic;
using System.Numerics;
using tp1;

namespace tpfinal
{

    public class Estrategia
    {

        public String Consulta1(List<Proceso> datos)
        {
            string resutl = "Implementar";

            return resutl;

        }

        public String Consulta2(List<Proceso> datos)
        {
            string resutl = "Implementar";

            return resutl;
        }



        public String Consulta3(List<Proceso> datos)
        {
            string resutl = "Implementar";

            return resutl;
        }


        public void ShortesJobFirst(List<Proceso> datos, List<Proceso> collected)
        {

            MinHeap minHeap = new MinHeap();
            minHeap.ConstruirHeap(datos); 

            while (!minHeap.EsVacia())
                {
                    Proceso proceso = minHeap.Eliminar(); // Extrae el proceso de menor tiempo
                    collected.Add(proceso); // Agrega el proceso a la lista "collected"
                }
            

        }


        public void PreemptivePriority(List<Proceso> datos, List<Proceso> collected)
        {           
        	// Implementar
            MaxHeap maxHeap = new MaxHeap();
        	maxHeap.ConstruirHeap(datos);

            while (!maxHeap.EsVacia()){
                Proceso proceso = maxHeap.Eliminar();
                collected.Add(proceso);
            }

        }
        
    }
}