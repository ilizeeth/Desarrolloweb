using System;

//Ejemplo de delegado como parametro

namespace p29Delegados5
{
    public delegate void MiDelegado(string msj);
    class Program
    {
        static void Main(string[] args)
        {
            MiDelegado d1,d2,d3;
            d1 =claseA.MetodoA;
            d1("tradicional A");
            Invocar(d1);

            d2=claseB.MetodoB;
            d2("Tradicional B");
            Invocar(d2);

            d3=(string msj)=>Console.WriteLine($"Llamado metodo con expresion llamada: {msj}");
            d3("Tradicional Llamada");
            Invocar(d3);
        }

        static void Invocar(MiDelegado del){
            del("Hola desde el invocador: ");
        }
    }

    public class claseA{
        public static void MetodoA(string msj)=>Console.WriteLine($"Llamando al metodo A de la clase A: {msj}");
    }

    public class claseB{
        public static void MetodoB(string msj)=>Console.WriteLine($"Llamando al metodo B de la clase B: {msj}");
    }
}
