using System;

namespace p24Interfaz2
{ 
    public class Organismo{
        public void Respiracion()=> Console.WriteLine("Respiración");
        public void Movimiento()=> Console.WriteLine("Movimiento");
        public void Crecimiento()=>Console.WriteLine("Crecimiento");
    }

    public interface IAnimales{
        void Mulyicelulares();
        void Sangrecaliente();
    }

    public interface ICanino: IAnimales{
        void Correr();
        void Cuatropatas();
    }

    public interface IPajaro: IAnimales{
        void Volar();
        void Dospatas();
    }

    public class Perro: Organismo, IAnimales, ICanino{
        public void Mulyicelulares()=>Console.WriteLine("Multicelular perro");
        public void Sangrecaliente()=>Console.WriteLine("Sangrecaliente perro");
        public void Correr()=>Console.WriteLine("Correr perro");
        public void Cuatropatas()=>Console.WriteLine("Cuatro patas del perro");
    }

    public class Perico: Organismo, IAnimales,IPajaro{
        public void Mulyicelulares()=>Console.WriteLine("Multicelular perico");
        public void Sangrecaliente()=>Console.WriteLine("Sangrecaliente perico");
        public void Volar()=>Console.WriteLine("El perico Vuela");
        public void Dospatas()=>Console.WriteLine("El perico tiene dos patas");
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\nSegundo ejemplo de interfaces: \n");

            Perro miperro = new Perro();
            Console.WriteLine("\nCaracteristicas del perro: ");
            miperro.Respiracion();
            miperro.Movimiento();
            miperro.Crecimiento();
            miperro.Mulyicelulares();
            miperro.Sangrecaliente();
            miperro.Correr();
            miperro.Cuatropatas();

            Perico miperico=new Perico();
            Console.WriteLine("\nCaracteristicas del perico: ");
            miperico.Respiracion();
            miperico.Movimiento();
            miperico.Crecimiento();
            miperico.Mulyicelulares();
            miperico.Sangrecaliente();
            miperico.Volar();
            miperico.Dospatas();


        }
    }
}
