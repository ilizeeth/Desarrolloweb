//Leer un vector A y realizar operaciones estadisticas (may,menor,media,varianza, desviacion estandar)

/*
    Paola Lizeth Medina Trejo
    08 de Septiembre de 2020
*/
using System;

namespace p14Estadisticas
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declaracion de variables
           int n=0;
           double[] A;
           double lamedia=0,lavarianza=0;
           Console.WriteLine("Cuatos elementos?: ");
           n=int.Parse(Console.ReadLine());
           A=new double[n];

           Console.WriteLine("\nDame los elementos del arreglo \n"); leer(A);
           Console.WriteLine("\nEstadisticas: \n");
           Console.WriteLine($"\nMayor: {may(A)}");
           Console.WriteLine($"\nMenor: {men(A)}");
           lamedia=media(A);
           lavarianza=varianza(A,lamedia); //Calculo de la varianza
           Console.WriteLine($"\nMedia: {lamedia}");
           Console.WriteLine($"\nVarianza: {lavarianza}");
           Console.WriteLine($"\nDesviacion estandar: {Math.Sqrt(lavarianza)}");
        }

        //Funcion que calcula la varianza
        static double varianza(double[] v,double m){
            double suma=0;
            for(int i=0;i<v.Length;i++)
                suma+=Math.Pow((v[i]-m),2);
            return suma/v.Length-1;
        }

        //Funcion que calcula la media
        static double media(double[] v){
            double suma=0;
            for(int i=0;i<v.Length;i++)
                suma+=v[i]; 
            return suma/v.Length;
        }

        //Funcion que comprueba cual es el elemento mayor
        static double may(double[] v){
            double m=v[0];
            for(int i=0;i<v.Length;i++)
                if(v[i]>m) m=v[i];
                return m;
            
        }

        //Funcion que comprueba cual es el elemento mayor
        static double men(double[] v){
            double m=v[0];
            for(int i=0;i<v.Length;i++)
                if(v[i]<m) m=v[i];
                return m;
            
        }


        //Funcion que se utiliza para poder leer los elementos del arreglo
         static void leer(double[] v){
            for(int i=0;i<v.Length;i++){
                Console.Write($"Elemento: [{i}]=");
                v[i]=double.Parse(Console.ReadLine());
            }
        }

        static void imprime(double[] v){
            for(int i=0;i<v.Length;i++){
                Console.Write($"[v{i}]: ");
                Console.WriteLine();
            }
        }
    }
}
