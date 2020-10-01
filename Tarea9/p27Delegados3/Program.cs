using System;
//Ejemplo de delegados multicast con parametros
namespace p27Delegados3
{
    public delegate int MiDelegado(int a, int b);
    class Program
    {
        static void Main(string[] args)
        {
            MiDelegado d1=A.MetodoA;
            MiDelegado d2=B.MetodoB;
            Console.WriteLine($"la suma es:{d1(10,20)}");
            Console.WriteLine($"la multiplicación es:{d2(10,20)}");
            MiDelegado d=d1+d2;
            Console.WriteLine($"El resultado es: {d,(5,2)}");
        }
    }

    public class A{
        public static int MetodoA(int a,int b)=>a+b;
    }

    public class B{
        public static int MetodoB(int a,int b)=>a*b;
    }
}
