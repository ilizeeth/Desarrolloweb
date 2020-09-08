//Este programa genera dos vectores aleatorios y los suma

/*
    Paola Lizeth Medina Trejo
    08 de Septiembre de 2020
*/

using System;

namespace p09NumAleatorio
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[15];
            int[] B = new int[15];
            int[] C = new int[15];

            Random rnd = new Random();
            //Generar numeros aleatorios para A y B
            for(int i=0;i<A.Length;i++){
                A[i]=rnd.Next(1,100);
                B[i]=rnd.Next(1,100);
                C[i]=A[i]+B[i]; //Suma los elementos de A y B y los asigna a C
            }
            //Mostrar vectores en pantalla
            Console.WriteLine("\nElemenots de A"); imprime(A);
            Console.WriteLine("\nElemenots de B"); imprime(B);
            Console.WriteLine("\nElemenots de C"); imprime(C);

        }

        static void imprime(int[] v){
            for(int i=0;i<v.Length;i++)
                Console.Write($"{v[i]} ");
            
        }
    }
}
