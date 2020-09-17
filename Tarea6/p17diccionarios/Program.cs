using System;
using System.Collections.Generic;

namespace p17diccionarios
{
    class Program
    {
        static void Main(string[] args)
        {
            //Definicion del diccionario y reserva de espacio de memoria
            //SortedDictionary<string,string> ndic= new SortedDictionary<string, string>();
            Dictionary<string,string> ndic= new Dictionary<string, string>();

            //Agregar elementos en el diccionario
            ndic.Add("txt","Archivo de texto");
            ndic.Add("jpg","Archivo de imagen");
            ndic.Add("mp3","Archivo de sonido");
            ndic.Add("exe","Archivo de ejecutable");
            ndic.Add("lll","Archivo de tipo desconocido");
            ndic.Add("html","Archivo de texto html");

            //Acceder elemento atraves de la llave
            Console.WriteLine(ndic["html"]);

            //Verificar si una llave existe, si no agregarla
            if(ndic.ContainsKey("elf"))
                Console.WriteLine("La llave ya existe en el diccionario");
            else 
                ndic.Add("elf","Archivo ejectucable en linux");

            //Borrar una entrada al diccionario en base a la llave
            if(ndic.ContainsKey("lll"))
                ndic.Remove("lll");
            //Recorrer el diccionario e imprimir la llave y su valor
            foreach(KeyValuePair<string,string> val in ndic){
                Console.WriteLine($"{val.Key} - {val.Key}");
            }

            //Imprimir solo las llaves del diccionario
             foreach(string key in ndic.Keys){
                Console.WriteLine($"{key}");

            }

            //Imprimir solo las entradas del diccionario
            foreach(string val in ndic.Values){
                Console.WriteLine($"{val}");
            }

            //Borrar todas las entradas al diccionario
            ndic.Clear();
        }
    }
}
