# Trabajo Final: Complejidad Temporal, Estructura de Datos y Algoritmos | UNAJ

Este proyecto corresponde al **Trabajo Final** de la materia **"Complejidad Temporal, Estructura de Datos y Algoritmos"** de la **Universidad Nacional Arturo Jauretche**, realizado durante el 2do año de la carrera **Ingeniería en Informática**. Los invito a leer los archivos **"ENUNCIADO, INFORME Y PRESENTACIÓN"**, incluídos en el repositorio.

## Descripción del Proyecto
El objetivo principal fue desarrollar una aplicación que permita gestionar procesos simulados utilizando estrategias de planificación de CPU. El sistema implementa algoritmos de planificación basados en estructuras de datos **Heaps**, diseñadas para soportar las operaciones requeridas por los algoritmos **Shortest Job First (SJF)** y **Preemptive Priority Scheduling (PPCSA)**, el trabajo ya nos brinda la estructura general del sistema y el front-end.

## Funcionalidades

1. **Carga de Dataset (incluída en el trabajo)**: Permite seleccionar un archivo en formato `.csv` con los datos de procesos (nombre, tiempo de CPU, prioridad).  
2. **Algoritmos de Planificación (implementadas)**:
   - **SJF**: Utiliza una MinHeap para ejecutar los procesos con menor tiempo de CPU primero.
   - **PPCSA**: Utiliza una MaxHeap para priorizar procesos con mayor prioridad.
3. **Consultas (implementadas)**:
   - **Consulta 1**: Obtiene las hojas de las Heaps generadas.
   - **Consulta 2**: Calcula la altura de las Heaps mediante operadores de desplazamiento.
   - **Consulta 3**: Muestra los procesos organizados por niveles dentro de las Heaps.
4. **Simulación Gráfica (incluída en el trabajo)**: Visualización del estado de ejecución para 1 o 5 CPUs.
5. **Reinicio del Sistema (incluída en el trabajo)**: Permite reiniciar la simulación para realizar nuevas configuraciones.

## Capturas del proyecto
<div align="center">
  <img src="https://github.com/user-attachments/assets/0fb10218-413a-4a03-82cb-f7716adbc060" alt="Pantalla de Inicio">
  <img src="https://github.com/user-attachments/assets/687c197e-8d14-422d-9869-a72d290744b9" alt="Selección de Archivo">
  <img src="https://github.com/user-attachments/assets/f6b22328-97ae-49b7-829e-44ba5385b947" alt="Simulación con 5 CPUs">
  <img src="https://github.com/user-attachments/assets/1a3d9321-b73e-4c4c-be2a-372ec3c909e7" alt="Consulta 1">
  <img src="https://github.com/user-attachments/assets/48b44f30-1c41-4e11-ab41-c3ef023a31da" alt="Pantalla de Reinicio">
</div>


## Implementación
### Estructuras de Datos
- **Heap Genérica**: Implementación eficiente que unifica MinHeap y MaxHeap (se selecciona el tipo mediante un bool en el constructor), eliminando redundancia. 
  - Métodos principales: `ConstruirHeap`, `Heapify`, `Insertar`, `Eliminar`, `EsVacia`, `Tamaño`.
  - Basado en un árbol binario completo, garantizando una complejidad O(log N) para operaciones críticas.

### Lógica de Cálculo
   - Elegí usar <strong>operadores de desplazamiento<strong> para calcular logaritmos en vez de utilizar Math.log(), mejorando la eficiencia y compatibilidad.

### Pantallas de la Aplicación
- **Inicio**: Selección de archivo `.csv`.
- **Simulación**: Visualización de CPUs y resultados de planificación.
- **Consultas**: Visualización detallada de las hojas, alturas y niveles de las Heaps.

## Tecnologías Utilizadas
- **Lenguaje**: C#  
- **Frameworks**: .NET  
- **Herramientas Gráficas**: Windows Forms

## Conclusión
Este proyecto permitió afianzar conocimientos sobre estructuras de datos y algoritmos de planificación. La implementación de Heaps genéricas optimizó el diseño, facilitando la expansión futura y mejorando la eficiencia del sistema.

## Referencias
- [Documentación sobre Heaps](https://publish.obsidian.md/algoritmos/Estructuras+de+datos/Heap)
- [Operadores Bitwise en C#](https://learn.microsoft.com/en-us/cpp/cpp/left-shift-and-right-shift-operators-input-and-output?view=msvc-170)
- [Logaritmos en C#](https://learn.microsoft.com/en-us/dotnet/api/system.math.log2?view=net-8.0)
