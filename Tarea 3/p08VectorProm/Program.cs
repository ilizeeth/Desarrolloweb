//Programa que calcula el promedio de un vector de valores constantes
/*Paola Lizeth Medina Trejo
08 septiembre 2020*/

using System;

namespace p08VectorProm
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] vector={10,20,30,40,50,60,70,80,90,100,
                            10,20,30,40,50,60,70,80,90,100,
                            10,20,30,40,50,60,70,80,90,100,
                            10,20,30,40,50,60,70,80,90,100,
                            10,20,30,40,50,60,70,80,90,100};
            int suma=0,nmp=0;
            float prom;

            for(int i=0;i<vector.Length;i++){
                Console.Write($"{vector[i]} ");
                suma+=vector[i]; //Suma los elementos del vector
            }
            prom=suma/vector.Length; //Calcula el promedio
            Console.WriteLine($"\nEl promedio es: {prom} \n"); //Muestra el promedio en pantalla
            foreach(int v in vector){
                if(v>prom){ //Verifica si el elemento del vector es mayor al promedio
                   Console.Write($"{v} "); //Muentra que elemento es mayor
                   nmp++;  //Contador de los elementos mayores al promedio
                }
            }
            //Mostrar cuantos elementos son mayores al promedio 
            Console.WriteLine($"\nElementos mayores al promedio: {nmp} \n");
        }
    }
}
