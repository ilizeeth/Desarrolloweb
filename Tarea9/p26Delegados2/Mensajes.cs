using System;
//Ejemplo de delegado multicast(un delegado que invoca a varios metodos al mismo tiempo)
namespace p26Delegados2
{
    public class Mensajes
    {
        public static void Mensaje1(string msj)=>Console.WriteLine($"{msj} Lleva el pastel");
        public static void Mensaje2(string msj)=>Console.WriteLine($"{msj} Fue el culpable de cancelar la fiesta");
    }
}