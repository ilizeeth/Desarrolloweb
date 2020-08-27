using System;
//Programa que calcula paga de un trabajador dado:
//Nombre, horas, paga y tasa de impuestos
//Paola Lizeth Medina Trejo
namespace p04pagatrabajador
{
    class Program
    {
        static void Main(string[] args)
        {
           string nombre;
           int hora;
           float paga, tasa=0.10f;
           float impuesto,pagabruta,pagoneta;

           Console.WriteLine("Calculado la paga de un trabajador");
           Console.WriteLine("Dame el nombre"); nombre=Console.ReadLine();
           Console.WriteLine("Dame las horas"); hora= int.Parse(Console.ReadLine());
           Console.WriteLine("Dame la paga"); paga= float.Parse(Console.ReadLine());

           pagabruta=hora*paga;
           impuesto= pagabruta*tasa;
           pagoneta=pagabruta-impuesto;

           Console.WriteLine($"El trabajador de nombre {nombre}");
           Console.WriteLine($"Trabajo {horas} horas");
           Console.WriteLine($"Con una paga de {paga} pesos");
           Console.WriteLine($"Por lo cual recibe una paga bruta de  {pagabruta} pesos");
           Console.WriteLine($"Esto genera un impusto de {impuesto} pesos");
           Console.WriteLine($"Al final llega a su casa con la miserabe cantidad de {pagoneta} pesos"); 

           
    }
}
