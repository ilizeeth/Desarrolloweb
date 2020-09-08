//Genera numeros aleatorios en un vector, calcula positivos, negativos , ceros y la suma de estos

/*
    Paola Lizeth Medina Trejo
    08 de Septiembre de 2020
*/
using System;

namespace p11VectorSumas
{
    class Program
    {
        static void Main(string[] args)
        {
            double [] A = new double[30];
            int pos=0,neg=0,cer=0;
            double spos=0,sneg=0;
            Random rnd=new Random();
            for(int i=0;i<A.Length;i++){
                A[i]= rnd.Next(-10,100); //Genera un numero aleatorio para el vector A
                Console.Write($"{A[i]} ");
                if(A[i]>0){ //Verifica si es positivo
                    pos++; //Contabilzia cada numero positivo
                    spos+=A[i]; //Suma de num pos
                }else if(A[i]<0){ //Verifica si es negativo
                    neg++; //Contador
                    sneg+=A[i]; //Suma de num neg
                }else cer++;
            }
            //Mostrar resultados en pantalla
            Console.WriteLine($"\nPositivos: {pos}\nsuma: {spos}");
            Console.WriteLine($"\nNegativos: {neg}\nsuma: {sneg}");
            Console.WriteLine($"\nCeros: {cer}");
        }
    }
}
