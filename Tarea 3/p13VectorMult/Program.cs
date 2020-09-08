//Leer dos vectores de tamaño n y multiplicar el primer elemento de A con el ultimo elemento de B
using System;

namespace p13VectorMult
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MAX=3;
            double[] A=new double[MAX];
            double[] B=new double[MAX];
            double[] C=new double[MAX];

            //Almacenar los datos de los vectores A y B
            Console.WriteLine("\nDame los elementos de A"); leer(A); 
            Console.WriteLine("\nDame los elementos de B"); leer(B);

            for(int i=0;i<MAX;i++) //Recorrer todo el vector
                C[i]=A[i]*B[(MAX-1)-i]; //Multiplicacion del primer elemento de A * el ultimo de B
            
            //Mostrar elementos en consola
            Console.WriteLine("Los 3 vectores son");
            imprime(A); 
            imprime(B);
            imprime(C);
            
       
        }

        static void leer(double[] v){
            for(int i=0;i<v.Length;i++){
                Console.Write($"Elemento: [{i}]= ");
                v[i]=double.Parse(Console.ReadLine());
            }
        }

        static void imprime(double[] v){
            for(int i=0;i<v.Length;i++)
                Console.Write($"[{v[i]}]");
            Console.WriteLine();
            
        }
    }
}
