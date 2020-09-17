using System;
using System.Collections.Generic;

namespace p19lista2
{
    class Program
    {
        static void Main(string[] args)
        {
           //Crear una lista con elementos de tipo pieza
           List<Pieza> mp=new List<Pieza>();

           //Agregar piezas a la lista
           mp.Add(new Pieza(1234,"Tuerca de rosca interior"));
           mp.Add(new Pieza(5678,"Tornillo de cabeza grande"));
           mp.Add(new Pieza(9345,"Martillo de chiva"));

           //Agregar un rango de piezas
           var provedor = new List<Pieza>(){
               new Pieza(8888,"Tornillo de cabeza pequeña"),
               new Pieza(9999,"Cables para pasar corriente"),
               new Pieza(6666, "Toqueres dobles de madera")
           };
           mp.AddRange(provedor);

           //Usar el metodo foreach integrado en la lista para imprimri su contenido
            mp.ForEach(p=>Console.WriteLine(p.ToString()));

          //Eliminar el ultimo elemento de la lista
          mp.RemoveAt(mp.Count-1);

          //Insertar un elemento en la 2da posicion
          Console.WriteLine("\nInsertar elemento en la posicion 2: \n");
          mp.Insert(1,new Pieza(2222, "Caja de 8 velocidades"));
            mp.ForEach(p=>Console.WriteLine(p.ToString()));

            //Buscar todas las ocurrencias de la palabra torinillo 
            Console.WriteLine("Piezas que contienen la palabra torniloo");
            var pzas=mp.FindAll(p=>p.Nombre.Contains("Tornillo"));
            pzas.ForEach(p=>Console.WriteLine(p.ToString()));

            //Bucar las piezas cuyo Id es menor de 5000
            Console.WriteLine("\n Piezas con id menor a 5000 \n");
            var pzas2 =mp.FindAll(p=>p.Id<5000);
            pzas2.ForEach(p=>Console.WriteLine(p.ToString()));
        }
    }
}
