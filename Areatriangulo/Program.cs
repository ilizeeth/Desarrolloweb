using System;

namespace Areatriangulo
{
    class Program
    {
        static void Main(string[] args)
        {
            float lbase,laltura;
            float area;

            Console.WriteLine("Dame la base"); lbase=float.Parse(Console.ReadLine());
            Console.WriteLine("Dame la altura"); laltura=float.Parse(Console.ReadLine());

            area=lbase*laltura/2;

            Console.WriteLine($"Un triagulo de base {lbase} y altura {laltura}tiene una area de {area}");
        }

    }
}
