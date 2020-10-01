using System;
//Ejemplo de delegado multicast(un delegado que invoca a varios metodos al mismo tiempo)
namespace p26Delegados2
{
    public delegate void Midelegado(string msj);
    class Program
    {
        static void Main(string[] args)
        {
            Midelegado d1,d2,d3,d;

            d1=Mensajes.Mensaje1;
            d2=Mensajes.Mensaje2;
            d=d1+d2;
            d("el peje");
            d3=(string msj)=>Console.WriteLine($"{msj} paga todo que no pare la fiesta");
            d+=d3;
            d("El barolas");
            d-=d2;
            d("Peña");
            d-=d1;
            d("pablo");
        }
    }
}
