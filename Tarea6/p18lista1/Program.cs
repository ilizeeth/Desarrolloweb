using System;
using System.Collections.Generic;

namespace p18lista1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> mats = new List<string>(){
                "Calculo I",
                "Redaccion Avanzada",
                "Introducción a la Ingenieria"
            };

            //Agregar elementos a la lista
            mats.Add("Matematicas Discretas");
            mats.Add("Compiladores e interpretes");
            imprime(mats);

            //Agregar un rango de materias
            string[]mopt={
                "Seguridad en redes y sistemas (op)",
                "Topicos selectos de redes (op)",
                "criptografía avanzada(op)"
            };
            mats.AddRange(mopt);
            imprime(mats);

            //Ordenar la lista
            mats.Sort();
            imprime(mats);

            //Invierte los elementos de la lista
            mats.Reverse();
            imprime(mats);

            //Buscar un elemento en la lista, en base a una condicion
            Console.WriteLine("Materias que tengan la palabra Discretas");
            string mat =mats.Find(x=>x.Contains("Discretas"));
            Console.WriteLine(mat);

            //Buscar todas las materias en la lista, que son optativas
            var ms=mats.FindAll(x=>x.Contains("op"));
            imprime(ms);
        }

        static void imprime(List<string> lista){
            //foreach(string m in lista){ Console.WriteLine(m);}
            lista.ForEach(m=>Console.WriteLine(m));
            Console.WriteLine();
        }
    }
}
